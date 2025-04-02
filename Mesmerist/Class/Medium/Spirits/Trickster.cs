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
    internal class Trickster
    {
        private static readonly string FeatName = "Trickster";
        internal const string DisplayName = "Trickster.Name";
        private static readonly string Description = "Trickster.Description";

        private static readonly string BUFF = Guids.TricksterBuff;
        private static readonly string ABILITY = Guids.TricksterActivatableAbility;
        private static readonly string FEATURE = Guids.Trickster;
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
