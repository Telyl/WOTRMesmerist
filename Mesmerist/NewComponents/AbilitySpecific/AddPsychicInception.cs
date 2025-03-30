using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.Blueprints;
using Kingmaker.EntitySystem;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules.Abilities;
using Kingmaker.RuleSystem.Rules.Damage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.UnitLogic;
using Mesmerist.Utils;
using Kingmaker.Blueprints.Facts;
using BlueprintCore.Utils;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic.Parts;
using TabletopTweaks.Core.NewUnitParts;
using Kingmaker.Blueprints.Classes.Spells;

namespace Mesmerist.NewComponents.AbilitySpecific
{
    [AllowMultipleComponents]
    [TypeId("fe4eb0615e264792b1d3030a9c010277")]
    public class AddPsychicInception : UnitFactComponentDelegate
       
    {
        public override void OnTurnOn()
        {
            UnitPartSpellResistance unitpart = base.Owner.Ensure<UnitPartSpellResistance>();
            UnitPartIgnoreBuffDescriptorImmunity buffunitpart = base.Owner.Ensure<UnitPartIgnoreBuffDescriptorImmunity>();
            unitpart.IgnoreImmunity(SpellDescriptor.MindAffecting | SpellDescriptor.Charm | SpellDescriptor.Compulsion | SpellDescriptor.Fear | SpellDescriptor.Emotion | SpellDescriptor.NegativeEmotion | SpellDescriptor.Shaken | SpellDescriptor.Frightened | SpellDescriptor.Confusion | SpellDescriptor.Sleep);
            buffunitpart.AddEntry(SpellDescriptor.MindAffecting | SpellDescriptor.Charm | SpellDescriptor.Compulsion | SpellDescriptor.Fear | SpellDescriptor.Emotion | SpellDescriptor.NegativeEmotion | SpellDescriptor.Shaken | SpellDescriptor.Frightened | SpellDescriptor.Confusion | SpellDescriptor.Sleep, base.Fact);
        }

        public override void OnTurnOff()
        {
            UnitPartSpellResistance unitpart = base.Owner.Ensure<UnitPartSpellResistance>();
            UnitPartIgnoreBuffDescriptorImmunity buffunitpart = base.Owner.Ensure<UnitPartIgnoreBuffDescriptorImmunity>();
            unitpart.RestoreImmunity(SpellDescriptor.MindAffecting | SpellDescriptor.Charm | SpellDescriptor.Compulsion | SpellDescriptor.Fear | SpellDescriptor.Emotion | SpellDescriptor.NegativeEmotion | SpellDescriptor.Shaken | SpellDescriptor.Frightened | SpellDescriptor.Confusion | SpellDescriptor.Sleep);
            buffunitpart.RemoveEntry(base.Fact);
        }
    }
}
