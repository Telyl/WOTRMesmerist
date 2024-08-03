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
using Mesmerist.Mesmerist.BoldStares;
using CharacterOptionsPlus.Util;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using System.Drawing;

namespace Mesmerist.Medium
{
    public class SpiritSurge
    {
        private static readonly string FeatName = "SpiritSurge";
        internal const string DisplayName = "SpiritSurge.Name";
        private static readonly string Description = "SpiritSurge.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);

        public static void Configure()
        {
            var icon = BuffRefs.EldritchFontGreaterSurgeBuff.Reference.Get().Icon;
            BuffConfigurator.New(FeatName + "Buff", Guids.SpiritSurgeBuff)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(icon)
                .Configure();

            AbilityConfigurator.New(FeatName + "Ability", Guids.SpiritSurgeAbility)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(icon)
                .Configure();

            FeatureConfigurator.New(FeatName, Guids.SpiritSurge)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIsClassFeature()
                .Configure();
        }
    }
}
