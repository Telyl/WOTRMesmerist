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
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using System.Drawing;
using static Kingmaker.UnitLogic.Commands.Base.UnitCommand;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Abilities;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using Kingmaker.Designers.Mechanics.Facts;
using Mesmerist.NewComponents;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.Armies.TacticalCombat.Components;
using Kingmaker.UnitLogic.Mechanics.Components;
using Mesmerist.Mesmerist;

namespace Mesmerist.Medium
{
    public class SpiritSurge
    {
        private static readonly string FeatName = "SpiritSurge";
        internal const string DisplayName = "SpiritSurge.Name";
        private static readonly string Description = "SpiritSurge.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);

        public static void Configure()
        {
            var icon = BuffRefs.EldritchFontGreaterSurgeBuff.Reference.Get().Icon;

            BuffConfigurator.New(FeatName + "BuffD10", Guids.SpiritSurgeBuffD10)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
            #region Archmage
                .AddComponent<ModifyD20SkillCheck>(c =>
                {
                    c.Bonus = ContextValues.Shared(AbilitySharedValue.Heal);
                    c.Skill = [StatType.SkillKnowledgeWorld, StatType.SkillKnowledgeArcana];
                    c.fact = BlueprintTool.GetRef<BlueprintUnitFactReference>(Guids.ArchmageBuff);
                })
                .AddComponent<ModifyD20Concentration>(c =>
                {
                    c.Bonus = ContextValues.Shared(AbilitySharedValue.Heal);
                    c.fact = BlueprintTool.GetRef<BlueprintUnitFactReference>(Guids.ArchmageBuff);
                })
            #endregion
            #region Champion
                .AddComponent<ModifyD20SkillCheck>(c =>
                {
                    c.Bonus = ContextValues.Shared(AbilitySharedValue.Heal);
                    c.Skill = [StatType.SkillAthletics];
                    c.fact = BlueprintTool.GetRef<BlueprintUnitFactReference>(Guids.ChampionBuff);
                })
                .AddComponent<ModifyD20AttackRoll>(c =>
                {
                    c.Bonus = ContextValues.Shared(AbilitySharedValue.Heal);
                    c.fact = BlueprintTool.GetRef<BlueprintUnitFactReference>(Guids.ChampionBuff);
                })
            #endregion
            #region Guardian
                //Constitution, AC, and Fortitude
                .AddComponent<ModifyD20SavingThrow>(c =>
                {
                    c.Bonus = ContextValues.Shared(AbilitySharedValue.Heal);
                    c.SavingThrowType = FlaggedSavingThrowType.Fortitude | FlaggedSavingThrowType.Reflex;
                    c.fact = BlueprintTool.GetRef<BlueprintUnitFactReference>(Guids.GuardianBuff);
                })
            #endregion
            #region Marshal
                .AddComponent<ModifyD20SkillCheck>(c =>
                {
                    c.Bonus = ContextValues.Shared(AbilitySharedValue.Heal);
                    c.Skill = [StatType.SkillPersuasion, StatType.SkillUseMagicDevice];
                    c.fact = BlueprintTool.GetRef<BlueprintUnitFactReference>(Guids.MarshalBuff);
                    c.checkSpiritBonus = true;
                })
            #endregion
            #region Hierophant
                .AddComponent<ModifyD20SkillCheck>(c =>
                {
                    c.Bonus = ContextValues.Shared(AbilitySharedValue.Heal);
                    c.Skill = [StatType.SkillLoreNature, StatType.SkillLoreReligion, StatType.SkillPerception];
                    c.fact = BlueprintTool.GetRef<BlueprintUnitFactReference>(Guids.HierophantBuff);
                })
                .AddComponent<ModifyD20SavingThrow>(c =>
                {
                    c.Bonus = ContextValues.Shared(AbilitySharedValue.Heal);
                    c.SavingThrowType = FlaggedSavingThrowType.Will;
                    c.fact = BlueprintTool.GetRef<BlueprintUnitFactReference>(Guids.HierophantBuff);
                })
            #endregion
            #region Trickster
                .AddComponent<ModifyD20SkillCheck>(c =>
                {
                    c.Bonus = ContextValues.Shared(AbilitySharedValue.Heal);
                    c.Skill = [StatType.SkillAthletics, StatType.SkillMobility,
                        StatType.SkillStealth, StatType.SkillThievery,
                        StatType.SkillKnowledgeArcana, StatType.SkillKnowledgeWorld,
                        StatType.SkillLoreNature, StatType.SkillLoreReligion,
                        StatType.SkillPerception,
                        StatType.SkillPersuasion, StatType.SkillUseMagicDevice];
                    c.fact = BlueprintTool.GetRef<BlueprintUnitFactReference>(Guids.TricksterBuff);
                })
                .AddComponent<ModifyD20SavingThrow>(c =>
                {
                    c.Bonus = ContextValues.Shared(AbilitySharedValue.Heal);
                    c.SavingThrowType = FlaggedSavingThrowType.Reflex;
                    c.fact = BlueprintTool.GetRef<BlueprintUnitFactReference>(Guids.TricksterBuff);
                })
            #endregion
                .AddContextCalculateSharedValue(1,
                    ContextDice.Value(DiceType.D10, ContextValues.Constant(1)),
                    AbilitySharedValue.Heal)
                .SetIcon(icon)
                .Configure();

            BuffConfigurator.New(FeatName + "BuffD8", Guids.SpiritSurgeBuffD8)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
            #region Archmage
                .AddComponent<ModifyD20SkillCheck>(c =>
                {
                    c.Bonus = ContextValues.Shared(AbilitySharedValue.Heal);
                    c.Skill = [StatType.SkillKnowledgeWorld, StatType.SkillKnowledgeArcana];
                    c.fact = BlueprintTool.GetRef<BlueprintUnitFactReference>(Guids.ArchmageBuff);
                })
                .AddComponent<ModifyD20Concentration>(c =>
                {
                    c.Bonus = ContextValues.Shared(AbilitySharedValue.Heal);
                    c.fact = BlueprintTool.GetRef<BlueprintUnitFactReference>(Guids.ArchmageBuff);
                })
            #endregion
            #region Champion
                .AddComponent<ModifyD20SkillCheck>(c =>
                {
                    c.Bonus = ContextValues.Shared(AbilitySharedValue.Heal);
                    c.Skill = [StatType.SkillAthletics];
                    c.fact = BlueprintTool.GetRef<BlueprintUnitFactReference>(Guids.ChampionBuff);
                })
                .AddComponent<ModifyD20AttackRoll>(c =>
                {
                    c.Bonus = ContextValues.Shared(AbilitySharedValue.Heal);
                    c.fact = BlueprintTool.GetRef<BlueprintUnitFactReference>(Guids.ChampionBuff);
                })
            #endregion
            #region Guardian
                //Constitution, AC, and Fortitude
                .AddComponent<ModifyD20SavingThrow>(c =>
                {
                    c.Bonus = ContextValues.Shared(AbilitySharedValue.Heal);
                    c.SavingThrowType = FlaggedSavingThrowType.Fortitude | FlaggedSavingThrowType.Reflex;
                    c.fact = BlueprintTool.GetRef<BlueprintUnitFactReference>(Guids.GuardianBuff);
                })
            #endregion
            #region Marshal
                .AddComponent<ModifyD20SkillCheck>(c =>
                {
                    c.Bonus = ContextValues.Shared(AbilitySharedValue.Heal);
                    c.Skill = [StatType.SkillPersuasion, StatType.SkillUseMagicDevice];
                    c.fact = BlueprintTool.GetRef<BlueprintUnitFactReference>(Guids.MarshalBuff);
                    c.checkSpiritBonus = true;
                })
            #endregion
            #region Hierophant
                .AddComponent<ModifyD20SkillCheck>(c =>
                {
                    c.Bonus = ContextValues.Shared(AbilitySharedValue.Heal);
                    c.Skill = [StatType.SkillLoreNature, StatType.SkillLoreReligion, StatType.SkillPerception];
                    c.fact = BlueprintTool.GetRef<BlueprintUnitFactReference>(Guids.HierophantBuff);
                })
                .AddComponent<ModifyD20SavingThrow>(c =>
                {
                    c.Bonus = ContextValues.Shared(AbilitySharedValue.Heal);
                    c.SavingThrowType = FlaggedSavingThrowType.Will;
                    c.fact = BlueprintTool.GetRef<BlueprintUnitFactReference>(Guids.HierophantBuff);
                })
            #endregion
            #region Trickster
                .AddComponent<ModifyD20SkillCheck>(c =>
                {
                    c.Bonus = ContextValues.Shared(AbilitySharedValue.Heal);
                    c.Skill = [StatType.SkillAthletics, StatType.SkillMobility,
                        StatType.SkillStealth, StatType.SkillThievery,
                        StatType.SkillKnowledgeArcana, StatType.SkillKnowledgeWorld,
                        StatType.SkillLoreNature, StatType.SkillLoreReligion,
                        StatType.SkillPerception,
                        StatType.SkillPersuasion, StatType.SkillUseMagicDevice];
                    c.fact = BlueprintTool.GetRef<BlueprintUnitFactReference>(Guids.TricksterBuff);
                })
                .AddComponent<ModifyD20SavingThrow>(c =>
                {
                    c.Bonus = ContextValues.Shared(AbilitySharedValue.Heal);
                    c.SavingThrowType = FlaggedSavingThrowType.Reflex;
                    c.fact = BlueprintTool.GetRef<BlueprintUnitFactReference>(Guids.TricksterBuff);
                })
            #endregion
                .AddContextCalculateSharedValue(1,
                    ContextDice.Value(DiceType.D8, ContextValues.Constant(1)),
                    AbilitySharedValue.Heal)
                .SetIcon(icon)
                .Configure();

            BuffConfigurator.New(FeatName + "BuffD6", Guids.SpiritSurgeBuffD6)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
            #region Archmage
                .AddComponent<ModifyD20SkillCheck>(c =>
                {
                    c.Bonus = ContextValues.Shared(AbilitySharedValue.Heal);
                    c.Skill = [StatType.SkillKnowledgeWorld, StatType.SkillKnowledgeArcana];
                    c.fact = BlueprintTool.GetRef<BlueprintUnitFactReference>(Guids.ArchmageBuff);
                })
                .AddComponent<ModifyD20Concentration>(c =>
                {
                    c.Bonus = ContextValues.Shared(AbilitySharedValue.Heal);
                    c.fact = BlueprintTool.GetRef<BlueprintUnitFactReference>(Guids.ArchmageBuff);
                })
            #endregion
            #region Champion
                .AddComponent<ModifyD20SkillCheck>(c =>
                {
                    c.Bonus = ContextValues.Shared(AbilitySharedValue.Heal);
                    c.Skill = [StatType.SkillAthletics];
                    c.fact = BlueprintTool.GetRef<BlueprintUnitFactReference>(Guids.ChampionBuff);
                })
                .AddComponent<ModifyD20AttackRoll>(c =>
                {
                    c.Bonus = ContextValues.Shared(AbilitySharedValue.Heal);
                    c.fact = BlueprintTool.GetRef<BlueprintUnitFactReference>(Guids.ChampionBuff);
                })
            #endregion
            #region Guardian
                //Constitution, AC, and Fortitude
                .AddComponent<ModifyD20SavingThrow>(c =>
                {
                    c.Bonus = ContextValues.Shared(AbilitySharedValue.Heal);
                    c.SavingThrowType = FlaggedSavingThrowType.Fortitude | FlaggedSavingThrowType.Reflex;
                    c.fact = BlueprintTool.GetRef<BlueprintUnitFactReference>(Guids.GuardianBuff);
                })
            #endregion
            #region Marshal
                .AddComponent<ModifyD20SkillCheck>(c =>
                {
                    c.Bonus = ContextValues.Shared(AbilitySharedValue.Heal);
                    c.Skill = [StatType.SkillPersuasion, StatType.SkillUseMagicDevice];
                    c.fact = BlueprintTool.GetRef<BlueprintUnitFactReference>(Guids.MarshalBuff);
                    c.checkSpiritBonus = true;
                })
            #endregion
            #region Hierophant
                .AddComponent<ModifyD20SkillCheck>(c =>
                {
                    c.Bonus = ContextValues.Shared(AbilitySharedValue.Heal);
                    c.Skill = [StatType.SkillLoreNature, StatType.SkillLoreReligion, StatType.SkillPerception];
                    c.fact = BlueprintTool.GetRef<BlueprintUnitFactReference>(Guids.HierophantBuff);
                })
                .AddComponent<ModifyD20SavingThrow>(c =>
                {
                    c.Bonus = ContextValues.Shared(AbilitySharedValue.Heal);
                    c.SavingThrowType = FlaggedSavingThrowType.Will;
                    c.fact = BlueprintTool.GetRef<BlueprintUnitFactReference>(Guids.HierophantBuff);
                })
            #endregion
            #region Trickster
                .AddComponent<ModifyD20SkillCheck>(c =>
                {
                    c.Bonus = ContextValues.Shared(AbilitySharedValue.Heal);
                    c.Skill = [StatType.SkillAthletics, StatType.SkillMobility,
                        StatType.SkillStealth, StatType.SkillThievery,
                        StatType.SkillKnowledgeArcana, StatType.SkillKnowledgeWorld,
                        StatType.SkillLoreNature, StatType.SkillLoreReligion,
                        StatType.SkillPerception,
                        StatType.SkillPersuasion, StatType.SkillUseMagicDevice];
                    c.fact = BlueprintTool.GetRef<BlueprintUnitFactReference>(Guids.TricksterBuff);
                })
                .AddComponent<ModifyD20SavingThrow>(c =>
                {
                    c.Bonus = ContextValues.Shared(AbilitySharedValue.Heal);
                    c.SavingThrowType = FlaggedSavingThrowType.Reflex;
                    c.fact = BlueprintTool.GetRef<BlueprintUnitFactReference>(Guids.TricksterBuff);
                })
            #endregion
                .AddContextCalculateSharedValue(1, 
                    ContextDice.Value(DiceType.D6, ContextValues.Constant(1)), 
                    AbilitySharedValue.Heal)
                .SetIcon(icon)
                .Configure();

            AbilityConfigurator.New(FeatName + "Ability", Guids.SpiritSurgeAbility)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(icon)
                .AddAbilityEffectRunAction(ActionsBuilder.New()
                .Conditional(
                    ConditionsBuilder.New().BuffRank(fact: Guids.SpiritSurge, useFactInsteadBuff: true,
                    rankValue: ContextValues.Constant(1)), 
                    ifTrue: ActionsBuilder.New().ApplyBuffPermanent(Guids.SpiritSurgeBuffD6))
                .Conditional(
                    ConditionsBuilder.New().BuffRank(fact: Guids.SpiritSurge, useFactInsteadBuff: true,
                    rankValue: ContextValues.Constant(2)),
                    ifTrue: ActionsBuilder.New().ApplyBuffPermanent(Guids.SpiritSurgeBuffD8).RemoveBuff(Guids.SpiritSurgeBuffD6))
                .Conditional(
                    ConditionsBuilder.New().BuffRank(fact: Guids.SpiritSurge, useFactInsteadBuff: true,
                    rankValue: ContextValues.Constant(3)),
                    ifTrue: ActionsBuilder.New().ApplyBuffPermanent(Guids.SpiritSurgeBuffD10).RemoveBuff(Guids.SpiritSurgeBuffD8)))
                .SetActionType(CommandType.Free)
                .SetRange(AbilityRange.Personal)
                .Configure();

            var SpiritSurge = FeatureConfigurator.New(FeatName, Guids.SpiritSurge)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIsClassFeature()
                .AddFacts(new() { Guids.SpiritSurgeAbility })
                .SetRanks(10)
                .Configure();

            FeatureConfigurator.For(SpiritSurge)
                .AddContextRankConfig(new ContextRankConfig
                {
                    m_Type = AbilityRankType.Default,
                    m_BaseValueType = ContextRankBaseValueType.FeatureRank,
                    m_Feature = SpiritSurge.ToReference<BlueprintFeatureReference>(),
                    m_Stat = StatType.Unknown,
                    m_Buff = null,
                    m_Progression = ContextRankProgression.AsIs,
                    m_StartLevel = 0,
                    m_StepLevel = 0,
                    m_UseMin = false,
                    m_Min = 0,
                    m_UseMax = false,
                    m_Max = 20,
                    m_ExceptClasses = false,
                    Archetype = null
                })
                .Configure();
        }
    }
}
