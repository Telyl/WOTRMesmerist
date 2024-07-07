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
                .SetSkillPoints(3) // Medium is 4 + INT in TT
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
                ItemWeaponRefs.ColdIronShortsword.Reference.Get(),
                ItemArmorRefs.ScalemailStandard.Reference.Get(),
                ItemEquipmentUsableRefs.PotionOfCureLightWounds.Reference.Get(),
                ItemEquipmentUsableRefs.ScrollOfMageArmor.Reference.Get(),
                ItemEquipmentUsableRefs.ScrollOfMageShield.Reference.Get())
                .SetPrimaryColor(11)
                .SetSecondaryColor(47)
                .SetDifficulty(3)
                .AddToMaleEquipmentEntities("1f538abc2802c5649b7ce177183f88c8", "54de61e669f916543b96da841357d2ff")
                .AddToFemaleEquipmentEntities("dc822f0446c675a45809202953fa52a7", "67d82fc7662a522449d5dc8ed622e33a")
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