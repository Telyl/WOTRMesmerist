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
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using Mesmerist.Medium;
using BlueprintCore.Utils;
using Mesmerist.Utils;

namespace Mesmerist.NewComponents
{
    [TypeId("ca6c7e4f8cf74aa5b2fcfed1886a5fc3")]
    public class ModifyD20SavingThrow : UnitFactComponentDelegate<ModifyD20.ComponentData>,
        IInitiatorRulebookHandler<RuleRollD20>, IRulebookHandler<RuleRollD20>,
        ISubscriber, IInitiatorRulebookSubscriber
    {
        private static readonly Logging.Logger Logger = Logging.GetLogger(nameof(ModifyD20SavingThrow));
        
        public void OnEventAboutToTrigger(RuleRollD20 evt)
        {
            RuleSavingThrow previousEvent = Rulebook.CurrentContext.PreviousEvent as RuleSavingThrow;
            if (previousEvent == null) { return; }
            if (previousEvent.IsSuccessRoll(evt.PreRollDice())) { return; }
            if (!IsSuitableSavingThrow(previousEvent)) { return; }
            if (fact != null && !base.Owner.HasFact(fact)) { return; }

            base.Data.Roll = evt;
            CharacterStats stats = evt.Initiator.Stats;
            int spiritBonusValue = 0;
            if (this.checkSpiritBonus) { spiritBonusValue = base.Fact.MaybeContext.MaybeCaster.GetFact(SpiritBonus).GetRank(); }
            int value = this.Bonus.Calculate(base.Fact.MaybeContext) + spiritBonusValue; ;
            previousEvent.AddTemporaryModifier(stats.SaveWill.AddModifier(value, base.Runtime, this.ModifierDescriptor));
            previousEvent.AddTemporaryModifier(stats.SaveReflex.AddModifier(value, base.Runtime, this.ModifierDescriptor));
            previousEvent.AddTemporaryModifier(stats.SaveFortitude.AddModifier(value, base.Runtime, this.ModifierDescriptor));
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
        private bool IsSuitableSavingThrow(RuleSavingThrow ruleSavingThrow)
        {
			if ( ruleSavingThrow == null)
			{
				return false;
			}
			MechanicsContext context = ruleSavingThrow.Reason.Context;
			SpellDescriptor descriptor = (context != null) ? context.SpellDescriptor : Kingmaker.Blueprints.Classes.Spells.SpellDescriptor.None;
            if (this.SpecificDescriptor && !descriptor.Intersects(this.SpellDescriptor))
			{
				return false;
			}
			FlaggedSavingThrowType flaggedSavingThrowType = RuleSavingThrow.ConvertToFlaggedSavingThrowType(ruleSavingThrow.Type);
			return (this.SavingThrowType & flaggedSavingThrowType) > (FlaggedSavingThrowType)0;
        }

        public bool DispellOnRerollFinished = true;
        public ContextValue Bonus;
        public bool checkFact = true;
        public BlueprintUnitFactReference fact;
        public bool SpecificDescriptor = false;
        public SpellDescriptorWrapper SpellDescriptor;
        public FlaggedSavingThrowType SavingThrowType = FlaggedSavingThrowType.All;
        public ModifierDescriptor ModifierDescriptor;
        public bool checkSpiritBonus = false;
        private BlueprintFeatureReference SpiritBonus = BlueprintTool.GetRef<BlueprintFeatureReference>(Guids.SpiritBonus);

    }
}