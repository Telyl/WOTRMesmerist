using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using Mesmerist.Utils;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using static TabletopTweaks.Core.MechanicsChanges.AdditionalActivatableAbilityGroups;
using Kingmaker.UnitLogic.ActivatableAbilities;
namespace Mesmerist.Mesmerist.Tricks
{
    public class FreeInBody
    {
        private static readonly string FeatName = "FreeInBody";
        internal const string DisplayName = "FreeInBody.Name";
        private static readonly string Description = "FreeInBody.Description";




        public static void Configure()
        {
            BuffConfigurator.New(FeatName + "BuffEffect", Guids.FreeInBodyBuffEffect)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddRemoveWhenCombatEnded()
                .SetFlags(Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff.Flags.HiddenInUi)
                .SetIcon(AbilityRefs.FreedomOfMovement.Reference.Get().Icon)
                .AddFacts(new() { BuffRefs.FreedomOfMovementBuff.Reference.Get() })
                .Configure();

            BuffConfigurator.New(FeatName + "Buff", Guids.FreeInBodyBuff)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.FreedomOfMovement.Reference.Get().Icon)
                .SetFlags(Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff.Flags.HiddenInUi)
                .Configure();

            ActivatableAbilityConfigurator.New(FeatName + "Ability", Guids.FreeInBodyAbility)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.FreedomOfMovement.Reference.Get().Icon)
                .SetGroup((ActivatableAbilityGroup)((ExtentedActivatableAbilityGroup)1819))
                .SetHiddenInUI()
                .SetBuff(Guids.FreeInBodyBuff)
                 .SetDeactivateImmediately()
                .Configure();

            //TODO: Change CharacterLevel to ClassLevel(Mesmerist)
            FeatureConfigurator.New(FeatName, Guids.FreeInBody)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddFacts(new() { Guids.FreeInBodyAbility })
                .SetIsClassFeature()
                .AddPrerequisiteFeature(Guids.MasterfulTricks)
                .Configure();
        }
    }
}
