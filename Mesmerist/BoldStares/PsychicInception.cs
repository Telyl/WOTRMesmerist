using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using Mesmerist.Utils;
using Kingmaker.Blueprints.Classes.Spells;
using CharacterOptionsPlus.Util;
using Kingmaker.Blueprints;
using BlueprintCore.Utils;
using Mesmerist.NewComponents.AbilitySpecific;

namespace Mesmerist.Mesmerist.BoldStares
{
    public class PsychicInception
    {
        private static readonly string FeatName = "PsychicInception";
        internal const string DisplayName = "PsychicInception.Name";
        private static readonly string Description = "PsychicInception.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);

        public static void Configure()
        {
            BuffConfigurator.New(FeatName + "Buff", Guids.PsychicInceptionBuff)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddUniqueBuff()
                .AddComponent<AddPsychicInceptionSpells>(c =>
                {
                    c.IgnoreDescriptors = SpellDescriptor.MindAffecting | SpellDescriptor.Charm | SpellDescriptor.Compulsion;
                    c.BecauseOfFact = BlueprintTool.GetRef<BlueprintFeatureReference>(Guids.PsychicInception);
                    c.BecauseOfFactBuff = BlueprintTool.GetRef<BlueprintBuffReference>(Guids.HypnoticStareBuff);
                })
                .SetIcon(BuffRefs.DebilitatingInjuryDisorientedEffectBuff.Reference.Get().Icon)
                .Configure();

            //TODO: Change CharacterLevel to ClassLevel(Mesmerist)
            FeatureConfigurator.New(FeatName, Guids.PsychicInception)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIsClassFeature()
                .SetIcon(AbilityRefs.TrueSeeing.Reference.Get().Icon)
                .Configure();

        }
    }
}
