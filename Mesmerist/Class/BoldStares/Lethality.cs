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
    public class Lethality
    {
        private static readonly string FeatName = "Lethality";
        internal const string DisplayName = "Lethality.Name";
        private static readonly string Description = "Lethality.Description";

        public static void Configure()
        {

            BuffConfigurator.New(FeatName + "Buff", Guids.LethalityBuff)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddUniqueBuff()
                .SetIcon(BuffRefs.LethalStanceEffectBuff.Reference.Get().Icon)
                .AddContextStatBonus(StatType.SaveFortitude, ContextValues.Rank(), ModifierDescriptor.UntypedStackable, 2, -1)
                .AddContextRankConfig(ContextRankConfigs.CharacterLevel(AbilityRankType.Default).WithCustomProgression((7, 2), (19, 3), (20, 5)))
                .Configure();

            //TODO: Change CharacterLevel to ClassLevel(Mesmerist)
            FeatureConfigurator.New(FeatName, Guids.Lethality)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIsClassFeature()
                .SetIcon(AbilityRefs.TrueSeeing.Reference.Get().Icon)
                .Configure();


        }
    }
}
