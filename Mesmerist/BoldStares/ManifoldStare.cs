using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using Mesmerist.Utils;
using CharacterOptionsPlus.Util;
using BlueprintCore.Blueprints.References;

namespace Mesmerist.Mesmerist.BoldStares
{
    public class ManifoldStare
    {
        private static readonly string FeatName = "ManifoldStare";
        internal const string DisplayName = "ManifoldStare.Name";
        private static readonly string Description = "ManifoldStare.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);

        public static void Configure()
        {

            var ManifoldStare = FeatureConfigurator.New(FeatName, Guids.ManifoldStare)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIsClassFeature()
                .SetIcon(AbilityRefs.TrueSeeing.Reference.Get().Icon)
                .AddPrerequisiteClassLevel(Guids.Mesmerist, 3)
                .AddFeatureOnApply(Guids.ManifoldStarePainfulStare)
                .Configure();

            FeatureConfigurator.New(FeatName + "2", Guids.ManifoldStare2)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIsClassFeature()
                .SetIcon(AbilityRefs.TrueSeeing.Reference.Get().Icon)
                .AddPrerequisiteClassLevel(Guids.Mesmerist, 9)
                .AddPrerequisiteFeature(Guids.ManifoldStare)
                .AddFeatureOnApply(Guids.ManifoldStarePainfulStare)
                .Configure();

            FeatureConfigurator.New(FeatName + "3", Guids.ManifoldStare3)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIsClassFeature()
                .SetIcon(AbilityRefs.TrueSeeing.Reference.Get().Icon)
                .AddPrerequisiteFeature(Guids.ManifoldStare2)
                .AddPrerequisiteClassLevel(Guids.Mesmerist, 15)
                .AddFeatureOnApply(Guids.ManifoldStarePainfulStare)
                .Configure();

        }
    }
}
