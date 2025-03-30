using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using Mesmerist.Utils;
using Kingmaker.Blueprints.Classes.Spells;
using TabletopTweaks.Core.NewComponents;
using Mesmerist.NewComponents.AbilitySpecific;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;

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
                //.AddComponent<SpellDescriptorImmunityIgnore>(c => c.Descriptor = SpellDescriptor.MindAffecting)
                //.AddComponent<SpellDescriptorImmunityIgnore>(c => c.Descriptor = SpellDescriptor.Compulsion)
                //.AddComponent<SpellDescriptorImmunityIgnore>(c => c.Descriptor = SpellDescriptor.Charm)
                //.AddFacts(new() { FeatureRefs.BloodlineSerpentineArcana.Reference.Get(), FeatureRefs.BloodlineUndeadArcana.Reference.Get() })
                .Configure();
            
            BuffConfigurator.New(FeatName + "Buff", Guids.PsychicInceptionBuff)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddUniqueBuff()
                .AddComponent<AddPsychicInception>()
                .SetIcon(BuffRefs.DebilitatingInjuryDisorientedEffectBuff.Reference.Get().Icon)
                //.AddRemoveFeatureOnApply(FeatureRefs.VerminImmunities.Reference.Get())
                //.AddRemoveFeatureOnApply(FeatureRefs.UndeadImmunities.Reference.Get())
                //.AddBuffDescriptorImmunity(descriptor: SpellDescriptor.MindAffecting | SpellDescriptor.Compulsion | SpellDescriptor.Charm, 
                //    ignoreFeature: BlueprintTool.GetRef<BlueprintUnitFactReference>(Guids.PsychicInception))
                //.AddSpellImmunity(spellDescriptor: SpellDescriptor.MindAffecting | SpellDescriptor.Compulsion | SpellDescriptor.Charm,
                //    casterIgnoreImmunityFact: BlueprintTool.GetRef<BlueprintUnitFactReference>(Guids.PsychicInception))
                .Configure();

        }
    }
}
