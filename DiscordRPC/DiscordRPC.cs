/*using Photon.Pun;
using UnityEngine;

namespace StupidTemplate
{
    public class DiscordRPCManager : MonoBehaviour
    {
        public static object client;

        public static void HandleRPC(bool enable)
        {
            try
            {
                if (enable) Init();
                else Terminate();
            }
            catch { }
        }

        public static void Init()
        {
            if (client != null) return;
            try
            {
                var rpc = new DiscordRPC.DiscordRpcClient("1474834964422987938", autoEvents: true);

                // Використовуємо подію OnReady, щоб відправити статус ТІЛЬКИ коли Discord дозволить
                rpc.OnReady += (sender, e) => {
                    UpdatePresence();
                };

                rpc.Initialize();
                client = rpc;
            }
            catch { }
        }


        public static void Terminate()
        {
            if (client is DiscordRPC.DiscordRpcClient rpc)
            {
                try
                {
                    rpc.ClearPresence();
                    rpc.Dispose();
                    client = null;
                }
                catch { }
            }
        }

        public static void UpdatePresence()
        {
            if (client is DiscordRPC.DiscordRpcClient rpc)
            {
                try
                {
                    string roomCode = PhotonNetwork.InRoom ? PhotonNetwork.CurrentRoom.Name : "Not in Room";

                    var presence = new DiscordRPC.RichPresence()
                    {
                        Details = "UA Mod Menu (Gorilla Tag)",
                        State = "Version: " + PluginInfo.Version + " | Room: " + roomCode,
                        Assets = new DiscordRPC.Assets()
                        {
                            LargeImageKey = "rpcimg",
                            LargeImageText = "UA Mod Menu"
                        },
                        Timestamps = DiscordRPC.Timestamps.Now
                    };
                    rpc.SetPresence(presence);
                }
                catch { }
            }
        }

        public static void RunCallbacks()
        {
            if (client is DiscordRPC.DiscordRpcClient rpc)
            {
                try { rpc.Invoke(); } catch { }
            }
        }
    }
}
*/