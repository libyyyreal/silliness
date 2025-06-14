using Photon.Realtime;
using Photon.Pun;
using BepInEx;
using HarmonyLib;
using UnityEngine;

namespace silliness.Classes
{
    internal class RigManager : BaseUnityPlugin
    {
        public static VRRig GetVRRigFromPlayer(Player p)
        {
            return GorillaGameManager.instance.FindPlayerVRRig(p);
        }

        public static VRRig GetRandomVRRig(bool includeSelf)
        {
            VRRig random = GorillaParent.instance.vrrigs[Random.Range(0, GorillaParent.instance.vrrigs.Count - 1)];
            if (includeSelf)
            {
                return random;
            }
            else
            {
                if (random != GorillaTagger.Instance.offlineVRRig)
                {
                    return random;
                }
                else
                {
                    return GetRandomVRRig(includeSelf);
                }
            }
        }

        public static VRRig GetClosestVRRig()
        {
            float num = float.MaxValue;
            VRRig outRig = null;
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (Vector3.Distance(GorillaTagger.Instance.bodyCollider.transform.position, vrrig.transform.position) < num)
                {
                    num = Vector3.Distance(GorillaTagger.Instance.bodyCollider.transform.position, vrrig.transform.position);
                    outRig = vrrig;
                }
            }
            return outRig;
        }

        public static PhotonView GetPhotonViewFromVRRig(VRRig p)
        {
            return (PhotonView)Traverse.Create(p).Field("photonView").GetValue();
        }

        public static Player GetRandomPlayer(bool includeSelf)
        {
            if (includeSelf)
            {
                return PhotonNetwork.PlayerList[Random.Range(0, PhotonNetwork.PlayerList.Length - 1)];
            } else
            {
                return PhotonNetwork.PlayerListOthers[Random.Range(0, PhotonNetwork.PlayerListOthers.Length - 1)];
            }
        }

        public static Player GetPlayerFromVRRig(VRRig p)
        {
            return GetPhotonViewFromVRRig(p).Owner;
        }

        public static Player GetPlayerFromID(string id)
        {
            Player found = null;
            foreach (Player target in PhotonNetwork.PlayerList)
            {
                if (target.UserId == id)
                {
                    found = target;
                    break;
                }
            }
            return found;
        }
    }
}