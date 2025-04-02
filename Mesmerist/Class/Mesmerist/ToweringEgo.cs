using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.EntitySystem.Stats;
using Mesmerist.Utils;
using Kingmaker.Enums;

namespace Mesmerist.Class.Mesmerist
{
    public class ToweringEgo
    {
        private static readonly string FeatName = "ToweringEgo";
        internal const string DisplayName = "ToweringEgo.Name";
        private static readonly string Description = "ToweringEgo.Description";
        public static void Configure()
        {

            FeatureConfigurator.New(FeatName, Guids.ToweringEgo)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.Guidance.Reference.Get().Icon)
                .SetIsClassFeature()
                .AddDerivativeStatBonus(StatType.Charisma, StatType.SaveWill, ModifierDescriptor.None)
                .AddRecalculateOnStatChange(stat: StatType.Charisma)
                .Configure();
        }
    }
}