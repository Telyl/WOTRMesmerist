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
using CharacterOptionsPlus.Util;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using static Kingmaker.UnitLogic.Commands.Base.UnitCommand;
using Mesmerist.MechanicsChanges;
using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
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
                .SetIcon(AbilityRefs.FlyTest.Reference.Get().Icon)
                .AddTargetAttackWithWeaponTrigger(actionsOnAttacker:
                 ActionsBuilder.New().CastSpell(AbilityRefs.BullRushAction.Reference.Get(), false, false, true),
                    waitForAttackResolve: true, onlyMelee: true, onlyOnFirstAttack: false, onlyRanged: false, onlyHit: true)
                .Configure();

            BuffConfigurator.New(FeatName + "Buff", Guids.LevitationBufferBuff)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.FlyTest.Reference.Get().Icon)
                .SetFlags(Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff.Flags.HiddenInUi)
                .Configure();

            ActivatableAbilityConfigurator.New(FeatName + "Ability", Guids.LevitationBufferAbility)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.FlyTest.Reference.Get().Icon)
                .SetGroup(ExpandedActivatableAbilityGroup.MesmeristTricks)
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
