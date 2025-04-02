using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Mesmerist.Utils;

namespace Mesmerist.Class.Mesmerist.Tricks
{
    internal class LinkedReaction
    {
        public static void Configure()
        {
            CommonTrickHelpers.CreateTrick("LinkedReaction",
                                           "LinkedReaction.Name",
                                           "LinkedReaction.Description",
                                           AbilityRefs.OracleRevelationLifeLinkAbility.Reference.Get().Icon,
                                           Guids.LinkedReaction,
                                           Guids.LinkedReactionAbility,
                                           Guids.LinkedReactionBuff);

            BuffConfigurator.For(Guids.LinkedReactionBuff)
                .AddContextStatBonus(StatType.Initiative, ContextValues.Rank(), ModifierDescriptor.Morale)
                .AddContextRankConfig(ContextRankConfigs.StatBonus(StatType.Charisma))
                .Configure();
        }
    }
}
