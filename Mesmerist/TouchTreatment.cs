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
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Abilities.Components.CasterCheckers;
using Kingmaker.UnitLogic.Abilities.Components.Base;
using Kingmaker.UnitLogic.Abilities.Components.TargetCheckers;
using BlueprintCore.Conditions.Builder.BasicEx;
using Kingmaker.Blueprints.Facts;

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

            var componentTypes = new Type[] { typeof(AbilitySpawnFx), typeof(AbilityDeliverTouch) };

            FeatureConfigurator.New(FeatName + "ResourceFeature", Guids.TouchTreatmentResourceFeat)
                .SetHideInUI(true)
                .AddAbilityResources(resource: ttresource, restoreAmount: true, useThisAsResource: false)
                .Configure();

            BlueprintAbility TTAbilitySelf = AbilityConfigurator.New(FeatName + "SelfAbility", Guids.TouchTreatmentSelfAbility)
                .CopyFrom(AbilityRefs.LayOnHandsSelf, componentTypes)
                .SetDisplayName("TouchTreatmentSelf.Name")
                .SetDescription("TouchTreatmentSelf.Description")
                .SetIcon(AbilityRefs.LayOnHandsSelf.Reference.Get().Icon)
                .SetRange(AbilityRange.Personal)
                .SetActionType(CommandType.Swift)
                .SetAnimation(Kingmaker.Visual.Animation.Kingmaker.Actions.UnitAnimationActionCastSpell.CastAnimationStyle.SelfTouch)
                .AddAbilityResourceLogic(amount: 1, isSpendResource: true, requiredResource: ttresource)
                .AddAbilityEffectRunAction(
                   actions: ActionsBuilder.New()
                   .DispelMagic(Kingmaker.UnitLogic.Mechanics.Actions.ContextActionDispelMagic.BuffType.All,
                               Kingmaker.RuleSystem.Rules.RuleDispelMagic.CheckType.None,
                               ContextValues.Constant(0), countToRemove: ContextValues.Constant(1), maxCasterLevel: ContextValues.Constant(0),
                               descriptor: SpellDescriptor.Shaken)
                        .Conditional(ConditionsBuilder.New().CasterHasFact(Guids.TouchTreatmentModerate), ifTrue: ActionsBuilder.New()
                   .DispelMagic(Kingmaker.UnitLogic.Mechanics.Actions.ContextActionDispelMagic.BuffType.All,
                               Kingmaker.RuleSystem.Rules.RuleDispelMagic.CheckType.None,
                               ContextValues.Constant(0), countToRemove: ContextValues.Constant(1), maxCasterLevel: ContextValues.Constant(0),
                               descriptor: SpellDescriptor.Confusion | SpellDescriptor.Daze | SpellDescriptor.Sickened | SpellDescriptor.Frightened))
                        .Conditional(ConditionsBuilder.New().CasterHasFact(Guids.TouchTreatmentGreater), ifTrue: ActionsBuilder.New()
                    .DispelMagic(Kingmaker.UnitLogic.Mechanics.Actions.ContextActionDispelMagic.BuffType.All,
                               Kingmaker.RuleSystem.Rules.RuleDispelMagic.CheckType.None,
                               ContextValues.Constant(0), countToRemove: ContextValues.Constant(1), maxCasterLevel: ContextValues.Constant(0),
                               descriptor: SpellDescriptor.Nauseated | SpellDescriptor.Stun))
                        .Conditional(ConditionsBuilder.New().CasterHasFact(Guids.TouchTreatmentBreak), ifTrue: ActionsBuilder.New()
                    .DispelMagic(Kingmaker.UnitLogic.Mechanics.Actions.ContextActionDispelMagic.BuffType.All,
                               Kingmaker.RuleSystem.Rules.RuleDispelMagic.CheckType.None,
                               ContextValues.Constant(0), countToRemove: ContextValues.Constant(1), maxCasterLevel: ContextValues.Constant(0),
                               descriptor: SpellDescriptor.Curse | SpellDescriptor.Petrified)))
                .Configure();

            BlueprintAbility TTAbilityOther = AbilityConfigurator.New(FeatName + "OtherAbility", Guids.TouchTreatmentOtherAbility)
                .CopyFrom(AbilityRefs.LayOnHandsOthers, componentTypes)
                .SetDisplayName("TouchTreatmentOther.Name")
                .SetDescription("TouchTreatmentOther.Description")
                .AddAbilityResourceLogic(amount: 1, isSpendResource: true, requiredResource: ttresource)
                .AddAbilityEffectRunAction(
                   actions: ActionsBuilder.New()
                   .DispelMagic(Kingmaker.UnitLogic.Mechanics.Actions.ContextActionDispelMagic.BuffType.All,
                               Kingmaker.RuleSystem.Rules.RuleDispelMagic.CheckType.None,
                               ContextValues.Constant(0), countToRemove: ContextValues.Constant(1), maxCasterLevel: ContextValues.Constant(0),
                               descriptor: SpellDescriptor.Shaken)
                        .Conditional(ConditionsBuilder.New().CasterHasFact(Guids.TouchTreatmentModerate), ifTrue: ActionsBuilder.New()
                   .DispelMagic(Kingmaker.UnitLogic.Mechanics.Actions.ContextActionDispelMagic.BuffType.All,
                               Kingmaker.RuleSystem.Rules.RuleDispelMagic.CheckType.None,
                               ContextValues.Constant(0), countToRemove: ContextValues.Constant(1), maxCasterLevel: ContextValues.Constant(0),
                               descriptor: SpellDescriptor.Confusion | SpellDescriptor.Daze | SpellDescriptor.Sickened | SpellDescriptor.Frightened))
                        .Conditional(ConditionsBuilder.New().CasterHasFact(Guids.TouchTreatmentGreater), ifTrue: ActionsBuilder.New()
                    .DispelMagic(Kingmaker.UnitLogic.Mechanics.Actions.ContextActionDispelMagic.BuffType.All,
                               Kingmaker.RuleSystem.Rules.RuleDispelMagic.CheckType.None,
                               ContextValues.Constant(0), countToRemove: ContextValues.Constant(1), maxCasterLevel: ContextValues.Constant(0),
                               descriptor: SpellDescriptor.Nauseated | SpellDescriptor.Stun))
                        .Conditional(ConditionsBuilder.New().CasterHasFact(Guids.TouchTreatmentBreak), ifTrue: ActionsBuilder.New()
                    .DispelMagic(Kingmaker.UnitLogic.Mechanics.Actions.ContextActionDispelMagic.BuffType.All,
                               Kingmaker.RuleSystem.Rules.RuleDispelMagic.CheckType.None,
                               ContextValues.Constant(0), countToRemove: ContextValues.Constant(1), maxCasterLevel: ContextValues.Constant(0),
                               descriptor: SpellDescriptor.Curse | SpellDescriptor.Petrified)))
                .Configure();

            FeatureConfigurator.New(FeatName + "Break", Guids.TouchTreatmentBreak)
                .SetHideInUI()
                .SetIsClassFeature()
                .Configure();

            // Nauseated & Stunned
            FeatureConfigurator.New(FeatName + "Greater", Guids.TouchTreatmentGreater)
                .SetHideInUI()
                .SetIsClassFeature()
                .Configure();


            // Dazed & Confused & Sickened & Frightened
            FeatureConfigurator.New(FeatName + "Moderate", Guids.TouchTreatmentModerate)
                .SetHideInUI()
                .SetIsClassFeature()
                .Configure();

            // Shaken
            FeatureConfigurator.New(FeatName, Guids.TouchTreatment)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(FeatureRefs.LayOnHandsFeature.Reference.Get().Icon)
                .AddFacts(new() { TTAbilitySelf, TTAbilityOther })
                .SetIsClassFeature()
                .Configure();
        }
    }
}
