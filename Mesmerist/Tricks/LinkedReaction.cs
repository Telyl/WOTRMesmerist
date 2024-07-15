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
    public class LinkedReaction
    {
        private static readonly string FeatName = "LinkedReaction";
        internal const string DisplayName = "LinkedReaction.Name";
        private static readonly string Description = "LinkedReaction.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);


        public static void Configure()
        {
            BuffConfigurator.New(FeatName + "BuffEffect", Guids.LinkedReactionBuffEffect)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddRemoveWhenCombatEnded()
                .AddComponent<AddLinkedReaction>()
                .SetIcon(AbilityRefs.OracleRevelationLifeLinkAbility.Reference.Get().Icon)
                .Configure();

            BuffConfigurator.New(FeatName + "Buff", Guids.LinkedReactionBuff)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.OracleRevelationLifeLinkAbility.Reference.Get().Icon)
                .SetFlags(Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff.Flags.HiddenInUi)
                .Configure();

            ActivatableAbilityConfigurator.New(FeatName + "Ability", Guids.LinkedReactionAbility)
                 .SetDisplayName(DisplayName)
                 .SetDescription(Description)
                 .SetIcon(AbilityRefs.OracleRevelationLifeLinkAbility.Reference.Get().Icon)
                 .SetGroup((ActivatableAbilityGroup)((ExtentedActivatableAbilityGroup)1819))
                 .SetHiddenInUI()
                 .SetBuff(Guids.LinkedReactionBuff)
                 .SetDeactivateImmediately()
                 .Configure();

            //TODO: Change CharacterLevel to ClassLevel(Mesmerist)
            FeatureConfigurator.New(FeatName, Guids.LinkedReaction)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddFacts(new() { Guids.LinkedReactionAbility })
                .SetIsClassFeature()
                .Configure();
        }
    }
}
