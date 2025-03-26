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
    public class Timidity
    {
        private static readonly string FeatName = "Timidity";
        internal const string DisplayName = "Timidity.Name";
        private static readonly string Description = "Timidity.Description";

        public static void Configure()
        {

            BuffConfigurator.New(FeatName + "Buff", Guids.TimidityBuff)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddUniqueBuff()
                .SetIcon(BuffRefs.DebilitatingInjuryDisorientedEffectBuff.Reference.Get().Icon)
                .AddContextStatBonus(StatType.AdditionalDamage, ContextValues.Rank(), ModifierDescriptor.UntypedStackable, 2, -1)
                .AddContextRankConfig(ContextRankConfigs.CharacterLevel().WithCustomProgression((7, 2), (20, 3)))
                .Configure(); 

            //TODO: Change CharacterLevel to ClassLevel(Mesmerist)
            FeatureConfigurator.New(FeatName, Guids.Timidity)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIsClassFeature()
                .SetIcon(AbilityRefs.TrueSeeing.Reference.Get().Icon)
                .Configure();
        }
    }
}
