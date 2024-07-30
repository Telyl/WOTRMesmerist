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

namespace Mesmerist.Mesmerist.VexingTrickster
{
    public class VexingTrickster
    {
        private static readonly string ArchetypeName = "VexingTrickster";
        internal const string DisplayName = "VexingTrickster.Name";
        private static readonly string Description = "VexingTrickster.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(ArchetypeName);

        public static void Configure()
        {

            var entries = LevelEntryBuilder.New()
                .AddEntry(1, FeatureRefs.MartialWeaponProficiency.Reference.Get());

            ArchetypeConfigurator.New(ArchetypeName, Guids.VexingTrickster, Guids.Mesmerist)
                .SetLocalizedName(DisplayName)
                .SetLocalizedDescription(Description)
                .SetRemoveSpellbook(false)
                .SetReplaceClassSkills(false)
                .SetReplaceStartingEquipment(false)
                .AddToRemoveFeatures(1, Guids.ConsummateLiar)
                .AddToRemoveFeatures(2, Guids.ToweringEgo)
                .AddToRemoveFeatures(3, Guids.TouchTreatment)
                .AddToRemoveFeatures(6, Guids.TouchTreatmentModerate)
                .AddToRemoveFeatures(10, Guids.TouchTreatmentGreater)
                .AddToRemoveFeatures(14, Guids.TouchTreatmentBreak)
                .AddToAddFeatures(1, Guids.ConsummateTrickster)
                .AddToAddFeatures(2, Guids.TrickstersEgo)
                .AddToAddFeatures(3, Guids.TrickFeats)
                .AddToAddFeatures(6, Guids.ManifoldHijinks)
                .AddToAddFeatures(10, Guids.TrickFeats)
                .AddToAddFeatures(14, Guids.ManifoldHijinks)
                .Configure();

        }
    }
}
