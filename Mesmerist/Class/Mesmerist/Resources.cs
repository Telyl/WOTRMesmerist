using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components.Base;
using Kingmaker.UnitLogic.Abilities.Components;
using Mesmerist.Utils;
using Kingmaker.EntitySystem.Stats;

namespace Mesmerist.Class.Mesmerist
{
    public class Resources
    {
        public static void Configure()
        {
            //Touch Treatment Resource
            BlueprintAbilityResource ttresource = AbilityResourceConfigurator.New("TouchTreatmentResource", Guids.TouchTreatmentResource)
                .SetMaxAmount(new BlueprintAbilityResource.Amount
                {
                    BaseValue = 3,
                    IncreasedByLevel = false,
                    IncreasedByLevelStartPlusDivStep = false,
                    StartingLevel = 0,
                    StartingIncrease = 0,
                    LevelStep = 2,
                    PerStepIncrease = 0,
                    MinClassLevelIncrease = 0,
                    m_ClassDiv = [BlueprintTool.GetRef<BlueprintCharacterClassReference>(Guids.Mesmerist)],
                    IncreasedByStat = true,
                    ResourceBonusStat = StatType.Charisma
                })
                .SetMax(10)
                .SetUseMax(false)
                .Configure();

            FeatureConfigurator.New("TouchTreatmentResourceFeature", Guids.TouchTreatmentResourceFeature)
                .SetHideInUI(true)
                .AddAbilityResources(resource: ttresource, restoreAmount: true, useThisAsResource: false)
                .Configure();

            // Trick Resource
            BlueprintAbilityResource mtresource = AbilityResourceConfigurator.New("MesmeristTricksResource", Guids.MesmeristTrickResource)
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
                    m_ClassDiv = [BlueprintTool.GetRef<BlueprintCharacterClassReference>(Guids.Mesmerist)],
                    IncreasedByStat = true,
                    ResourceBonusStat = StatType.Charisma
                })
                .SetMax(10)
                .SetUseMax(false)
                .Configure();

            FeatureConfigurator.New("MesmeristTrickResourceFeature", Guids.MesmeristTrickResourceFeature)
                .SetHideInUI(true)
                .AddAbilityResources(resource: mtresource, restoreAmount: true, useThisAsResource: false)
                .Configure();
        }
    }
}
