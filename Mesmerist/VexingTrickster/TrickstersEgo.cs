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
using CharacterOptionsPlus.Util;

namespace Mesmerist.Mesmerist.VexingTrickster
{
    public class TrickstersEgo
    {
        private static readonly string FeatName = "TrickstersEgo";
        internal const string DisplayName = "TrickstersEgo.Name";
        private static readonly string Description = "TrickstersEgo.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);

        public static void Configure()
        {

            //TODO: Change CharacterLevel to ClassLevel(Mesmerist)
            BlueprintFeature trickstersEgo = FeatureConfigurator.New(FeatName, Guids.TrickstersEgo)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(FeatureRefs.Vindictive_SoliloquyFeature.Reference.Get().Icon)
                .SetIsClassFeature()
                .AddFacts(new() { FeatureRefs.CombatExpertiseFeature.Reference.Get() })
                .Configure();

            FeatureConfigurator.For(FeatureRefs.Feint)
                .AddPrerequisiteFeature(trickstersEgo, false, Kingmaker.Blueprints.Classes.Prerequisites.Prerequisite.GroupType.Any)
                .Configure();

            FeatureConfigurator.For(FeatureRefs.FinalFeint)
                .AddPrerequisiteFeature(trickstersEgo, false, Kingmaker.Blueprints.Classes.Prerequisites.Prerequisite.GroupType.Any)
                .Configure();
        }
    }
}
