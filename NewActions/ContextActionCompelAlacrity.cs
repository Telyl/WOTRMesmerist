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
using TurnBased.Controllers;

namespace Mesmerist.NewActions
{
    public class ContextActionCompelAlacrity : ContextAction
    {
        private static readonly Logging.Logger Logger = Logging.GetLogger(nameof(ContextActionCompelAlacrity));
        public override string GetCaption()
        {
            return "Compel Alacrity";
        }

        public override void RunAction()
        {
            UnitEntityData target = base.Target.Unit;
            if (target == null)
            {
                Logger.Log("Target unit is missing - ContextActionCompelAlacrity");
                return;
            }
            UnitEntityData caster = base.Context.MaybeCaster;
            if (caster == null)
            {
                Logger.Log("Attacker unit is missing - ContextActionCompelAlacrity");
                return;
            }
        }
    }
}
