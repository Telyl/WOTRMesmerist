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
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using static Kingmaker.UnitLogic.Commands.Base.UnitCommand;
using Mesmerist.MechanicsChanges;
using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
namespace Mesmerist.Mesmerist.Tricks
{
    public class FleetInShadows
    {
        private static readonly string FeatName = "FleetInShadows";
        internal const string DisplayName = "FleetInShadows.Name";
        private static readonly string Description = "FleetInShadows.Description";

        


        public static void Configure()
        {
            BuffConfigurator.New(FeatName + "BuffEffect", Guids.FleetInShadowsBuffEffect)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.Longstrider.Reference.Get().Icon)
                .AddBuffActions(activated: ActionsBuilder.New().ApplyBuff(BuffRefs.ExpeditiousRetreatBuff.Reference.Get(), ContextDuration.Fixed(1)))
                .Configure();

            BuffConfigurator.New(FeatName + "Buff", Guids.FleetInShadowsBuff)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.Longstrider.Reference.Get().Icon)
                .SetFlags(Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff.Flags.HiddenInUi)
                .Configure();

            ActivatableAbilityConfigurator.New(FeatName + "Ability", Guids.FleetInShadowsAbility)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.Longstrider.Reference.Get().Icon)
                .SetGroup(ExpandedActivatableAbilityGroup.MesmeristTricks)
                .SetHiddenInUI()
                .SetBuff(Guids.FleetInShadowsBuff)
                 .SetDeactivateImmediately()
                .Configure();

            //TODO: Change CharacterLevel to ClassLevel(Mesmerist)
            FeatureConfigurator.New(FeatName, Guids.FleetInShadows)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddFacts(new() { Guids.FleetInShadowsAbility })
                .SetIsClassFeature()
                .Configure();
        }
    }
}
