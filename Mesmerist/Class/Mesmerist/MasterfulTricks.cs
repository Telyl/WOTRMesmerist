using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.Enums;
using Mesmerist.Utils;

namespace Mesmerist.Class.Mesmerist.Mesmerist
{
    internal class MasterfulTricks
    {
        private static readonly string FeatName = "MasterfulTricks";
        internal const string DisplayName = "MasterfulTricks.Name";
        private static readonly string Description = "MasterfulTricks.Description";
        public static void Configure()
        {
            FeatureConfigurator.New(FeatName, Guids.MasterfulTricks)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIsClassFeature()
                .Configure();
        }
    }
}
