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
using Kingmaker.Blueprints.Classes;
using Kingmaker.UnitLogic;

namespace Mesmerist.NewActions
{
    public class ContextActionRemoveFact : ContextAction
    {
        private static readonly Logging.Logger Logger = Logging.GetLogger(nameof(ContextActionRemoveFact));
        public BlueprintFeature Feature
        {
            get
            {
                BlueprintFeatureReference feature = this.m_Feature;
                if (feature == null)
                {
                    return null;
                }
                return feature.Get();
            }
        }
        public override string GetCaption()
        {
            return "Enable Spellbook";
        }

        public override void RunAction()
        {
            UnitEntityData target = base.Target.Unit;
            if (target == null)
            {
                Logger.Log("Target unit is missing - ContextActionAddTrick");
                return;
            }
            UnitEntityData caster = base.Context.MaybeCaster;
            if (caster == null)
            {
                Logger.Log("Attacker unit is missing - ContextActionAddTrick");
                return;
            }
            Logger.Log("I am removing fact in EnableSpellbook");
            target.RemoveFact(Feature);
        }

        [SerializeField]
        [FormerlySerializedAs("Buff")]
        public BlueprintFeatureReference m_Feature;
    }
}
