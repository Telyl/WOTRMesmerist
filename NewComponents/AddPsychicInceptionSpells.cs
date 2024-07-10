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
    [TypeId("5af58cb1a56c4c38be810dfc6b63fe86")]
    public class AddPsychicInceptionSpells : UnitFactComponentDelegate,
        IAfterRulebookEventTriggerHandler<RuleSavingThrow>,
        IBeforeRulebookEventTriggerHandler<RuleSavingThrow>,
        IAfterRulebookEventTriggerHandler<RuleSpellResistanceCheck>,
        IGlobalSubscriber

    {
        private static readonly Logging.Logger Logger = Logging.GetLogger(nameof(AddPsychicInceptionSpells));
        private static bool wasImmune = false;

        public void OnAfterRulebookEventTrigger(RuleSpellResistanceCheck evt)
        {
            if (!evt.Context.MaybeCaster.HasFact(BecauseOfFact)) { return; }
            if (!evt.Target.Descriptor.HasFact(BecauseOfFactBuff)) { return; }
            if (!evt.Ability.SpellDescriptor.HasAnyFlag(IgnoreDescriptors)) { return; }
            if (!evt.TargetIsImmune) { return; }
            evt.TargetIsImmune = false;
            wasImmune = true;
        }
        public void OnBeforeRulebookEventTrigger(RuleSavingThrow evt)
        {
            if (wasImmune)
            {
                evt.AddModifier(2, base.Fact, ModifierDescriptor.UntypedStackable);
            }
        }

        public void OnAfterRulebookEventTrigger(RuleSavingThrow evt)
        {
            wasImmune = false;
        }
        public SpellDescriptor IgnoreDescriptors;
        public BlueprintFeatureReference BecauseOfFact;
        public BlueprintBuffReference BecauseOfFactBuff;
    }
}