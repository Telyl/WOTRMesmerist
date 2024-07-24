using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.EntitySystem.Stats;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using Mesmerist.Utils;
using Kingmaker.Enums;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using static TabletopTweaks.Core.MechanicsChanges.AdditionalActivatableAbilityGroups;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.Utility;
using System.Drawing;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Mechanics;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints.Classes.Spells;
namespace Mesmerist.Mesmerist.Tricks
{
    public class CursedSanction
    {
        private static readonly string FeatName = "CursedSanction";
        internal const string DisplayName = "CursedSanction.Name";
        private static readonly string Description = "CursedSanction.Description";




        public static void Configure()
        {
            var Icon = AbilityRefs.BestowCurse.Reference.Get().Icon;
            var TrickBuff = Guids.CursedSanctionBuff;
            var Ability = Guids.CursedSanctionAbility;
            var Feat = Guids.CursedSanction;

            BuffConfigurator.New(FeatName + "DebuffEffect", Guids.CursedSanctionDebuffEffect)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(Icon)
                .AddUniqueBuff()
                .AddStatBonus(ModifierDescriptor.UntypedStackable, false, StatType.AdditionalAttackBonus, -4)
                .AddStatBonus(ModifierDescriptor.UntypedStackable, false, StatType.SaveFortitude, -4)
                .AddStatBonus(ModifierDescriptor.UntypedStackable, false, StatType.SaveReflex, -4)
                .AddStatBonus(ModifierDescriptor.UntypedStackable, false, StatType.SaveWill, -4)
                .AddStatBonus(ModifierDescriptor.UntypedStackable, false, StatType.SkillPerception, -4)
                .AddStatBonus(ModifierDescriptor.UntypedStackable, false, StatType.SkillPersuasion, -4)
                .AddStatBonus(ModifierDescriptor.UntypedStackable, false, StatType.SkillAthletics, -4)
                .AddStatBonus(ModifierDescriptor.UntypedStackable, false, StatType.SkillMobility, -4)
                .AddStatBonus(ModifierDescriptor.UntypedStackable, false, StatType.SkillStealth, -4)
                .AddStatBonus(ModifierDescriptor.UntypedStackable, false, StatType.SkillThievery, -4)
                .AddStatBonus(ModifierDescriptor.UntypedStackable, false, StatType.SkillLoreReligion, -4)
                .AddStatBonus(ModifierDescriptor.UntypedStackable, false, StatType.SkillLoreNature, -4)
                .AddStatBonus(ModifierDescriptor.UntypedStackable, false, StatType.SkillKnowledgeArcana, -4)
                .AddStatBonus(ModifierDescriptor.UntypedStackable, false, StatType.SkillKnowledgeWorld, -4)
                .SetFlags(BlueprintBuff.Flags.RemoveOnRest)
                .AddSpellDescriptorComponent(descriptor: SpellDescriptor.Curse)
                .Configure();

            TrickTools.CreateTrickTrickBuff(FeatName + "Buff", TrickBuff, DisplayName, Description, Icon);

            BuffConfigurator.For(TrickBuff)
                .AddRemoveWhenCombatEnded()
                .AddContextCalculateAbilityParamsBasedOnClass(Guids.Mesmerist, statType: StatType.Charisma)
                .AddIncomingDamageTrigger(actionsOnInitiator: true, actions: ActionsBuilder.New().SavingThrow(SavingThrowType.Will,
                 onResult: ActionsBuilder.New().ConditionalSaved(failed: ActionsBuilder.New().ApplyBuff(Guids.CursedSanctionDebuffEffect, ContextDuration.Variable(ContextValues.Rank(), DurationRate.Minutes))).RemoveSelf()))
                .AddContextRankConfig(ContextRankConfigs.ClassLevel([Guids.Mesmerist], false))
                .Configure();

            TrickTools.CreateTrickAbility(FeatName + "Ability", Ability, DisplayName, Description, Icon, TrickBuff, Feat, masterfulTrick: true);
            var feature = TrickTools.CreateTrickFeature(FeatName, Feat, DisplayName, Description, Ability);
            FeatureConfigurator.For(feature)
                .AddPrerequisiteClassLevel(Guids.Mesmerist, 12)
                .Configure();
        }
    }
}
