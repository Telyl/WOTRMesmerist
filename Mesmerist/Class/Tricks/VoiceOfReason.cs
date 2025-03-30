using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Mesmerist.Utils;

namespace Mesmerist.Class.Tricks
{
    internal class VoiceOfReason
    {
        public static void Configure()
        {
            CommonTrickHelpers.CreateTrick("VoiceOfReason",
                                           "VoiceOfReason.Name",
                                           "VoiceOfReason.Description",
                                           AbilityRefs.Shout.Reference.Get().Icon,
                                           Guids.VoiceOfReason,
                                           Guids.VoiceOfReasonAbility,
                                           Guids.VoiceOfReasonBuff);

            BuffConfigurator.For(Guids.VoiceOfReasonBuff)
                .AddContextStatBonus(StatType.SaveWill, ContextValues.Rank(), ModifierDescriptor.Insight)
                .AddContextRankConfig(ContextRankConfigs.StatBonus(StatType.Charisma))
                .Configure(); 
        }
    }
}
