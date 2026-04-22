using BepInEx;
using GorillaLocomotion;
using GorillaTag.GuidedRefs;
using Oculus.Interaction.Input;
using Photon.Pun;
using StupidTemplate.Classes;
using System.Collections.Generic;
using System.Drawing;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.XR;
using static StupidTemplate.Menu.Main;
using static UnityEngine.Rendering.DebugUI.Table;

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
                        Notifications.NotifiLib.SendNotification("<color=green>Hit: </color>" + hit.collider.gameObject.name);

                        VRRig rig = hit.collider.GetComponentInParent<VRRig>();
                        if (rig != null)
                        {
                            Notifications.NotifiLib.SendNotification("<color=green>Found rig: </color>" + rig.Creator.UserId);
                        }
                        else
                        {
                            Notifications.NotifiLib.SendNotification("<color=red>No VRRig found on: </color>" + hit.collider.gameObject.name);
                        }
                    }
                    else
                    {
                        Notifications.NotifiLib.SendNotification("<color=red>Raycast missed!</color>");
                    }
                }

                previousKickTrigger = ControllerInputPoller.TriggerFloat(XRNode.RightHand) > 0.5f;
            }
        }
    }
}
