using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.EntitySystem.Stats;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using Mesmerist.Utils;
using CharacterOptionsPlus.Util;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using Kingmaker.UnitLogic.ActivatableAbilities;
using static TabletopTweaks.Core.MechanicsChanges.AdditionalActivatableAbilityGroups;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.Utility;
using System.Drawing;
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
            var Icon = AbilityRefs.Fear.Reference.Get().Icon;
            var BuffEffect = Guids.ReflectFearBuffEffect;
            var ToggleBuff = Guids.ReflectFearBuff;
            var Ability = Guids.ReflectFearAbility;
            var Feat = Guids.ReflectFear;

            BuffConfigurator.New(FeatName + "BuffEffect", BuffEffect)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.Fear.Reference.Get().Icon)
                .AddRemoveWhenCombatEnded()
                .AddTargetAttackRollTrigger(actionsOnAttacker:
                ActionsBuilder.New().SavingThrow(SavingThrowType.Will, 
                onResult: ActionsBuilder.New().ConditionalSaved(succeed: ActionsBuilder.New().CastSpell(AbilityRefs.Fear.Reference.Get()))))
                .Configure();

            TrickTools.CreateTrickToggleBuff(FeatName + "Buff", ToggleBuff, DisplayName, Description, Icon);
            TrickTools.CreateTrickActivatableAbility(FeatName + "Ability", Ability, DisplayName, Description, Icon, ToggleBuff);
            TrickTools.CreateTrickFeature(FeatName, Feat, DisplayName, Description, Ability);
        }
    }
}
