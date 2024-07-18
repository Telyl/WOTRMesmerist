using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using CharacterOptionsPlus.Util;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Items.Ecnchantments;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.Enums;
using Kingmaker.Items;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.RuleSystem.Rules.Abilities;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.UnitLogic.Mechanics.ContextData;
using Kingmaker.Utility;
using Mesmerist.NewUnitParts;
using Mesmerist.Utils;
using System;

namespace Mesmerist.NewComponents.AbilitySpecific
{
    [TypeId("dd38ed5d373a43b1ad7f25af6f8c22c4")]
    public class AddAstoundingAvoidanceTrick : UnitFactComponentDelegate,
        ISubscriber, IUnitEvasionHandler
    {
        private static readonly Logging.Logger Logger = Logging.GetLogger(nameof(AddAstoundingAvoidanceTrick));

        public void HandleEffectEvaded(UnitEntityData unit, MechanicsContext context)
        {
            unit.Descriptor.Buffs.RemoveFact(AstoundingAvoidance);
        }

        public BlueprintBuffReference AstoundingAvoidance;
    }
}