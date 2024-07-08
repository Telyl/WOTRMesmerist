using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Classes;
using Kingmaker.EntitySystem.Stats;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using Mesmerist.Utils;
using static UnityModManagerNet.UnityModManager.ModEntry;
using System;
using Kingmaker.Enums;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints.Classes.Prerequisites;
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using Kingmaker.Blueprints.Classes.Spells;
using CharacterOptionsPlus.Util;
using Kingmaker.Blueprints;
using Kingmaker.UnitLogic.Mechanics.Components;

namespace Mesmerist.Mesmerist.BoldStares
{
    public class ManifoldStare
    {
        private static readonly string FeatName = "ManifoldStare";
        internal const string DisplayName = "ManifoldStare.Name";
        private static readonly string Description = "ManifoldStare.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);

        public static void Configure()
        {

            var ManifoldStare = FeatureConfigurator.New(FeatName, Guids.ManifoldStare)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIsClassFeature()
                .AddPrerequisiteClassLevel(Guids.Mesmerist, 3)
                .AddFeatureOnApply(Guids.ManifoldStarePainfulStare)
                .Configure();

            FeatureConfigurator.New(FeatName + "2", Guids.ManifoldStare2)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIsClassFeature()
                .AddPrerequisiteClassLevel(Guids.Mesmerist, 9)
                .AddPrerequisiteFeature(Guids.ManifoldStare)
                .AddFeatureOnApply(Guids.ManifoldStarePainfulStare)
                .Configure();

            FeatureConfigurator.New(FeatName + "3", Guids.ManifoldStare3)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIsClassFeature()
                .AddPrerequisiteFeature(Guids.ManifoldStare2)
                .AddPrerequisiteClassLevel(Guids.Mesmerist, 15)
                .AddFeatureOnApply(Guids.ManifoldStarePainfulStare)
                .Configure();

        }
    }
}
