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
using Kingmaker.UnitLogic.Mechanics;
using Mesmerist.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mesmerist.Mesmerist.VexingDaredevil.DazzlingFeint
{
    public class BlindingStrike
    {
        private static readonly string FeatName = "BlindingStrike";
        internal const string DisplayName = "BlindingStrike.Name";
        private static readonly string Description = "BlindingStrike.Description";
        public static void Configure()
        {

            BuffConfigurator.New(FeatName + "Buff", Guids.BlindingStrikeBuff)
                .AddContextCalculateAbilityParamsBasedOnClass(Guids.Mesmerist, statType: StatType.Charisma)
                .AddInitiatorAttackWithWeaponTrigger(ActionsBuilder.New()
                .Conditional(ConditionsBuilder.New().UseOr().HasBuffFromCaster(BuffRefs.FeintBuffEnemy.Reference.Get()).HasBuffFromCaster(BuffRefs.FeintBuffEnemyFinalFeintEnemyBuff.Reference.Get()),
                 ifTrue: ActionsBuilder.New()).SavingThrow(SavingThrowType.Fortitude, 
                    onResult: ActionsBuilder.New()
                    .ConditionalSaved(ActionsBuilder.New().ApplyBuff(BuffRefs.Blind.Reference.Get(), ContextDuration.Fixed(1)))),
                onlyOnFirstHit: true, actionsOnInitiator: false)
                .Configure();

            ActivatableAbilityConfigurator.New(FeatName + "Ability", Guids.BlindingStrikeAbility)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.Blindness.Reference.Get().Icon)
                .SetBuff(Guids.BlindingStrikeBuff)
                .Configure();

            FeatureConfigurator.New(FeatName, Guids.BlindingStrike)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddFacts(new() { Guids.BlindingStrikeAbility })
                .Configure();
        }
    }
}
