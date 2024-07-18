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
using Kingmaker.UnitLogic.Buffs.Blueprints;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Mesmerist.NewComponents;
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
            var TrickBuff = Guids.FleetInShadowsBuff;
            var Ability = Guids.FleetInShadowsAbility;
            var Feat = Guids.FleetInShadows;

            TrickTools.CreateTrickTrickBuff(FeatName + "Buff", TrickBuff, DisplayName, Description, Icon);
            BuffConfigurator.For(TrickBuff)
                .AddRemoveWhenCombatEnded()
                .AddBuffMovementSpeed(false, false, value: 30, descriptor: ModifierDescriptor.UntypedStackable)
                .Configure();
            TrickTools.CreateTrickAbility(FeatName + "Ability", Ability, DisplayName, Description, Icon, TrickBuff, Feat);
            TrickTools.CreateTrickFeature(FeatName, Feat, DisplayName, Description, Ability);
        }
    }
}
