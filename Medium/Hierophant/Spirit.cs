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

namespace Mesmerist.Medium.Hierophant
{
    public class HierophantSpirit
    {
        private static readonly string FeatName = "HierophantSpirit";
        internal const string DisplayName = "HierophantSpirit.Name";
        private static readonly string Description = "HierophantSpirit.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);

        public static void Configure()
        {
            BuffConfigurator.New(FeatName + "Buff", Guids.HierophantBuff)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.HealMass.Reference.Get().Icon)
                .AddContextStatBonus(StatType.SkillLoreNature, ContextValues.Rank(), ModifierDescriptor.UntypedStackable)
                .AddContextStatBonus(StatType.SkillLoreReligion, ContextValues.Rank(), ModifierDescriptor.UntypedStackable)
                .AddContextStatBonus(StatType.SkillPerception, ContextValues.Rank(), ModifierDescriptor.UntypedStackable)
                .AddContextStatBonus(StatType.SaveWill, ContextValues.Rank(), ModifierDescriptor.UntypedStackable)
                .AddConcentrationBonus(value: ContextValues.Rank())
                .AddContextRankConfig(ContextRankConfigs.FeatureRank(Guids.SpiritBonus))
                .Configure();

            ActivatableAbilityConfigurator.New(FeatName, Guids.HierophantActivatableAbility)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetGroup((ActivatableAbilityGroup)(ExtentedActivatableAbilityGroup)1824)
                .SetIcon(AbilityRefs.HealMass.Reference.Get().Icon)
                .AddTriggerOnActivationChanged(actionList: ActionsBuilder.New()
                    .ApplyBuffPermanent(Guids.HierophantBuff, true, false, false, true, false, false, true)
                    .CastSpell(Guids.SharedSeanceHierophantAbility)
                    .Conditional(ConditionsBuilder.New().CasterHasFact(Guids.Lesser), ifTrue: ActionsBuilder.New().Add<ContextActionRemoveFact>(c =>
                    {
                        c.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(Guids.ProhibitHierophantSpellbook);
                    }))
                    .Conditional(ConditionsBuilder.New().CasterHasFact(Guids.Intermediate), ifTrue: ActionsBuilder.New().Add<ContextActionAddFact>(c =>
                    {
                        c.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(Guids.HierophantIntermediate);
                    }))
                    .Conditional(ConditionsBuilder.New().CasterHasFact(Guids.Greater), ifTrue: ActionsBuilder.New().Add<ContextActionAddFact>(c =>
                    {
                        c.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(Guids.HierophantGreater);
                    }))
                    .Conditional(ConditionsBuilder.New().CasterHasFact(Guids.Supreme), ifTrue: ActionsBuilder.New().Add<ContextActionAddFact>(c =>
                    {
                        c.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(Guids.HierophantSupreme);
                    })),
                    stage: AddTriggerOnActivationChanged.Stage.OnSwitchOn)
                .AddTriggerOnActivationChanged(actionList: ActionsBuilder.New()
                    .RemoveBuff(Guids.HierophantBuff)
                    .RemoveBuff(Guids.SharedSeanceHierophantBuff)
                    .Conditional(ConditionsBuilder.New().CasterHasFact(Guids.Lesser), ifTrue: ActionsBuilder.New().Add<ContextActionAddFact>(c =>
                    {
                        c.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(Guids.ProhibitHierophantSpellbook);
                    }))
                    .Conditional(ConditionsBuilder.New().CasterHasFact(Guids.Intermediate), ifTrue: ActionsBuilder.New().Add<ContextActionRemoveFact>(c =>
                    {
                        c.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(Guids.HierophantIntermediate);
                    }))
                    .Conditional(ConditionsBuilder.New().CasterHasFact(Guids.Greater), ifTrue: ActionsBuilder.New().Add<ContextActionRemoveFact>(c =>
                    {
                        c.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(Guids.HierophantGreater);
                    })).Conditional(ConditionsBuilder.New().CasterHasFact(Guids.Supreme), ifTrue: ActionsBuilder.New().Add<ContextActionRemoveFact>(c =>
                    {
                        c.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(Guids.HierophantSupreme);
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
