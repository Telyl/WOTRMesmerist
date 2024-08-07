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
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Classes;
using Mesmerist.Utils;

namespace Mesmerist.NewComponents
{
    [TypeId("e21417d1223a4b7cafaa08207dffaf6f")]
    public class ModifyD20SkillCheck : UnitFactComponentDelegate<ModifyD20.ComponentData>,
        IInitiatorRulebookHandler<RuleRollD20>, IRulebookHandler<RuleRollD20>,
        ISubscriber, IInitiatorRulebookSubscriber
    {
        private static readonly Logging.Logger Logger = Logging.GetLogger(nameof(ModifyD20SkillCheck));
        
        public void OnEventAboutToTrigger(RuleRollD20 evt)
        {
            RuleSkillCheck previousEvent = Rulebook.CurrentContext.PreviousEvent as RuleSkillCheck;
            if (previousEvent == null) { return; }
            if (previousEvent.IsSuccessRoll(evt.PreRollDice())) { return; }
            if (!IsSuitableSkillCheck(previousEvent)) { return; }
            if (fact != null && !base.Owner.HasFact(fact)) { return; }

            int spiritBonusValue = 0;
            if (this.checkSpiritBonus) { spiritBonusValue = base.Fact.MaybeContext.MaybeCaster.GetFact(SpiritBonus).GetRank(); }
            base.Data.Roll = evt;
            int value = this.Bonus.Calculate(base.Fact.MaybeContext) + spiritBonusValue;
            previousEvent.Bonus.AddModifier(value, base.Runtime, ModifierDescriptor.UntypedStackable);
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
        private bool IsSuitableSkillCheck(RuleSkillCheck rule)
        {
            return this.Skill.HasItem(rule.StatType);
        }

        public bool DispellOnRerollFinished = true;
        public ContextValue Bonus;
        public StatType[] Skill;
        public bool checkFact = true;
        public BlueprintUnitFactReference fact;
        public bool checkSpiritBonus = false;
        private BlueprintFeatureReference SpiritBonus = BlueprintTool.GetRef<BlueprintFeatureReference>(Guids.SpiritBonus);



    }
}