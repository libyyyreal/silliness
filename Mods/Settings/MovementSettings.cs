using BepInEx;
using HarmonyLib;
using Oculus.Platform;
using Photon.Pun;
using silliness;
using silliness.Classes;
using silliness.Mods;
using silliness.Notifications;
using System;
using System.Windows.Input;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.XR;
using static silliness.Menu.Buttons;
using static silliness.Menu.Customization;
using static silliness.Classes.ButtonInfo;
using static silliness.Classes.RigManager;
using static silliness.Mods.SettingsMods;
using static silliness.Classes.ColorChanger;
using ExitGames.Client.Photon;
using GorillaNetworking;
using Photon.Realtime;
using PlayFab.ExperimentationModels;
using System.Collections.Generic;
using UnityEngine.Networking;
using Photon.Voice.Unity;
using GorillaTag;
using static silliness.Menu.Main;
using UnityEngine.InputSystem.Controls;

namespace silliness.Mods.Settings
{
    internal class MovementSettings
    {
        public static float FlySpeed;
        public static int flyType = 3;
        public static void ChangeFlySpeed()
        {
            flyType++;
            if (flyType > 5) // very slow, slow, normal, fast, very fast
            {
                flyType = 1;
            }
            switch (flyType)
            {
                case 1:
                    GetIndex("Change Fly Speed [Normal]").overlapText = "Change Fly Speed [Very Slow]";
                    FlySpeed = 1f;
                    break;
                case 2:
                    GetIndex("Change Fly Speed [Normal]").overlapText = "Change Fly Speed [Slow]";
                    FlySpeed = 2f;
                    break;
                case 3:
                    GetIndex("Change Fly Speed [Normal]").overlapText = "Change Fly Speed [Normal]";
                    FlySpeed = 4f;
                    break;
                case 4:
                    GetIndex("Change Fly Speed [Normal]").overlapText = "Change Fly Speed [Fast]";
                    FlySpeed = 8f;
                    break;
                case 5:
                    GetIndex("Change Fly Speed [Normal]").overlapText = "Change Fly Speed [Very Fast]";
                    FlySpeed = 16f;
                    break;
            }
        }

        public static float JM;
        public static float MJS;
        public static int speedboostType = 1;
        public static void ChangeSpeedboostSpeed()
        {
            speedboostType++;
            if (speedboostType > 5) // normal, fast, faster, high, why
            {
                speedboostType = 1;
            }
            switch (speedboostType)
            {
                case 1:
                    GetIndex("Change Speedboost [Normal]").overlapText = "Change Speedboost [Normal]";
                    JM = 2f;
                    MJS = 9f;
                    break;
                case 2:
                    GetIndex("Change Speedboost [Normal]").overlapText = "Change Speedboost [Fast]";
                    JM = 2.5f;
                    MJS = 11.25f;
                    break;
                case 3:
                    GetIndex("Change Speedboost [Normal]").overlapText = "Change Speedboost [Faster]";
                    JM = 3f;
                    MJS = 13.5f;
                    break;
                case 4:
                    GetIndex("Change Speedboost [Normal]").overlapText = "Change Speedboost [High]";
                    JM = 4f;
                    MJS = 18f;
                    break;
                case 5:
                    GetIndex("Change Speedboost [Normal]").overlapText = "Change Speedboost [Why]";
                    JM = 6f;
                    MJS = 27f;
                    break;
            }
        }
    }
}
