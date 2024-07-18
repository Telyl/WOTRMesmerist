using CharacterOptionsPlus.Util;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;

namespace Mesmerist.NewComponents
{
    [TypeId("7a5a7b221adf4d7db6913c0bda20ce44")]
    public class AddForceFlanked : UnitFactComponentDelegate, IInitiatorRulebookHandler<RuleAttackRoll>, IRulebookHandler<RuleAttackRoll>, ISubscriber, IInitiatorRulebookSubscriber
    {
        private static readonly Logging.Logger Logger = Logging.GetLogger(nameof(AddForceFlanked));
        public void OnEventAboutToTrigger(RuleAttackRoll evt)
        {
            if ((!evt.Target.CombatState.IsFlanked || !evt.TargetIsFlanked) && evt.Weapon.Blueprint.IsMelee)
            {
                evt.TargetIsFlanked = true;
            }
        }

        public void OnEventDidTrigger(RuleAttackRoll evt)
        {
           //evt.Initiator.Descriptor.Buffs.RemoveFact(base.Fact);
        }
    }
}