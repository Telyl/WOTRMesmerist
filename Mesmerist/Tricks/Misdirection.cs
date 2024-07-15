using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using Mesmerist.Utils;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using Kingmaker.UnitLogic.ActivatableAbilities;
using static TabletopTweaks.Core.MechanicsChanges.AdditionalActivatableAbilityGroups;
using Mesmerist.NewComponents;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.Utility;
using System.Drawing;
namespace Mesmerist.Mesmerist.Tricks
{
    public class Misdirection
    {
        private static readonly string FeatName = "Misdirection";
        internal const string DisplayName = "Misdirection.Name";
        private static readonly string Description = "Misdirection.Description";

        public static void Configure()
        {
            var Icon = AbilityRefs.Vanish.Reference.Get().Icon;
            var BuffEffect = Guids.MisdirectionBuffEffect;
            var ToggleBuff = Guids.MisdirectionBuff;
            var Ability = Guids.MisdirectionAbility;
            var Feat = Guids.Misdirection;

            BuffConfigurator.New(FeatName + "BuffEffect", BuffEffect)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(Icon)
                .AddComponent<AddTrickTrigger>(c =>
                {
                    c.ActionsOnTarget = ActionsBuilder.New().CastSpell(AbilityRefs.FeintAbility.Reference.Get(), false, false, true).Build();
                    c.BeforeAttackRoll = true;
                })
                .Configure();

            TrickTools.CreateTrickToggleBuff(FeatName + "Buff", ToggleBuff, DisplayName, Description, Icon);
            TrickTools.CreateTrickActivatableAbility(FeatName + "Ability", Ability, DisplayName, Description, Icon, ToggleBuff);
            TrickTools.CreateTrickFeature(FeatName, Feat, DisplayName, Description, Ability);
        }
    }
}
