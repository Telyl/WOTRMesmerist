using Kingmaker.Blueprints;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.UnitLogic;

namespace Mesmerist.NewContexts
{
    [TypeId("efd42e9514d047899c797a5c2ca5f09a")]
    public class ContextActionOnEnemiesWithFact : ContextAction
    {
        public override string GetCaption()
        {
            return "For each enemy";
        }

        // Token: 0x0600D2D3 RID: 53971 RVA: 0x0036CF70 File Offset: 0x0036B170
        public override void RunAction()
        {
            // Get the target of the enemy
            UnitEntityData target = null;
            UnitEntityData maybeCaster = base.Context.MaybeCaster;
            foreach( UnitGroupMemory.UnitInfo unitInfo in  maybeCaster.Memory.Enemies)
            {
                if (unitInfo != null && unitInfo.Unit.HasFact(FactToCheck))
                {
                    target = unitInfo.Unit;
                }
            };
            
            if (target == null) return;

            using (base.Context.GetDataScope(target))
            {
                this.Action.Run();
            }
        }
        // Token: 0x04008CBB RID: 36027
        public ActionList Action;
        public BlueprintUnitFactReference FactToCheck;
    }
}