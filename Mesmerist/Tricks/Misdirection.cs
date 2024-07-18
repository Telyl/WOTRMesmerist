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
using Kingmaker.UnitLogic.Buffs.Blueprints;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
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
            var TrickBuff = Guids.MisdirectionBuff;
            var Ability = Guids.MisdirectionAbility;
            var Feat = Guids.Misdirection;

            TrickTools.CreateTrickTrickBuff(FeatName + "Buff", TrickBuff, DisplayName, Description, Icon);
            BuffConfigurator.For(TrickBuff)
                .AddComponent<AddTrickTrigger>(c =>
                {
                    c.ActionsOnTarget = ActionsBuilder.New().CastSpell(AbilityRefs.FeintAbility.Reference.Get(), false, false, true).Build();
                    c.BeforeAttackRoll = true;
                })
                .Configure();
            TrickTools.CreateTrickAbility(FeatName + "Ability", Ability, DisplayName, Description, Icon, TrickBuff, Feat);
            TrickTools.CreateTrickFeature(FeatName, Feat, DisplayName, Description, Ability);
        }
    }
}
