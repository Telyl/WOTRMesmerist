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

namespace Mesmerist.Medium.Marshal
{
    public class MarshalSeance
    {
        private static readonly string FeatName = "MarshalSeance";
        internal const string DisplayName = "MarshalSeance.Name";
        private static readonly string Description = "MarshalSeance.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);

        public static void Configure()
        {
            BuffConfigurator.New(FeatName + "MarshalBuff", Guids.SharedSeanceMarshalBuff)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.ImitationFighterAbility.Reference.Get().Icon)
                .AddFacts(new() { Guids.SharedSeanceArchmageAbility, Guids.SharedSeanceChampionAbility, Guids.SharedSeanceGuardianAbility, Guids.SharedSeanceHierophantAbility })
                .Configure();

            AbilityConfigurator.New(FeatName + "Ability", Guids.SharedSeanceMarshalAbility)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.ImitationFighterAbility.Reference.Get().Icon)
                .AddAbilityEffectRunAction(actions: ActionsBuilder.New()
                    .ApplyBuffPermanent(Guids.SharedSeanceMarshalBuff, true, false, false, true,  false, false, false))
                .AddAbilitySpawnFx(anchor: AbilitySpawnFxAnchor.Caster, time: AbilitySpawnFxTime.OnStart,
                prefabLink: "d119d19888a8f964b8acc5dfce6ea9e9", orientationMode: AbilitySpawnFxOrientation.Copy, 
                delay: 0, destroyOnCast: false)
                .AddAbilityTargetsAround(radius: 30.Feet(), targetType: TargetType.Ally,
                includeDead: false, spreadSpeed: 17.Feet())
                .Configure();
        }
    }
}