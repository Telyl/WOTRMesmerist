using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.Enums.Damage;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Components;
using Mesmerist.Utils;
using Mesmerist.NewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UnityModManagerNet.UnityModManager.ModEntry;
using CharacterOptionsPlus.Util;
using BlueprintCore.Actions.Builder.BasicEx;
using Kingmaker.ElementsSystem;
using Kingmaker.Blueprints.Classes;

namespace Mesmerist.Features
{
    class IntensePain
    {
        private static readonly string FeatName = "IntensePain";
        private static readonly string DisplayName = "IntensePain.Name";
        private static readonly string Description = "IntensePain.Description";
        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);

        public static object Value { get; private set; }

        public static void Configure()
        {
            ProgressionConfigurator.New(FeatName + "Progression", Guids.IntensePainProgression)
                .SetIsClassFeature()
                .SetHideInUI()
                .SetClasses([Guids.Mesmerist])
                .SetGiveFeaturesForPreviousLevels(true)
                .AddToLevelEntry(7, Guids.PainfulStare)
                .AddToLevelEntry(12, Guids.PainfulStare)
                .AddToLevelEntry(18, Guids.PainfulStare)
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