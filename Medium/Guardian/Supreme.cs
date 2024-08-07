using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Mesmerist.Utils;
using Kingmaker.Enums;
using BlueprintCore.Utils.Types;
using CharacterOptionsPlus.Util;

namespace Mesmerist.Medium.Guardian
{
    public class GuardianSupreme
    {
        private static readonly string FeatName = "GuardianSupreme";
        internal const string DisplayName = "GuardianSupreme.Name";
        private static readonly string Description = "GuardianSupreme.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);

        public static void Configure()
        {
            FeatureConfigurator.New(FeatName, Guids.GuardianSupreme)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }
}
