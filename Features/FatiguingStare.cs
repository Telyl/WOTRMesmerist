using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using Kingmaker.EntitySystem.Stats;
using Mesmerist.Utils;
using CharacterOptionsPlus.Util;
using Kingmaker.Blueprints.Classes;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.ActivatableAbilities;
using static TabletopTweaks.Core.MechanicsChanges.AdditionalActivatableAbilityGroups;
using Mesmerist.NewComponents.AbilitySpecific;

namespace Mesmerist.Features
{
    class FatiguingStare
    {
        private static readonly string FeatName = "FatiguingStare";
        private static readonly string DisplayName = "FatiguingStare.Name";
        private static readonly string Description = "FatiguingStare.Description";
        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);

        public static void Configure()
        {
            BuffConfigurator.New(FeatName + "Buff", Guids.FatiguingStareBuff)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.TouchOfFatigueCast.Reference.Get().Icon)
                .AddComponent<AddCombatStare>(c => {
                    c.SavingThrow = SavingThrowType.Fortitude;
                    c.CombatStareDebuff = BuffRefs.Fatigued.Reference.Get();
                })
                .AddContextCalculateAbilityParamsBasedOnClass(Guids.Mesmerist, statType: StatType.Charisma)
                .Configure();

            ActivatableAbilityConfigurator.New(FeatName + "ActivatableAbility", Guids.FatiguingStareActivatableAbility)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.TouchOfFatigueCast.Reference.Get().Icon)
                .SetGroup((ActivatableAbilityGroup)((ExtentedActivatableAbilityGroup)1818))
                .SetBuff(Guids.FatiguingStareBuff)
                .SetDeactivateImmediately()
                .Configure();

            FeatureConfigurator.New(FeatName, Guids.FatiguingStare, [FeatureGroup.CombatFeat, FeatureGroup.Feat])
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIsClassFeature(true)
                .AddFacts(new() { Guids.FatiguingStareActivatableAbility })
                .SetReapplyOnLevelUp(false)
                .AddPrerequisiteClassLevel(Guids.Mesmerist, 7)
                .AddPrerequisiteFeature(Guids.PainfulStare)
                .AddRecommendationHasClasses(recommendedClasses: [Guids.Mesmerist])
                .SetRanks(1)
                .Configure();
        }
    }
}