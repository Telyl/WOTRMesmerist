using Kingmaker.Blueprints;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Mechanics.Conditions;

namespace Mesmerist.NewConditions
{
    [TypeId("be99edf87902467097bd566f17485098")]
    public class ContextConditionInitiatorHasFact : ContextCondition
    {
        public override string GetConditionCaption()
        {
            return "For initiator with fact";
        }

        public override bool CheckCondition()
        {
            var initiator = base.Context.MaybeOwner.LastHandledDamage.Initiator;
            if (initiator == null) return false;
            return initiator.HasFact(FactToCheck);
        }
        public BlueprintUnitFactReference FactToCheck;
    }
}