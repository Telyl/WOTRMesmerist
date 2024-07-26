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
using Mesmerist.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mesmerist.Mesmerist.VexingDaredevil.DazzlingFeint
{
    public class SloppyDefense
    {
        private static readonly string FeatName = "SloppyDefense";
        internal const string DisplayName = "SloppyDefense.Name";
        private static readonly string Description = "SloppyDefense.Description";
        public static void Configure()
        {
            BuffConfigurator.New(FeatName + "Buff", Guids.SloppyDefenseBuff)
                .AddContextCalculateAbilityParamsBasedOnClass(Guids.Mesmerist, statType: StatType.Charisma)
                .AddInitiatorAttackWithWeaponTrigger(ActionsBuilder.New()
                .Conditional(ConditionsBuilder.New().UseOr().HasFact(BuffRefs.FeintBuffEnemy.Reference.Get()).HasFact(BuffRefs.FeintBuffEnemyFinalFeintEnemyBuff.Reference.Get()),
                 ifTrue: ActionsBuilder.New().BuffActionAddStatBonus(Kingmaker.Enums.ModifierDescriptor.Circumstance,
                 StatType.AdditionalAttackBonus, ContextValues.Rank())),
                onlyOnFirstHit: true, triggerBeforeAttack: true)
                .AddContextRankConfig(ContextRankConfigs.ClassLevel([Guids.Mesmerist]).WithStartPlusDivStepProgression(5))
                .Configure();

            ActivatableAbilityConfigurator.New(FeatName + "Ability", Guids.SloppyDefenseAbility)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.FeintAbility.Reference.Get().Icon)
                .SetBuff(Guids.SloppyDefenseBuff)
                .Configure();

            FeatureConfigurator.New(FeatName, Guids.SloppyDefense)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddFacts(new() { Guids.SloppyDefenseAbility })
                .Configure();
        }
    }
}
