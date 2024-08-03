using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using CharacterOptionsPlus.Util;
using Mesmerist.Utils;

namespace Mesmerist.Medium.Champion
{
    public class ChampionLesser
    {
        private static readonly string FeatName = "ChampionLesser";
        internal const string DisplayName = "ChampionLesser.Name";
        private static readonly string Description = "ChampionLesser.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);
        public static void Configure()
        {
            BuffConfigurator.New(FeatName + "Buff", Guids.ChampionLesserBuff)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.ImitationFighterAbility.Reference.Get().Icon)
                .AddTemporaryFeat(FeatureRefs.MartialWeaponProficiency.Reference.Get())
                .AddTemporaryFeat(FeatureRefs.WeaponFinesse.Reference.Get())
                .Configure();

            FeatureConfigurator.New(FeatName, Guids.ChampionLesser)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.ImitationFighterAbility.Reference.Get().Icon)
                .AddFacts(new() { Guids.ChampionLesserBuff })
                .Configure();
        }
    }
}
