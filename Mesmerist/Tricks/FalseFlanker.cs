using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using Mesmerist.Utils;
using CharacterOptionsPlus.Util;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using static TabletopTweaks.Core.MechanicsChanges.AdditionalActivatableAbilityGroups;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Mesmerist.NewComponents;
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
            BuffConfigurator.New(FeatName + "BuffEffect", Guids.FalseFlankerBuffEffect)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.CleaveAction.Reference.Get().Icon)
                .AddRemoveWhenCombatEnded()
                .AddComponent<AddFalseFlanker>()
                .Configure();

            BuffConfigurator.New(FeatName + "Buff", Guids.FalseFlankerBuff)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.CleaveAction.Reference.Get().Icon)
                .SetFlags(Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff.Flags.HiddenInUi)
                .Configure();

            ActivatableAbilityConfigurator.New(FeatName + "Ability", Guids.FalseFlankerAbility)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.CleaveAction.Reference.Get().Icon)
                .SetGroup((ActivatableAbilityGroup)((ExtentedActivatableAbilityGroup)1819))
                .SetHiddenInUI()
                .SetBuff(Guids.FalseFlankerBuff)
                 .SetDeactivateImmediately()
                .Configure();

            //TODO: Change CharacterLevel to ClassLevel(Mesmerist)
            FeatureConfigurator.New(FeatName, Guids.FalseFlanker)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddFacts(new() { Guids.FalseFlankerAbility })
                .SetIsClassFeature()
                .Configure();
        }
    }
}
