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
using CharacterOptionsPlus.Util;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using static Kingmaker.UnitLogic.Commands.Base.UnitCommand;
using Mesmerist.MechanicsChanges;
using BlueprintCore.Utils;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Abilities.Components.TargetCheckers;
using Mesmerist.NewComponents;
using Kingmaker.Blueprints;
using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;

namespace Mesmerist.Mesmerist.Tricks
{
    public class CompelAlacrity
    {
        private static readonly string FeatName = "CompelAlacrity";
        internal const string DisplayName = "CompelAlacrity.Name";
        private static readonly string Description = "CompelAlacrity.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);

        public static void Configure()
        {
            

            AbilityConfigurator.New(FeatName + "DimensionDoorAbility", Guids.CompelAlacrityDimensionDoorAbility)
                .CopyFrom(AbilityRefs.DimensionDoor.Reference.Get(),typeof(AbilityCustomDimensionDoor))
                .CopyFrom(AbilityRefs.DimensionDoor.Reference.Get(),typeof(LineOfSightIgnorance))
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetActionType(CommandType.Swift)
                .SetCanTargetPoint(true)
                .SetCanTargetEnemies(true)
                .SetRange(AbilityRange.Close)
                .Configure();

            FeatureConfigurator.New(FeatName + "DimensionDoorFeat", Guids.CompelAlacrityDimensionDoorFeat)
                .AddFacts(new() { Guids.CompelAlacrityDimensionDoorAbility })
                .SetHideInUI()
                .Configure();

            // Add Temporary Feature - Dimensions Door
            BuffConfigurator.New(FeatName + "BuffEffect", Guids.CompelAlacrityBuffEffect)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.ExpeditiousRetreat.Reference.Get().Icon)
                .AddTemporaryFeat(Guids.CompelAlacrityDimensionDoorFeat)
                .Configure();

            BuffConfigurator.New(FeatName + "Buff", Guids.CompelAlacrityBuff)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.ExpeditiousRetreat.Reference.Get().Icon)
                .SetFlags(Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff.Flags.HiddenInUi)
                .Configure();

            ActivatableAbilityConfigurator.New(FeatName + "Ability", Guids.CompelAlacrityAbility)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.ExpeditiousRetreat.Reference.Get().Icon)
                .SetGroup(ExpandedActivatableAbilityGroup.MesmeristTricks)
                .SetHiddenInUI()
                .SetBuff(Guids.CompelAlacrityBuff)
                 .SetDeactivateImmediately()
                .Configure();

            //TODO: Change CharacterLevel to ClassLevel(Mesmerist)
            FeatureConfigurator.New(FeatName, Guids.CompelAlacrity)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddFacts(new() { Guids.CompelAlacrityAbility })
                .SetIsClassFeature()
                .Configure();
        }
    }
}
