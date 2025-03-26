using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.Designers.Mechanics.Buffs;
using Kingmaker.UnitLogic.Mechanics.Components;
using Mesmerist.Utils;

namespace Mesmerist.Class.Tricks
{
    internal class PsychosomaticSurge
    {
        public static void Configure()
        {

            CommonTrickHelpers.CreateTrick("PsychosomaticSurge",
                                          "PsychosomaticSurge.Name",
                                          "PsychosomaticSurge.Description",
                                          AbilityRefs.FalseLife.Reference.Get().Icon,
                                          Guids.PsychosomaticSurge,
                                          Guids.PsychosomaticSurgeAbility,
                                          Guids.PsychosomaticSurgeBuff);

            BuffConfigurator.For(Guids.PsychosomaticSurgeBuff)
                .CopyFrom(BuffRefs.FalseLifeBuff.Reference.Get(), typeof(TemporaryHitPointsFromAbilityValue))
                .CopyFrom(BuffRefs.FalseLifeBuff.Reference.Get(), typeof(ContextRankConfigs))
                .CopyFrom(BuffRefs.FalseLifeBuff.Reference.Get(), typeof(ContextCalculateSharedValue))
                .Configure();
        }
    }
}
