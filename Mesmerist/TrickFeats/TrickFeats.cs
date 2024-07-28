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
using Mesmerist.Mesmerist.Tricks;
using BlueprintCore.Blueprints.CustomConfigurators;
using Kingmaker.Blueprints;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.ActivatableAbilities;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Utils;
using CharacterOptionsPlus.Util;
using Kingmaker.UnitLogic.Mechanics.Components;
using Mesmerist.NewComponents;
using Mesmerist.NewUnitParts;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using System.Collections.Generic;

namespace Mesmerist.Mesmerist.TrickFeats
{
    public class TrickFeats
    {
        private static readonly string FeatName = "TrickFeats";
        internal const string DisplayName = "TrickFeats.Name";
        private static readonly string Description = "TrickFeats.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);

        public static void Configure()
        {

            FeatureSelectionConfigurator.New(FeatName + "Selection", Guids.TrickFeats)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(FeatureRefs.ArcanistArcaneReservoirFeature.Reference.Get().Icon)
                .AddPrerequisiteClassLevel(Guids.Mesmerist, 3)
                .AddToAllFeatures([Guids.BouncingTrick, Guids.ReapplyTrick, Guids.SpellTrick])
                .Configure();

            FeatureSelectionConfigurator.For(Guids.TrickFeats, true)
                .SetGroups(FeatureGroup.Feat, FeatureGroup.CombatFeat)
                .Configure();

        }
    }
}
