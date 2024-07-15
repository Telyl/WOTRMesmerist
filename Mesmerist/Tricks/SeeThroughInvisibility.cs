using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using Mesmerist.Utils;
using CharacterOptionsPlus.Util;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using static TabletopTweaks.Core.MechanicsChanges.AdditionalActivatableAbilityGroups;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.Utility;
using System.Drawing;
namespace Mesmerist.Mesmerist.Tricks
{
    public class SeeThroughInvisibility
    {
        private static readonly string FeatName = "SeeThroughInvisibility";
        internal const string DisplayName = "SeeThroughInvisibility.Name";
        private static readonly string Description = "SeeThroughInvisibility.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);

        public static void Configure()
        {
            var Icon = AbilityRefs.SeeInvisibility.Reference.Get().Icon;
            var BuffEffect = Guids.SeeThroughInvisibilityBuffEffect;
            var ToggleBuff = Guids.SeeThroughInvisibilityBuff;
            var Ability = Guids.SeeThroughInvisibilityAbility;
            var Feat = Guids.SeeThroughInvisibility;

            BuffConfigurator.New(FeatName + "BuffEffect", BuffEffect)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.SeeInvisibility.Reference.Get().Icon)
                .AddCondition(Kingmaker.UnitLogic.UnitCondition.SeeInvisibility)
                .Configure();

            TrickTools.CreateTrickToggleBuff(FeatName + "Buff", ToggleBuff, DisplayName, Description, Icon);
            TrickTools.CreateTrickActivatableAbility(FeatName + "Ability", Ability, DisplayName, Description, Icon, ToggleBuff);
            TrickTools.CreateTrickFeature(FeatName, Feat, DisplayName, Description, Ability);
        }
    }
}
