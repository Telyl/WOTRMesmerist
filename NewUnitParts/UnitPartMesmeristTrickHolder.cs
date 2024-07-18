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

namespace Mesmerist.NewUnitParts
{
    internal class UnitPartMesmeristTrickHolder : OldStyleUnitPart
    {
        [JsonProperty]

        public List<TrickData> TrackedTricks = new List<TrickData>();

        public class TrickData
        {
            public EntityRef<UnitEntityData> Unit;
            public Buff Buff;

            public bool Matches(UnitEntityData Unit, Buff Buff)
            {
                return Unit.UniqueId.Equals(this.Unit.Id) && Buff.UniqueId.Equals(this.Buff.UniqueId);
            }

            public override bool Equals(object obj)
            {
                return obj is TrickData data &&
                       this.Unit.Equals(data.Unit) &&
                       this.Buff.Equals(data.Buff);
            }

            public override int GetHashCode()
            {
                int hashCode = 1572805227;
                hashCode = hashCode * -1521134295 + Unit.GetHashCode();
                hashCode = hashCode * -1521134295 + Buff.GetHashCode();
                return hashCode;
            }

            public static bool operator ==(TrickData a, TrickData b)
            {
                return a.Unit.Equals(b.Unit) && a.Buff.Equals(b.Buff);
            }

            public static bool operator !=(TrickData a, TrickData b)
            {
                return !a.Unit.Equals(b.Unit) || !a.Buff.Equals(b.Buff);
            }
        }
    }
}
