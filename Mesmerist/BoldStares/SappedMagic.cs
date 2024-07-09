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
using CharacterOptionsPlus.Util;
using Kingmaker.Blueprints.Classes.Spells;
using TabletopTweaks.Core.NewComponents;
using Mesmerist.NewComponents;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;

namespace Mesmerist.Mesmerist.BoldStares
{
    public class SappedMagic
    {
        private static readonly string FeatName = "SappedMagic";
        internal const string DisplayName = "SappedMagic.Name";
        private static readonly string Description = "SappedMagic.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);

        public static void Configure()
        {

            BuffConfigurator.New(FeatName + "Buff", Guids.SappedMagicBuff)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddUniqueBuff()
                .AddSpellDescriptorComponent(SpellDescriptor.MindAffecting)
                .SetIcon(BuffRefs.SappingAssaultIBuff.Reference.Get().Icon)
                .AddIncreaseAllSpellsDC(descriptor: ModifierDescriptor.UntypedStackable, spellsOnly: false, value: ContextValues.Rank())
                .AddSpellResistance(true, value: ContextValues.Rank())
                .AddContextRankConfig(ContextRankConfigs.CharacterLevel().WithCustomProgression((7, -2), (20, -3)))
                .Configure();

            //TODO: Change CharacterLevel to ClassLevel(Mesmerist)
            FeatureConfigurator.New(FeatName, Guids.SappedMagic)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIsClassFeature()
                .Configure();


        }
    }
}
