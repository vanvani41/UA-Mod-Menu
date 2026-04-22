using BepInEx;
using GorillaLocomotion;
using Oculus.Interaction.Input;
using Photon.Pun;
using StupidTemplate.Classes;
using System.Collections.Generic;
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
                Notifications.NotifiLib.SendNotification("<color=grey>[</color><color=purple>MASTER</color><color=grey>]</color> You are now the master client.");
            }
            else
            {
                Notifications.NotifiLib.SendNotification("<color=grey>[</color><color=purple>MASTER</color><color=grey>]</color> You are no longer the master client.");
            }
        }
        public static void KickGun()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                var GunData = RenderGun();
                GameObject NewPointer = GunData.NewPointer;

                if (ControllerInputPoller.TriggerFloat(XRNode.RightHand) > 0.5f && !Movement.previousTeleportTrigger)
                {
                    if (Physics.Raycast(NewPointer.transform.position, NewPointer.transform.forward, out RaycastHit hit, 50f))
                    {
                        VRRig rig = hit.collider.GetComponentInParent<VRRig>();
                        if (rig != null && !rig.isLocal)
                        {
                            if (PhotonNetwork.IsMasterClient)
                            {
                                foreach (var player in PhotonNetwork.PlayerList)
                                {
                                    if (player.UserId == rig.Creator.UserId)
                                    {
                                        PhotonNetwork.CloseConnection(player);
                                        break;
                                    }
                                }
                            }
                            else
                                NetworkSystem.Instance.ReturnToSinglePlayer();
                        }
                    }
                }

                Movement.previousTeleportTrigger = ControllerInputPoller.TriggerFloat(XRNode.RightHand) > 0.5f;
            }
        }
    }
}
