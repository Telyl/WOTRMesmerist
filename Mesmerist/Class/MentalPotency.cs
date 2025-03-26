using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.EntitySystem.Stats;
using Mesmerist.Utils;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Mechanics.Components;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using HarmonyLib;
using Kingmaker.UnitLogic.Mechanics.Conditions;
using Kingmaker.EntitySystem.Entities;

namespace Mesmerist.Class
{
    public class MentalPotency
    {
        private static readonly string FeatName = "MentalPotency";
        internal const string DisplayName = "MentalPotency.Name";
        private static readonly string Description = "MentalPotency.Description";
        public static void Configure() 
        {

            var MentalPotency = FeatureConfigurator.New(FeatName, Guids.MentalPotency)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIsClassFeature()
                .SetIcon(AbilityRefs.PowerWordBlind.Reference.Get().Icon)
                .SetRanks(4)
                .Configure();

            FeatureConfigurator.For(Guids.MentalPotency)
                .AddContextRankConfig(new ContextRankConfig
                {
                    m_Type = AbilityRankType.Default,
                    m_BaseValueType = ContextRankBaseValueType.FeatureRank,
                    m_Feature = MentalPotency.ToReference<BlueprintFeatureReference>(),
                    m_Stat = StatType.Unknown,
                    m_Buff = null,
                    m_Progression = ContextRankProgression.AsIs,
                    m_StartLevel = 0,
                    m_StepLevel = 0,
                    m_UseMin = false,
                    m_Min = 0,
                    m_UseMax = false,
                    m_Max = 20,
                    m_ExceptClasses = false,
                    Archetype = null
                })
                .Configure();
        }


        [HarmonyPatch(typeof(ContextConditionHitDice), nameof(ContextConditionHitDice.CheckCondition))]
        static class ContextConditionHitDice_MentalPotency_Patch
        {
            static void Postfix(ContextConditionHitDice __instance, ref bool __result)
            {
                if (__instance.Context.MaybeCaster == null) { return; }
                int rank = __instance.Context.MaybeCaster.Progression.Features.GetRank(BlueprintTool.GetRef<BlueprintFeatureReference>(Guids.MentalPotency));
                var contextOwner = __instance.Context.MaybeOwner;
                bool awesomeDisplay = contextOwner.Progression.Features.HasFact(BlueprintTool.GetRef<BlueprintFeatureReference>(Guids.MythicAwesomeDisplay));
                int awesomeDisplay_cha = contextOwner.Stats.Charisma.Bonus;

                UnitEntityData unit = __instance.Target.Unit;
                int num = __instance.Context[__instance.SharedValue];
                if (__instance.AddSharedValue)
                {
                    if (awesomeDisplay)
                    {
                        __result = unit != null && (unit.Descriptor.Progression.CharacterLevel - awesomeDisplay_cha) <= __instance.HitDice + num + rank;
                    }
                    else
                    {
                        __result = unit != null && unit.Descriptor.Progression.CharacterLevel <= __instance.HitDice + num + rank;
                    }
                }
                else
                {
                    if (awesomeDisplay)
                    {
                        __result = unit != null && (unit.Descriptor.Progression.CharacterLevel - awesomeDisplay_cha) <= __instance.HitDice + rank;
                    }
                    else
                    {
                        __result = unit != null && unit.Descriptor.Progression.CharacterLevel <= __instance.HitDice + rank;
                    }
                }
            }
        }
    }
}