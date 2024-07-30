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

namespace Mesmerist.NewActions
{
    public class ContextActionSloppyDefense : ContextAction
    {
        private static readonly Logging.Logger Logger = Logging.GetLogger(nameof(ContextActionSloppyDefense));
        public override string GetCaption()
        {
            return "Sloppy Defense";
        }

        public override void RunAction()
        {
            UnitEntityData target = base.Target.Unit;
            if (target == null)
            {
                Logger.Log("Target unit is missing - ContextActionSloppyDefense");
                return;
            }
            UnitEntityData attacker = base.Context.MaybeCaster;
            if (attacker == null)
            {
                Logger.Log("Attacker unit is missing - ContextActionSloppyDefense");
                return;
            }
        }
    }
}
