using static StupidTemplate.Menu.Main;

namespace StupidTemplate.Mods.Settings
{
    public class Nametags
    {
        public static int nametagsindex = 3;
        public static float nametagssize = 1.2f;

        public static void ChangeFlySpeed()
        {
            string[] nametagsNames = new string[] { "Extra Small", "Very Small", "Small", "Medium", "Large", "Very Large", "Extra Large" };
            float[] nametagsValues = new float[] { 0.5f, 0.8f, 1f, 1.2f, 1.7f, 2f, 2.6f };

            nametagsindex++;
            nametagsindex %= nametagsNames.Length;
            nametagssize = nametagsValues[nametagsindex];

            GetIndex("Change Name Nametags Size").overlapText = $"Change Name Nametags Size <color=gray>[</color><color=green>{nametagsNames[nametagsindex]}</color><color=gray>]</color>";
        }
    }
}