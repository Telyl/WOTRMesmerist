using System;
using CharacterOptionsPlus.Util;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.Utility;
using Microsoft.Build.Utilities;

namespace Mesmerist.NewComponents
{
    // Token: 0x02001E23 RID: 7715
    [TypeId("d9824f4a3f7a4d0a94c55f8c1ce1b729")]
    public class AddInitiatorSavingThrowTriggerMesmerist : UnitFactComponentDelegate, IInitiatorRulebookHandler<RuleSavingThrow>, IRulebookHandler<RuleSavingThrow>, ISubscriber, IInitiatorRulebookSubscriber
    {
        private static readonly Logging.Logger Logger = Logging.GetLogger(nameof(AddInitiatorSavingThrowTriggerMesmerist));
        public void OnEventAboutToTrigger(RuleSavingThrow evt)
        {
        }

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
                        if (ActOnInitiator)
                        {
                            factContextOwner.RunActionInContext(this.ActionsOnInitiator, evt.Reason.Context.MaybeCaster);
                        }
                    }
                }
            }
        }

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

        public bool ActOnInitiator = false;

        public ActionList ActionsOnInitiator;

        // Token: 0x04008A55 RID: 35413
        [ShowIf("SpecificSave")]
        [InfoBox("Don't use Unknown - will not work on any throw")]
        public SavingThrowType ChooseSave = SavingThrowType.Fortitude;

        // Token: 0x04008A56 RID: 35414
        public ActionList Action;
    }
}
