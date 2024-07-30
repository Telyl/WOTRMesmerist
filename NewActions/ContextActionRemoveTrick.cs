using Kingmaker.EntitySystem.Entities;
using Kingmaker;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.UnitLogic.Parts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules.Abilities;
using Kingmaker.RuleSystem.Rules;
using Microsoft.Build.Utilities;
using CharacterOptionsPlus.Util;
using Kingmaker.EntitySystem.Persistence;
using Mesmerist.NewUnitParts;
using Kingmaker.Blueprints;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using UnityEngine.Serialization;
using UnityEngine;

namespace Mesmerist.NewActions
{
    public class ContextActionRemoveTrick : ContextAction
    {
        private static readonly Logging.Logger Logger = Logging.GetLogger(nameof(ContextActionRemoveTrick));
        public BlueprintBuff Buff
        {
            get
            {
                BlueprintBuffReference buff = this.m_Buff;
                if (buff == null)
                {
                    return null;
                }
                return buff.Get();
            }
        }
        public override string GetCaption()
        {
            return "Remove Trick";
        }

        public override void RunAction()
        {
            UnitEntityData target = base.Target.Unit;
            if (target == null)
            {
                Logger.Log("Target unit is missing - ContextActionMetaTrick");
                return;
            }
            UnitEntityData caster = base.Context.MaybeCaster;
            if (caster == null)
            {
                Logger.Log("Attacker unit is missing - ContextActionMetaTrick");
                return;
            }

            Logger.Log("target: " + target.ToString());
            Logger.Log("caster: " + caster.ToString());

            Logger.Log("RemoveTrick should be doing something here.");
            var unitPartTricks = caster.Ensure<UnitPartTricks>();
            var trickdata = unitPartTricks.RemoveTrick(target, Buff.AssetGuid);

            /*if (Game.Instance.SaveManager.CurrentState != SaveManager.State.Saving)
            {*/
            /*if (trickdata.ShouldBounce)
            {
                var unitbounce = unitPartTricks.TrickBounceToUnit(target);
                Rulebook.Trigger<RuleCastSpell>(new RuleCastSpell(base.AbilityContext.Ability, unitbounce)
                {
                    IsDuplicateSpellApplied = true
                });
                base.Context.SourceAbilityContext.Ability.Spend();
            }
            else if (trickdata.ShouldReapply)
            {
                Rulebook.Trigger<RuleCastSpell>(new RuleCastSpell(base.AbilityContext.Ability, target)
                {
                    IsDuplicateSpellApplied = true
                });
                base.Context.SourceAbilityContext.Ability.Spend();
            }
           // }*/
        }

        [SerializeField]
        [FormerlySerializedAs("Buff")]
        public BlueprintBuffReference m_Buff;
    }
}
