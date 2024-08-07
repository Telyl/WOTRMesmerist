using CharacterOptionsPlus.Util;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.ElementsSystem;
using Kingmaker.Enums;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.Utility;
using UnityEngine;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules.Abilities;
using Kingmaker.UnitLogic.Mechanics.Components;
using Mesmerist.Medium;
using BlueprintCore.Utils;
using Mesmerist.Utils;

namespace Mesmerist.NewComponents
{
    [TypeId("fa9442dbb76c4e1c982dbdb00a864de2")]
    public class ModifyD20AC: UnitFactComponentDelegate<ModifyD20.ComponentData>,
        ITargetRulebookHandler<RuleRollD20>, IRulebookHandler<RuleRollD20>,
        ISubscriber, ITargetRulebookSubscriber
    {
        private static readonly Logging.Logger Logger = Logging.GetLogger(nameof(ModifyD20AC));
        
        public void OnEventAboutToTrigger(RuleRollD20 evt)
        {
            RuleAttackRoll previousEvent = Rulebook.CurrentContext.PreviousEvent as RuleAttackRoll;
            if (previousEvent == null) { return; }
            if (!previousEvent.IsSuccessRoll(evt.PreRollDice())) { return; }
            if (fact != null && !base.Owner.HasFact(fact)) { return; }

            base.Data.Roll = evt;
            int spiritBonusValue = 0;
            if (this.checkSpiritBonus) { spiritBonusValue = base.Fact.MaybeContext.MaybeCaster.GetFact(SpiritBonus).GetRank(); }
            int value = this.Bonus.Calculate(base.Fact.MaybeContext) + spiritBonusValue;
            previousEvent.TargetAC += value;
        }
        public void OnEventDidTrigger(RuleRollD20 evt)
        {
            if (base.Data.Roll == evt)
            {
                if (this.DispellOnRerollFinished)
                {
                    base.Owner.RemoveFact(base.Fact);
                }
            }

        }

        public bool DispellOnRerollFinished = true;
        public ContextValue Bonus;
        public bool checkFact = true;
        public BlueprintUnitFactReference fact;
        public bool checkSpiritBonus = false;
        private BlueprintFeatureReference SpiritBonus = BlueprintTool.GetRef<BlueprintFeatureReference>(Guids.SpiritBonus);

    }
}