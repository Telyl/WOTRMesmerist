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
        IInitiatorRulebookHandler<RuleSavingThrow>,
        IRulebookHandler<RuleSavingThrow>,
        ISubscriber,
        IInitiatorRulebookSubscriber
    {
        private static readonly Logging.Logger Logger = Logging.GetLogger(nameof(AddPsychicInceptionSpells));
        
        public void OnEventAboutToTrigger(RuleSavingThrow evt)
        {
            Logger.Log("AboutToTrigger RuleSavingThrow");
        }

        public void OnEventDidTrigger(RuleSavingThrow evt)
        {
            Logger.Log("DidTrigger RuleSavingThrow");
        }
    }
}