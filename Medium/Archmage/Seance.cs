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

namespace Mesmerist.Medium
{
    public class ArchmageSeance
    {
        private static readonly string FeatName = "ArchmageSeance";
        internal const string DisplayName = "ArchmageSeance.Name";
        private static readonly string Description = "ArchmageSeance.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);

        public static void Configure()
        {
            BuffConfigurator.New(FeatName + "ArchmageBuff", Guids.SharedSeanceArchmageBuff)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.BloodlineArcaneItemBondAbility.Reference.Get().Icon)
                .AddDraconicBloodlineArcana(value: 2, spellDescriptor: SpellDescriptor.Arcane, spellsOnly: true, useContextBonus: true)
                .AddDraconicBloodlineArcana(value: 2, spellDescriptor: SpellDescriptor.Acid, spellsOnly: true, useContextBonus: true)
                .AddDraconicBloodlineArcana(value: 2, spellDescriptor: SpellDescriptor.Fire, spellsOnly: true, useContextBonus: true)
                .AddDraconicBloodlineArcana(value: 2, spellDescriptor: SpellDescriptor.Cold, spellsOnly: true, useContextBonus: true)
                .AddDraconicBloodlineArcana(value: 2, spellDescriptor: SpellDescriptor.Electricity, spellsOnly: true, useContextBonus: true)
                .AddDraconicBloodlineArcana(value: 2, spellDescriptor: SpellDescriptor.Force, spellsOnly: true, useContextBonus: true)
                .AddDraconicBloodlineArcana(value: 2, spellDescriptor: SpellDescriptor.Sonic, spellsOnly: true, useContextBonus: true)
                .AddDraconicBloodlineArcana(value: 2, spellDescriptor: SpellDescriptor.None, spellsOnly: true, useContextBonus: true)
                .Configure();

            AbilityConfigurator.New(FeatName + "Ability", Guids.SharedSeanceArchmageAbility)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.BloodlineArcaneItemBondAbility.Reference.Get().Icon)
                .AddAbilityEffectRunAction(actions: ActionsBuilder.New()
                    .ApplyBuffPermanent(Guids.SharedSeanceArchmageBuff, true, false, false, true,  false, false, false))
                .AddAbilitySpawnFx(anchor: AbilitySpawnFxAnchor.Caster, time: AbilitySpawnFxTime.OnStart,
                prefabLink: "d119d19888a8f964b8acc5dfce6ea9e9", orientationMode: AbilitySpawnFxOrientation.Copy, 
                delay: 0, destroyOnCast: false)
                .AddAbilityTargetsAround(radius: 30.Feet(), targetType: TargetType.Ally,
                includeDead: false, spreadSpeed: 17.Feet())
                .Configure();
        }
    }
}