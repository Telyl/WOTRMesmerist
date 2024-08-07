using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using CharacterOptionsPlus.Util;
using Mesmerist.Utils;
using static Kingmaker.UnitLogic.FactLogic.AddMechanicsFeature;

namespace Mesmerist.Medium.Marshal
{
    public class MarshalGreater
    {
        private static readonly string FeatName = "MarshalGreater";
        internal const string DisplayName = "MarshalGreater.Name";
        private static readonly string Description = "MarshalGreater.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);
        public static void Configure()
        {
            FeatureConfigurator.New(FeatName, Guids.MarshalGreater)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }
}
