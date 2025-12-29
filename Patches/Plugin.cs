using BepInEx;
using silliness.Patches;
using System;
using System.ComponentModel;
using UnityEngine;
using silliness.Classes;
using static silliness.Mods.SettingsMods;
//using Console = silliness.Classes.Console;

namespace silliness.Patches
{
    [Description(PluginInfo.Description)]
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class HarmonyPatches : BaseUnityPlugin
    {
        private void OnEnable()
        {
            Menu.ApplyHarmonyPatches();
        }

        private void OnDisable()
        {
            Menu.RemoveHarmonyPatches();
        }
        /*void Start() =>
        GorillaTagger.OnPlayerSpawned(OnPlayerSpawned);

        void OnPlayerSpawned()
        {
            string ConsoleGUID = $"goldentrophy_Console_{Console.ConsoleVersion}";
            GameObject ConsoleObject = GameObject.Find(ConsoleGUID);

            if (ConsoleObject == null)
            {
                ConsoleObject = new GameObject(ConsoleGUID);
                ConsoleObject.AddComponent<CoroutineManager>();
                ConsoleObject.AddComponent<Console>();
            }

            if (ServerData.ServerDataEnabled)
                ConsoleObject.AddComponent<ServerData>();
        }*/
    }
}
