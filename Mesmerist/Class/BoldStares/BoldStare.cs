using BlueprintCore.Blueprints.References;
using Mesmerist.Utils;
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;

namespace Mesmerist.Class.BoldStares
{
    public class BoldStare
    {
        private static readonly string FeatName = "BoldStare";
        internal const string DisplayName = "BoldStare.Name";
        private static readonly string Description = "BoldStare.Description";

        public static void Configure()
        {
            Disorientation.Configure();
            Disquiet.Configure();
            Distracted.Configure();
            Infiltration.Configure();
            Lethality.Configure();
            Nightmare.Configure();
            PsychicInception.Configure();
            SappedMagic.Configure();
            Sluggishness.Configure();
            Timidity.Configure();
            Manifold.Configure(); 

            FeatureSelectionConfigurator.New(FeatName, Guids.BoldStareSelection)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.Blindness.Reference.Get().Icon)
                .SetIsClassFeature()
                .AddToAllFeatures([Guids.Disorientation, Guids.Disquiet, Guids.Distracted,
                Guids.Infiltration, Guids.Lethality, Guids.Nightmare,
                Guids.SappedMagic, Guids.Sluggishness, Guids.Timidity, Guids.PsychicInception])
                .Configure();
        }
    }
}
