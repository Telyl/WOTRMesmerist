using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Classes;
using Kingmaker.EntitySystem.Stats;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using Mesmerist.Utils;
using static UnityModManagerNet.UnityModManager.ModEntry;
using System;
using Kingmaker.Enums;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using Kingmaker.Blueprints.Classes.Spells;
using static Kingmaker.UnitLogic.Commands.Base.UnitCommand;
using BlueprintCore.Actions.Builder;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.ResourceLinks;
using Kingmaker.AI.Blueprints.Considerations;
using CharacterOptionsPlus.Util;

namespace Mesmerist.Mesmerist
{
    public class TouchTreatment
    {
        private static readonly string FeatName = "TouchTreatment";
        internal const string DisplayName = "TouchTreatment.Name";
        private static readonly string Description = "TouchTreatment.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);

        public static void Configure()
        {
            BlueprintAbilityResource ttresource = AbilityResourceConfigurator.New(FeatName + "Resource", Guids.TouchTreatmentResource)
                .SetMaxAmount(new BlueprintAbilityResource.Amount
                {
                    BaseValue = 3,
                    IncreasedByLevel = false,
                    IncreasedByLevelStartPlusDivStep = false,
                    StartingLevel = 0,
                    StartingIncrease = 0,
                    LevelStep = 2,
                    PerStepIncrease = 0,
                    MinClassLevelIncrease = 0,
                    m_ClassDiv = [BlueprintTool.GetRef<BlueprintCharacterClassReference>(Guids.Mesmerist)],
                    IncreasedByStat = true,
                    ResourceBonusStat = StatType.Charisma
                })
                .SetMax(10)
                .SetUseMax(false)
                .Configure();

            FeatureConfigurator.New(FeatName + "ResourceFeature", Guids.TouchTreatmentResourceFeat)
                .SetHideInUI(true)
                .AddAbilityResources(resource: ttresource, restoreAmount: true, useThisAsResource: false)
                .Configure();

            BlueprintAbility TTAbilitySelf = AbilityConfigurator.New(FeatName + "SelfAbility", Guids.TouchTreatmentSelfAbility)
                .SetDisplayName("TouchTreatmentSelf.Name")
                .SetDescription("TouchTreatmentSelf.Description")
                .SetIcon(AbilityRefs.LayOnHandsSelf.Reference.Get().Icon)
                .SetRange(AbilityRange.Personal)
                .SetActionType(CommandType.Swift)
                .AddAbilityResourceLogic(amount: 1, isSpendResource: true, requiredResource: ttresource)
                .AddAbilityEffectRunAction(
                   actions: ActionsBuilder.New()
                   .DispelMagic(Kingmaker.UnitLogic.Mechanics.Actions.ContextActionDispelMagic.BuffType.All,
                               Kingmaker.RuleSystem.Rules.RuleDispelMagic.CheckType.None,
                               ContextValues.Constant(0), countToRemove: ContextValues.Constant(1), maxCasterLevel: ContextValues.Constant(0),
                               descriptor: SpellDescriptor.Shaken)
                   .DispelMagic(Kingmaker.UnitLogic.Mechanics.Actions.ContextActionDispelMagic.BuffType.All,
                               Kingmaker.RuleSystem.Rules.RuleDispelMagic.CheckType.None,
                               ContextValues.Constant(0), countToRemove: ContextValues.Constant(1), maxCasterLevel: ContextValues.Constant(0),
                               descriptor: SpellDescriptor.Fatigue))
                .Configure();

            BlueprintAbility TTAbilityOther = AbilityConfigurator.New(FeatName + "OtherAbility", Guids.TouchTreatmentOtherAbility)
                .SetDisplayName("TouchTreatmentOther.Name")
                .SetDescription("TouchTreatmentOther.Description")
                .SetShouldTurnToTarget(true)
                .SetIcon(AbilityRefs.LayOnHandsOthers.Reference.Get().Icon)
                .SetRange(AbilityRange.Touch)
                .SetActionType(CommandType.Standard)
                .AllowTargeting(friends: true, enemies: false)
                .SetCanTargetFriends(true)
                .SetCanTargetEnemies(false)
                .AddAbilityResourceLogic(amount: 1, isSpendResource: true, requiredResource: ttresource)
                .AddAbilityEffectRunAction(
                   actions: ActionsBuilder.New()
                   .DispelMagic(Kingmaker.UnitLogic.Mechanics.Actions.ContextActionDispelMagic.BuffType.All,
                               Kingmaker.RuleSystem.Rules.RuleDispelMagic.CheckType.None,
                               ContextValues.Constant(0), countToRemove: ContextValues.Constant(1), maxCasterLevel: ContextValues.Constant(0),
                               descriptor: SpellDescriptor.Shaken)
                   .DispelMagic(Kingmaker.UnitLogic.Mechanics.Actions.ContextActionDispelMagic.BuffType.All,
                               Kingmaker.RuleSystem.Rules.RuleDispelMagic.CheckType.None,
                               ContextValues.Constant(0), countToRemove: ContextValues.Constant(1), maxCasterLevel: ContextValues.Constant(0),
                               descriptor: SpellDescriptor.Fatigue))
                .Configure();

            FeatureConfigurator.New(FeatName + "Break", Guids.TouchTreatmentBreak)
                .SetHideInUI()
                .SetIsClassFeature()
                .Configure();

            FeatureConfigurator.New(FeatName + "Greater", Guids.TouchTreatmentGreater)
                .SetHideInUI()
                .SetIsClassFeature()
                .Configure();

            FeatureConfigurator.New(FeatName + "Moderate", Guids.TouchTreatmentModerate)
                .SetHideInUI()
                .SetIsClassFeature()
                .Configure();

            FeatureConfigurator.New(FeatName, Guids.TouchTreatment)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(FeatureRefs.LayOnHandsFeature.Reference.Get().Icon)
                .AddFacts(new() { TTAbilitySelf , TTAbilityOther })
                .SetIsClassFeature()
                .Configure();
        }
    }
}
