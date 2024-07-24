using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using Mesmerist.Utils;
using Kingmaker.Enums;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using BlueprintCore.Utils;
using CharacterOptionsPlus.Util;
using Mesmerist.NewComponents;
using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Conditions.Builder.BasicEx;
using Kingmaker.Designers.EventConditionActionSystem.Evaluators;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Abilities.Components.Base;
using BlueprintCore.Actions.Builder.BasicEx;
using BlueprintCore.Blueprints.CustomConfigurators;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.EntitySystem.Stats;

namespace Mesmerist.Mesmerist
{
    public class ManifoldTrick
    {
        private static readonly string FeatName = "Tricks";
        internal const string DisplayName = "ManifoldTrick.Name";
        private static readonly string Description = "ManifoldTrick.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);

        public static void Configure()
        {

            

            var feat = FeatureConfigurator.New(FeatName + "ManifoldTrick", Guids.ManifoldTrick)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.OverwhelmingPresence.Reference.Get().Icon)
                .SetIsClassFeature(true)
                .SetReapplyOnLevelUp(false)
                .SetRanks(4)
                .Configure();

            FeatureConfigurator.For(feat)
                .AddContextRankConfig(new ContextRankConfig
                {
                    m_Type = AbilityRankType.Default,
                    m_BaseValueType = ContextRankBaseValueType.FeatureRank,
                    m_Feature = feat.ToReference<BlueprintFeatureReference>(),
                    m_Stat = StatType.Unknown,
                    m_Buff = null,
                    m_Progression = ContextRankProgression.AsIs,
                    m_StartLevel = 0,
                    m_StepLevel = 0,
                    m_UseMin = false,
                    m_Min = 0,
                    m_UseMax = false,
                    m_Max = 20,
                    m_ExceptClasses = false,
                    Archetype = null
                })
                .Configure();

        }
    }
}
