using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Utils.Types;
using CharacterOptionsPlus.Util;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Mechanics;
using Mesmerist.Utils;
using static Kingmaker.UnitLogic.FactLogic.AddMechanicsFeature;

namespace Mesmerist.Medium.Hierophant
{
    public class HierophantGreater
    {
        private static readonly string FeatName = "HierophantGreater";
        internal const string DisplayName = "HierophantGreater.Name";
        private static readonly string Description = "HierophantGreater.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);
        public static void Configure()
        {
            Logger.Log("Generating Hierophant Overflowing Grace");
            BlueprintBuff overflowingbuff = BuffConfigurator.New(FeatName + "SacredBuff", Guids.HierophantGreaterSacred)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.ChannelEnergy.Reference.Get().Icon)
                .AddContextStatBonus(StatType.AdditionalAttackBonus, ContextValues.Rank(), ModifierDescriptor.Sacred)
                .AddContextStatBonus(StatType.SaveReflex, ContextValues.Rank(), ModifierDescriptor.Sacred)
                .AddContextStatBonus(StatType.SaveWill, ContextValues.Rank(), ModifierDescriptor.Sacred)
                .AddContextStatBonus(StatType.SaveFortitude, ContextValues.Rank(), ModifierDescriptor.Sacred)
                .AddBuffAllSkillsBonus(ModifierDescriptor.Sacred, ContextValues.Rank(), 1)
                .AddContextRankConfig(ContextRankConfigs.FeatureRank(Guids.SpiritBonus))
                .Configure();

            BlueprintBuff overflowingprofane = BuffConfigurator.New(FeatName + "ProfaneBuff", Guids.HierophantGreaterProfane)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.ChannelEnergy.Reference.Get().Icon)
                .AddContextStatBonus(StatType.AdditionalAttackBonus, ContextValues.Rank(), ModifierDescriptor.Profane)
                .AddContextStatBonus(StatType.SaveReflex, ContextValues.Rank(), ModifierDescriptor.Profane)
                .AddContextStatBonus(StatType.SaveWill, ContextValues.Rank(), ModifierDescriptor.Profane)
                .AddContextStatBonus(StatType.SaveFortitude, ContextValues.Rank(), ModifierDescriptor.Profane)
                .AddBuffAllSkillsBonus(ModifierDescriptor.Profane, ContextValues.Rank(), 1)
                .AddContextRankConfig(ContextRankConfigs.FeatureRank(Guids.SpiritBonus))
                .Configure();

            FeatureConfigurator.New(FeatName, Guids.HierophantGreater)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
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
