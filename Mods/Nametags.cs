using System.Text.RegularExpressions;
using UnityEngine;
using TMPro;

namespace StupidTemplate.Mods
{
    public class Nametags : MonoBehaviour
    {
        public static bool nameTags = true;
        public static bool idTags = false;

        public static void RunNametags()
        {
            if (Time.frameCount % 300 == 0)
            {
                int rigsCount = VRRigCache.ActiveRigs?.Count ?? -1;
                Debug.Log($"[NT] enabled={nameTags} parentNull={GorillaParent.instance == null} rigs={rigsCount}");
            }

            if (!nameTags) return;
            if (GorillaParent.instance == null) return;
            if (VRRigCache.ActiveRigs == null) return;

            foreach (VRRig rig in VRRigCache.ActiveRigs)
            {
                if (rig == null || rig.isOfflineVRRig) continue;

                if (rig.playerText1 == null)
                {
                    if (Time.frameCount % 300 == 0)
                        Debug.Log($"[NT] {rig.name}: playerText1 NULL");
                    continue;
                }

                UpdateNameOnly(rig);
            }
        }

        public static void UpdateNameOnly(VRRig rig)
        {
            try
            {
                TMP_Text tmp = rig.playerText1;
                if (tmp == null) return;

                if (!nameTags && !idTags)
                {
                    tmp.text = "";
                    tmp.transform.localPosition = new Vector3(0f, 0f, 0f); // постав свої координати
                    return;
                }

                string nameColor =
                    rig.mainSkin != null &&
                    rig.mainSkin.material != null &&
                    rig.mainSkin.material.name.Contains("fected")
                        ? "FF8000"
                        : ColorUtility.ToHtmlStringRGB(rig.playerColor);

                if (nameColor == "000000")
                    nameColor = "FFFFFF";

                string nick = (rig.Creator != null && !string.IsNullOrEmpty(rig.Creator.NickName))
                    ? rig.Creator.NickName
                    : "PLAYER";
                nick = Regex.Replace(nick, "<.*?>", string.Empty);

                string prefix = "";
                string suffix = "";
                string uppix = "";

                if (rig.Creator != null)
                {
                    if (rig.Creator.UserId == "ID")
                    {
                        prefix = "<color=gold>[OWNER]</color>";
                    }
                    /*if (rig.Creator.UserId == "ID")
                    {
                    prefix/suffix = "";
                    }*/
                }


                if (idTags && rig.Creator != null)
                    uppix = $"<color=grey><size=0.8>{rig.Creator.UserId}</size></color>\n";

                tmp.text = $"{uppix}{prefix}<color=#{nameColor}>{nick}</color>{suffix}";
                tmp.alignment = TextAlignmentOptions.Center;
                tmp.fontSize = 1.2f;
                tmp.transform.localScale = Vector3.one;
                tmp.transform.localPosition = new Vector3(0f, 0.8f, -0.02f);
            }
            catch { }
        }
    }
}