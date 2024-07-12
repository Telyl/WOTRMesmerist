using CharacterOptionsPlus.Util;
using HarmonyLib;
using Kingmaker.Armies.TacticalCombat;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.Enums;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;
using Mesmerist.NewComponents;
using System.Security.Policy;
using TabletopTweaks.Core.Utilities;

namespace Mesmerist.NewComponents
{
    [TypeId("7a5a7b221adf4d7db6913c0bda20ce44")]
    public class AddFalseFlanker : UnitFactComponentDelegate, IInitiatorRulebookHandler<RuleAttackRoll>, IRulebookHandler<RuleAttackRoll>, ISubscriber, IInitiatorRulebookSubscriber
    {
        private static readonly Logging.Logger Logger = Logging.GetLogger(nameof(AddFalseFlanker));
        public void OnEventAboutToTrigger(RuleAttackRoll evt)
        {
            if ((!evt.Target.CombatState.IsFlanked || !evt.TargetIsFlanked) && evt.Weapon.Blueprint.IsMelee)
            {
                evt.TargetIsFlanked = true;;
            }
        }

        public void OnEventDidTrigger(RuleAttackRoll evt)
        {
        }
    }
}