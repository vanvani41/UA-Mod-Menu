using GorillaLocomotion;
using StupidTemplate.Classes;
using UnityEngine;
using UnityEngine.XR;
using BepInEx;
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
            // ЛІВА РУКА
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

            // ПРАВА РУКА
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
                    platsgl.transform.localScale = new Vector3(0.025f, 0.3f, 1f);
                    platsgl.transform.position = TrueLeftHand().position;
                    platsgl.transform.rotation = TrueLeftHand().rotation;
                    FixStickyColliders(platsgl);
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
                    platsgr.transform.localScale = new Vector3(0.025f, 0.3f, 1f);
                    platsgr.transform.position = TrueRightHand().position;
                    platsgr.transform.rotation = TrueRightHand().rotation;
                    FixStickyColliders(platsgr);
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
                    platstl.transform.localScale = new Vector3(0.025f, 0.3f, 1f);
                    platstl.transform.position = TrueLeftHand().position;
                    platstl.transform.rotation = TrueLeftHand().rotation;
                    FixStickyColliders(platstl);
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
                    platstr.transform.localScale = new Vector3(0.025f, 0.3f, 1f);
                    platstr.transform.position = TrueRightHand().position;
                    platstr.transform.rotation = TrueRightHand().rotation;
                    FixStickyColliders(platstr);
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
        public static void GhostMonke()
        {
            if (ControllerInputPoller.instance.leftControllerPrimaryButton)
            {
                GorillaTagger.Instance.offlineVRRig.enabled = false;
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
            }
        }
        public static void InvisMonke()
        {
            var rig = GorillaTagger.Instance.offlineVRRig;
            if (rig == null) return;

            bool isPressed = ControllerInputPoller.instance.rightControllerPrimaryButton;

            // Вимикаємо основний меш тіла
            if (rig.mainSkin != null)
            {
                rig.mainSkin.enabled = !isPressed;
            }

            // Якщо headMesh видає помилку, шукаємо голову через трансформ
            // Зазвичай модель голови є дитиною об'єкта "head" або частиною mainSkin
            var headTransform = rig.head.rigTarget.transform;
            // Або спробуй вимкнути рендерери у всіх дочірніх об'єктах:
            foreach (var renderer in rig.GetComponentsInChildren<Renderer>())
            {
                renderer.enabled = !isPressed;
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
            bool isTriggerPressed = ControllerInputPoller.instance.rightControllerTriggerButton;
            MeshCollider[] colliders = Resources.FindObjectsOfTypeAll<MeshCollider>();
            if (isTriggerPressed)
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
            bool isTriggerPressed = ControllerInputPoller.instance.leftControllerTriggerButton;
            MeshCollider[] colliders = Resources.FindObjectsOfTypeAll<MeshCollider>();
            if (isTriggerPressed)
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

        public static void NoclipFly()
        {
            bool isTriggerPressed = ControllerInputPoller.instance.rightControllerPrimaryButton;
            MeshCollider[] colliders = Resources.FindObjectsOfTypeAll<MeshCollider>();
            if (isTriggerPressed)
            {
                foreach (MeshCollider collider in colliders)
                {
                    collider.enabled = false;
                    GTPlayer.Instance.transform.position += GorillaTagger.Instance.headCollider.transform.forward * Time.deltaTime * Settings.Movement.flySpeed;
                    GorillaTagger.Instance.rigidbody.linearVelocity = Vector3.zero;
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
        public static void CarMonke()
        {
            if (ControllerInputPoller.instance.leftGrab)
            {
                GTPlayer.Instance.transform.position -= GorillaTagger.Instance.headCollider.transform.forward * Time.deltaTime * Settings.Movement.CarMonkeSpeed;
            }
            if (ControllerInputPoller.instance.rightGrab)
            {
                GTPlayer.Instance.transform.position += GorillaTagger.Instance.headCollider.transform.forward * Time.deltaTime * Settings.Movement.CarMonkeSpeed;
            }
        }

        public static void PullModR()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                GTPlayer.Instance.transform.position = GTPlayer.Instance.transform.position * Settings.Movement.PullSpeed;
            }
        }
        public static void PullModL()
        {
            if (ControllerInputPoller.instance.leftGrab)
            {
                GTPlayer.Instance.transform.position = GTPlayer.Instance.transform.position * Settings.Movement.PullSpeed;
            }
        }
    }
}
