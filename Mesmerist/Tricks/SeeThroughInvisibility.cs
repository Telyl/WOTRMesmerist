using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using Mesmerist.Utils;
using CharacterOptionsPlus.Util;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using static TabletopTweaks.Core.MechanicsChanges.AdditionalActivatableAbilityGroups;
using Kingmaker.UnitLogic.ActivatableAbilities;
namespace Mesmerist.Mesmerist.Tricks
{
    public class SeeThroughInvisibility
    {
        private static readonly string FeatName = "SeeThroughInvisibility";
        internal const string DisplayName = "SeeThroughInvisibility.Name";
        private static readonly string Description = "SeeThroughInvisibility.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);

        public static void Configure()
        {
            BuffConfigurator.New(FeatName + "BuffEffect", Guids.SeeThroughInvisibilityBuffEffect)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.SeeInvisibility.Reference.Get().Icon)
                .AddCondition(Kingmaker.UnitLogic.UnitCondition.SeeInvisibility)
                .Configure();

            BuffConfigurator.New(FeatName + "Buff", Guids.SeeThroughInvisibilityBuff)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.SeeInvisibility.Reference.Get().Icon)
                .SetFlags(Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff.Flags.HiddenInUi)
                .Configure();

            ActivatableAbilityConfigurator.New(FeatName + "Ability", Guids.SeeThroughInvisibilityAbility)
                 .SetDisplayName(DisplayName)
                 .SetDescription(Description)
                 .SetIcon(AbilityRefs.SeeInvisibility.Reference.Get().Icon)
                 .SetGroup((ActivatableAbilityGroup)((ExtentedActivatableAbilityGroup)1819))
                 .SetHiddenInUI()
                 .SetBuff(Guids.SeeThroughInvisibilityBuff)
                 .SetDeactivateImmediately()
                 .Configure();

            //TODO: Change CharacterLevel to ClassLevel(Mesmerist)
            FeatureConfigurator.New(FeatName, Guids.SeeThroughInvisibility)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddFacts(new() { Guids.SeeThroughInvisibilityAbility })
                .SetIsClassFeature()
                .Configure();
        }
    }
}
