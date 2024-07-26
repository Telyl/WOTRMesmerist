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
        IInitiatorRulebookHandler<RuleApplySpell>, IRulebookHandler<RuleApplySpell>,
        ISubscriber, IInitiatorRulebookSubscriber
    {
        private static readonly Logging.Logger Logger = Logging.GetLogger(nameof(AddLinkedReaction));
        private static UnitEntityData mesmerist;


        public void OnEventAboutToTrigger(RuleInitiativeRoll evt)
        {
            try
            {
                var unitpart = mesmerist.Ensure<UnitPartMesmerist>();
                unitpart.LinkedReaction();
                evt.m_OverrideResult = unitpart.LinkedReactionD20 + unitpart.LinkedReactionInitiative;
            }
            catch
            {
                return;
            }
        }

        public void OnEventAboutToTrigger(RuleApplySpell evt) {
        }

        public void OnEventDidTrigger(RuleInitiativeRoll evt) {
        }

        public void OnEventDidTrigger(RuleApplySpell evt)
        {
            mesmerist = evt.Context.MaybeCaster;
        }
    }
}