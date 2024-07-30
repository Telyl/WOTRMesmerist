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
using CharacterOptionsPlus.Util;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;

namespace Mesmerist.Mesmerist.TrickFeats
{
    public class SpellTrick
    {
        private static readonly string FeatName = "SpellTrick";
        internal const string DisplayName = "SpellTrick.Name";
        private static readonly string Description = "SpellTrick.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);

        public static void Configure()
        {
            BuffConfigurator.New(FeatName + "Buff", Guids.SpellTrickBuff)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(FeatureRefs.QuickenSpellFeat.Reference.Get().Icon)
                //.AddMetamagicOnNextSpell(false, metamagic: Kingmaker.UnitLogic.Abilities.Metamagic.Quicken)
                .AddFreeActionSpell(checkAbilityType: true, abilityType: Kingmaker.UnitLogic.Abilities.Blueprints.AbilityType.Spell)
                .AddAbilityUseTrigger(action: ActionsBuilder.New().RemoveSelf(), type: Kingmaker.UnitLogic.Abilities.Blueprints.AbilityType.Spell)
                .Configure();

            AbilityConfigurator.New(FeatName + "Ability", Guids.SpellTrickAbility)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(FeatureRefs.QuickenSpellFeat.Reference.Get().Icon)
                .AddAbilityEffectRunAction(ActionsBuilder.New().ApplyBuffPermanent(Guids.SpellTrickBuff))
                .SetRange(Kingmaker.UnitLogic.Abilities.Blueprints.AbilityRange.Personal)
                .AddAbilityResourceLogic(1, false, true, requiredResource: Guids.MesmeristTrickResource)
                .Configure();

            FeatureConfigurator.New(FeatName, Guids.SpellTrick)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(FeatureRefs.QuickenSpellFeat.Reference.Get().Icon)
                .AddFacts(new() { Guids.SpellTrickAbility })
                .SetIsClassFeature()
                .Configure();
        }
    }
}
