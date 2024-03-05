using BepInEx;
using HarmonyLib;
using System.Reflection;
using UnityEngine;

namespace NoAbiltySpawn
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, "No Abilty Spawn", PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            // Plugin startup logic
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
            Harmony harmony = new Harmony("com.Diggity.NoAbilitySpawn");
            MethodBase original = AccessTools.Method(typeof(AbilitySpawner), "Awake");
            harmony.Patch(original, new HarmonyMethod(AccessTools.Method(typeof(myPatches), "NoAbilitySpawn")));
        }
    }
    public class myPatches
    {
        public static bool NoAbilitySpawn(AbilitySpawner __instance)
        {
            __instance.enabled = false;
            return false;
        }

    }
}
