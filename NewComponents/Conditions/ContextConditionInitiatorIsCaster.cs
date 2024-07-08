using BlueprintCore.Blueprints.References;
using CharacterOptionsPlus.Util;
using Kingmaker;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Mechanics.Conditions;
using System;
using static UnityModManagerNet.UnityModManager.ModEntry;

namespace Mesmerist.NewComponents.Conditions
{
    [TypeId("e7c164df-df70-4b0b-ace3-9ac3616ada67")]
    internal class ContextConditionInitiatorIsCaster : ContextCondition
    {
        private static readonly Logging.Logger Logger = Logging.GetLogger(nameof(ContextConditionInitiatorIsCaster));

        internal WeaponCategory Category;

        public override bool CheckCondition()
        {
            try
            {
                var caster = Context.MaybeCaster;
                if (caster == null) { return false; }
                Logger.Log(caster.ToString());

                var target = Target.Unit;
                if (target == null) { return false; }
                Logger.Log(target.ToString());

                return true;
            }
            catch (Exception e)
            {
                Logger.LogException("InitiatorIsCaster.CheckCondition", e);
            }
            return false;
        }

        public override string GetConditionCaption()
        {
            return "Checks for if initiator is the caster";
        }
    }
}