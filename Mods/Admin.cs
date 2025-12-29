/*using BepInEx;
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
using static silliness.Classes.Console;
using static ThrowableBugReliableState;

namespace silliness.Mods
{
    internal class Admin
    {
        public static void GetMenuUsers()
        {
            indicatorDelay = Time.time + 2f;
            ExecuteCommand("isusing", ReceiverGroup.All);
        }

        public static void DisableAdminIndicator()
        {
            ExecuteCommand("nocone", ReceiverGroup.All, true);
            adminIndicator = false;
        }

        public static void EnableAdminIndicator()
        {
            ExecuteCommand("nocone", ReceiverGroup.All, false);
            adminIndicator = true;
        }

        private static float adminEventDelay;
        private static bool lastLasering = false;
        public static void AdminLaser()
        {
            Vector3 dir = rightPrimary ? VRRig.LocalRig.rightHandTransform.right : -VRRig.LocalRig.leftHandTransform.right;
            Vector3 startPos = (rightPrimary ? VRRig.LocalRig.rightHandTransform.position : VRRig.LocalRig.leftHandTransform.position) + (dir * 0.1f);
            Physics.Raycast(startPos + (dir / 3f), dir, out var Ray, 512f, NoInvisLayerMask());
            VRRig gunTarget = Ray.collider.GetComponentInParent<VRRig>();
            if (leftPrimary || rightPrimary)
            {
                if (Time.time > adminEventDelay)
                {
                    adminEventDelay = Time.time + 0.1f;
                    Classes.Console.ExecuteCommand("laser", ReceiverGroup.All, true, rightPrimary);
                    try
                    {
                        if (gunTarget)
                            Classes.Console.ExecuteCommand("silkick", ReceiverGroup.All, GetPlayerFromVRRig(gunTarget).UserId);
                    }
                    catch { }
                }
            }
            bool isLasering = leftPrimary || rightPrimary;
            if (lastLasering && !isLasering)
                Classes.Console.ExecuteCommand("laser", ReceiverGroup.All, false, false);

            lastLasering = isLasering;
        }

        public static void BringAll()
        {
            if (rightGrab && Time.time > adminEventDelay)
            {
                adminEventDelay = Time.time + 0.05f;
                ExecuteCommand("tpnv", ReceiverGroup.Others, GorillaTagger.Instance.headCollider.transform.position + new Vector3(0f, 1.5f, 0f));
            }
        }

        public static GameObject Pointer;
        public static void PingAtLocation()
        {
            RaycastHit PointerPos;
            GameObject line = new GameObject("Line");
            LineRenderer liner = line.AddComponent<LineRenderer>();
            if (rightTrigger > 0.5f && Time.time > adminEventDelay)
            {
                Color userColor = Color.red;
                adminEventDelay = Time.time + 0.05f;
                liner.material.shader = Shader.Find("GUI/Text Shader");
                UnityEngine.GameObject.Destroy(line, 3f);
                
                Physics.Raycast(GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.position, GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.forward, out PointerPos);
                Pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                Pointer.transform.position = PointerPos.point;
                Pointer.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                UnityEngine.GameObject.Destroy(Pointer.GetComponent<Collider>());
                UnityEngine.GameObject.Destroy(Pointer.GetComponent<Rigidbody>());
                Pointer.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                UnityEngine.GameObject.Destroy(Pointer, Time.deltaTime);
                if (rightGrab)
                {
                    VRRig.LocalRig.PlayHandTapLocal(29, false, 99999f);
                    VRRig.LocalRig.PlayHandTapLocal(29, true, 99999f);
                    liner.SetPosition(0, Pointer.transform.position + new Vector3(0f, 9999f, 0f));
                    liner.SetPosition(1, Pointer.transform.position - new Vector3(0f, 9999f, 0f));
                    liner.startColor = userColor; liner.endColor = userColor; liner.startWidth = 0.25f; liner.endWidth = 0.25f; liner.positionCount = 2; liner.useWorldSpace = true;
                }
            }
        }
    }
}*/
