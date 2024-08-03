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
using CharacterOptionsPlus.Util;
using Mesmerist.Utils;
using System;
using Mesmerist.Medium.Archmage;

namespace Mesmerist.Medium
{
    /// <summary>
    /// Adds the Strong Jaw spell that only effects creatures of AnimalType.
    /// </summary>
    public class MediumClass
    {
        private static readonly string ClassName = "MediumClass";
        internal const string DisplayName = "MediumClass.Name";
        private static readonly string Description = "MediumClass.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(nameof(MediumClass));
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
                Logger.LogException("MediumClass.Configure", e);
            }
        }
        private static void ConfigureDisabled()
        {
            CharacterClassConfigurator.New(ClassName, Guids.Medium).Configure();
        }
        public static void ConfigureEnabled()
        {
            BlueprintCharacterClass mediumclass = CharacterClassConfigurator.New(ClassName, Guids.Medium).Configure();
            BlueprintProgression mediumprogression = MediumProgression.Configure();
            BlueprintSpellbook mediumspellbook = MediumSpellbook.Configure();

            CharacterClassConfigurator.For(Guids.Medium)
                .SetLocalizedName(DisplayName)
                .SetLocalizedDescription(Description)
                .SetSkillPoints(3) // Medium is 4 + INT in TT
                .SetHitDie(DiceType.D8)
                .SetPrestigeClass(false)
                .SetIsMythic(false)
                .SetHideIfRestricted(false)
                .SetBaseAttackBonus(StatProgressionRefs.BABMedium.Reference.Get())
                .SetFortitudeSave(StatProgressionRefs.SavesLow.Reference.Get())
                .SetReflexSave(StatProgressionRefs.SavesLow.Reference.Get())
                .SetWillSave(StatProgressionRefs.SavesHigh.Reference.Get())
                .SetProgression(mediumprogression)
                .SetSpellbook(mediumspellbook)
                .SetIsDivineCaster(false)
                .SetIsArcaneCaster(false)
                .SetStartingGold(411)
                .SetStartingItems(
                ItemWeaponRefs.ColdIronShortsword.Reference.Get(),
                ItemArmorRefs.ScalemailStandard.Reference.Get(),
                ItemEquipmentUsableRefs.PotionOfCureLightWounds.Reference.Get(),
                ItemEquipmentUsableRefs.ScrollOfMageArmor.Reference.Get(),
                ItemEquipmentUsableRefs.ScrollOfMageShield.Reference.Get())
                .SetPrimaryColor(11)
                .SetSecondaryColor(47)
                .SetDifficulty(3)
                .AddToMaleEquipmentEntities("65e7ae8b40be4d64ba07d50871719259", "04244d527b8a1f14db79374bc802aaaa")
                .AddToFemaleEquipmentEntities("11266d19b35cb714d96f4c9de08df48e", "64abd9c4d6565de419f394f71a2d496f")
                .AddToClassSkills(
                StatType.SkillPersuasion,
                StatType.SkillLoreReligion,
                StatType.SkillKnowledgeArcana,
                StatType.SkillPerception,
                StatType.SkillUseMagicDevice)
                .AddPrerequisiteIsPet(not: true, hideInUI: true)
                .AddToRecommendedAttributes(StatType.Charisma)
                .Configure();

            BlueprintCharacterClassReference classref = mediumclass.ToReference<BlueprintCharacterClassReference>();
            BlueprintRoot root = BlueprintTool.Get<BlueprintRoot>("2d77316c72b9ed44f888ceefc2a131f6");
            root.Progression.m_CharacterClasses = CommonTool.Append(root.Progression.m_CharacterClasses, classref);




        }
    }
}