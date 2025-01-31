﻿using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using CharacterOptionsPlus.Util;
using Kingmaker.Blueprints.Classes;
using Mesmerist.Medium.Archmage;
using Mesmerist.Medium.Champion;
using Mesmerist.Medium.Guardian;
using Mesmerist.Medium.Hierophant;
using Mesmerist.Medium.Marshal;
using Mesmerist.Utils;
using static UnityModManagerNet.UnityModManager.ModEntry;

namespace Mesmerist.Medium
{
    class MediumProgression
    {
        private static readonly string ProgressionName = "MediumProgression";
        private static readonly Logging.Logger Logger = Logging.GetLogger(nameof(MediumProgression));

        public static BlueprintProgression Configure()
        {
            Logger.Log("Generating Medium Progression");
            MediumProficiencies.Configure();
            MediumSpellcasterFeat.Configure();
            SpiritBonus.Configure();
            Spirit.Configure();
            SpiritSurge.Configure();
            SharedSeance.Configure();
            
            ArchmageSupreme.Configure();
            ArchmageGreater.Configure();
            ArchmageIntermediate.Configure();
            ArchmageSeance.Configure();
            ArchmageSpirit.Configure();

            ChampionSupreme.Configure();
            ChampionGreater.Configure();
            ChampionIntermediate.Configure();
            ChampionLesser.Configure();
            ChampionSeance.Configure();
            ChampionSpirit.Configure();

            HierophantIntermediate.Configure();
            HierophantGreater.Configure();
            HierophantSupreme.Configure();
            HierophantSeance.Configure();
            HierophantSpirit.Configure();

            GuardianLesser.Configure();
            GuardianIntermediate.Configure();
            GuardianGreater.Configure();
            GuardianSupreme.Configure();
            GuardianSeance.Configure();
            GuardianSpirit.Configure();

            MarshalLesser.Configure();
            MarshalIntermediate.Configure();
            MarshalGreater.Configure();
            MarshalSupreme.Configure();
            MarshalSeance.Configure();
            MarshalSpirit.Configure();



            var entries = LevelEntryBuilder.New()
                .AddEntry(1, Guids.MediumProficiencies, Guids.SpiritBonus, Guids.Spirit, Guids.MediumSpellcasterFeat, Guids.ProhibitArchmageSpellbook, Guids.Lesser, Guids.SpiritSurge)
                .AddEntry(2, Guids.SharedSeance)
                .AddEntry(4, Guids.SpiritBonus)
                .AddEntry(6, Guids.Intermediate)
                .AddEntry(8, Guids.SpiritBonus)
                .AddEntry(10, Guids.SpiritSurge)
                .AddEntry(11, Guids.Greater)
                .AddEntry(12, Guids.SpiritBonus)
                .AddEntry(16, Guids.SpiritBonus)
                .AddEntry(17, Guids.Supreme)
                .AddEntry(20, Guids.SpiritBonus, Guids.SpiritSurge);

            return ProgressionConfigurator.New(ProgressionName, Guids.MediumProgression)
                .SetAllowNonContextActions(false)
                .SetHideInUI(false)
                .SetHideInCharacterSheetAndLevelUp(false)
                .SetHideNotAvailibleInUI(false)
                .SetRanks(1)
                .SetReapplyOnLevelUp(false)
                .SetIsClassFeature(false)
                .SetForAllOtherClasses(false)
                .SetLevelEntries(entries)
                .AddToUIGroups([Guids.Lesser, Guids.Intermediate, Guids.Greater, Guids.Supreme])
                .Configure();
        }
    }
}