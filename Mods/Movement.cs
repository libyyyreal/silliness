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
using static silliness.Mods.Settings.MovementSettings;
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

namespace silliness.Mods
{
    internal class Movement
    {
        public static GameObject LeftPlatform;
        public static GameObject RightPlatform;
        public static void Platforms()
        {
            if (leftGrab)
            {
                if (LeftPlatform == null)
                {
                    LeftPlatform = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    LeftPlatform.transform.localScale = new Vector3(0.025f, 0.3f, 0.4f);
                    LeftPlatform.transform.position = GorillaTagger.Instance.leftHandTransform.position - new Vector3(0f, 0.05f, 0f);
                    LeftPlatform.transform.rotation = GorillaTagger.Instance.leftHandTransform.rotation;
                    if (shouldOutline)
                    {
                        OutlineObjNonMenu(LeftPlatform, true);
                    }

                    ColorChanger colorChanger = LeftPlatform.AddComponent<ColorChanger>();
                    colorChanger.colorInfo = bgColors;
                    colorChanger.Start();
                }
            }
            else
            {
                if (LeftPlatform != null)
                {
                    UnityEngine.Object.Destroy(LeftPlatform);
                }
            }
            if (rightGrab)
            {
                if (RightPlatform == null)
                {
                    RightPlatform = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    RightPlatform.transform.localScale = new Vector3(0.025f, 0.3f, 0.4f);
                    RightPlatform.transform.position = GorillaTagger.Instance.rightHandTransform.position - new Vector3(0f, 0.05f, 0f);
                    RightPlatform.transform.rotation = GorillaTagger.Instance.rightHandTransform.rotation;
                    if (shouldOutline)
                    {
                        OutlineObjNonMenu(RightPlatform, true);
                    }

                    ColorChanger colorChanger = RightPlatform.AddComponent<ColorChanger>();
                    colorChanger.colorInfo = bgColors;
                    colorChanger.Start();
                }
            }
            else
            {
                if (RightPlatform != null)
                {
                    UnityEngine.Object.Destroy(RightPlatform);
                }
            }
        }
        public static void TriggerPlatforms()
        {
            if (leftTrigger > 0.5f)
            {
                if (LeftPlatform == null)
                {
                    LeftPlatform = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    LeftPlatform.transform.localScale = new Vector3(0.025f, 0.3f, 0.4f);
                    LeftPlatform.transform.position = GorillaTagger.Instance.leftHandTransform.position - new Vector3(0f, 0.05f, 0f);
                    LeftPlatform.transform.rotation = GorillaTagger.Instance.leftHandTransform.rotation;
                    if (shouldOutline)
                    {
                        OutlineObjNonMenu(LeftPlatform, true);
                    }

                    ColorChanger colorChanger = LeftPlatform.AddComponent<ColorChanger>();
                    colorChanger.colorInfo = bgColors;
                    colorChanger.Start();
                }
            }
            else
            {
                if (LeftPlatform != null)
                {
                    UnityEngine.Object.Destroy(LeftPlatform);
                }
            }
            if (rightTrigger > 0.5f)
            {
                if (RightPlatform == null)
                {
                    RightPlatform = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    RightPlatform.transform.localScale = new Vector3(0.025f, 0.3f, 0.4f);
                    RightPlatform.transform.position = GorillaTagger.Instance.rightHandTransform.position - new Vector3(0f, 0.05f, 0f);
                    RightPlatform.transform.rotation = GorillaTagger.Instance.rightHandTransform.rotation;
                    if (shouldOutline)
                    {
                        OutlineObjNonMenu(RightPlatform, true);
                    }

                    ColorChanger colorChanger = RightPlatform.AddComponent<ColorChanger>();
                    colorChanger.colorInfo = bgColors;
                    colorChanger.Start();
                }
            }
            else
            {
                if (RightPlatform != null)
                {
                    UnityEngine.Object.Destroy(RightPlatform);
                }
            }
        }
        public static void Fly()
        {
            if (rightSecondary)
            {
                GorillaLocomotion.GTPlayer.Instance.transform.position += GorillaLocomotion.GTPlayer.Instance.headCollider.transform.forward * Time.deltaTime * FlySpeed;
                GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
            }
        }
        public static void NoclipFly()
        {
            if (rightSecondary)
            {
                GorillaLocomotion.GTPlayer.Instance.transform.position += GorillaLocomotion.GTPlayer.Instance.headCollider.transform.forward * Time.deltaTime * FlySpeed;
                GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
                foreach (MeshCollider v in Resources.FindObjectsOfTypeAll<MeshCollider>())
                {
                    v.enabled = false;
                }
            }
            else
            {
                foreach (MeshCollider v in Resources.FindObjectsOfTypeAll<MeshCollider>())
                {
                    v.enabled = true;
                }
            }
        }
        public static void Speedboost()
        {
            GorillaLocomotion.GTPlayer.Instance.jumpMultiplier = JM;
            GorillaLocomotion.GTPlayer.Instance.maxJumpSpeed = MJS;
        }
        public static void GripSpeedboost()
        {
            if (rightGrab || leftGrab)
            {
                GorillaLocomotion.GTPlayer.Instance.jumpMultiplier = JM;
                GorillaLocomotion.GTPlayer.Instance.maxJumpSpeed = MJS;
            }
        }
    }
}
