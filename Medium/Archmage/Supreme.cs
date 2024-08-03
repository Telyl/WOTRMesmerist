using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Mesmerist.Utils;
using Kingmaker.Enums;
using BlueprintCore.Utils.Types;
using CharacterOptionsPlus.Util;

namespace Mesmerist.Medium.Archmage
{
    public class ArchmageSupreme
    {
        private static readonly string FeatName = "ArchmageSupreme";
        internal const string DisplayName = "ArchmageSupreme.Name";
        private static readonly string Description = "ArchmageSupreme.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);

        public static void Configure()
        {
            FeatureConfigurator.New(FeatName, Guids.ArchmageSupreme)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.BloodlineArcaneItemBondAbility.Reference.Get().Icon)
                .AddPromoteSpellDices(1, minDice: Kingmaker.RuleSystem.DiceType.D6)
                .AddIncreaseCasterLevel(ModifierDescriptor.UntypedStackable, value: ContextValues.Rank())
                .AddIncreaseAllSpellsDC(ModifierDescriptor.UntypedStackable, spellsOnly: true, value: ContextValues.Rank())
                .AddContextRankConfig(ContextRankConfigs.FeatureRank(Guids.SpiritBonus))
                .Configure();
        }
    }
}
