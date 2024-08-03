using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Mesmerist.Utils;
using Kingmaker.Enums;
using BlueprintCore.Utils.Types;
using CharacterOptionsPlus.Util;

namespace Mesmerist.Medium.Archmage
{
    public class ArchmageIntermediate
    {
        private static readonly string FeatName = "ArchmageIntermediate";
        internal const string DisplayName = "ArchmageIntermediate.Name";
        private static readonly string Description = "ArchmageIntermediate.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);

        public static void Configure()
        {
            FeatureConfigurator.New(FeatName, Guids.ArchmageIntermediate)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.BloodlineArcaneItemBondAbility.Reference.Get().Icon)
                .AddIncreaseCasterLevel(ModifierDescriptor.UntypedStackable, value: ContextValues.Rank())
                .AddIncreaseAllSpellsDC(ModifierDescriptor.UntypedStackable, spellsOnly: true, value: ContextValues.Rank())
                .AddContextRankConfig(ContextRankConfigs.FeatureRank(Guids.SpiritBonus))
                .Configure();
        }
    }
}
