using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using CharacterOptionsPlus.Util;
using Kingmaker.Blueprints;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Mesmerist.NewComponents;
using Mesmerist.Utils;
using System.Drawing;
using static Kingmaker.UnitLogic.Commands.Base.UnitCommand;
using Kingmaker.EntitySystem.Stats;
using BlueprintCore.Conditions.Builder.ContextEx;

namespace Mesmerist.Medium.Marshal
{
    public class MarshalLesser
    {
        private static readonly string FeatName = "MarshalLesser";
        internal const string DisplayName = "MarshalLesser.Name";
        private static readonly string Description = "MarshalLesser.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);
        public static void Configure()
        {
            var icon = BuffRefs.ArcaneAccuracyBuff.Reference.Get().Icon;

            BuffConfigurator.New(FeatName + "BuffD10", Guids.MarshalLesserBuffD10)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddComponent<ModifyD20AttackRoll>(c =>
                {
                    c.Bonus = ContextValues.Shared(AbilitySharedValue.Heal);
                    c.checkSpiritBonus = true;
                })
                .AddComponent<ModifyD20Concentration>(c =>
                {
                    c.Bonus = ContextValues.Shared(AbilitySharedValue.Heal);
                    c.checkSpiritBonus = true;
                })
                .AddComponent<ModifyD20SkillCheck>(c =>
                {
                    c.Bonus = ContextValues.Shared(AbilitySharedValue.Heal);
                    c.Skill = [StatType.SkillAthletics, StatType.SkillMobility,
                        StatType.SkillStealth, StatType.SkillThievery,
                        StatType.SkillKnowledgeArcana, StatType.SkillKnowledgeWorld,
                        StatType.SkillLoreNature, StatType.SkillLoreReligion,
                        StatType.SkillPerception,
                        StatType.SkillPersuasion, StatType.SkillUseMagicDevice];
                    c.checkSpiritBonus = true;
                })
                .AddComponent<ModifyD20SavingThrow>(c =>
                {
                    c.Bonus = ContextValues.Shared(AbilitySharedValue.Heal);
                    c.SavingThrowType = FlaggedSavingThrowType.All;
                    c.checkSpiritBonus = true;
                })
                .AddContextCalculateSharedValue(1,
                    ContextDice.Value(DiceType.D6, ContextValues.Constant(1)),
                    AbilitySharedValue.Heal)
                .SetIcon(icon)
                .Configure();

            BuffConfigurator.New(FeatName + "BuffD6", Guids.MarshalLesserBuffD6)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddComponent<ModifyD20AttackRoll>(c =>
                {
                    c.Bonus = ContextValues.Shared(AbilitySharedValue.Heal);
                    c.checkSpiritBonus = true;
                })
                .AddComponent<ModifyD20Concentration>(c =>
                {
                    c.Bonus = ContextValues.Shared(AbilitySharedValue.Heal);
                    c.checkSpiritBonus = true;
                })
                .AddComponent<ModifyD20SkillCheck>(c =>
                {
                    c.Bonus = ContextValues.Shared(AbilitySharedValue.Heal);
                    c.Skill = [StatType.SkillAthletics, StatType.SkillMobility,
                        StatType.SkillStealth, StatType.SkillThievery,
                        StatType.SkillKnowledgeArcana, StatType.SkillKnowledgeWorld,
                        StatType.SkillLoreNature, StatType.SkillLoreReligion,
                        StatType.SkillPerception,
                        StatType.SkillPersuasion, StatType.SkillUseMagicDevice];
                    c.checkSpiritBonus = true;
                })
                .AddComponent<ModifyD20SavingThrow>(c =>
                {
                    c.Bonus = ContextValues.Shared(AbilitySharedValue.Heal);
                    c.SavingThrowType = FlaggedSavingThrowType.All;
                    c.checkSpiritBonus = true;
                })
                .AddContextCalculateSharedValue(1,
                    ContextDice.Value(DiceType.D10, ContextValues.Constant(1)),
                    AbilitySharedValue.Heal)
                .SetIcon(icon)
                .Configure();

            BuffConfigurator.New(FeatName + "BuffD8", Guids.MarshalLesserBuffD8)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddComponent<ModifyD20AttackRoll>(c =>
                {
                    c.Bonus = ContextValues.Shared(AbilitySharedValue.Heal);
                    c.checkSpiritBonus = true;
                })
                .AddComponent<ModifyD20Concentration>(c =>
                {
                    c.Bonus = ContextValues.Shared(AbilitySharedValue.Heal);
                    c.checkSpiritBonus = true;
                })
                .AddComponent<ModifyD20SkillCheck>(c =>
                {
                    c.Bonus = ContextValues.Shared(AbilitySharedValue.Heal);
                    c.Skill = [StatType.SkillAthletics, StatType.SkillMobility,
                        StatType.SkillStealth, StatType.SkillThievery,
                        StatType.SkillKnowledgeArcana, StatType.SkillKnowledgeWorld,
                        StatType.SkillLoreNature, StatType.SkillLoreReligion,
                        StatType.SkillPerception,
                        StatType.SkillPersuasion, StatType.SkillUseMagicDevice];
                    c.checkSpiritBonus = true;
                })
                .AddComponent<ModifyD20SavingThrow>(c =>
                {
                    c.Bonus = ContextValues.Shared(AbilitySharedValue.Heal);
                    c.SavingThrowType = FlaggedSavingThrowType.All;
                    c.checkSpiritBonus = true;
                })
                .AddContextCalculateSharedValue(1,
                    ContextDice.Value(DiceType.D8, ContextValues.Constant(1)),
                    AbilitySharedValue.Heal)
                .SetIcon(icon)
                .Configure();

            AbilityConfigurator.New(FeatName + "Ability", Guids.MarshalLesserAbility)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(icon)
                .AddAbilityEffectRunAction(ActionsBuilder.New()
                .Conditional(
                    ConditionsBuilder.New().BuffRank(fact: Guids.SpiritSurge, useFactInsteadBuff: true,
                    rankValue: ContextValues.Constant(1)),
                    ifTrue: ActionsBuilder.New().ApplyBuffPermanent(Guids.MarshalLesserBuffD6))
                .Conditional(
                    ConditionsBuilder.New().BuffRank(fact: Guids.SpiritSurge, useFactInsteadBuff: true,
                    rankValue: ContextValues.Constant(2)),
                    ifTrue: ActionsBuilder.New().ApplyBuffPermanent(Guids.MarshalLesserBuffD8).RemoveBuff(Guids.MarshalLesserBuffD6))
                .Conditional(
                    ConditionsBuilder.New().BuffRank(fact: Guids.SpiritSurge, useFactInsteadBuff: true,
                    rankValue: ContextValues.Constant(3)),
                    ifTrue: ActionsBuilder.New().ApplyBuffPermanent(Guids.MarshalLesserBuffD10).RemoveBuff(Guids.MarshalLesserBuffD8)))
                .SetActionType(CommandType.Free)
                .SetRange(AbilityRange.Close)
                .SetCanTargetFriends(true)
                .SetCanTargetEnemies(false)
                .Configure();

            FeatureConfigurator.New(FeatName, Guids.MarshalLesser)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddFacts(new() { Guids.MarshalLesserAbility })
                .Configure();
        }
    }
}
