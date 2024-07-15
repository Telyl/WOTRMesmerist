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
namespace Mesmerist.Mesmerist.Tricks
{
    public class FearsomeGuise
    {
        private static readonly string FeatName = "FearsomeGuise";
        internal const string DisplayName = "FearsomeGuise.Name";
        private static readonly string Description = "FearsomeGuise.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);

        public static void Configure()
        {
            BuffConfigurator.New(FeatName + "BuffEffect", Guids.FearsomeGuiseBuffEffect)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddRemoveWhenCombatEnded()
                .SetIcon(AbilityRefs.FrightfulAspect.Reference.Get().Icon)
                .AddComponent<AddSubjectInitiateTrickTrigger>(c =>
                {
                    c.ActionsOnTarget = ActionsBuilder.New().CastSpell(AbilityRefs.PersuasionUseAbility.Reference.Get(), false, false, true).Build();
                    c.OnlyMelee =  false;
                    c.OnlyHit = false;
                })
                .Configure();

            ActivatableAbilityConfigurator.New(FeatName + "ToggleEffect", Guids.FearsomeGuiseToggleEffect)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetBuff(Guids.FearsomeGuiseBuffEffect)
                .Configure();

            BuffConfigurator.New(FeatName + "Buff", Guids.FearsomeGuiseBuff)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.FrightfulAspect.Reference.Get().Icon)
                .SetFlags(Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff.Flags.HiddenInUi)
                .Configure();

            ActivatableAbilityConfigurator.New(FeatName + "Ability", Guids.FearsomeGuiseAbility)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.FrightfulAspect.Reference.Get().Icon)
                .SetGroup((ActivatableAbilityGroup)((ExtentedActivatableAbilityGroup)1819))
                .SetHiddenInUI()
                .SetBuff(Guids.FearsomeGuiseBuff)
                 .SetDeactivateImmediately()
                .Configure();

            //TODO: Change CharacterLevel to ClassLevel(Mesmerist)
            FeatureConfigurator.New(FeatName, Guids.FearsomeGuise)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddFacts(new() { Guids.FearsomeGuiseAbility })
                .SetIsClassFeature()
                .Configure();
        }
    }
}
