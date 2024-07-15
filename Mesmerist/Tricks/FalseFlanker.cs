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
    public class FalseFlanker
    {
        private static readonly string FeatName = "FalseFlanker";
        internal const string DisplayName = "FalseFlanker.Name";
        private static readonly string Description = "FalseFlanker.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);

        public static void Configure()
        {
            var Icon = AbilityRefs.CleaveAction.Reference.Get().Icon;
            var BuffEffect = Guids.FalseFlankerBuffEffect;
            var ToggleBuff = Guids.FalseFlankerBuff;
            var Ability = Guids.FalseFlankerAbility;
            var Feat = Guids.FalseFlanker;

            BuffConfigurator.New(FeatName + "BuffEffect", Guids.FalseFlankerBuffEffect)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(Icon)
                .AddRemoveWhenCombatEnded()
                .AddComponent<AddFalseFlankerTrick>()
                .Configure();

            TrickTools.CreateTrickToggleBuff(FeatName + "Buff", ToggleBuff, DisplayName, Description, Icon);
            TrickTools.CreateTrickActivatableAbility(FeatName + "Ability", Ability, DisplayName, Description, Icon, ToggleBuff);
            TrickTools.CreateTrickFeature(FeatName, Feat, DisplayName, Description, Ability);
        }
    }
}
