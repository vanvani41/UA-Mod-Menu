using HarmonyLib;
using Photon.Pun;
using PlayFab;
using PlayFab.ClientModels;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

namespace StupidTemplate.Mods
{
    public class Nametags : MonoBehaviour
    {
        public static bool nameTags, idTags, colorTags, platformTags, modsTags, fpsTags, infoTags, hzTags;

        private static Dictionary<string, string> datePool = new Dictionary<string, string>();

        public static void RunNametags()
        {
            if (GorillaParent.instance == null) return;

            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (vrrig != null && !vrrig.isOfflineVRRig)
                {
                    UpdateStupidTag(vrrig);
                }
            }
        }

        private static void UpdateStupidTag(VRRig rig)
        {
            try
            {
                List<string> lines = new List<string>();

                // 1. Нікнейм (Логіка з NameTags)
                string nameColor = rig.mainSkin.material.name.Contains("fected") ? "FF8000" : ColorUtility.ToHtmlStringRGB(rig.playerColor);
                if (nameTags) lines.Add($"<color=#{nameColor}>{rig.Creator.NickName}</color>");

                // 2. ID Гравця
                if (idTags) lines.Add($"ID: {rig.Creator.UserId}");

                // 3. Платформа
                if (platformTags)
                {
                    string p = rig.rawCosmeticString.Contains("S. FIRST LOGIN") ? "STEAM" :
                              (rig.rawCosmeticString.Contains("FIRST LOGIN") ? "PC" : "QUEST");
                    lines.Add($"PLATFORM: {p}");
                }

                // 4. Дата реєстрації (PlayFab)
                if (infoTags) lines.Add(GetCreationDate(rig));

                // 5. FPS (Traverse)
                if (fpsTags)
                {
                    var fpsField = Traverse.Create(rig).Field("fps");
                    if (fpsField.FieldExists())
                    {
                        lines.Add($"FPS: {fpsField.GetValue()}");
                    }
                }

                // 6. HZ (Traverse) - ПЕРЕНЕСЕНО СЮДИ
                if (hzTags)
                {
                    var hzField = Traverse.Create(rig).Field("hz");
                    if (hzField.FieldExists())
                    {
                        lines.Add($"HZ: {hzField.GetValue()}");
                    }
                }

                // 7. МОДИ (Аналіз CustomProperties)
                if (modsTags)
                {
                    string foundMods = CheckForMods(rig);
                    if (!string.IsNullOrEmpty(foundMods)) lines.Add($"MODS: {foundMods}");
                }

                // Записуємо все в текст над головою
                rig.playerText1.text = string.Join("\n", lines);

                // Оптимальний розмір для читання
                rig.playerText1.transform.localScale = new Vector3(2f, 2f, 2f);
            }
            catch { }
        }

        private static string GetCreationDate(VRRig rig)
        {
            string id = rig.Creator.UserId;
            if (datePool.ContainsKey(id)) return datePool[id];

            datePool[id] = "LOADING...";
            PlayFabClientAPI.GetAccountInfo(new GetAccountInfoRequest { PlayFabId = id }, result => {
                datePool[id] = result.AccountInfo.Created.ToString("MMM dd, yyyy").ToUpper();
            }, error => datePool[id] = "HIDDEN");

            return datePool[id];
        }

