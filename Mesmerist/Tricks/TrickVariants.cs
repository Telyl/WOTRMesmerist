using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Mesmerist.Utils;
using CharacterOptionsPlus.Util;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
namespace Mesmerist.Mesmerist.Tricks
{
    public class TrickVariants
    {
        private static readonly string FeatName = "Tricks";
        internal const string DisplayName = "MesmeristTrick.Name";
        private static readonly string Description = "MesmeristTrick.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);

        public static void Configure()
        {

            AbilityConfigurator.New(FeatName + "Ability", Guids.TrickVariantsActivatableAbility)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(FeatureRefs.ArcanistExploits.Reference.Get().Icon)
                .AddAbilityVariants(variants: new() { Guids.AstoundingAvoidanceAbility, Guids.CompelAlacrityAbility, Guids.FalseFlankerAbility,
                Guids.FearsomeGuiseAbility, Guids.FleetInShadowsAbility, Guids.LevitationBufferAbility,
                Guids.LinkedReactionAbility, Guids.MeekFacadeAbility, Guids.MesmericMirrorAbility,
                Guids.MesmericPantomimeAbility, Guids.MisdirectionAbility, Guids.PsychosomaticSurgeAbility,
                Guids.ReflectFearAbility, Guids.SeeThroughInvisibilityAbility, Guids.ShadowSplinterAbility,
                Guids.SpectralSmokeAbility, Guids.VanishArrowAbility, Guids.VoiceOfReasonAbility, 
                Guids.CursedSanctionAbility, Guids.FreeInBodyAbility, Guids.GoodHopeTrickAbility, Guids.ShadowBlendAbility })
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
