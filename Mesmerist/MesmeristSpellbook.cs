using BlueprintCore.Blueprints.Configurators.Classes.Spells;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Spells;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using CharacterOptionsPlus.Util;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.EntitySystem.Stats;
using Mesmerist.Mesmerist;
using Mesmerist.Mesmerist.BoldStares;
using Mesmerist.Utils;
using System.Linq;
using TabletopTweaks.Core.Utilities;
using static UnityModManagerNet.UnityModManager.ModEntry;

namespace Mesmerist.Mesmerist
{
    class MesmeristSpellbook
    {
        private static readonly string SpellbookName = "MesmeristSpellbook";
        private static readonly Logging.Logger Logger = Logging.GetLogger(nameof(MesmeristSpellbook));

        public static SpellLevelList Create0thLevelSpells()
        {
            var spelllist = new SpellLevelList(0);
            spelllist.m_Spells = new() {
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.Daze.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.Flare.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.Guidance.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.MageLight.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.Resistance.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.Stabilize.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.Virtue.ToString()),

            };
            return spelllist;
        }
        public static SpellLevelList Create1stLevelSpells()
        {
            SpellLevelList spelllist = new SpellLevelList(1);
            spelllist.m_Spells = new()
            {
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.Bane.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.ColorSpray.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.Command.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.CauseFear.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.Doom.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.ExpeditiousRetreat.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.FaerieFire.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.Grease.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.HideousLaughter.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.Hypnotism.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.IllOmen.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.RayOfEnfeeblement.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.RemoveFear.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.RemoveSickness.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.Sleep.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.TouchOfGracelessness.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.Vanish.ToString())
            };
            /*if (Settings.IsTTTBaseEnabled())
            {
                Logger.Log("I am in TTTBaseEnabled");
                string LongArmBuff = "d6a18709-af1b-4600-89c3-ce336373c4f7";
                var TTTSpell = BlueprintTool.GetRef<BlueprintAbilityReference>(LongArmBuff);
                spelllist.m_Spells.Append<BlueprintAbilityReference>(TTTSpell);
            }*/
            return spelllist;
        }
        public static SpellLevelList Create2ndLevelSpells()
        {
            SpellLevelList spelllist = new SpellLevelList(2);
            spelllist.m_Spells = new()
            {
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.Blindness.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.Blur.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.Castigate.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.CatsGrace.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.DelayPoison.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.EaglesSplendor.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.FalseLife.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.HauntingMists.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.HoldAnimal.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.HoldPerson.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.Invisibility.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.MirrorImage.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.RestorationLesser.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.Rage.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.Scare.ToString()),
            };
            return spelllist;
        }
        public static SpellLevelList Create3rdLevelSpells()
        {
            SpellLevelList spelllist = new SpellLevelList(3);
            spelllist.m_Spells = new()
            {
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.BestowCurse.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.ConfusionSpell.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.CrushingDespair.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.CurseOfMagicNegation.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.DeepSlumber.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.Displacement.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.DominateAnimal.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.FalseLifeGreater.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.Fear.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.OverwhelmingGrief.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.RayOfExhaustion.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.RemoveBlindness.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.RemoveCurse.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.SeeInvisibility.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.VampiricTouch.ToString()),
            };
            if (Settings.IsTTTBaseEnabled())
            {
                Logger.Log("I am in TTTBaseEnabled");
                string ShadowEnchantment = "d934f706-a12b-40ec-87a9-c8baf221b8a9";
                var TTTSpell = BlueprintTool.GetRef<BlueprintAbilityReference>(ShadowEnchantment);
                spelllist.m_Spells.Append<BlueprintAbilityReference>(TTTSpell);
            }
            return spelllist;
        }
        public static SpellLevelList Create4thLevelSpells()
        {
            SpellLevelList spelllist = new SpellLevelList(4);
            spelllist.m_Spells = new()
            {
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.BreakEnchantment.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.CommandGreater.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.DimensionDoor.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.DominatePerson.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.Enervation.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.FreedomOfMovement.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.HoldMonster.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.InvisibilityGreater.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.PhantasmalKiller.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.Poison.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.Restoration.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.Serenity.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.ShadowConjuration.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.ShadowFormAbility.ToString()),
            };
            return spelllist;
        }
        public static SpellLevelList Create5thLevelSpells()
        {
            SpellLevelList spelllist = new SpellLevelList(4);
            spelllist.m_Spells = new()
            {
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.CastigateMass.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.CloakofDreams.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.Feeblemind.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.JoyfulRapture.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.MindFog.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.PhantasmalPutrefaction.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.PhantasmalWeb.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.ShadowEvocation.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.WavesOfFatigue.ToString()),
            };
            return spelllist;
        }
        public static SpellLevelList Create6thLevelSpells()
        {
            SpellLevelList spelllist = new SpellLevelList(4);
            spelllist.m_Spells = new()
            {
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.EuphoricTranquility.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.Eyebite.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.HoldPersonMass.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.InvisibilityMass.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.OverwhelmingPresence.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.PowerWordBlind.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.TrueSeeing.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.WavesOfEctasy.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.WavesOfExhaustion.ToString()),
            };
            if (Settings.IsTTTBaseEnabled())
            {
                Logger.Log("I am in TTTBaseEnabled");
                string ShadowEnchantmentGreater = "ba079628-2748-4eb3-8bf0-b6aadd9f5f22";
                var TTTSpell = BlueprintTool.GetRef<BlueprintAbilityReference>(ShadowEnchantmentGreater);
                spelllist.m_Spells.Append<BlueprintAbilityReference>(TTTSpell);
            }
            return spelllist;
        }

        public static BlueprintSpellList CreateSpellList()
        {
            return SpellListConfigurator.New(SpellbookName + "SpellList", Guids.MesmeristSpellList)
                .AddToSpellsByLevel(Create0thLevelSpells(),
                Create1stLevelSpells(),
                Create2ndLevelSpells(),
                Create3rdLevelSpells(),
                Create4thLevelSpells(),
                Create5thLevelSpells(),
                Create6thLevelSpells())
                .Configure();
        }
        public static BlueprintSpellbook Configure()
        {
            var SpellSlotsTable = SpellsTableConfigurator.New("MesmeristSpellSlotsTable", Guids.MesmeristSpellSlotsTable)
                .SetLevels(new SpellsLevelEntry[] {
                    new SpellsLevelEntry{ Count = new int[] { 0 } },//0
                    new SpellsLevelEntry{ Count = new int[] { 0, 2 } },//1
                    new SpellsLevelEntry{ Count = new int[] { 0, 3 } },//2
                    new SpellsLevelEntry{ Count = new int[] { 0, 4 } },//3
                    new SpellsLevelEntry{ Count = new int[] { 0, 4, 2 } },//4
                    new SpellsLevelEntry{ Count = new int[] { 0, 4, 3 } },//5
                    new SpellsLevelEntry{ Count = new int[] { 0, 4, 4 } },//6
                    new SpellsLevelEntry{ Count = new int[] { 0, 5, 4, 2 } },//7
                    new SpellsLevelEntry{ Count = new int[] { 0, 5, 4, 3 } },//8
                    new SpellsLevelEntry{ Count = new int[] { 0, 5, 4, 4 } },//9
                    new SpellsLevelEntry{ Count = new int[] { 0, 5, 5, 4, 2 } },//10
                    new SpellsLevelEntry{ Count = new int[] { 0, 6, 5, 4, 3 } },//11
                    new SpellsLevelEntry{ Count = new int[] { 0, 6, 5, 4, 4 } },//12
                    new SpellsLevelEntry{ Count = new int[] { 0, 6, 5, 4, 4, 2 } },//13
                    new SpellsLevelEntry{ Count = new int[] { 0, 6, 6, 5, 4, 3 } },//14
                    new SpellsLevelEntry{ Count = new int[] { 0, 6, 6, 5, 4, 4 } },//15
                    new SpellsLevelEntry{ Count = new int[] { 0, 6, 6, 5, 5, 4, 2 } },//16
                    new SpellsLevelEntry{ Count = new int[] { 0, 6, 6, 6, 5, 4, 3 } },//17
                    new SpellsLevelEntry{ Count = new int[] { 0, 6, 6, 6, 5, 4, 4 } },//18
                    new SpellsLevelEntry{ Count = new int[] { 0, 6, 6, 6, 5, 5, 4 } },//19
                    new SpellsLevelEntry{ Count = new int[] { 0, 6, 6, 6, 6, 5, 5 } }//20
                    })
                .Configure();

            var SpellsPerDayTable = SpellsTableConfigurator.New("MesmeristSpellPerDayTable", Guids.MesmeristSpellsPerDayTable)
                .SetLevels(new SpellsLevelEntry[] {
                    new SpellsLevelEntry{ Count = new int[] { 0 } },//0
                    new SpellsLevelEntry{ Count = new int[] { 0, 1 } },//1
                    new SpellsLevelEntry{ Count = new int[] { 0, 2 } },//2
                    new SpellsLevelEntry{ Count = new int[] { 0, 3 } },//3
                    new SpellsLevelEntry{ Count = new int[] { 0, 3, 1 } },//4
                    new SpellsLevelEntry{ Count = new int[] { 0, 4, 2 } },//5
                    new SpellsLevelEntry{ Count = new int[] { 0, 4, 3 } },//6
                    new SpellsLevelEntry{ Count = new int[] { 0, 4, 3, 1 } },//7
                    new SpellsLevelEntry{ Count = new int[] { 0, 4, 4, 2 } },//8
                    new SpellsLevelEntry{ Count = new int[] { 0, 5, 4, 3 } },//9
                    new SpellsLevelEntry{ Count = new int[] { 0, 5, 4, 3, 1 } },//10
                    new SpellsLevelEntry{ Count = new int[] { 0, 5, 4, 4, 2 } },//11
                    new SpellsLevelEntry{ Count = new int[] { 0, 5, 5, 4, 3 } },//12
                    new SpellsLevelEntry{ Count = new int[] { 0, 5, 5, 4, 3, 1 } },//13
                    new SpellsLevelEntry{ Count = new int[] { 0, 5, 5, 4, 4, 2 } },//14
                    new SpellsLevelEntry{ Count = new int[] { 0, 5, 5, 5, 4, 3 } },//15
                    new SpellsLevelEntry{ Count = new int[] { 0, 5, 5, 5, 4, 3, 1 } },//16
                    new SpellsLevelEntry{ Count = new int[] { 0, 5, 5, 5, 4, 4, 2 } },//17
                    new SpellsLevelEntry{ Count = new int[] { 0, 5, 5, 5, 5, 4, 3 } },//18
                    new SpellsLevelEntry{ Count = new int[] { 0, 5, 5, 5, 5, 5, 4 } },//19
                    new SpellsLevelEntry{ Count = new int[] { 0, 5, 5, 5, 5, 5, 5 } }//20
                    })
                .Configure();

            var MesemeristSpellList = CreateSpellList();

            return SpellbookConfigurator.New("MesmeristSpellbook", Guids.MesmeristSpellbook)
                .SetName("MesmeristClass.Name")
                .SetCharacterClass(Guids.Mesmerist)
                .SetSpellsPerDay(SpellsPerDayTable)
                .SetSpellsKnown(SpellSlotsTable)
                .SetSpellList(MesemeristSpellList)
                .SetCastingAttribute(StatType.Charisma)
                .SetAllSpellsKnown(false)
                .SetIsMythic(false)
                .SetSpontaneous(true)
                .SetCantripsType(CantripsType.Cantrips)
                .SetIsArcane(false)
                .SetIsArcanist(false)
                .SetCanCopyScrolls(false)
                .SetCasterLevelModifier(0)
                .Configure();
        }
    }
}
