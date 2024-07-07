using BlueprintCore.Utils;
using CharacterOptionsPlus.Util;
using Kingmaker;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Facts;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.Utility;
using Mesmerist.Utils;
using Mesmerist.NewComponents;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnBased.Controllers;
using static UnityModManagerNet.UnityModManager.ModEntry;

namespace Mesmerist.NewUnitParts
{
    public class UnitPartMesmerist : UnitPart
    {
        private static readonly Logging.Logger Logger = Logging.GetLogger(nameof(UnitPartMesmerist));

        public void MesmeristTrick()
        {

        }
        public class MesmeristTrickEntry
        {
            public BlueprintAbilityReference ActiveTrick;
            public BlueprintAbilityReference ActiveManifold;
         
        }
    }


}