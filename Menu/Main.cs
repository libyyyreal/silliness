using BepInEx;
using HarmonyLib;
using Photon.Pun;
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
using UnityEngine.Profiling;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.XR;
using static silliness.Classes.TextGradient;
using static silliness.Menu.Buttons;
using static silliness.Menu.Customization;

namespace silliness.Menu
{
    [HarmonyPatch(typeof(GorillaLocomotion.GTPlayer))]
    [HarmonyPatch("LateUpdate", MethodType.Normal)]
    public class Main : MonoBehaviour
    {
        // Constant
        public static void Prefix()
        {
            if (!HasLoaded)
            {
                HasLoaded = true;
                OnLaunch();
            }
            // Initialize Menu
            try
            {
                bool toOpen = !rightHanded && ControllerInputPoller.instance.leftControllerSecondaryButton || rightHanded && ControllerInputPoller.instance.rightControllerSecondaryButton;
                bool keyboardOpen = UnityInput.Current.GetKey(keyboardButton);
                if (menu == null)
                {
                    if (toOpen || keyboardOpen)
                    {
                        CreateMenu();
                        RecenterMenu(rightHanded, keyboardOpen);
                        if (reference == null)
                        {
                            CreateReference(rightHanded);
                        }
                    }
                }
                else
                {
                    if (toOpen || keyboardOpen)
                    {
                        RecenterMenu(rightHanded, keyboardOpen);
                    }
                    else
                    {
                        GameObject.Find("Shoulder Camera").transform.Find("CM vcam1").gameObject.SetActive(true);

                        
                        if (rightHanded)
                        {
                            Rigidbody comp = menu.AddComponent(typeof(Rigidbody)) as Rigidbody;
                            if (comp != null)
                                comp.linearVelocity = GorillaLocomotion.GTPlayer.Instance.RightHand.velocityTracker
                                    .GetAverageVelocity(true, 0);
                        }
                        else
                        {
                            Rigidbody comp = menu.AddComponent(typeof(Rigidbody)) as Rigidbody;
                            if (comp != null)
                                comp.linearVelocity = GorillaLocomotion.GTPlayer.Instance.LeftHand.velocityTracker
                                    .GetAverageVelocity(true, 0);
                        }

                        Destroy(menu, 1);
                        menu = null;

                        Destroy(reference);
                        reference = null;
                    }
                }
            }
            catch (Exception exc)
            {
                Debug.LogError($"{PluginInfo.Name} // Error initializing at {exc.StackTrace}: {exc.Message}");
            }

            // Constant
            try
            {
                rightPrimary = ControllerInputPoller.instance.rightControllerPrimaryButton;
                rightSecondary = ControllerInputPoller.instance.rightControllerSecondaryButton;
                leftPrimary = ControllerInputPoller.instance.leftControllerPrimaryButton;
                leftSecondary = ControllerInputPoller.instance.leftControllerSecondaryButton;
                leftGrab = ControllerInputPoller.instance.leftGrab;
                rightGrab = ControllerInputPoller.instance.rightGrab;
                leftTrigger = ControllerInputPoller.TriggerFloat(XRNode.LeftHand);
                rightTrigger = ControllerInputPoller.TriggerFloat(XRNode.RightHand);
                // Pre-Execution
                if (fpsObject != null)
                {
                    fpsObject.text = "FPS: " + Mathf.Ceil(1f / Time.unscaledDeltaTime).ToString();
                    if (extendedFPS == true) 
                    {
                        fpsObject.text = $"FPS: {Mathf.Ceil(1f / Time.unscaledDeltaTime).ToString()}\nRAM: {Profiler.GetTotalReservedMemoryLong() / (1024.0 * 1024.0 * 1024.0):F2}/{SystemInfo.systemMemorySize / 1024.0:F0} GB";
                    }
                }
                if (Time.time > autoSaveDelay)
                {
                    autoSaveDelay = Time.time + 60f;
                    SettingsMods.SavePreferences();
                    UnityEngine.Debug.Log("preferences saved");
                }
                if (themeType == 22 && menu != null)
                {
                    badAppleTime = menuBackground.GetComponent<VideoPlayer>().time;
                }
                if (themeType == 30)
                {
                    title.text = MakeGradient("00ff7a", "00ffd2", PluginInfo.Name);
                    if (customMenuNameActivated == true)
                    {
                        title.text = MakeGradient("00ff7a", "00ffd2", customMenuName);
                    }
                }
                if (themeType == 32)
                {
                    title.text = MakeGradient("af69ee", "ff630d", PluginInfo.Name);
                    if (customMenuNameActivated == true)
                    {
                        title.text = MakeGradient("af69ee", "ff630d", customMenuName);
                    }
                }
                //BetterDayNightManager.instance.SetTimeOfDay(0);
                //Debug.Log(LightmapSettings.lightmaps);

                // Execute Enabled mods
                foreach (ButtonInfo[] buttonlist in buttons)
                {
                    foreach (ButtonInfo v in buttonlist)
                    {
                        if (v.enabled)
                        {
                            if (v.method != null)
                            {
                                try
                                {
                                    v.method.Invoke();
                                }
                                catch (Exception exc)
                                {
                                    Debug.LogError(
                                        $"{PluginInfo.Name} // Error with mod {v.buttonText} at {exc.StackTrace}: {exc.Message}");
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                Debug.LogError($"{PluginInfo.Name} // Error with executing mods at {exc.StackTrace}: {exc.Message}");
            }
            if (PhotonNetwork.LocalPlayer.UserId == ownerUserID && ownerSettings == false)
            {
                NotifiLib.SendNotification("<color=magenta>Welcome " + PhotonNetwork.LocalPlayer.NickName.ToString() + " you are the owner of silliness, you could probably do other shit.");
                ownerSettings = true;
            }
        }

        // Functions
        public static void CreateMenu()
        {
            // Menu Holder
            menu = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Destroy(menu.GetComponent<Rigidbody>());
            Destroy(menu.GetComponent<BoxCollider>());
            Destroy(menu.GetComponent<Renderer>());
            menu.transform.localScale = new Vector3(0.1f, 0.3f, 0.3825f);

            // Menu Background
            menuBackground = GameObject.CreatePrimitive(PrimitiveType.Cube);
            menuBackground.AddComponent<VideoPlayer>();
            Destroy(menuBackground.GetComponent<Rigidbody>());
            if (collidableMenu == false)
            {
                Destroy(menuBackground.GetComponent<BoxCollider>());
            }
            menuBackground.transform.parent = menu.transform;
            menuBackground.transform.localRotation = new Quaternion(360f, 0f, 0f, 360f);
            menuBackground.transform.localScale = menuSize;
            menuBackground.GetComponent<Renderer>().material.color = bgColors.colors[0].color;
            menuBackground.transform.position = new Vector3(0.05f, 0f, 0f);
            if (shouldOutline && themeType != 29 && themeType != 22 && customMenuBackground != true)
            {
                OutlineObj(menuBackground, true);
            }
            if (roundedMenu && themeType != 29 && themeType != 22 && customMenuBackground != true)
            {
                RoundObj(menuBackground);
            }
            if (themeType == 29 && customMenuBackground != true)
            {
                menuBackground.GetComponent<Renderer>().material.shader = Shader.Find($"Universal Render Pipeline/Lit");
                menuBackground.GetComponent<Renderer>().material.mainTexture = LoadTextureFromURL("https://libyyyreal.github.io/sillinesshosting/destinygradient.png", "destinygradient.png");
                menuBackground.GetComponent<Renderer>().material.mainTexture.filterMode = FilterMode.Point;
                menuBackground.GetComponent<Renderer>().material.mainTexture.wrapMode = TextureWrapMode.Clamp;
            }
            if (customMenuBackground == true)
            {
                menuBackground.GetComponent<Renderer>().material.shader = Shader.Find($"Universal Render Pipeline/Lit");
                menuBackground.GetComponent<Renderer>().material.mainTexture = LoadTextureFromURL("https://libyyyreal.github.io/sillinesshosting/custommenubackground_template.png", "custommenubackground_template.png");
                menuBackground.GetComponent<Renderer>().material.mainTexture.filterMode = FilterMode.Point;
                menuBackground.GetComponent<Renderer>().material.mainTexture.wrapMode = TextureWrapMode.Clamp;
            }
            if (themeType == 22)
            {
                textOutline = true;
                menuBackground.GetComponent<VideoPlayer>().url = "https://libyyyreal.github.io/sillinesshosting/badapple.webm";
                menuBackground.GetComponent<VideoPlayer>().time = badAppleTime;
                menuBackground.GetComponent<VideoPlayer>().audioOutputMode = VideoAudioOutputMode.Direct;
                menuBackground.GetComponent<VideoPlayer>().SetTargetAudioSource(0, menuBackground.AddComponent<AudioSource>());
                menuBackground.GetComponent<VideoPlayer>().SetDirectAudioVolume(0, 0.25f);
                menuBackground.GetComponent<VideoPlayer>().isLooping = true;
                menuBackground.GetComponent<Renderer>().material.shader = Shader.Find($"Universal Render Pipeline/Lit");
            }
            if (themeType == 21 || themeType == 23)
            {
                textOutline = wasTextOutlined;
                badAppleTime = 1;
                menuBackground.GetComponent<VideoPlayer>().time = 0;
            }
            if (customMenuBackground == true)
            {
                bgColors = new ExtGradient { colors = GetMultiGradient(Color.white, Color.white) };
            }


            ColorChanger colorChanger = menuBackground.AddComponent<ColorChanger>();
            colorChanger.colorInfo = bgColors;
            colorChanger.Start();

            // Canvas
            canvasObject = new GameObject();
            canvasObject.transform.parent = menu.transform;
            Canvas canvas = canvasObject.AddComponent<Canvas>();
            CanvasScaler canvasScaler = canvasObject.AddComponent<CanvasScaler>();
            canvasObject.AddComponent<GraphicRaycaster>();
            canvas.renderMode = RenderMode.WorldSpace;
            canvasScaler.dynamicPixelsPerUnit = 1000f;
            if (highQualityText == true)
            {
                canvasScaler.dynamicPixelsPerUnit = 2000f;
            }
            if (themeType == 29)
            {
                Image image = new GameObject
                {
                    transform =
                {
                    parent = canvasObject.transform
                }
                }.AddComponent<Image>();
                if (destinyIcon == null)
                {
                    destinyIcon = LoadTextureFromURL("https://libyyyreal.github.io/sillinesshosting/destinylogo.png", "destinylogo.png");
                }
                if (destinyMat == null)
                {
                    destinyMat = new Material(image.material);
                }
                image.material = destinyMat;
                image.material.SetTexture(MainTex, destinyIcon);
                image.color = Color.white;
                RectTransform destinycomp = image.GetComponent<RectTransform>();
                destinycomp.localPosition = Vector3.zero;
                destinycomp.position = new Vector3(0.06f, 0f, 0.1585f);
                destinycomp.sizeDelta = new Vector2(0.195f, 0.105f);
                destinycomp.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
            }
            if (themeType == 33)
            {
                Image image = new GameObject
                {
                    transform =
                {
                    parent = canvasObject.transform
                }
                }.AddComponent<Image>();
                if (RainXYZIcon == null)
                {
                    RainXYZIcon = LoadTextureFromURL("https://libyyyreal.github.io/sillinesshosting/explicitlogo.png", "explicitlogo.png");
                }
                if (RainXYZMat == null)
                {
                    RainXYZMat = new Material(image.material);
                }
                image.material = RainXYZMat;
                image.material.SetTexture(MainTex, RainXYZIcon);
                image.color = Color.white;
                RectTransform rainxyzcomp = image.GetComponent<RectTransform>();
                rainxyzcomp.localPosition = Vector3.zero;
                rainxyzcomp.position = new Vector3(0.06f, 0.115f, 0.1555f);
                rainxyzcomp.sizeDelta = new Vector2(0.0755f, 0.0755f);
                rainxyzcomp.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
            }
            if (themeType == 34)
            {
                Image image = new GameObject
                {
                    transform =
                {
                    parent = canvasObject.transform
                }
                }.AddComponent<Image>();
                if (GPhysIcon == null)
                {
                    GPhysIcon = LoadTextureFromURL("https://libyyyreal.github.io/sillinesshosting/GPhys.png", "GPhys.png");
                }
                if (GPhysMat == null)
                {
                    GPhysMat = new Material(image.material);
                }
                image.material = GPhysMat;
                image.material.SetTexture(MainTex, GPhysIcon);
                image.color = Color.white;
                RectTransform rainxyzcomp = image.GetComponent<RectTransform>();
                rainxyzcomp.localPosition = Vector3.zero;
                rainxyzcomp.position = new Vector3(0.06f, 0.115f, 0.1555f);
                rainxyzcomp.sizeDelta = new Vector2(0.0755f, 0.0755f);
                rainxyzcomp.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
            }

            title = new GameObject
            {
                    transform =
            {
                parent = canvasObject.transform
            }
            }.AddComponent<Text>();
            Destroy(title.GetComponent<Collider>());
            Destroy(title.GetComponent<Rigidbody>());
            title.font = currentFont;
            title.text = PluginInfo.Name; //"<color=grey>[</color><color=white>" + (pageNumber + 1).ToString() + "</color><color=grey>]</color>"
            title.fontSize = 1;
            title.color = titleColors.colors[0].color;
            title.supportRichText = true;
            title.fontStyle = FontStyle.Bold;
            title.alignment = TextAnchor.MiddleCenter;
            title.resizeTextForBestFit = true;
            title.resizeTextMinSize = 0;
            RectTransform titlecomp = title.GetComponent<RectTransform>();
            titlecomp.localPosition = Vector3.zero;
            titlecomp.sizeDelta = new Vector2(0.195f, 0.055f);
            titlecomp.position = new Vector3(0.06f, 0f, 0.166f);
            titlecomp.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
            if (customMenuNameActivated == true)
            {
                title.text = customMenuName;
            }
            if (uppercaseText == true)
            {
                title.text = title.text.ToUpper();
            }
            if (lowercaseText == true)
            {
                title.text = title.text.ToLower();
            }
            if (textShadow == true)
            {
                Shadow shadow = title.gameObject.AddComponent<Shadow>();
                Color shadowColor = txtOutlineColors[0].colors[0].color;
                shadowColor.a = 0.33f;

                shadow.effectColor = shadowColor;
                shadow.effectDistance = new Vector3(0.0025f, -0.0025f, 0.1675f);
            }
            if (textOutline == true && title.GetComponent<Outline>() == null)
            {
                Outline outline = title.gameObject.AddComponent<Outline>();
                outline.effectColor = txtOutlineColors[0].colors[0].color;
                outline.effectDistance = new Vector2(0.001f, 0.001f);
                outline.useGraphicAlpha = true;
            }
            else
            {
                Destroy(title.GetComponent<Outline>());
            }
            if (themeType == 29)
            {
                title.text = "";
            }
            if (themeType == 33 || themeType == 34)
            {
                titlecomp.position = new Vector3(0.06f, -0.02f, 0.166f);
            }

            if (fpsCounter)
            {
                fpsObject = new GameObject
                {
                    transform =
                    {
                        parent = canvasObject.transform
                    }
                }.AddComponent<Text>();
                fpsObject.font = currentFont;
                fpsObject.text = "FPS: " + Mathf.Ceil(1f / Time.unscaledDeltaTime).ToString();
                fpsObject.color = titleColors.colors[0].color;
                fpsObject.fontSize = 1;
                fpsObject.supportRichText = true;
                fpsObject.alignment = TextAnchor.MiddleLeft;
                fpsObject.horizontalOverflow = HorizontalWrapMode.Overflow;
                fpsObject.resizeTextForBestFit = true;
                fpsObject.resizeTextMinSize = 0;
                RectTransform component2 = fpsObject.GetComponent<RectTransform>();
                component2.localPosition = Vector3.zero;
                component2.sizeDelta = new Vector2(0.22f, 0.015f);
                component2.position = new Vector3(0.06f, 0.038f, -0.18f);
                component2.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
                if (extendedFPS == true)
                {
                    component2.sizeDelta = new Vector2(0.22f, 0.024f);
                    component2.position = new Vector3(0.06f, 0.0375f, -0.175f);
                }
                if (textShadow == true)
                {
                    Shadow shadow = fpsObject.gameObject.AddComponent<Shadow>();
                    Color shadowColor = txtOutlineColors[0].colors[0].color;
                    shadowColor.a = 0.33f;

                    shadow.effectColor = shadowColor;
                    shadow.effectDistance = new Vector3(0.0012f, -0.0012f, 0.1675f);
                }
                if (textOutline == true && fpsObject.GetComponent<Outline>() == null)
                {
                    Outline outline = fpsObject.gameObject.AddComponent<Outline>();
                    outline.effectColor = txtOutlineColors[0].colors[0].color;
                    outline.effectDistance = new Vector2(0.0005f, 0.0005f);
                    outline.useGraphicAlpha = true;
                }
                else
                {
                    Destroy(fpsObject.GetComponent<Outline>());
                }
            }
            versionObject = new GameObject
            {
                transform =
                    {
                        parent = canvasObject.transform
                    }
            }.AddComponent<Text>();
            versionObject.font = currentFont;
            versionObject.text = "VER: " + PluginInfo.Version;
            versionObject.color = titleColors.colors[0].color;
            versionObject.fontSize = 1;
            versionObject.supportRichText = true;
            versionObject.alignment = TextAnchor.MiddleRight;
            versionObject.horizontalOverflow = HorizontalWrapMode.Overflow;
            versionObject.resizeTextForBestFit = true;
            versionObject.resizeTextMinSize = 0;
            RectTransform isaac = versionObject.GetComponent<RectTransform>();
            isaac.localPosition = Vector3.zero;
            isaac.sizeDelta = new Vector2(0.22f, 0.015f);
            isaac.position = new Vector3(0.06f, -0.0374f, -0.18f);
            isaac.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
            if (textShadow == true)
            {
                Shadow shadow = versionObject.gameObject.AddComponent<Shadow>();
                Color shadowColor = txtOutlineColors[0].colors[0].color;
                shadowColor.a = 0.33f;

                shadow.effectColor = shadowColor;
                shadow.effectDistance = new Vector3(0.0012f, -0.0012f, 0.1675f);
            }
            if (textOutline == true && versionObject.GetComponent<Outline>() == null)
            {
                Outline outline = versionObject.gameObject.AddComponent<Outline>();
                outline.effectColor = txtOutlineColors[0].colors[0].color;
                outline.effectDistance = new Vector2(0.0005f, 0.0005f);
                outline.useGraphicAlpha = true;
            }
            else
            {
                Destroy(versionObject.GetComponent<Outline>());
            }
            
            if (discordtext)
            {
                discordObject = new GameObject
                {
                    transform =
                    {
                        parent = canvasObject.transform
                    }
                }.AddComponent<Text>();
                discordObject.font = currentFont;
                discordObject.text = "dsc.gg/silliness";
                discordObject.color = titleColors.colors[0].color; ;
                discordObject.fontSize = 1;
                discordObject.supportRichText = true;
                discordObject.alignment = TextAnchor.MiddleCenter;
                discordObject.horizontalOverflow = HorizontalWrapMode.Overflow;
                discordObject.resizeTextForBestFit = true;
                discordObject.resizeTextMinSize = 0;
                RectTransform isaac2 = discordObject.GetComponent<RectTransform>();
                isaac2.localPosition = Vector3.zero;
                isaac2.sizeDelta = new Vector2(0.22f, 0.015f);
                isaac2.position = new Vector3(0.06f, 0f, -0.178f);
                isaac2.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
                if (textShadow == true)
                {
                    Shadow shadow = discordObject.gameObject.AddComponent<Shadow>();
                    Color shadowColor = txtOutlineColors[0].colors[0].color;
                    shadowColor.a = 0.33f;

                    shadow.effectColor = shadowColor;
                    shadow.effectDistance = new Vector3(0.0012f, -0.0012f, 0.1675f);
                }
                if (textOutline == true && discordObject.GetComponent<Outline>() == null)
                {
                    Outline outline = discordObject.gameObject.AddComponent<Outline>();
                    outline.effectColor = txtOutlineColors[0].colors[0].color;
                    outline.effectDistance = new Vector2(0.0005f, 0.0005f);
                    outline.useGraphicAlpha = true;
                }
                else
                {
                    Destroy(discordObject.GetComponent<Outline>());
                }
            }

            // Buttons
            // Disconnect
            if (disconnectButton)
            {
                GameObject disconnectbutton = GameObject.CreatePrimitive(PrimitiveType.Cube);
                if (!UnityInput.Current.GetKey(KeyCode.Q))
                {
                    disconnectbutton.layer = 2;
                }
                Destroy(disconnectbutton.GetComponent<Rigidbody>());
                disconnectbutton.GetComponent<BoxCollider>().isTrigger = true;
                disconnectbutton.transform.parent = menu.transform;
                disconnectbutton.transform.rotation = Quaternion.identity;
                disconnectbutton.transform.localScale = new Vector3(0.1f, 0.55f, 0.12f);
                disconnectbutton.transform.localPosition = new Vector3(0.5f, 0f, 0.6f);
                disconnectbutton.GetComponent<Renderer>().material.color = btColors[0].colors[0].color;
                disconnectbutton.AddComponent<Classes.Button>().relatedText = "Disconnect";
                if (shouldOutline)
                {
                    OutlineObj(disconnectbutton, true);
                }
                if (roundedMenu)
                {
                    RoundObj(disconnectbutton);
                }

                colorChanger = disconnectbutton.AddComponent<ColorChanger>();
                colorChanger.colorInfo = btColors[0];
                colorChanger.Start();

                Text discontext = new GameObject
                {
                    transform =
                            {
                                parent = canvasObject.transform
                            }
                }.AddComponent<Text>();
                discontext.text = "Disconnect";
                discontext.font = currentFont;
                discontext.fontSize = 1;
                discontext.color = titleColors.colors[0].color;
                discontext.alignment = TextAnchor.MiddleCenter;
                discontext.resizeTextForBestFit = true;
                discontext.resizeTextMinSize = 0;

                RectTransform rectt = discontext.GetComponent<RectTransform>();
                rectt.localPosition = Vector3.zero;
                rectt.sizeDelta = new Vector2(0.15f, 0.03f);
                rectt.localPosition = new Vector3(0.064f, 0f, 0.23f);
                rectt.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
                if (uppercaseText == true)
                {
                    discontext.text = discontext.text.ToUpper();
                }
                if (lowercaseText == true)
                {
                    discontext.text = discontext.text.ToLower();
                }
                if (textShadow == true)
                {
                    Shadow shadow = discontext.gameObject.AddComponent<Shadow>();
                    Color shadowColor = txtOutlineColors[0].colors[0].color;
                    shadowColor.a = 0.33f;

                    shadow.effectColor = shadowColor;
                    shadow.effectDistance = new Vector3(0.002f, -0.002f, 0.1675f);
                }
                if (textOutline == true && discontext.GetComponent<Outline>() == null)
                {
                    Outline outline = discontext.gameObject.AddComponent<Outline>();
                    outline.effectColor = txtOutlineColors[0].colors[0].color;
                    outline.effectDistance = new Vector2(0.001f, 0.001f);
                    outline.useGraphicAlpha = true;
                }
                else
                {
                    Destroy(discontext.GetComponent<Outline>());
                }
            }

            GameObject homebutton = GameObject.CreatePrimitive(PrimitiveType.Cube);
            if (!UnityInput.Current.GetKey(KeyCode.Q))
            {
                homebutton.layer = 2;
            }
            Destroy(homebutton.GetComponent<Rigidbody>());
            homebutton.GetComponent<BoxCollider>().isTrigger = true;
            homebutton.transform.parent = menu.transform;
            homebutton.transform.rotation = Quaternion.identity;
            homebutton.transform.localScale = new Vector3(0.1f, 0.16f, 0.12f);
            homebutton.transform.localPosition = new Vector3(0.5f, -0.42f, 0.6f);
            homebutton.GetComponent<Renderer>().material.color = btColors[0].colors[0].color;
            homebutton.AddComponent<Classes.Button>().relatedText = "Home";
            if (shouldOutline)
            {
                OutlineObj(homebutton, true);
            }
            if (roundedMenu)
            {
                RoundObj(homebutton);
            }
            Image homebuttonimage = new GameObject
            {
                transform =
                {
                    parent = canvasObject.transform
                }
            }.AddComponent<Image>();
            if (homeIcon == null)
            {
                homeIcon = LoadTextureFromURL("https://libyyyreal.github.io/sillinesshosting/home.png", "home.png");
            }
            if (homeMat == null)
            {
                homeMat = new Material(homebuttonimage.material);
            }
            homebuttonimage.material = homeMat;
            homebuttonimage.material.SetTexture(MainTex, homeIcon);
            homebuttonimage.color = titleColors.colors[0].color;
            RectTransform homecomp = homebuttonimage.GetComponent<RectTransform>();
            homecomp.localPosition = Vector3.zero;
            homecomp.position = new Vector3(0.0575f, -0.126f, 0.229f);
            homecomp.sizeDelta = new Vector2(0.0375f, 0.0375f);
            homecomp.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
            if (textOutline == true && homebuttonimage.GetComponent<Outline>() == null)
            {
                Outline outline = homebuttonimage.gameObject.AddComponent<Outline>();
                outline.effectColor = txtOutlineColors[0].colors[0].color;
                outline.effectDistance = new Vector2(0.001f, 0.001f);
                outline.useGraphicAlpha = true;
            }

            colorChanger = homebutton.AddComponent<ColorChanger>();
            colorChanger.colorInfo = btColors[0];
            colorChanger.Start();

            GameObject settingsbutton = GameObject.CreatePrimitive(PrimitiveType.Cube);
            if (!UnityInput.Current.GetKey(KeyCode.Q))
            {
                settingsbutton.layer = 2;
            }
            Destroy(settingsbutton.GetComponent<Rigidbody>());
            settingsbutton.GetComponent<BoxCollider>().isTrigger = true;
            settingsbutton.transform.parent = menu.transform;
            settingsbutton.transform.rotation = Quaternion.identity;
            settingsbutton.transform.localScale = new Vector3(0.1f, 0.16f, 0.12f);
            settingsbutton.transform.localPosition = new Vector3(0.5f, 0.42f, 0.6f);
            settingsbutton.GetComponent<Renderer>().material.color = btColors[0].colors[0].color;
            settingsbutton.AddComponent<Classes.Button>().relatedText = "Settings";
            if (shouldOutline)
            {
                OutlineObj(settingsbutton, true);
            }
            if (roundedMenu)
            {
                RoundObj(settingsbutton);
            }
            Image settingsbuttonimage = new GameObject
            {
                transform =
                {
                    parent = canvasObject.transform
                }
            }.AddComponent<Image>();
            if (settingsIcon == null)
            {
                settingsIcon = LoadTextureFromURL("https://libyyyreal.github.io/sillinesshosting/settings.png", "settings.png");
            }
            if (settingsMat == null)
            {
                settingsMat = new Material(settingsbuttonimage.material);
            }
            settingsbuttonimage.material = settingsMat;
            settingsbuttonimage.material.SetTexture(MainTex, settingsIcon);
            settingsbuttonimage.color = titleColors.colors[0].color;
            RectTransform settingscomp = settingsbuttonimage.GetComponent<RectTransform>();
            settingscomp.localPosition = Vector3.zero;
            settingscomp.position = new Vector3(0.0575f, 0.126f, 0.229f);
            settingscomp.sizeDelta = new Vector2(0.0375f, 0.0375f);
            settingscomp.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
            if (textOutline == true && settingsbuttonimage.GetComponent<Outline>() == null)
            {
                Outline outline = settingsbuttonimage.gameObject.AddComponent<Outline>();
                outline.effectColor = txtOutlineColors[0].colors[0].color;
                outline.effectDistance = new Vector2(0.001f, 0.001f);
                outline.useGraphicAlpha = true;
            }

            colorChanger = settingsbutton.AddComponent<ColorChanger>();
            colorChanger.colorInfo = btColors[0];
            colorChanger.Start();

            GameObject skiptoendbutton = GameObject.CreatePrimitive(PrimitiveType.Cube);
            if (!UnityInput.Current.GetKey(KeyCode.Q))
            {
                skiptoendbutton.layer = 2;
            }
            Destroy(skiptoendbutton.GetComponent<Rigidbody>());
            skiptoendbutton.GetComponent<BoxCollider>().isTrigger = true;
            skiptoendbutton.transform.parent = menu.transform;
            skiptoendbutton.transform.rotation = Quaternion.identity;
            skiptoendbutton.transform.localScale = new Vector3(0.1f, 0.16f, 0.12f);
            skiptoendbutton.transform.localPosition = new Vector3(0.5f, -0.64f, -0.44f);
            skiptoendbutton.GetComponent<Renderer>().material.color = btColors[0].colors[0].color;
            skiptoendbutton.AddComponent<Classes.Button>().relatedText = "LastPage";
            if (shouldOutline)
            {
                OutlineObj(skiptoendbutton, true);
            }
            if (roundedMenu)
            {
                RoundObj(skiptoendbutton);
            }
            Image skiptoendbuttonimage = new GameObject
            {
                transform =
                {
                    parent = canvasObject.transform
                }
            }.AddComponent<Image>();
            if (skiptoendIcon == null)
            {
                skiptoendIcon = LoadTextureFromURL("https://libyyyreal.github.io/sillinesshosting/skip.png", "skip.png");
            }
            if (skiptoendMat == null)
            {
                skiptoendMat = new Material(skiptoendbuttonimage.material);
            }
            skiptoendbuttonimage.material = skiptoendMat;
            skiptoendbuttonimage.material.SetTexture(MainTex, skiptoendIcon);
            skiptoendbuttonimage.color = titleColors.colors[0].color;
            RectTransform skiptoendcomp = skiptoendbuttonimage.GetComponent<RectTransform>();
            skiptoendcomp.localPosition = Vector3.zero;
            skiptoendcomp.position = new Vector3(0.0575f, -0.1925f, -0.1675f);
            skiptoendcomp.sizeDelta = new Vector2(0.035f, 0.035f);
            skiptoendcomp.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
            if (textOutline == true && skiptoendbuttonimage.GetComponent<Outline>() == null)
            {
                Outline outline = skiptoendbuttonimage.gameObject.AddComponent<Outline>();
                outline.effectColor = txtOutlineColors[0].colors[0].color;
                outline.effectDistance = new Vector2(0.001f, 0.001f);
                outline.useGraphicAlpha = true;
            }

            colorChanger = skiptoendbutton.AddComponent<ColorChanger>();
            colorChanger.colorInfo = btColors[0];
            colorChanger.Start();

            GameObject backtostartbutton = GameObject.CreatePrimitive(PrimitiveType.Cube);
            if (!UnityInput.Current.GetKey(KeyCode.Q))
            {
                backtostartbutton.layer = 2;
            }
            Destroy(backtostartbutton.GetComponent<Rigidbody>());
            backtostartbutton.GetComponent<BoxCollider>().isTrigger = true;
            backtostartbutton.transform.parent = menu.transform;
            backtostartbutton.transform.rotation = Quaternion.identity;
            backtostartbutton.transform.localScale = new Vector3(0.1f, 0.16f, 0.12f);
            backtostartbutton.transform.localPosition = new Vector3(0.5f, 0.64f, -0.44f);
            backtostartbutton.GetComponent<Renderer>().material.color = btColors[0].colors[0].color;
            backtostartbutton.AddComponent<Classes.Button>().relatedText = "FirstPage";
            if (shouldOutline)
            {
                OutlineObj(backtostartbutton, true);
            }
            if (roundedMenu)
            {
                RoundObj(backtostartbutton);
            }
            Image backtostartbuttonimage = new GameObject
            {
                transform =
                {
                    parent = canvasObject.transform
                }
            }.AddComponent<Image>();
            if (skiptostartIcon == null)
            {
                skiptostartIcon = LoadTextureFromURL("https://libyyyreal.github.io/sillinesshosting/skip.png", "skip.png");
            }
            if (skiptostartMat == null)
            {
                skiptostartMat = new Material(backtostartbuttonimage.material);
            }
            backtostartbuttonimage.material = skiptostartMat;
            backtostartbuttonimage.material.SetTexture(MainTex, skiptostartIcon);
            backtostartbuttonimage.color = titleColors.colors[0].color;
            RectTransform skiptostartcomp = backtostartbuttonimage.GetComponent<RectTransform>();
            skiptostartcomp.localPosition = Vector3.zero;
            skiptostartcomp.position = new Vector3(0.0575f, 0.1925f, -0.1675f);
            skiptostartcomp.sizeDelta = new Vector2(0.035f, 0.035f);
            skiptostartcomp.rotation = Quaternion.Euler(new Vector3(180f, 90f, 270f));
            if (textOutline == true && backtostartbuttonimage.GetComponent<Outline>() == null)
            {
                Outline outline = backtostartbuttonimage.gameObject.AddComponent<Outline>();
                outline.effectColor = txtOutlineColors[0].colors[0].color;
                outline.effectDistance = new Vector2(0.001f, 0.001f);
                outline.useGraphicAlpha = true;
            }

            colorChanger = backtostartbutton.AddComponent<ColorChanger>();
            colorChanger.colorInfo = btColors[0];
            colorChanger.Start();

            // Page Buttons
            GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            if (!UnityInput.Current.GetKey(KeyCode.Q))
            {
                gameObject.layer = 2;
            }
            Destroy(gameObject.GetComponent<Rigidbody>());
            gameObject.GetComponent<BoxCollider>().isTrigger = true;
            gameObject.transform.parent = menu.transform;
            gameObject.transform.rotation = Quaternion.identity;
            gameObject.transform.localScale = new Vector3(0.1f, 0.16f, 0.83f);
            gameObject.transform.localPosition = new Vector3(0.5f, 0.64f, 0.085f);
            gameObject.GetComponent<Renderer>().material.color = btColors[0].colors[0].color;
            gameObject.AddComponent<Classes.Button>().relatedText = "PreviousPage";
            if (shouldOutline)
            {
                OutlineObj(gameObject, true);
            }
            if (roundedMenu)
            {
                RoundObj(gameObject);
            }

            colorChanger = gameObject.AddComponent<ColorChanger>();
            colorChanger.colorInfo = btColors[0];
            colorChanger.Start();

            leftPageText = new GameObject
            {
                transform =
                        {
                            parent = canvasObject.transform
                        }
            }.AddComponent<Text>();
            leftPageText.font = currentFont;
            leftPageText.text = "<";
            leftPageText.fontSize = 1;
            leftPageText.color = txtColors[0].colors[0].color;
            leftPageText.alignment = TextAnchor.MiddleCenter;
            leftPageText.resizeTextForBestFit = true;
            leftPageText.resizeTextMinSize = 0;
            RectTransform leftPageComp = leftPageText.GetComponent<RectTransform>();
            leftPageComp.localPosition = Vector3.zero;
            leftPageComp.sizeDelta = new Vector2(0.2f, 0.03f);
            leftPageComp.localPosition = new Vector3(0.064f, 0.19f, 0.045f);
            leftPageComp.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
            if (textShadow == true)
            {
                Shadow shadow = leftPageText.gameObject.AddComponent<Shadow>();
                Color shadowColor = txtOutlineColors[0].colors[0].color;
                shadowColor.a = 0.33f;

                shadow.effectColor = shadowColor;
                shadow.effectDistance = new Vector3(0.0015f, -0.0015f, 0.1675f);
            }
            if (textOutline == true && leftPageText.GetComponent<Outline>() == null)
            {
                Outline outline = leftPageText.gameObject.AddComponent<Outline>();
                outline.effectColor = txtOutlineColors[0].colors[0].color;
                outline.effectDistance = new Vector2(0.001f, 0.001f);
                outline.useGraphicAlpha = true;
            }
            else
            {
                Destroy(leftPageText.GetComponent<Outline>());
            }

            gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            if (!UnityInput.Current.GetKey(KeyCode.Q))
            {
                gameObject.layer = 2;
            }
            Destroy(gameObject.GetComponent<Rigidbody>());
            gameObject.GetComponent<BoxCollider>().isTrigger = true;
            gameObject.transform.parent = menu.transform;
            gameObject.transform.rotation = Quaternion.identity;
            gameObject.transform.localScale = new Vector3(0.1f, 0.16f, 0.83f);
            gameObject.transform.localPosition = new Vector3(0.5f, -0.64f, 0.085f);
            gameObject.GetComponent<Renderer>().material.color = btColors[0].colors[0].color;
            gameObject.AddComponent<Classes.Button>().relatedText = "NextPage";
            if (shouldOutline)
            {
                OutlineObj(gameObject, true);
            }
            if (roundedMenu)
            {
                RoundObj(gameObject);
            }

            colorChanger = gameObject.AddComponent<ColorChanger>();
            colorChanger.colorInfo = btColors[0];
            colorChanger.Start();

            rightPageText = new GameObject
            {
                transform =
                        {
                            parent = canvasObject.transform
                        }
            }.AddComponent<Text>();
            rightPageText.font = currentFont;
            rightPageText.text = ">";
            rightPageText.fontSize = 1;
            rightPageText.color = txtColors[0].colors[0].color;
            rightPageText.alignment = TextAnchor.MiddleCenter;
            rightPageText.resizeTextForBestFit = true;
            rightPageText.resizeTextMinSize = 0;
            RectTransform rightPageComp = rightPageText.GetComponent<RectTransform>();
            rightPageComp.localPosition = Vector3.zero;
            rightPageComp.sizeDelta = new Vector2(0.2f, 0.03f);
            rightPageComp.localPosition = new Vector3(0.064f, -0.19f, 0.045f);
            rightPageComp.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
            if (textShadow == true)
            {
                Shadow shadow = rightPageText.gameObject.AddComponent<Shadow>();
                Color shadowColor = txtOutlineColors[0].colors[0].color;
                shadowColor.a = 0.33f;

                shadow.effectColor = shadowColor;
                shadow.effectDistance = new Vector3(0.0015f, -0.0015f, 0.1675f);
            }
            if (textOutline == true && rightPageText.GetComponent<Outline>() == null)
            {
                Outline outline = rightPageText.gameObject.AddComponent<Outline>();
                outline.effectColor = txtOutlineColors[0].colors[0].color;
                outline.effectDistance = new Vector2(0.001f, 0.001f);
                outline.useGraphicAlpha = true;
            }
            else
            {
                Destroy(rightPageText.GetComponent<Outline>());
            }

            // Mod Buttons
            ButtonInfo[] activeButtons = buttons[currentCategory].Skip(pageNumber * buttonsPerPage).Take(buttonsPerPage).ToArray();
            for (int i = 0; i < activeButtons.Length; i++)
            {
                CreateButton(i * 0.083f, activeButtons[i]);
            }
        }

        public static void CreateButton(float offset, ButtonInfo method)
        {
            GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            if (!UnityInput.Current.GetKey(KeyCode.Q))
            {
                gameObject.layer = 2;
            }
            Destroy(gameObject.GetComponent<Rigidbody>());
            gameObject.GetComponent<BoxCollider>().isTrigger = true;
            gameObject.transform.parent = menu.transform;
            gameObject.transform.rotation = Quaternion.identity;
            gameObject.transform.localScale = new Vector3(0.09f, 0.9f, 0.07f);
            gameObject.transform.localPosition = new Vector3(0.56f, 0f, 0.28f - offset);
            gameObject.AddComponent<silliness.Classes.Button>().relatedText = method.buttonText;
            if (shouldOutline && themeType != 22)
            {
                OutlineObj(gameObject, true);
            }
            if (themeType == 22)
            {
                if (GetIndex("Rounded Menu").enabled)
                {
                    wasRounded = true;
                    GetIndex("Rounded Menu").enabled = false;
                }
                gameObject.GetComponent<Renderer>().enabled = false;
            }
            else
            {
                if (wasRounded == true)
                {
                    GetIndex("Rounded Menu").enabled = true;
                    wasRounded = false;
                }
                gameObject.GetComponent<Renderer>().enabled = true;
            }
            if (roundedMenu)
            {
                RoundObj(gameObject);
            }

                ColorChanger colorChanger = gameObject.AddComponent<ColorChanger>();
            if (method.enabled)
            {
                colorChanger.colorInfo = btColors[1];
            }
            else
            {
                colorChanger.colorInfo = btColors[0];
            }
            colorChanger.Start();

            Text text = new GameObject
            {
                transform =
                {
                    parent = canvasObject.transform
                }
            }.AddComponent<Text>();
            text.font = currentFont;
            text.text = method.buttonText;
            if (method.overlapText != null)
            {
                text.text = method.overlapText;
            }
            text.supportRichText = true;
            text.fontSize = 1;
            if (method.enabled)
            {
                text.color = txtColors[1].colors[1].color;
            }
            else
            {
                text.color = txtColors[0].colors[0].color;
            }
            text.alignment = TextAnchor.MiddleCenter;
            text.fontStyle = FontStyle.Normal;
            text.resizeTextForBestFit = true;
            text.resizeTextMinSize = 0;
            RectTransform component = text.GetComponent<RectTransform>();
            component.localPosition = Vector3.zero;
            component.sizeDelta = new Vector2(.26f, .02f);
            component.localPosition = new Vector3(.064f, 0, .111f - offset / 2.6f);
            component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
            if (overflowText == true)
            {
                component.sizeDelta = new Vector2(.1f, .012f);
                text.horizontalOverflow = HorizontalWrapMode.Overflow;
                text.verticalOverflow = VerticalWrapMode.Truncate;
            }
            if (uppercaseText == true)
            {
                text.text = text.text.ToUpper();
            }
            if (lowercaseText == true)
            {
                text.text = text.text.ToLower();
            }
            if (textShadow == true)
            {
                foreach (var existingShadow in text.GetComponents<Shadow>())
                {
                    GameObject.DestroyImmediate(existingShadow);
                }

                Shadow shadow = text.gameObject.AddComponent<Shadow>();
                shadow.effectDistance = new Vector3(0.0011f, -0.0011f, 0.1675f);

                Color shadowColor = method.enabled ? txtColors[1].colors[1].color : txtColors[0].colors[0].color;

                shadowColor.a = method.enabled ? 0.33f : 0.33f;
                shadow.effectColor = shadowColor;
            }
            if (textOutline == true && text.GetComponent<Outline>() == null)
            {
                Outline outline = text.gameObject.AddComponent<Outline>();
                outline.effectColor = method.enabled ? txtOutlineColors[1].colors[1].color : txtOutlineColors[0].colors[0].color;
                outline.effectDistance = new Vector2(0.0008f, 0.0008f);
                outline.useGraphicAlpha = true;
            }
            else
            {
                Destroy(text.GetComponent<Outline>());
            }
        }

        public static void RecreateMenu()
        {
            if (menu != null)
            {
                Destroy(menu);
                menu = null;

                CreateMenu();
                RecenterMenu(rightHanded, UnityInput.Current.GetKey(keyboardButton));
            }
        }

        public static void RecenterMenu(bool isRightHanded, bool isKeyboardCondition)
        {
            if (!isKeyboardCondition)
            {
                if (!isRightHanded)
                {
                    menu.transform.position = GorillaTagger.Instance.leftHandTransform.position;
                    menu.transform.rotation = GorillaTagger.Instance.leftHandTransform.rotation;
                }
                else
                {
                    menu.transform.position = GorillaTagger.Instance.rightHandTransform.position;
                    Vector3 rotation = GorillaTagger.Instance.rightHandTransform.rotation.eulerAngles;
                    rotation += new Vector3(0f, 0f, 180f);
                    menu.transform.rotation = Quaternion.Euler(rotation);
                }
            }
            else
            {
                try
                {
                    TPC = GameObject.Find("Player Objects/Third Person Camera/Shoulder Camera").GetComponent<Camera>();
                }
                catch { }

                GameObject.Find("Shoulder Camera").transform.Find("CM vcam1").gameObject.SetActive(false);

                if (TPC != null)
                {
                    TPC.transform.position = new Vector3(-999f, -999f, -999f);
                    TPC.transform.rotation = Quaternion.identity;
                    if (PCMenuBackground == true)
                    {
                        GameObject bg = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        bg.transform.localScale = new Vector3(10f, 10f, 0.01f);
                        bg.transform.transform.position = TPC.transform.position + TPC.transform.forward;
                        bg.GetComponent<Renderer>().material.color = new Color32((byte)(bgColors.colors[0].color.r * 50), (byte)(bgColors.colors[0].color.g * 50), (byte)(bgColors.colors[0].color.b * 50), 255);
                        Destroy(bg, Time.deltaTime);
                    }
                    menu.transform.parent = TPC.transform;
                    menu.transform.position = TPC.transform.position + Vector3.Scale(TPC.transform.forward, new Vector3(0.5f, 0.5f, 0.5f)) + Vector3.Scale(TPC.transform.up, new Vector3(-0.02f, -0.02f, -0.02f));
                    Vector3 rot = TPC.transform.rotation.eulerAngles;
                    rot = new Vector3(rot.x - 90, rot.y + 90, rot.z);
                    menu.transform.rotation = Quaternion.Euler(rot);
                    TPC.GetComponent<Camera>().fieldOfView = 75;

                    if (reference != null)
                    {
                        if (Mouse.current.leftButton.isPressed)
                        {
                            Ray ray = TPC.ScreenPointToRay(Mouse.current.position.ReadValue());
                            RaycastHit hit;
                            bool worked = Physics.Raycast(ray, out hit, 100);
                            if (worked)
                            {
                                Classes.Button collide = hit.transform.gameObject.GetComponent<Classes.Button>();
                                if (collide != null)
                                {
                                    collide.OnTriggerEnter(buttonCollider);
                                }
                            }
                        }
                        else
                        {
                            reference.transform.position = new Vector3(999f, -999f, -999f);
                        }
                    }
                }
            }
        }

        public static void CreateReference(bool isRightHanded)
        {
            reference = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            if (isRightHanded)
            {
                reference.transform.parent = GorillaTagger.Instance.leftHandTransform;
            }
            else
            {
                reference.transform.parent = GorillaTagger.Instance.rightHandTransform;
            }
            reference.GetComponent<Renderer>().material.color = bgColors.colors[0].color;
            reference.transform.localPosition = new Vector3(0f, -0.1f, 0f);
            reference.transform.localScale = new Vector3(0.008f, 0.008f, 0.008f);
            buttonCollider = reference.GetComponent<SphereCollider>();

            ColorChanger colorChanger = reference.AddComponent<ColorChanger>();
            colorChanger.colorInfo = bgColors;
            colorChanger.Start();
        }

        public static void Toggle(string buttonText)
        {
            int lastPage = (buttons[currentCategory].Length + buttonsPerPage - 1) / buttonsPerPage - 1;
            // skip to end
            if (buttonText == "LastPage")
            {
                pageNumber = lastPage;
            }
            if (buttonText == "FirstPage")
            {
                pageNumber = 0;
            }
            if (buttonText == "PreviousPage")
            {
                pageNumber--;
                if (pageNumber < 0)
                {
                    pageNumber = lastPage;
                }
            }
            else
            {
                if (buttonText == "NextPage")
                {
                    pageNumber++;
                    if (pageNumber > lastPage)
                    {
                        pageNumber = 0;
                    }
                }
                else
                {
                    ButtonInfo target = GetIndex(buttonText);
                    if (target != null)
                    {
                        if (target.isTogglable)
                        {
                            target.enabled = !target.enabled;
                            if (target.enabled)
                            {
                                if (uppercaseText == true)
                                {
                                    NotifiLib.SendNotification("<color=grey>[</color><color=green>ENABLE</color><color=grey>]</color> " + target.toolTip.ToUpper());
                                }
                                if (lowercaseText == true)
                                {
                                    NotifiLib.SendNotification("<color=grey>[</color><color=green>ENABLE</color><color=grey>]</color> " + target.toolTip.ToLower());
                                }
                                else
                                {
                                    NotifiLib.SendNotification("<color=grey>[</color><color=green>ENABLE</color><color=grey>]</color> " + target.toolTip);
                                }
                                if (target.enableMethod != null)
                                {
                                    try { target.enableMethod.Invoke(); } catch { }
                                }
                            }
                            else
                            {
                                if (uppercaseText == true)
                                {
                                    NotifiLib.SendNotification("<color=grey>[</color><color=red>DISABLE</color><color=grey>]</color> " + target.toolTip.ToUpper());
                                }
                                if (lowercaseText == true)
                                {
                                    NotifiLib.SendNotification("<color=grey>[</color><color=red>DISABLE</color><color=grey>]</color> " + target.toolTip.ToLower());
                                }
                                else
                                {
                                    NotifiLib.SendNotification("<color=grey>[</color><color=red>DISABLE</color><color=grey>]</color> " + target.toolTip);
                                }
                                if (target.disableMethod != null)
                                {
                                    try { target.disableMethod.Invoke(); } catch { }
                                }
                            }
                        }
                        else
                        {
                            if (uppercaseText == true)
                            {
                                NotifiLib.SendNotification("<color=grey>[</color><color=green>ENABLE</color><color=grey>]</color> " + target.toolTip.ToUpper());
                            }
                            if (lowercaseText == true)
                            {
                                NotifiLib.SendNotification("<color=grey>[</color><color=green>ENABLE</color><color=grey>]</color> " + target.toolTip.ToLower());
                            }
                            else
                            {
                                NotifiLib.SendNotification("<color=grey>[</color><color=green>ENABLE</color><color=grey>]</color> " + target.toolTip);
                            }
                            if (target.method != null)
                            {
                                try { target.method.Invoke(); } catch { }
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError(buttonText + " does not exist");
                    }
                }
            }
            RecreateMenu();
        }

        public static GradientColorKey[] GetSolidGradient(Color color)
        {
            return new GradientColorKey[] { new GradientColorKey(color, 0f), new GradientColorKey(color, 1f) };
        }
        public static GradientColorKey[] GetMultiGradient(Color a, Color b)
        {
            return new GradientColorKey[] { new GradientColorKey(a, 0f), new GradientColorKey(b, 0.5f), new GradientColorKey(a, 1f) };
        }
        public static GradientColorKey[] GetEToHGradient(Color a, Color b, Color c, Color d, Color e, Color f, Color g, Color h) // 8 colors, easy to insane, insane to nil
        {
            return new GradientColorKey[] { new GradientColorKey(a, 0f), new GradientColorKey(b, 0.142f), new GradientColorKey(c, 0.284f), new GradientColorKey(d, 0.426f), new GradientColorKey(e, 0.568f), new GradientColorKey(f, 0.71f), new GradientColorKey(g, 0.852f), new GradientColorKey(h, 0.96f) };
        }

        public static ButtonInfo GetIndex(string buttonText)
        {
            foreach (ButtonInfo[] buttons in buttons)
            {
                foreach (ButtonInfo button in buttons)
                {
                    if (button.buttonText == buttonText)
                    {
                        return button;
                    }
                }
            }

            return null;
        }
        public static void OutlineObj(GameObject toOut, bool shouldBeEnabled)
        {
            if (outlineactivation != false)
            {
                GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
                UnityEngine.Object.Destroy(gameObject.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(gameObject.GetComponent<BoxCollider>());
                gameObject.transform.parent = menu.transform;
                gameObject.transform.rotation = Quaternion.identity;
                gameObject.transform.localPosition = toOut.transform.localPosition;
                gameObject.transform.localScale = toOut.transform.localScale + new Vector3(-0.01f, 0.01f, 0.0075f);
                ColorChanger colorChanger = gameObject.AddComponent<ColorChanger>();
                colorChanger.colorInfo = outlineColors;
                colorChanger.Start();
                if (roundedMenu)
                {
                    RoundObj(gameObject, 0.024f);
                }
                if (themeType == 29)
                {
                    gameObject.GetComponent<Renderer>().material.color = new Color32(0, 255, 250, 255);
                }
            }  
        }
        public static void OutlineObjNonMenu(GameObject toOut, bool shouldBeEnabled)
        {
            if (outlineactivation != false)
            {
                GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
                UnityEngine.Object.Destroy(gameObject.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(gameObject.GetComponent<BoxCollider>());
                gameObject.transform.parent = toOut.transform.parent;
                gameObject.transform.rotation = toOut.transform.rotation;
                gameObject.transform.localPosition = toOut.transform.localPosition;
                gameObject.transform.localScale = toOut.transform.localScale + new Vector3(0.005f, 0.005f, -0.001f);
                ColorChanger colorChanger = gameObject.AddComponent<ColorChanger>();
                colorChanger.colorInfo = outlineColors;
                colorChanger.Start();
                if (toOut.activeSelf == true)
                {
                    Destroy(gameObject);
                }
            }
        }
        public static void RoundObj(GameObject toRound, float Bevel = 0.02f)
        {
            Renderer ToRoundRenderer = toRound.GetComponent<Renderer>();
            GameObject BaseA = GameObject.CreatePrimitive(PrimitiveType.Cube);
            BaseA.GetComponent<Renderer>().enabled = ToRoundRenderer.enabled;
            Destroy(BaseA.GetComponent<Collider>());

            BaseA.transform.parent = menu.transform;
            BaseA.transform.rotation = Quaternion.identity;
            BaseA.transform.localPosition = toRound.transform.localPosition;
            BaseA.transform.localScale = toRound.transform.localScale + new Vector3(0f, Bevel * -2.55f, 0f);

            GameObject BaseB = GameObject.CreatePrimitive(PrimitiveType.Cube);
            BaseB.GetComponent<Renderer>().enabled = ToRoundRenderer.enabled;
            Destroy(BaseB.GetComponent<Collider>());

            BaseB.transform.parent = menu.transform;
            BaseB.transform.rotation = Quaternion.identity;
            BaseB.transform.localPosition = toRound.transform.localPosition;
            BaseB.transform.localScale = toRound.transform.localScale + new Vector3(0f, 0f, -Bevel * 2f);

            GameObject RoundCornerA = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            RoundCornerA.GetComponent<Renderer>().enabled = ToRoundRenderer.enabled;
            Destroy(RoundCornerA.GetComponent<Collider>());

            RoundCornerA.transform.parent = menu.transform;
            RoundCornerA.transform.rotation = Quaternion.identity * Quaternion.Euler(0f, 0f, 90f);

            RoundCornerA.transform.localPosition = toRound.transform.localPosition + new Vector3(0f, (toRound.transform.localScale.y / 2f) - (Bevel * 1.275f), (toRound.transform.localScale.z / 2f) - Bevel);
            RoundCornerA.transform.localScale = new Vector3(Bevel * 2.55f, toRound.transform.localScale.x / 2f, Bevel * 2f);

            GameObject RoundCornerB = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            RoundCornerB.GetComponent<Renderer>().enabled = ToRoundRenderer.enabled;
            Destroy(RoundCornerB.GetComponent<Collider>());

            RoundCornerB.transform.parent = menu.transform;
            RoundCornerB.transform.rotation = Quaternion.identity * Quaternion.Euler(0f, 0f, 90f);

            RoundCornerB.transform.localPosition = toRound.transform.localPosition + new Vector3(0f, -(toRound.transform.localScale.y / 2f) + (Bevel * 1.275f), (toRound.transform.localScale.z / 2f) - Bevel);
            RoundCornerB.transform.localScale = new Vector3(Bevel * 2.55f, toRound.transform.localScale.x / 2f, Bevel * 2f);

            GameObject RoundCornerC = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            RoundCornerC.GetComponent<Renderer>().enabled = ToRoundRenderer.enabled;
            Destroy(RoundCornerC.GetComponent<Collider>());

            RoundCornerC.transform.parent = menu.transform;
            RoundCornerC.transform.rotation = Quaternion.identity * Quaternion.Euler(0f, 0f, 90f);

            RoundCornerC.transform.localPosition = toRound.transform.localPosition + new Vector3(0f, (toRound.transform.localScale.y / 2f) - (Bevel * 1.275f), -(toRound.transform.localScale.z / 2f) + Bevel);
            RoundCornerC.transform.localScale = new Vector3(Bevel * 2.55f, toRound.transform.localScale.x / 2f, Bevel * 2f);

            GameObject RoundCornerD = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            RoundCornerD.GetComponent<Renderer>().enabled = ToRoundRenderer.enabled;
            Destroy(RoundCornerD.GetComponent<Collider>());

            RoundCornerD.transform.parent = menu.transform;
            RoundCornerD.transform.rotation = Quaternion.identity * Quaternion.Euler(0f, 0f, 90f);

            RoundCornerD.transform.localPosition = toRound.transform.localPosition + new Vector3(0f, -(toRound.transform.localScale.y / 2f) + (Bevel * 1.275f), -(toRound.transform.localScale.z / 2f) + Bevel);
            RoundCornerD.transform.localScale = new Vector3(Bevel * 2.55f, toRound.transform.localScale.x / 2f, Bevel * 2f);

            GameObject[] ToChange = new GameObject[]
            {
                BaseA,
                BaseB,
                RoundCornerA,
                RoundCornerB,
                RoundCornerC,
                RoundCornerD
            };

            foreach (GameObject Changed in ToChange)
            {
                if (Changed.name.Contains("RoundCorner"))
                {
                    Renderer r = Changed.GetComponent<Renderer>();
                    var mat = new Material(Shader.Find("Universal Render Pipeline/Lit"));
                    mat.color = ToRoundRenderer.material.GetColor("_BaseColor");
                    r.material = mat;
                }
                else
                {
                    Changed.GetComponent<Renderer>().material = ToRoundRenderer.material;
                }

                ClampColor TargetChanger = Changed.AddComponent<ClampColor>();
                TargetChanger.targetRenderer = ToRoundRenderer;
            }

            ToRoundRenderer.enabled = false;
        }
        public static Texture2D LoadTextureFromURL(string resourcePath, string fileName)
        {
            Texture2D texture = new Texture2D(2, 2);

            if (!Directory.Exists("silliness/images/"))
            {
                Directory.CreateDirectory("silliness/images/");
            }
            if (!File.Exists("silliness/images/" + fileName))
            {
                UnityEngine.Debug.Log("Downloading " + fileName);
                WebClient stream = new WebClient();
                stream.DownloadFile(resourcePath, "silliness/images/" + fileName);
            }

            byte[] bytes = File.ReadAllBytes("silliness/images/" + fileName);
            texture.LoadImage(bytes);

            return texture;
        }
        public static Texture2D LoadTextureFromResource(string resourcePath)
        {
            Texture2D texture = new Texture2D(2, 2);

            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourcePath);
            if (stream != null)
            {
                byte[] fileData = new byte[stream.Length];
                stream.Read(fileData, 0, (int)stream.Length);
                texture.LoadImage(fileData);
            }
            else
            {
                Debug.LogError("Failed to load texture from resource: " + resourcePath);
            }
            return texture;
        }
        public static AssetBundle assetBundle;
        public static GameObject LoadAsset(string assetName)
        {
            GameObject gameObject = null;

            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("silliness.Resources.silliness");
            if (stream != null)
            {
                if (assetBundle == null)
                {
                    assetBundle = AssetBundle.LoadFromStream(stream);
                }
                gameObject = Instantiate<GameObject>(assetBundle.LoadAsset<GameObject>(assetName));
            }
            else
            {
                Debug.LogError("Failed to load asset from resource: " + assetName);
            }

            return gameObject;
        }
        public static void OnLaunch()
        {
            QualitySettings.vSyncCount = 0;
            if (File.Exists("silliness/EnabledMods.txt") || File.Exists("silliness/CurrentTheme.txt"))
            {
                savedMods = File.ReadAllText("silliness/EnabledMods.txt");
                try
                {
                    SettingsMods.LoadPreferences();
                }
                catch
                {
                    Task.Delay(1000).ContinueWith(t => SettingsMods.LoadPreferences());
                }
            }
            Debug.LogError(string.Format("onlaunch activated"));
            Debug.Log(Font.GetOSInstalledFontNames());
        }

        // i hate everything about this area
        public static GameObject menu;
        public static GameObject menuBackground;
        public static GameObject reference;
        public static GameObject canvasObject;
        public static GameObject canvasfucker;

        public static SphereCollider buttonCollider;
        public static Camera TPC;
        public static Text fpsObject;
        public static Text versionObject;
        public static Text discordObject;
        public static Text Title;
        static Text title;
        static Text leftPageText;
        static Text rightPageText;


        // liby in the studio cooking up DOGSHIT!
        // this HAS to be here in order for themes to properly work
        // without it there is no base theme on first launch or a main theme at all
        public static Color bgColorsA = new Color32(255, 186, 251, 255);
        public static Color bgColorsB = new Color32(255, 204, 253, 255);
        public static Color btDefaultA = new Color32(255, 186, 251, 255);
        public static Color btDefaultB = new Color32(255, 204, 253, 255);
        public static Color btClickedA = new Color32(255, 136, 249, 255);
        public static Color btClickedB = new Color32(255, 136, 249, 255);
        public static Color txtDefaultA = new Color32(255, 255, 255, 255);
        public static Color txtDefaultB = new Color32(255, 255, 255, 255);
        public static Color txtClickedA = new Color32(255, 255, 255, 255);
        public static Color txtClickedB = new Color32(255, 255, 255, 255);
        public static Color titleColorsA = new Color32(255, 255, 255, 255);
        public static Color titleColorsB = new Color32(255, 255, 255, 255);
        public static Color txtOutlineDefaultA = new Color32(255, 255, 255, 255);
        public static Color txtOutlineDefaultB = new Color32(255, 255, 255, 255);
        public static Color txtOutlineClickedA = new Color32(255, 255, 255, 255);
        public static Color txtOutlineClickedB = new Color32(255, 255, 255, 255);
        public static Color outlineColorsA = new Color32(255, 136, 249, 255);
        public static Color outlineColorsB = new Color32(255, 136, 249, 255);

        // the fonts of doom and despair
        public static Font sans = Font.CreateDynamicFontFromOSFont("Comic Sans MS", 24);
        public static Font Arial = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        public static Font Verdana = Font.CreateDynamicFontFromOSFont("Verdana", 24);
        public static Font agency = Font.CreateDynamicFontFromOSFont("Agency FB", 24);
        public static Font consolas = Font.CreateDynamicFontFromOSFont("Consolas", 24);
        public static Font ubuntu = Font.CreateDynamicFontFromOSFont("Candara", 24);
        public static Font MSGOTHIC = Font.CreateDynamicFontFromOSFont("MS Gothic", 24);
        public static Font impact = Font.CreateDynamicFontFromOSFont("Impact", 24);
        public static Font bahnschrift = Font.CreateDynamicFontFromOSFont("Bahnschrift", 24);
        public static Font calibri = Font.CreateDynamicFontFromOSFont("Calibri", 24);
        public static Font cambria = Font.CreateDynamicFontFromOSFont("Cambria", 24);
        public static Font cascadiacode = Font.CreateDynamicFontFromOSFont("Cascadia Code", 24);
        public static Font cascadiamono = Font.CreateDynamicFontFromOSFont("Cascadia Mono", 24);
        public static Font constantia = Font.CreateDynamicFontFromOSFont("Constantia", 24);
        public static Font corbel = Font.CreateDynamicFontFromOSFont("Corbel", 24);
        public static Font couriernew = Font.CreateDynamicFontFromOSFont("Courier New", 24);
        public static Font dengxian = Font.CreateDynamicFontFromOSFont("DengXian", 24);
        public static Font ebrima = Font.CreateDynamicFontFromOSFont("Ebrima", 24);
        public static Font fangsong = Font.CreateDynamicFontFromOSFont("FangSong", 24);
        public static Font franklingothic = Font.CreateDynamicFontFromOSFont("Franklin Gothic Medium", 24);
        public static Font gabriola = Font.CreateDynamicFontFromOSFont("Gabriola", 24);
        public static Font gadugi = Font.CreateDynamicFontFromOSFont("Gadugi", 24);
        public static Font georgia = Font.CreateDynamicFontFromOSFont("Georgia", 24);
        public static Font hololens = Font.CreateDynamicFontFromOSFont("HoloLens MDL2 Assets", 24);
        public static Font inkfree = Font.CreateDynamicFontFromOSFont("Ink Free", 24);
        public static Font javanesetext = Font.CreateDynamicFontFromOSFont("Javanese Text", 24);
        public static Font kaiti = Font.CreateDynamicFontFromOSFont("KaiTi", 24);
        public static Font lucidaconsole = Font.CreateDynamicFontFromOSFont("Lucida Console", 24);
        public static Font dynamo = Font.CreateDynamicFontFromOSFont("Dynamo Regular", 24);

        // like zoinks scoob! theres a fuck ton of integers and other shit making the area look like dogshit down here! RUH ROH RAGGY!
        public static int pageNumber = 0;
        public static int buttonsType = 0;
        public static int themeType = 1;
        public static int fontType = 0;
        public static float autoSaveDelay = Time.time + 60f;
        public static float recreateDelay = Time.time + 0.1f;
        public static string customMenuName = "You can change this in Gorilla Tag/silliness";
        public static string savedMods;
        public static string ownerUserID = "2C7484982273DD6C";
        public static bool HasLoaded = false;
        public static bool ownerSettings;
        public static bool adminSettings;
        public static bool superAdminSettings;
        public static bool wasRounded = false;
        public static bool wasTextOutlined = false;
        public static double badAppleTime = 1;
        public static Material destinyMat = null;
        public static Texture2D destinyIcon = null;
        public static Material RainXYZMat = null;
        public static Texture2D RainXYZIcon = null;
        public static Material GPhysMat = null;
        public static Texture2D GPhysIcon = null;
        public static Material homeMat = null;
        public static Texture2D homeIcon = null;
        public static Material settingsMat = null;
        public static Texture2D settingsIcon = null;
        public static Material skiptoendMat = null;
        public static Texture2D skiptoendIcon = null;
        public static Material skiptostartMat = null;
        public static Texture2D skiptostartIcon = null;
        public static bool rightPrimary = false;
        public static bool rightSecondary = false;
        public static bool leftPrimary = false;
        public static bool leftSecondary = false;
        public static bool leftGrab = false;
        public static bool rightGrab = false;
        public static float leftTrigger = 0f;
        public static float rightTrigger = 0f;

        public static int _currentCategory;
        private static readonly int MainTex = Shader.PropertyToID("_MainTex");

        public static int currentCategory
        {
            get => _currentCategory;
            set
            {
                _currentCategory = value;
                pageNumber = 0;
            }
        }
    }
}
