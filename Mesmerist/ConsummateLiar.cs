using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Classes;
using Kingmaker.EntitySystem.Stats;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using Mesmerist.Utils;
using static UnityModManagerNet.UnityModManager.ModEntry;
using System;
using Kingmaker.Enums;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints.Classes.Prerequisites;
using CharacterOptionsPlus.Util;

namespace Mesmerist.Mesmerist
{
    public class ConsummateLiar
    {
        private static readonly string FeatName = "ConsummateLiar";
        internal const string DisplayName = "ConsummateLiar.Name";
        private static readonly string Description = "ConsummateLiar.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);

        public static void Configure()
        {

            //TODO: Change CharacterLevel to ClassLevel(Mesmerist)
            BlueprintFeature consummateLiar = FeatureConfigurator.New(FeatName, Guids.ConsummateLiar)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(FeatureRefs.Deceitful.Reference.Get().Icon)
                .SetIsClassFeature()
                .AddContextStatBonus(stat: StatType.CheckBluff, value: new Kingmaker.UnitLogic.Mechanics.ContextValue()
                {
                    ValueType = Kingmaker.UnitLogic.Mechanics.ContextValueType.Rank,
                    Value = 0,
                    ValueRank = AbilityRankType.Default,
                    ValueShared = Kingmaker.UnitLogic.Abilities.AbilitySharedValue.Damage,
                    m_AbilityParameter = Kingmaker.UnitLogic.Mechanics.AbilityParameterType.Level
                })
                .AddContextRankConfig(ContextRankConfigs.CharacterLevel().WithDiv2Progression())
                .SetIsPrerequisiteFor([FeatureRefs.Feint.Reference.Get(), FeatureRefs.FinalFeint.Reference.Get()])
                .Configure();

            FeatureConfigurator.For(FeatureRefs.Feint)
                .RemoveComponents(c => c is PrerequisiteFeature)
                .RemoveComponents(c => c is PrerequisiteStatValue)
                .AddPrerequisiteFeature(FeatureRefs.CombatExpertiseFeature.Reference.Get(), false, Prerequisite.GroupType.Any)
                .AddPrerequisiteFeature(consummateLiar, false, Kingmaker.Blueprints.Classes.Prerequisites.Prerequisite.GroupType.Any)
                .AddPrerequisiteFeature(FeatureRefs.KineticWarriorFeature.Reference.Get(), false, Prerequisite.GroupType.Any)
                .Configure();

            FeatureConfigurator.For(FeatureRefs.FinalFeint)
                .RemoveComponents(c => c is PrerequisiteFeature)
                .RemoveComponents(c => c is PrerequisiteStatValue)
                .RemoveComponents(c => c is PrerequisiteFeaturesFromList)
                .AddPrerequisiteFeature(FeatureRefs.CombatExpertiseFeature.Reference.Get(), false, Prerequisite.GroupType.Any)
                .AddPrerequisiteFeature(consummateLiar, false, Kingmaker.Blueprints.Classes.Prerequisites.Prerequisite.GroupType.Any)
                .AddPrerequisiteFeature(FeatureRefs.KineticWarriorFeature.Reference.Get(), false, Prerequisite.GroupType.Any)
                .AddPrerequisiteFeature(FeatureRefs.Feint.Reference.Get())
                .Configure();
        }
    }
}
