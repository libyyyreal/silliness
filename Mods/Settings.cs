using silliness.Classes;
using silliness.Menu;
using silliness.Notifications;
using System.IO;
using static silliness.Menu.Customization;
using static silliness.Menu.Main;
using static silliness.Mods.Settings.MovementSettings;

namespace silliness.Mods
{
    internal class SettingsMods
    {
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

        public static void EnableDiscordText()
        {
            discordtext = true;
        }

        public static void DisableDiscordText()
        {
            discordtext = false;
        }

        public static void SavePreferences()
        {
            string text = "";
            foreach (ButtonInfo[] buttonlist in Buttons.buttons)
            {
                foreach (ButtonInfo v in buttonlist)
                {
                    if (v.enabled && v.buttonText != "Save Preferences")
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
            File.WriteAllText("silliness/CurrentTheme.txt", themeType.ToString());
            File.WriteAllText("silliness/CurrentFont.txt", fontType.ToString());
            File.WriteAllText("silliness/CurrentFlySpeed.txt", flyType.ToString());
            File.WriteAllText("silliness/CurrentSpeedboost.txt", speedboostType.ToString());
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
                string themer = File.ReadAllText("silliness/CurrentTheme.txt");
                string fonter = File.ReadAllText("silliness/CurrentFont.txt");
                string flyspeeder = File.ReadAllText("silliness/CurrentFlySpeed.txt");
                string speedbooster = File.ReadAllText("silliness/CurrentSpeedboost.txt");

                themeType = int.Parse(themer) - 1;
                Toggle("Change Theme >");
                fontType = int.Parse(fonter) - 1;
                Toggle("Change Font >");
                flyType = int.Parse(flyspeeder) - 1;
                Toggle("Change Fly Speed [Normal]");
                speedboostType = int.Parse(speedbooster) - 1;
                Toggle("Change Speedboost [Normal]");
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
