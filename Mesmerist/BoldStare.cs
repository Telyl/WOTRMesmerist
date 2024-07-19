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
using Mesmerist.Mesmerist.BoldStares;
using CharacterOptionsPlus.Util;

namespace Mesmerist.Mesmerist
{
    public class BoldStare
    {
        private static readonly string FeatName = "BoldStare";
        internal const string DisplayName = "BoldStare.Name";
        private static readonly string Description = "BoldStare.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);

        public static void Configure()
        {

            //TODO: Change CharacterLevel to ClassLevel(Mesmerist)
            FeatureSelectionConfigurator.New(FeatName, Guids.BoldStareSelection)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.Blindness.Reference.Get().Icon)
                .SetIsClassFeature()
                .AddToAllFeatures([Guids.Disorientation, Guids.Disquiet, Guids.Distracted,
                Guids.Infiltration, Guids.Lethality, Guids.Nightmare,
                Guids.PsychicInception, Guids.SappedMagic, Guids.Sluggishness,
                Guids.Timidity, Guids.ManifoldStare, Guids.ManifoldStare2, Guids.ManifoldStare3])
                .Configure();


        }
    }
}
