using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using CharacterOptionsPlus.Util;
using Mesmerist.Utils;
using static Kingmaker.UnitLogic.FactLogic.AddMechanicsFeature;

namespace Mesmerist.Medium.Guardian
{
    public class GuardianGreater
    {
        private static readonly string FeatName = "GuardianGreater";
        internal const string DisplayName = "GuardianGreater.Name";
        private static readonly string Description = "GuardianGreater.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);
        public static void Configure()
        {
            FeatureConfigurator.New(FeatName, Guids.GuardianGreater)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }
}
