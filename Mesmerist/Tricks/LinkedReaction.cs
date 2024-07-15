using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using Mesmerist.Utils;
using CharacterOptionsPlus.Util;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using static TabletopTweaks.Core.MechanicsChanges.AdditionalActivatableAbilityGroups;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Mesmerist.NewComponents;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.Utility;
using System.Drawing;
namespace Mesmerist.Mesmerist.Tricks
{
    public class LinkedReaction
    {
        private static readonly string FeatName = "LinkedReaction";
        internal const string DisplayName = "LinkedReaction.Name";
        private static readonly string Description = "LinkedReaction.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);


        public static void Configure()
        {
            var Icon = AbilityRefs.OracleRevelationLifeLinkAbility.Reference.Get().Icon;
            var BuffEffect = Guids.LinkedReactionBuffEffect;
            var ToggleBuff = Guids.LinkedReactionBuff;
            var Ability = Guids.LinkedReactionAbility;
            var Feat = Guids.LinkedReaction;

            BuffConfigurator.New(FeatName + "BuffEffect", BuffEffect)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddRemoveWhenCombatEnded()
                .AddComponent<AddLinkedReaction>()
                .SetIcon(Icon)
                .Configure();

            TrickTools.CreateTrickToggleBuff(FeatName + "Buff", ToggleBuff, DisplayName, Description, Icon);
            TrickTools.CreateTrickActivatableAbility(FeatName + "Ability", Ability, DisplayName, Description, Icon, ToggleBuff);
            TrickTools.CreateTrickFeature(FeatName, Feat, DisplayName, Description, Ability);
        }
    }
}
