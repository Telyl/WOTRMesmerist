using Kingmaker.EntitySystem.Entities;
using Kingmaker.EntitySystem;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Buffs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kingmaker.TextTools;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Microsoft.Build.Utilities;
using CharacterOptionsPlus.Util;

namespace Mesmerist.NewUnitParts
{
    internal class UnitPartLinkedReaction : OldStyleUnitPart
    {
        private static readonly Logging.Logger Logger = Logging.GetLogger(nameof(UnitPartLinkedReaction));
        public List<EntityRef<UnitEntityData>> TrackedReactions = new List<EntityRef<UnitEntityData>>();
        public BlueprintFeature LinkedReactionFeature => m_LinkedReactionFeature.Get();
        public int? LinkedReaction()
        {
            if (TrackedReactions.Count == 1) { return null; }
            if (d20 != null && initiative != null) { return d20 + initiative; }
            initiative = base.Owner.Stats.Initiative;
            d20 = RulebookEvent.Dice.D20;

            foreach (UnitEntityData unit in TrackedReactions)
            {
                initiative = Math.Max((int)initiative, unit.Stats.Initiative);
                var newD20 = RulebookEvent.Dice.D20;
                if (d20 <= newD20) { d20 = newD20; }
            }
            return d20 + initiative;
        }

        private BlueprintFeatureReference m_LinkedReactionFeature;
        private RuleRollD20 d20;
        private int? initiative;

    }
}
