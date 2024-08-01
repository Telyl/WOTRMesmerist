using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.BasicEx;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Utils.Types;
using Kingmaker.Designers.EventConditionActionSystem.Evaluators;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.Visual.Animation;
using Mesmerist.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mesmerist.Mesmerist.VexingDaredevil.DazzlingFeint
{
    public class CombatManeuver
    {
        private static readonly string FeatName = "CombatManeuver";
        internal const string DisplayName = "CombatManeuver.Name";
        private static readonly string Description = "CombatManeuver.Description";
        public static void Configure()
        {
            var value = WeaponCategory.Bardiche;

            foreach (WeaponCategory val in Enum.GetValues(typeof(WeaponCategory)))
            {
                value = value | val;
            }

            BuffConfigurator.New(FeatName + "Buff", Guids.CombatManeuverBuff)
                .AddInitiatorAttackWithWeaponTrigger(ActionsBuilder.New()
                .Conditional(ConditionsBuilder.New().UseOr().HasBuffFromCaster(BuffRefs.FeintBuffEnemy.Reference.Get()).HasBuffFromCaster(BuffRefs.FeintBuffEnemyFinalFeintEnemyBuff.Reference.Get()),
                 ifTrue: ActionsBuilder.New()).CastSpell(AbilityRefs.DisarmAction.Reference.Get(), false, false, true),
                onlyOnFirstHit: true, actionsOnInitiator: false)
                .Configure();

            ActivatableAbilityConfigurator.New(FeatName + "Ability", Guids.CombatManeuverAbility)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.DisarmAction.Reference.Get().Icon)
                .SetBuff(Guids.CombatManeuverBuff)
                .Configure();

            FeatureConfigurator.New(FeatName, Guids.CombatManeuver)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddFacts(new() { Guids.CombatManeuverAbility })
                .Configure();
        }
    }
}
