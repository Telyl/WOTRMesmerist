using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Utils.Types;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Mesmerist.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mesmerist.Mesmerist.VexingDaredevil.DazzlingFeint
{
    public class CriticalStrike
    {
        private static readonly string FeatName = "CriticalStrike";
        internal const string DisplayName = "CriticalStrike.Name";
        private static readonly string Description = "CriticalStrike.Description";
        public static void Configure()
        {
            BuffConfigurator.New(FeatName + "BuffEffect", Guids.CriticalStrikeBuffEffect)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(BuffRefs.CriticalFocusBuff.Reference.Get().Icon)
                .AddCriticalConfirmationBonus(value: ContextValues.Rank())
                .AddContextRankConfig(ContextRankConfigs.ClassLevel([Guids.Mesmerist]).WithStartPlusDivStepProgression(5))
                .AddRemoveBuffOnAttack()
                .Configure();

            BuffConfigurator.New(FeatName + "Buff", Guids.CriticalStrikeBuff)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(BuffRefs.CriticalFocusBuff.Reference.Get().Icon)
                .AddInitiatorAttackWithWeaponTrigger(ActionsBuilder.New()
                .Conditional(ConditionsBuilder.New().UseOr().HasBuffFromCaster(BuffRefs.FeintBuffEnemy.Reference.Get()).HasBuffFromCaster(BuffRefs.FeintBuffEnemyFinalFeintEnemyBuff.Reference.Get()),
                 ifTrue: ActionsBuilder.New().ApplyBuffPermanent(Guids.CriticalStrikeBuffEffect, true, false, false, true, toCaster: true)),
                 triggerBeforeAttack: true, onlyOnFirstAttack: true)
                .Configure();

            ActivatableAbilityConfigurator.New(FeatName + "Ability", Guids.CriticalStrikeAbility)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(BuffRefs.CriticalFocusBuff.Reference.Get().Icon)
                .SetBuff(Guids.CriticalStrikeBuff)
                .Configure();

            FeatureConfigurator.New(FeatName, Guids.CriticalStrike)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddFacts(new() { Guids.CriticalStrikeAbility })
                .Configure();
        }
    }
}
