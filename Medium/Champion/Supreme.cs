using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Mesmerist.Utils;
using Kingmaker.Enums;
using BlueprintCore.Utils.Types;
using CharacterOptionsPlus.Util;

namespace Mesmerist.Medium.Champion
{
    public class ChampionSupreme
    {
        private static readonly string FeatName = "ChampionSupreme";
        internal const string DisplayName = "ChampionSupreme.Name";
        private static readonly string Description = "ChampionSupreme.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);

        public static void Configure()
        {
            FeatureConfigurator.New(FeatName, Guids.ChampionSupreme)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.ImitationFighterAbility.Reference.Get().Icon)
                .AddIncreaseDiceSizeOnAttack(0, checkWeaponCategories: false, checkWeaponSubCategories: false, 
                useContextBonus: true, value: ContextValues.Rank())
                .AddContextRankConfig(ContextRankConfigs.FeatureRank(Guids.SpiritBonus).WithDiv2Progression())
                .Configure();
        }
    }
}
