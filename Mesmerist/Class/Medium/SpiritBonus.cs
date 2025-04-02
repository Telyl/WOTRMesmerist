using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using Mesmerist.Utils;

namespace Mesmerist.Class.Medium
{
    internal class SpiritBonus
    {
        private static readonly string FeatName = "SpiritBonus";
        internal const string DisplayName = "SpiritBonus.Name";
        private static readonly string Description = "SpiritBonus.Description";
        public static void Configure()
        {
            FeatureConfigurator.New(FeatName, Guids.SpiritBonus)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetRanks(10)
                .SetIsClassFeature(true)
                .Configure();
                
        }
    }
}
