using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Mesmerist.Utils;

namespace Mesmerist.Class.Mesmerist.Tricks
{
    internal class ForcedHope
    {
        public static void Configure()
        {
            CommonTrickHelpers.CreateMasterfulTrick("ForcedHope",
                                                    "ForcedHope.Name",
                                                    "ForcedHope.Description",
                                                    AbilityRefs.GoodHope.Reference.Get().Icon,
                                                    Guids.ForcedHope,
                                                    Guids.ForcedHopeAbility,
                                                    Guids.ForcedHopeBuff);

            BuffConfigurator.For(Guids.ForcedHopeBuff)
                .AddStatBonus(ModifierDescriptor.Morale, false, StatType.AdditionalAttackBonus, 4)
                .AddStatBonus(ModifierDescriptor.Morale, false, StatType.AdditionalDamage, 4)
                .Configure();
        }
    }
}
