using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Mesmerist.Utils;

namespace Mesmerist.Class.Mesmerist.Tricks
{
    internal class ConcealingVeil
    {
        public static void Configure()
        {
            CommonTrickHelpers.CreateMasterfulTrick("ConcealingVeil",
                                                    "ConcealingVeil.Name",
                                                    "ConcealingVeil.Description",
                                                    AbilityRefs.InvisibilityGreater.Reference.Get().Icon,
                                                    Guids.ConcealingVeil,
                                                    Guids.ConcealingVeilAbility,
                                                    Guids.ConcealingVeilBuff);

            BuffConfigurator.For(Guids.ConcealingVeilBuff)
                .AddBuffInvisibility(notDispellAfterOffensiveAction: true, stealthBonus: 5)
                .Configure();
        }
    }
}
