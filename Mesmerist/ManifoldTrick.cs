using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using Mesmerist.Utils;
using Kingmaker.Enums;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using BlueprintCore.Utils;
using CharacterOptionsPlus.Util;
using Mesmerist.NewComponents;
using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Conditions.Builder.BasicEx;
using Kingmaker.Designers.EventConditionActionSystem.Evaluators;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Abilities.Components.Base;

namespace Mesmerist.Mesmerist
{
    public class ManifoldTrick
    {
        private static readonly string FeatName = "ManifoldTrick";
        internal const string DisplayName = "ManifoldTrick.Name";
        private static readonly string Description = "ManifoldTrick.Description";
        internal const string DisplayNameUseTrick = "UseTrick.Name";
        private static readonly string DescriptionTrick = "UseTrick.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);

        public static void Configure()
        {

            var b=BuffConfigurator.New(FeatName + "Buff1", Guids.ManifoldTrick1Buff)
                .AddUniqueBuff()
                .SetFlags(Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff.Flags.HiddenInUi)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.ArcanistConsumeSpellsAbility1.Reference.Get().Icon)
                .AddContextRankConfig(ContextRankConfigs.ClassLevel([Guids.Mesmerist], false, AbilityRankType.Default, 20, 1))
                .AddBuffActions(activated: TrickBuilder())
                .Configure();

            var b2 = BuffConfigurator.New(FeatName + "Buff2", Guids.ManifoldTrick2Buff)
                .AddUniqueBuff()
                .SetFlags(Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff.Flags.HiddenInUi)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddContextRankConfig(ContextRankConfigs.ClassLevel([Guids.Mesmerist], false, AbilityRankType.Default, 20, 1))
                .SetIcon(AbilityRefs.ArcanistConsumeSpellsAbility2.Reference.Get().Icon)
                .AddBuffActions(activated: TrickBuilder())
                .Configure();

            var b3 = BuffConfigurator.New(FeatName + "Buff3", Guids.ManifoldTrick3Buff)
                .AddUniqueBuff()
                .SetFlags(Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff.Flags.HiddenInUi)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddContextRankConfig(ContextRankConfigs.ClassLevel([Guids.Mesmerist], false, AbilityRankType.Default, 20, 1))
                .SetIcon(AbilityRefs.ArcanistConsumeSpellsAbility3.Reference.Get().Icon)
                .AddBuffActions(activated: TrickBuilder())
                .Configure();

            var b4 = BuffConfigurator.New(FeatName + "Buff4", Guids.ManifoldTrick4Buff)
                .AddUniqueBuff()
                .SetFlags(Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff.Flags.HiddenInUi)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddContextRankConfig(ContextRankConfigs.ClassLevel([Guids.Mesmerist], false, AbilityRankType.Default, 20, 1))
                .SetIcon(AbilityRefs.ArcanistConsumeSpellsAbility4.Reference.Get().Icon)
                .AddBuffActions(activated: TrickBuilder())
                .Configure();

            var b5 = BuffConfigurator.New(FeatName + "Buff5", Guids.ManifoldTrick5Buff)
                .AddUniqueBuff()
                .SetFlags(Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff.Flags.HiddenInUi)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddContextRankConfig(ContextRankConfigs.ClassLevel([Guids.Mesmerist], false, AbilityRankType.Default, 20, 1))
                .SetIcon(AbilityRefs.ArcanistConsumeSpellsAbility5.Reference.Get().Icon)
                .AddBuffActions(activated: TrickBuilder())
                .Configure();

            AbilityConfigurator.New(FeatName + "1", Guids.MesmeristTrickActiveAbility1)
                .CopyFrom(AbilityRefs.LayOnHandsSelf, typeof(AbilitySpawnFx))
                .SetDisplayName(DisplayNameUseTrick)
                .SetDescription(DescriptionTrick)
                .AddAbilityResourceLogic(1, false, true, requiredResource: Guids.MesmeristTrickResource)
                .SetIcon(AbilityRefs.ArcanistConsumeSpellsAbility1.Reference.Get().Icon)
                .SetRange(AbilityRange.Touch)
                .SetCanTargetEnemies(false)
                .SetCanTargetFriends(true)
                .SetActionType(Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Standard)
                .AddAbilityEffectRunAction(ActionsBuilder.New().ApplyBuffPermanent(b))
                .Configure();

