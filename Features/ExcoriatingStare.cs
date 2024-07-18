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
    class ExcoriatingStare
    {
        private static readonly string FeatName = "ExcoriatingStare";
        private static readonly string DisplayName = "ExcoriatingStare.Name";
        private static readonly string Description = "ExcoriatingStare.Description";
        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);

        public static void Configure()
        {
            BuffConfigurator.New(FeatName + "Buff", Guids.ExcoriatingStareBuff)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(BuffRefs.Sickened.Reference.Get().Icon)
                .AddContextCalculateAbilityParamsBasedOnClass(Guids.Mesmerist, statType: StatType.Charisma)
                .AddComponent<AddCombatStare>(c => {
                    c.SavingThrow = SavingThrowType.Will;
                    c.CombatStareDebuff = BuffRefs.Sickened.Reference.Get();
                })
                .Configure();

            ActivatableAbilityConfigurator.New(FeatName + "ActivatableAbility", Guids.ExcoriatingStareActivatableAbility)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(BuffRefs.Sickened.Reference.Get().Icon)
                .SetGroup((ActivatableAbilityGroup)((ExtentedActivatableAbilityGroup)1818))
                .SetBuff(Guids.ExcoriatingStareBuff)
                .SetDeactivateImmediately()
                .Configure();

            FeatureConfigurator.New(FeatName, Guids.ExcoriatingStare, [FeatureGroup.CombatFeat, FeatureGroup.Feat])
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIsClassFeature(true)
                .AddFacts(new() { Guids.ExcoriatingStareActivatableAbility })
                .SetReapplyOnLevelUp(false)
                .AddPrerequisiteClassLevel(Guids.Mesmerist, 11)
                .AddPrerequisiteFeature(Guids.PainfulStare)
                .AddRecommendationHasClasses(recommendedClasses: [Guids.Mesmerist])
                .SetRanks(1)
                .Configure();
        }
    }
}