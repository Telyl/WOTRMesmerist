using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using Mesmerist.Utils;

namespace Mesmerist.Class.Medium.Spirits
{
    internal class Guardian
    {
        private static readonly string FeatName = "Guardian";
        internal const string DisplayName = "Guardian.Name";
        private static readonly string Description = "Guardian.Description";

        private static readonly string BUFF = Guids.GuardianBuff;
        private static readonly string ABILITY = Guids.GuardianActivatableAbility;
        private static readonly string FEATURE = Guids.Guardian;
        public static void Configure()
        {
            var buff = BuffConfigurator.New(FeatName + "Buff", BUFF)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();

            var ability = ActivatableAbilityConfigurator.New(FeatName + "ActivatableAbility", ABILITY)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetDeactivateImmediately()
                .SetBuff(buff)
                .Configure();

            var feature = FeatureConfigurator.New(FeatName, FEATURE)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIsClassFeature(true)
                .AddFacts(new() { ability })
                .Configure();
        }
    }
}
