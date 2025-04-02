using BlueprintCore.Blueprints.References;
using Kingmaker.EntitySystem.Stats;
using BlueprintCore.Blueprints.Configurators.Classes;
using Kingmaker.RuleSystem;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Root;
using Kingmaker.Blueprints.Classes.Spells;
using Mesmerist.Utils;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Utils.Types;
using Mesmerist.Class.Medium.Spirits;

namespace Mesmerist.Class.Medium
{
    /// <summary>
    /// Adds the Strong Jaw spell that only effects creatures of AnimalType.
    /// </summary>
    public class MediumClass
    {
        private static readonly string ClassName = "MediumClass";
        internal const string DisplayName = "MediumClass.Name";
        private static readonly string Description = "MediumClass.Description";
        internal static void Configure()
        {
            BlueprintCharacterClass mediumClass= CharacterClassConfigurator.New(ClassName, Guids.Medium).Configure();
            BlueprintSpellbook mediumSpellbook = MediumSpellbook.Configure();

            MediumProficiencies.Configure();
            SpiritBonus.Configure();
            SpiritPower.Configure();
            SpiritFeature.Configure();
            SpiritSurge.Configure();



            var entries = LevelEntryBuilder.New()
                .AddEntry(1, Guids.MediumProficiencies, Guids.SpiritBonus, Guids.SpiritPowerLesser, Guids.SpiritFeature, Guids.SpiritSurge)
                .AddEntry(4, Guids.SpiritBonus)
                .AddEntry(6, Guids.SpiritPowerIntermediate)
                .AddEntry(8, Guids.SpiritBonus)
                .AddEntry(10, Guids.SpiritSurge)
                .AddEntry(11, Guids.SpiritPowerGreater)
                .AddEntry(12, Guids.SpiritBonus)
                .AddEntry(16, Guids.SpiritBonus)
                .AddEntry(17, Guids.SpiritPowerSupreme)
                .AddEntry(20, Guids.SpiritBonus, Guids.SpiritSurge);

            BlueprintProgression mediumProgression = ProgressionConfigurator.New("MediumProgression", Guids.MediumProgression)
                .SetAllowNonContextActions(false)
                .SetHideInUI(false)
                .SetHideInCharacterSheetAndLevelUp(false)
                .SetHideNotAvailibleInUI(false)
                .SetRanks(1)
                .SetReapplyOnLevelUp(false)
                .SetIsClassFeature(true)
                .AddToClasses(Guids.Medium)
                .SetForAllOtherClasses(false)
                .SetLevelEntries(entries)
                .AddToUIGroups(Guids.SpiritPowerLesser, Guids.SpiritPowerIntermediate, Guids.SpiritPowerGreater, Guids.SpiritPowerSupreme)
                .Configure();

        //BlueprintSpellbook mesmeristSpellbook = MesmeristSpellbook.Configure();

        CharacterClassConfigurator.For(Guids.Medium)
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
                .SetProgression(mediumProgression)
                .SetSpellbook(mediumSpellbook)
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

            BlueprintCharacterClassReference classref = mediumClass.ToReference<BlueprintCharacterClassReference>();
            BlueprintRoot root = BlueprintTool.Get<BlueprintRoot>("2d77316c72b9ed44f888ceefc2a131f6");
            root.Progression.m_CharacterClasses = CommonTool.Append(root.Progression.m_CharacterClasses, classref);
        }
    }
}