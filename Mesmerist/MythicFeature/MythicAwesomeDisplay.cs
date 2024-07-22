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
using CharacterOptionsPlus.Util;

namespace Mesmerist.Mesmerist
{
    public class MythicAwesomeDisplay
    {
        private static readonly string FeatName = "MythicAwesomeDisplay";
        internal const string DisplayName = "MythicAwesomeDisplay.Name";
        private static readonly string Description = "MythicAwesomeDisplay.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);

        public static void Configure()
        {

            FeatureConfigurator.New(FeatName, Guids.MythicAwesomeDisplay, FeatureGroup.MythicAbility)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.Starlight.Reference.Get().Icon)
                .Configure();
        }
    }
}
