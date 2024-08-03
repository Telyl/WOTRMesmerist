using Kingmaker;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Components.Base;
using Kingmaker.Utility;
using System;
using Mesmerist.Utils;
using BlueprintCore.Utils;

namespace Mesmerist.NewComponents
{
    [TypeId("0a24f433ea94482ab7fd920923e4bfe1")]
    public class AbilityRestoreSpell : AbilityApplyEffect, IAbilityRestriction, IAbilityRequiredParameters
    {
        public AbilityParameter RequiredParameters
        {
            get
            {
                return AbilityParameter.Spellbook | AbilityParameter.SpellLevel;
            }
        }
        // NOT IMPLEMENTED YET
        public override void Apply(AbilityExecutionContext context, TargetWrapper target)
        {
            if (context.Ability.ParamSpellbook == null)
            {
                PFLog.Default.Error(context.AbilityBlueprint, string.Format("Target spellbook is missing: {0}", context.AbilityBlueprint), Array.Empty<object>());
                return;
            }
            if (context.Ability.ParamSpellLevel == null)
            {
                PFLog.Default.Error(context.AbilityBlueprint, string.Format("Target spell level is missing: {0}", context.AbilityBlueprint), Array.Empty<object>());
                return;
            }
            if (context.Ability.ParamSpellLevel.Value > this.SpellLevel && !this.AnySpellLevel)
            {
                PFLog.Default.Error(context.AbilityBlueprint, string.Format("Invalid target spell level {0}: {1}", context.Ability.ParamSpellLevel.Value, context.AbilityBlueprint), Array.Empty<object>());
                return;
            }
            context.Ability.ParamSpellbook.RestoreSpontaneousSlots(context.Ability.ParamSpellLevel.Value, 1);
        }

        public bool IsAbilityRestrictionPassed(AbilityData ability)
        {
            if (ability == null)
            {
                return false;
            }
            Spellbook paramSpellbook = ability.ParamSpellbook;
            int? paramSpellLevel = ability.ParamSpellLevel;
            if (paramSpellbook != null && paramSpellLevel != null)
            {
                if (!this.AnySpellLevel)
                {
                    int? num = paramSpellLevel;
                    int spellLevel = this.SpellLevel;
                    if (num.GetValueOrDefault() > spellLevel & num != null)
                    {
                        return false;
                    }
                }
                if (paramSpellbook.Blueprint.Spontaneous)
                {
                    int spontaneousSlots = paramSpellbook.GetSpontaneousSlots(paramSpellLevel.Value);
                    int spellsPerDay = paramSpellbook.GetSpellsPerDay(paramSpellLevel.Value);
                    return spontaneousSlots < spellsPerDay;
                }
                foreach (SpellSlot spellSlot in paramSpellbook.GetMemorizedSpellSlots(paramSpellLevel.Value))
                {
                    if (!spellSlot.Available)
                    {
                        AbilityData spellShell = spellSlot.SpellShell;
                        SpellSlot paramSpellSlot = ability.ParamSpellSlot;
                        if (spellShell == ((paramSpellSlot != null) ? paramSpellSlot.SpellShell : null))
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            return false;
        }

        public bool CanCreateRestoreSpell(Spellbook spellbook)
        {
            if (spellbook == null)
            {
                return false;
            }
            if (!this.CheckSpellBook)
            {
                return true;
            }
            foreach (BlueprintSpellbookReference blueprintSpellbookReference in this.SpellbooksReference)
            {
                BlueprintSpellbook blueprintSpellbook = (blueprintSpellbookReference != null) ? blueprintSpellbookReference.Get() : null;
                if (blueprintSpellbook && spellbook.Blueprint == blueprintSpellbook)
                {
                    return true;
                }
            }
            return false;
        }

        public string GetAbilityRestrictionUIText()
        {
            return "";
        }

        public bool AnySpellLevel = true;

        [HideIf("AnySpellLevel")]
        public int SpellLevel = 0;

        public bool CheckSpellBook = true;

        public BlueprintSpellbookReference[] SpellbooksReference = 
            [BlueprintTool.GetRef<BlueprintSpellbookReference>(Guids.ArchmageSpellbook)];
    }
}