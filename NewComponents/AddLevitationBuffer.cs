using BlueprintCore.Utils;
using CharacterOptionsPlus.Util;
using HarmonyLib;
using Kingmaker;
using Kingmaker.Armies.TacticalCombat;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.Enums;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;
using Mesmerist.NewComponents;
using Mesmerist.Utils;
using System.Security.Policy;
using TabletopTweaks.Core.Utilities;

namespace Mesmerist.NewComponents
{
    [TypeId("6f4d16b58ed74e3fb6aa48c45eecfaf3")]
    public class AddLevitationBuffer : UnitFactComponentDelegate, 
        ITargetRulebookHandler<RuleAttackWithWeapon>, IRulebookHandler<RuleAttackWithWeapon>,
        ISubscriber, ITargetRulebookSubscriber
    {
        private static readonly Logging.Logger Logger = Logging.GetLogger(nameof(AddLevitationBuffer));

        public void OnEventAboutToTrigger(RuleAttackWithWeapon evt)
        {

        }

        public void OnEventDidTrigger(RuleAttackWithWeapon evt)
        {
            RuleCombatManeuver cmb = new RuleCombatManeuver(base.Fact.MaybeContext.MaybeCaster, evt.Initiator, CombatManeuver.BullRush);
            cmb.ReplaceBaseStat = Kingmaker.EntitySystem.Stats.StatType.Charisma;
            cmb.ReplaceAttackBonus = base.Fact.MaybeContext.MaybeCaster.Progression.GetClassLevel(BlueprintTool.Get<BlueprintCharacterClass>(Guids.Mesmerist));

            Game.Instance.Rulebook.TriggerEvent<RuleCombatManeuver>(cmb);
            
            evt.Target.Descriptor.Buffs.RemoveFact(base.Fact);
        }
    }
}