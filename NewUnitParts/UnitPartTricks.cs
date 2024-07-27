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

namespace Mesmerist.NewUnitParts
{
    public class UnitPartTricks : OldStyleUnitPart,
        ISubscriber,
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
                Logger.Log("Used tricks: " + this.ActiveEntryCount());
                return this.ActiveEntryCount();
            }
        }
        public int MaxTricks
        {
            get
            {
                Logger.Log("Max Tricks: " + (1 + base.Owner.Progression.Features.GetRank(ManifoldTrick)));
                return Math.Max(0, 1 + base.Owner.Progression.Features.GetRank(ManifoldTrick));
            }
        }
        public int RemainingTricks
        {
            get
            {
                Logger.Log("Remaining Tricks: " + (this.MaxTricks - this.UsedTricks));
                return Math.Max(0, this.MaxTricks - this.UsedTricks);
            }
        }
        public BlueprintFeature ManifoldHijinks => this.settings.m_ManifoldHijinks?.Get();
        public BlueprintFeature ManifoldTrick => this.settings.m_ManifoldTrick?.Get();
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
        public void AddTrick(EntityRef<UnitEntityData> Unit, BlueprintGuid Guid)
        {

            if (ActiveEntryCountUnit(Unit) > ManifoldHijinksRank)
            {
                var trickdata = GetTrickDataByUnit(Unit);
                var buff = GetBuffByTrickData(trickdata);
                trickdata.Unit.Entity.RemoveFact(buff);
            }

            else if (RemainingTricks == 0)
            {
                var oldTrick = this.m_TrickHolderCache.TrackedTricks[0];
                var buff = GetBuffByTrickData(oldTrick);
                oldTrick.Unit.Entity.RemoveFact(buff);
            }
            this.m_TrickHolderCache.TrackedTricks.Add(new TrickData
            {
                Unit = Unit,
                Guid = Guid,
            });
        }
        public void RemoveTrick(EntityRef<UnitEntityData> Unit, BlueprintGuid Guid)
        {
            this.m_TrickHolderCache.TrackedTricks.RemoveAll(entry => entry.Matches(Unit, Guid));
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

        private UnitPartMesmeristTrickHolder m_TrickHolderCache;
        private AddMesmeristPart settings;
    }
}
