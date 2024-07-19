using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using Mesmerist.Utils;
using Kingmaker.Blueprints.Classes.Spells;
using CharacterOptionsPlus.Util;

namespace Mesmerist.Mesmerist.BoldStares
{
    public class Nightmare
    {
        private static readonly string FeatName = "Nightmare";
        internal const string DisplayName = "Nightmare.Name";
        private static readonly string Description = "Nightmare.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);

        public static void Configure()
        {

            BuffConfigurator.New(FeatName + "Buff", Guids.NightmareBuff)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddUniqueBuff()
                .AddSpellDescriptorComponent(SpellDescriptor.MindAffecting)
                .SetIcon(BuffRefs.DebilitatingInjuryDisorientedEffectBuff.Reference.Get().Icon)
                .AddModifyD20(takeBest: false, rule: Kingmaker.Designers.Mechanics.Facts.RuleType.SavingThrow, 
                rollsAmount: 1, spellDescriptor: SpellDescriptor.Fear, 
                savingThrowType: Kingmaker.RuleSystem.Rules.FlaggedSavingThrowType.Will, specificDescriptor: true)
                .Configure();

            //TODO: Change CharacterLevel to ClassLevel(Mesmerist)
            FeatureConfigurator.New(FeatName, Guids.Nightmare)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIsClassFeature()
                .SetIcon(AbilityRefs.TrueSeeing.Reference.Get().Icon)
                .Configure();


        }
    }
}
