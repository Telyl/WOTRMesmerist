using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.BasicEx;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Designers;
using Kingmaker.Designers.EventConditionActionSystem.Evaluators;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.UnitLogic.Mechanics.Components;
using Mesmerist.NewConditions;
using Mesmerist.NewContexts;
using Mesmerist.Utils;
using TabletopTweaks.Core;
using TabletopTweaks.Core.NewActions;
using TabletopTweaks.Core.NewComponents;
using TabletopTweaks.Core.NewComponents.OwlcatReplacements;
using UniRx;
using static Kingmaker.Blueprints.Area.FactHolder;

namespace Mesmerist.Class
{
    internal class PainfulStare
    {
        private static readonly string FeatName = "PainfulStare";
        internal const string DisplayName = "PainfulStare.Name";
        private static readonly string Description = "PainfulStare.Description";
        public static void Configure()
        {
            var ActionsList = ActionsBuilder.New().Add<ContextActionApplyBuffRanks>(c =>
            {
                c.IsFromSpell = false;
                c.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(Guids.PainfulStareBuff);
                c.Rank = new ContextValue()
                {
                    ValueType = ContextValueType.Rank,
                    ValueRank = AbilityRankType.Default,
                };
                c.Permanent = true;
            }).Build();

            // Painful Stare Feature Rank
            var PainfulStare = FeatureConfigurator.New(FeatName, Guids.PainfulStare)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetRanks(4)
                .SetIsClassFeature(true)
                .AddContextRankConfig(ContextRankConfigs.FeatureRank(Guids.PainfulStare, type: AbilityRankType.Default))
                .AddNewRoundTrigger(newRoundActions: ActionsBuilder.New().Add<ContextActionOnEnemiesWithFact>(c =>
                {
                    c.FactToCheck = BlueprintTool.GetRef<BlueprintUnitFactReference>(Guids.HypnoticStareBuff);
                    c.Action = ActionsList;
                }))
                .Configure();

            // Painful Stare Buff
            BuffConfigurator.New(FeatName + "Buff", Guids.PainfulStareBuff)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetRanks(4)
                .SetStacking(StackingType.Rank)
                .SetFlags(BlueprintBuff.Flags.HiddenInUi)
                .AddUniqueBuff()
                .AddContextRankConfig(ContextRankConfigs.ClassLevel(new[] { Guids.Mesmerist }, type: AbilityRankType.DamageBonus).WithStartPlusDivStepProgression(2, 2))
                .AddContextRankConfig(ContextRankConfigs.ClassLevel(new[] { Guids.Mesmerist }, type: AbilityRankType.DamageDice).WithStartPlusDivStepProgression(3,3, true))
                .AddIncomingDamageTrigger(actions: ActionsBuilder.New().Conditional(ConditionsBuilder.New().Add<ContextConditionInitiatorHasFact>(c =>
                {
                    c.FactToCheck = BlueprintTool.GetRef<BlueprintUnitFactReference>(Guids.PainfulStare);
                }), ifTrue: ActionsBuilder.New().DealDamage(new DamageTypeDescription() { Type = DamageType.Direct }, new ContextDiceValue()
                {
                    DiceType = DiceType.D6,
                    DiceCountValue = new ContextValue()
                    {
                        ValueType = ContextValueType.Rank,
                        ValueRank = AbilityRankType.DamageDice,
                    },
                    BonusValue = new ContextValue()
                    {
                        ValueType = ContextValueType.Rank,
                        ValueRank = AbilityRankType.DamageBonus,
                    }
                }, setFactAsReason: true, ignoreCritical: true),
                ifFalse: ActionsBuilder.New().DealDamage(new DamageTypeDescription() { Type = DamageType.Direct }, new ContextDiceValue()
                        {
                            DiceType = DiceType.One,
                            DiceCountValue = 0,
                            BonusValue = new ContextValue()
                            {
                                ValueType = ContextValueType.Rank,
                                ValueRank = AbilityRankType.DamageBonus,
                            }
                        }, setFactAsReason: true, ignoreCritical: true)).RemoveBuff(Guids.PainfulStareBuff, removeRank: true), ignoreDamageFromThisFact: true)
                .Configure();
        }
    }
}
