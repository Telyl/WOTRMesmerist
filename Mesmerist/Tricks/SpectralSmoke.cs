using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using Mesmerist.Utils;
using Kingmaker.Enums;
using CharacterOptionsPlus.Util;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using Kingmaker.Utility;
using static TabletopTweaks.Core.MechanicsChanges.AdditionalActivatableAbilityGroups;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Abilities;
using System.Drawing;
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
            var Icon = AbilityRefs.MindFog.Reference.Get().Icon;
            var BuffEffect = Guids.SpectralSmokeBuffEffect;
            var ToggleBuff = Guids.SpectralSmokeBuff;
            var Ability = Guids.SpectralSmokeAbility;
            var Feat = Guids.SpectralSmoke;

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

            BuffConfigurator.New(FeatName + "BuffEffect", BuffEffect)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.MindFog.Reference.Get().Icon)
                .AddAreaEffect(Guids.SpectralSmokeAreaEffect)
                .Configure();

            TrickTools.CreateTrickToggleBuff(FeatName + "Buff", ToggleBuff, DisplayName, Description, Icon);
            TrickTools.CreateTrickActivatableAbility(FeatName + "Ability", Ability, DisplayName, Description, Icon, ToggleBuff);
            TrickTools.CreateTrickFeature(FeatName, Feat, DisplayName, Description, Ability);
        }
    }
}
