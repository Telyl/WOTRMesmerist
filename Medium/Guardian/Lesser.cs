using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using CharacterOptionsPlus.Util;
using Mesmerist.Utils;

namespace Mesmerist.Medium.Guardian
{
    public class GuardianLesser
    {
        private static readonly string FeatName = "GuardianLesser";
        internal const string DisplayName = "GuardianLesser.Name";
        private static readonly string Description = "GuardianLesser.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);
        public static void Configure()
        {
            BuffConfigurator.New(FeatName + "Buff", Guids.GuardianLesserBuff)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.ImitationFighterAbility.Reference.Get().Icon)
                .AddTemporaryFeat(FeatureRefs.HeavyArmorProficiency.Reference.Get())
                .AddTemporaryFeat(FeatureRefs.TowerShieldProficiency.Reference.Get())
                .AddTemporaryFeat(FeatureRefs.ShieldsProficiency.Reference.Get())
                .AddTemporaryFeat(FeatureRefs.ShieldBashFeature.Reference.Get())
                .Configure();

            FeatureConfigurator.New(FeatName, Guids.GuardianLesser)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.ImitationFighterAbility.Reference.Get().Icon)
                .AddFacts(new() { Guids.GuardianLesserBuff })
                .Configure();
        }
    }
}
