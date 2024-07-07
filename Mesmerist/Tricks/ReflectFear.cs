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
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.StoryEx;
using BlueprintCore.Actions.Builder.ContextEx;
namespace Mesmerist.Mesmerist.Tricks
{
    public class ReflectFear
    {
        private static readonly string FeatName = "ReflectFear";
        internal const string DisplayName = "ReflectFear.Name";
        private static readonly string Description = "ReflectFear.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);

        public static void Configure()
        {
            BuffConfigurator.New(FeatName + "BuffEffect", Guids.ReflectFearBuffEffect)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.Fear.Reference.Get().Icon)
                .AddTargetAttackRollTrigger(actionsOnAttacker: 
                ActionsBuilder.New().SavingThrow(SavingThrowType.Will, 
                onResult: ActionsBuilder.New().ConditionalSaved(succeed: ActionsBuilder.New().CastSpell(AbilityRefs.Fear.Reference.Get()))))
                .Configure();

            BuffConfigurator.New(FeatName + "Buff", Guids.ReflectFearBuff)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.Fear.Reference.Get().Icon)
                .SetFlags(Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff.Flags.HiddenInUi)
                .Configure();

            ActivatableAbilityConfigurator.New(FeatName + "Ability", Guids.ReflectFearAbility)
                 .SetDisplayName(DisplayName)
                 .SetDescription(Description)
                 .SetIcon(AbilityRefs.Fear.Reference.Get().Icon)
                 .SetGroup(ExpandedActivatableAbilityGroup.MesmeristTricks)
                 .SetHiddenInUI()
                 .SetBuff(Guids.ReflectFearBuff)
                 .SetDeactivateImmediately()
                 .Configure();

            //TODO: Change CharacterLevel to ClassLevel(Mesmerist)
            FeatureConfigurator.New(FeatName, Guids.ReflectFear)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddFacts(new() { Guids.ReflectFearAbility })
                .SetIsClassFeature()
                .Configure();
        }
    }
}
