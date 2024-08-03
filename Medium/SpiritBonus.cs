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
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using Mesmerist.Mesmerist.BoldStares;
using CharacterOptionsPlus.Util;
using ModMenu;
using Kingmaker.Blueprints;
using Kingmaker.UnitLogic.Mechanics.Components;
using Mesmerist.Mesmerist;

namespace Mesmerist.Medium
{
    public class SpiritBonus
    {
        private static readonly string FeatName = "SpiritBonus";
        internal const string DisplayName = "SpiritBonus.Name";
        private static readonly string Description = "SpiritBonus.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);

        public static void Configure()
        {
            //When a medium channels a spirit, he gains a bonus on certain checks and to certain statistics, depending on the spirit.
            //A 1st-level medium’s spirit bonus is +1; it increases by 1 at 4th level and every 4 levels thereafter.
            BlueprintFeature SpiritBonus = FeatureConfigurator.New(FeatName, Guids.SpiritBonus)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIsClassFeature()
                .SetRanks(10)
                .Configure();

            FeatureConfigurator.For(Guids.SpiritBonus)
                .AddContextRankConfig(new ContextRankConfig
                {
                    m_Type = AbilityRankType.Default,
                    m_BaseValueType = ContextRankBaseValueType.FeatureRank,
                    m_Feature = SpiritBonus.ToReference<BlueprintFeatureReference>(),
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
