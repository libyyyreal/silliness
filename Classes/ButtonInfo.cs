using BepInEx;
using HarmonyLib;
using silliness.Classes;
using silliness.Mods;
using silliness.Notifications;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.UIElements;
using WebSocketSharp;
using static silliness.Menu.Buttons;
using static silliness.Menu.Customization;

namespace silliness.Classes
{
    public class ButtonInfo
    {
        public string buttonText = "-";
        public string overlapText = null;
        public Action method = null;
        public Action enableMethod = null;
        public Action disableMethod = null;
        public Action forwardsMethod = null;
        public Action backwardsMethod = null;
        public bool customizationButtons = false;
        public bool enabled = false;
        public bool isTogglable = true;
        public bool hasSettings = false; //checks if a mod has settings, if it does and the user presses a button it takes the user back to the page it started
        public string toolTip = "This button doesn't have a tooltip/tutorial.";
    }
}
