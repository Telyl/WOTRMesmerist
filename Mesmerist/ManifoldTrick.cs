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
using BlueprintCore.Actions.Builder.BasicEx;
using BlueprintCore.Blueprints.CustomConfigurators;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.EntitySystem.Stats;

namespace Mesmerist.Mesmerist
{
    public class ManifoldTrick
    {
        private static readonly string FeatName = "Tricks";
        internal const string DisplayName = "ManifoldTrick.Name";
        private static readonly string Description = "ManifoldTrick.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);

        public static void Configure()
        {

            

            var feat = FeatureConfigurator.New(FeatName + "ManifoldTrick", Guids.ManifoldTrick)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.EnlargePersonMass.Reference.Get().Icon)
                .SetIsClassFeature(true)
                .SetReapplyOnLevelUp(false)
                .SetRanks(4)
                .Configure();

            FeatureConfigurator.For(feat)
                .AddContextRankConfig(new ContextRankConfig
                {
                    m_Type = AbilityRankType.Default,
                    m_BaseValueType = ContextRankBaseValueType.FeatureRank,
                    m_Feature = feat.ToReference<BlueprintFeatureReference>(),
                    m_Stat = StatType.Unknown,
                    m_Buff = null,
                    m_Progression = ContextRankProgression.AsIs,
                    m_StartLevel = 0,
                    m_StepLevel = 0,
                    m_UseMin = false,
                    m_Min = 0,
                    m_UseMax = false,
                    m_Max = 20,
                    m_ExceptClasses = false,
                    Archetype = null
                })
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
                               ifTrue: ActionsBuilder.New().ApplyBuff(Guids.VoiceOfReasonBuffEffect,
                               ContextDuration.Variable(ContextValues.Rank(), DurationRate.Minutes), true, false, false, true, null));
        }
    }
}
