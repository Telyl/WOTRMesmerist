using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using Mesmerist.Utils;
using Kingmaker.Blueprints.Classes;
using Kingmaker.UnitLogic.ActivatableAbilities;
using static TabletopTweaks.Core.MechanicsChanges.AdditionalActivatableAbilityGroups;

namespace Mesmerist.Class.Features
{
    class CompoundedPain
    {
        private static readonly string FeatName = "CompoundedPain";
        private static readonly string DisplayName = "CompoundedPain.Name";
        private static readonly string Description = "CompoundedPain.Description";
        public static void Configure()
        {
            // TODO: This does not work. TTT-Core's extented activatable ability group fails to increase the group size by +1.
            FeatureConfigurator.New(FeatName, Guids.CompoundedPain, [FeatureGroup.CombatFeat, FeatureGroup.Feat])
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddIncreaseActivatableAbilityGroupSize((ActivatableAbilityGroup)((ExtentedActivatableAbilityGroup)1818))
                .SetIsClassFeature(true)
                .SetReapplyOnLevelUp(false)
                .AddPrerequisiteClassLevel(Guids.Mesmerist, 13)
                .AddPrerequisiteFeature(Guids.PainfulStare)
                .AddRecommendationHasClasses(recommendedClasses: [Guids.Mesmerist])
                .SetRanks(1)
                .Configure();
        }
    }
}