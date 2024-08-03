using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using CharacterOptionsPlus.Util;
using Mesmerist.Utils;

namespace Mesmerist.Medium.Champion
{
    public class ChampionIntermediate
    {
        private static readonly string FeatName = "ChampionIntermediate";
        internal const string DisplayName = "ChampionIntermediate.Name";
        private static readonly string Description = "ChampionIntermediate.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);
        public static void Configure()
        {
            FeatureConfigurator.New(FeatName, Guids.ChampionIntermediate)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.ImitationFighterAbility.Reference.Get().Icon)
                .AddBuffExtraAttack(false, number: 1, penalized: false)
                .Configure();
        }
    }
}
