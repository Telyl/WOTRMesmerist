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
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using CharacterOptionsPlus.Util;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
namespace Mesmerist.Mesmerist.Tricks
{
    public class TrickVariants
    {
        private static readonly string FeatName = "TrickVariants";
        internal const string DisplayName = "MesmeristTrick.Name";
        private static readonly string Description = "MesmeristTrick.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);

        public static void Configure()
        {

            ActivatableAbilityConfigurator.New(FeatName + "Ability", Guids.TrickVariantsActivatableAbility)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.AngelBringBackTouch.Reference.Get().Icon)
                .AddActivatableAbilityVariants(variants: new() { Guids.AstoundingAvoidanceAbility, Guids.CompelAlacrityAbility, Guids.FalseFlankerAbility,
                Guids.FearsomeGuiseAbility, Guids.FleetInShadowsAbility, Guids.LevitationBufferAbility,
                Guids.LinkedReactionAbility, Guids.MeekFacadeAbility, Guids.MesmericMirrorAbility,
                Guids.MesmericPantomimeAbility, Guids.MisdirectionAbility, Guids.PsychosomaticSurgeAbility,
                Guids.ReflectFearAbility, Guids.SeeThroughInvisibilityAbility, Guids.ShadowSplinterAbility,
                Guids.SpectralSmokeAbility, Guids.VanishArrowAbility, Guids.VoiceOfReasonAbility })
                .Configure();

            //TODO: Change CharacterLevel to ClassLevel(Mesmerist)
            FeatureConfigurator.New(FeatName, Guids.TrickVariants)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddFacts(new() { Guids.TrickVariantsActivatableAbility })
                .SetIsClassFeature()
                .Configure();
        }
    }
}
