using BepInEx;
using GorillaLocomotion;
using Oculus.Interaction.Input;
using StupidTemplate.Classes;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using static StupidTemplate.Menu.Main;

namespace StupidTemplate.Mods
{
    public class Movement
    {
        public static void Fly()
        {
            if (ControllerInputPoller.instance.rightControllerPrimaryButton)
            {
                GTPlayer.Instance.transform.position += GorillaTagger.Instance.headCollider.transform.forward * Time.deltaTime * Settings.Movement.flySpeed;
                GorillaTagger.Instance.rigidbody.linearVelocity = Vector3.zero;
            }
        }

        public static GameObject platgl;
        public static GameObject platgr;

        public static void GripPlatforms()
        {
            if (ControllerInputPoller.instance.leftGrab)
            {
                if (platgl == null)
                {
                    platgl = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    platgl.transform.localScale = new Vector3(0.025f, 0.3f, 0.4f);
                    platgl.transform.position = TrueLeftHand().position - (Vector3.up * 0.1f);
                    platgl.transform.rotation = TrueLeftHand().rotation;
                    FixStickyColliders(platgl);
                    platgl.AddComponent<ColorChanger>().colors = StupidTemplate.Settings.backgroundColor;
                }
            }
            else
            {
                if (platgl != null) { Object.Destroy(platgl); platgl = null; }
            }
            if (ControllerInputPoller.instance.rightGrab)
            {
                if (platgr == null)
                {
                    platgr = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    platgr.transform.localScale = new Vector3(0.025f, 0.3f, 0.4f);
                    platgr.transform.position = TrueRightHand().position - (Vector3.up * 0.1f);
                    platgr.transform.rotation = TrueRightHand().rotation;
                    FixStickyColliders(platgr);
                    platgr.AddComponent<ColorChanger>().colors = StupidTemplate.Settings.backgroundColor;
                }
            }
            else
            {
                if (platgr != null) { Object.Destroy(platgr); platgr = null; }
            }
        }

        public static GameObject plattl;
        public static GameObject plattr;

        public static void TriggerPlatforms()
        {
            if (ControllerInputPoller.instance.leftControllerTriggerButton)
            {
                if (plattl == null)
                {
                    plattl = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    plattl.transform.localScale = new Vector3(0.025f, 0.3f, 0.4f);
                    plattl.transform.position = TrueLeftHand().position - (Vector3.up * 0.1f);
                    plattl.transform.rotation = TrueLeftHand().rotation;
                    FixStickyColliders(plattl);
                    plattl.AddComponent<ColorChanger>().colors = StupidTemplate.Settings.backgroundColor;
                }
            }
            else
            {
                if (plattl != null) { Object.Destroy(plattl); plattl = null; }
            }

            if (ControllerInputPoller.instance.rightControllerTriggerButton)
            {
                if (plattr == null)
                {
                    plattr = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    plattr.transform.localScale = new Vector3(0.025f, 0.3f, 0.4f);
                    plattr.transform.position = TrueRightHand().position - (Vector3.up * 0.1f);
                    plattr.transform.rotation = TrueRightHand().rotation;
                    FixStickyColliders(plattr);
                    plattr.AddComponent<ColorChanger>().colors = StupidTemplate.Settings.backgroundColor;
                }
            }
            else
            {
                if (plattr != null) { Object.Destroy(plattr); plattr = null; }
            }
        }

        public static GameObject platsgl;
        public static GameObject platsgr;

        public static void GripStickyPlatforms()
        {
            if (ControllerInputPoller.instance.leftGrab)
            {
                if (platsgl == null)
                {
                    platsgl = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    platsgl.transform.localScale = new Vector3(0.05f, 0.05f, 0.4f);
                    platsgl.transform.position = TrueLeftHand().position;
                    platsgl.transform.rotation = TrueLeftHand().rotation;
                    FixStickyColliders1(platsgl);
                    platsgl.AddComponent<ColorChanger>().colors = StupidTemplate.Settings.backgroundColor;
                }
            }
            else
            {
                if (platsgl != null) { Object.Destroy(platsgl); platsgl = null; }
            }

            if (ControllerInputPoller.instance.rightGrab)
            {
                if (platsgr == null)
                {
                    platsgr = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    platsgr.transform.localScale = new Vector3(0.05f, 0.05f, 0.4f);
                    platsgr.transform.position = TrueRightHand().position;
                    platsgr.transform.rotation = TrueRightHand().rotation;
                    FixStickyColliders1(platsgr);
                    platsgr.AddComponent<ColorChanger>().colors = StupidTemplate.Settings.backgroundColor;
                }
            }
            else
            {
                if (platsgr != null) { Object.Destroy(platsgr); platsgr = null; }
            }
        }

