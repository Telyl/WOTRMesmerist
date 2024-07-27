using BlueprintCore.Utils;
using CharacterOptionsPlus.Util;
using HarmonyLib;
using Kingmaker;
using Kingmaker.Armies.TacticalCombat;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.RuleSystem.Rules.Abilities;
using Kingmaker.UnitLogic;
using Mesmerist.NewUnitParts;
using Mesmerist.Utils;
using System;
using System.Security.AccessControl;
using System.Security.Policy;
using TabletopTweaks.Core.Utilities;

namespace Mesmerist.NewComponents.AbilitySpecific
{
    [TypeId("f5a934142ccc4ebc882b3acf896ad81f")]
    public class AddLinkedReaction : UnitFactComponentDelegate,
        IInitiatorRulebookHandler<RuleInitiativeRoll>, IRulebookHandler<RuleInitiativeRoll>,
        ISubscriber, IInitiatorRulebookSubscriber
    {
        private static readonly Logging.Logger Logger = Logging.GetLogger(nameof(AddLinkedReaction));
        private static UnitPartLinkedReaction unitPartLinkedReaction;

        public override void OnTurnOn()
        {
            unitPartLinkedReaction = base.Context.MaybeCaster.Ensure<UnitPartLinkedReaction>();
            unitPartLinkedReaction.TrackedReactions.Add(base.Owner);
        }
        public override void OnTurnOff()
        {
            unitPartLinkedReaction = base.Context.MaybeCaster.Ensure<UnitPartLinkedReaction>();
            unitPartLinkedReaction.TrackedReactions.Remove(base.Owner);
        }
        public void OnEventAboutToTrigger(RuleInitiativeRoll evt)
        {
            Logger.Log("I am in RULEINITIATIVEROLL");
            Logger.Log("Unit is: " + evt.Reason.SourceUnit.ToString());
            evt.m_OverrideResult = unitPartLinkedReaction.LinkedReaction();
        }
        public void OnEventDidTrigger(RuleInitiativeRoll evt) {
        }
    }
}