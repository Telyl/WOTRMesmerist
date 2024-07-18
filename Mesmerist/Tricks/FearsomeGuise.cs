using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using Mesmerist.Utils;
using CharacterOptionsPlus.Util;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using Kingmaker.UnitLogic.ActivatableAbilities;
using static TabletopTweaks.Core.MechanicsChanges.AdditionalActivatableAbilityGroups;
using Mesmerist.NewComponents;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.Utility;
using System.Drawing;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using TabletopTweaks.Core.NewComponents.OwlcatReplacements;
using Kingmaker.UnitLogic.Mechanics.Components;
namespace Mesmerist.Mesmerist.Tricks
{
    public class FearsomeGuise
    {
        private static readonly string FeatName = "FearsomeGuise";
        internal const string DisplayName = "FearsomeGuise.Name";
        private static readonly string Description = "FearsomeGuise.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);

        public static void Configure()
        {
            var Icon = AbilityRefs.FrightfulAspect.Reference.Get().Icon;
            var TrickBuff = Guids.FearsomeGuiseBuff;
            var Ability = Guids.FearsomeGuiseAbility;
            var Feat = Guids.FearsomeGuise;

            TrickTools.CreateTrickTrickBuff(FeatName + "Buff", TrickBuff, DisplayName, Description, Icon);
            BuffConfigurator.For(TrickBuff)
                .AddComponent<AddInitiatorAttackRollTrigger>(c =>
                {
                    c.Action =  ActionsBuilder.New().CastSpell(AbilityRefs.PersuasionUseAbility.Reference.Get(), false, false, true).Build();
                    c.OnlyHit = false;
                })
                .AddRemoveBuffOnAttack()
                .Configure();
            TrickTools.CreateTrickAbility(FeatName + "Ability", Ability, DisplayName, Description, Icon, TrickBuff, Feat);
            TrickTools.CreateTrickFeature(FeatName, Feat, DisplayName, Description, Ability);
        }
    }
}
