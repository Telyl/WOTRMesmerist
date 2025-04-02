using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using Mesmerist.Utils;

namespace Mesmerist.Class.Medium.Spirits
{
    internal class SpiritFeature
    {
        private static readonly string FeatName = "Spirits";
        internal const string DisplayName = "Spirits.Name";
        private static readonly string Description = "Spirits.Description";
        public static void Configure()
        {
            Archmage.Configure();
            Champion.Configure();
            Guardian.Configure();
            Hierophant.Configure();
            Marshal.Configure();
            Trickster.Configure();

            FeatureConfigurator.New(FeatName, Guids.SpiritFeature)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIsClassFeature(true)
                .AddFacts(new() { Guids.Archmage, Guids.Champion, Guids.Guardian, Guids.Hierophant, Guids.Marshal, Guids.Trickster })
                .Configure();
        }
    }
}
