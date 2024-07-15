using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using Mesmerist.Utils;
using BlueprintCore.Utils.Types;
using CharacterOptionsPlus.Util;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Buffs.Components;
using Kingmaker.UnitLogic.ActivatableAbilities;
using static TabletopTweaks.Core.MechanicsChanges.AdditionalActivatableAbilityGroups;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.Utility;
using System.Drawing;
namespace Mesmerist.Mesmerist.Tricks
{
    public class MesmericMirror
    {
        private static readonly string FeatName = "MesmericMirror";
        internal const string DisplayName = "MesmericMirror.Name";
        private static readonly string Description = "MesmericMirror.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);

        public static void Configure()
        {
            var Icon = AbilityRefs.MirrorImage.Reference.Get().Icon;
            var BuffEffect = Guids.MesmericMirrorBuffEffect;
            var ToggleBuff = Guids.MesmericMirrorBuff;
            var Ability = Guids.MesmericMirrorAbility;
            var Feat = Guids.MesmericMirror;

            BuffConfigurator.New(FeatName + "BuffEffect", BuffEffect)
                .CopyFrom(BuffRefs.MirrorImageBuff.Reference.Get(), typeof(AddMirrorImage))
                .CopyFrom(BuffRefs.MirrorImageBuff.Reference.Get(), typeof(ContextRankConfigs))
                .AddRemoveWhenCombatEnded()
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(Icon)
                .Configure();

            TrickTools.CreateTrickToggleBuff(FeatName + "Buff", ToggleBuff, DisplayName, Description, Icon);
            TrickTools.CreateTrickActivatableAbility(FeatName + "Ability", Ability, DisplayName, Description, Icon, ToggleBuff);
            TrickTools.CreateTrickFeature(FeatName, Feat, DisplayName, Description, Ability);
        }
    }
}
