using BlueprintCore.Utils;
using CharacterOptionsPlus.Util;
using Kingmaker.Blueprints;
using Kingmaker.Localization;
using ModMenu.Settings;
using System.Linq;
using UnityEngine;
using UnityModManagerNet;
using static UnityModManagerNet.UnityModManager.ModEntry;
using Menu = ModMenu.ModMenu;


/* Taken directly from CharacterOptionsPlus. See: https://github.com/WittleWolfie/CharacterOptionsPlus */
/* Credit goes to WittleWolfie */
namespace Mesmerist.Utils
{
    internal static class Settings
    {
        private static readonly string RootKey = "mesmserist.settings";

        private static readonly Logging.Logger Logger = Logging.GetLogger(nameof(Settings));

        internal static bool IsEnabled(string key)
        {
            return Menu.GetSettingValue<bool>(GetKey(key));
        }

        internal static bool IsTTTBaseEnabled()
        {
            return UnityModManager.modEntries.Where(
                mod => mod.Info.Id.Equals("TabletopTweaks-Base") && mod.Enabled && !mod.ErrorOnLoading)
              .Any();
        }

        internal static void Init()
        {
            Logger.Log("Initializing settings.");
            var settings =
              SettingsBuilder.New(RootKey, GetString("Settings.Title"))
                //.AddImage(ResourcesLibrary.TryGetResource<Sprite>("assets/illustrations/wolfie.png"), height: 200, imageScale: 0.75f)
                .AddDefaultButton(OnDefaultsApplied);

            settings.AddSubHeader(GetString("Settings.Classes.Title"));
            foreach (var (guid, name) in Guids.Classes)
            {
                settings.AddToggle(
                  Toggle.New(GetKey(guid), defaultValue: true, GetString(name))
                    .WithLongDescription(GetString("Settings.EnableFeature")));
            }

            settings.AddSubHeader(GetString("Settings.Homebrew.Title"));
            foreach (var (guid, name) in Guids.Homebrews)
            {
                settings.AddToggle(
                  Toggle.New(GetKey(guid), defaultValue: true, GetString(name))
                    .WithLongDescription(GetString("Settings.EnableFeature")));
            }

            settings.AddSubHeader(GetString("Settings.Feats.Title"));
            foreach (var (guid, name) in Guids.Features)
            {
                settings.AddToggle(
                  Toggle.New(GetKey(guid), defaultValue: true, GetString(name))
                    .WithLongDescription(GetString("Settings.EnableFeature")));
            }

            settings.AddSubHeader(GetString("Settings.Spells.Title"));
            foreach (var (guid, name) in Guids.Spells)
            {
                settings.AddToggle(
                  Toggle.New(GetKey(guid), defaultValue: true, GetString(name))
                    .WithLongDescription(GetString("Settings.EnableFeature")));
            }

            Menu.AddSettings(settings);
        }

        private static void OnDefaultsApplied()
        {
            Logger.Log($"Default settings restored.");
        }

        private static LocalizedString GetString(string key)
        {
            return LocalizationTool.GetString(key);
        }

        private static string GetKey(string partialKey)
        {
            return $"{RootKey}.{partialKey}";
        }
    }
}