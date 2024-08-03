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

namespace Mesmerist.Medium.Champion
{
    public class ChampionSpirit
    {
        private static readonly string FeatName = "ChampionSpirit";
        internal const string DisplayName = "ChampionSpirit.Name";
        private static readonly string Description = "ChampionSpirit.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);

        public static void Configure()
        {
            BuffConfigurator.New(FeatName + "Buff", Guids.ChampionBuff)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.ImitationFighterAbility.Reference.Get().Icon)
                .AddContextStatBonus(StatType.SkillKnowledgeArcana, ContextValues.Rank(), ModifierDescriptor.UntypedStackable)
                .AddContextStatBonus(StatType.SkillKnowledgeWorld, ContextValues.Rank(), ModifierDescriptor.UntypedStackable)
                .AddConcentrationBonus(value: ContextValues.Rank())
                .AddContextRankConfig(ContextRankConfigs.FeatureRank(Guids.SpiritBonus))
                .Configure();

            ActivatableAbilityConfigurator.New(FeatName, Guids.ChampionActivatableAbility)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.ImitationFighterAbility.Reference.Get().Icon)
                .AddTriggerOnActivationChanged(actionList: ActionsBuilder.New()
                    .ApplyBuffPermanent(Guids.ChampionBuff, true, false, false, true, false, false, true)
                    .CastSpell(Guids.SharedSeanceChampionAbility)
                    .Conditional(ConditionsBuilder.New().CasterHasFact(Guids.Lesser), ifTrue: ActionsBuilder.New().Add<ContextActionAddFact>(c =>
                    {
                        c.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(Guids.ChampionLesser);
                    }))
                    .Conditional(ConditionsBuilder.New().CasterHasFact(Guids.Intermediate), ifTrue: ActionsBuilder.New().Add<ContextActionAddFact>(c =>
                    {
                        c.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(Guids.ChampionIntermediate);
                    }))
                    .Conditional(ConditionsBuilder.New().CasterHasFact(Guids.Greater), ifTrue: ActionsBuilder.New().Add<ContextActionAddFact>(c =>
                    {
                        c.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(Guids.ChampionGreater);
                    }))
                    .Conditional(ConditionsBuilder.New().CasterHasFact(Guids.Supreme), ifTrue: ActionsBuilder.New().Add<ContextActionAddFact>(c =>
                    {
                        c.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(Guids.ChampionSupreme);
                    })),
                    stage: AddTriggerOnActivationChanged.Stage.OnSwitchOn)
                .AddTriggerOnActivationChanged(actionList: ActionsBuilder.New()
                    .RemoveBuff(Guids.ChampionBuff)
                    .RemoveBuff(Guids.SharedSeanceChampionBuff)
                    .Conditional(ConditionsBuilder.New().CasterHasFact(Guids.Lesser), ifTrue: ActionsBuilder.New().Add<ContextActionRemoveFact>(c =>
                    {
                        c.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(Guids.ChampionLesser);
                    }))
                    .Conditional(ConditionsBuilder.New().CasterHasFact(Guids.Intermediate), ifTrue: ActionsBuilder.New().Add<ContextActionRemoveFact>(c =>
                    {
                        c.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(Guids.ChampionIntermediate);
                    }))
                    .Conditional(ConditionsBuilder.New().CasterHasFact(Guids.Greater), ifTrue: ActionsBuilder.New().Add<ContextActionRemoveFact>(c =>
                    {
                        c.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(Guids.ChampionGreater);
                    })).Conditional(ConditionsBuilder.New().CasterHasFact(Guids.Supreme), ifTrue: ActionsBuilder.New().Add<ContextActionRemoveFact>(c =>
                    {
                        c.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(Guids.ChampionSupreme);
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