            AbilityConfigurator.New(FeatName + "2", Guids.MesmeristTrickActiveAbility2)
                .CopyFrom(AbilityRefs.LayOnHandsSelf, typeof(AbilitySpawnFx))
                .SetDisplayName(DisplayNameUseTrick)
                .SetDescription(DescriptionTrick)
                .AddAbilityResourceLogic(1, false, true, requiredResource: Guids.MesmeristTrickResource)
                .SetIcon(AbilityRefs.ArcanistConsumeSpellsAbility2.Reference.Get().Icon)
                .AddComponent<AddRequirementOnFeatureRank>(c => {
                    c.Feature =BlueprintTool.GetRef<BlueprintFeatureReference>(Guids.ManifoldTrick);
                    c.checkValue = 1;
                })
                .SetRange(AbilityRange.Touch)
                .SetCanTargetEnemies(false)
                .SetCanTargetFriends(true)
                .SetActionType(Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Standard)
                .AddAbilityEffectRunAction(ActionsBuilder.New().ApplyBuffPermanent(b2))
                .Configure();

            AbilityConfigurator.New(FeatName + "3", Guids.MesmeristTrickActiveAbility3)
                .CopyFrom(AbilityRefs.LayOnHandsSelf, typeof(AbilitySpawnFx))
                .SetDisplayName(DisplayNameUseTrick)
                .SetDescription(DescriptionTrick)
                .AddAbilityResourceLogic(1, false, true, requiredResource: Guids.MesmeristTrickResource)
                .SetIcon(AbilityRefs.ArcanistConsumeSpellsAbility3.Reference.Get().Icon)
                .AddComponent<AddRequirementOnFeatureRank>(c => {
                    c.Feature =BlueprintTool.GetRef<BlueprintFeatureReference>(Guids.ManifoldTrick);
                    c.checkValue = 2;
                })
                .SetRange(AbilityRange.Touch)
                .SetCanTargetEnemies(false)
                .SetCanTargetFriends(true)
                .SetActionType(Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Standard)
                .AddAbilityEffectRunAction(ActionsBuilder.New().ApplyBuffPermanent(b3))
                .Configure();

            AbilityConfigurator.New(FeatName + "4", Guids.MesmeristTrickActiveAbility4)
                .CopyFrom(AbilityRefs.LayOnHandsSelf, typeof(AbilitySpawnFx))
                .AddComponent<AddRequirementOnFeatureRank>()
                .SetDisplayName(DisplayNameUseTrick)
                .SetDescription(DescriptionTrick)
                .AddAbilityResourceLogic(1, false, true, requiredResource: Guids.MesmeristTrickResource)
                .SetIcon(AbilityRefs.ArcanistConsumeSpellsAbility4.Reference.Get().Icon)
                .AddComponent<AddRequirementOnFeatureRank>(c => {
                    c.Feature =BlueprintTool.GetRef<BlueprintFeatureReference>(Guids.ManifoldTrick);
                    c.checkValue = 3;
                })
                .SetRange(AbilityRange.Touch)
                .SetCanTargetEnemies(false)
                .SetCanTargetFriends(true)
                .SetActionType(Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Standard)
                .AddAbilityEffectRunAction(ActionsBuilder.New().ApplyBuffPermanent(b4))
                .Configure();

            AbilityConfigurator.New(FeatName + "5", Guids.MesmeristTrickActiveAbility5)
                .CopyFrom(AbilityRefs.LayOnHandsSelf, typeof(AbilitySpawnFx))
                .SetDisplayName(DisplayNameUseTrick)
                .SetDescription(DescriptionTrick)
                .AddAbilityResourceLogic(1, false, true, requiredResource: Guids.MesmeristTrickResource)
                .SetIcon(AbilityRefs.ArcanistConsumeSpellsAbility5.Reference.Get().Icon)
                .AddComponent<AddRequirementOnFeatureRank>(c => {
                    c.Feature =BlueprintTool.GetRef<BlueprintFeatureReference>(Guids.ManifoldTrick);
                    c.checkValue = 4;
                })
                .SetRange(AbilityRange.Touch)
                .SetCanTargetEnemies(false)
                .SetCanTargetFriends(true)
                .SetActionType(Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Standard)
                .AddAbilityEffectRunAction(ActionsBuilder.New().ApplyBuffPermanent(b5))
                .Configure();

