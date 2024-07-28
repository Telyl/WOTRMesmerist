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
using Kingmaker.Blueprints;
using Kingmaker.UnitLogic.Mechanics.Components;

namespace Mesmerist.Mesmerist.VexingTrickster
{
    public class ManifoldHijinks
    {
        private static readonly string FeatName = "ManifoldHijinks";
        internal const string DisplayName = "ManifoldHijinks.Name";
        private static readonly string Description = "ManifoldHijinks.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);

        public static void Configure()
        {

            var manifoldhijinks = FeatureConfigurator.New(FeatName, Guids.ManifoldHijinks)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(FeatureRefs.ArcanistConsumeSpellsFeature.Reference.Get().Icon)
                .SetIsClassFeature()
                .SetRanks(2)
                .Configure();

            FeatureConfigurator.For(Guids.ManifoldHijinks)
                .AddContextRankConfig(new ContextRankConfig
                {
                    m_Type = AbilityRankType.Default,
                    m_BaseValueType = ContextRankBaseValueType.FeatureRank,
                    m_Feature = manifoldhijinks.ToReference<BlueprintFeatureReference>(),
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
