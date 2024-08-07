using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Mesmerist.Utils;
using Kingmaker.Enums;
using BlueprintCore.Utils.Types;
using CharacterOptionsPlus.Util;
using BlueprintCore.Actions.Builder;
using BlueprintCore.Conditions.Builder;
using Kingmaker.UnitLogic.Mechanics;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.EntitySystem.Stats;
using BlueprintCore.Conditions.Builder.ContextEx;

namespace Mesmerist.Medium.Hierophant
{
    public class HierophantSupreme
    {
        private static readonly string FeatName = "HierophantSupreme";
        internal const string DisplayName = "HierophantSupreme.Name";
        private static readonly string Description = "HierophantSupreme.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);

        public static void Configure()
        {
            BlueprintBuff overflowingbuff = BuffConfigurator.New(FeatName + "SacredBuff", Guids.HierophantSupremeSacred)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.ChannelEnergy.Reference.Get().Icon)
                .AddContextStatBonus(StatType.BaseAttackBonus, ContextValues.Rank(), ModifierDescriptor.Sacred)
                .AddIncreaseAllSpellsDC(ModifierDescriptor.Sacred, spellsOnly: true, value: ContextValues.Rank())
                .AddContextRankConfig(ContextRankConfigs.FeatureRank(Guids.SpiritBonus))
                .Configure();

            BlueprintBuff overflowingprofane = BuffConfigurator.New(FeatName + "ProfaneBuff", Guids.HierophantSupremeProfane)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.ChannelEnergy.Reference.Get().Icon)
                .AddContextStatBonus(StatType.BaseAttackBonus, ContextValues.Rank(), ModifierDescriptor.Profane)
                .AddIncreaseAllSpellsDC(ModifierDescriptor.Profane, spellsOnly: true, value: ContextValues.Rank())
                .AddContextRankConfig(ContextRankConfigs.FeatureRank(Guids.SpiritBonus))
                .Configure();

            FeatureConfigurator.New(FeatName, Guids.HierophantSupreme)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.ImitationFighterAbility.Reference.Get().Icon)
                .SetIcon(AbilityRefs.ChannelEnergy.Reference.Get().Icon)
                .AddOverHealTrigger(maxValue: new ContextValue()
                {
                    Value = 1,
                }, limitMaximum: true, actionOnTarget: ActionsBuilder.New().Conditional(ConditionsBuilder.New().IsAlly().HasFact(FeatureRefs.NegativeEnergyAffinity.Reference.Get(), true),
                    ifTrue: ActionsBuilder.New().ApplyBuff(buff: overflowingbuff, asChild: true, isFromSpell: false, isNotDispelable: true, toCaster: false, durationValue: ContextDuration.Fixed(5, DurationRate.Rounds))))
                .AddOverHealTrigger(maxValue: new ContextValue()
                {
                    Value = 1,
                }, limitMaximum: true, actionOnTarget: ActionsBuilder.New().Conditional(ConditionsBuilder.New().IsAlly().HasFact(FeatureRefs.LifeDominantSoul.Reference.Get()),
                    ifTrue: ActionsBuilder.New().ApplyBuff(buff: overflowingbuff, asChild: true, isFromSpell: false, isNotDispelable: true, toCaster: false, durationValue: ContextDuration.Fixed(5, DurationRate.Rounds))))
                .AddOverHealTrigger(maxValue: new ContextValue()
                {
                    Value = 1,
                }, limitMaximum: true, actionOnTarget: ActionsBuilder.New().Conditional(ConditionsBuilder.New().IsAlly().HasFact(FeatureRefs.NegativeEnergyAffinity.Reference.Get()),
                    ifTrue: ActionsBuilder.New().ApplyBuff(buff: overflowingprofane, asChild: true, isFromSpell: false, isNotDispelable: true, toCaster: false, durationValue: ContextDuration.Fixed(5, DurationRate.Rounds))))
                .Configure();
        }
    }
}
