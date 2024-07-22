using CharacterOptionsPlus.Util;
using Kingmaker.Blueprints;
using Kingmaker.EntitySystem;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.Utility;
using Kingmaker.PubSubSystem;
using Kingmaker.UnitLogic.Class.Kineticist;
using Kingmaker.EntitySystem.Stats;
using System;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using System.Collections.Generic;
using Kingmaker.Blueprints.Classes;
using Kingmaker.UnitLogic.ActivatableAbilities;
using static Mesmerist.NewUnitParts.UnitPartMesmeristTrickHolder;
using System.Linq;
using Kingmaker.UnitLogic.Buffs;
using static Kingmaker.UI.CanvasScalerWorkaround;
using BlueprintCore.Utils;
using Mesmerist.Utils;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.Enums.Damage;
using Kingmaker.RuleSystem;
using Kingmaker;
using BlueprintCore.Actions.Builder;
using BlueprintCore.Utils.Types;
using Kingmaker.ElementsSystem;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.References;
using Kingmaker.UnitLogic.Mechanics.Components;
using HarmonyLib;

namespace Mesmerist.NewUnitParts
{
    public class UnitPartMesmerist : OldStyleUnitPart,
        IGlobalRulebookHandler<RuleDealDamage>, IRulebookHandler<RuleDealDamage>, IGlobalRulebookSubscriber,
        IUnitNewCombatRoundHandler, IUnitRestHandler, IUnitBuffHandler,
        ISubscriber,
        IInitiatorRulebookSubscriber
    {
        private static readonly Logging.Logger Logger = Logging.GetLogger(nameof(UnitPartMesmerist));

        public int PainfulStareBonusDamage
        {
            get
            {
                return Math.Max(1, ClassLevel / 2);
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
        public int UsedTricks
        {
            get
            {
                return this.ActiveEntryCount();
            }
        }
        public int MaxTricks
        {
            get
            {
                return Math.Max(0, 1 + base.Owner.Progression.Features.GetRank(this.m_Settings.MaxTrick));
            }
        }
        public int LeftTricks
        {
            get
            {
                return Math.Max(0, this.MaxTricks - this.UsedTricks);
            }
        }

        public int ClassLevel
        {
            get
            {
                return base.Owner.Progression.GetClassLevel(this.m_Settings.Class);
            }
        }

        public string[] Tricks
        {
            get
            {
                return this.m_Settings.Tricks;
            }
        }

        public IEnumerable<BlueprintFeature> Stares
        {
            get
            {
                return this.m_Settings.Stares;
            }
        }
        public BlueprintBuff HypnoticStare
        {
            get
            {
                return this.m_Settings.HypnoticStare;
            }
        }

        public BlueprintBuff PainfulStareCooldown
        {
            get
            {
                return this.m_Settings.PainfulStareCooldown;
            }
        }
        public BlueprintFeature PainfulStare
        {
            get
            {
                return this.m_Settings.PainfulStare;
            }
        }
        public BlueprintFeature ManifoldStare
        {
            get
            {
                return this.m_Settings.ManifoldStare;
            }
        }

        public void Setup(AddMesmeristPart settings)
        {
            this.m_TrickHolderCache = base.Owner.Ensure<UnitPartMesmeristTrickHolder>();
            this.m_StareHolderCache = base.Owner.Ensure<UnitPartMesmeristStareHolder>();
            this.m_Settings = settings;
        }

        public void DequeueTrick()
        {
            if (LeftTricks > 0) { return; }
            TrickData OldTrick = m_TrickHolderCache.TrackedTricks[0];
            this.m_TrickHolderCache.TrackedTricks.RemoveAt(0);
            OldTrick.Unit.Entity.Descriptor.RemoveFact(OldTrick.Buff);
        }

        public void AddTrick(EntityRef<UnitEntityData> Unit, Buff Buff)
        {
            this.m_TrickHolderCache.TrackedTricks.Add(new TrickData
            {
                Unit = Unit,
                Buff = Buff,
            });
        }
        public void RemoveTrick(EntityRef<UnitEntityData> Unit, Buff Buff)
        {
            this.m_TrickHolderCache.TrackedTricks.Remove(entry => entry.Matches(Unit, Buff));

        }

        public bool HasActiveEntry(EntityRef<UnitEntityData> Unit, Buff Buff)
        {
            return this.m_TrickHolderCache.TrackedTricks.Any(entry => entry.Matches(Unit, Buff));
        }

        public int ActiveEntryCount()
        {
            return this.m_TrickHolderCache.TrackedTricks.Count();
        }
        public void CleanupTrackedTricks()
        {
            this.m_TrickHolderCache.TrackedTricks.Clear();
        }

        public void HandleNewCombatRound(UnitEntityData unit)
        {
            if (unit.Progression.Features.HasFact(PainfulStare)) {
                foreach (var u in m_StareHolderCache.TrackedStare)
                {
                    u.Entity.Descriptor.RemoveFact(PainfulStareCooldown);
                }
                m_StareHolderCache.TrackedStare.Clear();
            }
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
        public void OnEventAboutToTrigger(RuleDealDamage evt) { 
        }

        public void OnEventDidTrigger(RuleDealDamage evt)
        {
            int CooldownPainfulStare;

            if (!evt.Target.Descriptor.HasFact(HypnoticStare)) { return; }
            if (evt.Reason.Fact == base.Owner.Facts.Get(PainfulStare)) { return; }
            
            if (evt.Target.HasFact(PainfulStareCooldown)) { 
                CooldownPainfulStare = evt.Target.GetFact(PainfulStareCooldown).GetRank(); }
            else { 
                CooldownPainfulStare = 0; }

            if ( CooldownPainfulStare >= PainfulStareAttackNumber) { return; }
            
            var BonusDamage = CalculateDamage(PainfulStareBonusDamage, DiceType.One, base.Owner.Facts.Get(PainfulStare));
            var MesmeristDamage = CalculateDamage(PainfulStareDiceDamage, DiceType.D6, base.Owner.Facts.Get(PainfulStare));
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
            evt.Target.AddBuff(PainfulStareCooldown, base.Owner, new Rounds(1).Seconds);
            m_StareHolderCache.TrackedStare.Add(evt.Target);
            Logger.Log(m_StareHolderCache.TrackedStare.ToString());
            Logger.Log(m_StareHolderCache.TrackedStare.Count.ToString());
        }

        public void HandleUnitRest(UnitEntityData unit)
        {
            CleanupTrackedTricks();
        }

        public void HandleBuffDidAdded(Buff buff)
        {
            if (!Tricks.Contains(buff.Blueprint.AssetGuid.ToString())) { return; }
            
            // If we have an active entry, remove the trick and then add the trick to refresh place in List.
            if (HasActiveEntry(buff.Owner.Unit, buff))
            {
                RemoveTrick(buff.Owner.Unit, buff);
                AddTrick(buff.Owner.Unit, buff);
                return;
            }
            // No active entry, make sure we have enough resources, check dequeue then add trick.
            else
            {
                DequeueTrick();
                AddTrick(buff.Owner.Unit, buff);
            }
        }

        public void HandleBuffDidRemoved(Buff buff)
        {
            if (!Tricks.Contains(buff.Blueprint.AssetGuid.ToString())) { return; }

            if (HasActiveEntry(buff.Owner.Unit, buff))
            {
                RemoveTrick(buff.Owner.Unit, buff);
                return;
            }
        }

        private AddMesmeristPart m_Settings;
        private UnitPartMesmeristTrickHolder m_TrickHolderCache;
        private UnitPartMesmeristStareHolder m_StareHolderCache;
    }
}