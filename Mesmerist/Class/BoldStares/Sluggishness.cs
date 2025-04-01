using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.EntitySystem.Stats;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using Mesmerist.Utils;
using Kingmaker.Enums;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints.Classes.Spells;

namespace Mesmerist.Class.BoldStares
{
    public class Sluggishness
    {
        private static readonly string FeatName = "Sluggishness";
        internal const string DisplayName = "Sluggishness.Name";
        private static readonly string Description = "Sluggishness.Description";

        public static void Configure()
        {
            BuffConfigurator.New(FeatName + "Buff", Guids.SluggishnessBuff)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddUniqueBuff()
                .SetIcon(BuffRefs.DebilitatingInjuryDisorientedEffectBuff.Reference.Get().Icon)
                .AddContextStatBonus(StatType.SaveReflex, ContextValues.Rank(), ModifierDescriptor.UntypedStackable, 2, -1)
                .AddBuffMovementSpeed(descriptor: ModifierDescriptor.UntypedStackable, value: -5, cappedMinimum: true, minimumCap: 5)
                .AddContextRankConfig(ContextRankConfigs.CharacterLevel(AbilityRankType.Default).WithCustomProgression((7, 2), (19, 3), (20, 5)))
                .Configure();

            //TODO: Change CharacterLevel to ClassLevel(Mesmerist)
            FeatureConfigurator.New(FeatName, Guids.Sluggishness)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIsClassFeature()
                .SetIcon(AbilityRefs.TrueSeeing.Reference.Get().Icon)
                .Configure();


        }
    }
}
