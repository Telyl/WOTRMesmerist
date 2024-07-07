using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.Enums.Damage;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Components;
using Mesmerist.Utils;
using Mesmerist.NewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UnityModManagerNet.UnityModManager.ModEntry;
using CharacterOptionsPlus.Util;
using BlueprintCore.Actions.Builder.BasicEx;

namespace Mesmerist.Mesmerist
{
    class PainfulStare
    {
        private static readonly string FeatName = "PainfulStare";
        private static readonly string DisplayName = "PainfulStare.Name";
        private static readonly string Description = "PainfulStare.Description";
        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);

        public static object Value { get; private set; }

        public static void Configure()
        {
            BuffConfigurator.New(FeatName + "StaticCooldown", Guids.PainfulStareStaticCooldown)
                .SetFlags(BlueprintBuff.Flags.HiddenInUi | BlueprintBuff.Flags.RemoveOnRest)
                .SetStacking(StackingType.Replace)
                .SetDescription(Description)
                .SetDisplayName(DisplayName)
                .SetIcon(AbilityRefs.WitchHexEvilEyeACAbility.Reference.Get().Icon)
                .SetRanks(0)
                .Configure();

            BuffConfigurator.New(FeatName + "Cooldown", Guids.PainfulStareCooldown)
                .SetFlags(BlueprintBuff.Flags.HiddenInUi | BlueprintBuff.Flags.RemoveOnRest)
                .SetStacking(StackingType.Replace)
                .SetDescription(Description)
                .SetDisplayName(DisplayName)
                .SetIcon(AbilityRefs.WitchHexEvilEyeACAbility.Reference.Get().Icon)
                .SetRanks(0)
                .Configure();

            var PainfulStare = FeatureConfigurator.New(FeatName, Guids.PainfulStare)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.WitchHexEvilEyeAttackAbility.Reference.Get().Icon)
                .SetIsClassFeature(true)
                .SetReapplyOnLevelUp(false)
                .SetRanks(10)
                .Configure();

            FeatureConfigurator.For(PainfulStare)
                .AddInitiatorAttackRollTrigger(action: ActionsBuilder.New().Conditional(ConditionsBuilder.New().HasBuff(Guids.HypnoticStareBuff).HasBuff(Guids.PainfulStareCooldown,true),
                ifTrue: ActionsBuilder.New().ApplyBuff(Guids.PainfulStareCooldown, ContextDuration.Fixed(1)).DealDamage(new DamageTypeDescription()
                {
                    Type = DamageType.Physical,
                    Common =
                    {
                        Precision = true
                    },
                    Physical =
                    {
                        Form = PhysicalDamageForm.Slashing & PhysicalDamageForm.Piercing & PhysicalDamageForm.Bludgeoning
                    }
                }, ContextDice.Value(DiceType.D6, ContextValues.Rank()), disableSneakDamage: true, ignoreCritical: true)), onlyHit: true)
                .AddContextRankConfig(new ContextRankConfig
                {
                    m_Type = AbilityRankType.Default,
                    m_BaseValueType = ContextRankBaseValueType.FeatureRank,
                    m_Feature = PainfulStare.ToReference<BlueprintFeatureReference>(),
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
    }
}