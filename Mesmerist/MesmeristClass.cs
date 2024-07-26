using BlueprintCore.Blueprints.References;
using static UnityModManagerNet.UnityModManager.ModEntry;
using Kingmaker.EntitySystem.Stats;
using BlueprintCore.Blueprints.Configurators.Classes;
using Kingmaker.RuleSystem;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Root;
using Kingmaker.Blueprints.Classes.Spells;
using Mesmerist.Utils;
using UnityEngine;
using System;
using CharacterOptionsPlus.Util;

namespace Mesmerist.Mesmerist
{
    /// <summary>
    /// Adds the Strong Jaw spell that only effects creatures of AnimalType.
    /// </summary>
    public class MesmeristClass
    {
        private static readonly string ClassName = "MesmeristClass";
        internal const string DisplayName = "MesmeristClass.Name";
        private static readonly string Description = "MesmeristClass.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(ClassName);

        internal static void Configure()
        {
            try
            {
                if (Settings.IsEnabled(Guids.Mesmerist))
                    ConfigureEnabled();
                else
                    ConfigureDisabled();
            }
            catch (Exception e)
            {
                Logger.LogException("ConsummateLiar.Configure", e);
            }
        }
        private static void ConfigureDisabled()
        {
            CharacterClassConfigurator.New(ClassName, Guids.Mesmerist).Configure();
        }
        private static void ConfigureEnabled()
        {
            BlueprintCharacterClass mesmeristClass = CharacterClassConfigurator.New(ClassName, Guids.Mesmerist).Configure();
            BlueprintProgression mesmeristProgression = MesmeristProgression.Configure();
            BlueprintSpellbook mesmeristSpellbook = MesmeristSpellbook.Configure();

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
                .SetPrimaryColor(0)
                .SetSecondaryColor(52)
                .SetDifficulty(3)
                .AddToEquipmentEntities("b6909b0518714fa695f5f7f80761524a", "21d733c2019c4db780a172680e16198c")
                .AddToMaleEquipmentEntities("ae5e71563e46899428dd0205914391db", "195163e220b10fb43be4d86038cdb72f")
                .AddToFemaleEquipmentEntities("a212481fa5646dd428e4c7fd9f720c8d", "b9a1009f8f1387c4f891e37a24e189ca")
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
                //.AddToArchetypes(Guids.VexingDaredevil)
                .Configure();

            BlueprintCharacterClassReference classref = mesmeristClass.ToReference<BlueprintCharacterClassReference>();
            BlueprintRoot root = BlueprintTool.Get<BlueprintRoot>("2d77316c72b9ed44f888ceefc2a131f6");
            root.Progression.m_CharacterClasses = CommonTool.Append(root.Progression.m_CharacterClasses, classref);




        }
    }
}