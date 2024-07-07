using BlueprintCore.Utils;
using CharacterOptionsPlus.Util;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components.Base;
using Mesmerist.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UnityModManagerNet.UnityModManager.ModEntry;
using Mesmerist.NewComponents;

namespace Mesmerist.NewComponents
{
    [TypeId("d280e0d7-3074-4145-bd86-36241ba42259")]
    public class AddRequirementOnFeatureRank : BlueprintComponent, IAbilityRestriction
    {
        private static readonly Logging.Logger Logger = Logging.GetLogger(nameof(AddRequirementOnFeatureRank));
        public string GetAbilityRestrictionUIText()
        {
            return $"Manifold Trick unavailable.";
        }

        public bool IsAbilityRestrictionPassed(AbilityData ability)
        {
            try
            {
                int rank = ability.Caster.Progression.Features.GetRank(Feature);
                if (rank >= checkValue)
                    return true;
            }
            catch { return false; }
            return false;
        }
        public BlueprintFeatureReference Feature = null;
        public int checkValue;
    }


}