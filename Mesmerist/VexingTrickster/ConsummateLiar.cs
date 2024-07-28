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

namespace Mesmerist.Mesmerist.VexingTrickster
{
    public class ConsummateTrickster
    {
        private static readonly string FeatName = "ConsummateTrickster";
        internal const string DisplayName = "ConsummateTrickster.Name";
        private static readonly string Description = "ConsummateTrickster.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);

        public static void Configure()
        {

            FeatureConfigurator.New(FeatName, Guids.ConsummateTrickster)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(FeatureRefs.FamousFeature.Reference.Get().Icon)
                .SetIsClassFeature()
                .AddContextStatBonus(stat: StatType.CheckBluff, value: ContextValues.Rank())
                .AddContextStatBonus(stat: StatType.SkillStealth, value: ContextValues.Rank())
                .AddContextStatBonus(stat: StatType.SkillThievery, value: ContextValues.Rank())
                .AddContextRankConfig(ContextRankConfigs.ClassLevel([Guids.Mesmerist]).WithStartPlusDivStepProgression(3))
                .Configure();
        }
    }
}
