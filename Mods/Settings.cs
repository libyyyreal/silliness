using silliness.Classes;
using silliness.Menu;
using silliness.Notifications;
using System.IO;
using static silliness.Menu.Customization;
using static silliness.Menu.Main;

namespace silliness.Mods
{
    internal class SettingsMods
    {
        public static void EnterSettings()
        {
            buttonsType = 1;
        }

        public static void MenuSettings()
        {
            buttonsType = 2;
        }

        public static void MovementSettings()
        {
            buttonsType = 3;
        }

        public static void ProjectileSettings()
        {
            buttonsType = 4;
        }

        public static void CustomizationSettings()
        {
            buttonsType = 5;
        }

        public static void RightHand()
        {
            rightHanded = true;
        }

        public static void LeftHand()
        {
            rightHanded = false;
        }

        public static void EnableFPSCounter()
        {
            fpsCounter = true;
        }

        public static void DisableFPSCounter()
        {
            fpsCounter = false;
        }

        public static void EnableNotifications()
        {
            disableNotifications = false;
        }

        public static void DisableNotifications()
        {
            disableNotifications = true;
        }

        public static void EnableDisconnectButton()
        {
            disconnectButton = true;
        }

        public static void DisableDisconnectButton()
        {
            disconnectButton = false;
        }

        public static void SavePreferences()
        {
            string text = "";
            foreach (ButtonInfo[] buttonlist in Buttons.buttons)
            {
                foreach (ButtonInfo v in buttonlist)
                {
                    if (v.enabled && v.buttonText != "save preferences")
                    {
                        if (text == "")
                        {
                            text += v.buttonText;
                        }
                        else
                        {
                            text += "\n" + v.buttonText;
                        }
                    }
                }
            }

            if (!Directory.Exists("silliness"))
            {
                Directory.CreateDirectory("silliness");
            }
            File.WriteAllText("silliness/EnabledMods.txt", text);
            File.WriteAllText("silliness/EnabledTheme.txt", themeType.ToString());
        }
        public static void LoadPreferences()
        {
            if (Directory.Exists("silliness"))
            {
                TurnOffAllMods();
                try
                {
                    string config = File.ReadAllText("silliness/EnabledMods.txt");
                    string[] activebuttons = config.Split("\n");
                    for (int index = 0; index < activebuttons.Length; index++)
                    {
                        Toggle(activebuttons[index]);
                    }
                }
                catch { }
                string themer = File.ReadAllText("silliness/EnabledTheme.txt");

                themeType = int.Parse(themer) - 1;
                Toggle("change theme >");
            }
        }
        public static void TurnOffAllMods()
        {
            foreach (ButtonInfo[] buttonlist in Buttons.buttons)
            {
                foreach (ButtonInfo v in buttonlist)
                {
                    if (v.enabled)
                    {
                        Toggle(v.buttonText);
                    }
                }
            }
            NotifiLib.ClearAllNotifications();
        }
    }
}
