﻿using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using Kingmaker.EntitySystem.Stats;
using Mesmerist.Utils;
using CharacterOptionsPlus.Util;
using Kingmaker.Blueprints.Classes;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.ActivatableAbilities;
using static TabletopTweaks.Core.MechanicsChanges.AdditionalActivatableAbilityGroups;

namespace Mesmerist.Features
{
    class DemoralizingStare
    {
        private static readonly string FeatName = "DemoralizingStare";
        private static readonly string DisplayName = "DemoralizingStare.Name";
        private static readonly string Description = "DemoralizingStare.Description";
        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);

        public static void Configure()
        {
            BuffConfigurator.New(FeatName + "Buff", Guids.DemoralizingStareBuff)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.PersuasionUseAbility.Reference.Get().Icon)
                .AddContextCalculateAbilityParamsBasedOnClass(Guids.Mesmerist, statType: StatType.Charisma)
                .Configure();

            ActivatableAbilityConfigurator.New(FeatName + "ActivatableAbility", Guids.DemoralizingStareActivatableAbility)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.PersuasionUseAbility.Reference.Get().Icon)
                .SetGroup((ActivatableAbilityGroup)((ExtentedActivatableAbilityGroup)1818))
                .SetBuff(Guids.DemoralizingStareBuff)
                .SetDeactivateImmediately()
                .Configure();

            FeatureConfigurator.New(FeatName, Guids.DemoralizingStare, [FeatureGroup.CombatFeat, FeatureGroup.Feat])
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIsClassFeature(true)
                .AddFacts(new() { Guids.DemoralizingStareActivatableAbility })
                .SetReapplyOnLevelUp(false)
                .AddPrerequisiteClassLevel(Guids.Mesmerist, 7)
                .AddPrerequisiteFeature(Guids.PainfulStare)
                .AddRecommendationHasClasses(recommendedClasses: [Guids.Mesmerist])
                .SetRanks(1)
                .Configure();
        }
    }
}