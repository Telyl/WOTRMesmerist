using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using CharacterOptionsPlus.Util;
using Mesmerist.Utils;
using static Kingmaker.UnitLogic.FactLogic.AddMechanicsFeature;

namespace Mesmerist.Medium.Champion
{
    public class ChampionGreater
    {
        private static readonly string FeatName = "ChampionGreater";
        internal const string DisplayName = "ChampionGreater.Name";
        private static readonly string Description = "ChampionGreater.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);
        public static void Configure()
        {
            FeatureConfigurator.New(FeatName, Guids.ChampionGreater)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.ImitationFighterAbility.Reference.Get().Icon)
                .AddMechanicsFeature(MechanicsFeatureType.Pounce)
                .Configure();
        }
    }
}
