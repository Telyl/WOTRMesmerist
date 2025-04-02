using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using Mesmerist.Utils;

namespace Mesmerist.Class.Medium
{
    internal class SpiritPower
    {
        private static readonly string FeatName = "SpiritPower";

        public static void Configure()
        {
            FeatureConfigurator.New(FeatName + "Lesser", Guids.SpiritPowerLesser)
                .SetDisplayName("SpiritPowerLesser.Name")
                .SetDescription("SpiritPowerLesser.Description")
                .SetIsClassFeature(true)
                .Configure();

            FeatureConfigurator.New(FeatName + "Intermediate", Guids.SpiritPowerIntermediate)
                .SetDisplayName("SpiritPowerIntermediate.Name")
                .SetDescription("SpiritPowerIntermediate.Description")
                .SetIsClassFeature(true)
                .Configure();

            FeatureConfigurator.New(FeatName + "Greater", Guids.SpiritPowerGreater)
                .SetDisplayName("SpiritPowerGreater.Name")
                .SetDescription("SpiritPowerGreater.Description")
                .SetIsClassFeature(true)
                .Configure();

            FeatureConfigurator.New(FeatName + "Supreme", Guids.SpiritPowerSupreme)
                .SetDisplayName("SpiritPowerSupreme.Name")
                .SetDescription("SpiritPowerSupreme.Description")
                .SetIsClassFeature(true)
                .Configure();
        }
    }
}
