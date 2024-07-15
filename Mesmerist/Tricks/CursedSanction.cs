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
            var BuffEffect = Guids.CursedSanctionBuffEffect;
            var ToggleBuff = Guids.CursedSanctionBuff;
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
                .Configure();

            BuffConfigurator.New(FeatName + "BuffEffect", Guids.CursedSanctionBuffEffect)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddRemoveWhenCombatEnded()
                .AddContextCalculateAbilityParamsBasedOnClass(Guids.Mesmerist, statType: StatType.Charisma)
                .SetIcon(AbilityRefs.BestowCurse.Reference.Get().Icon)
                .AddIncomingDamageTrigger(actionsOnInitiator: true, actions: ActionsBuilder.New().SavingThrow(SavingThrowType.Will, 
                 onResult: ActionsBuilder.New().ConditionalSaved(failed: ActionsBuilder.New().ApplyBuffPermanent(Guids.CursedSanctionDebuffEffect))))
                .Configure();

            TrickTools.CreateTrickToggleBuff(FeatName + "Buff", ToggleBuff, DisplayName, Description, Icon);
            TrickTools.CreateTrickActivatableAbility(FeatName + "Ability", Ability, DisplayName, Description, Icon, ToggleBuff);
            TrickTools.CreateTrickFeature(FeatName, Feat, DisplayName, Description, Ability);
        }
    }
}
