using BlueprintCore.Blueprints.Configurators.Classes;
using BlueprintCore.Blueprints.Configurators.Classes.Spells;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using CharacterOptionsPlus.Util;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.EntitySystem.Stats;
using Mesmerist.Utils;

namespace Mesmerist.Medium.Archmage
{
    class ArchmageSpellbook
    {
        private static readonly string ClassName = "Archmage";
        internal const string ArchmageName = "Archmage.Name";
        private static readonly string ArchmageDescription = "Archmage.Description";
        private static readonly Logging.Logger Logger = Logging.GetLogger(nameof(Archmage));

        public static void Configure()
        {
            var SpellSlotsTable = SpellsTableConfigurator.New(ClassName + "SpellSlotsTable", Guids.ArchmageSpellSlotsTable)
                .SetLevels(new SpellsLevelEntry[] {
                    new SpellsLevelEntry{ Count = new int[] { 0 } },//0
                    new SpellsLevelEntry{ Count = new int[] { 0, 1 } },//1
                    new SpellsLevelEntry{ Count = new int[] { 0, 1 } },//2
                    new SpellsLevelEntry{ Count = new int[] { 0, 1 } },//3
                    new SpellsLevelEntry{ Count = new int[] { 0, 1, 1 } },//4
                    new SpellsLevelEntry{ Count = new int[] { 0, 1, 1 } },//5
                    new SpellsLevelEntry{ Count = new int[] { 0, 1, 1 } },//6
                    new SpellsLevelEntry{ Count = new int[] { 0, 1, 1, 1 } },//7
                    new SpellsLevelEntry{ Count = new int[] { 0, 1, 1, 1 } },//8
                    new SpellsLevelEntry{ Count = new int[] { 0, 1, 1, 1 } },//9
                    new SpellsLevelEntry{ Count = new int[] { 0, 1, 1, 1, 1 } },//10
                    new SpellsLevelEntry{ Count = new int[] { 0, 1, 1, 1, 1 } },//11
                    new SpellsLevelEntry{ Count = new int[] { 0, 1, 1, 1, 1 } },//12
                    new SpellsLevelEntry{ Count = new int[] { 0, 1, 1, 1, 1, 1 } },//13
                    new SpellsLevelEntry{ Count = new int[] { 0, 1, 1, 1, 1, 1 } },//14
                    new SpellsLevelEntry{ Count = new int[] { 0, 1, 1, 1, 1, 1 } },//15
                    new SpellsLevelEntry{ Count = new int[] { 0, 1, 1, 1, 1, 1, 1 } },//16
                    new SpellsLevelEntry{ Count = new int[] { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1 } },//17
                    new SpellsLevelEntry{ Count = new int[] { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1 } },//18
                    new SpellsLevelEntry{ Count = new int[] { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1 } },//19
                    new SpellsLevelEntry{ Count = new int[] { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1 } },//20
                    })
                .Configure();

            var SpellsPerDayTable = SpellsTableConfigurator.New(ClassName + "SpellPerDayTable", Guids.ArchmageSpellsPerDayTable)
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
                    new SpellsLevelEntry{ Count = new int[] { 0, 5, 5, 5, 5, 5, 5 } },//20
                    })
                .Configure();

            SpellbookConfigurator.New(ClassName + "Spellbook", Guids.ArchmageSpellbook)
                .SetName(ArchmageName)
                .SetSpellsPerDay(SpellsPerDayTable)
                .SetSpellSlots(SpellSlotsTable)
                .SetSpellList(SpellListRefs.WizardSpellList.Reference.Get())
                .SetCastingAttribute(StatType.Charisma)
                .SetAllSpellsKnown(true)
                .SetIsMythic(false)
                .SetSpontaneous(true)
                .SetCantripsType(CantripsType.Cantrips)
                .SetIsArcane(true)
                .SetIsArcanist(true)
                .SetCanCopyScrolls(false)
                .SetCasterLevelModifier(0)
                .Configure();
        }
    }
}