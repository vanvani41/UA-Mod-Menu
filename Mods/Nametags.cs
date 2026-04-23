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
            if (!nameTags && !idTags) return;
            if (GorillaParent.instance == null) return;
            if (VRRigCache.ActiveRigs == null) return;

            foreach (VRRig rig in VRRigCache.ActiveRigs)
            {
                if (rig == null || rig.isOfflineVRRig) continue;
                if (rig.playerText1 == null) continue;

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
                    if (rig.Creator.UserId == "C686727BCD7F2D8E")
                    {
                        prefix = "<color=yellow>[OWNER] (Steam)</color>";
                    }
                    if (rig.Creator.UserId == "8F406DB4A6CC20B0")
                    {
                        prefix = "<color=yellow>[OWNER] (Quest)</color>";
                    }
                    /*if (rig.Creator.UserId == "ID")
                    {
                    prefix/suffix = "";
                    }*/
                }


                if (idTags && rig.Creator != null)
                    uppix = $"<color=grey><size=0.8>{rig.Creator.UserId}</size></color>\n";

                tmp.text = $"{uppix}{prefix} <color=#{nameColor}>{nick}</color> {suffix}";
                tmp.alignment = TextAlignmentOptions.Center;
                tmp.fontSize = 1.2f;
                tmp.transform.localScale = Vector3.one;
                tmp.transform.localPosition = new Vector3(0f, 0.8f, -0.02f);
            }
            catch { }
        }
    }
}