            AbilityConfigurator.New(FeatName + "Variants", Guids.MesmeristTrickActiveVariants)
                .SetDisplayName(DisplayNameUseTrick)
                .SetDescription(DescriptionTrick)
                .SetIcon(AbilityRefs.ArcanistConsumeSpellsAbility9.Reference.Get().Icon)
                .AddAbilityVariants(variants: new() { Guids.MesmeristTrickActiveAbility1, 
                    Guids.MesmeristTrickActiveAbility2, Guids.MesmeristTrickActiveAbility3, 
                    Guids.MesmeristTrickActiveAbility4, Guids.MesmeristTrickActiveAbility5 })
                .Configure();

            FeatureConfigurator.New(FeatName + "InitialTrick", Guids.InitialTrick)
                .SetIcon(AbilityRefs.EnlargePersonMass.Reference.Get().Icon)
                .SetIsClassFeature(true)
                .SetReapplyOnLevelUp(false)
                .SetHideInUI()
                .SetHideInCharacterSheetAndLevelUp()
                .AddFacts(new() { Guids.MesmeristTrickActiveVariants })
                .Configure();

            BlueprintFeature manifoldTrick = FeatureConfigurator.New(FeatName + "ManifoldTrick", Guids.ManifoldTrick)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.EnlargePersonMass.Reference.Get().Icon)
                .SetIsClassFeature(true)
                .SetReapplyOnLevelUp(false)
                .SetRanks(4)
                .Configure();

        }

        private static ActionsBuilder TrickBuilder()
        {
            return ActionsBuilder.New()
                   .Conditional(
                               ConditionsBuilder.New().CasterHasFact(Guids.AstoundingAvoidanceBuff),
                               ifTrue: ActionsBuilder.New().Conditional(
                                   ConditionsBuilder.New().IsUnitLevelLessThan(true, 12, false, new FactOwner()),
                                   ifTrue: ActionsBuilder.New().ApplyBuffPermanent(Guids.AstoundingAvoidanceBuffEffect,
                                   true, false, false, true, null),
                                   ifFalse: ActionsBuilder.New().ApplyBuffPermanent(Guids.AstoundingAvoidanceBuffEffectImproved, true, false, false, true, null)))
                   .Conditional(
                               ConditionsBuilder.New().CasterHasFact(Guids.CompelAlacrityBuff),
                               ifTrue: ActionsBuilder.New().ApplyBuffPermanent(Guids.CompelAlacrityBuffEffect, true, false, false, true, null))
                   .Conditional(
                               ConditionsBuilder.New().CasterHasFact(Guids.CursedSanctionBuff),
                               ifTrue: ActionsBuilder.New().ApplyBuffPermanent(Guids.CursedSanctionBuffEffect, true, false, false, true, null))
                   .Conditional(
                               ConditionsBuilder.New().CasterHasFact(Guids.FalseFlankerBuff),
                               ifTrue: ActionsBuilder.New().ApplyBuffPermanent(Guids.FalseFlankerBuffEffect, true, false, false, true, null))
                   .Conditional(
                               ConditionsBuilder.New().CasterHasFact(Guids.FearsomeGuiseBuff),
                               ifTrue: ActionsBuilder.New().ApplyBuffPermanent(Guids.FearsomeGuiseBuffEffect, true, false, false, true, null))
                   .Conditional(
                               ConditionsBuilder.New().CasterHasFact(Guids.FreeInBodyBuff),
                               ifTrue: ActionsBuilder.New().ApplyBuffPermanent(Guids.FreeInBodyBuffEffect, true, false, false, true, null))
                   .Conditional(
                               ConditionsBuilder.New().CasterHasFact(Guids.FleetInShadowsBuff),
                               ifTrue: ActionsBuilder.New().ApplyBuff(Guids.FleetInShadowsBuffEffect,
                               ContextDuration.Variable(ContextValues.Rank(), DurationRate.Minutes), true, false, false, true, null))
                   .Conditional(
                               ConditionsBuilder.New().CasterHasFact(Guids.LevitationBufferBuff),
                               ifTrue: ActionsBuilder.New().ApplyBuffPermanent(Guids.LevitationBufferBuffEffect, true, false, false, true, null))
                   .Conditional(
                               ConditionsBuilder.New().CasterHasFact(Guids.LinkedReactionBuff),
                               ifTrue: ActionsBuilder.New().ApplyBuffPermanent(Guids.LinkedReactionBuffEffect, true, false, false, true, null))
                   .Conditional(
                               ConditionsBuilder.New().CasterHasFact(Guids.MeekFacadeBuff),
                               ifTrue: ActionsBuilder.New().ApplyBuffPermanent(Guids.MeekFacadeBuffEffect, true, false, false, true, null))
                   .Conditional(
                               ConditionsBuilder.New().CasterHasFact(Guids.MesmericMirrorBuff),
                               ifTrue: ActionsBuilder.New().ApplyBuff(Guids.MesmericMirrorBuffEffect,
                               ContextDuration.Variable(ContextValues.Rank(), DurationRate.Minutes), true, false, false, true, null))
                   .Conditional(
                               ConditionsBuilder.New().CasterHasFact(Guids.MesmericPantomimeBuff),
                               ifTrue: ActionsBuilder.New().ApplyBuff(Guids.MesmericPantomimeBuffEffect,
                               ContextDuration.Variable(ContextValues.Rank(), DurationRate.Minutes), true, false, false, true, null))
                   .Conditional(
                               ConditionsBuilder.New().CasterHasFact(Guids.MisdirectionBuff),
                               ifTrue: ActionsBuilder.New().ApplyBuffPermanent(Guids.MisdirectionBuffEffect, true, false, false, true, null))
                   .Conditional(
                               ConditionsBuilder.New().CasterHasFact(Guids.PsychosomaticSurgeBuff),
                               ifTrue: ActionsBuilder.New().ApplyBuffPermanent(Guids.PsychosomaticSurgeBuffEffect, true, false, false, true, null))
                   .Conditional(
                               ConditionsBuilder.New().CasterHasFact(Guids.ReflectFearBuff),
                               ifTrue: ActionsBuilder.New().ApplyBuffPermanent(Guids.ReflectFearBuffEffect, true, false, false, true, null))
                   .Conditional(
                               ConditionsBuilder.New().CasterHasFact(Guids.SeeThroughInvisibilityBuff),
                               ifTrue: ActionsBuilder.New().ApplyBuff(Guids.SeeThroughInvisibilityBuffEffect,
                               ContextDuration.Variable(ContextValues.Rank(), DurationRate.Minutes), true, false, false, true, null))
                   .Conditional(
                               ConditionsBuilder.New().CasterHasFact(Guids.ShadowSplinterBuff),
                               ifTrue: ActionsBuilder.New().ApplyBuffPermanent(Guids.ShadowSplinterBuffEffect, true, false, false, true, null))
                   .Conditional(
                               ConditionsBuilder.New().CasterHasFact(Guids.SpectralSmokeBuff),
                               ifTrue: ActionsBuilder.New().ApplyBuffPermanent(Guids.SpectralSmokeBuffEffect, true, false, false, true, null))
                   .Conditional(
                               ConditionsBuilder.New().CasterHasFact(Guids.VanishArrowBuff),
                               ifTrue: ActionsBuilder.New().ApplyBuffPermanent(Guids.VanishArrowBuffEffect, true, false, false, true, null))
                   .Conditional(
                               ConditionsBuilder.New().CasterHasFact(Guids.VoiceOfReasonBuff),
                               ifTrue: ActionsBuilder.New().ApplyBuffPermanent(Guids.VoiceOfReasonBuffEffect, true, false, false, true, null));
        }
    }
}
