using System;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Events
{
    [ComponentName("Events/OnTurnOffTrigger")]
    [AllowMultipleComponents]
    [TypeId("2f7bd5c8a9714cd3b70feb26b2bb03ec")]
    public class OnTurnOffTrigger : EntityFactComponentDelegate
    {
        public override void OnTurnOff()
        {
            if (!this.Conditions.Check())
            {
                return;
            }
            this.Actions.Run();
        }
        public ConditionsChecker Conditions;
        public ActionList Actions;
    }
}