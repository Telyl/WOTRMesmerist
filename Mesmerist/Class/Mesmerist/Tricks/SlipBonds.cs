using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.Utility;
using Mesmerist.Utils;

namespace Mesmerist.Class.Mesmerist.Tricks
{
    internal class SlipBonds
    {
        public static void Configure()
        {
            CommonTrickHelpers.CreateTrick("SlipBonds",
                                           "SlipBonds.Name",
                                           "SlipBonds.Description",
                                           AbilityRefs.ItemBondAbility.Reference.Get().Icon,
                                           Guids.SlipBonds,
                                           Guids.SlipBondsAbility,
                                           Guids.SlipBondsBuff);

            BuffConfigurator.For(Guids.SlipBondsBuff)
                .AddContextStatBonus(StatType.AdditionalCMD, ContextValues.Rank(), ModifierDescriptor.Circumstance)
                .AddContextStatBonus(StatType.AdditionalCMB, ContextValues.Rank(), ModifierDescriptor.Circumstance)
                .AddContextRankConfig(ContextRankConfigs.ClassLevel([Guids.Mesmerist], type: AbilityRankType.Default).WithCustomProgression((11, 2), (12, 6)))
                .Configure();
        }
    }
}
