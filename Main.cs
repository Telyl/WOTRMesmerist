//using Mesmerist.NewSpells;
//using Mesmerist.Homebrew;
using BlueprintCore.Blueprints.Configurators.Root;
using BlueprintCore.Utils;
using HarmonyLib;
using Kingmaker.Blueprints.JsonSystem;
using System;
using UnityModManagerNet;
using static UnityModManagerNet.UnityModManager.ModEntry;
using Mesmerist.Utils;
using Kingmaker.PubSubSystem;
using Mesmerist.Mesmerist;
using CharacterOptionsPlus.Util;
using Mesmerist.Features;
using Mesmerist.Mesmerist.BoldStares;
using Mesmerist.Mesmerist.VexingDaredevil;
using Mesmerist.Mesmerist.VexingDaredevil.DazzlingFeint;
using Mesmerist.Mesmerist.TrickFeats;
using Mesmerist.Mesmerist.VexingTrickster;


namespace Mesmerist
{
    public static class Main
    {
        public static bool Enabled;
        private static readonly Logging.Logger Logger = Logging.GetLogger(nameof(Main));

        public static bool Load(UnityModManager.ModEntry modEntry)
        {
            try
            {
                var harmony = new Harmony(modEntry.Info.Id);
                harmony.PatchAll();

                EventBus.Subscribe(new BlueprintCacheInitHandler());

                Logger.Log("Finished patching.");
            }
            catch (Exception e)
            {
                Logger.LogException("Failed to patch", e);
            }
            return true;
        }

        class BlueprintCacheInitHandler : IBlueprintCacheInitHandler
        {
            private static bool Initialized = false;
            private static bool InitializeDelayed = false;

            public void AfterBlueprintCachePatches()
            {
                try
                {
                    if (InitializeDelayed)
                    {
                        Logger.Log("Already initialized blueprints cache.");
                        return;
                    }
                    InitializeDelayed = true;

                    ConfigureFeatsDelayed();

                    RootConfigurator.ConfigureDelayedBlueprints();
                }
                catch (Exception e)
                {
                    Logger.LogException("Delayed blueprint configuration failed.", e);
                }
            }

            public void BeforeBlueprintCachePatches()
            {

            }

            public void BeforeBlueprintCacheInit()
            {

            }

            public void AfterBlueprintCacheInit()
            {
                try
                {
                    if (Initialized)
                    {
                        Logger.Log("Already initialized blueprints cache.");
                        return;
                    }
                    Initialized = true;

                    // First strings
                    LocalizationTool.LoadEmbeddedLocalizationPacks(
                      "Mesmerist.Strings.Archetypes.json",
                      "Mesmerist.Strings.Homebrew.json",
                      "Mesmerist.Strings.Features.json",
                      "Mesmerist.Strings.Settings.json",
                      "Mesmerist.Strings.Spells.json",
                      "Mesmerist.Strings.ClassFeatures.json");

                    // Then settings
                    Settings.Init();
                    ConfigureFeats();
                    ConfigureClasses();
                    ConfigureArchetypes();
                    ConfigureHomebrew();
                    ConfigureSpells();
                }
                catch (Exception e)
                {
                    Logger.LogException("Failed to initialize.", e);
                }
            }
            private static void ConfigureClasses()
            {
                Logger.Log("Configuring classes.");
                MesmeristClass.Configure();
            }
            private static void ConfigureHomebrew()
            {
                MythicAwesomeDisplay.Configure();
                Logger.Log("Configuring homebrew.");
            }
            private static void ConfigureArchetypes()
            {
                Logger.Log("Configuring archetypes.");
                //VexingDaredevil.Configure();
                VexingTrickster.Configure();
            }
            private static void ConfigureClassFeats()
            {
                Logger.Log("Configuring class features.");
                

            }
            private static void ConfigureFeats()
            {
                Logger.Log("Configuring features."); 
                IntensePain.Configure();
                DemoralizingStare.Configure();
                //BleedingStare.Configure();
                ExcoriatingStare.Configure();
                FatiguingStare.Configure();
                //CompoundedPain.Configure();
                BouncingTrick.Configure();
                ReapplyTrick.Configure();
                SpellTrick.Configure();
                TrickFeats.Configure();
                DazzlingFeint.Configure();
                ConsummateTrickster.Configure();
                TrickstersEgo.Configure();
                ManifoldHijinks.Configure();
            }
            private static void ConfigureSpells()
            {
                Logger.Log("Configuring spells.");
            }
            private static void ConfigureFeatsDelayed()
            {
                Logger.Log("Configuring delayed.");
            }
        }
    }
}

