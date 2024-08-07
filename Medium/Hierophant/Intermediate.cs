using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Mesmerist.Utils;
using Kingmaker.Enums;
using BlueprintCore.Utils.Types;
using CharacterOptionsPlus.Util;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators;
using Kingmaker.Blueprints;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.UnitLogic.Abilities.Components;

namespace Mesmerist.Medium.Hierophant
{
    public class HierophantIntermediate
    {
        private static readonly string FeatName = "HierophantIntermediate";
        internal const string DisplayName = "HierophantIntermediate.Name";
        private static readonly string Description = "HierophantIntermediate.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);

        public static void Configure()
        {
            // The resource for our channel energy, because we're fancy.
            var resource = AbilityResourceConfigurator.New(FeatName + "Resource", Guids.HierophantIntermediateResource)
                .SetMaxAmount(new BlueprintAbilityResource.Amount
                {
                    BaseValue = 1,
                    IncreasedByLevel = false,
                    IncreasedByLevelStartPlusDivStep = false,
                    StartingLevel = 0,
                    StartingIncrease = 0,
                    LevelStep = 0,
                    PerStepIncrease = 0,
                    MinClassLevelIncrease = 0,
                    IncreasedByStat = true,
                    ResourceBonusStat = StatType.Charisma
                })
                .SetMax(10)
                .SetUseMax(false)
                .Configure();


            var posability = AbilityConfigurator.New(FeatName + "PositiveHeal", Guids.HierophantIntermediatePositiveHeal)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddAbilityResourceLogic(amount: 1, requiredResource: resource, isSpendResource: true, costIsCustom: false)
                .CopyFrom(AbilityRefs.ChannelEnergy, c => c is not (ContextRankConfig or AbilityResourceLogic))
                .AddContextRankConfig(ContextRankConfigs.ClassLevel(new string[] { Guids.Medium }, type: default, max: 20, min: 0).WithDiv2Progression())
                .AddContextRankConfig(ContextRankConfigs.CustomProperty(type: AbilityRankType.DamageBonus, property: UnitPropertyRefs.MythicChannelProperty.ToString(), max: 20, min: 0))
                .Configure();

            var posharmability = AbilityConfigurator.New(FeatName + "PositiveHarm", Guids.HierophantIntermediatePositiveHarm)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddAbilityResourceLogic(amount: 1, requiredResource: resource, isSpendResource: true, costIsCustom: false)
                .CopyFrom(AbilityRefs.ChannelPositiveHarm, c => c is not (ContextRankConfig or AbilityResourceLogic))
                .AddContextRankConfig(ContextRankConfigs.ClassLevel(new string[] { Guids.Medium }, type: default, max: 20, min: 0).WithDiv2Progression())
                .AddContextRankConfig(ContextRankConfigs.CustomProperty(type: AbilityRankType.DamageBonus, property: UnitPropertyRefs.MythicChannelProperty.ToString(), max: 20, min: 0))
                .Configure();

            var negability = AbilityConfigurator.New(FeatName + "NegativeHarm", Guids.HierophantIntermediateNegativeHarm)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddAbilityResourceLogic(amount: 1, requiredResource: resource, isSpendResource: true, costIsCustom: false)
                .CopyFrom(AbilityRefs.ChannelNegativeEnergy, c => c is not (ContextRankConfig or AbilityResourceLogic))
                .AddContextRankConfig(ContextRankConfigs.ClassLevel(new string[] { Guids.Medium }, type: default, max: 20, min: 0).WithDiv2Progression())
                .AddContextRankConfig(ContextRankConfigs.CustomProperty(type: AbilityRankType.DamageBonus, property: UnitPropertyRefs.MythicChannelProperty.ToString(), max: 20, min: 0))
                .Configure();

            var neghealability = AbilityConfigurator.New(FeatName + "NegativeHeal", Guids.HierophantIntermediateNegativeHeal)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddAbilityResourceLogic(amount: 1, requiredResource: resource, isSpendResource: true, costIsCustom: false)
                .CopyFrom(AbilityRefs.ChannelNegativeHeal, c => c is not (ContextRankConfig or AbilityResourceLogic))
                .AddContextRankConfig(ContextRankConfigs.ClassLevel(new string[] { Guids.Medium }, type: default, max: 20, min: 0).WithDiv2Progression())
                .AddContextRankConfig(ContextRankConfigs.CustomProperty(type: AbilityRankType.DamageBonus, property: UnitPropertyRefs.MythicChannelProperty.ToString(), max: 20, min: 0))
                .Configure();

            FeatureConfigurator.New(FeatName, Guids.HierophantIntermediate)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddAbilityResources(resource: resource, restoreAmount: true, useThisAsResource: false)
                .AddToIsPrerequisiteFor(FeatureRefs.SelectiveChannel.Reference.Get(), FeatureRefs.MythicChannelMythicFeat.Reference.Get())
                .AddSpellKnownTemporary(Guids.Medium, 1, true, AbilityRefs.CureLightWounds.Reference.Get())
                .AddSpellKnownTemporary(Guids.Medium, 1, true, AbilityRefs.InflictLightWounds.Reference.Get())
                .AddSpellKnownTemporary(Guids.Medium, 2, true, AbilityRefs.CureModerateWounds.Reference.Get())
                .AddSpellKnownTemporary(Guids.Medium, 2, true, AbilityRefs.InflictModerateWounds.Reference.Get())
                .AddSpellKnownTemporary(Guids.Medium, 3, true, AbilityRefs.CureSeriousWounds.Reference.Get())
                .AddSpellKnownTemporary(Guids.Medium, 3, true, AbilityRefs.InflictSeriousWounds.Reference.Get())
                .AddSpellKnownTemporary(Guids.Medium, 4, true, AbilityRefs.CureCriticalWounds.Reference.Get())
                .AddSpellKnownTemporary(Guids.Medium, 4, true, AbilityRefs.InflictCriticalWounds.Reference.Get())
                .AddFacts(new() { posability, posharmability, negability, neghealability })
                .Configure();


            // We want the player to be able to select this regardless of if they have the Hierophant channeled or not.
            FeatureConfigurator.For(FeatureRefs.SelectiveChannel)
                .AddPrerequisiteFeature(Guids.Spirit, group: Kingmaker.Blueprints.Classes.Prerequisites.Prerequisite.GroupType.Any)
                .Configure();
        }
    }
}