        private static string CheckForMods(VRRig rig)
        {
            string mods = "";
            var props = rig.Creator.GetPlayerRef().CustomProperties;

            // Можна додати всі моди з твого довгого списку сюди
            Dictionary<string, string[]> specialModsList = new Dictionary<string, string[]> {
                { "genesis", new string[] { "GENESIS", "07019C" } },
                { "HP_Left", new string[] { "HOLDABLEPAD", "332316" } },
                { "GrateVersion", new string[] { "GRATE", "707070" } },
                { "void", new string[] { "VOID", "FFFFFF" } },
                { "BANANAOS", new string[] { "BANANAOS", "FFFF00" } },
                { "GC", new string[] { "GORILLACRAFT", "43B581" } },
                { "CarName", new string[] { "GORILLAVEHICLES", "43B581" } },
                { "6p72ly3j85pau2g9mda6ib8px", new string[] { "CCMV2", "BF00FC" } },
                { "FPS-Nametags for Zlothy", new string[] { "FPSTAGS", "B103FC" } },
                { "cronos", new string[] { "CRONOS", "0000FF" } },
                { "ORBIT", new string[] { "ORBIT", "FFFFFF" } },
                { "Violet On Top", new string[] { "VIOLET", "DF6BFF" } },
                { "MP25", new string[] { "MONKEPHONE", "707070" } },
                { "GorillaWatch", new string[] { "GORILLAWATCH", "707070" } },
                { "InfoWatch", new string[] { "GORILLAINFOWATCH", "707070" } },
                { "BananaPhone", new string[] { "BANANAPHONE", "FFFC45" } },
                { "Vivid", new string[] { "VIVID", "F000BC" } },
                { "RGBA", new string[] { "CUSTOMCOSMETICS", "FF0000" } },
                { "cheese is gouda", new string[] { "WHOSICHEATING", "707070" } },
                { "shirtversion", new string[] { "GORILLASHIRTS", "707070" } },
                { "gpronouns", new string[] { "GORILLAPRONOUNS", "707070" } },
                { "gfaces", new string[] { "GORILLAFACES", "707070" } },
                { "monkephone", new string[] { "MONKEPHONE", "707070" } },
                { "pmversion", new string[] { "PLAYERMODELS", "707070" } },
                { "gtrials", new string[] { "GORILLATRIALS", "707070" } },
                { "msp", new string[] { "MONKESMARTPHONE", "707070" } },
                { "gorillastats", new string[] { "GORILLASTATS", "707070" } },
                { "using gorilladrift", new string[] { "GORILLADRIFT", "707070" } },
                { "monkehavocversion", new string[] { "MONKEHAVOC", "707070" } },
                { "tictactoe", new string[] { "TICTACTOE", "a89232" } },
                { "ccolor", new string[] { "INDEX", "0febff" } },
                { "imposter", new string[] { "GORILLAAMONGUS", "ff0000" } },
                { "spectapeversion", new string[] { "SPECTAPE", "707070" } },
                { "cats", new string[] { "CATS", "707070" } },
                { "made by biotest05 :3", new string[] { "DOGS", "707070" } },
                { "fys cool magic mod", new string[] { "FYSMAGICMOD", "707070" } },
                { "colour", new string[] { "CUSTOMCOSMETICS", "707070" } },
                { "chainedtogether", new string[] { "CHAINED TOGETHER", "707070" } },
                { "goofywalkversion", new string[] { "GOOFYWALK", "707070" } },
                { "void_menu_open", new string[] { "VOID", "303030" } },
                { "violetpaiduser", new string[] { "VIOLETPAID", "DF6BFF" } },
                { "violetfree", new string[] { "VIOLETFREE", "DF6BFF" } },
                { "obsidianmc", new string[] { "OBSIDIAN.LOL", "303030" } },
                { "dark", new string[] { "SHIBAGT DARK", "303030" } },
                { "hidden menu", new string[] { "HIDDEN", "707070" } },
                { "oblivionuser", new string[] { "OBLIVION", "5055d3" } },
                { "hgrehngio889584739_hugb\n", new string[] { "RESURGENCE", "470050" } },
                { "eyerock reborn", new string[] { "EYEROCK", "707070" } },
                { "asteroidlite", new string[] { "ASTEROID LITE", "707070" } },
                { "Explicit", new string[] { "EXPLICIT", "707070" } },
                { "cokecosmetics", new string[] { "COKE COSMETX", "00ff00" } },
                { "GFaces", new string[] { "gFACES", "707070" } },
                { "github.com/maroon-shadow/SimpleBoards", new string[] { "SIMPLEBOARDS", "707070" } },
                { "ObsidianMC", new string[] { "OBSIDIAN", "DC143C" } },
                { "hgrehngio889584739_hugb", new string[] { "RESURGENCE", "707070" } },
                { "GTrials", new string[] { "gTRIALS", "707070" } },
                { "github.com/ZlothY29IQ/GorillaMediaDisplay", new string[] { "GMD", "B103FC" } },
                { "github.com/ZlothY29IQ/TooMuchInfo", new string[] { "TOOMUCHINFO", "B103FC" } },
                { "github.com/ZlothY29IQ/RoomUtils-IW", new string[] { "ROOMUTILS-IW", "B103FC" } },
                { "github.com/ZlothY29IQ/MonkeClick", new string[] { "MONKECLICK", "B103FC" } },
                { "github.com/ZlothY29IQ/MonkeClick-CI", new string[] { "MONKECLICK-CI", "B103FC" } },
                { "github.com/ZlothY29IQ/MonkeRealism", new string[] { "MONKEREALISM", "B103FC" } },
                { "MediaPad", new string[] { "MEDIAPAD", "B103FC" } },
                { "GorillaCinema", new string[] { "gCINEMA", "B103FC" } },
                { "ChainedTogetherActive", new string[] { "CHAINEDTOGETHER", "B103FC" } },
                { "GPronouns", new string[] { "gPRONOUNS", "707070" } },
                { "CSVersion", new string[] { "CustomSkin", "707070" } },
                { "github.com/ZlothY29IQ/Zloth-RecRoomRig", new string[] { "ZLOTH-RRR", "B103FC" } },
                { "ShirtProperties", new string[] { "SHIRTS-OLD", "707070" } },
                { "GorillaShirts", new string[] { "SHIRTS", "707070" } },
                { "GS", new string[] { "OLD SHIRTS", "707070" } },
                { "6XpyykmrCthKhFeUfkYGxv7xnXpoe2", new string[] { "CCMV2", "DC143C" } },
                { "Body Tracking", new string[] { "BODYTRACK-OLD", "7AA11F" } },
                { "Body Estimation", new string[] { "HANBodyEst", "7AA11F" } },
                { "Gorilla Track", new string[] { "BODYTRACK", "7AA11F" } },
                { "CustomMaterial", new string[] { "CUSTOMCOSMETICS", "707070" } },
                { "I like cheese", new string[] { "RECROOMRIG", "FE8232" } },
                { "silliness", new string[] { "SILLINESS", "FFBAFF" } },
                { "emotewheel", new string[] { "EMOTEWHEEL", "1E2030" } },
                { "untitled", new string[] { "UNTITLED", "2D73AF" } },
                { "gorillaware", new string[] {"GORILLAWARE", "0F20A30" } },
                { "uamodmenu", new string[] {"UA MOD MENU", "FFFF00" } },
                { "stupidmenu", new string[] {"Stupid", "A35B0D" } }
            };

            return mods;
        }
    }
}
