using System.Text.RegularExpressions;
using UnityEngine;
using TMPro;

namespace StupidTemplate.Mods
{
    public class Nametags : MonoBehaviour
    {
        public static bool nameTags = true;

        public static void RunNametags()
        {
            if (!nameTags) return;
            if (GorillaParent.instance == null) return;

            foreach (VRRig rig in GorillaParent.instance.vrrigs)
            {
                if (rig == null || rig.isOfflineVRRig) continue;
                UpdateNameOnly(rig);
            }
        }

        private static void UpdateNameOnly(VRRig rig)
        {
            try
            {
                TMP_Text tmp = rig.playerText1;
                if (tmp == null) return;

                string nameColor =
                    rig.mainSkin != null &&
                    rig.mainSkin.material != null &&
                    rig.mainSkin.material.name.Contains("fected")
                        ? "FF8000"
                        : ColorUtility.ToHtmlStringRGB(rig.playerColor);

                string nick = (rig.Creator != null && !string.IsNullOrEmpty(rig.Creator.NickName))
                    ? rig.Creator.NickName
                    : "PLAYER";
                nick = Regex.Replace(nick, "<.*?>", string.Empty);

                tmp.text = $"<color=#{nameColor}>{nick}</color>";

                tmp.alignment = TextAlignmentOptions.Center;
                tmp.fontStyle = FontStyles.Italic;

                tmp.transform.localScale = Vector3.one * 1.05f;
            }
            catch { }
        }
    }
}