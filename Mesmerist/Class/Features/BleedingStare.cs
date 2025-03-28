using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Mesmerist.Utils;
using Kingmaker.Blueprints.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using static TabletopTweaks.Core.MechanicsChanges.AdditionalActivatableAbilityGroups;
using Kingmaker.UnitLogic.ActivatableAbilities;

namespace Mesmerist.Class.Features
{
    class BleedingStare
    {
        private static readonly string FeatName = "BleedingStare";
        private static readonly string DisplayName = "BleedingStare.Name";
        private static readonly string Description = "BleedingStare.Description";

        public static object Value { get; private set; }

        public static void Configure()
        {
            BuffConfigurator.New(FeatName + "BuffEffect", Guids.BleedingStareBuffEffect)
                .AddUniqueBuff()
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(BuffRefs.Bleed1d6Buff.Reference.Get().Icon)
                .Configure();

            BuffConfigurator.New(FeatName + "Buff", Guids.BleedingStareBuff)
                .AddUniqueBuff()
                .SetFlags(BlueprintBuff.Flags.HiddenInUi)
                .Configure();

            ActivatableAbilityConfigurator.New(FeatName + "ActivatableAbility", Guids.BleedingStareActivatableAbility)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.FalseLifeGreater.Reference.Get().Icon)
                .SetGroup((ActivatableAbilityGroup)(ExtentedActivatableAbilityGroup)1818)
                .SetBuff(Guids.BleedingStareBuff)
                .SetDeactivateImmediately()
                .Configure();

            FeatureConfigurator.New(FeatName, Guids.BleedingStare, [FeatureGroup.CombatFeat, FeatureGroup.Feat])
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIsClassFeature(true)
                .SetReapplyOnLevelUp(false)
                .AddPrerequisiteClassLevel(Guids.Mesmerist, 5)
                .AddPrerequisiteFeature(Guids.PainfulStare)
                .AddRecommendationHasClasses(recommendedClasses: [Guids.Mesmerist])
                .SetRanks(1)
                .Configure();
        }
    }
}