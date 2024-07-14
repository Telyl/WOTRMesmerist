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
namespace Mesmerist.Mesmerist.Tricks
{
    public class CursedSanction
    {
        private static readonly string FeatName = "CursedSanction";
        internal const string DisplayName = "CursedSanction.Name";
        private static readonly string Description = "CursedSanction.Description";




        public static void Configure()
        {
            BuffConfigurator.New(FeatName + "DebuffEffect", Guids.CursedSanctionDebuffEffect)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.BestowCurse.Reference.Get().Icon)
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

            BuffConfigurator.New(FeatName + "Buff", Guids.CursedSanctionBuff)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.BestowCurse.Reference.Get().Icon)
                .SetFlags(Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff.Flags.HiddenInUi)
                .Configure();

            ActivatableAbilityConfigurator.New(FeatName + "Ability", Guids.CursedSanctionAbility)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.BestowCurse.Reference.Get().Icon)
                .SetGroup((ActivatableAbilityGroup)((ExtentedActivatableAbilityGroup)1819))
                .SetHiddenInUI()
                .SetBuff(Guids.CursedSanctionBuff)
                 .SetDeactivateImmediately()
                .Configure();

            //TODO: Change CharacterLevel to ClassLevel(Mesmerist)
            FeatureConfigurator.New(FeatName, Guids.CursedSanction)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddFacts(new() { Guids.CursedSanctionAbility })
                .SetIsClassFeature()
                .AddPrerequisiteFeature(Guids.MasterfulTricks)
                .Configure();
        }
    }
}
