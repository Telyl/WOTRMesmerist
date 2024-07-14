using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.EntitySystem.Stats;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using Mesmerist.Utils;
using Kingmaker.Enums;
using BlueprintCore.Utils.Types;
using CharacterOptionsPlus.Util;
using Kingmaker.Blueprints.Classes.Spells;

namespace Mesmerist.Mesmerist.BoldStares
{
    public class Lethality
    {
        private static readonly string FeatName = "Lethality";
        internal const string DisplayName = "Lethality.Name";
        private static readonly string Description = "Lethality.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);

        public static void Configure()
        {

            BuffConfigurator.New(FeatName + "Buff", Guids.LethalityBuff)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddUniqueBuff()
                .AddSpellDescriptorComponent(SpellDescriptor.MindAffecting)
                .SetIcon(BuffRefs.LethalStanceEffectBuff.Reference.Get().Icon)
                .AddContextStatBonus(StatType.SaveFortitude, ContextValues.Rank(), ModifierDescriptor.UntypedStackable, 2, -1)
                .AddContextRankConfig(ContextRankConfigs.CharacterLevel().WithCustomProgression((7, 2), (20, 3)))
                .Configure();

            //TODO: Change CharacterLevel to ClassLevel(Mesmerist)
            FeatureConfigurator.New(FeatName, Guids.Lethality)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIsClassFeature()
                .Configure();


        }
    }
}
