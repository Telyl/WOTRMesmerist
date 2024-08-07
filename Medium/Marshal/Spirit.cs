using BlueprintCore.Blueprints.References;
using Kingmaker.EntitySystem.Stats;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using Mesmerist.Utils;
using Kingmaker.Enums;
using BlueprintCore.Utils.Types;
using CharacterOptionsPlus.Util;
using Kingmaker.Blueprints;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Actions.Builder;
using BlueprintCore.Conditions.Builder;
using Kingmaker.UnitLogic.FactLogic;
using BlueprintCore.Utils;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Conditions.Builder.ContextEx;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Commands.Base;
using Mesmerist.NewActions;
using static TabletopTweaks.Core.MechanicsChanges.AdditionalActivatableAbilityGroups;

namespace Mesmerist.Medium.Marshal
{
    public class MarshalSpirit
    {
        private static readonly string FeatName = "MarshalSpirit";
        internal const string DisplayName = "MarshalSpirit.Name";
        private static readonly string Description = "MarshalSpirit.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);

        public static void Configure()
        {
            BuffConfigurator.New(FeatName + "Buff", Guids.MarshalBuff)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.Nurah_InspirecourageAbility.Reference.Get().Icon)
                .AddContextStatBonus(StatType.SkillUseMagicDevice, ContextValues.Rank(), ModifierDescriptor.UntypedStackable)
                .AddContextStatBonus(StatType.SkillPersuasion, ContextValues.Rank(), ModifierDescriptor.UntypedStackable)
                .AddConcentrationBonus(value: ContextValues.Rank())
                .AddContextRankConfig(ContextRankConfigs.FeatureRank(Guids.SpiritBonus))
                .Configure();

            ActivatableAbilityConfigurator.New(FeatName, Guids.MarshalActivatableAbility)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetGroup((ActivatableAbilityGroup)(ExtentedActivatableAbilityGroup)1824)
                .SetIcon(AbilityRefs.Nurah_InspirecourageAbility.Reference.Get().Icon)
                .AddTriggerOnActivationChanged(actionList: ActionsBuilder.New()
                    .ApplyBuffPermanent(Guids.MarshalBuff, true, false, false, true, false, false, true)
                    .CastSpell(Guids.SharedSeanceMarshalAbility)
                    .Conditional(ConditionsBuilder.New().CasterHasFact(Guids.Lesser), ifTrue: ActionsBuilder.New().Add<ContextActionAddFact>(c =>
                    {
                        c.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(Guids.MarshalLesser);
                    }))
                    .Conditional(ConditionsBuilder.New().CasterHasFact(Guids.Intermediate), ifTrue: ActionsBuilder.New().Add<ContextActionAddFact>(c =>
                    {
                        c.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(Guids.MarshalIntermediateStandard);
                    }))
                    .Conditional(ConditionsBuilder.New().CasterHasFact(Guids.Greater), ifTrue: ActionsBuilder.New().Add<ContextActionAddFact>(c =>
                    {
                        c.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(Guids.MarshalGreater);
                    }).Add<ContextActionAddFact>(c =>
                    {
                        c.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(Guids.MarshalIntermediateMove);
                    }))
                    .Conditional(ConditionsBuilder.New().CasterHasFact(Guids.Supreme), ifTrue: ActionsBuilder.New().Add<ContextActionAddFact>(c =>
                    {
                        c.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(Guids.MarshalSupreme);
                    }).Add<ContextActionAddFact>(c =>
                    {
                        c.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(Guids.MarshalIntermediateSwift);
                    })),
                    stage: AddTriggerOnActivationChanged.Stage.OnSwitchOn)
                .AddTriggerOnActivationChanged(actionList: ActionsBuilder.New()
                    .RemoveBuff(Guids.MarshalBuff)
                    .RemoveBuff(Guids.SharedSeanceMarshalBuff)
                    .Conditional(ConditionsBuilder.New().CasterHasFact(Guids.Lesser), ifTrue: ActionsBuilder.New().Add<ContextActionRemoveFact>(c =>
                    {
                        c.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(Guids.MarshalLesser);
                    }))
                    .Conditional(ConditionsBuilder.New().CasterHasFact(Guids.Intermediate), ifTrue: ActionsBuilder.New().Add<ContextActionRemoveFact>(c =>
                    {
                        c.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(Guids.MarshalIntermediateStandard);
                    }))
                    .Conditional(ConditionsBuilder.New().CasterHasFact(Guids.Greater), ifTrue: ActionsBuilder.New().Add<ContextActionRemoveFact>(c =>
                    {
                        c.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(Guids.MarshalGreater);
                    }).Add<ContextActionRemoveFact>(c =>
                    {
                        c.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(Guids.MarshalIntermediateMove);
                    }))
                    .Conditional(ConditionsBuilder.New().CasterHasFact(Guids.Supreme), ifTrue: ActionsBuilder.New().Add<ContextActionRemoveFact>(c =>
                    {
                        c.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(Guids.MarshalSupreme);
                    }).Add<ContextActionRemoveFact>(c =>
                    {
                        c.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(Guids.MarshalIntermediateSwift);
                    })),
                    stage: AddTriggerOnActivationChanged.Stage.OnSwitchOff)
                .AddActionPanelLogic(
                autoFillConditions:
                    ConditionsBuilder.New().CharacterClass(false, Guids.Medium, 0, true))
                .SetDeactivateImmediately()
                .SetActivationType(AbilityActivationType.Immediately)
                .SetActivateWithUnitCommand(UnitCommand.CommandType.Free)
                .Configure();
        }
    }
}
