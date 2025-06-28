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

namespace silliness.Menu
{
    internal class Customization
    {
        public static ExtGradient bgColors = new ExtGradient { colors = GetMultiGradient(bgColorsA, bgColorsB) }; // Background Colors
        public static ExtGradient titleColors = new ExtGradient { colors = GetMultiGradient(titleColorsA, titleColorsB) }; // Background Colors
        public static ExtGradient[] btColors = new ExtGradient[]
        {
            new ExtGradient{ colors = GetMultiGradient(btDefaultA, btDefaultB) }, // Disabled Button Colors
            new ExtGradient{ colors = GetMultiGradient(btClickedA, btClickedB) } // Enabled Button Colors
        };
        public static ExtGradient[] txtColors = new ExtGradient[]
        {
            new ExtGradient{ colors = GetMultiGradient(txtDefaultA, txtDefaultB) }, // Disabled Text Colors
            new ExtGradient{ colors = GetMultiGradient(txtClickedA, txtClickedB) } // Enabled Text Colors
        };

        public static Font currentFont = sans;

        public static bool fpsCounter = true;
        public static bool disconnectButton = true;
        public static bool rightHanded = false;
        public static bool disableNotifications = false;
        public static bool shouldOutline = true;
        public static bool customMenuNameActivated = false;
        public static bool highQualityText = false;
        public static bool overflowText = false;

        public static KeyCode keyboardButton = KeyCode.Q;

        public static Vector3 menuSize = new Vector3(0.1f, 1f, 1f); // Depth, Width, Height
        public static int buttonsPerPage = 9;

