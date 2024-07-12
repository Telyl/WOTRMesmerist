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
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using Kingmaker.Blueprints.Classes.Spells;
using CharacterOptionsPlus.Util;
using TabletopTweaks.Core.NewComponents;
using Mesmerist.NewComponents;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;

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
                .Configure();


        }
    }
}
