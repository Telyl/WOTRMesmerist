using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Mesmerist.Utils;
using Kingmaker.Enums;
using BlueprintCore.Utils.Types;
using CharacterOptionsPlus.Util;

namespace Mesmerist.Medium.Marshal
{
    public class MarshalSupreme
    {
        private static readonly string FeatName = "MarshalSupreme";
        internal const string DisplayName = "MarshalSupreme.Name";
        private static readonly string Description = "MarshalSupreme.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);

        public static void Configure()
        {
            FeatureConfigurator.New(FeatName, Guids.MarshalSupreme)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }
}