        public static void EnableOutlines()
        {
            shouldOutline = true;
        }
        public static void DisableOutlines()
        {
            shouldOutline = false;
        }
        public static void EnableHQText()
        {
            highQualityText = true;
        }
        public static void DisableHQText()
        {
            highQualityText = false;
        }
        public static void EnableOverflowText()
        {
            overflowText = true;
        }
        public static void DisableOverflowText()
        {
            overflowText = false;
        }
        public static void CustomMenuName()
        {
            customMenuNameActivated = true;
            if (!File.Exists("silliness/CustomMenuName.txt"))
                File.WriteAllText("silliness/CustomMenuName.txt", "your text here");

            customMenuName = File.ReadAllText("silliness/CustomMenuName.txt");
        }
        public static void DoNotCustomMenuName()
        {
            customMenuNameActivated = false;
        }
        public static void ChangeThemeTypeForwards()
        {
            themeType++;
            if (themeType > 5)
            {
                themeType = 1;
            }
            switch (themeType)
            {
                case 1: // Main
                    GetIndex("theme: [Main] [1]").overlapText = "theme: [Main] [1]";
                    bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(255, 186, 251, 255), new Color32(255, 204, 253, 255)) };
                    titleColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) };
                    btColors = new ExtGradient[]
                    {
                        new ExtGradient{ colors = GetMultiGradient(new Color32(255, 186, 251, 255), new Color32(255, 204, 253, 255)) },
                        new ExtGradient{ colors = GetMultiGradient(new Color32(255, 136, 249, 255), new Color32(255, 136, 249, 255)) }
                    };
                    txtColors = new ExtGradient[]
                    {
                        new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) },
                        new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) }
                    };
                    return;
                case 2: // Midnight (Originally made by Bando, fixed by me)
                    GetIndex("theme: [Main] [1]").overlapText = "theme: [Midnight] [2]";
                    bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(1, 0, 62, 255), new Color32(2, 0, 93, 255)) };
                    titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(127, 124, 255, 255), new Color32(127, 124, 255, 255)) };
                    btColors = new ExtGradient[]
                    {
                        new ExtGradient{ colors = GetMultiGradient(new Color32(1, 0, 53, 255), new Color32(1, 0, 43, 255)) },
                        new ExtGradient{ colors = GetMultiGradient(new Color32(4, 0, 170, 255), new Color32(4, 0, 190, 255)) }
                    };
                    txtColors = new ExtGradient[]
                    {
                        new ExtGradient { colors = GetMultiGradient(new Color32(127, 124, 255, 255), new Color32(127, 124, 255, 255)) },
                        new ExtGradient { colors = GetMultiGradient(new Color32(2, 0, 94, 255), new Color32(2, 0, 94, 255)) }
                    };
                    return;
                case 3: // SNES
                    GetIndex("theme: [Main] [1]").overlapText = "theme: [SNES] [3]";
                    bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(188, 188, 198, 255), new Color32(166, 166, 175, 255)) };
                    titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(220, 226, 240, 255), new Color32(220, 226, 240, 255)) };
                    btColors = new ExtGradient[]
                    {
                        new ExtGradient{ colors = GetMultiGradient(new Color32(99, 80, 183, 255), new Color32(80, 72, 165, 255)) },
                        new ExtGradient{ colors = GetMultiGradient(new Color32(169, 167, 215, 255), new Color32(152, 150, 193, 255)) }
                    };
                    txtColors = new ExtGradient[]
                    {
                        new ExtGradient { colors = GetMultiGradient(new Color32(220, 226, 240, 255), new Color32(220, 226, 240, 255)) },
                        new ExtGradient { colors = GetMultiGradient(new Color32(220, 226, 240, 255), new Color32(220, 226, 240, 255)) }
                    };
                    return;
                case 4: // Folly
                    GetIndex("theme: [Main] [1]").overlapText = "theme: [Folly] [4]";
                    bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(10, 0, 3, 255), new Color32(14, 0, 4, 255)) };
                    titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(255, 0, 79, 255), new Color32(252, 0, 78, 255)) };
                    btColors = new ExtGradient[]
                    {
                        new ExtGradient{ colors = GetMultiGradient(new Color32(10, 0, 3, 255), new Color32(14, 0, 4, 255)) },
                        new ExtGradient{ colors = GetMultiGradient(new Color32(255, 0, 79, 255), new Color32(252, 0, 78, 255)) }
                    };
                    txtColors = new ExtGradient[]
                    {
                        new ExtGradient { colors = GetMultiGradient(new Color32(255, 0, 79, 255), new Color32(252, 0, 78, 255)) },
                        new ExtGradient { colors = GetMultiGradient(new Color32(10, 0, 3, 255), new Color32(14, 0, 4, 255)) }
                    };
                    return;
                case 5: // ii's Stupid Menu
                    GetIndex("theme: [Main] [1]").overlapText = "theme: [ii's Stupid Menu] [5]";
                    bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(255, 128, 0, 128), new Color32(255, 102, 0, 128)) };
                    titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(255, 190, 125, 255), new Color32(255, 190, 125, 255)) };
                    btColors = new ExtGradient[]
                    {
                        new ExtGradient{ colors = GetMultiGradient(new Color32(170, 85, 0, 255), new Color32(170, 85, 0, 255)) },
                        new ExtGradient{ colors = GetMultiGradient(new Color32(85, 42, 0, 255), new Color32(85, 42, 0, 255)) }
                    };
                    txtColors = new ExtGradient[]
                    {
                        new ExtGradient { colors = GetMultiGradient(new Color32(255, 190, 125, 255), new Color32(255, 190, 125, 255)) },
                        new ExtGradient { colors = GetMultiGradient(new Color32(255, 190, 125, 255), new Color32(255, 190, 125, 255)) }
                    };
                    return;
            }
        }
        public static void ChangeThemeTypeBackwards()
        {
            themeType--;
            if (themeType < 1)
            {
                themeType = 5;
            }
            switch (themeType)
            {
                case 1: // Main
                    GetIndex("theme: [Main] [1]").overlapText = "theme: [Main] [1]";
                    bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(255, 186, 251, 255), new Color32(255, 204, 253, 255)) };
                    titleColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) };
                    btColors = new ExtGradient[]
                    {
                        new ExtGradient{ colors = GetMultiGradient(new Color32(255, 186, 251, 255), new Color32(255, 204, 253, 255)) },
                        new ExtGradient{ colors = GetMultiGradient(new Color32(255, 136, 249, 255), new Color32(255, 136, 249, 255)) }
                    };
                    txtColors = new ExtGradient[]
                    {
                        new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) },
                        new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) }
                    };
                    return;
                case 2: // Midnight (Originally made by Bando, fixed by me)
                    GetIndex("theme: [Main] [1]").overlapText = "theme: [Midnight] [2]";
                    bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(1, 0, 62, 255), new Color32(2, 0, 93, 255)) };
                    titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(127, 124, 255, 255), new Color32(127, 124, 255, 255)) };
                    btColors = new ExtGradient[]
                    {
                        new ExtGradient{ colors = GetMultiGradient(new Color32(1, 0, 53, 255), new Color32(1, 0, 43, 255)) },
                        new ExtGradient{ colors = GetMultiGradient(new Color32(4, 0, 170, 255), new Color32(4, 0, 190, 255)) }
                    };
                    txtColors = new ExtGradient[]
                    {
                        new ExtGradient { colors = GetMultiGradient(new Color32(127, 124, 255, 255), new Color32(127, 124, 255, 255)) },
                        new ExtGradient { colors = GetMultiGradient(new Color32(2, 0, 94, 255), new Color32(2, 0, 94, 255)) }
                    };
                    return;
                case 3: // SNES
                    GetIndex("theme: [Main] [1]").overlapText = "theme: [SNES] [3]";
                    bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(188, 188, 198, 255), new Color32(166, 166, 175, 255)) };
                    titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(220, 226, 240, 255), new Color32(220, 226, 240, 255)) };
                    btColors = new ExtGradient[]
                    {
                        new ExtGradient{ colors = GetMultiGradient(new Color32(99, 80, 183, 255), new Color32(80, 72, 165, 255)) },
                        new ExtGradient{ colors = GetMultiGradient(new Color32(169, 167, 215, 255), new Color32(152, 150, 193, 255)) }
                    };
                    txtColors = new ExtGradient[]
                    {
                        new ExtGradient { colors = GetMultiGradient(new Color32(220, 226, 240, 255), new Color32(220, 226, 240, 255)) },
                        new ExtGradient { colors = GetMultiGradient(new Color32(220, 226, 240, 255), new Color32(220, 226, 240, 255)) }
                    };
                    return;
                case 4: // Folly
                    GetIndex("theme: [Main] [1]").overlapText = "theme: [Folly] [4]";
                    bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(10, 0, 3, 255), new Color32(14, 0, 4, 255)) };
                    titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(255, 0, 79, 255), new Color32(252, 0, 78, 255)) };
                    btColors = new ExtGradient[]
                    {
                        new ExtGradient{ colors = GetMultiGradient(new Color32(10, 0, 3, 255), new Color32(14, 0, 4, 255)) },
                        new ExtGradient{ colors = GetMultiGradient(new Color32(255, 0, 79, 255), new Color32(252, 0, 78, 255)) }
                    };
                    txtColors = new ExtGradient[]
                    {
                        new ExtGradient { colors = GetMultiGradient(new Color32(255, 0, 79, 255), new Color32(252, 0, 78, 255)) },
                        new ExtGradient { colors = GetMultiGradient(new Color32(10, 0, 3, 255), new Color32(14, 0, 4, 255)) }
                    };
                    return;
                case 5: // ii's Stupid Menu
                    GetIndex("theme: [Main] [1]").overlapText = "theme: [ii's Stupid Menu] [5]";
                    bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(255, 128, 0, 128), new Color32(255, 102, 0, 128)) };
                    titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(255, 190, 125, 255), new Color32(255, 190, 125, 255)) };
                    btColors = new ExtGradient[]
                    {
                        new ExtGradient{ colors = GetMultiGradient(new Color32(170, 85, 0, 255), new Color32(170, 85, 0, 255)) },
                        new ExtGradient{ colors = GetMultiGradient(new Color32(85, 42, 0, 255), new Color32(85, 42, 0, 255)) }
                    };
                    txtColors = new ExtGradient[]
                    {
                        new ExtGradient { colors = GetMultiGradient(new Color32(255, 190, 125, 255), new Color32(255, 190, 125, 255)) },
                        new ExtGradient { colors = GetMultiGradient(new Color32(255, 190, 125, 255), new Color32(255, 190, 125, 255)) }
                    };
                    return;
            }
        }
        public static void ChangeFontTypeBackwards()
        {
            fontType--;
            if (fontType < 0) // to get the number of fonts exactly, add 1 onto this number
            {
                fontType = 26;
            }

            switch (fontType)
            {
                case 0:
                    GetIndex("font: [Comic Sans] [1]").overlapText = "font: [Comic Sans] [1]";
                    currentFont = sans;
                    return;
                case 1:
                    GetIndex("font: [Comic Sans] [1]").overlapText = "font: [Arial] [2]";
                    currentFont = Arial;
                    return;
                case 2:
                    GetIndex("font: [Comic Sans] [1]").overlapText = "font: [Berdana] [3]";
                    currentFont = Verdana;
                    return;
                case 3:
                    GetIndex("font: [Comic Sans] [1]").overlapText = "font: [Consolas] [5]";
                    currentFont = consolas;
                    return;
                case 4:
                    GetIndex("font: [Comic Sans] [1]").overlapText = "font: [Ubuntu] [6]";
                    currentFont = ubuntu;
                    return;
                case 5:
                    GetIndex("font: [Comic Sans] [1]").overlapText = "font: [msgothic] [7]";
                    currentFont = MSGOTHIC;
                    return;
                case 6:
                    GetIndex("font: [Comic Sans] [1]").overlapText = "font: [impact] [8]";
                    currentFont = impact;
                    return;
                case 7:
                    GetIndex("font: [Comic Sans] [1]").overlapText = "font: [bahnschrift] [9]";
                    currentFont = bahnschrift;
                    return;
                case 8:
                    GetIndex("font: [Comic Sans] [1]").overlapText = "font: [calibri] [10]";
                    currentFont = calibri;
                    return;
                case 9:
                    GetIndex("font: [Comic Sans] [1]").overlapText = "font: [cambria] [11]";
                    currentFont = cambria;
                    return;
                case 10:
                    GetIndex("font: [Comic Sans] [1]").overlapText = "font: [cascadia code] [12]";
                    currentFont = cascadiacode;
                    return;
                case 11:
                    GetIndex("font: [Comic Sans] [1]").overlapText = "font: [constantia] [13]";
                    currentFont = constantia;
                    return;
                case 12:
                    GetIndex("font: [Comic Sans] [1]").overlapText = "font: [corbel] [14]";
                    currentFont = corbel;
                    return;
                case 13:
                    GetIndex("font: [Comic Sans] [1]").overlapText = "font: [courier new] [15]";
                    currentFont = couriernew;
                    return;
                case 14:
                    GetIndex("font: [Comic Sans] [1]").overlapText = "font: [dengxian] [16]";
                    currentFont = dengxian;
                    return;
                case 15:
                    GetIndex("font: [Comic Sans] [1]").overlapText = "font: [ebrima] [17]";
                    currentFont = ebrima;
                    return;
                case 16:
                    GetIndex("font: [Comic Sans] [1]").overlapText = "font: [fangsong] [18]";
                    currentFont = fangsong;
                    return;
                case 17:
                    GetIndex("font: [Comic Sans] [1]").overlapText = "font: [franklin gothic] [19]";
                    currentFont = franklingothic;
                    return;
                case 18:
                    GetIndex("font: [Comic Sans] [1]").overlapText = "font: [gabriola] [20]";
                    currentFont = gabriola;
                    return;
                case 19:
                    GetIndex("font: [Comic Sans] [1]").overlapText = "font: [gadugi] [21]";
                    currentFont = gadugi;
                    return;
                case 20:
                    GetIndex("font: [Comic Sans] [1]").overlapText = "font: [georgia] [22]";
                    currentFont = georgia;
                    return;
                case 21:
                    GetIndex("font: [Comic Sans] [1]").overlapText = "font: [hololens] [23]";
                    currentFont = hololens;
                    return;
                case 22:
                    GetIndex("font: [Comic Sans] [1]").overlapText = "font: [ink free] [24]";
                    currentFont = inkfree;
                    return;
                case 23:
                    GetIndex("font: [Comic Sans] [1]").overlapText = "font: [javanese text] [25]";
                    currentFont = javanesetext;
                    return;
                case 24:
                    GetIndex("font: [Comic Sans] [1]").overlapText = "font: [kaiti] [26]";
                    currentFont = kaiti;
                    return;
                case 25:
                    GetIndex("font: [Comic Sans] [1]").overlapText = "font: [lucida console] [27]";
                    currentFont = lucidaconsole;
                    return;
            }
        }
        public static void ChangeFontTypeForwards()
        {
            fontType++;
            if (fontType > 26) // to get the number of fonts exactly, add 1 onto this number
            {
                fontType = 0;
            }

            switch (fontType)
            {
                case 0:
                    GetIndex("font: [Comic Sans] [1]").overlapText = "font: [Comic Sans] [1]";
                    currentFont = sans;
                    return;
                case 1:
                    GetIndex("font: [Comic Sans] [1]").overlapText = "font: [Arial] [2]";
                    currentFont = Arial;
                    return;
                case 2:
                    GetIndex("font: [Comic Sans] [1]").overlapText = "font: [Berdana] [3]";
                    currentFont = Verdana;
                    return;
                case 3:
                    GetIndex("font: [Comic Sans] [1]").overlapText = "font: [Consolas] [5]";
                    currentFont = consolas;
                    return;
                case 4:
                    GetIndex("font: [Comic Sans] [1]").overlapText = "font: [Ubuntu] [6]";
                    currentFont = ubuntu;
                    return;
                case 5:
                    GetIndex("font: [Comic Sans] [1]").overlapText = "font: [msgothic] [7]";
                    currentFont = MSGOTHIC;
                    return;
                case 6:
                    GetIndex("font: [Comic Sans] [1]").overlapText = "font: [impact] [8]";
                    currentFont = impact;
                    return;
                case 7:
                    GetIndex("font: [Comic Sans] [1]").overlapText = "font: [bahnschrift] [9]";
                    currentFont = bahnschrift;
                    return;
                case 8:
                    GetIndex("font: [Comic Sans] [1]").overlapText = "font: [calibri] [10]";
                    currentFont = calibri;
                    return;
                case 9:
                    GetIndex("font: [Comic Sans] [1]").overlapText = "font: [cambria] [11]";
                    currentFont = cambria;
                    return;
                case 10:
                    GetIndex("font: [Comic Sans] [1]").overlapText = "font: [cascadia code] [12]";
                    currentFont = cascadiacode;
                    return;
                case 11:
                    GetIndex("font: [Comic Sans] [1]").overlapText = "font: [constantia] [13]";
                    currentFont = constantia;
                    return;
                case 12:
                    GetIndex("font: [Comic Sans] [1]").overlapText = "font: [corbel] [14]";
                    currentFont = corbel;
                    return;
                case 13:
                    GetIndex("font: [Comic Sans] [1]").overlapText = "font: [courier new] [15]";
                    currentFont = couriernew;
                    return;
                case 14:
                    GetIndex("font: [Comic Sans] [1]").overlapText = "font: [dengxian] [16]";
                    currentFont = dengxian;
                    return;
                case 15:
                    GetIndex("font: [Comic Sans] [1]").overlapText = "font: [ebrima] [17]";
                    currentFont = ebrima;
                    return;
                case 16:
                    GetIndex("font: [Comic Sans] [1]").overlapText = "font: [fangsong] [18]";
                    currentFont = fangsong;
                    return;
                case 17:
                    GetIndex("font: [Comic Sans] [1]").overlapText = "font: [franklin gothic] [19]";
                    currentFont = franklingothic;
                    return;
                case 18:
                    GetIndex("font: [Comic Sans] [1]").overlapText = "font: [gabriola] [20]";
                    currentFont = gabriola;
                    return;
                case 19:
                    GetIndex("font: [Comic Sans] [1]").overlapText = "font: [gadugi] [21]";
                    currentFont = gadugi;
                    return;
                case 20:
                    GetIndex("font: [Comic Sans] [1]").overlapText = "font: [georgia] [22]";
                    currentFont = georgia;
                    return;
                case 21:
                    GetIndex("font: [Comic Sans] [1]").overlapText = "font: [hololens] [23]";
                    currentFont = hololens;
                    return;
                case 22:
                    GetIndex("font: [Comic Sans] [1]").overlapText = "font: [ink free] [24]";
                    currentFont = inkfree;
                    return;
                case 23:
                    GetIndex("font: [Comic Sans] [1]").overlapText = "font: [javanese text] [25]";
                    currentFont = javanesetext;
                    return;
                case 24:
                    GetIndex("font: [Comic Sans] [1]").overlapText = "font: [kaiti] [26]";
                    currentFont = kaiti;
                    return;
                case 25:
                    GetIndex("font: [Comic Sans] [1]").overlapText = "font: [lucida console] [27]";
                    currentFont = lucidaconsole;
                    return;
            }
        }
    }
}
