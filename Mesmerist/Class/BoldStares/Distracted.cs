﻿using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using Mesmerist.Utils;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints.Classes.Spells;

namespace Mesmerist.Class.BoldStares
{
    public class Distracted
    {
        private static readonly string FeatName = "Distracted";
        internal const string DisplayName = "Distracted.Name";
        private static readonly string Description = "Distracted.Description";

        public static void Configure()
        {
            BuffConfigurator.New(FeatName + "Buff", Guids.DistractedBuff)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddUniqueBuff()
                .SetIcon(BuffRefs.DistractingShotsBuff.Reference.Get().Icon)
                .AddConcentrationBonus(value: ContextValues.Rank())
                .AddContextRankConfig(ContextRankConfigs.CharacterLevel().WithCustomProgression((7, -2), (20, -3)))
                .Configure();

            //TODO: Change CharacterLevel to ClassLevel(Mesmerist)
            FeatureConfigurator.New(FeatName, Guids.Distracted)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIsClassFeature()
                .SetIcon(AbilityRefs.TrueSeeing.Reference.Get().Icon)
                .Configure();


        }
    }
}
