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
    public class AddSubjectInitiateTrickTrigger : UnitFactComponentDelegate,
        IInitiatorRulebookHandler<RuleAttackRoll>, IRulebookHandler<RuleAttackRoll>,
        ISubscriber, IInitiatorRulebookSubscriber
    {
        private static readonly Logging.Logger Logger = Logging.GetLogger(nameof(AddSubjectInitiateTrickTrigger));
        public void OnEventAboutToTrigger(RuleAttackRoll evt)
        {
            if (!this.BeforeAttackRoll)
            {
                return;
            }
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
            if (evt.IsFake || this.BeforeAttackRoll)
            {
                return;
            }
            if (this.CheckConditions(evt))
            {
                using (this.DoNotPassAttackRoll ? null : ContextData<ContextAttackData>.Request().Setup(evt, null, 0, 0))
                {
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
                        factContextOwner2.RunActionInContext(this.ActionOnSelf, evt.Initiator);
                        if (RemoveAfterUse) { evt.Initiator.Descriptor.Buffs.RemoveFact(base.Fact); }
                    }
                }
            }
        }
        private bool CheckConditions(RuleAttackRoll evt)
        {
            return (!this.OnlyHit || evt.IsHit) && 
                (!this.CriticalHit || (evt.IsCriticalConfirmed && !evt.FortificationNegatesCriticalHit)) && 
                (!this.OnlyMelee || (evt.Weapon != null && evt.Weapon.Blueprint.IsMelee)) && (!this.NotReach || 
                (evt.Weapon != null && !(evt.Weapon.Blueprint.Type.AttackRange > GameConsts.MinWeaponRange))) && 
                (this.AffectFriendlyTouchSpells || 
                evt.Initiator.IsEnemy(evt.Target) || (evt.Weapon.Blueprint.Type.AttackType != 
                AttackType.Touch && evt.Weapon.Blueprint.Type.AttackType != AttackType.RangedTouch));
        }

        [HideIf("CriticalHit")]
        public bool OnlyHit = true;

        public bool BeforeAttackRoll = false;

        // Token: 0x04008A7E RID: 35454
        public bool CriticalHit;

        // Token: 0x04008A7F RID: 35455
        public bool OnlyMelee;

        // Token: 0x04008A80 RID: 35456
        public bool NotReach;

        // Token: 0x04008A81 RID: 35457
        public bool CheckCategory;

        // Token: 0x04008A84 RID: 35460
        public bool AffectFriendlyTouchSpells;

        // Token: 0x04008A85 RID: 35461
        public ActionList ActionsOnTarget;

        // Token: 0x04008A86 RID: 35462
        public ActionList ActionOnSelf;

        public bool RemoveAfterUse = true;

        // Token: 0x04008A87 RID: 35463
        [InfoBox("Ignore attacker's roll")]
        public bool DoNotPassAttackRoll;
    }
}