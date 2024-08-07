using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using BlueprintCore.Utils;
using CharacterOptionsPlus.Util;
using Kingmaker.Blueprints;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.Utility;
using Mesmerist.Utils;
using Kingmaker.EntitySystem.Stats;
using BlueprintCore.Actions.Builder.ContextEx;
using Kingmaker.UnitLogic.Abilities.Components;

namespace Mesmerist.Medium.Marshal
{
    public class MarshalIntermediate
    {
        private static readonly string FeatName = "MarshalIntermediate";
        internal const string DisplayName = "MarshalIntermediate.Name";
        private static readonly string Description = "MarshalIntermediate.Description";
        internal const string DisplayNameSaves = "MarshalIntermediateSaves.Name";
        internal const string DisplayNameAttack = "MarshalIntermediateAttack.Name";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);
        public static void Configure()
        {
            var icon = AbilityRefs.ArcanistExploitIceMissileAbility.Reference.Get().Icon;

            var savingthrowsbuff = BuffConfigurator.New(FeatName + "SavingThrowBuff", Guids.MarshalIntermediateAbilityBuffSavingThrow)
                .SetDisplayName(DisplayNameSaves)
                .SetDescription(Description)
                .SetIcon(icon)
                .SetFxOnStart(fxOnStart: "a68e191c519cae741b6c4177b4d13ef6")
                .AddContextStatBonus(StatType.SaveFortitude, ContextValues.Rank(), ModifierDescriptor.Competence)
                .AddContextStatBonus(StatType.SaveReflex, ContextValues.Rank(), ModifierDescriptor.Competence)
                .AddContextStatBonus(StatType.SaveWill, ContextValues.Rank(), ModifierDescriptor.Competence)
                .AddContextRankConfig(ContextRankConfigs.FeatureRank(Guids.SpiritBonus))
                .Configure();

            var attackbuff = BuffConfigurator.New(FeatName +"AttackBuff", Guids.MarshalIntermediateAbilityBuffAttackDamage)
                .SetDisplayName(DisplayNameAttack)
                .SetDescription(Description)
                .SetIcon(icon)
                .SetFxOnStart(fxOnStart: "a68e191c519cae741b6c4177b4d13ef6")
                .AddContextStatBonus(StatType.AdditionalAttackBonus, ContextValues.Rank(), ModifierDescriptor.Competence)
                .AddContextStatBonus(StatType.AdditionalDamage, ContextValues.Rank(), ModifierDescriptor.Competence)
                .AddContextRankConfig(ContextRankConfigs.FeatureRank(Guids.SpiritBonus))
                .Configure();

            var savingthrowabilityswift = AbilityConfigurator.New(FeatName + "SavingThrowAbilitySwift", Guids.MarshalIntermediateAbilitySavingSwift)
                .SetDisplayName(DisplayNameSaves)
                .SetDescription(Description)
                .SetIcon(icon)
                .AddAbilityEffectRunAction(actions: ActionsBuilder.New().ApplyBuff(savingthrowsbuff, durationValue: ContextDuration.Fixed(1, DurationRate.Rounds)))
                .AddAbilityTargetsAround(radius: FeetExtension.Feet(50), spreadSpeed: FeetExtension.Feet(0), targetType: TargetType.Ally)
                .SetActionType(UnitCommand.CommandType.Swift)
                .Configure();

            var attackabilityswift = AbilityConfigurator.New(FeatName + "AttackAbilitySwift", Guids.MarshalIntermediateAbilityAttackSwift)
                .SetDisplayName(DisplayNameAttack)
                .SetDescription(Description)
                .SetIcon(icon)
                .AddAbilityEffectRunAction(actions: ActionsBuilder.New().ApplyBuff(attackbuff, durationValue: ContextDuration.Fixed(1, DurationRate.Rounds)))
                .AddAbilityTargetsAround(radius: FeetExtension.Feet(50), spreadSpeed: FeetExtension.Feet(0), targetType: TargetType.Ally)
                .SetActionType(UnitCommand.CommandType.Swift)
                .Configure();

            var savingthrowabilitymove = AbilityConfigurator.New(FeatName + "SavingThrowAbilityMove", Guids.MarshalIntermediateAbilitySavingMove)
                .SetDisplayName(DisplayNameSaves)
                .SetDescription(Description)
                .SetIcon(icon)
                .AddAbilityEffectRunAction(actions: ActionsBuilder.New().ApplyBuff(savingthrowsbuff, durationValue: ContextDuration.Fixed(1, DurationRate.Rounds)))
                .AddAbilityTargetsAround(radius: FeetExtension.Feet(50), spreadSpeed: FeetExtension.Feet(0), targetType: TargetType.Ally)
                .SetActionType(UnitCommand.CommandType.Move)
                .Configure();

            var attackabilitymove = AbilityConfigurator.New(FeatName + "AttackAbilityMove", Guids.MarshalIntermediateAbilityAttackMove)
                .SetDisplayName(DisplayNameAttack)
                .SetDescription(Description)
                .SetIcon(icon)
                .AddAbilityEffectRunAction(actions: ActionsBuilder.New().ApplyBuff(attackbuff, durationValue: ContextDuration.Fixed(1, DurationRate.Rounds)))
                .AddAbilityTargetsAround(radius: FeetExtension.Feet(50), spreadSpeed: FeetExtension.Feet(0), targetType: TargetType.Ally)
                .SetActionType(UnitCommand.CommandType.Move)
                .Configure();

            var savingthrowabilitystandard = AbilityConfigurator.New(FeatName + "SavingThrowAbilityStandard", Guids.MarshalIntermediateAbilitySavingStandard)
                .SetDisplayName(DisplayNameSaves)
                .SetDescription(Description)
                .SetIcon(icon)
                .AddAbilityEffectRunAction(actions: ActionsBuilder.New().ApplyBuff(savingthrowsbuff, durationValue: ContextDuration.Fixed(1, DurationRate.Rounds)))
                .AddAbilityTargetsAround(radius: FeetExtension.Feet(50), spreadSpeed: FeetExtension.Feet(0), targetType: TargetType.Ally)
                .Configure();

            var attackabilitystandard = AbilityConfigurator.New(FeatName + "AttackAbilityStandard", Guids.MarshalIntermediateAbilityAttackStandard)
                .SetDisplayName(DisplayNameAttack)
                .SetDescription(Description)
                .SetIcon(icon)
                .AddAbilityEffectRunAction(actions: ActionsBuilder.New().ApplyBuff(attackbuff, durationValue: ContextDuration.Fixed(1, DurationRate.Rounds)))
                .AddAbilityTargetsAround(radius: FeetExtension.Feet(50), spreadSpeed: FeetExtension.Feet(0), targetType: TargetType.Ally)
                .Configure();

            var abilityswift = AbilityConfigurator.New(FeatName + "AbilitySwift", Guids.MarshalIntermediateAbilitySwift)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(icon)
                .SetActionType(UnitCommand.CommandType.Free)
                .AddAbilityVariants(new() { savingthrowabilityswift, attackabilityswift })
                .Configure();

            var abilitymove = AbilityConfigurator.New(FeatName + "AbilityMove", Guids.MarshalIntermediateAbilityMove)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(icon)
                .SetActionType(UnitCommand.CommandType.Free)
                .AddAbilityVariants(new() { savingthrowabilitymove, attackabilitymove })
                .Configure();

            var ability = AbilityConfigurator.New(FeatName + "AbilityStandard", Guids.MarshalIntermediateAbilityStandard)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(icon)
                .SetActionType(UnitCommand.CommandType.Free)
                .AddAbilityVariants(new() { savingthrowabilitystandard, attackabilitystandard })
                .Configure();

            FeatureConfigurator.New(FeatName + "Swift", Guids.MarshalIntermediateSwift)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(BuffRefs.InspireCompetenceEffectBuff.Reference.Get().Icon)
                .AddFacts(new() { abilityswift })
                .Configure();

            FeatureConfigurator.New(FeatName + "Move", Guids.MarshalIntermediateMove)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(BuffRefs.InspireCompetenceEffectBuff.Reference.Get().Icon)
                .AddFacts(new() { abilitymove })
                .Configure();

            FeatureConfigurator.New(FeatName + "Standard", Guids.MarshalIntermediateStandard)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(BuffRefs.InspireCompetenceEffectBuff.Reference.Get().Icon)
                .AddFacts(new() { ability })
                .Configure();
        }
    }
}
