using silliness.Classes;
using silliness.Mods;
using static silliness.Menu.Customization;

namespace silliness.Menu
{
    internal class Buttons
    {
        public static ButtonInfo[][] buttons = new ButtonInfo[][]
        {
            new ButtonInfo[] { // Main Mods [0]
                new ButtonInfo { buttonText = "settings", method =() => SettingsMods.EnterSettings(), isTogglable = false, toolTip = "opens the main settings page for the menu"},
                new ButtonInfo { buttonText = "togglable placeholder"},
            },

            new ButtonInfo[] { // Settings [1]
                new ButtonInfo { buttonText = "return to main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "returns to the main page of the menu"},
                new ButtonInfo { buttonText = "menu", method =() => SettingsMods.MenuSettings(), isTogglable = false, toolTip = "opens the settings for the menu"},
                new ButtonInfo { buttonText = "customization", method =() => SettingsMods.CustomizationSettings(), isTogglable = false, toolTip = "opens the customization settings for the menu"},
                new ButtonInfo { buttonText = "movement", method =() => SettingsMods.MovementSettings(), isTogglable = false, toolTip = "opens the movement settings for the menu"},
                new ButtonInfo { buttonText = "projectile", method =() => SettingsMods.ProjectileSettings(), isTogglable = false, toolTip = "opens the projectile settings for the menu"},
            },

            new ButtonInfo[] { // Menu Settings [2]
                new ButtonInfo { buttonText = "Return to Settings", method =() => SettingsMods.EnterSettings(), isTogglable = false, toolTip = "returns to the main settings page for the menu."},
                new ButtonInfo { buttonText = "Right Hand", enableMethod =() => SettingsMods.RightHand(), disableMethod =() => SettingsMods.LeftHand(), toolTip = "puts the menu on your right hand"},
                new ButtonInfo { buttonText = "Notifications", enableMethod =() => SettingsMods.EnableNotifications(), disableMethod =() => SettingsMods.DisableNotifications(), enabled = !disableNotifications, toolTip = "toggles the notifications"},
                new ButtonInfo { buttonText = "FPS Counter", enableMethod =() => SettingsMods.EnableFPSCounter(), disableMethod =() => SettingsMods.DisableFPSCounter(), enabled = fpsCounter, toolTip = "toggles the FPS counter"},
                new ButtonInfo { buttonText = "Disconnect Button", enableMethod =() => SettingsMods.EnableDisconnectButton(), disableMethod =() => SettingsMods.DisableDisconnectButton(), enabled = disconnectButton, toolTip = "toggles the disconnect button"},
            },

            new ButtonInfo[] { // Movement Settings [3]
                new ButtonInfo { buttonText = "Return to Settings", method =() => SettingsMods.EnterSettings(), isTogglable = false, toolTip = "returns to the main settings page for the menu"},
            },

            new ButtonInfo[] { // Projectile Settings [4]
                new ButtonInfo { buttonText = "Return to Settings", method =() => SettingsMods.MenuSettings(), isTogglable = false, toolTip = "opens the settings for the menu"},
            },

            new ButtonInfo[] { // Customization Settings [5]
                new ButtonInfo { buttonText = "Return to Settings", method =() => SettingsMods.EnterSettings(), isTogglable = false, toolTip = "returns to the main settings page for the menu"},
                new ButtonInfo { buttonText = "theme: [Main] [1]", isTogglable = false},
                new ButtonInfo { buttonText = "change theme <", method =() => Customization.ChangeThemeTypeBackwards(), isTogglable = false, toolTip = "changes the theme backwards by 1"},
                new ButtonInfo { buttonText = "change theme >", method =() => Customization.ChangeThemeTypeForwards(), isTogglable = false, toolTip = "changes the theme forwards by 1"},
                new ButtonInfo { buttonText = "font: [Comic Sans] [1]", isTogglable = false},
                new ButtonInfo { buttonText = "change font <", method =() => Customization.ChangeFontTypeBackwards(), isTogglable = false, toolTip = "changes the font backwards by 1"},
                new ButtonInfo { buttonText = "change font >", method =() => Customization.ChangeFontTypeForwards(), isTogglable = false, toolTip = "changes the font forwards by 1"},
                new ButtonInfo { buttonText = "custom menu name", disableMethod =() => Customization.DoNotCustomMenuName(), enableMethod =() => Customization.CustomMenuName(), toolTip = "allows you to use a custom menu name, changed in silliness/CustomMenuName.txt"},
                new ButtonInfo { buttonText = "save preferences", method =() => SettingsMods.SavePreferences(), isTogglable = false, toolTip = "saves your preferecnes"},
                new ButtonInfo { buttonText = "load preferences", method =() => SettingsMods.LoadPreferences(), isTogglable = false, toolTip = "loads your preferences"},
            },
        };
    }
}
