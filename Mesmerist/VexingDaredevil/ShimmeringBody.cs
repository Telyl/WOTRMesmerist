using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Blueprints.References;
using CharacterOptionsPlus.Util;
using Kingmaker.Utility;
using Mesmerist.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mesmerist.Mesmerist.VexingDaredevil
{
    public class ShimmeringBody
    {
        private static readonly string FeatName = "ShimmeringBody";
        internal const string DisplayName = "ShimmeringBody.Name";
        private static readonly string Description = "ShimmeringBody.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);

        public static void Configure()
        {

            //TODO: Change CharacterLevel to ClassLevel(Mesmerist)
            FeatureSelectionConfigurator.New(FeatName, Guids.ShimmeringBody)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.Blur.Reference.Get().Icon)
                .SetIsClassFeature()
                .AddConcealment(descriptor: Kingmaker.Enums.ConcealmentDescriptor.Blur,
                concealment: Kingmaker.Enums.Concealment.Partial,
                checkDistance: false,
                checkWeaponRangeType: false,
                rangeType: Kingmaker.Enums.WeaponRangeType.Melee,
                onlyForAttacks: false)
                .AddFormationACBonus(1, unitProperty: false)
                .Configure();


        }
    }
}
