using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Classes;
using Kingmaker.EntitySystem.Stats;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using Mesmerist.Utils;
using static UnityModManagerNet.UnityModManager.ModEntry;
using System;
using Kingmaker.Enums;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints.Classes.Prerequisites;
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using CharacterOptionsPlus.Util;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using static Kingmaker.UnitLogic.Commands.Base.UnitCommand;
using Mesmerist.MechanicsChanges;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.ElementsSystem;
namespace Mesmerist.Mesmerist.Tricks
{
    public class SeeThroughInvisibility
    {
        private static readonly string FeatName = "SeeInDarkness";
        internal const string DisplayName = "SeeInDarkness.Name";
        private static readonly string Description = "SeeInDarkness.Description";

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
                 .SetGroup(ExpandedActivatableAbilityGroup.MesmeristTricks)
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
