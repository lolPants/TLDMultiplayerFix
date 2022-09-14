using BepInEx;

namespace TLDMultiplayerFix
{
    [BepInPlugin("dev.lulu.plugins.tldmpfix", "TLD Multiplayer Fix", PluginInfo.PLUGIN_VERSION)]
    [BepInProcess("TheLongDrive.exe")]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {

        }
    }
}
