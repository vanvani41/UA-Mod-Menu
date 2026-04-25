using GorillaLocomotion;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using static StupidTemplate.Menu.Main;

namespace StupidTemplate.Mods
{
    internal class Guns
    {
        private static bool Grabbing => ControllerInputPoller.instance.rightGrab || (Mouse.current != null && Mouse.current.rightButton.isPressed);
        private static bool Triggering => ControllerInputPoller.TriggerFloat(XRNode.RightHand) > 0.5f || (Mouse.current != null && Mouse.current.leftButton.isPressed);

        public static bool previousTeleportTrigger;
        public static void TeleportGun()
        {
            if (Grabbing)
            {
                var GunData = RenderGun();
                GameObject NewPointer = GunData.NewPointer;

                if (Triggering && !previousTeleportTrigger)
                {
                    GTPlayer.Instance.TeleportTo(NewPointer.transform.position + Vector3.up, GTPlayer.Instance.transform.rotation);
                    GorillaTagger.Instance.rigidbody.linearVelocity = Vector3.zero;
                }

                previousTeleportTrigger = Triggering;
            }
        }

        public static bool previousTagTrigger;
        private static float tagReturnTime;
        private static bool waitingToReturn;

        public static void TagGun()
        {
            var rig = GorillaTagger.Instance.offlineVRRig;

            if (waitingToReturn && Time.time >= tagReturnTime)
            {
                rig.enabled = true;
                waitingToReturn = false;
            }

            if (Grabbing)
            {
                var GunData = RenderGun();
                GameObject NewPointer = GunData.NewPointer;

                if (Triggering && !previousTagTrigger && !waitingToReturn)
                {
                    if (Physics.Raycast(NewPointer.transform.position, NewPointer.transform.forward, out RaycastHit hit, 50f))
                    {
                        VRRig target = hit.collider.GetComponentInParent<VRRig>();
                        if (target != null && !target.isLocal)
                        {
                            rig.enabled = false;
                            rig.transform.position = target.transform.position;
                            tagReturnTime = Time.time + 0.5f;
                            waitingToReturn = true;
                        }
                    }
                }

                previousTagTrigger = Triggering;
            }
        }
    }
}