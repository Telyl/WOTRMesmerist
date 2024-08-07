using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using Mesmerist.Utils;
using CharacterOptionsPlus.Util;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using Kingmaker.Utility;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Abilities.Components.Base;
using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using Kingmaker.Blueprints.Classes.Spells;
using BlueprintCore.Blueprints.References;
using Kingmaker.UnitLogic.Mechanics;
using BlueprintCore.Utils.Types;

namespace Mesmerist.Medium.Hierophant
{
    public class HierophantSeance
    {
        private static readonly string FeatName = "HierophantSeance";
        internal const string DisplayName = "HierophantSeance.Name";
        private static readonly string Description = "HierophantSeance.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);

        public static void Configure()
        {
            BuffConfigurator.New(FeatName + "HierophantBuff", Guids.SharedSeanceHierophantBuff)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.ImitationFighterAbility.Reference.Get().Icon)
                .AddIncreaseSpellHealing(healBonus: ContextValues.Rank())
                .AddContextRankConfig(ContextRankConfigs.FeatureRank(Guids.SpiritBonus).WithMultiplyByModifierProgression(2))
                .Configure();

            AbilityConfigurator.New(FeatName + "Ability", Guids.SharedSeanceHierophantAbility)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.ImitationFighterAbility.Reference.Get().Icon)
                .AddAbilityEffectRunAction(actions: ActionsBuilder.New()
                    .ApplyBuffPermanent(Guids.SharedSeanceHierophantBuff, true, false, false, true,  false, false, false))
                .AddAbilitySpawnFx(anchor: AbilitySpawnFxAnchor.Caster, time: AbilitySpawnFxTime.OnStart,
                prefabLink: "d119d19888a8f964b8acc5dfce6ea9e9", orientationMode: AbilitySpawnFxOrientation.Copy, 
                delay: 0, destroyOnCast: false)
                .AddAbilityTargetsAround(radius: 30.Feet(), targetType: TargetType.Ally,
                includeDead: false, spreadSpeed: 17.Feet())
                .Configure();
        }
    }
}