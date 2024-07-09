using BlueprintCore.Utils;
using CharacterOptionsPlus.Util;
using HarmonyLib;
using Kingmaker.Armies.TacticalCombat;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.RuleSystem.Rules.Abilities;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Parts;
using Mesmerist.NewComponents;
using Mesmerist.Utils;
using System.Security.Policy;
using TabletopTweaks.Core.NewUnitParts;

namespace Mesmerist.NewComponents
{
    [TypeId("6ce6acee4e42469d8d8e692f31168fd9")]
    public class AddPsychicInceptionAllowGaze : UnitFactComponentDelegate,
        IInitiatorRulebookHandler<RuleApplySpell>,
        IRulebookHandler<RuleApplySpell>,
        ISubscriber,
        IInitiatorRulebookSubscriber
    {
        private static readonly Logging.Logger Logger = Logging.GetLogger(nameof(AddPsychicInceptionAllowGaze));
        
        public void OnEventAboutToTrigger(RuleApplySpell evt)
        {
            if (!evt.Context.MaybeCaster.HasFact(BecauseOfFact)) { return; }
            evt.SpellTarget.Unit.Ensure<UnitPartIgnoreBuffDescriptorImmunity>().AddEntry(IgnoreDescriptors, base.Fact);
        }

        public void OnEventDidTrigger(RuleApplySpell evt)
        {
            
        }
        public SpellDescriptor IgnoreDescriptors;
        public BlueprintFeatureReference BecauseOfFact;
    }
}