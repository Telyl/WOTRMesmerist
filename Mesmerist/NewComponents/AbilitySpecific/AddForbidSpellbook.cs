using System;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Parts;
using UnityEngine;
using UnityEngine.Serialization;

namespace Mesmerist.NewComponents.AbilitySpecific
{
    // Token: 0x02001CD9 RID: 7385
    [AllowedOn(typeof(BlueprintUnitFact), false)]
    [TypeId("0e9eb64c0dd743efad474f8f188187c2")]
    public class AddForbidSpellbook : UnitFactComponentDelegate
    {
        // Token: 0x17001EB4 RID: 7860
        // (get) Token: 0x0600C6F3 RID: 50931 RVA: 0x0033E9ED File Offset: 0x0033CBED
        public BlueprintSpellbook Spellbook
        {
            get
            {
                BlueprintSpellbookReference spellbook = this.m_Spellbook;
                if (spellbook == null)
                {
                    return null;
                }
                return spellbook.Get();
            }
        }

        // Token: 0x0600C6F4 RID: 50932 RVA: 0x0033EA00 File Offset: 0x0033CC00
        public override void OnTurnOn()
        {
            UnitPartForbiddenSpellbooks unitPartForbiddenSpellbooks = base.Owner.Get<UnitPartForbiddenSpellbooks>();
            if (unitPartForbiddenSpellbooks == null)
            {
                return;
            }
            unitPartForbiddenSpellbooks.Remove(this.Spellbook, ForbidSpellbookReason.Other);
        }

        // Token: 0x0600C6F5 RID: 50933 RVA: 0x0033EA19 File Offset: 0x0033CC19
        public override void OnTurnOff()
        {
            base.Owner.Ensure<UnitPartForbiddenSpellbooks>().Add(this.Spellbook, ForbidSpellbookReason.Other);
        }

        // Token: 0x04008634 RID: 34356
        [SerializeField]
        [FormerlySerializedAs("Spellbook")]
        public BlueprintSpellbookReference m_Spellbook;
    }
}
