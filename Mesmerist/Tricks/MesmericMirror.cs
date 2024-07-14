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
            BuffConfigurator.New(FeatName + "BuffEffect", Guids.MesmericMirrorBuffEffect)
                .CopyFrom(BuffRefs.MirrorImageBuff.Reference.Get(), typeof(AddMirrorImage))
                .CopyFrom(BuffRefs.MirrorImageBuff.Reference.Get(), typeof(ContextRankConfigs))
                .AddRemoveWhenCombatEnded()
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.MirrorImage.Reference.Get().Icon)
                .Configure();

            BuffConfigurator.New(FeatName + "Buff", Guids.MesmericMirrorBuff)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.MirrorImage.Reference.Get().Icon)
                .SetFlags(Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff.Flags.HiddenInUi)
                .Configure();

            ActivatableAbilityConfigurator.New(FeatName + "Ability", Guids.MesmericMirrorAbility)
                 .SetDisplayName(DisplayName)
                 .SetDescription(Description)
                 .SetIcon(AbilityRefs.MirrorImage.Reference.Get().Icon)
                 .SetGroup((ActivatableAbilityGroup)((ExtentedActivatableAbilityGroup)1819))

                 .SetBuff(Guids.MesmericMirrorBuff)
                 .SetDeactivateImmediately()
                 .SetHiddenInUI()
                 .Configure();

            //TODO: Change CharacterLevel to ClassLevel(Mesmerist)
            FeatureConfigurator.New(FeatName, Guids.MesmericMirror)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddFacts(new() { Guids.MesmericMirrorAbility })
                .SetIsClassFeature()
                .Configure();
        }
    }
}
