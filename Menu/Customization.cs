using silliness.Classes;
using System.IO;
using UnityEngine;
using static silliness.Menu.Main;

namespace silliness.Menu
{
    internal class Customization
    {
        public static ExtGradient bgColors = new ExtGradient { colors = GetMultiGradient(bgColorsA, bgColorsB) }; // Background Colors
        public static ExtGradient titleColors = new ExtGradient { colors = GetMultiGradient(titleColorsA, titleColorsB) }; // Title Colors
        public static ExtGradient outlineColors = new ExtGradient { colors = GetMultiGradient(outlineColorsA, outlineColorsB) }; // Outline Colors
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
        public static ExtGradient[] txtOutlineColors = new ExtGradient[]
        {
            new ExtGradient{ colors = GetMultiGradient(txtOutlineDefaultA, txtOutlineDefaultB) }, // Disabled Text Outline Colors
            new ExtGradient{ colors = GetMultiGradient(txtOutlineClickedA, txtOutlineClickedB) } // Enabled Text Outline Colors
        };

        public static Font currentFont = sans;

        // i love variables I LOVE VARIABLES
        public static bool fpsCounter = true;
        public static bool discordtext = true;
        public static bool disconnectButton = true;
        public static bool rightHanded = false;
        public static bool disableNotifications = false;
        public static bool shouldOutline = true;
        public static bool customMenuNameActivated = false;
        public static bool customMenuBackground = false;
        public static bool highQualityText = false;
        public static bool textShadow = false;
        public static bool textOutline = false;
        public static bool overflowText = false;
        public static bool swapMenuColors = false;
        public static bool uppercaseText = false;
        public static bool lowercaseText = true;
        public static bool roundedMenu = false;
        public static bool PCMenuBackground = true;
        public static bool menuBackgroundMorning = false;
        public static bool menuBackgroundDay = false;
        public static bool menuBackgroundAfternoon = false;
        public static bool menuBackgroundNight = false;
        public static bool menuBackgroundRain = false;
        public static bool collidableMenu = false;
        public static bool EToH = false;
        public static bool badApple = false;
        public static bool adminIndicator = true;
        public static bool badappleactivation = false;
        public static bool outlineactivation = true;
        public static bool extendedFPS = false;

        public static KeyCode keyboardButton = KeyCode.Q;

        public static Vector3 menuSize = new Vector3(0.1f, 1f, 1f); // Depth, Width, Height
        public static int buttonsPerPage = 9;

