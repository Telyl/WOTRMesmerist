using Kingmaker.EntitySystem.Entities;
using Kingmaker.EntitySystem;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Buffs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mesmerist.NewUnitParts.UnitPartMesmeristTrickHolder;
using Kingmaker.PubSubSystem;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints;
using BlueprintCore.Blueprints.Configurators.AI;
using CharacterOptionsPlus.Util;
using static Kingmaker.EntitySystem.Properties.BaseGetter.ListPropertyGetter;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.Designers;
using Kingmaker.Utility;
using Kingmaker;
using Kingmaker.RuleSystem.Rules.Abilities;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.Controllers;
using System.Net;

namespace Mesmerist.NewUnitParts
{
    public class UnitPartTricks : OldStyleUnitPart,
        ISubscriber, IUnitRestHandler,
        IInitiatorRulebookSubscriber
    {
        private static readonly Logging.Logger Logger = Logging.GetLogger(nameof(UnitPartTricks));
        public int ManifoldHijinksRank
        {
            get
            {
                return Math.Max(0, base.Owner.Progression.Features.GetRank(ManifoldHijinks));
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
                return Math.Max(0, 1 + base.Owner.Progression.Features.GetRank(ManifoldTrick));
            }
        }
        public int RemainingTricks
        {
            get
            {
                return Math.Max(0, this.MaxTricks - this.UsedTricks);
            }
        }
        public BlueprintFeature ManifoldHijinks => this.settings.m_ManifoldHijinks?.Get();
        public BlueprintFeature ManifoldTrick => this.settings.m_ManifoldTrick?.Get();
        public EntityFact BouncingTrick => Owner.GetFact(this.settings.m_BouncingTrick);
        public EntityFact ReapplyTrick => Owner.GetFact(this.settings.m_ReapplyTrick);
        public void Setup(AddMesmeristPart settings)
        {
            this.settings = settings;
            this.m_TrickHolderCache = base.Owner.Ensure<UnitPartMesmeristTrickHolder>();
        }
        public void Remove()
        {
            base.Owner.Remove<UnitPartMesmeristTrickHolder>();
        }
        public void CleanupTrackedTricks()
        {
            this.m_TrickHolderCache.TrackedTricks.Clear();
        }
        public void AddTrick(EntityRef<UnitEntityData> Unit, BlueprintGuid Guid, bool duplicate = false)
        {
            if (ActiveEntryCountUnit(Unit) > ManifoldHijinksRank)
            {
                var trickdata = GetTrickDataByUnit(Unit);
                var buff = GetBuffByTrickData(trickdata);
                trickdata.ShouldReapply = false;
                trickdata.ShouldBounce = false;
                trickdata.Unit.Entity.RemoveFact(buff);
            }

            else if (RemainingTricks == 0)
            {
                var oldTrick = this.m_TrickHolderCache.TrackedTricks[0];
                var buff = GetBuffByTrickData(oldTrick);
                this.m_TrickHolderCache.TrackedTricks.RemoveAt(0);
                oldTrick.ShouldReapply = false;
                oldTrick.ShouldBounce = false;
                oldTrick.Unit.Entity.RemoveFact(buff);
            }

            var bounceTrick = CheckBounceTrick(duplicate);
            var reapplyTrick = CheckReapplyTrick(duplicate);
            this.m_TrickHolderCache.TrackedTricks.Add(new TrickData
            {
                Unit = Unit,
                Guid = Guid,
                ShouldBounce = bounceTrick,
                ShouldReapply = reapplyTrick,

            });
        }
        public UnitEntityData TrickBounceToUnit(EntityRef<UnitEntityData> OriginalUnit)
        {
            UnitEntityData Unit = OriginalUnit;
            foreach (var unit in Game.Instance.Player.PartyAndPets)
            {
                if (unit == OriginalUnit) { continue; }
                else if (ActiveEntryCountUnit(unit) > ManifoldHijinksRank) {
                    continue;
                }
                else
                {
                    Unit = unit;
                    break;
                }
            }
            if (Unit == OriginalUnit) { return null; }
            return Unit;
        }
        public TrickData RemoveTrick(EntityRef<UnitEntityData> Unit, BlueprintGuid Guid)
        {
            TrickData trickdata = this.m_TrickHolderCache.TrackedTricks.
                Where(entry => entry.Matches(Unit,Guid)).
                FirstOrDefault();

            this.m_TrickHolderCache.TrackedTricks.RemoveAll(entry => entry.Matches(Unit, Guid));
            return trickdata;
        }
        public int ActiveEntryCount()
        {
            return this.m_TrickHolderCache.TrackedTricks.Count();
        }
        public int ActiveEntryCountUnit(EntityRef<UnitEntityData> Unit)
        {
            return this.m_TrickHolderCache.TrackedTricks
                .Where(x => x.Unit.Id == Unit.Id).Count();
        }
        public TrickData GetTrickDataByUnit(EntityRef<UnitEntityData> Unit)
        {
            return this.m_TrickHolderCache.TrackedTricks
                .Where(x => x.Unit.Id == Unit.Id).FirstOrDefault();
        }

        public Buff GetBuffByTrickData(TrickData trickdata)
        {
            return trickdata.Unit.Entity.Descriptor.Buffs.Enumerable
                    .Where(c => c.Blueprint.AssetGuid == trickdata.Guid)
                    .FirstOrDefault();
        }

        public bool CheckBounceTrick(bool duplicate)
        {
            if (duplicate) { return false; }
            if (BouncingTrick != null) {
                return true; }
            return false;
        }

        public bool CheckReapplyTrick(bool duplicate)
        {
            if (duplicate) { return false; }
            if (ReapplyTrick != null) {
                return true; }
            return false;
        }

        public void HandleUnitRest(UnitEntityData unit)
        {
            CleanupTrackedTricks();
        }

        private UnitPartMesmeristTrickHolder m_TrickHolderCache;
        private AddMesmeristPart settings;
        private EntityFact FilterNoFact;
    }
}
