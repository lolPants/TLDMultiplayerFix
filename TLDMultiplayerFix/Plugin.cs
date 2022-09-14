using BepInEx;
using BepInEx.Configuration;

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

        private void Awake()
        {

        }
    }
}
