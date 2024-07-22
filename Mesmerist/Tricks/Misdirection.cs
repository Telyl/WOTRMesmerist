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
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using Kingmaker.Blueprints.Classes;
using System.Text.RegularExpressions;
namespace Mesmerist.Mesmerist.Tricks
{
    public class Misdirection
    {
        private static readonly string FeatName = "Misdirection";
        internal const string DisplayName = "Misdirection.Name";
        private static readonly string Description = "Misdirection.Description";

        public static void Configure()
        {
            var Icon = AbilityRefs.FeintAbility.Reference.Get().Icon;
            var TrickBuff = Guids.MisdirectionBuff;
            var Ability = Guids.MisdirectionAbility;
            var Feat = Guids.Misdirection;

            var CustomFeintFeature = FeatureConfigurator.New(FeatName + "Feint", Guids.MisdirectionFeintFeat)
                .CopyFrom(FeatureRefs.Feint, c => c is not AddFacts)
                .AddPlayerLeaveCombatTrigger(actions: ActionsBuilder.New().RemoveSelf())
                .SetGroups()
                .SetHideInUI(true)
                .SetHideInCharacterSheetAndLevelUp(true)
                .SetHideNotAvailibleInUI(true)
                .Configure();

            TrickTools.CreateTrickTrickBuff(FeatName + "Buff", TrickBuff, DisplayName, Description, Icon);
            BuffConfigurator.For(TrickBuff)
                .AddInitiatorAttackWithWeaponTrigger(onlyHit: false, triggerBeforeAttack: true, action: ActionsBuilder.New()
                    .CastSpell(AbilityRefs.FeintAbility.Reference.Get(), false, false, true), onlyOnFirstAttack: true)
                .AddRemoveBuffOnAttack()
                .Configure();
            TrickTools.CreateTrickAbility(FeatName + "Ability", Ability, DisplayName, Description, Icon, TrickBuff, Feat);
            AbilityConfigurator.For(Ability)
                .AddFacts(new() { CustomFeintFeature });
            TrickTools.CreateTrickFeature(FeatName, Feat, DisplayName, Description, Ability);
        }
    }
}
