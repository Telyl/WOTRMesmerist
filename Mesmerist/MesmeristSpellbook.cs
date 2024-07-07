using BlueprintCore.Blueprints.Configurators.Classes.Spells;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using CharacterOptionsPlus.Util;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.EntitySystem.Stats;
using Mesmerist.Mesmerist;
using Mesmerist.Mesmerist.BoldStares;
using Mesmerist.Utils;
using static UnityModManagerNet.UnityModManager.ModEntry;

namespace Mesmerist.Mesmerist
{
    class MesmeristSpellbook
    {
        private static readonly string SpellbookName = "MesmeristSpellbook";
        private static readonly Logging.Logger Logger = Logging.GetLogger(nameof(MesmeristSpellbook));
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

            return SpellbookConfigurator.New("MesmeristSpellbook", Guids.MesmeristSpellbook)
                .SetName("MesmeristClass.Name")
                .SetCharacterClass(Guids.Mesmerist)
                .SetSpellsPerDay(SpellsPerDayTable)
                .SetSpellsKnown(SpellSlotsTable)
                .SetSpellList(SpellListRefs.WizardIllusionSpellList.Reference.Get())
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
