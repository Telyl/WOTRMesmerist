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
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Mesmerist.NewComponents;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
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
            var TrickBuff = Guids.MesmericMirrorBuff;
            var Ability = Guids.MesmericMirrorAbility;
            var Feat = Guids.MesmericMirror;

            TrickTools.CreateTrickTrickBuff(FeatName + "Buff", TrickBuff, DisplayName, Description, Icon);
            BuffConfigurator.For(TrickBuff)
                .CopyFrom(BuffRefs.MirrorImageBuff.Reference.Get(), typeof(AddMirrorImage))
                .CopyFrom(BuffRefs.MirrorImageBuff.Reference.Get(), typeof(ContextRankConfigs))
                .Configure();
            TrickTools.CreateTrickAbility(FeatName + "Ability", Ability, DisplayName, Description, Icon, TrickBuff, Feat, false);
            TrickTools.CreateTrickFeature(FeatName, Feat, DisplayName, Description, Ability);
        }
    }
}
