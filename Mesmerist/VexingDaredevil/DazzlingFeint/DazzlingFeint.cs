using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Classes;
using Mesmerist.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mesmerist.Mesmerist.VexingDaredevil.DazzlingFeint
{
    public class DazzlingFeint
    {
        private static readonly string FeatName = "DazzlingFeint";
        internal const string DisplayName = "DazzlingFeint.Name";
        private static readonly string Description = "DazzlingFeint.Description";

        public static void Configure()
        {
            BlindingStrike.Configure();
            CombatManeuver.Configure();
            CriticalStrike.Configure();
            Outmanuever.Configure();
            PiercingStrike.Configure();
            SloppyDefense.Configure();
            SurpriseStrike.Configure();

            FeatureSelectionConfigurator.New(FeatName, Guids.DazzlingFeint, FeatureGroup.None)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(FeatureRefs.ArcanistExploits.Reference.Get().Icon)
                .SetIsClassFeature()
                .AddToAllFeatures([Guids.BlindingStrike, Guids.CombatManeuver,
                Guids.CriticalStrike, Guids.Outmanuever, Guids.PiercingStrike,
                Guids.SloppyDefense, Guids.SurpriseStrike])
                .Configure();
        }
    }
}
