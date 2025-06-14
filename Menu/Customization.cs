using silliness.Classes;
using UnityEngine;
using static silliness.Menu.Main;

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
        public static void ChangeThemeTypeForwards()
        {
            themeType++;
            if (themeType > 2)
            {
                themeType = 1;
            }
            switch (themeType)
            {
                case 1: // Main
                    GetIndex("theme: [main] [1]").overlapText = "theme: [main] [1]";
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
                    }
                    ;
                    return;
                case 2: // ii's Stupid Menu
                    GetIndex("theme: [main] [1]").overlapText = "theme: [ii's stupid menu] [2]";
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
                    }
                    ;
                    return;
            }
        }
        public static void ChangeThemeTypeBackwards()
        {
            themeType--;
            if (themeType < 1)
            {
                themeType = 2;
            }
            switch (themeType)
            {
                case 1: // Main
                    GetIndex("theme: [main] [1]").overlapText = "theme: [main] [1]";
                    bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(255, 186, 251, 255), new Color32(255, 214, 253, 255)) };
                    titleColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) };
                    btColors = new ExtGradient[]
                    {
                        new ExtGradient{ colors = GetMultiGradient(new Color32(255, 178, 251, 255), new Color32(255, 178, 251, 255)) },
                        new ExtGradient{ colors = GetMultiGradient(new Color32(255, 136, 249, 255), new Color32(255, 136, 249, 255)) }
                    };
                    txtColors = new ExtGradient[]
                    {
                        new ExtGradient { colors = GetMultiGradient(txtDefaultA, txtDefaultB) },
                        new ExtGradient { colors = GetMultiGradient(txtClickedA, txtClickedB) }
                    }
                    ;
                    return;
                case 2: // Test
                    GetIndex("theme: [main] [1]").overlapText = "theme: [test] [2]";
                    bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(255, 255, 255, 255), new Color32(255, 255, 255, 255)) };
                    titleColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) };
                    btColors = new ExtGradient[]
                    {
                        new ExtGradient{ colors = GetMultiGradient(new Color32(255, 255, 255, 255), new Color32(255, 255, 255, 255)) },
                        new ExtGradient{ colors = GetMultiGradient(new Color32(255, 255, 255, 255), new Color32(255, 255, 255, 255)) }
                    };
                    txtColors = new ExtGradient[]
                    {
                        new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) },
                        new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) }
                    }
                    ;
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
                    GetIndex("font: [comic sans] [1]").overlapText = "font: [comic sans] [1]";
                    currentFont = sans;
                    return;
                case 1:
                    GetIndex("font: [comic sans] [1]").overlapText = "font: [arial] [2]";
                    currentFont = Arial;
                    return;
                case 2:
                    GetIndex("font: [comic sans] [1]").overlapText = "font: [verdana] [3]";
                    currentFont = Verdana;
                    return;
                case 3:
                    GetIndex("font: [comic sans] [1]").overlapText = "font: [agency] [4]";
                    currentFont = agency;
                    return;
                case 4:
                    GetIndex("font: [comic sans] [1]").overlapText = "font: [consolas] [5]";
                    currentFont = consolas;
                    return;
                case 5:
                    GetIndex("font: [comic sans] [1]").overlapText = "font: [ubuntu] [6]";
                    currentFont = ubuntu;
                    return;
                case 6:
                    GetIndex("font: [comic sans] [1]").overlapText = "font: [msgothic] [7]";
                    currentFont = MSGOTHIC;
                    return;
                case 7:
                    GetIndex("font: [comic sans] [1]").overlapText = "font: [impact] [8]";
                    currentFont = impact;
                    return;
                case 8:
                    GetIndex("font: [comic sans] [1]").overlapText = "font: [bahnschrift] [9]";
                    currentFont = bahnschrift;
                    return;
                case 9:
                    GetIndex("font: [comic sans] [1]").overlapText = "font: [calibri] [10]";
                    currentFont = calibri;
                    return;
                case 10:
                    GetIndex("font: [comic sans] [1]").overlapText = "font: [cambria] [11]";
                    currentFont = cambria;
                    return;
                case 11:
                    GetIndex("font: [comic sans] [1]").overlapText = "font: [cascadia code] [12]";
                    currentFont = cascadiacode;
                    return;
                case 12:
                    GetIndex("font: [comic sans] [1]").overlapText = "font: [constantia] [13]";
                    currentFont = constantia;
                    return;
                case 13:
                    GetIndex("font: [comic sans] [1]").overlapText = "font: [corbel] [14]";
                    currentFont = corbel;
                    return;
                case 14:
                    GetIndex("font: [comic sans] [1]").overlapText = "font: [courier new] [15]";
                    currentFont = couriernew;
                    return;
                case 15:
                    GetIndex("font: [comic sans] [1]").overlapText = "font: [dengxian] [16]";
                    currentFont = dengxian;
                    return;
                case 16:
                    GetIndex("font: [comic sans] [1]").overlapText = "font: [ebrima] [17]";
                    currentFont = ebrima;
                    return;
                case 17:
                    GetIndex("font: [comic sans] [1]").overlapText = "font: [fangsong] [18]";
                    currentFont = fangsong;
                    return;
                case 18:
                    GetIndex("font: [comic sans] [1]").overlapText = "font: [franklin gothic] [19]";
                    currentFont = franklingothic;
                    return;
                case 19:
                    GetIndex("font: [comic sans] [1]").overlapText = "font: [gabriola] [20]";
                    currentFont = gabriola;
                    return;
                case 20:
                    GetIndex("font: [comic sans] [1]").overlapText = "font: [gadugi] [21]";
                    currentFont = gadugi;
                    return;
                case 21:
                    GetIndex("font: [comic sans] [1]").overlapText = "font: [georgia] [22]";
                    currentFont = georgia;
                    return;
                case 22:
                    GetIndex("font: [comic sans] [1]").overlapText = "font: [hololens] [23]";
                    currentFont = hololens;
                    return;
                case 23:
                    GetIndex("font: [comic sans] [1]").overlapText = "font: [ink free] [24]";
                    currentFont = inkfree;
                    return;
                case 24:
                    GetIndex("font: [comic sans] [1]").overlapText = "font: [javanese text] [25]";
                    currentFont = javanesetext;
                    return;
                case 25:
                    GetIndex("font: [comic sans] [1]").overlapText = "font: [kaiti] [26]";
                    currentFont = kaiti;
                    return;
                case 26:
                    GetIndex("font: [comic sans] [1]").overlapText = "font: [lucida console] [27]";
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
                    GetIndex("font: [comic sans] [1]").overlapText = "font: [comic sans] [1]";
                    currentFont = sans;
                    return;
                case 1:
                    GetIndex("font: [comic sans] [1]").overlapText = "font: [arial] [2]";
                    currentFont = Arial;
                    return;
                case 2:
                    GetIndex("font: [comic sans] [1]").overlapText = "font: [verdana] [3]";
                    currentFont = Verdana;
                    return;
                case 3:
                    GetIndex("font: [comic sans] [1]").overlapText = "font: [agency] [4]";
                    currentFont = agency;
                    return;
                case 4:
                    GetIndex("font: [comic sans] [1]").overlapText = "font: [consolas] [5]";
                    currentFont = consolas;
                    return;
                case 5:
                    GetIndex("font: [comic sans] [1]").overlapText = "font: [ubuntu] [6]";
                    currentFont = ubuntu;
                    return;
                case 6:
                    GetIndex("font: [comic sans] [1]").overlapText = "font: [msgothic] [7]";
                    currentFont = MSGOTHIC;
                    return;
                case 7:
                    GetIndex("font: [comic sans] [1]").overlapText = "font: [impact] [8]";
                    currentFont = impact;
                    return;
                case 8:
                    GetIndex("font: [comic sans] [1]").overlapText = "font: [bahnschrift] [9]";
                    currentFont = bahnschrift;
                    return;
                case 9:
                    GetIndex("font: [comic sans] [1]").overlapText = "font: [calibri] [10]";
                    currentFont = calibri;
                    return;
                case 10:
                    GetIndex("font: [comic sans] [1]").overlapText = "font: [cambria] [11]";
                    currentFont = cambria;
                    return;
                case 11:
                    GetIndex("font: [comic sans] [1]").overlapText = "font: [cascadia code] [12]";
                    currentFont = cascadiacode;
                    return;
                case 12:
                    GetIndex("font: [comic sans] [1]").overlapText = "font: [constantia] [13]";
                    currentFont = constantia;
                    return;
                case 13:
                    GetIndex("font: [comic sans] [1]").overlapText = "font: [corbel] [14]";
                    currentFont = corbel;
                    return;
                case 14:
                    GetIndex("font: [comic sans] [1]").overlapText = "font: [courier new] [15]";
                    currentFont = couriernew;
                    return;
                case 15:
                    GetIndex("font: [comic sans] [1]").overlapText = "font: [dengxian] [16]";
                    currentFont = dengxian;
                    return;
                case 16:
                    GetIndex("font: [comic sans] [1]").overlapText = "font: [ebrima] [17]";
                    currentFont = ebrima;
                    return;
                case 17:
                    GetIndex("font: [comic sans] [1]").overlapText = "font: [fangsong] [18]";
                    currentFont = fangsong;
                    return;
                case 18:
                    GetIndex("font: [comic sans] [1]").overlapText = "font: [franklin gothic] [19]";
                    currentFont = franklingothic;
                    return;
                case 19:
                    GetIndex("font: [comic sans] [1]").overlapText = "font: [gabriola] [20]";
                    currentFont = gabriola;
                    return;
                case 20:
                    GetIndex("font: [comic sans] [1]").overlapText = "font: [gadugi] [21]";
                    currentFont = gadugi;
                    return;
                case 21:
                    GetIndex("font: [comic sans] [1]").overlapText = "font: [georgia] [22]";
                    currentFont = georgia;
                    return;
                case 22:
                    GetIndex("font: [comic sans] [1]").overlapText = "font: [hololens] [23]";
                    currentFont = hololens;
                    return;
                case 23:
                    GetIndex("font: [comic sans] [1]").overlapText = "font: [ink free] [24]";
                    currentFont = inkfree;
                    return;
                case 24:
                    GetIndex("font: [comic sans] [1]").overlapText = "font: [javanese text] [25]";
                    currentFont = javanesetext;
                    return;
                case 25:
                    GetIndex("font: [comic sans] [1]").overlapText = "font: [kaiti] [26]";
                    currentFont = kaiti;
                    return;
                case 26:
                    GetIndex("font: [comic sans] [1]").overlapText = "font: [lucida console] [27]";
                    currentFont = lucidaconsole;
                    return;
            }
        }
    }
}
