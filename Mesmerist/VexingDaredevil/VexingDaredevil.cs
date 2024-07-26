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

namespace Mesmerist.Mesmerist.VexingDaredevil
{
    public class VexingDaredevil
    {
        private static readonly string ArchetypeName = "VexingDaredevil";
        internal const string DisplayName = "VexingDaredevil.Name";
        private static readonly string Description = "VexingDaredevil.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(ArchetypeName);

        public static void Configure()
        {
            ShimmeringBody.Configure();

            var entries = LevelEntryBuilder.New()
                .AddEntry(1, FeatureRefs.MartialWeaponProficiency.Reference.Get());

            ArchetypeConfigurator.New(ArchetypeName, Guids.VexingDaredevil, Guids.Mesmerist)
                .SetLocalizedName(DisplayName)
                .SetLocalizedDescription(Description)
                .SetRemoveSpellbook(false)
                .SetReplaceClassSkills(false)
                .SetReplaceStartingEquipment(false)
                .AddToRemoveFeatures(1, Guids.MesmeristTrickSelection)
                .AddToRemoveFeatures(3, [Guids.BoldStareSelection, Guids.TouchTreatment])
                .AddToRemoveFeatures(6, Guids.TouchTreatmentModerate)
                .AddToRemoveFeatures(7, Guids.BoldStareSelection)
                .AddToRemoveFeatures(10, Guids.TouchTreatmentGreater)
                .AddToRemoveFeatures(11, Guids.BoldStareSelection)
                .AddToRemoveFeatures(14, Guids.TouchTreatmentBreak)
                .AddToRemoveFeatures(15, Guids.BoldStareSelection)
                .AddToRemoveFeatures(19, Guids.BoldStareSelection)
                .AddToAddFeatures(1, FeatureRefs.MartialWeaponProficiency.Reference.Get())
                .AddToAddFeatures(3, FeatureRefs.Feint.Reference.Get(), Guids.DazzlingFeint)
                .AddToAddFeatures(6, FeatureRefs.FinalFeint.Reference.Get())
                .AddToAddFeatures(7, Guids.DazzlingFeint)
                .AddToAddFeatures(10, FeatureSelectionRefs.RogueTalentSelection.Reference.Get())
                .AddToAddFeatures(11, Guids.ShimmeringBody, Guids.DazzlingFeint)
                .AddToAddFeatures(14,Guids.DazzlingFeint)
                .AddToAddFeatures(15, Guids.DazzlingFeint)
                .AddToAddFeatures(19, Guids.DazzlingFeint)
                .Configure();

        }
    }
}
