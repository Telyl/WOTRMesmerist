using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.BasicEx;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.Configurators.Classes.Spells;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.FactLogic;
using Mesmerist.NewComponents.AbilitySpecific;
using Mesmerist.Utils;
using static Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff;

namespace Mesmerist.Class.Medium.Spirits
{
    internal class Archmage
    {
        private static readonly string FeatName = "Archmage";
        internal const string DisplayName = "Archmage.Name";
        private static readonly string Description = "Archmage.Description";

        private static readonly string BUFF = Guids.ArchmageBuff;
        private static readonly string ABILITY = Guids.ArchmageActivatableAbility;
        private static readonly string FEATURE = Guids.Archmage;

        private static void ArchmageSpellbook()
        {
            var SpellSlotsTable = SpellsTableConfigurator.New(FeatName + "SpellSlotsTable", Guids.ArchmageSpellSlotsTable)
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
                    new SpellsLevelEntry{ Count = new int[] { 0, 1, 1, 1, 1, 1, 1 } },//17
                    new SpellsLevelEntry{ Count = new int[] { 0, 1, 1, 1, 1, 1, 1 } },//18
                    new SpellsLevelEntry{ Count = new int[] { 0, 1, 1, 1, 1, 1, 1 } },//19
                    new SpellsLevelEntry{ Count = new int[] { 0, 1, 1, 1, 1, 1, 1 } },//20
                    })
                .Configure();

            var SpellsPerDayTable = SpellsTableConfigurator.New(FeatName + "SpellPerDayTable", Guids.ArchmageSpellsPerDayTable)
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
                    new SpellsLevelEntry{ Count = new int[] { 0, 5, 5, 5, 4, 4, 2, 1, 1, 1 } },//17
                    new SpellsLevelEntry{ Count = new int[] { 0, 5, 5, 5, 5, 4, 3, 1, 1, 1 } },//18
                    new SpellsLevelEntry{ Count = new int[] { 0, 5, 5, 5, 5, 5, 4, 1, 1, 1 } },//19
                    new SpellsLevelEntry{ Count = new int[] { 0, 5, 5, 5, 5, 5, 5, 1, 1, 1 } },//20
                    })
                .Configure();

            SpellbookConfigurator.New(FeatName + "Spellbook", Guids.ArchmageSpellbook)
                .SetName(DisplayName)
                .SetCharacterClass(Guids.Mesmerist)
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

        public static void Configure()
        {
            ArchmageSpellbook();

            BuffConfigurator.New(FeatName + "Supreme", Guids.ArchmageSupreme)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(BuffRefs.ElectricityVulnerabilityBuff.Reference.Get().Icon)
                .AddAutoMetamagic(metamagic: Kingmaker.UnitLogic.Abilities.Metamagic.Intensified, checkSpellbook: true, spellbook: Guids.ArchmageSpellbook)
                .Configure();

            BuffConfigurator.New(FeatName + "Greater", Guids.ArchmageGreater)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(BuffRefs.DestructionJudgmentBuff.Reference.Get().Icon)
                .AddContextRankConfig(ContextRankConfigs.FeatureRank(Guids.SpiritBonus))  
                .AddDraconicBloodlineArcana(value: 2, spellsOnly: true, useContextBonus: true, 
                    spellDescriptor: SpellDescriptor.Arcane | SpellDescriptor.Sonic | SpellDescriptor.Acid | SpellDescriptor.Fire | SpellDescriptor.Cold | SpellDescriptor.Electricity | SpellDescriptor.Force | SpellDescriptor.None)
                .Configure();

            BuffConfigurator.New(FeatName + "Intermediate", Guids.ArchmageIntermediate)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(BuffRefs.DazeBuff.Reference.Get().Icon)
                .AddIncreaseSpellSpellbookDC(spellbooks: new() { Guids.ArchmageSpellbook}, bonusDC: 2, descriptor: ModifierDescriptor.UntypedStackable)
                .AddCasterLevelForSpellbook(spellbooks: new() { Guids.ArchmageSpellbook }, bonus: 2, descriptor: ModifierDescriptor.UntypedStackable)
                .Configure();

            BuffConfigurator.New(FeatName + "Lesser", Guids.ArchmageLesser)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(BuffRefs.GuidanceBuff.Reference.Get().Icon)
                .AddComponent<AddForbidSpellbook>(c =>
                {
                    c.m_Spellbook = BlueprintTool.GetRef<BlueprintSpellbookReference>(Guids.ArchmageSpellbook);
                })
                .Configure();

            var buff = BuffConfigurator.New(FeatName + "Buff", BUFF)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetFlags(Flags.HiddenInUi)
                .AddBuffActions(activated: ActionsBuilder.New().ApplyBuffPermanent(Guids.ArchmageLesser)
                    .Conditional(ConditionsBuilder.New().CasterHasFact(Guids.SpiritPowerIntermediate), ifTrue: ActionsBuilder.New().ApplyBuffPermanent(Guids.ArchmageIntermediate)
                    .Conditional(ConditionsBuilder.New().CasterHasFact(Guids.SpiritPowerGreater), ifTrue: ActionsBuilder.New().ApplyBuffPermanent(Guids.ArchmageGreater)
                    .Conditional(ConditionsBuilder.New().CasterHasFact(Guids.SpiritPowerSupreme), ifTrue: ActionsBuilder.New().ApplyBuffPermanent(Guids.ArchmageSupreme)))))
                .Configure();

            var ability = ActivatableAbilityConfigurator.New(FeatName + "ActivatableAbility", ABILITY)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetDeactivateImmediately()
                .SetBuff(buff)
                .Configure();

            FeatureConfigurator.New(FeatName + "ProhibitSpellbook", Guids.ProhibitArchmageSpellbook)
                .SetHideInUI(true)
                .AddComponent<ForbidSpellbook>(c =>
                {
                    c.m_Spellbook = BlueprintTool.GetRef<BlueprintSpellbookReference>(Guids.ArchmageSpellbook);
                })
                .Configure();

            var feature = FeatureConfigurator.New(FeatName, FEATURE)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIsClassFeature(true)
                .AddContextRankConfig(ContextRankConfigs.ClassLevel(new string[] { BlueprintTool.Get<BlueprintCharacterClass>(Guids.Medium).ToString() }, false, Kingmaker.Enums.AbilityRankType.Default, 20, 1))
                .AddSpellbook(ContextValues.Rank(), spellbook: Guids.ArchmageSpellbook)
                .AddFacts(new() { ability, Guids.ProhibitArchmageSpellbook })
                .Configure();
        }
    }
}
