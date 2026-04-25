using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using TMPro;

namespace StupidTemplate.Mods
{
    public class Nametags : MonoBehaviour
    {
        public static bool nameTags = true;
        public static bool idTags = false;

        // Store original values so we can restore them when disabling
        private static readonly Dictionary<TMP_Text, OriginalNametagData> originalData = new Dictionary<TMP_Text, OriginalNametagData>();

        private struct OriginalNametagData
        {
            public string text;
            public float fontSize;
            public Vector3 localPosition;
            public Vector3 localScale;
            public TextAlignmentOptions alignment;
        }

        private static void SaveOriginal(TMP_Text tmp)
        {
            if (!originalData.ContainsKey(tmp))
            {
                originalData[tmp] = new OriginalNametagData
                {
                    text = tmp.text,
                    fontSize = tmp.fontSize,
                    localPosition = tmp.transform.localPosition,
                    localScale = tmp.transform.localScale,
                    alignment = tmp.alignment
                };
            }
        }

        private static void RestoreOriginal(TMP_Text tmp)
        {
            if (originalData.TryGetValue(tmp, out var data))
            {
                tmp.fontSize = data.fontSize;
                tmp.transform.localPosition = data.localPosition;
                tmp.transform.localScale = data.localScale;
                tmp.alignment = data.alignment;
                originalData.Remove(tmp);
            }
        }

        public static void EnableNameTags()
        {
            nameTags = true;
        }

        public static void DisableNameTags()
        {
            nameTags = false;
            // If both are off, restore all nametags
            if (!nameTags && !idTags)
                RestoreAllNametags();
        }

        public static void EnableIdTags()
        {
            idTags = true;
        }

        public static void DisableIdTags()
        {
            idTags = false;
            // If both are off, restore all nametags
            if (!nameTags && !idTags)
                RestoreAllNametags();
        }

        private static void RestoreAllNametags()
        {
            if (GorillaParent.instance == null) return;
            if (VRRigCache.ActiveRigs == null) return;

            foreach (VRRig rig in VRRigCache.ActiveRigs)
            {
                if (rig == null || rig.isOfflineVRRig) continue;
                if (rig.playerText1 == null) continue;

                RestoreOriginal(rig.playerText1);
            }
        }

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

                // Save original data before modifying
                SaveOriginal(tmp);

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
                    uppix = $"<color=white><size=0.8>{rig.Creator.UserId}</size></color>\n";

                // Build text based on what's enabled
                if (nameTags)
                {
                    tmp.text = $"{uppix}{prefix} <color=#{nameColor}>{nick}</color> {suffix}";
                }
                else if (idTags)
                {
                    // Only ID tags, no name
                    tmp.text = $"<color=white><size=0.8>{rig.Creator?.UserId ?? "?"}</size></color>";
                }

                tmp.alignment = TextAlignmentOptions.Center;
                tmp.fontSize = 1.2f;
                tmp.transform.localScale = Vector3.one;
                tmp.transform.localPosition = new Vector3(0f, 0.8f, -0.02f);
            }
            catch { }
        }
    }
}