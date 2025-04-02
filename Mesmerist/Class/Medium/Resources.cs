using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Mesmerist.Utils;
using Kingmaker.EntitySystem.Stats;

namespace Mesmerist.Class.Medium
{
    public class Resources
    {
        public static void Configure()
        {
            // Trick Resource
            BlueprintAbilityResource mtresource = AbilityResourceConfigurator.New("MediumSpiritResource", Guids.MediumSpiritResource)
                .SetMaxAmount(new BlueprintAbilityResource.Amount
                {
                    BaseValue = 1,
                    IncreasedByLevel = false,
                    IncreasedByLevelStartPlusDivStep = true,
                    StartingLevel = 2,
                    StartingIncrease = 0,
                    LevelStep = 2,
                    PerStepIncrease = 1,
                    MinClassLevelIncrease = 0,
                    m_ClassDiv = [BlueprintTool.GetRef<BlueprintCharacterClassReference>(Guids.Medium)],
                    IncreasedByStat = true,
                    ResourceBonusStat = StatType.Charisma
                })
                .SetMax(10)
                .SetUseMax(false)
                .Configure();

            FeatureConfigurator.New("MesmeristTrickResourceFeature", Guids.MediumSpiritResourceFeature)
                .SetHideInUI(true)
                .AddAbilityResources(resource: mtresource, restoreAmount: true, useThisAsResource: false)
                .Configure();
        }
    }
}
