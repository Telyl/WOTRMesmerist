using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using Mesmerist.Utils;
using Kingmaker.Blueprints.Classes.Spells;
using TabletopTweaks.Core.NewComponents;
using Kingmaker.Blueprints.Classes;

namespace Mesmerist.Class.Mesmerist.BoldStares
{
    public class Manifold
    {
        private static readonly string FeatName = "ManifoldStare";
        internal const string DisplayName = "ManifoldStare.Name";
        private static readonly string Description = "ManifoldStare.Description";

        public static void Configure()
        {
            //TODO: Change CharacterLevel to ClassLevel(Mesmerist)
            FeatureConfigurator.New(FeatName, Guids.ManifoldStare3rd, [FeatureGroup.CombatFeat, FeatureGroup.Feat])
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIsClassFeature()
                .SetIcon(AbilityRefs.TrueSeeing.Reference.Get().Icon)
                .AddFacts(new() { Guids.PainfulStare })
                .SetIsPrerequisiteFor(Guids.ManifoldStare9th, Guids.ManifoldStare15th)
                .AddRecommendationHasClasses(recommendedClasses: [Guids.Mesmerist])
                .AddPrerequisiteClassLevel(Guids.Mesmerist, 3)
                .Configure();

            FeatureConfigurator.New(FeatName + "9th", Guids.ManifoldStare9th, [FeatureGroup.CombatFeat, FeatureGroup.Feat])
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIsClassFeature()
                .SetIcon(AbilityRefs.TrueSeeing.Reference.Get().Icon)
                .SetIsPrerequisiteFor(Guids.ManifoldStare15th)
                .AddPrerequisiteClassLevel(Guids.Mesmerist, 9)
                .AddPrerequisitePlayerHasFeature(Guids.ManifoldStare3rd)
                .AddRecommendationHasClasses(recommendedClasses: [Guids.Mesmerist])
                .AddFacts(new() { Guids.PainfulStare })
                .Configure();

            FeatureConfigurator.New(FeatName + "15th", Guids.ManifoldStare15th, [FeatureGroup.CombatFeat, FeatureGroup.Feat])
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIsClassFeature()
                .SetIcon(AbilityRefs.TrueSeeing.Reference.Get().Icon)
                .AddPrerequisiteClassLevel(Guids.Mesmerist, 15)
                .AddPrerequisitePlayerHasFeature(Guids.ManifoldStare9th)
                .AddRecommendationHasClasses(recommendedClasses: [Guids.Mesmerist])
                .AddFacts(new() { Guids.PainfulStare })
                .Configure(); 

        }
    }
}