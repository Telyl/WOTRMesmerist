using BlueprintCore.Blueprints.Configurators.Classes.Spells;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using CharacterOptionsPlus.Util;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.EntitySystem.Stats;
using Mesmerist.Mesmerist;
using Mesmerist.Mesmerist.BoldStares;
using Mesmerist.Mesmerist.Tricks;
using Mesmerist.Utils;
using static UnityModManagerNet.UnityModManager.ModEntry;

namespace Mesmerist.Mesmerist
{
    class MesmeristProgression
    {
        private static readonly string ProgressionName = "MesmeristProgression";
        private static readonly Logging.Logger Logger = Logging.GetLogger(nameof(MesmeristProgression));
        public static BlueprintProgression Configure()
        {
            Logger.Log("Generating Mesmerist Progression");
            MesmeristProficiencies.Configure();
            ConsummateLiar.Configure();
            ToweringEgo.Configure();

            // Load Tricks
            AstoundingAvoidance.Configure();
            CompelAlacrity.Configure();
            FalseFlanker.Configure();
            FearsomeGuise.Configure();
            FleetInShadows.Configure();
            LevitationBuffer.Configure();
            LinkedReaction.Configure();
            MeekFacade.Configure();
            MesmericMirror.Configure();
            MesmericPantomime.Configure();
            Misdirection.Configure();
            PsychosomaticSurge.Configure();
            ReflectFear.Configure();
            SeeThroughInvisibility.Configure();
            ShadowSplinter.Configure();
            SpectralSmoke.Configure();
            VanishArrow.Configure();
            VoiceOfReason.Configure();

            // Load Trick Variant Ability
            TrickVariants.Configure();
            
            // Load Stares
            Disorientation.Configure();
            Disquiet.Configure();
            Distracted.Configure();
            Infiltration.Configure();
            Lethality.Configure();
            Nightmare.Configure();
            PsychicInception.Configure();
            SappedMagic.Configure();
            Sluggishness.Configure();
            Timidity.Configure();
            


            TouchTreatment.Configure();

            // Put these at the bottom just in case there are dependencies...
            ManifoldTrick.Configure();
            HypnoticStare.Configure();
            PainfulStare.Configure();
            ManifoldStare.Configure();
            MesmeristTricks.Configure();
            BoldStare.Configure();


            var entries = LevelEntryBuilder.New()
                .AddEntry(1, Guids.ConsummateLiar, Guids.MesmeristProficiencies, Guids.HypnoticStare, 
                Guids.MesmeristTrickSelection, Guids.MesmeristTrickResourceFeature,
                Guids.TouchTreatmentResourceFeat, Guids.TrickVariants, Guids.MesmeristTrickActiveVariants, Guids.InitialTrick, Guids.ManifoldStarePainfulStare)
                .AddEntry(2, Guids.MesmeristTrickSelection, Guids.ToweringEgo)
                .AddEntry(3, Guids.PainfulStare, Guids.BoldStareSelection, Guids.TouchTreatment)
                .AddEntry(4, Guids.MesmeristTrickSelection)
                .AddEntry(5, Guids.ManifoldTrick)
                .AddEntry(6, Guids.PainfulStare, Guids.MesmeristTrickSelection, Guids.TouchTreatmentModerate)
                .AddEntry(7, Guids.BoldStareSelection)
                .AddEntry(8, Guids.HypnoticStare, Guids.MesmeristTrickSelection)
                .AddEntry(9, Guids.PainfulStare, Guids.ManifoldTrick)
                .AddEntry(10, Guids.MesmeristTrickSelection, Guids.TouchTreatmentGreater)
                .AddEntry(11, Guids.BoldStareSelection)
                .AddEntry(12, Guids.PainfulStare, Guids.MesmeristTrickSelection)
                .AddEntry(13, Guids.ManifoldTrick)
                .AddEntry(14, Guids.MesmeristTrickSelection, Guids.TouchTreatmentBreak)
                .AddEntry(15, Guids.PainfulStare, Guids.BoldStareSelection)
                .AddEntry(16, Guids.MesmeristTrickSelection)
                .AddEntry(17, Guids.ManifoldTrick)
                .AddEntry(18, Guids.PainfulStare, Guids.MesmeristTrickSelection)
                .AddEntry(19, Guids.BoldStareSelection)
                .AddEntry(20, Guids.MesmeristTrickSelection);

            return ProgressionConfigurator.New(ProgressionName, Guids.MesmeristProgression)
                .SetAllowNonContextActions(false)
                .SetHideInUI(false)
                .SetHideInCharacterSheetAndLevelUp(false)
                .SetHideNotAvailibleInUI(false)
                .SetRanks(1)
                .SetReapplyOnLevelUp(false)
                .SetIsClassFeature(false)
                .SetForAllOtherClasses(false)
                .SetLevelEntries(entries)
                .Configure();
        }
    }
}