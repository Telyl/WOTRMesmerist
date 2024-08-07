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
using BlueprintCore.Utils.Types;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;

namespace Mesmerist.Medium.Guardian
{
    public class GuardianSeance
    {
        private static readonly string FeatName = "GuardianSeance";
        internal const string DisplayName = "GuardianSeance.Name";
        private static readonly string Description = "GuardianSeance.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);

        public static void Configure()
        {
            BuffConfigurator.New(FeatName + "ChampionBuff", Guids.SharedSeanceGuardianBuff)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.ImitationFighterAbility.Reference.Get().Icon)
                .AddContextStatBonus(StatType.AC, ContextValues.Rank(), ModifierDescriptor.UntypedStackable)
                .AddContextStatBonus(StatType.AdditionalCMD, ContextValues.Rank(), ModifierDescriptor.UntypedStackable)
                .AddContextRankConfig(ContextRankConfigs.FeatureRank(Guids.SpiritBonus, min: 1).WithDiv2Progression())
                .Configure();

            AbilityConfigurator.New(FeatName + "Ability", Guids.SharedSeanceGuardianAbility)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.ImitationFighterAbility.Reference.Get().Icon)
                .AddAbilityEffectRunAction(actions: ActionsBuilder.New()
                    .ApplyBuffPermanent(Guids.SharedSeanceGuardianBuff, true, false, false, true,  false, false, false))
                .AddAbilitySpawnFx(anchor: AbilitySpawnFxAnchor.Caster, time: AbilitySpawnFxTime.OnStart,
                prefabLink: "d119d19888a8f964b8acc5dfce6ea9e9", orientationMode: AbilitySpawnFxOrientation.Copy, 
                delay: 0, destroyOnCast: false)
                .AddAbilityTargetsAround(radius: 30.Feet(), targetType: TargetType.Ally,
                includeDead: false, spreadSpeed: 17.Feet())
                .Configure();
        }
    }
}