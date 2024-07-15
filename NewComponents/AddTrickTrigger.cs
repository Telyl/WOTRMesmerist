using CharacterOptionsPlus.Util;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Ecnchantments;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem;
using Kingmaker.Enums;
using Kingmaker.Items;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.UnitLogic.Mechanics.ContextData;
using Kingmaker.Utility;
using System.Runtime.Remoting.Contexts;
using System.Security.Policy;
using static Kingmaker.Blueprints.Area.FactHolder;
using static Kingmaker.UI.CanvasScalerWorkaround;

namespace Mesmerist.NewComponents
{
    [TypeId("db85a277dbcb4237b6e4371ace0c44e6")]
    public class AddTrickTrigger : UnitFactComponentDelegate,
        IInitiatorRulebookHandler<RuleAttackRoll>, IRulebookHandler<RuleAttackRoll>,
        IInitiatorRulebookHandler<RuleSavingThrow>, IRulebookHandler<RuleSavingThrow>,
        ISubscriber, IInitiatorRulebookSubscriber
    {
        private static readonly Logging.Logger Logger = Logging.GetLogger(nameof(AddTrickTrigger));
        public void OnEventAboutToTrigger(RuleAttackRoll evt)
        {
            Logger.Log("AddTrickTrigger - EventAboutToTrigger - RuleAttackRoll");
            if (!this.BeforeAttackRoll)
            {
                return;
            }
            Logger.Log("AddTrickTrigger - EventAboutToTrigger - RuleAttackRoll - BeforeCheckConditions");
            using (BeforeAttackRoll ? null : ContextData<ContextAttackData>.Request().Setup(evt, null, 0, 0))
            {
                IFactContextOwner factContextOwner = base.Fact as IFactContextOwner;
                if (factContextOwner != null)
                {
                    Logger.Log("actions on target of attack:" + evt.Target.ToString());
                    factContextOwner.RunActionInContext(this.ActionsOnTarget, evt.Target);
                    if (RemoveAfterUse) { evt.Initiator.Descriptor.Buffs.RemoveFact(base.Fact); }
                }
            }
        }
        public void OnEventDidTrigger(RuleAttackRoll evt)
        {
            Logger.Log("AddTrickTrigger - EventDidTrigger - RuleAttackRoll");
            if (evt.IsFake || this.BeforeAttackRoll)
            {
                return;
            }
            Logger.Log("AddTrickTrigger - EventDidTrigger - RuleAttackRoll - BeforeCheckConditions");
            if (this.CheckConditions(evt))
            {
                using (this.DoNotPassAttackRoll ? null : ContextData<ContextAttackData>.Request().Setup(evt, null, 0, 0))
                {
                    Logger.Log("AddTrickTrigger - EventDidTrigger - RuleAttackRoll - Actions");
                    IFactContextOwner factContextOwner = base.Fact as IFactContextOwner;
                    if (factContextOwner != null)
                    {
                        Logger.Log("actions on target of attack:" + evt.Target.ToString());
                        factContextOwner.RunActionInContext(this.ActionsOnTarget, evt.Target);
                        if (RemoveAfterUse) { evt.Initiator.Descriptor.Buffs.RemoveFact(base.Fact); }
                        
                    }
                    IFactContextOwner factContextOwner2 = base.Fact as IFactContextOwner;
                    if (factContextOwner2 != null)
                    {
                        Logger.Log("Actions on self:" + evt.Initiator.ToString());
                        factContextOwner2.RunActionInContext(this.ActionsOnSelf, evt.Initiator);
                        if (RemoveAfterUse) { evt.Initiator.Descriptor.Buffs.RemoveFact(base.Fact); }
                    }
                }
            }
        }
        private bool CheckConditions(RuleAttackRoll evt)
        {
            return (!this.OnlyHit || evt.IsHit) && 
                (evt.Initiator.IsEnemy(evt.Target));
        }

        public void OnEventAboutToTrigger(RuleSavingThrow evt)
        {
            Logger.Log("AddTrickTrigger - EventAboutToTrigger - RuleSavingThrow");
        }

        public void OnEventDidTrigger(RuleSavingThrow evt)
        {
            Logger.Log("AddTrickTrigger - EventDidTrigger - RuleSavingThrow");
        }
        public bool OnlyHit = true;
        public bool BeforeAttackRoll = false;
        public ActionList ActionsOnTarget;
        public ActionList ActionsOnSelf;
        public bool RemoveAfterUse = true;
        public bool DoNotPassAttackRoll;

    }
}