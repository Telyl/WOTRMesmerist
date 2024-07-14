using CharacterOptionsPlus.Util;
using HarmonyLib;
using Kingmaker.Armies.TacticalCombat;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.RuleSystem.Rules.Abilities;
using Kingmaker.UnitLogic;
using Mesmerist.NewComponents;
using System.Security.Policy;
using TabletopTweaks.Core.Utilities;

namespace Mesmerist.NewComponents
{
    [TypeId("f5a934142ccc4ebc882b3acf896ad81f")]
    public class AddLinkedReaction : UnitFactComponentDelegate, 
        IInitiatorRulebookHandler<RuleApplySpell>, IRulebookHandler<RuleApplySpell>,
        ISubscriber, IInitiatorRulebookSubscriber
    {
        private static readonly Logging.Logger Logger = Logging.GetLogger(nameof(AddLinkedReaction));
        private static UnitEntityData caster;
        private static UnitEntityData target;
        private static bool executed = false;
        public void OnEventAboutToTrigger(RuleApplySpell evt)
        {
            caster = evt.Reason.Context.MaybeCaster;
            target = evt.SpellTarget.Unit;
            var casterInit = caster.Stats.Initiative;
            var targetInit = target.Stats.Initiative;
            var initDiff = casterInit - targetInit;
            if (initDiff < 0) { 
                initDiff = initDiff * -1;
                caster.Stats.Initiative.AddModifier(initDiff, ModifierDescriptor.UntypedStackable);
            }
            else
            {
                target.Stats.Initiative.AddModifier(initDiff, ModifierDescriptor.UntypedStackable);
            }
        }
        public void OnEventDidTrigger(RuleApplySpell evt)
        {
           
        }
    }
}