﻿using HarmonyLib;
using System;
using System.Reflection;
using UnityModManagerNet;
using Kingmaker.Blueprints.JsonSystem;
using Mesmerist.Class.Mesmerist.Features;
using Mesmerist.Class.Mesmerist.MythicFeature;
using Mesmerist.Class.Mesmerist;
using Mesmerist.Class.Medium;

namespace Mesmerist;

#if DEBUG
[EnableReloading]
#endif
public static class Main {
    internal static Harmony HarmonyInstance;
    internal static UnityModManager.ModEntry.ModLogger log;

    public static bool Load(UnityModManager.ModEntry modEntry) {
        log = modEntry.Logger;
#if DEBUG
        modEntry.OnUnload = OnUnload;
#endif
        modEntry.OnGUI = OnGUI;
        HarmonyInstance = new Harmony(modEntry.Info.Id);
        HarmonyInstance.PatchAll(Assembly.GetExecutingAssembly());
        return true;
    }

    public static void OnGUI(UnityModManager.ModEntry modEntry) {

    }

#if DEBUG
    public static bool OnUnload(UnityModManager.ModEntry modEntry) {
        HarmonyInstance.UnpatchAll(modEntry.Info.Id);
        return true;
    }
#endif
    [HarmonyPatch(typeof(BlueprintsCache))]
    public static class BlueprintsCaches_Patch {
        private static bool Initialized = false;

        [HarmonyPriority(Priority.First)]
        [HarmonyPatch(nameof(BlueprintsCache.Init)), HarmonyPostfix]
        public static void Init_Postfix() {
            try {
                if (Initialized) {
                    log.Log("Already initialized blueprints cache.");
                    return;
                }
                Initialized = true;

                log.Log("Patching blueprints.");
                // Insert your mod's patching methods here
                MesmeristClass.Configure();
                //BleedingStare.Configure();
                //CompoundedPain.Configure();
                DemoralizingStare.Configure();
                ExcoriatingStare.Configure();
                FatiguingStare.Configure();
                IntensePain.Configure();
                MythicAwesomeDisplay.Configure();

                //MediumClass.Configure();
                
            } catch (Exception e) {
                log.Log(string.Concat("Failed to initialize.", e));
            }
        }
    }
}
