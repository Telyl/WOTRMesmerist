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
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UnitLogic;
using System.Security.Policy;
using TabletopTweaks.Core.Utilities;

namespace Mesmerist.NewComponents.AbilitySpecific
{
    [TypeId("21273f91df984e7983274183ecd1cd7e")]
    public class AddShadowSplinter : UnitFactComponentDelegate,
        IInitiatorRulebookHandler<RuleCalculateDamage>, IRulebookHandler<RuleCalculateDamage>,
        ISubscriber, IInitiatorRulebookSubscriber
    {
        private static readonly Logging.Logger Logger = Logging.GetLogger(nameof(AddShadowSplinter));

        public void OnEventAboutToTrigger(RuleCalculateDamage evt)
        {

        }
        public void OnEventDidTrigger(RuleCalculateDamage evt)
        {
            foreach (BaseDamage baseDamage in evt.DamageBundle)
            {
                baseDamage.SetReductionBecauseResistance(3 + evt.Reason.Caster.Stats.Charisma, Fact);
            }
        }
    }
}