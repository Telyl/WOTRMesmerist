using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Classes;
using Kingmaker.EntitySystem.Stats;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using Mesmerist.Utils;
using static UnityModManagerNet.UnityModManager.ModEntry;
using System;
using Kingmaker.Enums;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints.Classes.Prerequisites;
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using CharacterOptionsPlus.Util;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.Utility;
using static TabletopTweaks.Core.MechanicsChanges.AdditionalActivatableAbilityGroups;
using Kingmaker.UnitLogic.ActivatableAbilities;
namespace Mesmerist.Mesmerist.Tricks
{
    public class SpectralSmoke
    {
        private static readonly string FeatName = "SpectralSmoke";
        internal const string DisplayName = "SpectralSmoke.Name";
        private static readonly string Description = "SpectralSmoke.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);

        public static void Configure()
        {

            BuffConfigurator.New(FeatName + "AreaEffectBuff", Guids.SpectralSmokeAreaEffectBuff)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddRemoveWhenCombatEnded()
                .SetFxOnStart("45622cc69bf53fc4b88fea9c0209407d")
                .AddConcealment(true, false, Concealment.Total, ConcealmentDescriptor.Fog, FeetExtension.Feet(5), onlyForAttacks:true)
                .Configure();

            AbilityAreaEffectConfigurator.New(FeatName + "AreaEffect", Guids.SpectralSmokeAreaEffect)
                .SetSize(FeetExtension.Feet(10))
                .SetShape(AreaEffectShape.Cylinder)
                .SetTargetType(BlueprintAbilityAreaEffect.TargetType.Ally)
                .AddAbilityAreaEffectBuff(Guids.SpectralSmokeAreaEffectBuff, true, ConditionsBuilder.New().IsAlly())
                .Configure();

            BuffConfigurator.New(FeatName + "BuffEffect", Guids.SpectralSmokeBuffEffect)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.MindFog.Reference.Get().Icon)
                .AddAreaEffect(Guids.SpectralSmokeAreaEffect)
                .Configure();

            BuffConfigurator.New(FeatName + "Buff", Guids.SpectralSmokeBuff)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.MindFog.Reference.Get().Icon)
                .SetFlags(Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff.Flags.HiddenInUi)
                .Configure();

            ActivatableAbilityConfigurator.New(FeatName + "Ability", Guids.SpectralSmokeAbility)
                 .SetDisplayName(DisplayName)
                 .SetDescription(Description)
                 .SetIcon(AbilityRefs.MindFog.Reference.Get().Icon)
                 .SetGroup((ActivatableAbilityGroup)((ExtentedActivatableAbilityGroup)1819))
                 .SetHiddenInUI()
                 .SetBuff(Guids.SpectralSmokeBuff)
                 .SetDeactivateImmediately()
                 .Configure();

            //TODO: Change CharacterLevel to ClassLevel(Mesmerist)
            FeatureConfigurator.New(FeatName, Guids.SpectralSmoke)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddFacts(new() { Guids.SpectralSmokeAbility })
                .SetIsClassFeature()
                .Configure();
        }
    }
}
