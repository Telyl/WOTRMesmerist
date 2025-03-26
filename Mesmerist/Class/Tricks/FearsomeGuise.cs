using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Mechanics.Components;
using Mesmerist.Utils;

namespace Mesmerist.Class.Tricks
{
    internal class FearsomeGuise
    {
        public static void Configure()
        {
            CommonTrickHelpers.CreateTrick("FearsomeGuise",
                                           "FearsomeGuise.Name",
                                           "FearsomeGuise.Description",
                                           AbilityRefs.PersuasionUseAbility.Reference.Get().Icon,
                                           Guids.FearsomeGuise,
                                           Guids.FearsomeGuiseAbility,
                                           Guids.FearsomeGuiseBuff);

            BuffConfigurator.For(Guids.FearsomeGuiseBuff)
                .AddComponent<AddInitiatorAttackRollTrigger>(c =>
                {
                    c.Action = ActionsBuilder.New().CastSpell(AbilityRefs.PersuasionUseAbility.Reference.Get(), false, false, true).Build();
                    c.OnlyHit = true;
                })
                .Configure();
        }
    }
}
