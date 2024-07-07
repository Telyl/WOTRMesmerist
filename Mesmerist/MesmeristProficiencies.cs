using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Items.Armors;
using Mesmerist.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UnityModManagerNet.UnityModManager;

namespace Mesmerist.Mesmerist
{
    class MesmeristProficiencies
    {
        private static readonly string FeatName = "MesmeristProficiencies";
        internal const string DisplayName = "MesmeristProficiencies.Name";
        private static readonly string Description = "MesmeristProficiencies.Description";

        public static void Configure()
        {
            FeatureConfigurator.New(FeatName, Guids.MesmeristProficiencies)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddFacts(new()
                {
                    FeatureRefs.SimpleWeaponProficiency.Reference.Get(),
                    FeatureRefs.LightArmorProficiency.Reference.Get(),
                })
                .SetHideInUI(false)
                .SetHideNotAvailibleInUI(false)
                .SetIsClassFeature(true)
                .SetReapplyOnLevelUp(false)
                .SetRanks(1)
                .SetAllowNonContextActions(false)
                .Configure();
        }
    }
}