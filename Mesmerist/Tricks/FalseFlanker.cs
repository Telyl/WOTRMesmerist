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
using Kingmaker.UnitLogic.Buffs.Blueprints;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using BlueprintCore.Utils.Types;
using Kingmaker.UnitLogic.Buffs.Components;
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
            var TrickBuff = Guids.FalseFlankerBuff;
            var Ability = Guids.FalseFlankerAbility;
            var Feat = Guids.FalseFlanker;

            TrickTools.CreateTrickTrickBuff(FeatName + "Buff", TrickBuff, DisplayName, Description, Icon);

            BuffConfigurator.For(TrickBuff)
                .AddRemoveWhenCombatEnded()
                .AddComponent<AddForceFlanked>()
                .Configure();

            TrickTools.CreateTrickAbility(FeatName + "Ability", Ability, DisplayName, Description, Icon, TrickBuff, Feat);
            TrickTools.CreateTrickFeature(FeatName, Feat, DisplayName, Description, Ability);
        }
    }
}
