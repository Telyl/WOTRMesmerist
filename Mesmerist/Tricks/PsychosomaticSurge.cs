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
namespace Mesmerist.Mesmerist.Tricks
{
    public class PsychosomaticSurge
    {
        private static readonly string FeatName = "PsychosomaticSurge";
        internal const string DisplayName = "PsychosomaticSurge.Name";
        private static readonly string Description = "PsychosomaticSurge.Description";

        




        public static void Configure()
        {
            BuffConfigurator.New(FeatName + "BuffEffect", Guids.PsychosomaticSurgeBuffEffect)
                .CopyFrom(BuffRefs.FalseLifeBuff.Reference.Get(), typeof(TemporaryHitPointsFromAbilityValue))
                .CopyFrom(BuffRefs.FalseLifeBuff.Reference.Get(), typeof(ContextCalculateSharedValue))
                .AddContextRankConfig(ContextRankConfigs.ClassLevel([Guids.Mesmerist]).WithDiv2Progression())
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.FalseLifeGreater.Reference.Get().Icon)
                .Configure();

            BuffConfigurator.New(FeatName + "Buff", Guids.PsychosomaticSurgeBuff)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.FalseLifeGreater.Reference.Get().Icon)
                .SetFlags(Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff.Flags.HiddenInUi)
                .Configure();

            ActivatableAbilityConfigurator.New(FeatName + "Ability", Guids.PsychosomaticSurgeAbility)
                 .SetDisplayName(DisplayName)
                 .SetDescription(Description)
                 .SetIcon(AbilityRefs.FalseLifeGreater.Reference.Get().Icon)
                .SetGroup((ActivatableAbilityGroup)((ExtentedActivatableAbilityGroup)1819))
                 .SetHiddenInUI()
                 .SetBuff(Guids.PsychosomaticSurgeBuff)
                 .SetDeactivateImmediately()
                 .Configure();

            //TODO: Change CharacterLevel to ClassLevel(Mesmerist)
            FeatureConfigurator.New(FeatName, Guids.PsychosomaticSurge)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddFacts(new() { Guids.PsychosomaticSurgeAbility })
                .SetIsClassFeature()
                .Configure();
        }
    }
}
