﻿using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.Enums.Damage;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Components;
using Mesmerist.Utils;
using Mesmerist.NewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UnityModManagerNet.UnityModManager.ModEntry;
using CharacterOptionsPlus.Util;
using BlueprintCore.Actions.Builder.BasicEx;
using Kingmaker.ElementsSystem;
using Kingmaker.Blueprints.Classes;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using Mesmerist.MechanicsChanges;

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
                .AddContextCalculateAbilityParamsBasedOnClass(Guids.Mesmerist, statType: StatType.Charisma)
                .Configure();

            ActivatableAbilityConfigurator.New(FeatName + "ActivatableAbility", Guids.FatiguingStareActivatableAbility)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.TouchOfFatigueCast.Reference.Get().Icon)
                .SetGroup(ExpandedActivatableAbilityGroup.Stares)
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