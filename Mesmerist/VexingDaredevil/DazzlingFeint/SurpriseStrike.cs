using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.BasicEx;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Utils.Types;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Mesmerist.NewActions;
using Mesmerist.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mesmerist.Mesmerist.VexingDaredevil.DazzlingFeint
{
    public class SurpriseStrike
    {
        private static readonly string FeatName = "SurpriseStrike";
        internal const string DisplayName = "SurpriseStrike.Name";
        private static readonly string Description = "SurpriseStrike.Description";
        public static void Configure()
        {
            BuffConfigurator.New(FeatName + "Buff", Guids.SurpriseStrikeBuff)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(FeatureRefs.SneakAttack.Reference.Get().Icon)
                .AddContextCalculateAbilityParamsBasedOnClass(Guids.Mesmerist, statType: StatType.Charisma)
                .AddInitiatorAttackWithWeaponTrigger(ActionsBuilder.New()
                .Conditional(ConditionsBuilder.New().UseOr().HasBuffFromCaster(BuffRefs.FeintBuffEnemy.Reference.Get()).HasBuffFromCaster(BuffRefs.FeintBuffEnemyFinalFeintEnemyBuff.Reference.Get()),
                 ifTrue: ActionsBuilder.New().Add<ContextActionSurpriseStrike>()),
                onlyOnFirstHit: true)
                .Configure();

            ActivatableAbilityConfigurator.New(FeatName + "Ability", Guids.SurpriseStrikeAbility)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(FeatureRefs.SneakAttack.Reference.Get().Icon)
                .SetBuff(Guids.SurpriseStrikeBuff)
                .Configure();

            FeatureConfigurator.New(FeatName, Guids.SurpriseStrike)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddPrerequisiteClassLevel(Guids.Mesmerist, 7)
                .AddFacts(new() { Guids.SurpriseStrikeAbility })
                .Configure();
        }
    }
}
