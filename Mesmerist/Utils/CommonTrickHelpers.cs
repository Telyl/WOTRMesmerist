using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Utils.Types;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Abilities.Blueprints;

namespace Mesmerist.Utils
{
    public class CommonTrickHelpers
    {
        public static void CreateTrick(string FeatName, string DisplayName, string Description, UnityEngine.Sprite icon, string GUID_FEAT, string GUID_ABILITY, string GUID_BUFF)
        {
            BuffConfigurator.New(FeatName + "Buff", GUID_BUFF)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(icon)
                .AddRestTrigger(ActionsBuilder.New().RemoveSelf())
                .Configure();

            AbilityConfigurator.New(FeatName + "Ability", GUID_ABILITY)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(icon)
                .SetLocalizedDuration(Duration.MinutePerLevel)
                .AddAbilityEffectRunAction(ActionsBuilder.New().ApplyBuff(GUID_BUFF, ContextDuration.Variable(ContextValues.Rank(), Kingmaker.UnitLogic.Mechanics.DurationRate.Minutes), true, false, false, true))
                .AddContextRankConfig(ContextRankConfigs.ClassLevel([Guids.Mesmerist], false))
                .SetCanTargetFriends(true)
                .SetCanTargetEnemies(false)
                .SetRange(AbilityRange.Touch)
                .AddAbilityTargetHasFact(inverted: true, fromCaster: true, checkedFacts: [Guids.FalseFlankerBuff, Guids.MeekFacadeBuff, Guids.MesmericPantomimeBuff, Guids.MesmericMirrorBuff, 
                    Guids.PsychosomaticSurgeBuff, Guids.VoiceOfReasonBuff, Guids.SeeInDarknessBuff, Guids.UnwittingMessangerBuff, Guids.FearsomeGuiseBuff, Guids.SlipBondsBuff,
                    Guids.VanishArrowBuff, Guids.FreeInBodyBuff, Guids.ShadowBlendBuff, Guids.ConcealingVeilBuff, Guids.ForcedHopeBuff])
                .AddAbilityCasterHasFacts(new() { GUID_FEAT })
                .AddAbilityShowIfCasterHasFact(unitFact: GUID_FEAT)
                .SetNotOffensive(true)
                .AddAbilitySpawnFx(Kingmaker.UnitLogic.Abilities.Components.Base.AbilitySpawnFxAnchor.SelectedTarget, 0,
                   false, Kingmaker.UnitLogic.Abilities.Components.Base.AbilitySpawnFxAnchor.None,
                   Kingmaker.UnitLogic.Abilities.Components.Base.AbilitySpawnFxOrientation.Copy,
                   Kingmaker.UnitLogic.Abilities.Components.Base.AbilitySpawnFxAnchor.None, "224fb8fd952ec4d45b6d3436a77663d9")
                .AddAbilityResourceLogic(1, false, true, requiredResource: Guids.MesmeristTrickResource)
                .Configure();

            FeatureConfigurator.New(FeatName, GUID_FEAT)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(icon)
                .AddFacts(new() { GUID_ABILITY })
                .Configure();
        }

        public static void CreateMasterfulTrick(string FeatName, string DisplayName, string Description, UnityEngine.Sprite icon, string GUID_FEAT, string GUID_ABILITY, string GUID_BUFF)
        {
            BuffConfigurator.New(FeatName + "Buff", GUID_BUFF)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(icon)
                .AddRestTrigger(ActionsBuilder.New().RemoveSelf())
                .Configure();

            AbilityConfigurator.New(FeatName + "Ability", GUID_ABILITY)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(icon)
                .SetLocalizedDuration(Duration.MinutePerLevel)
                .AddAbilityEffectRunAction(ActionsBuilder.New().ApplyBuff(GUID_BUFF, ContextDuration.Variable(ContextValues.Rank(), Kingmaker.UnitLogic.Mechanics.DurationRate.Minutes), true, false, false, true))
                .AddContextRankConfig(ContextRankConfigs.ClassLevel([Guids.Mesmerist], false))
                .SetCanTargetFriends(true)
                .SetCanTargetEnemies(false)
                .SetRange(AbilityRange.Touch)
                .AddAbilityTargetHasFact(inverted: true, fromCaster: true, checkedFacts: [Guids.FalseFlankerBuff, Guids.MeekFacadeBuff, Guids.MesmericPantomimeBuff, Guids.MesmericMirrorBuff,
                    Guids.PsychosomaticSurgeBuff, Guids.VoiceOfReasonBuff, Guids.SeeInDarknessBuff, Guids.UnwittingMessangerBuff, Guids.FearsomeGuiseBuff, Guids.SlipBondsBuff,
                    Guids.VanishArrowBuff, Guids.FreeInBody, Guids.ShadowBlendBuff, Guids.ConcealingVeilBuff, Guids.ForcedHopeBuff])
                .AddAbilityCasterHasFacts(new() { GUID_FEAT })
                .AddAbilityShowIfCasterHasFact(unitFact: GUID_FEAT)
                .SetNotOffensive(true)
                .AddAbilitySpawnFx(Kingmaker.UnitLogic.Abilities.Components.Base.AbilitySpawnFxAnchor.SelectedTarget, 0,
                   false, Kingmaker.UnitLogic.Abilities.Components.Base.AbilitySpawnFxAnchor.None,
                   Kingmaker.UnitLogic.Abilities.Components.Base.AbilitySpawnFxOrientation.Copy,
                   Kingmaker.UnitLogic.Abilities.Components.Base.AbilitySpawnFxAnchor.None, "224fb8fd952ec4d45b6d3436a77663d9")
                .AddAbilityResourceLogic(2, false, true, requiredResource: Guids.MesmeristTrickResource)
                .Configure();

            FeatureConfigurator.New(FeatName, GUID_FEAT)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(icon)
                .AddFacts(new() { GUID_ABILITY })
                .AddPrerequisiteFeature(Guids.MasterfulTricks)
                .Configure();
        }
    }
}
