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
    public class Timidity
    {
        private static readonly string FeatName = "Timidity";
        internal const string DisplayName = "Timidity.Name";
        private static readonly string Description = "Timidity.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);

        public static void Configure()
        {

            BuffConfigurator.New(FeatName + "Buff", Guids.TimidityBuff)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddUniqueBuff()
                .AddSpellDescriptorComponent(SpellDescriptor.MindAffecting)
                .SetIcon(BuffRefs.DebilitatingInjuryDisorientedEffectBuff.Reference.Get().Icon)
                .AddContextStatBonus(StatType.AdditionalDamage, ContextValues.Rank(), ModifierDescriptor.UntypedStackable, 2, -1)
                .AddContextRankConfig(ContextRankConfigs.CharacterLevel().WithCustomProgression((7, 2), (20, 3)))
                .Configure();

            //TODO: Change CharacterLevel to ClassLevel(Mesmerist)
            FeatureConfigurator.New(FeatName, Guids.Timidity)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIsClassFeature()
                .Configure();
        }
    }
}
