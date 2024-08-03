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

namespace Mesmerist.Medium.Archmage
{
    public class ArchmageSpirit
    {
        private static readonly string FeatName = "ArchmageSpirit";
        internal const string DisplayName = "ArchmageSpirit.Name";
        private static readonly string Description = "ArchmageSpirit.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);

        public static void Configure()
        {
            BuffConfigurator.New(FeatName + "Buff", Guids.ArchmageBuff)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.TricksterSummonPerpetuallyAnnoyedWizard.Reference.Get().Icon)
                .AddContextStatBonus(StatType.SkillKnowledgeArcana, ContextValues.Rank(), ModifierDescriptor.UntypedStackable)
                .AddContextStatBonus(StatType.SkillKnowledgeWorld, ContextValues.Rank(), ModifierDescriptor.UntypedStackable)
                .AddConcentrationBonus(value: ContextValues.Rank())
                .AddContextRankConfig(ContextRankConfigs.FeatureRank(Guids.SpiritBonus))
                .Configure();

            ActivatableAbilityConfigurator.New(FeatName, Guids.ArchmageActivatableAbility)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.TricksterSummonPerpetuallyAnnoyedWizard.Reference.Get().Icon)
                .AddTriggerOnActivationChanged(actionList: ActionsBuilder.New()
                    .ApplyBuffPermanent(Guids.ArchmageBuff, true, false, false, true, false, false, true)
                    .CastSpell(Guids.SharedSeanceArchmageAbility)
                    .Conditional(ConditionsBuilder.New().CasterHasFact(Guids.Lesser), ifTrue: ActionsBuilder.New().Add<ContextActionRemoveFact>(c =>
                    {
                        c.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(Guids.ProhibitArchmageSpellbook);
                    }))
                    .Conditional(ConditionsBuilder.New().CasterHasFact(Guids.Intermediate), ifTrue: ActionsBuilder.New().Add<ContextActionAddFact>(c =>
                    {
                        c.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(Guids.ArchmageIntermediate);
                    }))
                    .Conditional(ConditionsBuilder.New().CasterHasFact(Guids.Greater), ifTrue: ActionsBuilder.New().Add<ContextActionAddFact>(c =>
                    {
                        c.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(Guids.ArchmageGreater);
                    }))
                    .Conditional(ConditionsBuilder.New().CasterHasFact(Guids.Supreme), ifTrue: ActionsBuilder.New().Add<ContextActionAddFact>(c =>
                    {
                        c.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(Guids.ArchmageSupreme);
                    })),
                    stage: AddTriggerOnActivationChanged.Stage.OnSwitchOn)
                .AddTriggerOnActivationChanged(actionList: ActionsBuilder.New()
                    .RemoveBuff(Guids.ArchmageBuff)
                    .RemoveBuff(Guids.SharedSeanceArchmageBuff)
                    .Conditional(ConditionsBuilder.New().CasterHasFact(Guids.Lesser), ifTrue: ActionsBuilder.New().Add<ContextActionAddFact>(c =>
                    {
                        c.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(Guids.ProhibitArchmageSpellbook);
                    }))
                    .Conditional(ConditionsBuilder.New().CasterHasFact(Guids.Intermediate), ifTrue: ActionsBuilder.New().Add<ContextActionRemoveFact>(c =>
                    {
                        c.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(Guids.ArchmageIntermediate);
                    }))
                    .Conditional(ConditionsBuilder.New().CasterHasFact(Guids.Greater), ifTrue: ActionsBuilder.New().Add<ContextActionRemoveFact>(c =>
                    {
                        c.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(Guids.ArchmageGreater);
                    })).Conditional(ConditionsBuilder.New().CasterHasFact(Guids.Supreme), ifTrue: ActionsBuilder.New().Add<ContextActionRemoveFact>(c =>
                    {
                        c.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(Guids.ArchmageSupreme);
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
