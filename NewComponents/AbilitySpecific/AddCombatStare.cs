using BlueprintCore.Utils;
using CharacterOptionsPlus.Util;
using Kingmaker;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UnitLogic;
using Mesmerist.Utils;
using System;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums.Damage;
using BlueprintCore.Utils.Types;
using Kingmaker.UnitLogic.Mechanics.Components;
using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Conditions.Builder.BasicEx;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using Kingmaker.Utility;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Mesmerist.Features;
using Mesmerist.Mesmerist;
using Kingmaker.Blueprints.Classes;
using static HarmonyLib.Code;

namespace Mesmerist.NewComponents.AbilitySpecific
{
    [AllowMultipleComponents]
    [TypeId("fe4eb0615e264792b1d3030a9c010277")]
    public class AddCombatStare : EntityFactComponentDelegate,
        IGlobalRulebookHandler<RuleDealDamage>, IRulebookHandler<RuleDealDamage>, IGlobalRulebookSubscriber,
        ISubscriber
    {
        private static readonly Logging.Logger Logger = Logging.GetLogger(nameof(AddCombatStare));
        public void OnEventAboutToTrigger(RuleDealDamage evt)
        {
        }

        public void OnEventDidTrigger(RuleDealDamage evt)
        {
            if (evt.Reason.Fact.Blueprint != BlueprintTool.Get<BlueprintFeature>(Guids.PainfulStare)) { return; }

            IFactContextOwner factContextOwner = Fact as IFactContextOwner;
            if (factContextOwner == null)
            {
                return;
            }

            ActionList Actions = ActionsBuilder.New().SavingThrow(SavingThrow,
                    onResult: ActionsBuilder.New().ConditionalSaved(failed: ActionsBuilder.New().ApplyBuff(CombatStareDebuff, ContextDuration.Fixed(1)))).Build();
            factContextOwner.RunActionInContext(Actions, evt.Target);
        }

        public BlueprintBuff CombatStareDebuff;
        public SavingThrowType SavingThrow;
    }
}