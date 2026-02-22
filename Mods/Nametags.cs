using UnityEngine;
using Photon.Pun;

namespace StupidTemplate.Mods
{
    public class Nametags : MonoBehaviour
    {
        public static bool nameTags, idTags, colorTags, platformTags, modsTags, fpsTags, hzTags, lagTags;

        public static TextMesh GetTag(VRRig rig)
        {
            // Використовуємо head.rigTarget, щоб уникнути помилки CS1061 з headMesh
            Transform headTransform = rig.head.rigTarget.transform;
            Transform existing = headTransform.Find("StupidNameTag");

            if (existing == null)
            {
                GameObject obj = new GameObject("StupidNameTag");
                obj.transform.SetParent(headTransform, false);
                obj.transform.localPosition = new Vector3(0, 0.45f, 0);

                TextMesh tm = obj.AddComponent<TextMesh>();

                // Використовуємо твій currentFont
                if (StupidTemplate.Settings.currentFont != null)
                {
                    tm.font = StupidTemplate.Settings.currentFont;
                    obj.GetComponent<MeshRenderer>().material = tm.font.material;
                }

                tm.fontSize = 50;
                tm.characterSize = 0.01f;
                tm.anchor = TextAnchor.LowerCenter;
                tm.alignment = TextAlignment.Center;
                return tm;
            }
            return existing.GetComponent<TextMesh>();
        }

        public static void ClearTag(VRRig rig)
        {
            Transform t = rig.head.rigTarget.transform.Find("StupidNameTag");
            if (t != null) t.GetComponent<TextMesh>().text = "";
        }

        public static void RunNametags()
        {
            if (GorillaParent.instance == null) return;

            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (vrrig != null && !vrrig.isOfflineVRRig)
                {
                    ClearTag(vrrig);
                    TextMesh tm = GetTag(vrrig);

                    if (nameTags) tm.text += vrrig.playerNameVisible + "\n";

                    if (idTags)
                    {
                        PhotonView view = vrrig.GetComponent<PhotonView>();
                        tm.text += "ID: " + (view?.Owner?.UserId ?? "N/A") + "\n";
                    }

                    if (colorTags)
                    {
                        Color c = vrrig.playerColor;
                        tm.text += $"Color: {Mathf.RoundToInt(c.r * 9)},{Mathf.RoundToInt(c.g * 9)},{Mathf.RoundToInt(c.b * 9)}\n";
                    }

                    // Billboarding (поворот до гравця)
                    if (Camera.main != null)
                    {
                        tm.transform.LookAt(tm.transform.position + Camera.main.transform.rotation * Vector3.forward,
                                           Camera.main.transform.rotation * Vector3.up);
                    }

                    // Якщо тексту немає - видаляємо об'єкт
                    if (string.IsNullOrEmpty(tm.text)) Destroy(tm.gameObject);
                }
            }
        }
    }
}
