using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Classes;
using Kingmaker.EntitySystem.Stats;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using Mesmerist.Utils;
using static UnityModManagerNet.UnityModManager.ModEntry;
using System;
using Kingmaker.Enums;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints.Classes.Prerequisites;
using CharacterOptionsPlus.Util;
using Mesmerist.NewComponents;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using TabletopTweaks.Core.Utilities;
using System.Linq;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.UnitLogic.Mechanics.Properties;
using BlueprintCore.Blueprints.Configurators.UnitLogic.Properties;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using TabletopTweaks.Core.NewComponents;
using HarmonyLib;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Mechanics;
using static TabletopTweaks.Core.MechanicsChanges.MetamagicExtention;
using TabletopTweaks.Core.MechanicsChanges;
using static Kingmaker.GameModes.GameModeType;
using Kingmaker.UnitLogic.Mechanics.Conditions;
using Kingmaker.EntitySystem.Entities;

namespace Mesmerist.Mesmerist
{
    public class MentalPotency
    {
        private static readonly string FeatName = "MentalPotency";
        internal const string DisplayName = "MentalPotency.Name";
        private static readonly string Description = "MentalPotency.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);

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
                        __result = unit != null && unit.Descriptor.Progression.CharacterLevel <= __instance.HitDice  + rank;
                    }
                }
            }
        }
    }
}
