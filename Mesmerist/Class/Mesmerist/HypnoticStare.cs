using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.BasicEx;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Mesmerist.Utils;
using TabletopTweaks.Core.NewActions;
using TabletopTweaks.Core.NewComponents;
using static Kingmaker.UnitLogic.Commands.Base.UnitCommand;

namespace Mesmerist.Class.Mesmerist.Mesmerist
{
    public class HypnoticStare
    {
        private static readonly string FeatName = "HypnoticStare";
        internal const string DisplayName = "HypnoticStare.Name";
        private static readonly string Description = "HypnoticStare.Description";

        public static void Configure()
        {

            BlueprintBuff hypnoticStareBuff = BuffConfigurator.New(FeatName + "Buff", Guids.HypnoticStareBuff)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.Eyebite.Reference.Get().Icon)
                .AddSpellDescriptorComponent(SpellDescriptor.MindAffecting)
                .AddUniqueBuff()
                .SetFxOnStart("8de64fbe047abc243a9b4715f643739f")
                .AddContextCalculateAbilityParamsBasedOnClass(Guids.Mesmerist, statType: StatType.Charisma)
                .AddContextStatBonus(StatType.SaveWill, ContextValues.Rank(AbilityRankType.Default), ModifierDescriptor.UntypedStackable, 2, -1)
                .AddContextRankConfig(ContextRankConfigs.CharacterLevel(AbilityRankType.Default).WithCustomProgression((7, 2), (19, 3), (20, 5)))
                .Configure();

            BlueprintAbility hypnoticStareAbility = AbilityConfigurator.New(FeatName + "Ability", Guids.HypnoticStareAbility)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.EyebiteAbility.Reference.Get().Icon)
                .SetRange(AbilityRange.Close)
                .SetActionType(CommandType.Swift)
                .SetCanTargetSelf(false)
                .SetCanTargetFriends(false)
                .SetCanTargetEnemies(true)
                //.AddAbilityTargetIsAlly(true)
                .AddAbilityTargetHasFact(inverted: true, fromCaster: true, checkedFacts: [hypnoticStareBuff])
                //.SetSpellDescriptor(SpellDescriptor.MindAffecting)
                .SetNotOffensive(true)
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
                               ifTrue: ActionsBuilder.New().ApplyBuffPermanent(Guids.PsychicInceptionBuff, true, false))
                   .Conditional(
                               ConditionsBuilder.New().CasterHasFact(Guids.SappedMagic),
                               ifTrue: ActionsBuilder.New().ApplyBuffPermanent(Guids.SappedMagicBuff, true, false))
                   .Conditional(
                               ConditionsBuilder.New().CasterHasFact(Guids.Sluggishness),
                               ifTrue: ActionsBuilder.New().ApplyBuffPermanent(Guids.SluggishnessBuff, true, false))
                   .Conditional(
                               ConditionsBuilder.New().CasterHasFact(Guids.Timidity),
                               ifTrue: ActionsBuilder.New().ApplyBuffPermanent(Guids.TimidityBuff, true, false))
                   .ApplyBuffPermanent(hypnoticStareBuff, true)
                   .Add<ContextActionApplyBuffRanks>(c =>
                   {
                       c.IsFromSpell = false;
                       c.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(Guids.PainfulStareBuff);
                       c.Rank = new ContextValue()
                       {
                           ValueType = ContextValueType.Rank
                       };
                       c.Permanent = true;
                   }))
                   .AddContextRankConfig(ContextRankConfigs.FeatureRank(Guids.PainfulStare))
                .Configure();

            FeatureConfigurator.New(FeatName, Guids.HypnoticStare)
                .AddFacts(new() { hypnoticStareAbility })
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.EyebiteAbility.Reference.Get().Icon)
                .SetIsClassFeature()
                .SetReapplyOnLevelUp(false)
                .Configure();

            FeatureConfigurator.New(FeatName + "Upgrade", Guids.HypnoticStareUpgrade)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.EyebiteAbility.Reference.Get().Icon)
                .SetIsClassFeature()
                .Configure();

            FeatureConfigurator.New(FeatName + "PiercingGaze", Guids.HypnoticStarePiercingGaze)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.EyebiteAbility.Reference.Get().Icon)
                .SetIsClassFeature()
                .Configure();
        }
    }
}
