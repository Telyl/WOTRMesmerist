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
namespace Mesmerist.Mesmerist.Tricks
{
    public class ShadowSplinter
    {
        private static readonly string FeatName = "ShadowSplinter";
        internal const string DisplayName = "ShadowSplinter.Name";
        private static readonly string Description = "ShadowSplinter.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);

        public static void Configure()
        {
            BuffConfigurator.New(FeatName + "BuffEffect", Guids.ShadowSplinterBuffEffect)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.ShadowEvocation.Reference.Get().Icon)
                .AddDamageReductionAgainstFactOwner(checkedFact: Guids.HypnoticStareBuff, reduction: 2)
                .Configure();

            BuffConfigurator.New(FeatName + "Buff", Guids.ShadowSplinterBuff)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.ShadowEvocation.Reference.Get().Icon)
                .SetFlags(Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff.Flags.HiddenInUi)
                .Configure();

            ActivatableAbilityConfigurator.New(FeatName + "Ability", Guids.ShadowSplinterAbility)
                 .SetDisplayName(DisplayName)
                 .SetDescription(Description)
                 .SetIcon(AbilityRefs.ShadowEvocation.Reference.Get().Icon)
                 .SetGroup(ExpandedActivatableAbilityGroup.MesmeristTricks)
                 .SetHiddenInUI()
                 .SetBuff(Guids.ShadowSplinterBuff)
                 .SetDeactivateImmediately()
                 .Configure();

            //TODO: Change CharacterLevel to ClassLevel(Mesmerist)
            FeatureConfigurator.New(FeatName, Guids.ShadowSplinter)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddFacts(new() { Guids.ShadowSplinterAbility })
                .SetIsClassFeature()
                .Configure();
        }
    }
}
