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

namespace Mesmerist.Medium.Guardian
{
    public class GuardianSpirit
    {
        private static readonly string FeatName = "GuardianSpirit";
        internal const string DisplayName = "GuardianSpirit.Name";
        private static readonly string Description = "GuardianSpirit.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);

        public static void Configure()
        {
            BuffConfigurator.New(FeatName + "Buff", Guids.GuardianBuff)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.ImitationFighterAbility.Reference.Get().Icon)
                .AddContextStatBonus(StatType.AC, ContextValues.Rank(), ModifierDescriptor.UntypedStackable)
                .AddContextStatBonus(StatType.SaveReflex, ContextValues.Rank(), ModifierDescriptor.UntypedStackable)
                .AddContextStatBonus(StatType.SaveFortitude, ContextValues.Rank(), ModifierDescriptor.UntypedStackable)
                .AddConcentrationBonus(value: ContextValues.Rank())
                .AddContextRankConfig(ContextRankConfigs.FeatureRank(Guids.SpiritBonus))
                .Configure();

            ActivatableAbilityConfigurator.New(FeatName, Guids.GuardianActivatableAbility)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetGroup((ActivatableAbilityGroup)(ExtentedActivatableAbilityGroup)1824)
                .SetIcon(AbilityRefs.ImitationFighterAbility.Reference.Get().Icon)
                .AddTriggerOnActivationChanged(actionList: ActionsBuilder.New()
                    .ApplyBuffPermanent(Guids.GuardianBuff, true, false, false, true, false, false, true)
                    .CastSpell(Guids.SharedSeanceGuardianAbility)
                    .Conditional(ConditionsBuilder.New().CasterHasFact(Guids.Lesser), ifTrue: ActionsBuilder.New().Add<ContextActionAddFact>(c =>
                    {
                        c.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(Guids.GuardianLesser);
                    }))
                    .Conditional(ConditionsBuilder.New().CasterHasFact(Guids.Intermediate), ifTrue: ActionsBuilder.New().Add<ContextActionAddFact>(c =>
                    {
                        c.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(Guids.GuardianIntermediate);
                    }))
                    .Conditional(ConditionsBuilder.New().CasterHasFact(Guids.Greater), ifTrue: ActionsBuilder.New().Add<ContextActionAddFact>(c =>
                    {
                        c.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(Guids.GuardianGreater);
                    }))
                    .Conditional(ConditionsBuilder.New().CasterHasFact(Guids.Supreme), ifTrue: ActionsBuilder.New().Add<ContextActionAddFact>(c =>
                    {
                        c.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(Guids.GuardianSupreme);
                    })),
                    stage: AddTriggerOnActivationChanged.Stage.OnSwitchOn)
                .AddTriggerOnActivationChanged(actionList: ActionsBuilder.New()
                    .RemoveBuff(Guids.GuardianBuff)
                    .RemoveBuff(Guids.SharedSeanceGuardianBuff)
                    .Conditional(ConditionsBuilder.New().CasterHasFact(Guids.Lesser), ifTrue: ActionsBuilder.New().Add<ContextActionRemoveFact>(c =>
                    {
                        c.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(Guids.GuardianLesser);
                    }))
                    .Conditional(ConditionsBuilder.New().CasterHasFact(Guids.Intermediate), ifTrue: ActionsBuilder.New().Add<ContextActionRemoveFact>(c =>
                    {
                        c.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(Guids.GuardianIntermediate);
                    }))
                    .Conditional(ConditionsBuilder.New().CasterHasFact(Guids.Greater), ifTrue: ActionsBuilder.New().Add<ContextActionRemoveFact>(c =>
                    {
                        c.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(Guids.GuardianGreater);
                    })).Conditional(ConditionsBuilder.New().CasterHasFact(Guids.Supreme), ifTrue: ActionsBuilder.New().Add<ContextActionRemoveFact>(c =>
                    {
                        c.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(Guids.GuardianSupreme);
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
