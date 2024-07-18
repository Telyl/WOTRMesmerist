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
using Kingmaker.UnitLogic.Buffs.Blueprints;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using Mesmerist.NewComponents.AbilitySpecific;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Mesmerist.NewComponents;
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
            var TrickBuff = Guids.LinkedReactionBuff;
            var Ability = Guids.LinkedReactionAbility;
            var Feat = Guids.LinkedReaction;

            TrickTools.CreateTrickTrickBuff(FeatName + "Buff", TrickBuff, DisplayName, Description, Icon);
            BuffConfigurator.For(TrickBuff)
                .AddRemoveWhenCombatEnded()
                .AddComponent<AddLinkedReaction>()
                .Configure();
            TrickTools.CreateTrickAbility(FeatName + "Ability", Ability, DisplayName, Description, Icon, TrickBuff, Feat);
            TrickTools.CreateTrickFeature(FeatName, Feat, DisplayName, Description, Ability);

            AbilityConfigurator.For(Ability)
            .SetCanTargetSelf(false)
            .Configure();
        }
    }
}
