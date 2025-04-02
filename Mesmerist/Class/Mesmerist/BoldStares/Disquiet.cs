using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using Mesmerist.Utils;
using Kingmaker.Blueprints.Classes.Spells;

namespace Mesmerist.Class.Mesmerist.BoldStares
{
    public class Disquiet
    {
        private static readonly string FeatName = "Disquiet";
        internal const string DisplayName = "Disquiet.Name";
        private static readonly string Description = "Disquiet.Description";

        public static void Configure()
        {
            BuffConfigurator.New(FeatName + "Buff", Guids.DisquietBuff)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddUniqueBuff()
                .SetIcon(BuffRefs.FearBuff.Reference.Get().Icon)
                .AddCondition(Kingmaker.UnitLogic.UnitCondition.Shaken)
                .Configure();

            //TODO: Change CharacterLevel to ClassLevel(Mesmerist)
            FeatureConfigurator.New(FeatName, Guids.Disquiet)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.TrueSeeing.Reference.Get().Icon)
                .SetIsClassFeature()
                .Configure();


        }
    }
}