        public static GameObject platstl;
        public static GameObject platstr;

        public static void TriggerStickyPlatforms()
        {
            if (ControllerInputPoller.instance.leftControllerTriggerButton)
            {
                if (platstl == null)
                {
                    platstl = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    platstl.transform.localScale = new Vector3(0.05f, 0.05f, 0.4f);
                    platstl.transform.position = TrueLeftHand().position;
                    platstl.transform.rotation = TrueLeftHand().rotation;
                    FixStickyColliders1(platstl);
                    platstl.AddComponent<ColorChanger>().colors = StupidTemplate.Settings.backgroundColor;
                }
            }
            else
            {
                if (platstl != null) { Object.Destroy(platstl); platstl = null; }
            }

            if (ControllerInputPoller.instance.rightControllerTriggerButton)
            {
                if (platstr == null)
                {
                    platstr = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    platstr.transform.localScale = new Vector3(0.05f, 0.05f, 0.4f);
                    platstr.transform.position = TrueRightHand().position;
                    platstr.transform.rotation = TrueRightHand().rotation;
                    FixStickyColliders1(platstr);
                    platstr.AddComponent<ColorChanger>().colors = StupidTemplate.Settings.backgroundColor;
                }
            }
            else
            {
                if (platstr != null) { Object.Destroy(platstr); platstr = null; }
            }
        }



        public static bool previousTeleportTrigger;
        public static void TeleportGun()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                var GunData = RenderGun();
                GameObject NewPointer = GunData.NewPointer;

                if (ControllerInputPoller.TriggerFloat(XRNode.RightHand) > 0.5f && !previousTeleportTrigger)
                {
                    GTPlayer.Instance.TeleportTo(NewPointer.transform.position + Vector3.up, GTPlayer.Instance.transform.rotation);
                    GorillaTagger.Instance.rigidbody.linearVelocity = Vector3.zero;
                }

