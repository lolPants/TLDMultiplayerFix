using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using System.Diagnostics.CodeAnalysis;

namespace TLDMultiplayerFix
{
    [BepInPlugin("dev.lulu.plugins.tldmpfix", "TLD Multiplayer Fix", PluginInfo.PLUGIN_VERSION)]
    [BepInProcess("TheLongDrive.exe")]
    public class Plugin : BaseUnityPlugin
    {
        private ConfigEntry<float> configPhysicsUpdateRate;

        public Plugin()
        {
            configPhysicsUpdateRate = Config.Bind("Sync", "Physics.UpdateRate", 10f, "Physics update rate (Hz)");
        }

        [SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "Called by BepInEx")]
        private void Awake()
        {
            Harmony.CreateAndPatchAll(typeof(Plugin));
            Logger.LogInfo($"Applied patches successfully!");
        }
    }
}
