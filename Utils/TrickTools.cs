using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.BasicEx;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.EventConditionActionSystem.ContextData;
using Kingmaker.Designers.EventConditionActionSystem.Evaluators;
using Kingmaker.ElementsSystem;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Mesmerist.Mesmerist.Tricks;
using Mesmerist.NewComponents;
using Mesmerist.NewComponents.AbilitySpecific;
using static TabletopTweaks.Core.MechanicsChanges.AdditionalActivatableAbilityGroups;

namespace Mesmerist.Utils
{
    public class TrickTools
    {
        public static BlueprintBuff CreateTrickTrickBuff(string FeatName, string GUID,
            string DisplayName, string Description, UnityEngine.Sprite Icon)
        {
            return BuffConfigurator.New(FeatName, GUID)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(Icon)
                .SetFlags(BlueprintBuff.Flags.RemoveOnRest)
                .AddComponent<AddTrickComponent>()
                .Configure();
        }

        public static BlueprintAbility CreateTrickAbility(string FeatName, string GUID,
            string DisplayName, string Description, UnityEngine.Sprite Icon, string TrickBuff, 
            string FeatureRequired, bool permanent = true, bool astoundingAvoidance = false, string TrickBuffImproved = "", bool masterfulTrick = false,
            bool linkedreact = false)
        {
            var ability = AbilityConfigurator.New(FeatName, GUID)
                 .SetDisplayName(DisplayName)
                 .SetDescription(Description)
                 .SetIcon(Icon)
                 .SetHidden(true)
                 .SetCanTargetFriends(true)
                 .SetCanTargetEnemies(false)
                 .SetRange(AbilityRange.Touch)
                 .SetNotOffensive(true)
                 .AddAbilitySpawnFx(Kingmaker.UnitLogic.Abilities.Components.Base.AbilitySpawnFxAnchor.SelectedTarget, 0,
                   false, Kingmaker.UnitLogic.Abilities.Components.Base.AbilitySpawnFxAnchor.None,
                   Kingmaker.UnitLogic.Abilities.Components.Base.AbilitySpawnFxOrientation.Copy,
                   Kingmaker.UnitLogic.Abilities.Components.Base.AbilitySpawnFxAnchor.None, "224fb8fd952ec4d45b6d3436a77663d9")
                 .AddAbilityCasterHasFacts(new() { FeatureRequired })
                 .AddAbilityShowIfCasterHasFact(unitFact: FeatureRequired )
                 .Configure();

            if(masterfulTrick)
            {
                AbilityConfigurator.For(GUID)
                 .AddAbilityResourceLogic(2, false, true, requiredResource: Guids.MesmeristTrickResource)
                 .Configure();
            }
            else
            {
                AbilityConfigurator.For(GUID)
                 .AddAbilityResourceLogic(1, false, true, requiredResource: Guids.MesmeristTrickResource)
                 .Configure();
            }

            if (astoundingAvoidance)
            {
                AbilityConfigurator.For(GUID)
                 .AddAbilityEffectRunAction(ActionsBuilder.New().Conditional(ConditionsBuilder.New().CasterHasFact(Guids.MasterfulTricks, true),
                    ifTrue: ActionsBuilder.New().ApplyBuffPermanent(TrickBuff, true, false, false, true),
                    ifFalse: ActionsBuilder.New().ApplyBuffPermanent(TrickBuffImproved, true, false, false, true)))
                 .Configure();
            }
            else if (linkedreact)
            {
                AbilityConfigurator.For(GUID)
                 .AddAbilityEffectRunAction(ActionsBuilder.New().ApplyBuffPermanent(TrickBuff, true, false, false, true).ApplyBuffPermanent(Guids.LinkedReactionMesmeristBuff, true, false, false, true, false, true, true))
                 .Configure();
            }
            else if (!permanent)
            {
                AbilityConfigurator.For(GUID)
                 .AddAbilityEffectRunAction(ActionsBuilder.New().ApplyBuff(TrickBuff, ContextDuration.Variable(ContextValues.Rank(), Kingmaker.UnitLogic.Mechanics.DurationRate.Minutes), true, false, false, true))
                 .AddContextRankConfig(ContextRankConfigs.ClassLevel([Guids.Mesmerist], false))
                 .Configure();
            }
            else
            {
                AbilityConfigurator.For(GUID)
                 .AddAbilityEffectRunAction(ActionsBuilder.New().ApplyBuffPermanent(TrickBuff, true, false, false, true))
                 .Configure();
            }


            return ability;

        }

        public static BlueprintFeature CreateTrickFeature(string FeatName, string GUID, 
            string DisplayName, string Description, string Facts)
        {
            return FeatureConfigurator.New(FeatName, GUID)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddFacts(new() { Facts })
                .SetIsClassFeature()
                .SetHideInUI()
                .SetHideNotAvailibleInUI()
                .Configure();
        }
    }
}
