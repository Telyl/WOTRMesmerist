using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using Mesmerist.Utils;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using Kingmaker.UnitLogic.ActivatableAbilities;
using static TabletopTweaks.Core.MechanicsChanges.AdditionalActivatableAbilityGroups;
namespace Mesmerist.Mesmerist.Tricks
{
    public class Misdirection
    {
        private static readonly string FeatName = "Misdirection";
        internal const string DisplayName = "Misdirection.Name";
        private static readonly string Description = "Misdirection.Description";

        public static void Configure()
        {
            BuffConfigurator.New(FeatName + "BuffEffect", Guids.MisdirectionBuffEffect)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddRemoveWhenCombatEnded()
                .SetIcon(AbilityRefs.Vanish.Reference.Get().Icon)
                .AddInitiatorAttackWithWeaponTrigger(action: 
                    ActionsBuilder.New().CastSpell(AbilityRefs.FeintAbility.Reference.Get(), false, false, true), 
                    triggerBeforeAttack: true, onlyOnFirstAttack: true, checkDistance: false)
                .Configure();

            BuffConfigurator.New(FeatName + "Buff", Guids.MisdirectionBuff)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.Vanish.Reference.Get().Icon)
                .SetFlags(Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff.Flags.HiddenInUi)
                .Configure();

            ActivatableAbilityConfigurator.New(FeatName + "Ability", Guids.MisdirectionAbility)
                 .SetDisplayName(DisplayName)
                 .SetDescription(Description)
                 .SetIcon(AbilityRefs.Vanish.Reference.Get().Icon)
                .SetGroup((ActivatableAbilityGroup)((ExtentedActivatableAbilityGroup)1819))

                 .SetHiddenInUI()
                 .SetBuff(Guids.MisdirectionBuff)
                 .SetDeactivateImmediately()
                 .Configure();

            //TODO: Change CharacterLevel to ClassLevel(Mesmerist)
            FeatureConfigurator.New(FeatName, Guids.Misdirection)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddFacts(new() { Guids.MisdirectionAbility })
                .SetIsClassFeature()
                .Configure();
        }
    }
}
