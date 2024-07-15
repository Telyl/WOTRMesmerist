using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using Mesmerist.Utils;
using Kingmaker.Enums;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using static TabletopTweaks.Core.MechanicsChanges.AdditionalActivatableAbilityGroups;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.Utility;
using System.Drawing;
namespace Mesmerist.Mesmerist.Tricks
{
    public class FleetInShadows
    {
        private static readonly string FeatName = "FleetInShadows";
        internal const string DisplayName = "FleetInShadows.Name";
        private static readonly string Description = "FleetInShadows.Description";

        


        public static void Configure()
        {
            var Icon = AbilityRefs.Longstrider.Reference.Get().Icon;
            var BuffEffect = Guids.FleetInShadowsBuffEffect;
            var ToggleBuff = Guids.FleetInShadowsBuff;
            var Ability = Guids.FleetInShadowsAbility;
            var Feat = Guids.FleetInShadows;

            BuffConfigurator.New(FeatName + "BuffEffect", Guids.FleetInShadowsBuffEffect)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddRemoveWhenCombatEnded()
                .SetIcon(Icon)
                .AddBuffMovementSpeed(value: 30, descriptor: ModifierDescriptor.Enhancement)
                .Configure();

            TrickTools.CreateTrickToggleBuff(FeatName + "Buff", ToggleBuff, DisplayName, Description, Icon);
            TrickTools.CreateTrickActivatableAbility(FeatName + "Ability", Ability, DisplayName, Description, Icon, ToggleBuff);
            TrickTools.CreateTrickFeature(FeatName, Feat, DisplayName, Description, Ability);
        }
    }
}
