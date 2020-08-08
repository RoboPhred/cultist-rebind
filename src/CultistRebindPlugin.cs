using System.IO;
using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using UnityEngine;

namespace CultistRebind
{
    [BepInPlugin("CultistRebind", "CultistRebind", "1.0.0")]
    public class CultistRebindPlugin : BaseUnityPlugin
    {
        // KeyDown
        public ConfigEntry<KeyboardShortcut> NormalSpeedKey;
        public ConfigEntry<KeyboardShortcut> FastSpeedKey;

        // ButtonPressed
        public ConfigEntry<KeyboardShortcut> PauseKey;
        public ConfigEntry<KeyboardShortcut> CancelKey;
        public ConfigEntry<KeyboardShortcut> StackCardsKey;

        // Axis
        public ConfigEntry<KeyboardShortcut> StartRecipeKey;
        public ConfigEntry<KeyboardShortcut> CollectAllKey;
        public ConfigEntry<KeyboardShortcut> ZoomInKey;
        public ConfigEntry<KeyboardShortcut> ZoomOutKey;
        public ConfigEntry<KeyboardShortcut> ZoomLevel1Key;
        public ConfigEntry<KeyboardShortcut> ZoomLevel2Key;
        public ConfigEntry<KeyboardShortcut> ZoomLevel3Key;
        public ConfigEntry<KeyboardShortcut> MoveLeftKey;
        public ConfigEntry<KeyboardShortcut> MoveRightKey;
        public ConfigEntry<KeyboardShortcut> MoveUpKey;
        public ConfigEntry<KeyboardShortcut> MoveDownKey;


        private static CultistRebindPlugin sInstance;
        public static CultistRebindPlugin Instance
        {
            get
            {
                return sInstance;
            }
        }

        void Start()
        {
            sInstance = this;

            NormalSpeedKey = Config.Bind(new ConfigDefinition("Hotkeys", "NormalSpeedKey"), new KeyboardShortcut(KeyCode.N));
            FastSpeedKey = Config.Bind(new ConfigDefinition("Hotkeys", "FastSpeedKey"), new KeyboardShortcut(KeyCode.M));

            PauseKey = Config.Bind(new ConfigDefinition("Hotkeys", "PauseKey"), new KeyboardShortcut(KeyCode.Space));
            CancelKey = Config.Bind(new ConfigDefinition("Hotkeys", "CancelKey"), new KeyboardShortcut(KeyCode.Escape));
            StackCardsKey = Config.Bind(new ConfigDefinition("Hotkeys", "StackCardsKey"), new KeyboardShortcut(KeyCode.Tab));

            StartRecipeKey = Config.Bind(new ConfigDefinition("Hotkeys", "StartRecipeKey"), new KeyboardShortcut(KeyCode.S));
            CollectAllKey = Config.Bind(new ConfigDefinition("Hotkeys", "CollectAllKey"), new KeyboardShortcut(KeyCode.C));
            ZoomInKey = Config.Bind(new ConfigDefinition("Hotkeys", "ZoomInKey"), new KeyboardShortcut(KeyCode.E));
            ZoomOutKey = Config.Bind(new ConfigDefinition("Hotkeys", "ZoomOutKey"), new KeyboardShortcut(KeyCode.Q));
            ZoomLevel1Key = Config.Bind(new ConfigDefinition("Hotkeys", "ZoomLevel1Key"), new KeyboardShortcut(KeyCode.Alpha1));
            ZoomLevel2Key = Config.Bind(new ConfigDefinition("Hotkeys", "ZoomLevel2Key"), new KeyboardShortcut(KeyCode.Alpha2));
            ZoomLevel3Key = Config.Bind(new ConfigDefinition("Hotkeys", "ZoomLevel3Key"), new KeyboardShortcut(KeyCode.Alpha3));
            MoveLeftKey = Config.Bind(new ConfigDefinition("Hotkeys", "MoveLeftKey"), new KeyboardShortcut(KeyCode.LeftArrow));
            MoveRightKey = Config.Bind(new ConfigDefinition("Hotkeys", "MoveRightKey"), new KeyboardShortcut(KeyCode.RightArrow));
            MoveUpKey = Config.Bind(new ConfigDefinition("Hotkeys", "MoveUpKey"), new KeyboardShortcut(KeyCode.UpArrow));
            MoveDownKey = Config.Bind(new ConfigDefinition("Hotkeys", "MoveDownKey"), new KeyboardShortcut(KeyCode.DownArrow));

            this.Logger.LogInfo("Configuration file is located at " + Config.ConfigFilePath);
            if (!File.Exists(Config.ConfigFilePath))
            {
                Config.Save();
            }


            var harmony = new Harmony("net.robophreddev.CultistSimulator.CultistRebind");
            harmony.PatchAll();
            this.Logger.LogInfo("CultistRebind initialized.");
        }
    }
}