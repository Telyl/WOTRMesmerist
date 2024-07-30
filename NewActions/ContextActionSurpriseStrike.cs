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
    public class ContextActionSurpriseStrike : ContextAction
    {
        private static readonly Logging.Logger Logger = Logging.GetLogger(nameof(ContextActionSurpriseStrike));
        public override string GetCaption()
        {
            return "Surprise Strike";
        }

        public override void RunAction()
        {
            UnitEntityData target = base.Target.Unit;
            if (target == null)
            {
                Logger.Log("Target unit is missing - ContextActionSurpriseStrike");
                return;
            }
            UnitEntityData attacker = base.Context.MaybeCaster;
            if (attacker == null)
            {
                Logger.Log("Attacker unit is missing - ContextActionSurpriseStrike");
                return;
            }
            Rulebook.Trigger<RuleAttackWithWeapon>(new RuleAttackWithWeapon(attacker, target, attacker.GetFirstWeapon(), 5)
            { });
        }
    }
}
