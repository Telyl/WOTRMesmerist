using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Enums;
using Mesmerist.Utils;
using Kingmaker.EntitySystem.Stats;

namespace Mesmerist.Class
{
    internal class ConsummateLiar
    {
        private static readonly string FeatName = "ConsummateLiar";
        internal const string DisplayName = "ConsummateLiar.Name";
        private static readonly string Description = "ConsummateLiar.Description";

        public static void Configure()
        {
            BlueprintFeature consummateLiar = FeatureConfigurator.New(FeatName, Guids.ConsummateLiar)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(FeatureRefs.Deceitful.Reference.Get().Icon)
                .SetIsClassFeature()
                .AddReplaceStatForPrerequisites(StatType.Charisma, StatType.Intelligence)
                .AddContextStatBonus(stat: StatType.CheckBluff, value: new Kingmaker.UnitLogic.Mechanics.ContextValue()
                {
                    ValueType = Kingmaker.UnitLogic.Mechanics.ContextValueType.Rank,
                    Value = 0,
                    ValueRank = AbilityRankType.Default,
                    ValueShared = Kingmaker.UnitLogic.Abilities.AbilitySharedValue.Damage,
                    m_AbilityParameter = Kingmaker.UnitLogic.Mechanics.AbilityParameterType.Level
                })
                .AddContextRankConfig(ContextRankConfigs.ClassLevel([Guids.Mesmerist]).WithDiv2Progression())
                .SetIsPrerequisiteFor([FeatureRefs.Feint.Reference.Get(), FeatureRefs.FinalFeint.Reference.Get()])
                .Configure();

            FeatureConfigurator.For(FeatureRefs.Feint)
                .RemoveComponents(c => c is PrerequisiteFeature)
                .AddPrerequisiteFeature(FeatureRefs.CombatExpertiseFeature.Reference.Get(), false, Prerequisite.GroupType.Any)
                .AddPrerequisiteFeature(consummateLiar, false, Kingmaker.Blueprints.Classes.Prerequisites.Prerequisite.GroupType.Any)
                .AddPrerequisiteFeature(FeatureRefs.KineticWarriorFeature.Reference.Get(), false, Prerequisite.GroupType.Any)
                .Configure();

            FeatureConfigurator.For(FeatureRefs.FinalFeint)
                .RemoveComponents(c => c is PrerequisiteFeature)
                .AddPrerequisiteFeature(FeatureRefs.CombatExpertiseFeature.Reference.Get(), false, Prerequisite.GroupType.Any)
                .AddPrerequisiteFeature(consummateLiar, false, Kingmaker.Blueprints.Classes.Prerequisites.Prerequisite.GroupType.Any)
                .AddPrerequisiteFeature(FeatureRefs.KineticWarriorFeature.Reference.Get(), false, Prerequisite.GroupType.Any)
                .AddPrerequisiteFeature(FeatureRefs.Feint.Reference.Get())
                .Configure();
        }
    }
}
