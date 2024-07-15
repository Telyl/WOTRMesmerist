using BlueprintCore.Utils;
using CharacterOptionsPlus.Util;
using Kingmaker;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UnitLogic;
using Mesmerist.Utils;
using System;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums.Damage;
using BlueprintCore.Utils.Types;
using Kingmaker.UnitLogic.Mechanics.Components;
using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Conditions.Builder.BasicEx;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using Kingmaker.Utility;

namespace Mesmerist.NewComponents
{
    [AllowMultipleComponents]
    [TypeId("fe4eb0615e264792b1d3030a9c010277")]
    public class AddPainfulStare : EntityFactComponentDelegate, ITargetRulebookHandler<RuleDealDamage>, 
        IRulebookHandler<RuleDealDamage>, ISubscriber, ITargetRulebookSubscriber
    {
        private static readonly Logging.Logger Logger = Logging.GetLogger(nameof(AddPainfulStare));

        private void RunAction(RulebookEvent e, UnitEntityData target)
        {
            if ((e.Reason.Fact != base.Fact) && Actions.HasActions)
            {
                IFactContextOwner factContextOwner = base.Fact as IFactContextOwner;
                if (factContextOwner == null)
                {
                    return;
                }
                factContextOwner.RunActionInContext(Actions, target);
            }
        }
        public void OnEventAboutToTrigger(RuleDealDamage evt)
        {

            // If we're here because of ourselves, return.
            if (evt.Reason.Fact == base.Fact) { return; }
            // Get the caster
            var caster = this.Context.MaybeCaster;

            // Get the number of dice counts we should use.
            int diceCount = caster.Progression.Features.GetRank(BlueprintTool.GetRef<BlueprintFeatureReference>(Guids.PainfulStare));
            // Get the number of manifold tricks we have. This can equal 0.
            int totalAttackNum = caster.Progression.Features.GetRank(BlueprintTool.GetRef<BlueprintFeatureReference>(Guids.ManifoldStarePainfulStare));
            int bonusDmg = caster.Progression.GetClassLevel(BlueprintTool.GetRef<BlueprintCharacterClassReference>(Guids.Mesmerist)) / 2;
            // Set our cooldown rank initially to 0.
            int cooldownRank = 0;
            try
            {
                // Get the cooldown rank of the monster.
                cooldownRank = evt.Target.GetFact(BlueprintTool.GetRef<BlueprintBuffReference>(Guids.PainfulStareCooldown)).GetRank();
            }
            catch { cooldownRank = 0; }
            if (cooldownRank >= totalAttackNum) { return; } 
            BaseDamage baseDamage = new DamageDescription
            {
                TypeDescription = new DamageTypeDescription()
                {
                    Type = DamageType.Direct,
                    Common =
                    {
                        Precision = true
                    },
                    Physical =
                    {
                        Form = PhysicalDamageForm.Slashing & PhysicalDamageForm.Piercing & PhysicalDamageForm.Bludgeoning
                    }
                },
                Dice = new DiceFormula(diceCount, DiceType.D6),
                SourceFact = base.Fact
            }.CreateDamage();

            BaseDamage otherDamage = new DamageDescription
            {
                TypeDescription = new DamageTypeDescription()
                {
                    Type = DamageType.Direct,
                    Common =
                    {
                        Precision = true
                    },
                    Physical =
                    {
                        Form = PhysicalDamageForm.Slashing & PhysicalDamageForm.Piercing & PhysicalDamageForm.Bludgeoning
                    }
                },
                Dice = new DiceFormula(bonusDmg, DiceType.One),
                SourceFact = base.Fact
            }.CreateDamage();

            if (caster == evt.Initiator) {
                Game.Instance.Rulebook.TriggerEvent(
                    new RuleDealDamage(caster, evt.Target, baseDamage)
                    {
                        SourceAbility = base.Context.SourceAbility,
                        Reason = new RuleReason(base.Fact)
                    }
                );
            }
            Game.Instance.Rulebook.TriggerEvent(
                new RuleDealDamage(caster, evt.Target, otherDamage)
                {
                    SourceAbility = base.Context.SourceAbility,
                    Reason = new RuleReason(base.Fact)
                }
            );
        }

        public void OnEventDidTrigger(RuleDealDamage evt)
        {
            var caster = this.Context.MaybeCaster;
            int totalAttackNum = caster.Progression.Features.GetRank(BlueprintTool.GetRef<BlueprintFeatureReference>(Guids.ManifoldStarePainfulStare));
            int cooldownRank = 0;
            try
            {
                cooldownRank = evt.Target.GetFact(BlueprintTool.GetRef<BlueprintBuffReference>(Guids.PainfulStareCooldown)).GetRank();
            }
            catch { cooldownRank = 0; }

            if (evt.Reason.Fact == base.Fact) { return; }
            
            evt.Target.AddBuff(CheckFactOnTarget, caster, new Rounds(1).Seconds);
            if (cooldownRank >= totalAttackNum) { return; }
            bool DemoralizingStare = caster.HasFact(BlueprintTool.GetRef<BlueprintBuffReference>(Guids.DemoralizingStareBuff));
            bool FatiguingStare = caster.HasFact(BlueprintTool.GetRef<BlueprintBuffReference>(Guids.FatiguingStareBuff));
            bool ExcoriatingStare = caster.HasFact(BlueprintTool.GetRef<BlueprintBuffReference>(Guids.ExcoriatingStareBuff));
            //bool BleedingStare = this.Context.MaybeCaster.HasFact(BlueprintTool.GetRef<BlueprintBuffReference>(Guids.BleedingStareBuff));

            if (DemoralizingStare)
            {
                Actions = ActionsBuilder.New().SavingThrow(SavingThrowType.Will,
                    onResult: ActionsBuilder.New().ConditionalSaved(failed: ActionsBuilder.New().ApplyBuff(BuffRefs.Shaken.Reference.Get(), ContextDuration.Fixed(1)))).Build();
            }
            else if (ExcoriatingStare)
            {
                Actions = ActionsBuilder.New().SavingThrow(SavingThrowType.Will,
                        onResult: ActionsBuilder.New().ConditionalSaved(failed: ActionsBuilder.New().ApplyBuff(BuffRefs.Sickened.Reference.Get(), ContextDuration.Fixed(1)))).Build();
            }
            else if (FatiguingStare)
            {
                Actions = ActionsBuilder.New().SavingThrow(SavingThrowType.Fortitude,
                    onResult: ActionsBuilder.New().ConditionalSaved(failed: ActionsBuilder.New().ApplyBuff(BuffRefs.Fatigued.Reference.Get(), ContextDuration.Fixed(1)))).Build();
            }
            //var BleedingActions = ActionsBuilder.New().SavingThrow(SavingThrowType.Will,
            //        onResult: ActionsBuilder.New().ConditionalSaved(failed: ActionsBuilder.New().ApplyBuff(BuffRefs.Shaken.Reference.Get(), ContextDuration.Fixed(1)))).Build();
             
            RunAction(evt, evt.Target);
        }
        public BlueprintBuffReference CheckFactOnTarget;
        public ActionList Actions;
    }
}