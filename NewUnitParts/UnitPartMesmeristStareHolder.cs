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
    internal class UnitPartMesmeristStareHolder : OldStyleUnitPart
    {
        [JsonProperty]

        public List<EntityRef<UnitEntityData>> TrackedStare = new List<EntityRef<UnitEntityData>>();
    }
}
