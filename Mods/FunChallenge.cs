using static StupidTemplate.Mods.Safety;

namespace StupidTemplate.Mods
{
    internal class FunChallenge
    {
        public static void AntiReportCloseGorillaTag()
        {
            AntiReport((vrrig, position) =>
            {
                CloseGorillaTag();
            });
        }
        public static void AntiReportRestartGorillaTag()
        {
            AntiReport((vrrig, position) =>
            {
                RestartGorillaTag();
            });
        }
        public static void AntiReportSHUTDOWNPC()
        {
            AntiReport((vrrig, position) =>
            {
                ShutdownPC();
            });

        }
        public static void AntiReportRESTARTPC()
        {
            AntiReport((vrrig, position) =>
            {
                RestartPC();
            });

        }
    }
}
