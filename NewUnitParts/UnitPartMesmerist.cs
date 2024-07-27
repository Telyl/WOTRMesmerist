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
using Kingmaker.Controllers.Combat;
using static Kingmaker.RuleSystem.RulebookEvent;

namespace Mesmerist.NewUnitParts
{
    public class UnitPartMesmerist : OldStyleUnitPart,
        ISubscriber,
        IInitiatorRulebookSubscriber
    {
        private static readonly Logging.Logger Logger = Logging.GetLogger(nameof(UnitPartMesmerist));
    }
}
       