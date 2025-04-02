using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using Mesmerist.Utils;

namespace Mesmerist.Class.Mesmerist.Tricks
{
    internal class FalseFlanker
    {
        public static void Configure()
        {

            CommonTrickHelpers.CreateTrick("FalseFlanker",
                                          "FalseFlanker.Name",
                                          "FalseFlanker.Description",
                                          AbilityRefs.PerfectForm.Reference.Get().Icon,
                                          Guids.FalseFlanker,
                                          Guids.FalseFlankerAbility,
                                          Guids.FalseFlankerBuff);

            BuffConfigurator.For(Guids.FalseFlankerBuff)
                .AddFlankedAttackBonus(2, Kingmaker.Enums.ModifierDescriptor.UntypedStackable)
                .Configure();
        }
    }
}
