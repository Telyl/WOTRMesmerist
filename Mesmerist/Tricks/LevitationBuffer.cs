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
using Kingmaker.EntitySystem.Stats;
using BlueprintCore.Utils.Types;
using Epic.OnlineServices.Stats;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.Utility;
using System.Drawing;
namespace Mesmerist.Mesmerist.Tricks
{
    public class LevitationBuffer
    {
        private static readonly string FeatName = "LevitationBuffer";
        internal const string DisplayName = "LevitationBuffer.Name";
        private static readonly string Description = "LevitationBuffer.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);

        public static void Configure()
        {

            var Icon = AbilityRefs.BullRushAction.Reference.Get().Icon;
            var BuffEffect = Guids.LevitationBufferBuffEffect;
            var ToggleBuff = Guids.LevitationBufferBuff;
            var Ability = Guids.LevitationBufferAbility;
            var Feat = Guids.LevitationBuffer;

            BuffConfigurator.New(FeatName + "BuffEffect", Guids.LevitationBufferBuffEffect)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(Icon)
                .AddComponent<AddLevitationBuffer>()
                .Configure();

            TrickTools.CreateTrickToggleBuff(FeatName + "Buff", ToggleBuff, DisplayName, Description, Icon);
            TrickTools.CreateTrickActivatableAbility(FeatName + "Ability", Ability, DisplayName, Description, Icon, ToggleBuff);
            TrickTools.CreateTrickFeature(FeatName, Feat, DisplayName, Description, Ability);
        }
    }
}
