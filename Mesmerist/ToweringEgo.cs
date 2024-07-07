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
    public class ToweringEgo
    {
        private static readonly string FeatName = "ToweringEgo";
        internal const string DisplayName = "ToweringEgo.Name";
        private static readonly string Description = "ToweringEgo.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);

        public static void Configure()
        {

            //TODO: Change CharacterLevel to ClassLevel(Mesmerist)
            BlueprintFeature consummateLiar = FeatureConfigurator.New(FeatName, Guids.ToweringEgo)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.Guidance.Reference.Get().Icon)
                .SetIsClassFeature()
                .AddDerivativeStatBonus(StatType.Charisma, StatType.SaveWill, ModifierDescriptor.None)
                .AddRecalculateOnStatChange(stat: StatType.Charisma)
                .Configure();
        }
    }
}
