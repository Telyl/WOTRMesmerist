﻿using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using Mesmerist.Utils;
using CharacterOptionsPlus.Util;
using Kingmaker.Blueprints.Classes.Spells;

namespace Mesmerist.Mesmerist.BoldStares
{
    public class Disquiet
    {
        private static readonly string FeatName = "Disquiet";
        internal const string DisplayName = "Disquiet.Name";
        private static readonly string Description = "Disquiet.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);

        public static void Configure()
        {
            BuffConfigurator.New(FeatName + "Buff", Guids.DisquietBuff)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddUniqueBuff()
                .AddSpellDescriptorComponent(SpellDescriptor.MindAffecting)
                .SetIcon(BuffRefs.FearBuff.Reference.Get().Icon)
                .AddCondition(Kingmaker.UnitLogic.UnitCondition.Shaken)
                .Configure();

            //TODO: Change CharacterLevel to ClassLevel(Mesmerist)
            FeatureConfigurator.New(FeatName, Guids.Disquiet)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIsClassFeature()
                .Configure();


        }
    }
}
