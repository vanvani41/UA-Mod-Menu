using System;
using UnityEngine;
using Photon.Pun;
using GorillaLocomotion;

namespace StupidTemplate.Mods
{
    public class Nametags : MonoBehaviour
    {
        // Допоміжний метод для створення/пошуку об'єкта тексту на голові
        public static bool nameTags = false;
        public static bool idTags = false;
        public static bool colorTags = false;
        public static bool platformTags = false;
        public static bool modsTags = false;
        public static bool fpsTags = false;
        public static bool hzTags = false;
        public static bool lagTags = false;

        public static TextMesh GetTag(VRRig rig)
        {
            Transform existing = rig.headMesh.transform.Find("StupidNameTag");
            if (existing == null)
            {
                GameObject obj = new GameObject("StupidNameTag");
                obj.transform.SetParent(rig.headMesh.transform, false);
                obj.transform.localPosition = new Vector3(0, 0.45f, 0); // Трохи над головою

                TextMesh tm = obj.AddComponent<TextMesh>();
                tm.fontSize = 45;
                tm.characterSize = 0.012f;
                tm.anchor = TextAnchor.LowerCenter;
                tm.alignment = TextAlignment.Center;
                return tm;
            }
            return existing.GetComponent<TextMesh>();
        }

        // Очищення тексту перед кожним оновленням (щоб рядки не дублювалися)
        public static void ClearTag(VRRig rig)
        {
            Transform t = rig.headMesh.transform.Find("StupidNameTag");
            if (t != null) t.GetComponent<TextMesh>().text = "";
        }

        // 1. Name Nametag
        public static void NameNametag(VRRig rig)
        {
            GetTag(rig).text += rig.playerNameVisible + "\n";
        }

        // 2. ID Nametag (Master ID / PlayFab)
        public static void IDNametag(VRRig rig)
        {
            PhotonView view = rig.GetComponent<PhotonView>();
            string id = (view != null && view.Owner != null && !string.IsNullOrEmpty(view.Owner.UserId))
                ? view.Owner.UserId : "N/A";
            GetTag(rig).text += "ID: " + id + "\n";
        }

        // 3. Color Nametag (Format 0-9, 0-9, 0-9)
        public static void ColorNametag(VRRig rig)
        {
            Color c = rig.playerColor;
            string colorStr = $"{Mathf.RoundToInt(c.r * 9)}, {Mathf.RoundToInt(c.g * 9)}, {Mathf.RoundToInt(c.b * 9)}";
            GetTag(rig).text += "Color: " + colorStr + "\n";
        }

        // 4. Platform Nametag
        public static void PlatformNametag(VRRig rig)
        {
            PhotonView view = rig.GetComponent<PhotonView>();
            string plat = (view != null && view.Owner.CustomProperties.ContainsKey("platform"))
                ? view.Owner.CustomProperties["platform"].ToString() : "PC/Quest";
            GetTag(rig).text += "Platform: " + plat + "\n";
        }

        // 5. Mods Nametag (Mods: None якщо порожньо)
        public static void ModsNametag(VRRig rig)
        {
            PhotonView view = rig.GetComponent<PhotonView>();
            bool hasMods = view != null && (view.Owner.CustomProperties.ContainsKey("mods") || view.Owner.CustomProperties.ContainsKey("modded"));
            GetTag(rig).text += "Mods: " + (hasMods ? "Active" : "None") + "\n";
        }

        // 6. FPS Nametag
        public static void FPSNametag(VRRig rig)
        {
            PhotonView view = rig.GetComponent<PhotonView>();
            string fps = (view != null && view.Owner.CustomProperties.ContainsKey("fps"))
                ? view.Owner.CustomProperties["fps"].ToString() : "??";
            GetTag(rig).text += "FPS: " + fps + "\n";
        }

        // 7. HZ Nametag
        public static void HZNametag(VRRig rig)
        {
            PhotonView view = rig.GetComponent<PhotonView>();
            string hz = (view != null && view.Owner.CustomProperties.ContainsKey("hz"))
                ? view.Owner.CustomProperties["hz"].ToString() : "90";
            GetTag(rig).text += "HZ: " + hz + "\n";
        }

        // 8. Lag Nametag (Червоний статус, що зникає)
        public static void LagNametag(VRRig rig)
        {
            PhotonView view = rig.GetComponent<PhotonView>();
            if (view != null && (view.Owner.IsInactive || PhotonNetwork.GetPing() > 180))
            {
                GetTag(rig).text += "<color=red>Lagging</color>\n";
            }
        }

        // Фінальне оновлення: Billboarding та видалення порожніх тегів
        public static void UpdateNametag(VRRig rig)
        {
            Transform t = rig.headMesh.transform.Find("StupidNameTag");
            if (t != null)
            {
                TextMesh tm = t.GetComponent<TextMesh>();
                if (string.IsNullOrEmpty(tm.text))
                {
                    Destroy(t.gameObject); // Видаляємо об'єкт, якщо тексту немає
                }
                else if (Camera.main != null)
                {
                    // ПРАВИЛЬНИЙ BILLBOARDING:
                    // Текст завжди дивиться на камеру і не перевертається
                    t.LookAt(t.position + Camera.main.transform.rotation * Vector3.forward,
                             Camera.main.transform.rotation * Vector3.up);
                }
            }
        }
        // Цей метод об'єднує все і запускає процес для кожного гравця
        public static void RunNametags()
        {
            // Проходимо по всіх VRRig в грі
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                // Не чіпаємо офлайн-ріг (себе в меню) та перевіряємо наявність об'єкта
                if (vrrig != null && !vrrig.isOfflineVRRig)
                {
                    // 1. Очищуємо старий текст, щоб він не накопичувався
                    ClearTag(vrrig);

                    // 2. Додаємо рядки тільки якщо відповідна кнопка увімкнена
                    if (nameTags) NameNametag(vrrig);
                    if (idTags) IDNametag(vrrig);
                    if (colorTags) ColorNametag(vrrig);
                    if (platformTags) PlatformNametag(vrrig);
                    if (modsTags) ModsNametag(vrrig);
                    if (fpsTags) FPSNametag(vrrig);
                    if (hzTags) HZNametag(vrrig);
                    if (lagTags) LagNametag(vrrig);

                    // 3. Повертаємо до себе та видаляємо порожні теги
                    UpdateNametag(vrrig);
                }
            }
        }
    }
}