                previousTeleportTrigger = ControllerInputPoller.TriggerFloat(XRNode.RightHand) > 0.5f;
            }
        }
        public static void Speedboost()
        {
            bool speedboost = true;
            if (speedboost == true)
            {
                GTPlayer.Instance.maxJumpSpeed = Settings.Movement.Speedboost;
                GTPlayer.Instance.jumpMultiplier = Settings.Movement.Speedboost;
            }
            else
            {
                    GTPlayer.Instance.maxJumpSpeed = 6.5f;
                    GTPlayer.Instance.jumpMultiplier = 1.1f;
            }
        }
        public static bool ghostOn = false;
        public static bool ghostPressed = false;

        public static bool invOn = false;
        public static bool invPressed = false;

        public static void GhostMonkeT()
        {
            bool isDown = ControllerInputPoller.instance.leftControllerPrimaryButton;
            if (isDown && !ghostPressed) ghostOn = !ghostOn;
            ghostPressed = isDown;

            UpdateRigState();
        }

        public static void InvisMonkeH()
        {
            bool invHold = ControllerInputPoller.instance.rightControllerPrimaryButton;
            UpdateRigState(invHold);
        }

        public static void InvisMonkeT()
        {
            bool isDown = ControllerInputPoller.instance.rightControllerPrimaryButton;
            if (isDown && !invPressed) invOn = !invOn;
            invPressed = isDown;

            UpdateRigState(false);
        }

        private static void UpdateRigState(bool invHold = false)
        {
            var rig = GorillaTagger.Instance.offlineVRRig;

            bool invisActive = invOn || invHold;

            rig.enabled = !(ghostOn || invisActive);

            if (invisActive)
                rig.transform.position = Vector3.up * 9999f;
            else if (!ghostOn)
                rig.transform.position = GorillaTagger.Instance.headCollider.transform.position;
        }

        public static void GhostMonkeH()
        {
            if(ControllerInputPoller.instance.leftControllerPrimaryButton)
            {
                GorillaTagger.Instance.offlineVRRig.enabled = false;
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
            }
        }
      
        public static void WASDFly()
        {
            if (UnityInput.Current.GetKey(KeyCode.W))
            {
                GTPlayer.Instance.transform.position += GorillaTagger.Instance.headCollider.transform.forward * Time.deltaTime * Settings.Movement.WASDSpeed;
                GorillaTagger.Instance.rigidbody.linearVelocity = Vector3.zero;
            }
            if (UnityInput.Current.GetKey(KeyCode.S))
            {
                GTPlayer.Instance.transform.position -= GorillaTagger.Instance.headCollider.transform.forward * Time.deltaTime * Settings.Movement.WASDSpeed;
                GorillaTagger.Instance.rigidbody.linearVelocity = Vector3.zero;
            }
            if (UnityInput.Current.GetKey(KeyCode.D))
            {
                GTPlayer.Instance.transform.position += GorillaTagger.Instance.headCollider.transform.right * Time.deltaTime * Settings.Movement.WASDSpeed;
                GorillaTagger.Instance.rigidbody.linearVelocity = Vector3.zero;
            }
            if (UnityInput.Current.GetKey(KeyCode.A))
            {
                GTPlayer.Instance.transform.position -= GorillaTagger.Instance.headCollider.transform.right * Time.deltaTime * Settings.Movement.WASDSpeed;
                GorillaTagger.Instance.rigidbody.linearVelocity = Vector3.zero;
            }
            if (UnityInput.Current.GetKey(KeyCode.Space))
            {
                GTPlayer.Instance.transform.position += GorillaTagger.Instance.headCollider.transform.up * Time.deltaTime * Settings.Movement.WASDSpeed;
                GorillaTagger.Instance.rigidbody.linearVelocity = Vector3.zero;
            }
            if (UnityInput.Current.GetKey(KeyCode.LeftControl))
            {
                GTPlayer.Instance.transform.position -= GorillaTagger.Instance.headCollider.transform.up * Time.deltaTime * Settings.Movement.WASDSpeed;
                GorillaTagger.Instance.rigidbody.linearVelocity = Vector3.zero;
            }
        }
        public static void NoclipRT()
        {
            MeshCollider[] colliders = Resources.FindObjectsOfTypeAll<MeshCollider>();
            if (ControllerInputPoller.instance.rightControllerTriggerButton)
            {
                foreach (MeshCollider collider in colliders)
                {
                    collider.enabled = false;
                }
            }
            else
            {
                foreach (MeshCollider collider in colliders)
                {
                    collider.enabled = true;
                }
            }
        }
        public static void NoclipLT()
        {
            MeshCollider[] colliders = Resources.FindObjectsOfTypeAll<MeshCollider>();
            if (ControllerInputPoller.instance.leftControllerTriggerButton)
            {
                foreach (MeshCollider collider in colliders)
                {
                    collider.enabled = false;
                }
            }
            else
            {
                foreach (MeshCollider collider in colliders)
                {
                    collider.enabled = true;
                }
            }
        }
        public static void CarMonkeG()
        {
            if (ControllerInputPoller.instance.leftGrab)
            {
                GTPlayer.Instance.transform.position -= GorillaTagger.Instance.headCollider.transform.forward * Time.deltaTime * Settings.Movement.CarMonkeSpeed;
                GorillaTagger.Instance.rigidbody.linearVelocity -= Vector3.forward;
            }
            if (ControllerInputPoller.instance.rightGrab)
            {
                GTPlayer.Instance.transform.position += GorillaTagger.Instance.headCollider.transform.forward * Time.deltaTime * Settings.Movement.CarMonkeSpeed;
                GorillaTagger.Instance.rigidbody.linearVelocity = Vector3.forward;
            }
        }
        public static void CarMonkeT()
        {
            if (ControllerInputPoller.instance.leftControllerTriggerButton)
            {
                GTPlayer.Instance.transform.position -= GorillaTagger.Instance.headCollider.transform.forward * Time.deltaTime * Settings.Movement.CarMonkeSpeed;
                GorillaTagger.Instance.rigidbody.linearVelocity -= Vector3.forward;
            }
            if (ControllerInputPoller.instance.rightControllerTriggerButton)
            {
                GTPlayer.Instance.transform.position += GorillaTagger.Instance.headCollider.transform.forward * Time.deltaTime * Settings.Movement.CarMonkeSpeed;
                GorillaTagger.Instance.rigidbody.linearVelocity = Vector3.forward;
            }
        }
        public static void SpiderMonkeLWLT()
        {
            if (ControllerInputPoller.instance.leftControllerTriggerButton)
            {
                GTPlayer.Instance.transform.position += GorillaTagger.Instance.headCollider.transform.forward * Time.deltaTime * 10f;
                GorillaTagger.Instance.rigidbody.linearVelocity += Vector3.forward;
            }
        }
        public static void SpiderMonkeLWLG()
        {
            if (ControllerInputPoller.instance.leftGrab)
            {
                GTPlayer.Instance.transform.position += GorillaTagger.Instance.headCollider.transform.forward * Time.deltaTime * 10f;
                GorillaTagger.Instance.rigidbody.linearVelocity += Vector3.forward;
            }
        }
        // Ти сам встановлюєш ці рефи десь у Start/Awake
        public static Rigidbody playerBody;
        public static Transform rightHand;

        public static LayerMask groundMask;

        public static float pullStrength = 1.0f;
        public static float maxStep = 0.08f;
        public static float groundRadius = 0.04f;

        private static Vector3 prevRightHandPos;
        private static bool inited;
        public static Transform leftHand;
        private static Vector3 prevLeftHandPos;

        public static void PullModR(bool triggerHeld)
        {
            if (!inited)
            {
                if (leftHand != null) prevRightHandPos = leftHand.position;
                inited = true;
            }

            if (playerBody == null || leftHand == null) return;

            if (triggerHeld)
            {
                // тут код (актив)
                Vector3 delta = leftHand.position - prevRightHandPos;

                bool touchingGround = Physics.CheckSphere(leftHand.position, groundRadius, groundMask, QueryTriggerInteraction.Ignore);

                if (touchingGround)
                {
                    Vector3 desired = (-delta) * pullStrength;

                    if (desired.magnitude > maxStep)
                        desired = desired.normalized * maxStep;

                    playerBody.MovePosition(playerBody.position + desired);
                }
            }
            else
            {
                // тут код (неактив) — просто ресет, щоб не було ривка
                prevLeftHandPos = leftHand.position;
            }

            prevLeftHandPos = leftHand.position;
        }
        public static void PullModL(bool triggerHeld)
        {
            if (!inited)
            {
                if (rightHand != null) prevLeftHandPos = rightHand.position;
                inited = true;
            }

            if (playerBody == null || rightHand == null) return;

            if (triggerHeld)
            {
                // тут код (актив)
                Vector3 delta = rightHand.position - prevLeftHandPos;

                bool touchingGround = Physics.CheckSphere(rightHand.position, groundRadius, groundMask, QueryTriggerInteraction.Ignore);

                if (touchingGround)
                {
                    Vector3 desired = (-delta) * pullStrength;

                    if (desired.magnitude > maxStep)
                        desired = desired.normalized * maxStep;

                    playerBody.MovePosition(playerBody.position + desired);
                }
            }
            else
            {
                prevRightHandPos = rightHand.position;
            }

            prevLeftHandPos = rightHand.position;
        }
        public static void PullModRG()
        {
            PullModR(ControllerInputPoller.instance.rightGrab);
        }
        public static void PullModRT()
        {
            PullModR(ControllerInputPoller.instance.rightControllerTriggerButton);
        }
        public static void PullModLG()
        {
            PullModR(ControllerInputPoller.instance.leftGrab);
        }
        public static void PullModLT()
        {
            PullModR(ControllerInputPoller.instance.leftControllerTriggerButton);
        }
    }
}
