using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.BasicEx;
using BlueprintCore.Utils.Types;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Mechanics;
using Mesmerist.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mesmerist.Mesmerist.VexingDaredevil.DazzlingFeint
{
    public class CombatManeuver
    {
        private static readonly string FeatName = "CombatManeuver";
        internal const string DisplayName = "CombatManeuver.Name";
        private static readonly string Description = "CombatManeuver.Description";
        public static void Configure()
        {
            BuffConfigurator.New(FeatName + "Buff", Guids.CombatManeuverBuff)
                .AddContextCalculateAbilityParamsBasedOnClass(Guids.Mesmerist, statType: StatType.Charisma)
                .AddCMBBonus(checkedFact: BuffRefs.FeintBuffEnemy.Reference.Get(), true, ModifierDescriptor.Circumstance,
                ContextValues.Rank())
                .AddCMBBonus(checkedFact: BuffRefs.FeintBuffEnemyFinalFeintEnemyBuff.Reference.Get(), true, ModifierDescriptor.Circumstance,
                ContextValues.Rank())
                .AddContextRankConfig(ContextRankConfigs.ClassLevel([Guids.Mesmerist]).WithStartPlusDivStepProgression(3))
                .Configure();

            ActivatableAbilityConfigurator.New(FeatName + "Ability", Guids.CombatManeuverAbility)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.FeintAbility.Reference.Get().Icon)
                .SetBuff(Guids.CombatManeuverBuff)
                .Configure();

            FeatureConfigurator.New(FeatName, Guids.CombatManeuver)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddFacts(new() { Guids.CombatManeuverAbility })
                .Configure();
        }
    }
}
