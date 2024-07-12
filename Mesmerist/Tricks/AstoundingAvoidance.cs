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
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using Kingmaker.UnitLogic.ActivatableAbilities;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using CharacterOptionsPlus.Util;
using static TabletopTweaks.Core.MechanicsChanges.AdditionalActivatableAbilityGroups;
using Mesmerist.NewComponents;

namespace Mesmerist.Mesmerist.Tricks
{
    public class AstoundingAvoidance
    {
        private static readonly string FeatName = "AstoundingAvoidance";
        internal const string DisplayName = "AstoundingAvoidance.Name";
        private static readonly string Description = "AstoundingAvoidance.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);

        public static void Configure()
        {
            BuffConfigurator.New(FeatName + "BuffEffectImproved", Guids.AstoundingAvoidanceBuffEffectImproved)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(FeatureRefs.Evasion.Reference.Get().Icon)
                .AddTemporaryFeat(FeatureRefs.ImprovedEvasion.Reference.Get())
                .Configure();

            BuffConfigurator.New(FeatName + "BuffEffect", Guids.AstoundingAvoidanceBuffEffect)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(FeatureRefs.Evasion.Reference.Get().Icon)
                .AddTemporaryFeat(FeatureRefs.Evasion.Reference.Get())
                .Configure();

            BuffConfigurator.New(FeatName + "Buff", Guids.AstoundingAvoidanceBuff)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(FeatureRefs.Evasion.Reference.Get().Icon)
                .SetFlags(BlueprintBuff.Flags.HiddenInUi)
                .Configure();

            ActivatableAbilityConfigurator.New(FeatName + "Ability", Guids.AstoundingAvoidanceAbility)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(FeatureRefs.Evasion.Reference.Get().Icon)
                .SetGroup((ActivatableAbilityGroup)((ExtentedActivatableAbilityGroup)1819))
                .SetHiddenInUI()
                .SetBuff(Guids.AstoundingAvoidanceBuff)
                .SetDeactivateImmediately()
                .Configure();

            //TODO: Change CharacterLevel to ClassLevel(Mesmerist)
            FeatureConfigurator.New(FeatName, Guids.AstoundingAvoidance)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddFacts(new() { Guids.AstoundingAvoidanceAbility })
                .SetIsClassFeature()
                .Configure();
        }
    }
}
