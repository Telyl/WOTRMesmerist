﻿using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.EntitySystem.Stats;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using Mesmerist.Utils;
using Kingmaker.Enums;
using BlueprintCore.Utils.Types;
using CharacterOptionsPlus.Util;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using static TabletopTweaks.Core.MechanicsChanges.AdditionalActivatableAbilityGroups;
using Kingmaker.UnitLogic.ActivatableAbilities;
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
                .AddRemoveWhenCombatEnded()
                .SetIcon(AbilityRefs.ShadowEvocation.Reference.Get().Icon)
                .AddDamageResistancePhysical(value: ContextValues.Rank())
                .AddContextRankConfig(ContextRankConfigs.StatBonus(StatType.Charisma, ModifierDescriptor.UntypedStackable, min:1))
                //.AddDamageReductionAgainstFactOwner(checkedFact: Guids.HypnoticStareBuff, reduction: 3)
                //.AddIncomingDamageTrigger(checkDamageDealt: true, actions)
                //.AddDamageReductionAgainstFactOwner()
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
                 .SetGroup((ActivatableAbilityGroup)((ExtentedActivatableAbilityGroup)1819))
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
