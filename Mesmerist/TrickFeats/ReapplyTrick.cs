using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Classes;
using Kingmaker.EntitySystem.Stats;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using Mesmerist.Utils;
using static UnityModManagerNet.UnityModManager.ModEntry;
using System;
using Kingmaker.Enums;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints.Classes.Prerequisites;
using CharacterOptionsPlus.Util;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using static TabletopTweaks.Core.MechanicsChanges.AdditionalActivatableAbilityGroups;
using Kingmaker.UnitLogic.ActivatableAbilities;

namespace Mesmerist.Mesmerist.TrickFeats
{
    public class ReapplyTrick
    {
        private static readonly string FeatName = "ReapplyTrick";
        internal const string DisplayName = "ReapplyTrick.Name";
        private static readonly string Description = "ReapplyTrick.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);

        public static void Configure()
        {

            BuffConfigurator.New(FeatName + "Buff", Guids.ReapplyTrickBuff)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.DominatePerson.Reference.Get().Icon)
                .Configure();

            ActivatableAbilityConfigurator.New(FeatName + "Ability", Guids.ReapplyTrickAbility)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.DominatePerson.Reference.Get().Icon)
                .SetGroup((ActivatableAbilityGroup)((ExtentedActivatableAbilityGroup)1820))
                .SetBuff(Guids.ReapplyTrickBuff)
                .SetDeactivateImmediately()
                .Configure();

            FeatureConfigurator.New(FeatName, Guids.ReapplyTrick)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.DominatePerson.Reference.Get().Icon) 
                .AddFacts(new() { Guids.ReapplyTrickAbility })
                .SetIsClassFeature()
                .Configure();
        }
    }
}
