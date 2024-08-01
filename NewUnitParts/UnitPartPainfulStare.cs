using Kingmaker.Blueprints;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.EntitySystem;
using Kingmaker.UnitLogic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Buffs;
using Kingmaker.UI.ServiceWindow.CharacterScreen;
using Mesmerist.Mesmerist.BoldStares;
using Mesmerist.Mesmerist;
using Kingmaker.Blueprints.Classes;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.RuleSystem;
using BlueprintCore.Utils;
using Kingmaker;
using Mesmerist.Utils;
using static Kingmaker.UI.CanvasScalerWorkaround;
using Kingmaker.PubSubSystem;

namespace Mesmerist.NewUnitParts
{
    internal class UnitPartPainfulStare : OldStyleUnitPart,
        IGlobalRulebookHandler<RuleDealDamage>, IRulebookHandler<RuleDealDamage>,
        IUnitNewCombatRoundHandler, IUnitRestHandler, IUnitCombatHandler,
        ISubscriber,
        IInitiatorRulebookSubscriber
    {
        private int PainfulStareCooldown = 0;
        public BlueprintCharacterClass Class => m_Class?.Get();
        public EntityFact IntensePain => Owner.GetFact(m_IntensePain);
        public EntityFact PiercingStrike => Owner.GetFact(m_PiercingStrike);
        public BlueprintFeature ManifoldStare => m_ManifoldStare?.Get();
        public BlueprintFeature PainfulStare => m_PainfulStare?.Get();
        public BlueprintBuff HypnoticStare => m_HypnoticStare?.Get();

        public int PainfulStareBonusDamage
        {
            get
            {
                if (IntensePain != null)
                {
                    return Math.Max(1, (ClassLevel / 2) + (ClassLevel / 4));
                }
                else
                {
                    return Math.Max(1, ClassLevel / 2);
                }
            }
        }
        public int PainfulStareDiceDamage
        {
            get
            {
                return Math.Max(0, base.Owner.Progression.Features.GetRank(PainfulStare));
            }
        }
        public int PainfulStareAttackNumber
        {
            get
            {
                return Math.Max(1, base.Owner.Progression.Features.GetRank(ManifoldStare));
            }
        }

        public int ClassLevel
        {
            get
            {
                return base.Owner.Progression.GetClassLevel(this.Class);
            }
        }

        public void Remove()
        {
            base.RemoveSelf();
        }
        public void SetClass(BlueprintCharacterClassReference clazz)
        {
            m_Class = clazz;
        }

        public void SetManifoldStare(BlueprintFeatureReference manifoldStare)
        {
            m_ManifoldStare = manifoldStare;
        }

        public void SetPainfulStare(BlueprintFeatureReference painfulStare)
        {
            m_PainfulStare = painfulStare;
        }

        public void SetIntensePain(BlueprintFeatureReference intensePain)
        {
            m_IntensePain = intensePain;
        }
        public void SetPiercingStrike(BlueprintFeatureReference piercingStrike)
        {
            m_PiercingStrike = piercingStrike;
        }

        public void SetHypnoticStare(BlueprintBuffReference hypnoticStare)
        {
            m_HypnoticStare = hypnoticStare;
        }

        private BaseDamage CalculateDamage(int diceCount, DiceType diceType, EntityFact fact)
        {
            return new DamageDescription
            {
                TypeDescription = new DamageTypeDescription()
                {
                    Type = DamageType.Direct,
                    Common =
                    {
                        Precision = true
                    },
                },
                Dice = new DiceFormula(diceCount, diceType),
                Bonus = 0,
                SourceFact = fact,
            }.CreateDamage();
        }
        
        private void ResetPainfulStareCooldown(UnitEntityData unit)
        {
            if (unit.Progression.Features.HasFact(PainfulStare))
            {
                PainfulStareCooldown = 0;
            }
        }

        public void OnEventAboutToTrigger(RuleDealDamage evt) { }

        public void OnEventDidTrigger(RuleDealDamage evt)
        {
            if (!evt.Target.Descriptor.HasFact(HypnoticStare)) { return; }
            if (evt.Reason.Fact == base.Owner.Facts.Get(PainfulStare)) { return; }
            if (PainfulStareCooldown >= PainfulStareAttackNumber) { return; }
            var dicetype = DiceType.D6;
            if (base.Owner.HasFact(PiercingStrike))
            {
                dicetype = DiceType.D8;
            }
            var BonusDamage = CalculateDamage(PainfulStareBonusDamage, DiceType.One, base.Owner.Facts.Get(PainfulStare));
            var MesmeristDamage = CalculateDamage(PainfulStareDiceDamage, dicetype, base.Owner.Facts.Get(PainfulStare));
            DamageBundle CombinedDamage = new DamageBundle([BonusDamage, MesmeristDamage]);

            if (base.Owner == evt.Initiator)
            {
                Game.Instance.Rulebook.TriggerEvent(
                    new RuleDealDamage(base.Owner, evt.Target, CombinedDamage)
                    {
                        Reason = new RuleReason(base.Owner.Facts.Get(PainfulStare))
                    });
            }
            else
            {
                Game.Instance.Rulebook.TriggerEvent(
                new RuleDealDamage(base.Owner, evt.Target, BonusDamage)
                {
                    Reason = new RuleReason(base.Owner.Facts.Get(PainfulStare))
                });
            }
            PainfulStareCooldown += 1;
            //m_StareHolderCache.TrackedStare.Add(evt.Target);
        }

        public void HandleUnitRest(UnitEntityData unit)
        {
            ResetPainfulStareCooldown(unit);
        }

        public void HandleNewCombatRound(UnitEntityData unit)
        {
            ResetPainfulStareCooldown(unit);
        }

        public void HandleUnitJoinCombat(UnitEntityData unit)
        {
            ResetPainfulStareCooldown(unit);
        }

        public void HandleUnitLeaveCombat(UnitEntityData unit)
        {
            ResetPainfulStareCooldown(unit);
        }

        private BlueprintCharacterClassReference m_Class;
        private BlueprintFeatureReference m_ManifoldStare;
        private BlueprintFeatureReference m_PainfulStare;
        private BlueprintFeatureReference m_IntensePain;
        private BlueprintFeatureReference m_PiercingStrike;
        private BlueprintBuffReference m_HypnoticStare;
        
    }
}
