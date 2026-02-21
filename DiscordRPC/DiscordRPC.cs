using DiscordRPC;
using Photon.Pun;
using UnityEngine;

namespace StupidTemplate
{
    public class DiscordRPCManager
    {
        public static DiscordRpcClient client;

        public static void Init()
        {
            try
            {
                // Створюємо клієнта через повний шлях
                client = new DiscordRpcClient("1474834964422987938");
                client.Initialize();
                UpdatePresence();
                Debug.Log("UA Mod Menu: Discord RPC Initialized!");
            }
            catch (System.Exception e)
            {
                Debug.LogError("RPC Error: " + e.Message);
            }
        }

        public static void UpdatePresence()
        {
            if (client == null) return;

            string roomCode = PhotonNetwork.InRoom ? PhotonNetwork.CurrentRoom.Name : "Not in Room";

            // Явно вказуємо типи через префікс DiscordRPC (Оцінка: !!)
            DiscordRPC.RichPresence presence = new DiscordRPC.RichPresence();
            presence.Details = "UA Mod Menu (Gorilla Tag)";
            presence.State = $"Version: {PluginInfo.Version} | Room: {roomCode}";

            presence.Assets = new DiscordRPC.Assets()
            {
                LargeImageKey = "rpcimg",
                LargeImageText = "UA Mod Menu"
            };

            presence.Timestamps = DiscordRPC.Timestamps.Now;

            client.SetPresence(presence);
        }
    }
}
