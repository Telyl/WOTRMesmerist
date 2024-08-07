using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.EntitySystem.Stats;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using Mesmerist.Utils;
using Kingmaker.Enums;
using BlueprintCore.Utils.Types;
using CharacterOptionsPlus.Util;
using Kingmaker.Blueprints;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Actions.Builder;
using BlueprintCore.Conditions.Builder;
using Kingmaker.UnitLogic.FactLogic;
using BlueprintCore.Utils;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Conditions.Builder.ContextEx;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Commands.Base;
using Mesmerist.NewActions;
using Kingmaker.UnitLogic.Abilities;

namespace Mesmerist.Medium
{
    public class Spirit
    {
        private static readonly string FeatName = "Spirit";
        internal const string DisplayName = "Spirit.Name";
        private static readonly string Description = "Spirit.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);

        public static void Configure()
        {
            FeatureConfigurator.New("Supreme", Guids.Supreme)
                .SetDisplayName("Supreme.Name")
                .SetDescription("Supreme.Description")
                .SetIsClassFeature()
                .SetRanks(1)
                .Configure();

            FeatureConfigurator.New("Greater", Guids.Greater)
                .SetDisplayName("Greater.Name")
                .SetDescription("Greater.Description")
                .SetIsClassFeature()
                .SetRanks(1)
                .Configure();

            FeatureConfigurator.New("Intermediate", Guids.Intermediate)
                .SetDisplayName("Intermediate.Name")
                .SetDescription("Intermediate.Description")
                .SetIsClassFeature()
                .SetRanks(1)
                .Configure();

            FeatureConfigurator.New("Lesser", Guids.Lesser)
                .SetDisplayName("Lesser.Name")
                .SetDescription("Lesser.Description")
                .SetIsClassFeature()
                .SetRanks(1)
                .Configure();

            FeatureConfigurator.New(FeatName, Guids.Spirit)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIsClassFeature()
                .AddFacts(new() { Guids.ArchmageActivatableAbility, Guids.ChampionActivatableAbility, 
                    Guids.HierophantActivatableAbility, Guids.GuardianActivatableAbility,
                    Guids.MarshalActivatableAbility })
                .SetRanks(1)
                .Configure();
        }
    }
}
