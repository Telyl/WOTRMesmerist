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
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.ActivatableAbilities;
using static TabletopTweaks.Core.MechanicsChanges.AdditionalActivatableAbilityGroups;

namespace Mesmerist.Mesmerist.TrickFeats
{
    public class BouncingTrick
    {
        private static readonly string FeatName = "BouncingTrick";
        internal const string DisplayName = "BouncingTrick.Name";
        private static readonly string Description = "BouncingTrick.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);

        public static void Configure()
        {
            BuffConfigurator.New(FeatName + "Buff", Guids.BouncingTrickBuff)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(FeatureRefs.ZippyMagicFeature.Reference.Get().Icon)
                .Configure();

            ActivatableAbilityConfigurator.New(FeatName + "Ability", Guids.BouncingTrickAbility)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(FeatureRefs.ZippyMagicFeature.Reference.Get().Icon)
                .SetBuff(Guids.BouncingTrickBuff)
                .SetGroup((ActivatableAbilityGroup)((ExtentedActivatableAbilityGroup)1820))
                .SetDeactivateImmediately()
                .Configure();

            FeatureConfigurator.New(FeatName, Guids.BouncingTrick)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(FeatureRefs.ZippyMagicFeature.Reference.Get().Icon)
                .AddFacts(new() { Guids.BouncingTrickAbility })
                .SetIsClassFeature()
                .Configure();
        }
    }
}
