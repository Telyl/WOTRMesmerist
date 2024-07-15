using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using Mesmerist.Utils;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using static TabletopTweaks.Core.MechanicsChanges.AdditionalActivatableAbilityGroups;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.Utility;
using System.Drawing;
namespace Mesmerist.Mesmerist.Tricks
{
    public class FreeInBody
    {
        private static readonly string FeatName = "FreeInBody";
        internal const string DisplayName = "FreeInBody.Name";
        private static readonly string Description = "FreeInBody.Description";




        public static void Configure()
        {

            var Icon = AbilityRefs.FreedomOfMovement.Reference.Get().Icon;
            var BuffEffect = Guids.FreeInBodyBuffEffect;
            var ToggleBuff = Guids.FreeInBodyBuff;
            var Ability = Guids.FreeInBodyAbility;
            var Feat = Guids.FreeInBody;

            BuffConfigurator.New(FeatName + "BuffEffect", Guids.FreeInBodyBuffEffect)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddRemoveWhenCombatEnded()
                .SetFlags(Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff.Flags.HiddenInUi)
                .SetIcon(Icon)
                .AddFacts(new() { BuffRefs.FreedomOfMovementBuff.Reference.Get() })
                .Configure();

            TrickTools.CreateTrickToggleBuff(FeatName + "Buff", ToggleBuff, DisplayName, Description, Icon);
            TrickTools.CreateTrickActivatableAbility(FeatName + "Ability", Ability, DisplayName, Description, Icon, ToggleBuff);
            TrickTools.CreateTrickFeature(FeatName, Feat, DisplayName, Description, Ability);
        }
    }
}
