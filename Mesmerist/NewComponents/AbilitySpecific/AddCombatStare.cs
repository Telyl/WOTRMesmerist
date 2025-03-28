using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules.Damage;
using Mesmerist.Utils;
using Kingmaker.EntitySystem.Stats;
using BlueprintCore.Utils.Types;
using Kingmaker.UnitLogic.Mechanics.Components;
using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.Blueprints.Classes;

namespace Mesmerist.NewComponents.AbilitySpecific
{
    [AllowMultipleComponents]
    [TypeId("fe4eb0615e264792b1d3030a9c010277")]
    public class AddCombatStare : EntityFactComponentDelegate,
        IGlobalRulebookHandler<RuleDealDamage>, IRulebookHandler<RuleDealDamage>, IGlobalRulebookSubscriber,
        ISubscriber
    {
        public void OnEventAboutToTrigger(RuleDealDamage evt)
        {
        }

        public void OnEventDidTrigger(RuleDealDamage evt)
        {
            if (evt.Reason.Fact.Blueprint != BlueprintTool.Get<BlueprintBuff>(Guids.PainfulStareBuff)) { return; } 

            IFactContextOwner factContextOwner = Fact as IFactContextOwner;
            if (factContextOwner == null)
            {
                return;
            }
            ActionList Actions = ActionsBuilder.New().SavingThrow(SavingThrow,
                    onResult: ActionsBuilder.New().ConditionalSaved(failed: ActionsBuilder.New().ApplyBuff(CombatStareDebuff, ContextDuration.Fixed(1)))).Build();
            factContextOwner.RunActionInContext(Actions, evt.Target);
        }

        public BlueprintBuff CombatStareDebuff;
        public SavingThrowType SavingThrow;
    }
}