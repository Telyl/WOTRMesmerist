using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using Mesmerist.Utils;
using CharacterOptionsPlus.Util;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using Kingmaker.UnitLogic.ActivatableAbilities;
using static TabletopTweaks.Core.MechanicsChanges.AdditionalActivatableAbilityGroups;
using Mesmerist.NewComponents;
using Kingmaker.EntitySystem.Stats;
using BlueprintCore.Utils.Types;
using Epic.OnlineServices.Stats;
namespace Mesmerist.Mesmerist.Tricks
{
    public class LevitationBuffer
    {
        private static readonly string FeatName = "LevitationBuffer";
        internal const string DisplayName = "LevitationBuffer.Name";
        private static readonly string Description = "LevitationBuffer.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);

        public static void Configure()
        {
            BuffConfigurator.New(FeatName + "BuffEffect", Guids.LevitationBufferBuffEffect)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.BullRushAction.Reference.Get().Icon)
                .AddTargetAttackWithWeaponTrigger(actionsOnAttacker:
                 ActionsBuilder.New().CastSpell(AbilityRefs.BullRushAction.Reference.Get(), false, false, true, ContextValues.Rank()),
                    waitForAttackResolve: true, onlyMelee: true, onlyOnFirstAttack: false, onlyRanged: false, onlyHit: true,
                    actionOnSelf: ActionsBuilder.New().RemoveBuff(Guids.LevitationBufferBuffEffect))
                .Configure();

            BuffConfigurator.New(FeatName + "Buff", Guids.LevitationBufferBuff)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.BullRushAction.Reference.Get().Icon)
                .SetFlags(Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff.Flags.HiddenInUi)
                .Configure();

            ActivatableAbilityConfigurator.New(FeatName + "Ability", Guids.LevitationBufferAbility)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.BullRushAction.Reference.Get().Icon)
                .SetGroup((ActivatableAbilityGroup)((ExtentedActivatableAbilityGroup)1819))
                .SetHiddenInUI()
                .SetBuff(Guids.LevitationBufferBuff)
                 .SetDeactivateImmediately()
                .Configure();

            //TODO: Change CharacterLevel to ClassLevel(Mesmerist)
            FeatureConfigurator.New(FeatName, Guids.LevitationBuffer)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddFacts(new() { Guids.LevitationBufferAbility })
                .SetIsClassFeature()
                .Configure();
        }
    }
}
