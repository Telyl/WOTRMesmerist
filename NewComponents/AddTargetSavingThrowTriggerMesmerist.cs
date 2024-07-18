using System;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.Utility;

namespace Mesmerist.NewComponents
{
    // Token: 0x02001E23 RID: 7715
    [TypeId("89f15541405c410e9a42869bdc3294cd")]
    public class AddTargetSavingThrowTriggerMesmerist : UnitFactComponentDelegate, ITargetRulebookHandler<RuleSavingThrow>,
        IRulebookHandler<RuleSavingThrow>, ISubscriber, ITargetRulebookSubscriber
    {
        // Token: 0x0600D025 RID: 53285 RVA: 0x0035FCC5 File Offset: 0x0035DEC5
        public void OnEventAboutToTrigger(RuleSavingThrow evt)
        {
        }

        // Token: 0x0600D026 RID: 53286 RVA: 0x0035FCC8 File Offset: 0x0035DEC8
        public void OnEventDidTrigger(RuleSavingThrow evt)
        {
            if (this.CheckConditions(evt) && base.Fact.MaybeContext != null)
            {
                MechanicsContext maybeContext = base.Fact.MaybeContext;
                using ((maybeContext != null) ? maybeContext.GetDataScope(base.Owner) : null)
                {
                    IFactContextOwner factContextOwner = base.Fact as IFactContextOwner;
                    if (factContextOwner != null)
                    {
                        factContextOwner.RunActionInContext(this.Action, base.Owner);
                    }
                }
            }
        }

        // Token: 0x0600D027 RID: 53287 RVA: 0x0035FD54 File Offset: 0x0035DF54
        private bool CheckConditions(RuleSavingThrow evt)
        {
            return (!this.OnlyPass || evt.IsPassed) && (!this.OnlyFail || !evt.IsPassed) && (!this.SpecificSave || this.ChooseSave == evt.Type);
        }

        // Token: 0x04008A52 RID: 35410
        public bool OnlyPass;

        // Token: 0x04008A53 RID: 35411
        public bool OnlyFail;

        // Token: 0x04008A54 RID: 35412
        public bool SpecificSave;

        // Token: 0x04008A55 RID: 35413
        [ShowIf("SpecificSave")]
        [InfoBox("Don't use Unknown - will not work on any throw")]
        public SavingThrowType ChooseSave = SavingThrowType.Will;

        // Token: 0x04008A56 RID: 35414
        public ActionList Action;
    }
}
