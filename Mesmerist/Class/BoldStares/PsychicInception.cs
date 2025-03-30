using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using Mesmerist.Utils;
using Kingmaker.Blueprints.Classes.Spells;
using TabletopTweaks.Core.NewComponents;
using Mesmerist.NewComponents.AbilitySpecific;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Components.TargetCheckers;

namespace Mesmerist.Class.BoldStares
{
    public class PsychicInception
    {
        private static readonly string FeatName = "PsychicInception";
        internal const string DisplayName = "PsychicInception.Name";
        private static readonly string Description = "PsychicInception.Description";

        public static void Configure()
        {
            //TODO: Change CharacterLevel to ClassLevel(Mesmerist)
            FeatureConfigurator.New(FeatName, Guids.PsychicInception)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIsClassFeature()
                .Configure();
            
            BuffConfigurator.New(FeatName + "Buff", Guids.PsychicInceptionBuff)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddUniqueBuff()
                .AddComponent<AddPsychicInception>()
                .SetIcon(BuffRefs.DebilitatingInjuryDisorientedEffectBuff.Reference.Get().Icon)
                .Configure();

            /*.AddAbilityTargetHasNoFactUnless(
                checkedFacts: [FeatureRefs.AnimalType.Reference.Get(), FeatureRefs.VerminType.Reference.Get(), FeatureRefs.MagicalBeastType.Reference.Get()],
                unlessFact: BlueprintTool.GetRef<BlueprintUnitFactReference>(Guids.PsychicInception))*/
            AbilityConfigurator.For(AbilityRefs.Daze)
                .RemoveComponents(c => c is AbilityTargetHasNoFactUnless).Configure();

            AbilityConfigurator.For(AbilityRefs.CauseFear)
                .RemoveComponents(c => c is AbilityTargetHasNoFactUnless).Configure();

            AbilityConfigurator.For(AbilityRefs.Doom)
                .RemoveComponents(c => c is AbilityTargetHasNoFactUnless).Configure();

            AbilityConfigurator.For(AbilityRefs.CommandApproach)
                .RemoveComponents(c => c is AbilityTargetHasNoFactUnless).Configure();

            AbilityConfigurator.For(AbilityRefs.CommandFall)
                .RemoveComponents(c => c is AbilityTargetHasNoFactUnless).Configure();

            AbilityConfigurator.For(AbilityRefs.CommandFlee)
                .RemoveComponents(c => c is AbilityTargetHasNoFactUnless).Configure();

            AbilityConfigurator.For(AbilityRefs.CommandHalt)
                .RemoveComponents(c => c is AbilityTargetHasNoFactUnless).Configure();

            AbilityConfigurator.For(AbilityRefs.Castigate)
                .RemoveComponents(c => c is AbilityTargetHasNoFactUnless).Configure();

            AbilityConfigurator.For(AbilityRefs.HideousLaughter)
                .RemoveComponents(c => c is AbilityTargetHasNoFactUnless).Configure();

            AbilityConfigurator.For(AbilityRefs.HoldPerson)
                .RemoveComponents(c => c is AbilityTargetHasNoFactUnless).Configure();

            AbilityConfigurator.For(AbilityRefs.PhantasmalKiller)
                .RemoveComponents(c => c is AbilityTargetHasNoFactUnless).Configure();

            AbilityConfigurator.For(AbilityRefs.ConstrictingCoils)
                .RemoveComponents(c => c is AbilityTargetHasNoFactUnless).Configure();

            AbilityConfigurator.For(AbilityRefs.DominatePerson)
                .RemoveComponents(c => c is AbilityTargetHasNoFactUnless).Configure();

            AbilityConfigurator.For(AbilityRefs.HoldMonster)
                .RemoveComponents(c => c is AbilityTargetHasNoFactUnless).Configure();

            AbilityConfigurator.For(AbilityRefs.CommandGreaterApproach)
                .RemoveComponents(c => c is AbilityTargetHasNoFactUnless).Configure();

            AbilityConfigurator.For(AbilityRefs.CommandGreaterFall)
                .RemoveComponents(c => c is AbilityTargetHasNoFactUnless).Configure();

            AbilityConfigurator.For(AbilityRefs.CommandGreaterFlee)
                .RemoveComponents(c => c is AbilityTargetHasNoFactUnless).Configure();

            AbilityConfigurator.For(AbilityRefs.CommandGreaterHalt)
                .RemoveComponents(c => c is AbilityTargetHasNoFactUnless).Configure();

            AbilityConfigurator.For(AbilityRefs.HoldPersonMass)
                .RemoveComponents(c => c is AbilityTargetHasNoFactUnless).Configure();

            AbilityConfigurator.For(AbilityRefs.PowerWordKill)
                .RemoveComponents(c => c is AbilityTargetHasNoFactUnless).Configure();

            AbilityConfigurator.For(AbilityRefs.DominateMonster)
                .RemoveComponents(c => c is AbilityTargetHasNoFactUnless).Configure();

            AbilityConfigurator.For(AbilityRefs.Insanity)
                .RemoveComponents(c => c is AbilityTargetHasNoFactUnless).Configure();
        }
    }
}