        public static void EnableExtendedFPS()
        {
            extendedFPS = true;
        }
        public static void DisableExtendedFPS()
        {
            extendedFPS = false;
        }
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
        public static void EnableTextShadow()
        {
            textShadow = true;
        }
        public static void DisableTextShadow()
        {
            textShadow = false;
        }
        public static void EnableTextOutline()
        {
            wasTextOutlined = true;
            textOutline = true;
        }
        public static void DisableTextOutline()
        {
            wasTextOutlined = false;
            textOutline = false;
        }
        public static void EnableOverflowText()
        {
            overflowText = true;
        }
        public static void DisableOverflowText()
        {
            overflowText = false;
        }
        public static void EnableUppercaseText()
        {
            uppercaseText = true;
        }
        public static void DisableUppercaseText()
        {
            uppercaseText = false;
        }
        public static void EnableLowercaseText()
        {
            lowercaseText = true;
        }
        public static void DisableLowercaseText()
        {
            lowercaseText = false;
        }
        public static void EnableSwapMenuColors()
        {
            swapMenuColors = true;
            ChangeThemeTypeBackwards();
            ChangeThemeTypeForwards();
        }
        public static void DisableSwapMenuColors()
        {
            swapMenuColors = false;
            ChangeThemeTypeBackwards();
            ChangeThemeTypeForwards();
        }
        public static void EnableRoundedMenu()
        {
            roundedMenu = true;
        }
        public static void DisableRoundedMenu()
        {
            roundedMenu = false;
        }
        public static void EnableCustomMenuName()
        {
            customMenuNameActivated = true;
            if (!File.Exists("silliness/CustomMenuName.txt"))
                File.WriteAllText("silliness/CustomMenuName.txt", "your text here");

            customMenuName = File.ReadAllText("silliness/CustomMenuName.txt");
        }
        public static void DisableCustomMenuName()
        {
            customMenuNameActivated = false;
        }
        public static void EnableCustomMenuBackground()
        {
            customMenuBackground = true;
            ChangeThemeTypeBackwards();
            ChangeThemeTypeForwards();
        }
        public static void DisableCustomMenuBackground()
        {
            customMenuBackground = false;
            ChangeThemeTypeBackwards();
            ChangeThemeTypeForwards();
        }
        public static void CustomTheme()
        {
            GetIndex("Theme: [Main] [1]").overlapText = "Theme: [Custom] [??]";
            if (!File.Exists("silliness/CustomTheme/CustomThemebgColors.txt"))
            {
                File.WriteAllText("silliness/CustomTheme/CustomThemebgColors.txt", "new Color32(0, 0, 0, 255), new Color32(0, 0, 0, 255)\nnew Color32(0, 0, 0, 255), new Color32(0, 0, 0, 255)\nnew Color32(0, 0, 0, 255), new Color32(0, 0, 0, 255)\nnew Color32(0, 0, 0, 255), new Color32(0, 0, 0, 255)\nnew Color32(0, 0, 0, 255), new Color32(0, 0, 0, 255)\nnew Color32(0, 0, 0, 255), new Color32(0, 0, 0, 255)");
            }
        }
        public static void EnablePCMenuBackground()
        {
            PCMenuBackground = true;
        }
        public static void DisablePCMenuBackground()
        {
            PCMenuBackground = false;
        }
        public static void EnableCollidableMenu()
        {
            collidableMenu = true;
        }
        public static void DisableCollidableMenu()
        {
            collidableMenu = false;
        }
        public static void EnableEToHFunction()
        {
            EToH = true;
        }
        public static void DisableEToHFunction()
        {
            EToH = false;
        }
        public static void ChangeThemeTypeForwards()
        {
            themeType++;
            if (themeType > 41)
            {
                themeType = 1;
            }
            switch (themeType)
            {
                case 1 /* Main */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [Main] [1]";
                    if (swapMenuColors == true)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(255, 136, 249, 255), new Color32(255, 136, 249, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(255, 186, 251, 255), new Color32(255, 204, 253, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(255, 136, 249, 255), new Color32(255, 136, 249, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(255, 186, 251, 255), new Color32(255, 204, 253, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(255, 186, 251, 255), new Color32(255, 190, 253, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(255, 136, 249, 255), new Color32(255, 136, 249, 255)) };
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
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                    }
                    return;
                case 2 /* Red Fade */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [Red Fade] [2]";
                    if (swapMenuColors == false)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(Color.red, Color.black) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.black, Color.black) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(Color.black, Color.red) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.red, Color.red) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient { colors = GetMultiGradient(Color.red, Color.red) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.red, Color.red) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(Color.black, Color.red) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.red, Color.red) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(Color.red, Color.black) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(Color.red, Color.red) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.red, Color.red) },
                            new ExtGradient { colors = GetMultiGradient(Color.black, Color.black) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(Color.red, Color.red) }
                        };
                    }
                    return;
                case 3 /* Orange Fade */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [Orange Fade] [3]";
                    if (swapMenuColors == false)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(249, 105, 14, 255), Color.black) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.black, Color.black) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(Color.black, new Color32(249, 105, 14, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(249, 105, 14, 255), new Color32(249, 105, 14, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient { colors = GetMultiGradient(new Color32(249, 105, 14, 255), new Color32(249, 105, 14, 255)) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(249, 105, 14, 255), new Color32(249, 105, 14, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(Color.black, new Color32(249, 105, 14, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(249, 105, 14, 255), new Color32(249, 105, 14, 255)) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(249, 105, 14, 255), Color.black) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(249, 105, 14, 255), new Color32(249, 105, 14, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(new Color32(249, 105, 14, 255), new Color32(249, 105, 14, 255)) },
                            new ExtGradient { colors = GetMultiGradient(Color.black, Color.black) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(249, 105, 14, 255), new Color32(249, 105, 14, 255)) }
                        };
                    }
                    return;
                case 4 /* Yellow Fade */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [Yellow Fade] [4]";
                    if (swapMenuColors == false)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(Color.yellow, Color.black) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.black, Color.black) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(Color.black, Color.yellow) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.yellow, Color.yellow) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient { colors = GetMultiGradient(Color.yellow, Color.yellow) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.yellow, Color.yellow) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(Color.black, Color.yellow) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.yellow, Color.yellow) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(Color.yellow, Color.black) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(Color.yellow, Color.yellow) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.yellow, Color.yellow) },
                            new ExtGradient { colors = GetMultiGradient(Color.black, Color.black) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(Color.yellow, Color.yellow) }
                        };
                    }
                    return;
                case 5 /* Green Fade */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [Green Fade] [5]";
                    if (swapMenuColors == false)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(Color.green, Color.black) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.black, Color.black) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(Color.black, Color.green) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.green, Color.green) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient { colors = GetMultiGradient(Color.green, Color.green) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.green, Color.green) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(Color.black, Color.green) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.green, Color.green) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(Color.green, Color.black) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(Color.green, Color.green) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.green, Color.green) },
                            new ExtGradient { colors = GetMultiGradient(Color.black, Color.black) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(Color.green, Color.green) }
                        };
                    }
                    return;
                case 6 /* Cyan Fade */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [Cyan Fade] [6]";
                    if (swapMenuColors == false)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(Color.cyan, Color.black) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.black, Color.black) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(Color.black, Color.cyan) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.cyan, Color.cyan) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient { colors = GetMultiGradient(Color.cyan, Color.cyan) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.cyan, Color.cyan) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(Color.black, Color.cyan) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.cyan, Color.cyan) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(Color.cyan, Color.black) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(Color.cyan, Color.cyan) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.cyan, Color.cyan) },
                            new ExtGradient { colors = GetMultiGradient(Color.black, Color.black) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(Color.cyan, Color.cyan) }
                        };
                    }
                    return;
                case 7 /* Blue Fade */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [Blue Fade] [7]";
                    if (swapMenuColors == false)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(Color.blue, Color.black) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.black, Color.black) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(Color.black, Color.blue) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.blue, Color.blue) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient { colors = GetMultiGradient(Color.blue, Color.blue) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.blue, Color.blue) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(Color.black, Color.blue) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.blue, Color.blue) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(Color.blue, Color.black) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(Color.blue, Color.blue) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.blue, Color.blue) },
                            new ExtGradient { colors = GetMultiGradient(Color.black, Color.black) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(Color.blue, Color.blue) }
                        };
                    }
                    return;
                case 8 /* Magenta Fade */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [Magenta Fade] [8]";
                    if (swapMenuColors == false)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(Color.magenta, Color.black) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.black, Color.black) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(Color.black, Color.magenta) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.magenta, Color.magenta) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient { colors = GetMultiGradient(Color.magenta, Color.magenta) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.magenta, Color.magenta) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(Color.black, Color.magenta) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.magenta, Color.magenta) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(Color.magenta, Color.black) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(Color.magenta, Color.magenta) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.magenta, Color.magenta) },
                            new ExtGradient { colors = GetMultiGradient(Color.black, Color.black) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(Color.magenta, Color.magenta) }
                        };
                    }
                    return;
                case 9 /* White Fade */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [White Fade] [9]";
                    if (swapMenuColors == false)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.black) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.black, Color.black) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(Color.black, Color.white) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(Color.black, Color.white) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.black) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(Color.white, Color.white) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient { colors = GetMultiGradient(Color.black, Color.black) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(Color.white, Color.white) }
                        };
                    }
                    return;
                case 10 /* OG Purple */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [Purple] [10]";
                    if (swapMenuColors == false)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(190, 129, 255, 255), new Color32(190, 129, 255, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(156, 64, 255, 255), new Color32(156, 64, 255, 255)) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(175, 105, 250, 255), new Color32(175, 105, 250, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(190, 129, 255, 255), new Color32(190, 129, 255, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(172, 95, 255, 255), new Color32(172, 95, 255, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(new Color32(156, 64, 255, 255), new Color32(156, 64, 255, 255)) },
                            new ExtGradient { colors = GetMultiGradient(new Color32(196, 140, 255, 255), new Color32(196, 140, 255, 255)) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(196, 140, 255, 255), new Color32(196, 140, 255, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(156, 64, 255, 255), new Color32(156, 64, 255, 255)) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(172, 95, 255, 255), new Color32(172, 95, 255, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(196, 140, 255, 255), new Color32(196, 140, 255, 255)) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(194, 138, 255, 255), new Color32(194, 138, 255, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(172, 95, 255, 255), new Color32(172, 95, 255, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(190, 129, 255, 255), new Color32(190, 129, 255, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(new Color32(196, 140, 255, 255), new Color32(196, 140, 255, 255)) },
                            new ExtGradient { colors = GetMultiGradient(new Color32(156, 64, 255, 255), new Color32(156, 64, 255, 255)) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(new Color32(156, 64, 255, 255), new Color32(156, 64, 255, 255)) },
                            new ExtGradient { colors = GetMultiGradient(new Color32(196, 140, 255, 255), new Color32(196, 140, 255, 255)) }
                        };
                    }
                    return;
                case 11 /* OG Blue */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [Blue] [11]";
                    if (swapMenuColors == false)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(106, 109, 255, 255), new Color32(106, 109, 255, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(151, 154, 255, 255), new Color32(151, 154, 255, 255)) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(86, 89, 252, 255), new Color32(86, 89, 252, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(106, 109, 255, 255), new Color32(106, 109, 255, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(67, 71, 255, 255), new Color32(67, 71, 255, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(new Color32(151, 154, 255, 255), new Color32(151, 154, 255, 255)) },
                            new ExtGradient { colors = GetMultiGradient(new Color32(151, 154, 255, 255), new Color32(151, 154, 255, 255)) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(67, 71, 255, 255), new Color32(67, 71, 255, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(106, 109, 255, 255), new Color32(106, 109, 255, 255)) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(67, 71, 255, 255), new Color32(67, 71, 255, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(151, 154, 255, 255), new Color32(151, 154, 255, 255)) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(140, 142, 255, 255), new Color32(140, 142, 255, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(67, 71, 255, 255), new Color32(67, 71, 255, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(106, 109, 255, 255), new Color32(106, 109, 255, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(new Color32(151, 154, 255, 255), new Color32(151, 154, 255, 255)) },
                            new ExtGradient { colors = GetMultiGradient(new Color32(151, 154, 255, 255), new Color32(151, 154, 255, 255)) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(106, 109, 255, 255), new Color32(106, 109, 255, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(67, 71, 255, 255), new Color32(67, 71, 255, 255)) }
                        };
                    }
                    return;
                case 12 /* OG Light Blue */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [Light Blue] [12]";
                    if (swapMenuColors == false)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(156, 222, 255, 255), new Color32(156, 222, 255, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(65, 192, 255, 255), new Color32(65, 192, 255, 255)) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(97, 202, 255, 255), new Color32(97, 202, 255, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(156, 222, 255, 255), new Color32(156, 222, 255, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(110, 207, 255, 255), new Color32(110, 207, 255, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(new Color32(65, 192, 255, 255), new Color32(65, 192, 255, 255)) },
                            new ExtGradient { colors = GetMultiGradient(new Color32(195, 235, 255, 255), new Color32(195, 235, 255, 255)) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(32, 124, 170, 255), new Color32(32, 124, 170, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(82, 166, 207, 255), new Color32(82, 166, 207, 255)) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(110, 207, 255, 255), new Color32(110, 207, 255, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(195, 235, 255, 255), new Color32(195, 235, 255, 255)) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(171, 227, 255, 255), new Color32(171, 227, 255, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(110, 207, 255, 255), new Color32(110, 207, 255, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(156, 222, 255, 255), new Color32(156, 222, 255, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(new Color32(195, 235, 255, 255), new Color32(195, 235, 255, 255)) },
                            new ExtGradient { colors = GetMultiGradient(new Color32(65, 192, 255, 255), new Color32(65, 192, 255, 255)) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(82, 166, 207, 255), new Color32(82, 166, 207, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(32, 124, 170, 255), new Color32(32, 124, 170, 255)) }
                        };
                    }
                    return;
                case 13 /* OG Green */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [Green] [13]";
                    if (swapMenuColors == false)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(106, 255, 106, 255), new Color32(106, 255, 106, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(67, 191, 67, 255), new Color32(67, 191, 67, 255)) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(52, 179, 52, 255), new Color32(52, 179, 52, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(106, 255, 106, 255), new Color32(106, 255, 106, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(67, 191, 67, 255), new Color32(67, 191, 67, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(new Color32(67, 191, 67, 255), new Color32(67, 191, 67, 255)) },
                            new ExtGradient { colors = GetMultiGradient(new Color32(106, 255, 106, 255), new Color32(106, 255, 106, 255)) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(32, 145, 32, 255), new Color32(32, 145, 32, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(50, 117, 50, 255), new Color32(50, 117, 50, 255)) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(67, 191, 67, 255), new Color32(67, 191, 67, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(106, 255, 106, 255), new Color32(106, 255, 106, 255)) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(122, 255, 122, 255), new Color32(122, 255, 122, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(67, 191, 67, 255), new Color32(67, 191, 67, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(106, 255, 106, 255), new Color32(106, 255, 106, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(new Color32(106, 255, 106, 255), new Color32(106, 255, 106, 255)) },
                            new ExtGradient { colors = GetMultiGradient(new Color32(67, 191, 67, 255), new Color32(67, 191, 67, 255)) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(50, 117, 50, 255), new Color32(50, 117, 50, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(32, 145, 32, 255), new Color32(32, 145, 32, 255)) }
                        };
                    }
                    return;
                case 14 /* OG Orange */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [Orange] [14]";
                    if (swapMenuColors == false)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(255, 148, 69, 255), new Color32(255, 148, 69, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(219, 91, 0, 255), new Color32(219, 91, 0, 255)) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(255, 171, 112, 255), new Color32(255, 171, 112, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(255, 148, 69, 255), new Color32(255, 148, 69, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(214, 123, 57, 255), new Color32(214, 123, 57, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(new Color32(219, 91, 0, 255), new Color32(219, 91, 0, 255)) },
                            new ExtGradient { colors = GetMultiGradient(new Color32(171, 71, 0, 255), new Color32(171, 71, 0, 255)) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(171, 71, 0, 255), new Color32(171, 71, 0, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(219, 91, 0, 255), new Color32(219, 91, 0, 255)) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(214, 123, 57, 255), new Color32(214, 123, 57, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(171, 71, 0, 255), new Color32(171, 71, 0, 255)) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(255, 171, 112, 255), new Color32(255, 171, 112, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(214, 123, 57, 255), new Color32(214, 123, 57, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(255, 148, 69, 255), new Color32(255, 148, 69, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(new Color32(171, 71, 0, 255), new Color32(171, 71, 0, 255)) },
                            new ExtGradient { colors = GetMultiGradient(new Color32(219, 91, 0, 255), new Color32(219, 91, 0, 255)) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(219, 91, 0, 255), new Color32(219, 91, 0, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(171, 71, 0, 255), new Color32(171, 71, 0, 255)) }
                        };
                    }
                    return;
                case 15 /* OG Red */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [Red] [15]";
                    if (swapMenuColors == false)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(255, 69, 69, 255), new Color32(255, 69, 69, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(255, 48, 48, 255), new Color32(255, 48, 48, 255)) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(255, 119, 119, 255), new Color32(255, 119, 119, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(255, 69, 69, 255), new Color32(255, 69, 69, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(209, 72, 72, 255), new Color32(209, 72, 72, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(new Color32(255, 48, 48, 255), new Color32(255, 48, 48, 255)) },
                            new ExtGradient { colors = GetMultiGradient(new Color32(161, 31, 31, 255), new Color32(161, 31, 31, 255)) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(161, 31, 31, 255), new Color32(161, 31, 31, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(255, 48, 48, 255), new Color32(255, 48, 48, 255)) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(209, 72, 72, 255), new Color32(209, 72, 72, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(161, 31, 31, 255), new Color32(161, 31, 31, 255)) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(255, 119, 119, 255), new Color32(255, 119, 119, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(209, 72, 72, 255), new Color32(209, 72, 72, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(255, 69, 69, 255), new Color32(255, 69, 69, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(new Color32(161, 31, 31, 255), new Color32(161, 31, 31, 255)) },
                            new ExtGradient { colors = GetMultiGradient(new Color32(255, 48, 48, 255), new Color32(255, 48, 48, 255)) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(255, 48, 48, 255), new Color32(255, 48, 48, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(161, 31, 31, 255), new Color32(161, 31, 31, 255)) }
                        };
                    }
                    return;
                case 16 /* Mr R. (BENDY AND THE RAPE MACHINE) */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [Mr. R] [16]";
                    if (swapMenuColors == false)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(8, 7, 0, 255), new Color32(8, 7, 0, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(138, 115, 69, 255), new Color32(138, 115, 69, 255)) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(138, 115, 69, 255), new Color32(138, 115, 69, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(8, 7, 0, 255), new Color32(8, 7, 0, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(8, 7, 0, 255), new Color32(8, 7, 0, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(new Color32(138, 115, 69, 255), new Color32(138, 115, 69, 255)) },
                            new ExtGradient { colors = GetMultiGradient(new Color32(97, 80, 47, 255), new Color32(97, 80, 47, 255)) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(97, 80, 47, 255), new Color32(97, 80, 47, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(138, 115, 69, 255), new Color32(138, 115, 69, 255)) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(138, 115, 69, 255), new Color32(138, 115, 69, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(8, 7, 0, 255), new Color32(8, 7, 0, 255)) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(8, 7, 0, 255), new Color32(8, 7, 0, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(138, 115, 69, 255), new Color32(138, 115, 69, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(138, 115, 69, 255), new Color32(138, 115, 69, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(new Color32(97, 80, 47, 255), new Color32(97, 80, 47, 255)) },
                            new ExtGradient { colors = GetMultiGradient(new Color32(8, 7, 0, 255), new Color32(8, 7, 0, 255)) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(8, 7, 0, 255), new Color32(8, 7, 0, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(97, 80, 47, 255), new Color32(97, 80, 47, 255)) }
                        };
                    }
                    return;
                case 17 /* Dracula */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [Dracula] [17]";
                    if (swapMenuColors == false)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(33, 32, 43, 255), new Color32(33, 32, 43, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(20, 18, 31, 255), new Color32(20, 18, 31, 255)) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(42, 37, 63, 255), new Color32(42, 37, 63, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(41, 39, 53, 255), new Color32(41, 39, 53, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(20, 18, 31, 255), new Color32(20, 18, 31, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(new Color32(20, 18, 31, 255), new Color32(20, 18, 31, 255)) },
                            new ExtGradient { colors = GetMultiGradient(new Color32(41, 39, 53, 255), new Color32(41, 39, 53, 255)) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(149, 128, 253, 255), new Color32(149, 128, 253, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(149, 128, 253, 255), new Color32(149, 128, 253, 255)) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(42, 37, 63, 255), new Color32(42, 37, 63, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(20, 18, 31, 255), new Color32(20, 18, 31, 255)) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(33, 32, 43, 255), new Color32(33, 32, 43, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(20, 18, 31, 255), new Color32(20, 18, 31, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(41, 39, 53, 255), new Color32(41, 39, 53, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(new Color32(41, 39, 53, 255), new Color32(41, 39, 53, 255)) },
                            new ExtGradient { colors = GetMultiGradient(new Color32(20, 18, 31, 255), new Color32(20, 18, 31, 255)) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(149, 128, 253, 255), new Color32(149, 128, 253, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(149, 128, 253, 255), new Color32(149, 128, 253, 255)) }
                        };
                    }
                    return;
                case 18 /* Noctua */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [Noctua] [18]";
                    if (swapMenuColors == false)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(231, 206, 181, 255), new Color32(231, 206, 181, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(101, 48, 36, 255), new Color32(101, 48, 36, 255)) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(101, 48, 36, 255), new Color32(101, 48, 36, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(231, 206, 181, 255), new Color32(231, 206, 181, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(101, 48, 36, 255), new Color32(101, 48, 36, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(new Color32(101, 48, 36, 255), new Color32(101, 48, 36, 255)) },
                            new ExtGradient { colors = GetMultiGradient(new Color32(231, 206, 181, 255), new Color32(231, 206, 181, 255)) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(251, 226, 201, 255), new Color32(251, 226, 201, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(141, 88, 76, 255), new Color32(141, 88, 76, 255)) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(101, 48, 36, 255), new Color32(101, 48, 36, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(231, 206, 181, 255), new Color32(231, 206, 181, 255)) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(231, 206, 181, 255), new Color32(231, 206, 181, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(101, 48, 36, 255), new Color32(101, 48, 36, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(231, 206, 181, 255), new Color32(231, 206, 181, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(new Color32(231, 206, 181, 255), new Color32(231, 206, 181, 255)) },
                            new ExtGradient { colors = GetMultiGradient(new Color32(101, 48, 36, 255), new Color32(101, 48, 36, 255)) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(141, 88, 76, 255), new Color32(141, 88, 76, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(251, 226, 201, 255), new Color32(251, 226, 201, 255)) }
                        };
                    }
                    return;
                case 19 /* Oblivion */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [Oblivion] [19]";
                    if (swapMenuColors == false)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(10, 10, 10, 255), new Color32(10, 10, 10, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(188, 130, 255, 255), new Color32(188, 130, 255, 255)) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(188, 130, 255, 255), new Color32(188, 130, 255, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(10, 10, 10, 255), new Color32(10, 10, 10, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(188, 130, 255, 255), new Color32(188, 130, 255, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(new Color32(188, 130, 255, 255), new Color32(188, 130, 255, 255)) },
                            new ExtGradient { colors = GetMultiGradient(new Color32(10, 10, 10, 255), new Color32(10, 10, 10, 255)) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(78, 20, 155, 255), new Color32(78, 20, 155, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(188, 130, 255, 255), new Color32(188, 130, 255, 255)) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(188, 130, 255, 255), new Color32(188, 130, 255, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(10, 10, 10, 255), new Color32(10, 10, 10, 255)) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(10, 10, 10, 255), new Color32(10, 10, 10, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(188, 130, 255, 255), new Color32(188, 130, 255, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(10, 10, 10, 255), new Color32(10, 10, 10, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(new Color32(10, 10, 10, 255), new Color32(10, 10, 10, 255)) },
                            new ExtGradient { colors = GetMultiGradient(new Color32(188, 130, 255, 255), new Color32(188, 130, 255, 255)) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(228, 170, 255, 255), new Color32(228, 170, 255, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(78, 20, 155, 255), new Color32(78, 20, 155, 255)) }
                        };
                    }
                    return;
                case 20 /* Midnight */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [Midnight] [20]";
                    if (swapMenuColors == true)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(4, 0, 170, 255), new Color32(4, 0, 190, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(2, 0, 94, 255), new Color32(2, 0, 94, 255)) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(6, 3, 128, 255), new Color32(6, 3, 128, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(4, 0, 170, 255), new Color32(4, 0, 190, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(1, 0, 53, 255), new Color32(1, 0, 43, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(new Color32(2, 0, 94, 255), new Color32(2, 0, 94, 255)) },
                            new ExtGradient { colors = GetMultiGradient(new Color32(127, 124, 255, 255), new Color32(127, 124, 255, 255)) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(127, 124, 255, 255), new Color32(127, 124, 255, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(42, 0, 134, 255), new Color32(42, 0, 134, 255)) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(1, 0, 62, 255), new Color32(2, 0, 93, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(127, 124, 255, 255), new Color32(127, 124, 255, 255)) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(21, 16, 204, 255), new Color32(21, 16, 204, 255)) };
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
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(42, 0, 134, 255), new Color32(42, 0, 134, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(127, 124, 255, 255), new Color32(127, 124, 255, 255)) }
                        };
                    }
                    return;
                case 21 /* Folly */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [Folly] [21]";
                    if (swapMenuColors == false)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(10, 0, 3, 255), new Color32(14, 0, 4, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(255, 0, 79, 255), new Color32(252, 0, 78, 255)) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(255, 0, 79, 255), new Color32(252, 0, 78, 255)) };
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
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(145, 0, 39, 255), new Color32(142, 0, 18, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(145, 0, 39, 255), new Color32(142, 0, 18, 255)) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(255, 0, 79, 255), new Color32(252, 0, 78, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(10, 0, 3, 255), new Color32(14, 0, 4, 255)) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(10, 0, 3, 255), new Color32(14, 0, 4, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(255, 0, 79, 255), new Color32(252, 0, 78, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(10, 0, 3, 255), new Color32(14, 0, 4, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(new Color32(10, 0, 3, 255), new Color32(14, 0, 4, 255)) },
                            new ExtGradient { colors = GetMultiGradient(new Color32(255, 0, 79, 255), new Color32(252, 0, 78, 255)) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(145, 0, 39, 255), new Color32(142, 0, 18, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(145, 0, 39, 255), new Color32(142, 0, 18, 255)) }
                        };
                    }
                    return;
                case 22 /* Bad Apple */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [Bad Apple] [22]";
                    if (swapMenuColors == false)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(10, 13, 17, 255), new Color32(10, 13, 17, 255)) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(10, 13, 17, 255), new Color32(10, 13, 17, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient{ colors = GetMultiGradient(Color.white, Color.white) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(new Color32(10, 13, 17, 255), new Color32(10, 13, 17, 255)) },
                            new ExtGradient { colors = GetMultiGradient(Color.green, Color.green) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(10, 13, 17, 255), new Color32(10, 13, 17, 255)) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(10, 13, 17, 255), new Color32(10, 13, 17, 255)) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(10, 13, 17, 255), new Color32(10, 13, 17, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient{ colors = GetMultiGradient(Color.white, Color.white) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(new Color32(10, 13, 17, 255), new Color32(10, 13, 17, 255)) },
                            new ExtGradient { colors = GetMultiGradient(Color.green, Color.green) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(10, 13, 17, 255), new Color32(10, 13, 17, 255)) }
                        };
                    }
                    return;
                case 23 /* ii's Stupid Menu */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [ii's Stupid Menu] [23]";
                    if (swapMenuColors == false)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(255, 128, 0, 255), new Color32(255, 102, 0, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(255, 190, 125, 255), new Color32(255, 190, 125, 255)) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(85, 42, 0, 255), new Color32(85, 42, 0, 255)) };
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
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(180, 115, 50, 255), new Color32(180, 115, 50, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(180, 115, 50, 255), new Color32(180, 115, 50, 255)) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(170, 85, 0, 255), new Color32(170, 85, 0, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(255, 190, 125, 255), new Color32(255, 190, 125, 255)) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(255, 128, 0, 255), new Color32(255, 102, 0, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(85, 42, 0, 255), new Color32(85, 42, 0, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(255, 128, 0, 255), new Color32(255, 102, 0, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(new Color32(255, 190, 125, 255), new Color32(255, 190, 125, 255)) },
                            new ExtGradient { colors = GetMultiGradient(new Color32(255, 190, 125, 255), new Color32(255, 190, 125, 255)) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(180, 115, 50, 255), new Color32(180, 115, 50, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(180, 115, 50, 255), new Color32(180, 115, 50, 255)) }
                        };
                    }
                    return;
                case 24 /* Wyvern OLD */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [Old Wyvern] [24]";
                    if (swapMenuColors == false)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(199, 115, 173, 255), new Color32(165, 233, 185, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(165, 233, 185, 255), new Color32(199, 115, 173, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(99, 58, 86, 255), new Color32(83, 116, 92, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(99, 58, 86, 255), new Color32(83, 116, 92, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient { colors = GetMultiGradient(Color.green, Color.green) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(99, 58, 86, 255), new Color32(83, 116, 92, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(165, 233, 185, 255), new Color32(199, 115, 173, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(199, 115, 173, 255), new Color32(165, 233, 185, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(199, 115, 173, 255), new Color32(165, 233, 185, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient { colors = GetMultiGradient(Color.green, Color.green) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                    }
                    return;
                case 25 /* Wyvern */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [Wyvern] [25]";
                    if (swapMenuColors == false)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(20, 20, 22, 255), new Color32(20, 20, 22, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(51, 199, 127, 255), new Color32(51, 199, 127, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(50, 50, 50, 255), new Color32(50, 50, 50, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(51, 199, 127, 255), new Color32(51, 199, 127, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient { colors = GetMultiGradient(Color.green, Color.green) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(20, 20, 22, 255), new Color32(20, 20, 22, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(50, 50, 50, 255), new Color32(50, 50, 50, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(51, 199, 127, 255), new Color32(51, 199, 127, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(50, 50, 50, 255), new Color32(50, 50, 50, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient { colors = GetMultiGradient(Color.green, Color.green) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                    }
                    return;
                case 26 /* ShibaGT Genesis */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [ShibaGT Genesis] [26]";
                    if (swapMenuColors == false)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(0, 0, 200, 255), Color.blue) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(0, 0, 200, 255), new Color32(0, 0, 200, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(0, 0, 200, 255), new Color32(0, 0, 200, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(0, 0, 200, 255), new Color32(0, 0, 200, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient { colors = GetMultiGradient(Color.magenta, Color.magenta) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(0, 0, 200, 255), new Color32(0, 0, 200, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(0, 0, 200, 255), new Color32(0, 0, 200, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(0, 0, 200, 255), Color.blue) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(0, 0, 200, 255), Color.blue) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient { colors = GetMultiGradient(Color.magenta, Color.magenta) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                    }
                    return;
                case 27 /* Untitled */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [Untitled] [27]";
                    if (swapMenuColors == false)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(19, 20, 36, 255), new Color32(19, 20, 36, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(10, 10, 19, 255), new Color32(10, 10, 19, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(39, 39, 60, 255), new Color32(39, 39, 60, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(10, 10, 19, 255), new Color32(10, 10, 19, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(10, 10, 19, 255), new Color32(10, 10, 19, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(39, 39, 60, 255), new Color32(39, 39, 60, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(19, 20, 36, 255), new Color32(19, 20, 36, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(39, 39, 60, 255), new Color32(39, 39, 60, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                    }
                    return;
                case 28 /* Orbit */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [Orbit] [28]";
                    if (swapMenuColors == false)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(36, 0, 78, 255), Color.black) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(54, 1, 109, 255), new Color32(54, 1, 109, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(54, 1, 109, 255), new Color32(54, 1, 109, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(54, 1, 109, 255), new Color32(54, 1, 109, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient { colors = GetMultiGradient(new Color32(153, 117, 191, 255), new Color32(153, 117, 191, 255)) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(153, 117, 191, 255), new Color32(153, 117, 191, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(Color.white, Color.white) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(54, 1, 109, 255), new Color32(54, 1, 109, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(36, 0, 78, 255), Color.black) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(36, 0, 78, 255), Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(36, 0, 78, 255), Color.black) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient { colors = GetMultiGradient(new Color32(153, 117, 191, 255), new Color32(153, 117, 191, 255)) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(153, 117, 191, 255), new Color32(153, 117, 191, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(Color.white, Color.white) }
                        };
                    }
                    return;
                case 29 /* Destiny OLD */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [Old Destiny] [29]";
                    if (swapMenuColors == false)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) }; // HAS CUSTOM BACKGROUND, GO TO MAIN.CS TO EDIT
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(0, 180, 150, 255), new Color32(0, 180, 150, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(0, 180, 150, 255), new Color32(0, 180, 150, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(0, 122, 99, 255), new Color32(0, 122, 99, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(0, 122, 99, 255), new Color32(0, 122, 99, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(0, 122, 99, 255), new Color32(0, 122, 99, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(0, 180, 150, 255), new Color32(0, 180, 150, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                    }
                    return;
                case 30 /* Destiny RAT */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [Destiny] [30]";
                    if (swapMenuColors == false)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(10, 10, 10, 255), new Color32(10, 10, 10, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(0, 254, 209, 255), new Color32(0, 254, 209, 255)) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(0, 255, 250, 255), new Color32(0, 255, 250, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(40, 40, 40, 255), new Color32(40, 40, 40, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(60, 60, 60, 255), new Color32(60, 60, 60, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(10, 10, 10, 255), new Color32(10, 10, 10, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(0, 254, 209, 255), new Color32(0, 254, 209, 255)) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(0, 255, 250, 255), new Color32(0, 255, 250, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(60, 60, 60, 255), new Color32(60, 60, 60, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(40, 40, 40, 255), new Color32(40, 40, 40, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                    }
                    return;
                case 31 /* Haunted Mod Menu */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [Haunted Mod Menu] [31]";
                    if (swapMenuColors == false)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(8, 9, 13, 255), new Color32(8, 9, 13, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(160, 159, 162, 255), new Color32(160, 159, 162, 255)) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(160, 159, 162, 255), new Color32(160, 159, 162, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(210, 64, 66, 255), new Color32(210, 64, 66, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(125, 180, 95, 255), new Color32(125, 180, 95, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(new Color32(7, 8, 0, 255), new Color32(7, 8, 0, 255)) },
                            new ExtGradient { colors = GetMultiGradient(new Color32(7, 8, 0, 255), new Color32(7, 8, 0, 255)) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient{ colors = GetMultiGradient(Color.white, Color.white) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(160, 159, 162, 255), new Color32(160, 159, 162, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(8, 9, 13, 255), new Color32(8, 9, 13, 255)) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(8, 9, 13, 255), new Color32(8, 9, 13, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(210, 64, 66, 255), new Color32(210, 64, 66, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(125, 180, 95, 255), new Color32(125, 180, 95, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(new Color32(160, 159, 162, 255), new Color32(160, 159, 162, 255)) },
                            new ExtGradient { colors = GetMultiGradient(new Color32(160, 159, 162, 255), new Color32(160, 159, 162, 255)) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient{ colors = GetMultiGradient(Color.white, Color.white) }
                        };
                    }
                    return;
                case 32 /* Spectral Menu */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [Spectral Menu] [32]";
                    if (swapMenuColors == false)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(5, 10, 40, 255), new Color32(5, 10, 40, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(60, 120, 255, 255), new Color32(60, 120, 255, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(5, 10, 40, 255), new Color32(5, 10, 40, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(40, 80, 200, 255), new Color32(40, 80, 200, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(40, 80, 200, 255), new Color32(40, 80, 200, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(60, 120, 255, 255), new Color32(60, 120, 255, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(40, 80, 200, 255), new Color32(40, 80, 200, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(5, 10, 40, 255), new Color32(5, 10, 40, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                    }
                    return;
                case 33 /* Explicit Menu */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [Explicit Menu] [33]";
                    if (swapMenuColors == false)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(15, 15, 15, 255), new Color32(15, 15, 15, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(77, 77, 77, 255), new Color32(77, 77, 77, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(40, 40, 40, 255), new Color32(40, 40, 40, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(75, 75, 75, 255), new Color32(75, 75, 75, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(75, 75, 75, 255), new Color32(75, 75, 75, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(40, 40, 40, 255), new Color32(40, 40, 40, 255)) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(40, 40, 40, 255), new Color32(40, 40, 40, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(77, 77, 77, 255), new Color32(77, 77, 77, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(15, 15, 15, 255), new Color32(15, 15, 15, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(75, 75, 75, 255), new Color32(75, 75, 75, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(75, 75, 75, 255), new Color32(75, 75, 75, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(40, 40, 40, 255), new Color32(40, 40, 40, 255)) }
                        };
                    }
                    return;
                case 34 /* GPhys */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [GPhys] [34]";
                    if (swapMenuColors == false)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(82, 113, 255, 255), new Color32(82, 113, 255, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(60, 85, 200, 255), new Color32(60, 85, 200, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(82, 113, 255, 255), new Color32(82, 113, 255, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(60, 85, 200, 255), new Color32(60, 85, 200, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(60, 85, 200, 255), new Color32(60, 85, 200, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(82, 113, 255, 255), new Color32(82, 113, 255, 255)) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(60, 85, 200, 255), new Color32(60, 85, 200, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(82, 113, 255, 255), new Color32(82, 113, 255, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(60, 85, 200, 255), new Color32(60, 85, 200, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(82, 113, 255, 255), new Color32(82, 113, 255, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(82, 113, 255, 255), new Color32(82, 113, 255, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(60, 85, 200, 255), new Color32(60, 85, 200, 255)) }
                        };
                    }
                    return;
                case 35 /* Sentinel */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [Sentinel] [35]";
                    if (swapMenuColors == false)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(10, 10, 31, 255), new Color32(10, 10, 31, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(24, 25, 112, 255), new Color32(24, 25, 112, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(24, 25, 112, 255), new Color32(24, 25, 112, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(76, 0, 130, 255), new Color32(76, 0, 130, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient { colors = GetMultiGradient(Color.magenta, Color.magenta) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(24, 25, 112, 255), new Color32(24, 25, 112, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(10, 10, 31, 255), new Color32(10, 10, 31, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(10, 10, 31, 255), new Color32(10, 10, 31, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(76, 0, 130, 255), new Color32(76, 0, 130, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient { colors = GetMultiGradient(Color.magenta, Color.magenta) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                    }
                    return;
                case 36 /* Scintilla */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [Scintilla] [36]";
                    if (swapMenuColors == false)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(134, 75, 214, 255), new Color32(134, 75, 214, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(95, 41, 151, 255), new Color32(95, 41, 151, 255)) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(87, 42, 130, 255), new Color32(87, 42, 130, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(87, 42, 130, 255), new Color32(87, 42, 130, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(134, 75, 214, 255), new Color32(134, 75, 214, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(87, 42, 130, 255), new Color32(87, 42, 130, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(134, 75, 214, 255), new Color32(134, 75, 214, 255)) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(134, 75, 214, 255), new Color32(134, 75, 214, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(134, 75, 214, 255), new Color32(134, 75, 214, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(87, 42, 130, 255), new Color32(87, 42, 130, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                    }
                    return;
                case 37 /* Heal */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [Heal] [37]";
                    if (swapMenuColors == false)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(159, 90, 254, 255), new Color32(159, 90, 254, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(131, 81, 184, 255), new Color32(131, 81, 184, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(101, 50, 154, 255), new Color32(101, 50, 154, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(131, 81, 184, 255), new Color32(131, 81, 184, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(101, 50, 154, 255), new Color32(101, 50, 154, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(134, 75, 214, 255), new Color32(134, 75, 214, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(131, 81, 184, 255), new Color32(131, 81, 184, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(101, 50, 154, 255), new Color32(101, 50, 154, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                    }
                    return;
                case 38 /* Solace (REXON) */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [Solace (REXON)] [38]";
                    if (swapMenuColors == false)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(26, 59, 34, 255), new Color32(26, 59, 34, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(79, 201, 101, 255), new Color32(79, 201, 101, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(26, 59, 34, 255), new Color32(26, 59, 34, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(48, 152, 73, 255), new Color32(48, 152, 73, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(48, 152, 73, 255), new Color32(48, 152, 73, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(79, 201, 101, 255), new Color32(79, 201, 101, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(48, 152, 73, 255), new Color32(48, 152, 73, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(26, 59, 34, 255), new Color32(26, 59, 34, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                    }
                    return;
                case 39 /* Solace.lol (KINGOFNETFLIX/BTC) */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [solace.lol] [39]";
                    if (swapMenuColors == false)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(10, 164, 192, 255), new Color32(10, 164, 192, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(10, 62, 140, 255), new Color32(10, 62, 140, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(0, 100, 220, 255), new Color32(0, 100, 220, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(10, 62, 140, 255), new Color32(10, 62, 140, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(10, 62, 140, 255), new Color32(10, 62, 140, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(0, 100, 220, 255), new Color32(0, 100, 220, 255)) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(0, 100, 220, 255), new Color32(0, 100, 220, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(10, 62, 140, 255), new Color32(10, 62, 140, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(10, 164, 192, 255), new Color32(10, 164, 192, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(10, 62, 140, 255), new Color32(10, 62, 140, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(10, 62, 140, 255), new Color32(10, 62, 140, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(0, 100, 220, 255), new Color32(0, 100, 220, 255)) }
                        };
                    }
                    return;
                case 40 /* Tenacity */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [Tenacity] [40]";
                    if (swapMenuColors == false)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(124, 25, 194, 255), new Color32(124, 25, 194, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(136, 9, 227, 255), new Color32(136, 9, 227, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(88, 9, 145, 255), new Color32(88, 9, 145, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(136, 9, 227, 255), new Color32(136, 9, 227, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(136, 9, 227, 255), new Color32(136, 9, 227, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(88, 9, 145, 255), new Color32(88, 9, 145, 255)) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(88, 9, 145, 255), new Color32(88, 9, 145, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(136, 9, 227, 255), new Color32(136, 9, 227, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(124, 25, 194, 255), new Color32(124, 25, 194, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(136, 9, 227, 255), new Color32(136, 9, 227, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(136, 9, 227, 255), new Color32(136, 9, 227, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(124, 25, 194, 255), new Color32(124, 25, 194, 255)) }
                        };
                    }
                    return;
                case 41 /* ShibaGT Gold */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [ShibaGT Gold] [41]";
                    if (swapMenuColors == false)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(Color.yellow, Color.black) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(Color.yellow, Color.yellow) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.yellow, Color.yellow) },
                            new ExtGradient{ colors = GetMultiGradient(Color.yellow, Color.yellow) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient { colors = GetMultiGradient(Color.magenta, Color.magenta) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(Color.yellow, Color.black) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(Color.yellow, Color.yellow) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.yellow, Color.yellow) },
                            new ExtGradient{ colors = GetMultiGradient(Color.yellow, Color.yellow) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient { colors = GetMultiGradient(Color.magenta, Color.magenta) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                    }
                    return;
            }
        }
        public static void ChangeThemeTypeBackwards()
        {
            themeType--;
            if (themeType < 1)
            {
                themeType = 41;
            }
            switch (themeType)
            {
                case 1 /* Main */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [Main] [1]";
                    if (swapMenuColors == true)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(255, 136, 249, 255), new Color32(255, 136, 249, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(255, 186, 251, 255), new Color32(255, 204, 253, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(255, 136, 249, 255), new Color32(255, 136, 249, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(255, 186, 251, 255), new Color32(255, 204, 253, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(255, 186, 251, 255), new Color32(255, 190, 253, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(255, 136, 249, 255), new Color32(255, 136, 249, 255)) };
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
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                    }
                    return;
                case 2 /* Red Fade */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [Red Fade] [2]";
                    if (swapMenuColors == false)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(Color.red, Color.black) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.black, Color.black) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(Color.black, Color.red) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.red, Color.red) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient { colors = GetMultiGradient(Color.red, Color.red) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.red, Color.red) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(Color.black, Color.red) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.red, Color.red) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(Color.red, Color.black) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(Color.red, Color.red) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.red, Color.red) },
                            new ExtGradient { colors = GetMultiGradient(Color.black, Color.black) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(Color.red, Color.red) }
                        };
                    }
                    return;
                case 3 /* Orange Fade */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [Orange Fade] [3]";
                    if (swapMenuColors == false)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(249, 105, 14, 255), Color.black) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.black, Color.black) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(Color.black, new Color32(249, 105, 14, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(249, 105, 14, 255), new Color32(249, 105, 14, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient { colors = GetMultiGradient(new Color32(249, 105, 14, 255), new Color32(249, 105, 14, 255)) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(249, 105, 14, 255), new Color32(249, 105, 14, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(Color.black, new Color32(249, 105, 14, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(249, 105, 14, 255), new Color32(249, 105, 14, 255)) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(249, 105, 14, 255), Color.black) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(249, 105, 14, 255), new Color32(249, 105, 14, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(new Color32(249, 105, 14, 255), new Color32(249, 105, 14, 255)) },
                            new ExtGradient { colors = GetMultiGradient(Color.black, Color.black) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(249, 105, 14, 255), new Color32(249, 105, 14, 255)) }
                        };
                    }
                    return;
                case 4 /* Yellow Fade */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [Yellow Fade] [4]";
                    if (swapMenuColors == false)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(Color.yellow, Color.black) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.black, Color.black) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(Color.black, Color.yellow) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.yellow, Color.yellow) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient { colors = GetMultiGradient(Color.yellow, Color.yellow) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.yellow, Color.yellow) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(Color.black, Color.yellow) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.yellow, Color.yellow) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(Color.yellow, Color.black) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(Color.yellow, Color.yellow) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.yellow, Color.yellow) },
                            new ExtGradient { colors = GetMultiGradient(Color.black, Color.black) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(Color.yellow, Color.yellow) }
                        };
                    }
                    return;
                case 5 /* Green Fade */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [Green Fade] [5]";
                    if (swapMenuColors == false)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(Color.green, Color.black) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.black, Color.black) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(Color.black, Color.green) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.green, Color.green) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient { colors = GetMultiGradient(Color.green, Color.green) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.green, Color.green) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(Color.black, Color.green) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.green, Color.green) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(Color.green, Color.black) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(Color.green, Color.green) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.green, Color.green) },
                            new ExtGradient { colors = GetMultiGradient(Color.black, Color.black) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(Color.green, Color.green) }
                        };
                    }
                    return;
                case 6 /* Cyan Fade */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [Cyan Fade] [6]";
                    if (swapMenuColors == false)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(Color.cyan, Color.black) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.black, Color.black) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(Color.black, Color.cyan) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.cyan, Color.cyan) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient { colors = GetMultiGradient(Color.cyan, Color.cyan) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.cyan, Color.cyan) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(Color.black, Color.cyan) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.cyan, Color.cyan) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(Color.cyan, Color.black) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(Color.cyan, Color.cyan) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.cyan, Color.cyan) },
                            new ExtGradient { colors = GetMultiGradient(Color.black, Color.black) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(Color.cyan, Color.cyan) }
                        };
                    }
                    return;
                case 7 /* Blue Fade */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [Blue Fade] [7]";
                    if (swapMenuColors == false)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(Color.blue, Color.black) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.black, Color.black) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(Color.black, Color.blue) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.blue, Color.blue) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient { colors = GetMultiGradient(Color.blue, Color.blue) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.blue, Color.blue) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(Color.black, Color.blue) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.blue, Color.blue) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(Color.blue, Color.black) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(Color.blue, Color.blue) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.blue, Color.blue) },
                            new ExtGradient { colors = GetMultiGradient(Color.black, Color.black) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(Color.blue, Color.blue) }
                        };
                    }
                    return;
                case 8 /* Magenta Fade */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [Magenta Fade] [8]";
                    if (swapMenuColors == false)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(Color.magenta, Color.black) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.black, Color.black) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(Color.black, Color.magenta) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.magenta, Color.magenta) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient { colors = GetMultiGradient(Color.magenta, Color.magenta) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.magenta, Color.magenta) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(Color.black, Color.magenta) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.magenta, Color.magenta) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(Color.magenta, Color.black) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(Color.magenta, Color.magenta) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.magenta, Color.magenta) },
                            new ExtGradient { colors = GetMultiGradient(Color.black, Color.black) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(Color.magenta, Color.magenta) }
                        };
                    }
                    return;
                case 9 /* White Fade */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [White Fade] [9]";
                    if (swapMenuColors == false)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.black) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.black, Color.black) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(Color.black, Color.white) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(Color.black, Color.white) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.black) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(Color.white, Color.white) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient { colors = GetMultiGradient(Color.black, Color.black) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(Color.white, Color.white) }
                        };
                    }
                    return;
                case 10 /* OG Purple */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [Purple] [10]";
                    if (swapMenuColors == false)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(190, 129, 255, 255), new Color32(190, 129, 255, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(156, 64, 255, 255), new Color32(156, 64, 255, 255)) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(175, 105, 250, 255), new Color32(175, 105, 250, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(190, 129, 255, 255), new Color32(190, 129, 255, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(172, 95, 255, 255), new Color32(172, 95, 255, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(new Color32(156, 64, 255, 255), new Color32(156, 64, 255, 255)) },
                            new ExtGradient { colors = GetMultiGradient(new Color32(196, 140, 255, 255), new Color32(196, 140, 255, 255)) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(196, 140, 255, 255), new Color32(196, 140, 255, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(156, 64, 255, 255), new Color32(156, 64, 255, 255)) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(172, 95, 255, 255), new Color32(172, 95, 255, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(196, 140, 255, 255), new Color32(196, 140, 255, 255)) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(194, 138, 255, 255), new Color32(194, 138, 255, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(172, 95, 255, 255), new Color32(172, 95, 255, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(190, 129, 255, 255), new Color32(190, 129, 255, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(new Color32(196, 140, 255, 255), new Color32(196, 140, 255, 255)) },
                            new ExtGradient { colors = GetMultiGradient(new Color32(156, 64, 255, 255), new Color32(156, 64, 255, 255)) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(new Color32(156, 64, 255, 255), new Color32(156, 64, 255, 255)) },
                            new ExtGradient { colors = GetMultiGradient(new Color32(196, 140, 255, 255), new Color32(196, 140, 255, 255)) }
                        };
                    }
                    return;
                case 11 /* OG Blue */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [Blue] [11]";
                    if (swapMenuColors == false)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(106, 109, 255, 255), new Color32(106, 109, 255, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(151, 154, 255, 255), new Color32(151, 154, 255, 255)) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(86, 89, 252, 255), new Color32(86, 89, 252, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(106, 109, 255, 255), new Color32(106, 109, 255, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(67, 71, 255, 255), new Color32(67, 71, 255, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(new Color32(151, 154, 255, 255), new Color32(151, 154, 255, 255)) },
                            new ExtGradient { colors = GetMultiGradient(new Color32(151, 154, 255, 255), new Color32(151, 154, 255, 255)) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(67, 71, 255, 255), new Color32(67, 71, 255, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(106, 109, 255, 255), new Color32(106, 109, 255, 255)) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(67, 71, 255, 255), new Color32(67, 71, 255, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(151, 154, 255, 255), new Color32(151, 154, 255, 255)) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(140, 142, 255, 255), new Color32(140, 142, 255, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(67, 71, 255, 255), new Color32(67, 71, 255, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(106, 109, 255, 255), new Color32(106, 109, 255, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(new Color32(151, 154, 255, 255), new Color32(151, 154, 255, 255)) },
                            new ExtGradient { colors = GetMultiGradient(new Color32(151, 154, 255, 255), new Color32(151, 154, 255, 255)) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(106, 109, 255, 255), new Color32(106, 109, 255, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(67, 71, 255, 255), new Color32(67, 71, 255, 255)) }
                        };
                    }
                    return;
                case 12 /* OG Light Blue */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [Light Blue] [12]";
                    if (swapMenuColors == false)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(156, 222, 255, 255), new Color32(156, 222, 255, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(65, 192, 255, 255), new Color32(65, 192, 255, 255)) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(97, 202, 255, 255), new Color32(97, 202, 255, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(156, 222, 255, 255), new Color32(156, 222, 255, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(110, 207, 255, 255), new Color32(110, 207, 255, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(new Color32(65, 192, 255, 255), new Color32(65, 192, 255, 255)) },
                            new ExtGradient { colors = GetMultiGradient(new Color32(195, 235, 255, 255), new Color32(195, 235, 255, 255)) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(32, 124, 170, 255), new Color32(32, 124, 170, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(82, 166, 207, 255), new Color32(82, 166, 207, 255)) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(110, 207, 255, 255), new Color32(110, 207, 255, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(195, 235, 255, 255), new Color32(195, 235, 255, 255)) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(171, 227, 255, 255), new Color32(171, 227, 255, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(110, 207, 255, 255), new Color32(110, 207, 255, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(156, 222, 255, 255), new Color32(156, 222, 255, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(new Color32(195, 235, 255, 255), new Color32(195, 235, 255, 255)) },
                            new ExtGradient { colors = GetMultiGradient(new Color32(65, 192, 255, 255), new Color32(65, 192, 255, 255)) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(82, 166, 207, 255), new Color32(82, 166, 207, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(32, 124, 170, 255), new Color32(32, 124, 170, 255)) }
                        };
                    }
                    return;
                case 13 /* OG Green */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [Green] [13]";
                    if (swapMenuColors == false)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(106, 255, 106, 255), new Color32(106, 255, 106, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(67, 191, 67, 255), new Color32(67, 191, 67, 255)) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(52, 179, 52, 255), new Color32(52, 179, 52, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(106, 255, 106, 255), new Color32(106, 255, 106, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(67, 191, 67, 255), new Color32(67, 191, 67, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(new Color32(67, 191, 67, 255), new Color32(67, 191, 67, 255)) },
                            new ExtGradient { colors = GetMultiGradient(new Color32(106, 255, 106, 255), new Color32(106, 255, 106, 255)) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(32, 145, 32, 255), new Color32(32, 145, 32, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(50, 117, 50, 255), new Color32(50, 117, 50, 255)) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(67, 191, 67, 255), new Color32(67, 191, 67, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(106, 255, 106, 255), new Color32(106, 255, 106, 255)) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(122, 255, 122, 255), new Color32(122, 255, 122, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(67, 191, 67, 255), new Color32(67, 191, 67, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(106, 255, 106, 255), new Color32(106, 255, 106, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(new Color32(106, 255, 106, 255), new Color32(106, 255, 106, 255)) },
                            new ExtGradient { colors = GetMultiGradient(new Color32(67, 191, 67, 255), new Color32(67, 191, 67, 255)) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(50, 117, 50, 255), new Color32(50, 117, 50, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(32, 145, 32, 255), new Color32(32, 145, 32, 255)) }
                        };
                    }
                    return;
                case 14 /* OG Orange */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [Orange] [14]";
                    if (swapMenuColors == false)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(255, 148, 69, 255), new Color32(255, 148, 69, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(219, 91, 0, 255), new Color32(219, 91, 0, 255)) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(255, 171, 112, 255), new Color32(255, 171, 112, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(255, 148, 69, 255), new Color32(255, 148, 69, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(214, 123, 57, 255), new Color32(214, 123, 57, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(new Color32(219, 91, 0, 255), new Color32(219, 91, 0, 255)) },
                            new ExtGradient { colors = GetMultiGradient(new Color32(171, 71, 0, 255), new Color32(171, 71, 0, 255)) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(171, 71, 0, 255), new Color32(171, 71, 0, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(219, 91, 0, 255), new Color32(219, 91, 0, 255)) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(214, 123, 57, 255), new Color32(214, 123, 57, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(171, 71, 0, 255), new Color32(171, 71, 0, 255)) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(255, 171, 112, 255), new Color32(255, 171, 112, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(214, 123, 57, 255), new Color32(214, 123, 57, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(255, 148, 69, 255), new Color32(255, 148, 69, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(new Color32(171, 71, 0, 255), new Color32(171, 71, 0, 255)) },
                            new ExtGradient { colors = GetMultiGradient(new Color32(219, 91, 0, 255), new Color32(219, 91, 0, 255)) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(219, 91, 0, 255), new Color32(219, 91, 0, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(171, 71, 0, 255), new Color32(171, 71, 0, 255)) }
                        };
                    }
                    return;
                case 15 /* OG Red */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [Red] [15]";
                    if (swapMenuColors == false)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(255, 69, 69, 255), new Color32(255, 69, 69, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(255, 48, 48, 255), new Color32(255, 48, 48, 255)) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(255, 119, 119, 255), new Color32(255, 119, 119, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(255, 69, 69, 255), new Color32(255, 69, 69, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(209, 72, 72, 255), new Color32(209, 72, 72, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(new Color32(255, 48, 48, 255), new Color32(255, 48, 48, 255)) },
                            new ExtGradient { colors = GetMultiGradient(new Color32(161, 31, 31, 255), new Color32(161, 31, 31, 255)) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(161, 31, 31, 255), new Color32(161, 31, 31, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(255, 48, 48, 255), new Color32(255, 48, 48, 255)) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(209, 72, 72, 255), new Color32(209, 72, 72, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(161, 31, 31, 255), new Color32(161, 31, 31, 255)) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(255, 119, 119, 255), new Color32(255, 119, 119, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(209, 72, 72, 255), new Color32(209, 72, 72, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(255, 69, 69, 255), new Color32(255, 69, 69, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(new Color32(161, 31, 31, 255), new Color32(161, 31, 31, 255)) },
                            new ExtGradient { colors = GetMultiGradient(new Color32(255, 48, 48, 255), new Color32(255, 48, 48, 255)) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(255, 48, 48, 255), new Color32(255, 48, 48, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(161, 31, 31, 255), new Color32(161, 31, 31, 255)) }
                        };
                    }
                    return;
                case 16 /* Mr R. (BENDY AND THE RAPE MACHINE) */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [Mr. R] [16]";
                    if (swapMenuColors == false)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(8, 7, 0, 255), new Color32(8, 7, 0, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(138, 115, 69, 255), new Color32(138, 115, 69, 255)) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(138, 115, 69, 255), new Color32(138, 115, 69, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(8, 7, 0, 255), new Color32(8, 7, 0, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(8, 7, 0, 255), new Color32(8, 7, 0, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(new Color32(138, 115, 69, 255), new Color32(138, 115, 69, 255)) },
                            new ExtGradient { colors = GetMultiGradient(new Color32(97, 80, 47, 255), new Color32(97, 80, 47, 255)) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(97, 80, 47, 255), new Color32(97, 80, 47, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(138, 115, 69, 255), new Color32(138, 115, 69, 255)) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(138, 115, 69, 255), new Color32(138, 115, 69, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(8, 7, 0, 255), new Color32(8, 7, 0, 255)) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(8, 7, 0, 255), new Color32(8, 7, 0, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(138, 115, 69, 255), new Color32(138, 115, 69, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(138, 115, 69, 255), new Color32(138, 115, 69, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(new Color32(97, 80, 47, 255), new Color32(97, 80, 47, 255)) },
                            new ExtGradient { colors = GetMultiGradient(new Color32(8, 7, 0, 255), new Color32(8, 7, 0, 255)) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(8, 7, 0, 255), new Color32(8, 7, 0, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(97, 80, 47, 255), new Color32(97, 80, 47, 255)) }
                        };
                    }
                    return;
                case 17 /* Dracula */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [Dracula] [17]";
                    if (swapMenuColors == false)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(33, 32, 43, 255), new Color32(33, 32, 43, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(20, 18, 31, 255), new Color32(20, 18, 31, 255)) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(42, 37, 63, 255), new Color32(42, 37, 63, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(41, 39, 53, 255), new Color32(41, 39, 53, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(20, 18, 31, 255), new Color32(20, 18, 31, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(new Color32(20, 18, 31, 255), new Color32(20, 18, 31, 255)) },
                            new ExtGradient { colors = GetMultiGradient(new Color32(41, 39, 53, 255), new Color32(41, 39, 53, 255)) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(149, 128, 253, 255), new Color32(149, 128, 253, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(149, 128, 253, 255), new Color32(149, 128, 253, 255)) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(42, 37, 63, 255), new Color32(42, 37, 63, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(20, 18, 31, 255), new Color32(20, 18, 31, 255)) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(33, 32, 43, 255), new Color32(33, 32, 43, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(20, 18, 31, 255), new Color32(20, 18, 31, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(41, 39, 53, 255), new Color32(41, 39, 53, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(new Color32(41, 39, 53, 255), new Color32(41, 39, 53, 255)) },
                            new ExtGradient { colors = GetMultiGradient(new Color32(20, 18, 31, 255), new Color32(20, 18, 31, 255)) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(149, 128, 253, 255), new Color32(149, 128, 253, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(149, 128, 253, 255), new Color32(149, 128, 253, 255)) }
                        };
                    }
                    return;
                case 18 /* Noctua */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [Noctua] [18]";
                    if (swapMenuColors == false)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(231, 206, 181, 255), new Color32(231, 206, 181, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(101, 48, 36, 255), new Color32(101, 48, 36, 255)) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(101, 48, 36, 255), new Color32(101, 48, 36, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(231, 206, 181, 255), new Color32(231, 206, 181, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(101, 48, 36, 255), new Color32(101, 48, 36, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(new Color32(101, 48, 36, 255), new Color32(101, 48, 36, 255)) },
                            new ExtGradient { colors = GetMultiGradient(new Color32(231, 206, 181, 255), new Color32(231, 206, 181, 255)) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(251, 226, 201, 255), new Color32(251, 226, 201, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(141, 88, 76, 255), new Color32(141, 88, 76, 255)) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(101, 48, 36, 255), new Color32(101, 48, 36, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(231, 206, 181, 255), new Color32(231, 206, 181, 255)) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(231, 206, 181, 255), new Color32(231, 206, 181, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(101, 48, 36, 255), new Color32(101, 48, 36, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(231, 206, 181, 255), new Color32(231, 206, 181, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(new Color32(231, 206, 181, 255), new Color32(231, 206, 181, 255)) },
                            new ExtGradient { colors = GetMultiGradient(new Color32(101, 48, 36, 255), new Color32(101, 48, 36, 255)) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(141, 88, 76, 255), new Color32(141, 88, 76, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(251, 226, 201, 255), new Color32(251, 226, 201, 255)) }
                        };
                    }
                    return;
                case 19 /* Oblivion */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [Oblivion] [19]";
                    if (swapMenuColors == false)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(10, 10, 10, 255), new Color32(10, 10, 10, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(188, 130, 255, 255), new Color32(188, 130, 255, 255)) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(188, 130, 255, 255), new Color32(188, 130, 255, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(10, 10, 10, 255), new Color32(10, 10, 10, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(188, 130, 255, 255), new Color32(188, 130, 255, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(new Color32(188, 130, 255, 255), new Color32(188, 130, 255, 255)) },
                            new ExtGradient { colors = GetMultiGradient(new Color32(10, 10, 10, 255), new Color32(10, 10, 10, 255)) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(78, 20, 155, 255), new Color32(78, 20, 155, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(188, 130, 255, 255), new Color32(188, 130, 255, 255)) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(188, 130, 255, 255), new Color32(188, 130, 255, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(10, 10, 10, 255), new Color32(10, 10, 10, 255)) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(10, 10, 10, 255), new Color32(10, 10, 10, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(188, 130, 255, 255), new Color32(188, 130, 255, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(10, 10, 10, 255), new Color32(10, 10, 10, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(new Color32(10, 10, 10, 255), new Color32(10, 10, 10, 255)) },
                            new ExtGradient { colors = GetMultiGradient(new Color32(188, 130, 255, 255), new Color32(188, 130, 255, 255)) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(228, 170, 255, 255), new Color32(228, 170, 255, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(78, 20, 155, 255), new Color32(78, 20, 155, 255)) }
                        };
                    }
                    return;
                case 20 /* Midnight */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [Midnight] [20]";
                    if (swapMenuColors == true)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(4, 0, 170, 255), new Color32(4, 0, 190, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(2, 0, 94, 255), new Color32(2, 0, 94, 255)) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(6, 3, 128, 255), new Color32(6, 3, 128, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(4, 0, 170, 255), new Color32(4, 0, 190, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(1, 0, 53, 255), new Color32(1, 0, 43, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(new Color32(2, 0, 94, 255), new Color32(2, 0, 94, 255)) },
                            new ExtGradient { colors = GetMultiGradient(new Color32(127, 124, 255, 255), new Color32(127, 124, 255, 255)) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(127, 124, 255, 255), new Color32(127, 124, 255, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(42, 0, 134, 255), new Color32(42, 0, 134, 255)) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(1, 0, 62, 255), new Color32(2, 0, 93, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(127, 124, 255, 255), new Color32(127, 124, 255, 255)) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(21, 16, 204, 255), new Color32(21, 16, 204, 255)) };
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
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(42, 0, 134, 255), new Color32(42, 0, 134, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(127, 124, 255, 255), new Color32(127, 124, 255, 255)) }
                        };
                    }
                    return;
                case 21 /* Folly */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [Folly] [21]";
                    if (swapMenuColors == false)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(10, 0, 3, 255), new Color32(14, 0, 4, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(255, 0, 79, 255), new Color32(252, 0, 78, 255)) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(255, 0, 79, 255), new Color32(252, 0, 78, 255)) };
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
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(145, 0, 39, 255), new Color32(142, 0, 18, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(145, 0, 39, 255), new Color32(142, 0, 18, 255)) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(255, 0, 79, 255), new Color32(252, 0, 78, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(10, 0, 3, 255), new Color32(14, 0, 4, 255)) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(10, 0, 3, 255), new Color32(14, 0, 4, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(255, 0, 79, 255), new Color32(252, 0, 78, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(10, 0, 3, 255), new Color32(14, 0, 4, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(new Color32(10, 0, 3, 255), new Color32(14, 0, 4, 255)) },
                            new ExtGradient { colors = GetMultiGradient(new Color32(255, 0, 79, 255), new Color32(252, 0, 78, 255)) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(145, 0, 39, 255), new Color32(142, 0, 18, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(145, 0, 39, 255), new Color32(142, 0, 18, 255)) }
                        };
                    }
                    return;
                case 22 /* Bad Apple */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [Bad Apple] [22]";
                    if (swapMenuColors == false)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(10, 13, 17, 255), new Color32(10, 13, 17, 255)) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(10, 13, 17, 255), new Color32(10, 13, 17, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient{ colors = GetMultiGradient(Color.white, Color.white) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(new Color32(10, 13, 17, 255), new Color32(10, 13, 17, 255)) },
                            new ExtGradient { colors = GetMultiGradient(Color.green, Color.green) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(10, 13, 17, 255), new Color32(10, 13, 17, 255)) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(10, 13, 17, 255), new Color32(10, 13, 17, 255)) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(10, 13, 17, 255), new Color32(10, 13, 17, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient{ colors = GetMultiGradient(Color.white, Color.white) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(new Color32(10, 13, 17, 255), new Color32(10, 13, 17, 255)) },
                            new ExtGradient { colors = GetMultiGradient(Color.green, Color.green) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(10, 13, 17, 255), new Color32(10, 13, 17, 255)) }
                        };
                    }
                    return;
                case 23 /* ii's Stupid Menu */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [ii's Stupid Menu] [23]";
                    if (swapMenuColors == false)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(255, 128, 0, 255), new Color32(255, 102, 0, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(255, 190, 125, 255), new Color32(255, 190, 125, 255)) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(85, 42, 0, 255), new Color32(85, 42, 0, 255)) };
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
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(180, 115, 50, 255), new Color32(180, 115, 50, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(180, 115, 50, 255), new Color32(180, 115, 50, 255)) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(170, 85, 0, 255), new Color32(170, 85, 0, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(255, 190, 125, 255), new Color32(255, 190, 125, 255)) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(255, 128, 0, 255), new Color32(255, 102, 0, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(85, 42, 0, 255), new Color32(85, 42, 0, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(255, 128, 0, 255), new Color32(255, 102, 0, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(new Color32(255, 190, 125, 255), new Color32(255, 190, 125, 255)) },
                            new ExtGradient { colors = GetMultiGradient(new Color32(255, 190, 125, 255), new Color32(255, 190, 125, 255)) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(180, 115, 50, 255), new Color32(180, 115, 50, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(180, 115, 50, 255), new Color32(180, 115, 50, 255)) }
                        };
                    }
                    return;
                case 24 /* Wyvern OLD */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [Old Wyvern] [24]";
                    if (swapMenuColors == false)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(199, 115, 173, 255), new Color32(165, 233, 185, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(165, 233, 185, 255), new Color32(199, 115, 173, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(99, 58, 86, 255), new Color32(83, 116, 92, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(99, 58, 86, 255), new Color32(83, 116, 92, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient { colors = GetMultiGradient(Color.green, Color.green) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(99, 58, 86, 255), new Color32(83, 116, 92, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(165, 233, 185, 255), new Color32(199, 115, 173, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(199, 115, 173, 255), new Color32(165, 233, 185, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(199, 115, 173, 255), new Color32(165, 233, 185, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient { colors = GetMultiGradient(Color.green, Color.green) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                    }
                    return;
                case 25 /* Wyvern */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [Wyvern] [25]";
                    if (swapMenuColors == false)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(20, 20, 22, 255), new Color32(20, 20, 22, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(51, 199, 127, 255), new Color32(51, 199, 127, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(50, 50, 50, 255), new Color32(50, 50, 50, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(51, 199, 127, 255), new Color32(51, 199, 127, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient { colors = GetMultiGradient(Color.green, Color.green) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(20, 20, 22, 255), new Color32(20, 20, 22, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(50, 50, 50, 255), new Color32(50, 50, 50, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(51, 199, 127, 255), new Color32(51, 199, 127, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(50, 50, 50, 255), new Color32(50, 50, 50, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient { colors = GetMultiGradient(Color.green, Color.green) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                    }
                    return;
                case 26 /* ShibaGT Genesis */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [ShibaGT Genesis] [26]";
                    if (swapMenuColors == false)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(0, 0, 200, 255), Color.blue) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(0, 0, 200, 255), new Color32(0, 0, 200, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(0, 0, 200, 255), new Color32(0, 0, 200, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(0, 0, 200, 255), new Color32(0, 0, 200, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient { colors = GetMultiGradient(Color.magenta, Color.magenta) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(0, 0, 200, 255), new Color32(0, 0, 200, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(0, 0, 200, 255), new Color32(0, 0, 200, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(0, 0, 200, 255), Color.blue) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(0, 0, 200, 255), Color.blue) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient { colors = GetMultiGradient(Color.magenta, Color.magenta) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                    }
                    return;
                case 27 /* Untitled */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [Untitled] [27]";
                    if (swapMenuColors == false)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(19, 20, 36, 255), new Color32(19, 20, 36, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(10, 10, 19, 255), new Color32(10, 10, 19, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(39, 39, 60, 255), new Color32(39, 39, 60, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(10, 10, 19, 255), new Color32(10, 10, 19, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(10, 10, 19, 255), new Color32(10, 10, 19, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(39, 39, 60, 255), new Color32(39, 39, 60, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(19, 20, 36, 255), new Color32(19, 20, 36, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(39, 39, 60, 255), new Color32(39, 39, 60, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                    }
                    return;
                case 28 /* Orbit */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [Orbit] [28]";
                    if (swapMenuColors == false)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(36, 0, 78, 255), Color.black) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(54, 1, 109, 255), new Color32(54, 1, 109, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(54, 1, 109, 255), new Color32(54, 1, 109, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(54, 1, 109, 255), new Color32(54, 1, 109, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient { colors = GetMultiGradient(new Color32(153, 117, 191, 255), new Color32(153, 117, 191, 255)) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(153, 117, 191, 255), new Color32(153, 117, 191, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(Color.white, Color.white) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(54, 1, 109, 255), new Color32(54, 1, 109, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(36, 0, 78, 255), Color.black) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(36, 0, 78, 255), Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(36, 0, 78, 255), Color.black) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient { colors = GetMultiGradient(new Color32(153, 117, 191, 255), new Color32(153, 117, 191, 255)) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(153, 117, 191, 255), new Color32(153, 117, 191, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(Color.white, Color.white) }
                        };
                    }
                    return;
                case 29 /* Destiny OLD */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [Old Destiny] [29]";
                    if (swapMenuColors == false)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) }; // HAS CUSTOM BACKGROUND, GO TO MAIN.CS TO EDIT
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(0, 180, 150, 255), new Color32(0, 180, 150, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(0, 180, 150, 255), new Color32(0, 180, 150, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(0, 122, 99, 255), new Color32(0, 122, 99, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(0, 122, 99, 255), new Color32(0, 122, 99, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(0, 122, 99, 255), new Color32(0, 122, 99, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(0, 180, 150, 255), new Color32(0, 180, 150, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                    }
                    return;
                case 30 /* Destiny RAT */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [Destiny] [30]";
                    if (swapMenuColors == false)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(10, 10, 10, 255), new Color32(10, 10, 10, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(0, 254, 209, 255), new Color32(0, 254, 209, 255)) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(0, 255, 250, 255), new Color32(0, 255, 250, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(40, 40, 40, 255), new Color32(40, 40, 40, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(60, 60, 60, 255), new Color32(60, 60, 60, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(10, 10, 10, 255), new Color32(10, 10, 10, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(0, 254, 209, 255), new Color32(0, 254, 209, 255)) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(0, 255, 250, 255), new Color32(0, 255, 250, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(60, 60, 60, 255), new Color32(60, 60, 60, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(40, 40, 40, 255), new Color32(40, 40, 40, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                    }
                    return;
                case 31 /* Haunted Mod Menu */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [Haunted Mod Menu] [31]";
                    if (swapMenuColors == false)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(8, 9, 13, 255), new Color32(8, 9, 13, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(160, 159, 162, 255), new Color32(160, 159, 162, 255)) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(160, 159, 162, 255), new Color32(160, 159, 162, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(210, 64, 66, 255), new Color32(210, 64, 66, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(125, 180, 95, 255), new Color32(125, 180, 95, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(new Color32(7, 8, 0, 255), new Color32(7, 8, 0, 255)) },
                            new ExtGradient { colors = GetMultiGradient(new Color32(7, 8, 0, 255), new Color32(7, 8, 0, 255)) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient{ colors = GetMultiGradient(Color.white, Color.white) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(160, 159, 162, 255), new Color32(160, 159, 162, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(8, 9, 13, 255), new Color32(8, 9, 13, 255)) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(8, 9, 13, 255), new Color32(8, 9, 13, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(210, 64, 66, 255), new Color32(210, 64, 66, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(125, 180, 95, 255), new Color32(125, 180, 95, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(new Color32(160, 159, 162, 255), new Color32(160, 159, 162, 255)) },
                            new ExtGradient { colors = GetMultiGradient(new Color32(160, 159, 162, 255), new Color32(160, 159, 162, 255)) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient{ colors = GetMultiGradient(Color.white, Color.white) }
                        };
                    }
                    return;
                case 32 /* Spectral Menu */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [Spectral Menu] [32]";
                    if (swapMenuColors == false)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(5, 10, 40, 255), new Color32(5, 10, 40, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(60, 120, 255, 255), new Color32(60, 120, 255, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(5, 10, 40, 255), new Color32(5, 10, 40, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(40, 80, 200, 255), new Color32(40, 80, 200, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(40, 80, 200, 255), new Color32(40, 80, 200, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(60, 120, 255, 255), new Color32(60, 120, 255, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(40, 80, 200, 255), new Color32(40, 80, 200, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(5, 10, 40, 255), new Color32(5, 10, 40, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                    }
                    return;
                case 33 /* Explicit Menu */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [Explicit Menu] [33]";
                    if (swapMenuColors == false)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(15, 15, 15, 255), new Color32(15, 15, 15, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(77, 77, 77, 255), new Color32(77, 77, 77, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(40, 40, 40, 255), new Color32(40, 40, 40, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(75, 75, 75, 255), new Color32(75, 75, 75, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(75, 75, 75, 255), new Color32(75, 75, 75, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(40, 40, 40, 255), new Color32(40, 40, 40, 255)) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(40, 40, 40, 255), new Color32(40, 40, 40, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(77, 77, 77, 255), new Color32(77, 77, 77, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(15, 15, 15, 255), new Color32(15, 15, 15, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(75, 75, 75, 255), new Color32(75, 75, 75, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(75, 75, 75, 255), new Color32(75, 75, 75, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(40, 40, 40, 255), new Color32(40, 40, 40, 255)) }
                        };
                    }
                    return;
                case 34 /* GPhys */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [GPhys] [34]";
                    if (swapMenuColors == false)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(82, 113, 255, 255), new Color32(82, 113, 255, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(60, 85, 200, 255), new Color32(60, 85, 200, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(82, 113, 255, 255), new Color32(82, 113, 255, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(60, 85, 200, 255), new Color32(60, 85, 200, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(60, 85, 200, 255), new Color32(60, 85, 200, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(82, 113, 255, 255), new Color32(82, 113, 255, 255)) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(60, 85, 200, 255), new Color32(60, 85, 200, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(82, 113, 255, 255), new Color32(82, 113, 255, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(60, 85, 200, 255), new Color32(60, 85, 200, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(82, 113, 255, 255), new Color32(82, 113, 255, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(82, 113, 255, 255), new Color32(82, 113, 255, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(60, 85, 200, 255), new Color32(60, 85, 200, 255)) }
                        };
                    }
                    return;
                case 35 /* Sentinel */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [Sentinel] [35]";
                    if (swapMenuColors == false)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(10, 10, 31, 255), new Color32(10, 10, 31, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(24, 25, 112, 255), new Color32(24, 25, 112, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(24, 25, 112, 255), new Color32(24, 25, 112, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(76, 0, 130, 255), new Color32(76, 0, 130, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient { colors = GetMultiGradient(Color.magenta, Color.magenta) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(24, 25, 112, 255), new Color32(24, 25, 112, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(10, 10, 31, 255), new Color32(10, 10, 31, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(10, 10, 31, 255), new Color32(10, 10, 31, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(76, 0, 130, 255), new Color32(76, 0, 130, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient { colors = GetMultiGradient(Color.magenta, Color.magenta) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                    }
                    return;
                case 36 /* Scintilla */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [Scintilla] [36]";
                    if (swapMenuColors == false)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(134, 75, 214, 255), new Color32(134, 75, 214, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(95, 41, 151, 255), new Color32(95, 41, 151, 255)) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(87, 42, 130, 255), new Color32(87, 42, 130, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(87, 42, 130, 255), new Color32(87, 42, 130, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(134, 75, 214, 255), new Color32(134, 75, 214, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(87, 42, 130, 255), new Color32(87, 42, 130, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(134, 75, 214, 255), new Color32(134, 75, 214, 255)) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(134, 75, 214, 255), new Color32(134, 75, 214, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(134, 75, 214, 255), new Color32(134, 75, 214, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(87, 42, 130, 255), new Color32(87, 42, 130, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                    }
                    return;
                case 37 /* Heal */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [Heal] [37]";
                    if (swapMenuColors == false)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(159, 90, 254, 255), new Color32(159, 90, 254, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(131, 81, 184, 255), new Color32(131, 81, 184, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(101, 50, 154, 255), new Color32(101, 50, 154, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(131, 81, 184, 255), new Color32(131, 81, 184, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(101, 50, 154, 255), new Color32(101, 50, 154, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(134, 75, 214, 255), new Color32(134, 75, 214, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(131, 81, 184, 255), new Color32(131, 81, 184, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(101, 50, 154, 255), new Color32(101, 50, 154, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                    }
                    return;
                case 38 /* Solace (REXON) */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [Solace (REXON)] [38]";
                    if (swapMenuColors == false)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(26, 59, 34, 255), new Color32(26, 59, 34, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(79, 201, 101, 255), new Color32(79, 201, 101, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(26, 59, 34, 255), new Color32(26, 59, 34, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(48, 152, 73, 255), new Color32(48, 152, 73, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(48, 152, 73, 255), new Color32(48, 152, 73, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(79, 201, 101, 255), new Color32(79, 201, 101, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(48, 152, 73, 255), new Color32(48, 152, 73, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(26, 59, 34, 255), new Color32(26, 59, 34, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                    }
                    return;
                case 39 /* Solace.lol (KINGOFNETFLIX/BTC) */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [solace.lol] [39]";
                    if (swapMenuColors == false)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(10, 164, 192, 255), new Color32(10, 164, 192, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(10, 62, 140, 255), new Color32(10, 62, 140, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(0, 100, 220, 255), new Color32(0, 100, 220, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(10, 62, 140, 255), new Color32(10, 62, 140, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(10, 62, 140, 255), new Color32(10, 62, 140, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(0, 100, 220, 255), new Color32(0, 100, 220, 255)) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(0, 100, 220, 255), new Color32(0, 100, 220, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(10, 62, 140, 255), new Color32(10, 62, 140, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(10, 164, 192, 255), new Color32(10, 164, 192, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(10, 62, 140, 255), new Color32(10, 62, 140, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(10, 62, 140, 255), new Color32(10, 62, 140, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(0, 100, 220, 255), new Color32(0, 100, 220, 255)) }
                        };
                    }
                    return;
                case 40 /* Tenacity */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [Tenacity] [40]";
                    if (swapMenuColors == false)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(124, 25, 194, 255), new Color32(124, 25, 194, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(136, 9, 227, 255), new Color32(136, 9, 227, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(88, 9, 145, 255), new Color32(88, 9, 145, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(136, 9, 227, 255), new Color32(136, 9, 227, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(136, 9, 227, 255), new Color32(136, 9, 227, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(88, 9, 145, 255), new Color32(88, 9, 145, 255)) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(88, 9, 145, 255), new Color32(88, 9, 145, 255)) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(new Color32(136, 9, 227, 255), new Color32(136, 9, 227, 255)) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(124, 25, 194, 255), new Color32(124, 25, 194, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(136, 9, 227, 255), new Color32(136, 9, 227, 255)) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(new Color32(136, 9, 227, 255), new Color32(136, 9, 227, 255)) },
                            new ExtGradient{ colors = GetMultiGradient(new Color32(124, 25, 194, 255), new Color32(124, 25, 194, 255)) }
                        };
                    }
                    return;
                case 41 /* ShibaGT Gold */:
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [ShibaGT Gold] [41]";
                    if (swapMenuColors == false)
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(Color.yellow, Color.black) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(Color.yellow, Color.yellow) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.yellow, Color.yellow) },
                            new ExtGradient{ colors = GetMultiGradient(Color.yellow, Color.yellow) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient { colors = GetMultiGradient(Color.magenta, Color.magenta) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                    }
                    else
                    {
                        bgColors = new ExtGradient { colors = GetMultiGradient(Color.yellow, Color.black) };
                        titleColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) };
                        outlineColors = new ExtGradient { colors = GetMultiGradient(Color.yellow, Color.yellow) };
                        btColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.yellow, Color.yellow) },
                            new ExtGradient{ colors = GetMultiGradient(Color.yellow, Color.yellow) }
                        };
                        txtColors = new ExtGradient[]
                        {
                            new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) },
                            new ExtGradient { colors = GetMultiGradient(Color.magenta, Color.magenta) }
                        };
                        txtOutlineColors = new ExtGradient[]
                        {
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) },
                            new ExtGradient{ colors = GetMultiGradient(Color.black, Color.black) }
                        };
                    }
                    return;
            }
        }
        public static void ChangeFontTypeBackwards()
        {
            fontType--;
            if (fontType < 0) // to get the number of fonts exactly, add 1 onto this number
            {
                fontType = 25;
            }

            switch (fontType)
            {
                case 0:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Comic Sans] [1]";
                    currentFont = sans;
                    return;
                case 1:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Arial] [2]";
                    currentFont = Arial;
                    return;
                case 2:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Berdana] [3]";
                    currentFont = Verdana;
                    return;
                case 3:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Consolas] [4]";
                    currentFont = consolas;
                    return;
                case 4:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Ubuntu] [5]";
                    currentFont = ubuntu;
                    return;
                case 5:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [MS Gothic] [6]";
                    currentFont = MSGOTHIC;
                    return;
                case 6:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Impact] [7]";
                    currentFont = impact;
                    return;
                case 7:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Bahnschrift] [8]";
                    currentFont = bahnschrift;
                    return;
                case 8:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Calibri] [9]";
                    currentFont = calibri;
                    return;
                case 9:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Cambria] [10]";
                    currentFont = cambria;
                    return;
                case 10:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Cascadia Code] [11]";
                    currentFont = cascadiacode;
                    return;
                case 11:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Constantia] [12]";
                    currentFont = constantia;
                    return;
                case 12:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Corbel] [13]";
                    currentFont = corbel;
                    return;
                case 13:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Courier New] [14]";
                    currentFont = couriernew;
                    return;
                case 14:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Dengxian] [15]";
                    currentFont = dengxian;
                    return;
                case 15:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Ebrima] [16]";
                    currentFont = ebrima;
                    return;
                case 16:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Fangsong] [17]";
                    currentFont = fangsong;
                    return;
                case 17:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Franklin Gothic] [18]";
                    currentFont = franklingothic;
                    return;
                case 18:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Gabriola] [19]";
                    currentFont = gabriola;
                    return;
                case 19:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Gadugi] [20]";
                    currentFont = gadugi;
                    return;
                case 20:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Georgia] [21]";
                    currentFont = georgia;
                    return;
                case 21:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Hololens] [22]";
                    currentFont = hololens;
                    return;
                case 22:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Ink Free] [23]";
                    currentFont = inkfree;
                    return;
                case 23:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Javanese Text] [24]";
                    currentFont = javanesetext;
                    return;
                case 24:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Kaiti] [25]";
                    currentFont = kaiti;
                    return;
                case 25:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Lucida Console] [26]";
                    currentFont = lucidaconsole;
                    return;
            }
        }
        public static void ChangeFontTypeForwards()
        {
            fontType++;
            if (fontType > 25) // to get the number of fonts exactly, add 1 onto this number
            {
                fontType = 0;
            }

            switch (fontType)
            {
                case 0:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Comic Sans] [1]";
                    currentFont = sans;
                    return;
                case 1:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Arial] [2]";
                    currentFont = Arial;
                    return;
                case 2:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Berdana] [3]";
                    currentFont = Verdana;
                    return;
                case 3:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Consolas] [4]";
                    currentFont = consolas;
                    return;
                case 4:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Ubuntu] [5]";
                    currentFont = ubuntu;
                    return;
                case 5:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [MS Gothic] [6]";
                    currentFont = MSGOTHIC;
                    return;
                case 6:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Impact] [7]";
                    currentFont = impact;
                    return;
                case 7:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Bahnschrift] [8]";
                    currentFont = bahnschrift;
                    return;
                case 8:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Calibri] [9]";
                    currentFont = calibri;
                    return;
                case 9:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Cambria] [10]";
                    currentFont = cambria;
                    return;
                case 10:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Cascadia Code] [11]";
                    currentFont = cascadiacode;
                    return;
                case 11:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Constantia] [12]";
                    currentFont = constantia;
                    return;
                case 12:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Corbel] [13]";
                    currentFont = corbel;
                    return;
                case 13:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Courier New] [14]";
                    currentFont = couriernew;
                    return;
                case 14:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Dengxian] [15]";
                    currentFont = dengxian;
                    return;
                case 15:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Ebrima] [16]";
                    currentFont = ebrima;
                    return;
                case 16:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Fangsong] [17]";
                    currentFont = fangsong;
                    return;
                case 17:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Franklin Gothic] [18]";
                    currentFont = franklingothic;
                    return;
                case 18:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Gabriola] [19]";
                    currentFont = gabriola;
                    return;
                case 19:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Gadugi] [20]";
                    currentFont = gadugi;
                    return;
                case 20:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Georgia] [21]";
                    currentFont = georgia;
                    return;
                case 21:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Hololens] [22]";
                    currentFont = hololens;
                    return;
                case 22:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Ink Free] [23]";
                    currentFont = inkfree;
                    return;
                case 23:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Javanese Text] [24]";
                    currentFont = javanesetext;
                    return;
                case 24:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Kaiti] [25]";
                    currentFont = kaiti;
                    return;
                case 25:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Lucida Console] [26]";
                    currentFont = lucidaconsole;
                    return;
            }
        }
    }
}
