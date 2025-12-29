using BepInEx;
using ExitGames.Client.Photon;
using GorillaLocomotion.Climbing;
using GorillaNetworking;
using GorillaTag;
using HarmonyLib;
using Oculus.Platform;
using Photon.Pun;
using Photon.Realtime;
using Photon.Voice.Unity;
using PlayFab.ExperimentationModels;
using silliness;
using silliness.Classes;
using silliness.Mods;
using silliness.Notifications;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Input;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Networking;
using UnityEngine.Profiling;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngine.XR;
using WebSocketSharp;
using static silliness.Classes.Button;
using static silliness.Classes.ButtonInfo;
using static silliness.Classes.RigManager;
using static silliness.Menu.Buttons;
using static silliness.Menu.Customization;
using static silliness.Mods.SettingsMods;
using static silliness.Menu.Main;
using silliness.Mods.Settings;

namespace silliness.Menu
{
    internal class Buttons
    {
        public static ButtonInfo[][] buttons = new ButtonInfo[][]
        {
            new ButtonInfo[] { // Main Mods [0]
                new ButtonInfo { buttonText = "Movement", method =() => currentCategory = 6, isTogglable = false},
            },

            new ButtonInfo[] { // Settings [1]
                new ButtonInfo { buttonText = "Return To Main", method =() => currentCategory = 0, isTogglable = false},
                new ButtonInfo { buttonText = "Menu", method =() => currentCategory = 2, isTogglable = false},
                new ButtonInfo { buttonText = "Customization", method =() => currentCategory = 3, isTogglable = false},
            },

            new ButtonInfo[] { // Menu Settings [2]
                new ButtonInfo { buttonText = "Return to Settings", method =() => currentCategory = 1, isTogglable = false},
                new ButtonInfo { buttonText = "Right Hand", enableMethod =() => SettingsMods.RightHand(), disableMethod =() => SettingsMods.LeftHand(), toolTip = "Puts the menu on your right hand"},
                new ButtonInfo { buttonText = "Notifications", enableMethod =() => SettingsMods.EnableNotifications(), disableMethod =() => SettingsMods.DisableNotifications(), enabled = !disableNotifications, toolTip = "Toggles the notifications"},
                new ButtonInfo { buttonText = "Discord Invite", enableMethod =() => SettingsMods.EnableDiscordText(), disableMethod =() => SettingsMods.DisableDiscordText(), enabled = discordtext, toolTip = "Toggles the discord invite link"},
                new ButtonInfo { buttonText = "Extended FPS", disableMethod =() => Customization.DisableExtendedFPS(), enableMethod =() => Customization.EnableExtendedFPS(), enabled = extendedFPS, toolTip = "Adds more info to your FPS counter"},
            },

            new ButtonInfo[] { // Customization Settings [3]
                new ButtonInfo { buttonText = "Return To Settings", method =() => currentCategory = 1, isTogglable = false},
                new ButtonInfo { buttonText = "Theme: [Main] [1]", isTogglable = false},
                new ButtonInfo { buttonText = "Change Theme <", method =() => Customization.ChangeThemeTypeBackwards(), isTogglable = false, toolTip = "Changes the theme backwards by 1"},
                new ButtonInfo { buttonText = "Change Theme >", method =() => Customization.ChangeThemeTypeForwards(), isTogglable = false, toolTip = "Changes the theme forwards by 1"},
                new ButtonInfo { buttonText = "Font: [Comic Sans] [1]", isTogglable = false},
                new ButtonInfo { buttonText = "Change Font <", method =() => Customization.ChangeFontTypeBackwards(), isTogglable = false, toolTip = "Changes the font backwards by 1"},
                new ButtonInfo { buttonText = "Change Font >", method =() => Customization.ChangeFontTypeForwards(), isTogglable = false, toolTip = "Changes the font forwards by 1"},
                new ButtonInfo { buttonText = "Swap Menu Colors", disableMethod =() => Customization.DisableSwapMenuColors(), enableMethod =() => Customization.EnableSwapMenuColors(), toolTip = "Swaps all menu colors, thus creating new themes"},
                new ButtonInfo { buttonText = "Text Shadow", disableMethod =() => Customization.DisableTextShadow(), enableMethod =() => Customization.EnableTextShadow(), enabled = textShadow, toolTip = "Adds a shadow under all text, making it have a cool effect"},
                new ButtonInfo { buttonText = "Text Outline", disableMethod =() => Customization.DisableTextOutline(), enableMethod =() => Customization.EnableTextOutline(), enabled = textOutline, toolTip = "Adds a outline around all text, making it way more readable in some cases"},
                new ButtonInfo { buttonText = "High Quality Text", disableMethod =() => Customization.DisableHQText(), enableMethod =() => Customization.EnableHQText(), toolTip = "Makes text more readable and less blurry"},
                new ButtonInfo { buttonText = "Overflow Text", disableMethod =() => Customization.DisableOverflowText(), enableMethod =() => Customization.EnableOverflowText(), toolTip = "Makes all button text a set size no matter the length"},
                new ButtonInfo { buttonText = "Uppercase Text", disableMethod =() => Customization.DisableUppercaseText(), enableMethod =() => Customization.EnableUppercaseText(), enabled = uppercaseText, toolTip = "Makes all text in the menu uppercase"},
                new ButtonInfo { buttonText = "Lowercase Text", disableMethod =() => Customization.DisableLowercaseText(), enableMethod =() => Customization.EnableLowercaseText(), enabled = lowercaseText, toolTip = "Makes all text in the menu lowercase, the true silliness experience"},
                //new ButtonInfo { buttonText = "EToH Theme Functionality", disableMethod =() => Customization.DisableEToHFunction(), enableMethod =() => Customization.EnableEToHFunction(), enabled = EToH, toolTip = "Makes the EToH theme smoothly transition through the entire difficulty chart"},
                new ButtonInfo { buttonText = "Custom Menu Name", disableMethod =() => Customization.DisableCustomMenuName(), enableMethod =() => Customization.EnableCustomMenuName(), toolTip = "Allows you to use a custom menu name, changed in silliness/CustomMenuName.txt"},
                new ButtonInfo { buttonText = "Custom Menu Background", disableMethod =() => Customization.DisableCustomMenuBackground(), enableMethod =() => Customization.EnableCustomMenuBackground(), toolTip = "Allows you to use a custom menu theme, changed in silliness/custommenubackground_template.png, use the tutorial for more help"},
                //new ButtonInfo { buttonText = "Custom Menu Theme", disableMethod =() => Customization.DisableCustomMenuName(), enableMethod =() => Customization.EnableCustomMenuName(), toolTip = "Allows you to use a custom menu theme, changed in silliness/CustomTheme/, use the tutorial for more help"},
                new ButtonInfo { buttonText = "Rounded Menu", disableMethod =() => Customization.DisableRoundedMenu(), enableMethod =() => Customization.EnableRoundedMenu(), enabled = roundedMenu || wasRounded, toolTip = "Rounds the menu, removing all sharp corners"},
                new ButtonInfo { buttonText = "PC Menu Background", disableMethod =() => Customization.DisablePCMenuBackground(), enableMethod =() => Customization.EnablePCMenuBackground(), enabled = PCMenuBackground, toolTip = "Enables the colored background when using the menu on PC"},
                new ButtonInfo { buttonText = "Collidable Menu", disableMethod =() => Customization.DisableCollidableMenu(), enableMethod =() => Customization.EnableCollidableMenu(), enabled = collidableMenu, toolTip = "Makes the menu collidable, also comes with it interacting with the geometry around you"},
                new ButtonInfo { buttonText = "Save Preferences", method =() => SettingsMods.SavePreferences(), isTogglable = false, toolTip = "Saves your preferences"},
                new ButtonInfo { buttonText = "Load Preferences", method =() => SettingsMods.LoadPreferences(), isTogglable = false, toolTip = "Loads your preferences"},
            },

            new ButtonInfo[] { // Movement Settings [4]
                new ButtonInfo { buttonText = "Return to Movement", method =() => currentCategory = 6, isTogglable = false},
                new ButtonInfo { buttonText = "Change Fly Speed [Normal]", method =() => MovementSettings.ChangeFlySpeed(), isTogglable = false, toolTip = "Changes the speed of any mod that has [fly] in the name"},
                new ButtonInfo { buttonText = "Change Speedboost [Normal]", method =() => MovementSettings.ChangeSpeedboostSpeed(), isTogglable = false, toolTip = "Changes the speed of any mod that has [speedboost] in the name"},
            },

            new ButtonInfo[] { // Projectile Settings [5]
                new ButtonInfo { buttonText = "Return to Settings", method =() => currentCategory = 1, isTogglable = false},
            },

            new ButtonInfo[] { // Movement Mods [6]
                new ButtonInfo { buttonText = "Return To Main", method =() => currentCategory = 0, isTogglable = false},
                new ButtonInfo { buttonText = "Movement Settings", method =() => currentCategory = 4, isTogglable = false},
                new ButtonInfo { buttonText = "Speedboost", method =() => Movement.Speedboost(), toolTip = "Makes you go faster"},
                new ButtonInfo { buttonText = "Grip Speedboost [<color=#b6b6b6>G</color>]", method =() => Movement.GripSpeedboost(), toolTip = "Makes you go faster whilst using left and right grip"},
                new ButtonInfo { buttonText = "Platforms [<bold><color=#b6b6b6>G</color></bold>]", method =() => Movement.Platforms(), toolTip = "Spawns platforms at your hands using left and right grip"},
                new ButtonInfo { buttonText = "Platforms [<color=#b6b6b6>T</color>]", method =() => Movement.TriggerPlatforms(), toolTip = "Spawns platforms at your hands using left and right trigger"},
                new ButtonInfo { buttonText = "Fly [<color=#b6b6b6>B</color>]", method =() => Movement.Fly(), toolTip = "Sends you flying in the direction your head is looking whilst holding [<color=#b6b6b6>B</color>]"},
                new ButtonInfo { buttonText = "Noclip Fly [<color=#b6b6b6>B</color>]", method =() => Movement.NoclipFly(), toolTip = "Sends you flying with no collision in the direction your head is looking whilst holding [<color=#b6b6b6>B</color>]"},
            },

            new ButtonInfo[] { // Hidden Stuff
                new ButtonInfo { buttonText = "Disconnect", method =() => PhotonNetwork.Disconnect(), isTogglable = false, toolTip = "Disconnected from code: " + PhotonNetwork.CurrentLobby},
                new ButtonInfo { buttonText = "Home", method =() => currentCategory = 0, isTogglable = false, toolTip = "Returned to Home Page"},
                new ButtonInfo { buttonText = "Settings", method =() => currentCategory = 1, isTogglable = false, toolTip = "Opened Settings"},
            },
        };
    }
}
