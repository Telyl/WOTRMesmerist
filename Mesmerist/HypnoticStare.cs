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
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Actions.Builder;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Mechanics;
using BlueprintCore.Actions.Builder.ContextEx;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using static Kingmaker.UnitLogic.Commands.Base.UnitCommand;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using BlueprintCore.Blueprints.Configurators.Classes;
using Kingmaker.Blueprints;
using Kingmaker.UnitLogic.Mechanics.Components;
using BlueprintCore.Utils;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using CharacterOptionsPlus.Util;
using Kingmaker.Enums.Damage;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.RuleSystem;
using static Kingmaker.UnitLogic.Mechanics.Conditions.ContextConditionInContext;
using Mesmerist.NewComponents;
using Kingmaker.AI.Blueprints;
using TabletopTweaks.Core.Utilities;
using Mesmerist.NewComponents.Conditions;
using Kingmaker.Designers.EventConditionActionSystem.Evaluators;
using TabletopTweaks.Core.NewComponents;

namespace Mesmerist.Mesmerist
{
    public class HypnoticStare
    {
        private static readonly string FeatName = "HypnoticStare";
        internal const string DisplayName = "HypnoticStare.Name";
        private static readonly string Description = "HypnoticStare.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);

        public static void Configure()
        {
            BlueprintBuff hypnoticStareBuff = BuffConfigurator.New(FeatName + "Buff", Guids.HypnoticStareBuff)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.Eyebite.Reference.Get().Icon)
                .AddSpellDescriptorComponent(SpellDescriptor.MindAffecting)
                .AddUniqueBuff()
                .AddContextCalculateAbilityParamsBasedOnClass(Guids.Mesmerist, statType: StatType.Charisma)
                .AddComponent<AddPainfulStare>(C => C.CheckFactOnTarget = BlueprintTool.GetRef<BlueprintBuffReference>(Guids.PainfulStareCooldown))
                .AddContextStatBonus(StatType.SaveWill, ContextValues.Rank(AbilityRankType.Default), ModifierDescriptor.UntypedStackable, 2, -1)
                .AddContextRankConfig(ContextRankConfigs.CharacterLevel(AbilityRankType.Default).WithCustomProgression((7, 2), (20, 3)))
                .Configure();

            BlueprintAbility hypnoticStareAbility = AbilityConfigurator.New(FeatName + "Ability", Guids.HypnoticStareAbility)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetShouldTurnToTarget(true)
                .SetLocalizedDuration(Duration.OneRound)
                .SetIcon(AbilityRefs.EyebiteAbility.Reference.Get().Icon)
                .SetRange(AbilityRange.Close)
                .SetActionType(CommandType.Swift)
                .SetSpellDescriptor(SpellDescriptor.MindAffecting)
                .AddComponent<AddPsychicInceptionAllowGaze>(c =>
                {
                    c.IgnoreDescriptors = SpellDescriptor.MindAffecting;
                    c.BecauseOfFact = BlueprintTool.GetRef<BlueprintFeatureReference>(Guids.PsychicInception);
                })
                .AllowTargeting(friends: false, enemies: true)
                .SetCanTargetFriends(false)
                .SetCanTargetEnemies(true)
                .AddAbilityEffectRunAction(
                   actions: ActionsBuilder.New()
                   .Conditional(
                               ConditionsBuilder.New().CasterHasFact(Guids.Disorientation),
                               ifTrue: ActionsBuilder.New().ApplyBuffPermanent(Guids.DisorientationBuff, true, false))
                   .Conditional(
                               ConditionsBuilder.New().CasterHasFact(Guids.Disquiet),
                               ifTrue: ActionsBuilder.New().ApplyBuffPermanent(Guids.DisquietBuff, true, false))
                   .Conditional(
                               ConditionsBuilder.New().CasterHasFact(Guids.Distracted),
                               ifTrue: ActionsBuilder.New().ApplyBuffPermanent(Guids.DistractedBuff, true, false))
                   .Conditional(
                               ConditionsBuilder.New().CasterHasFact(Guids.Infiltration),
                               ifTrue: ActionsBuilder.New().ApplyBuffPermanent(Guids.InfiltrationBuff, true, false))
                   .Conditional(
                               ConditionsBuilder.New().CasterHasFact(Guids.Lethality),
                               ifTrue: ActionsBuilder.New().ApplyBuffPermanent(Guids.LethalityBuff, true, false))
                   .Conditional(
                               ConditionsBuilder.New().CasterHasFact(Guids.Nightmare),
                               ifTrue: ActionsBuilder.New().ApplyBuffPermanent(Guids.NightmareBuff, true, false))
                   .Conditional(
                               ConditionsBuilder.New().CasterHasFact(Guids.PsychicInception),
                               ifTrue: ActionsBuilder.New().ApplyBuffPermanent(Guids.PsychicInceptionBuff, true, false, toCaster: true))
                   .Conditional(
                               ConditionsBuilder.New().CasterHasFact(Guids.SappedMagic),
                               ifTrue: ActionsBuilder.New().ApplyBuffPermanent(Guids.SappedMagicBuff, true, false))
                   .Conditional(
                               ConditionsBuilder.New().CasterHasFact(Guids.Sluggishness),
                               ifTrue: ActionsBuilder.New().ApplyBuffPermanent(Guids.SluggishnessBuff, true, false))
                   .Conditional(
                               ConditionsBuilder.New().CasterHasFact(Guids.Timidity),
                               ifTrue: ActionsBuilder.New().ApplyBuffPermanent(Guids.TimidityBuff, true, false))
                   .ApplyBuffPermanent(hypnoticStareBuff, true))
                .Configure();

            
            FeatureConfigurator.New(FeatName, Guids.HypnoticStare)
                .AddFacts(new() { hypnoticStareAbility })
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.EyebiteAbility.Reference.Get().Icon)
                .SetIsClassFeature()
                .SetReapplyOnLevelUp(false)
                .Configure();

            
        }
    }
}
