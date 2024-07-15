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
            var BuffEffect = Guids.FearsomeGuiseBuffEffect;
            var ToggleBuff = Guids.FearsomeGuiseBuff;
            var Ability = Guids.FearsomeGuiseAbility;
            var Feat = Guids.FearsomeGuise;

            BuffConfigurator.New(FeatName + "BuffEffect", Guids.FearsomeGuiseBuffEffect)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(Icon)
                .AddComponent<AddTrickTrigger>(c =>
                {
                    c.ActionsOnTarget = ActionsBuilder.New().CastSpell(AbilityRefs.PersuasionUseAbility.Reference.Get(), false, false, true).Build();
                    c.OnlyHit = false;
                })
                .Configure();

            TrickTools.CreateTrickToggleBuff(FeatName + "Buff", ToggleBuff, DisplayName, Description, Icon);
            TrickTools.CreateTrickActivatableAbility(FeatName + "Ability", Ability, DisplayName, Description, Icon, ToggleBuff);
            TrickTools.CreateTrickFeature(FeatName, Feat, DisplayName, Description, Ability);
        }
    }
}
