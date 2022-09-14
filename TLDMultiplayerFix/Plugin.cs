using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Emit;

namespace TLDMultiplayerFix
{
    [BepInPlugin("dev.lulu.plugins.tldmpfix", "TLD Multiplayer Fix", PluginInfo.PLUGIN_VERSION)]
    [BepInProcess("TheLongDrive.exe")]
    public class Plugin : BaseUnityPlugin
    {
        private static Plugin Instance = null!;
        private ConfigEntry<float> configPhysicsUpdateRate;

        public Plugin()
        {
            Instance = this;
            configPhysicsUpdateRate = Config.Bind("Sync", "Physics.UpdateRate", 10f, "Physics update rate (Hz)");
        }

        [SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "Called by BepInEx")]
        private void Awake()
        {
            Harmony.CreateAndPatchAll(typeof(Plugin));
            Logger.LogInfo($"Applied patches successfully!");
        }

        [HarmonyPatch(typeof(mountStuff), "Update")]
        [HarmonyTranspiler]
        private static IEnumerable<CodeInstruction> TranspileMountStuffUpdate(IEnumerable<CodeInstruction> instructions)
        {
            foreach (var instruction in instructions)
            {
                if (instruction.opcode == OpCodes.Ldc_R4)
                {
                    float updateRate = 1f / Instance.configPhysicsUpdateRate.Value;
                    instruction.operand = updateRate;
                }

                yield return instruction;
            }
        }
    }
}
