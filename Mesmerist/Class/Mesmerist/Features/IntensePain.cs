﻿using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using Mesmerist.Utils;
using Kingmaker.Blueprints.Classes;

namespace Mesmerist.Class.Mesmerist.Features
{
    class IntensePain
    {
        private static readonly string FeatName = "IntensePain";
        private static readonly string DisplayName = "IntensePain.Name";
        private static readonly string Description = "IntensePain.Description";

        public static object Value { get; private set; }

        public static void Configure()
        {
            //TODO: Make painful stare go based off feature levels and not based off mesmerist level / 3
            ProgressionConfigurator.New(FeatName + "Progression", Guids.IntensePainProgression)
                .SetIsClassFeature()
                .SetHideInUI()
                .SetClasses([Guids.Mesmerist])
                .SetGiveFeaturesForPreviousLevels(true)
                .AddToLevelEntry(7, Guids.PainfulStareRank, Guids.PainfulStareBaseDmg)
                .AddToLevelEntry(8, Guids.PainfulStareBaseDmg)
                .AddToLevelEntry(12, Guids.PainfulStareRank, Guids.PainfulStareBaseDmg)
                .AddToLevelEntry(16, Guids.PainfulStareBaseDmg)
                .AddToLevelEntry(18, Guids.PainfulStareRank)
                .AddToLevelEntry(20, Guids.PainfulStareBaseDmg)
                .Configure();

            FeatureConfigurator.New(FeatName, Guids.IntensePain, [FeatureGroup.CombatFeat, FeatureGroup.Feat])
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIsClassFeature(true)
                .SetReapplyOnLevelUp(false)
                .AddFeatureOnApply(Guids.IntensePainProgression)
                .AddPrerequisiteClassLevel(Guids.Mesmerist, 7)
                .AddPrerequisiteFeature(Guids.PainfulStare)
                .AddRecommendationHasClasses(recommendedClasses: [Guids.Mesmerist])
                .SetRanks(1)
                .Configure();
        }
    }
}