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
            var BuffEffect = Guids.PsychosomaticSurgeBuffEffect;
            var ToggleBuff = Guids.PsychosomaticSurgeBuff;
            var Ability = Guids.PsychosomaticSurgeAbility;
            var Feat = Guids.PsychosomaticSurge;

            BuffConfigurator.New(FeatName + "BuffEffect", BuffEffect)
                .CopyFrom(BuffRefs.FalseLifeBuff.Reference.Get(), typeof(TemporaryHitPointsFromAbilityValue))
                .CopyFrom(BuffRefs.FalseLifeBuff.Reference.Get(), typeof(ContextCalculateSharedValue))
                .AddContextRankConfig(ContextRankConfigs.ClassLevel([Guids.Mesmerist]).WithDiv2Progression())
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.FalseLifeGreater.Reference.Get().Icon)
                .Configure();

            TrickTools.CreateTrickToggleBuff(FeatName + "Buff", ToggleBuff, DisplayName, Description, Icon);
            TrickTools.CreateTrickActivatableAbility(FeatName + "Ability", Ability, DisplayName, Description, Icon, ToggleBuff);
            TrickTools.CreateTrickFeature(FeatName, Feat, DisplayName, Description, Ability);
        }
    }
}
