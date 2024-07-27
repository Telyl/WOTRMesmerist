using Kingmaker.Blueprints;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.EntitySystem;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Buffs;
using Mesmerist.NewUnitParts;
using TabletopTweaks.Core.NewUnitParts;
using static Kingmaker.UI.CanvasScalerWorkaround;
using Kingmaker.RuleSystem.Rules.Abilities;
using Kingmaker.PubSubSystem;
using Microsoft.Build.Utilities;
using CharacterOptionsPlus.Util;
using Kingmaker.RuleSystem.Rules;

namespace Mesmerist.NewComponents.AbilitySpecific
{
    [AllowMultipleComponents]
    [TypeId("c34dc5de6b08466f802d8106cb9c195d")]
    public class AddTrickComponent : UnitFactComponentDelegate
    {
        private static readonly Logging.Logger Logger = Logging.GetLogger(nameof(AddTrickComponent));
        public override void OnTurnOn()
        {
            var unitPartTricks = base.Context.MaybeCaster.Ensure<UnitPartTricks>();
            unitPartTricks.AddTrick(base.Owner, base.OwnerBlueprint.AssetGuid);
        }
        public override void OnTurnOff() {
            var unitPartTricks = base.Context.MaybeCaster.Ensure<UnitPartTricks>();
            unitPartTricks.RemoveTrick(base.Owner, base.OwnerBlueprint.AssetGuid);
        }

    }
}