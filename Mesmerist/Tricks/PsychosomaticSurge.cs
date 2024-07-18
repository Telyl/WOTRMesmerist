using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using Mesmerist.Utils;
using BlueprintCore.Utils.Types;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using Kingmaker.Designers.Mechanics.Buffs;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.UnitLogic.ActivatableAbilities;
using static TabletopTweaks.Core.MechanicsChanges.AdditionalActivatableAbilityGroups;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.Utility;
using System.Drawing;
using Kingmaker.UnitLogic.Buffs.Blueprints;
namespace Mesmerist.Mesmerist.Tricks
{
    public class PsychosomaticSurge
    {
        private static readonly string FeatName = "PsychosomaticSurge";
        internal const string DisplayName = "PsychosomaticSurge.Name";
        private static readonly string Description = "PsychosomaticSurge.Description";

        




        public static void Configure()
        {
            var Icon = AbilityRefs.FalseLifeGreater.Reference.Get().Icon;
            var TrickBuff = Guids.PsychosomaticSurgeBuff;
            var Ability = Guids.PsychosomaticSurgeAbility;
            var Feat = Guids.PsychosomaticSurge;

            TrickTools.CreateTrickTrickBuff(FeatName + "Buff", TrickBuff, DisplayName, Description, Icon);
            BuffConfigurator.For(TrickBuff)
                .CopyFrom(BuffRefs.FalseLifeBuff.Reference.Get(), typeof(TemporaryHitPointsFromAbilityValue))
                .CopyFrom(BuffRefs.FalseLifeBuff.Reference.Get(), typeof(ContextCalculateSharedValue))
                .AddContextRankConfig(ContextRankConfigs.ClassLevel([Guids.Mesmerist]).WithDiv2Progression())
                .Configure();
            TrickTools.CreateTrickAbility(FeatName + "Ability", Ability, DisplayName, Description, Icon, TrickBuff, Feat);
            TrickTools.CreateTrickFeature(FeatName, Feat, DisplayName, Description, Ability);
        }
    }
}
