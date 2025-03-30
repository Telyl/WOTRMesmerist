using BlueprintCore.Blueprints.References;
using Kingmaker.EntitySystem.Stats;
using BlueprintCore.Blueprints.Configurators.Classes;
using Kingmaker.RuleSystem;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Root;
using Kingmaker.Blueprints.Classes.Spells;
using UnityModManagerNet;
using Mesmerist.Utils;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Utils.Types;
using Mesmerist.Class.BoldStares;
using Mesmerist.Class.Tricks;

namespace Mesmerist.Class
{
    /// <summary>
    /// Adds the Strong Jaw spell that only effects creatures of AnimalType.
    /// </summary>
    public class Mesmerist
    {
        private static readonly string ClassName = "MesmeristClass";
        internal const string DisplayName = "MesmeristClass.Name";
        private static readonly string Description = "MesmeristClass.Description";
        internal static void Configure()
        {
            BlueprintCharacterClass mesmeristClass = CharacterClassConfigurator.New(ClassName, Guids.Mesmerist).Configure();
            BlueprintSpellbook mesmeristSpellbook = Spellbook.Configure();

            Proficiencies.Configure();
            ConsummateLiar.Configure();
            Resources.Configure();
            TrickSelection.Configure();
            PainfulStare.Configure();
            ToweringEgo.Configure();
            
            BoldStare.Configure();
            HypnoticStare.Configure();

            MasterfulTricks.Configure();
            MentalPotency.Configure();

            TouchTreatment.Configure();


            var entries = LevelEntryBuilder.New() 
                .AddEntry(1, Guids.ConsummateLiar, Guids.MesmeristProficiencies, Guids.HypnoticStare,
                Guids.MesmeristTrickSelection,
                Guids.MesmeristTrickResourceFeature,
                Guids.TouchTreatmentResourceFeature, Guids.PainfulStare, Guids.PainfulStareBaseDmg)
                .AddEntry(2, Guids.ToweringEgo, Guids.MesmeristTrickSelection)
                .AddEntry(3, Guids.BoldStareSelection, Guids.TouchTreatment, Guids.PainfulStareRank)
                .AddEntry(4, Guids.MesmeristTrickSelection, Guids.PainfulStareBaseDmg)
                .AddEntry(5, Guids.MentalPotency)
                .AddEntry(6, Guids.MesmeristTrickSelection, Guids.TouchTreatmentModerate, Guids.PainfulStareRank, Guids.PainfulStareBaseDmg)
                .AddEntry(7, Guids.BoldStareSelection)
                .AddEntry(8, Guids.MesmeristTrickSelection, Guids.HypnoticStareUpgrade, Guids.PainfulStareBaseDmg)
                .AddEntry(9, Guids.PainfulStareRank)
                .AddEntry(10, Guids.MesmeristTrickSelection, Guids.MentalPotency, Guids.TouchTreatmentGreater, Guids.PainfulStareBaseDmg)
                .AddEntry(11, Guids.BoldStareSelection)
                .AddEntry(12, Guids.MesmeristTrickSelection, Guids.MasterfulTricks, Guids.PainfulStareRank, Guids.PainfulStareBaseDmg)
                .AddEntry(14, Guids.MesmeristTrickSelection, Guids.TouchTreatmentBreak, Guids.PainfulStareBaseDmg)
                .AddEntry(15, Guids.BoldStareSelection, Guids.MentalPotency, Guids.PainfulStareRank)
                .AddEntry(16, Guids.MesmeristTrickSelection, Guids.PainfulStareBaseDmg)
                .AddEntry(18, Guids.MesmeristTrickSelection, Guids.PainfulStareRank, Guids.PainfulStareBaseDmg)
                .AddEntry(19, Guids.BoldStareSelection)
                .AddEntry(20, Guids.MesmeristTrickSelection, Guids.HypnoticStarePiercingGaze, Guids.MentalPotency, Guids.PainfulStareBaseDmg);


            BlueprintProgression mesmeristProgression = ProgressionConfigurator.New("MesmeristProgression", Guids.MesmeristProgression)
                .SetAllowNonContextActions(false)
                .SetHideInUI(false)
                .SetHideInCharacterSheetAndLevelUp(false)
                .SetHideNotAvailibleInUI(false)
                .SetRanks(1)
                .SetReapplyOnLevelUp(false)
                .SetIsClassFeature(true)
                .AddToClasses(Guids.Mesmerist)
                .SetForAllOtherClasses(false)
                .SetLevelEntries(entries)
                .Configure();

        //BlueprintSpellbook mesmeristSpellbook = MesmeristSpellbook.Configure();

        CharacterClassConfigurator.For(Guids.Mesmerist)
                .SetLocalizedName(DisplayName)
                .SetLocalizedDescription(Description)
                .SetSkillPoints(4) // Mesmerist is 6 + INT in TT
                .SetHitDie(DiceType.D8)
                .SetPrestigeClass(false)
                .SetIsMythic(false)
                .SetHideIfRestricted(false)
                .SetBaseAttackBonus(StatProgressionRefs.BABMedium.Reference.Get())
                .SetFortitudeSave(StatProgressionRefs.SavesLow.Reference.Get())
                .SetReflexSave(StatProgressionRefs.SavesHigh.Reference.Get())
                .SetWillSave(StatProgressionRefs.SavesHigh.Reference.Get())
                .SetProgression(mesmeristProgression)
                .SetSpellbook(mesmeristSpellbook)
                .SetIsDivineCaster(false)
                .SetIsArcaneCaster(false)
                .SetStartingGold(411)
                .SetStartingItems(
                ItemWeaponRefs.ColdIronDagger.Reference.Get(),
                ItemArmorRefs.StuddedStandard.Reference.Get(),
                ItemEquipmentUsableRefs.PotionOfCureLightWounds.Reference.Get(),
                ItemEquipmentUsableRefs.ScrollOfMageArmor.Reference.Get(),
                ItemEquipmentUsableRefs.ScrollOfMageShield.Reference.Get())
                .SetPrimaryColor(75) //44
                .SetSecondaryColor(9) //47
                .SetDifficulty(3)
                .AddToEquipmentEntities("b6909b0518714fa695f5f7f80761524a", "21d733c2019c4db780a172680e16198c")
                .AddToMaleEquipmentEntities("ae1e5e4fc4163094ba8bc06dec79d325", "e2e011242ea29fd4593d6cfbd06c8a2b")
                .AddToFemaleEquipmentEntities("46d879e169045334190df70681415f35", "b2fe1a2aa7dd60c41a185dfdfca2e33f")
                .AddToRecommendedAttributes(StatType.Charisma)
                .AddPrerequisiteIsPet(not: true, hideInUI: true)
                .AddToClassSkills(
                StatType.SkillPersuasion,
                StatType.SkillMobility,
                StatType.SkillLoreReligion,
                StatType.SkillKnowledgeArcana,
                StatType.SkillKnowledgeWorld,
                StatType.SkillPerception,
                StatType.SkillUseMagicDevice,
                StatType.SkillStealth,
                StatType.SkillThievery)
                .Configure();

            BlueprintCharacterClassReference classref = mesmeristClass.ToReference<BlueprintCharacterClassReference>();
            BlueprintRoot root = BlueprintTool.Get<BlueprintRoot>("2d77316c72b9ed44f888ceefc2a131f6");
            root.Progression.m_CharacterClasses = CommonTool.Append(root.Progression.m_CharacterClasses, classref);
        }
    }
}