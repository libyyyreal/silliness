using silliness.Classes;
using UnityEngine;
using static silliness.Menu.Main;

namespace silliness.Menu
{
    internal class Customization
    {
        public static ExtGradient bgColors = new ExtGradient{ colors = GetMultiGradient(bgColorsA, bgColorsB) }; // Background Colors
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

        public static Font currentFont = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;

        public static bool fpsCounter = true;
        public static bool disconnectButton = true;
        public static bool rightHanded = false;
        public static bool disableNotifications = false;
        public static bool shouldOutline = true;

        public static KeyCode keyboardButton = KeyCode.Q;

        public static Vector3 menuSize = new Vector3(0.1f, 1f, 1f); // Depth, Width, Height
        public static int buttonsPerPage = 8;

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
            }
        }
    }
}
