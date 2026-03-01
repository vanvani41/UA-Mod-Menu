using GorillaNetworking;

namespace StupidTemplate.Mods
{
    public class Room
    {
        public static void Disconnect()
        {
            NetworkSystem.Instance.ReturnToSinglePlayer();
        }
        public static void JoinRoomUkraine()
        {
            PhotonNetworkController.Instance.AttemptToJoinSpecificRoom("UKRAINE", JoinType.Solo);
        }
        public static void JoinRoomUkraine1()
        {
            PhotonNetworkController.Instance.AttemptToJoinSpecificRoom("UKRAINE1", JoinType.Solo);
        }
        public static void JoinRoomUkraine2()
        {
            PhotonNetworkController.Instance.AttemptToJoinSpecificRoom("UKRAINE2", JoinType.Solo);
        }
        public static void JoinRoomUkraine3()
        {
            PhotonNetworkController.Instance.AttemptToJoinSpecificRoom("UKRAINE3", JoinType.Solo);
        }
        public static void JoinRoomUkraine4()
        {
            PhotonNetworkController.Instance.AttemptToJoinSpecificRoom("UKRAINE4", JoinType.Solo);
        }
        public static void JoinRoomUkraine5()
        {
            PhotonNetworkController.Instance.AttemptToJoinSpecificRoom("UKRAINE5", JoinType.Solo);
        }
        public static void JoinRoomVanvani41()
        {
            PhotonNetworkController.Instance.AttemptToJoinSpecificRoom("VANVANI41", JoinType.Solo);
        }
        public static void JoinRoomV41Fan()
        {
            PhotonNetworkController.Instance.AttemptToJoinSpecificRoom("V41FAN", JoinType.Solo);
        }
        public static void JoinRoomPBBV()
        {
            PhotonNetworkController.Instance.AttemptToJoinSpecificRoom("PBBV", JoinType.Solo);
        }
        public static void JoinRoomDAISY09()
        {
            PhotonNetworkController.Instance.AttemptToJoinSpecificRoom("DAISY09", JoinType.Solo);
        }
        public static void JoinRoomECHO()
        {
            PhotonNetworkController.Instance.AttemptToJoinSpecificRoom("ECHO", JoinType.Solo);
        }
    }
}
