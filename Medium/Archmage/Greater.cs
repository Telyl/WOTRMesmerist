using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using Mesmerist.Utils;
using CharacterOptionsPlus.Util;
using Kingmaker.UnitLogic.Abilities;
using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Utils.Types;

namespace Mesmerist.Medium.Archmage
{
    public class ArchmageGreater
    {
        private static readonly string FeatName = "ArchmageGreater";
        internal const string DisplayName = "ArchmageGreater.Name";
        private static readonly string Description = "ArchmageGreater.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);
        public static void Configure()
        {
            BuffConfigurator.New(FeatName + "Buff", Guids.ArchmageGreaterBuff)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.BloodlineArcaneItemBondAbility.Reference.Get().Icon)
                .AddMetamagicOnNextSpell(false, metamagic: Metamagic.Intensified)
                .Configure();

            FeatureConfigurator.New(FeatName, Guids.ArchmageGreater)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.BloodlineArcaneItemBondAbility.Reference.Get().Icon)
                .AddInitiatorAttackWithWeaponTrigger(action: ActionsBuilder.New().ApplyBuff(Guids.ArchmageGreaterBuff, ContextDuration.Fixed(3), true),
                   onlyHit: true, criticalHit: true, actionsOnInitiator: true)
                .SetIsClassFeature(true)
                .SetRanks(1)
                .Configure();
        }
    }
}
