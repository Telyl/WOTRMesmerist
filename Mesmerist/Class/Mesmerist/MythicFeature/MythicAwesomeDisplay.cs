using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Classes;
using Mesmerist.Utils;

namespace Mesmerist.Class.Mesmerist.MythicFeature
{
    public class MythicAwesomeDisplay
    {
        private static readonly string FeatName = "MythicAwesomeDisplay";
        internal const string DisplayName = "MythicAwesomeDisplay.Name";
        private static readonly string Description = "MythicAwesomeDisplay.Description";

        public static void Configure()
        {

            FeatureConfigurator.New(FeatName, Guids.MythicAwesomeDisplay, FeatureGroup.MythicAbility)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.Starlight.Reference.Get().Icon)
                .Configure();
        }
    }
}
