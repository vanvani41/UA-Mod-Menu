using Photon.Pun;
using UnityEngine;
using UnityEngine.XR;
using static StupidTemplate.Menu.Main;

namespace StupidTemplate.Mods
{
    internal class Master
    {
        public static void CheckIsMaster()
        {
            if (PhotonNetwork.IsMasterClient)
            {
                Notifications.NotifiLib.SendNotification("<color=grey>[</color><color=purple>MASTER</color><color=grey>]</color> You are the master client.");
            }
            else
            {
                Notifications.NotifiLib.SendNotification("<color=grey>[</color><color=purple>MASTER</color><color=grey>]</color> You are not the master client.");
            }
        }

        public static bool previousKickTrigger;

        public static void KickGun()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                var GunData = RenderGun();
                GameObject NewPointer = GunData.NewPointer;

                if (ControllerInputPoller.TriggerFloat(XRNode.RightHand) > 0.5f && !previousKickTrigger)
                {
                    if (Physics.Raycast(NewPointer.transform.position, NewPointer.transform.forward, out RaycastHit hit, 50f))
                    {
                        VRRig rig = hit.collider.GetComponentInParent<VRRig>();
                        if (rig != null && !rig.isLocal && rig.Creator != null)
                        {
                            if (PhotonNetwork.IsMasterClient)
                            {
                                foreach (var player in PhotonNetwork.PlayerList)
                                {
                                    if (player.UserId == rig.Creator.UserId)
                                    {
                                        PhotonNetwork.CloseConnection(player);
                                        Notifications.NotifiLib.SendNotification("<color=green>Kicked: </color>" + rig.Creator.NickName);
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                Notifications.NotifiLib.SendNotification("<color=red>Not master client!</color>");
                            }
                        }
                    }
                }

                previousKickTrigger = ControllerInputPoller.TriggerFloat(XRNode.RightHand) > 0.5f;
            }
        }
    }
}
