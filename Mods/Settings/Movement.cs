using static StupidTemplate.Menu.Main;

namespace StupidTemplate.Mods.Settings
{
    public class Movement
    {
        public static int flySpeedIndex = 3;
        public static float flySpeed = 15f;

        public static void ChangeFlySpeed()
        {
            string[] flyNames = new string[] { "Extra Slow", "Very Slow", "Slow", "Normal", "Fast", "Very Fast", "Extra Fast" };
            float[] flyValues = new float[] { 3f, 5f, 10f, 15f, 20f, 30f, 50f };

            flySpeedIndex++;
            flySpeedIndex %= flyNames.Length;

            GetIndex("Change Fly Speed").overlapText = $"Change Fly Speed <color=gray>[</color><color=green>{flyNames[flySpeedIndex]}</color><color=gray>]</color>";
        }

        public static int SpeedboostIndex = 3;
        public static float Speedboost = 9f;

        public static void ChangeSpeedboostSpeed()
        {
            string[] speedNames = new string[] { "Extra Slow", "Very Slow", "Slow", "Normal", "Fast", "Very Fast", "Extra Fast" };
            float[] speedValues = new float[] { 3f, 5f, 7f, 9f, 13f, 16f, 21f };

            SpeedboostIndex++;
            SpeedboostIndex %= speedNames.Length;

            GetIndex("Change Speedboost Speed").overlapText = $"Change Speedboost Speed <color=gray>[</color><color=green>{speedNames[SpeedboostIndex]}</color><color=gray>]</color>";
        }

        public static int WASDSpeedIndex = 3;
        public static float WASDSpeed = 15f;

        public static void ChangeWASDSpeed()
        {
            string[] WASDNames = new string[] { "Extra Slow", "Very Slow", "Slow", "Normal", "Fast", "Very Fast", "Extra Fast" };
            float[] WASDValues = new float[] { 3f, 5f, 10f, 15f, 20f, 30f, 50f };

            WASDSpeedIndex++;
            WASDSpeedIndex %= WASDNames.Length;

            GetIndex("Change WASD Fly Speed").overlapText = $"Change WASD Fly Speed <color=gray>[</color><color=green>{WASDNames[WASDSpeedIndex]}</color><color=gray>]</color>";
        }

        public static int CarMonkeSpeedIndex = 3;
        public static float CarMonkeSpeed = 15f;

        public static void ChangeCarMonkeSpeed()
        {
            string[] CarNames = new string[] { "Extra Slow", "Very Slow", "Slow", "Normal", "Fast", "Very Fast", "Extra Fast" };
            float[] CarValues = new float[] { 3f, 5f, 10f, 15f, 20f, 30f, 50f };

            CarMonkeSpeedIndex++;
            CarMonkeSpeedIndex %= CarNames.Length;

            GetIndex("Change Car Monke Speed").overlapText = $"Change Car Monke Speed <color=gray>[</color><color=green>{CarNames[CarMonkeSpeedIndex]}</color><color=gray>]</color>";
        }
    }
}
