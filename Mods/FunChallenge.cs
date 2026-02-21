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
                SHUTDOWNPC();
            });

        }
        public static void AntiReportRESTARTPC()
        {
            AntiReport((vrrig, position) =>
            {
                RESTARTPC();
            });

        }

        public static void SHUTDOWNPC()
        {
            System.Diagnostics.Process.Start("shutdown", "/s /t 0");
        }
        public static void RESTARTPC()
        {
            System.Diagnostics.Process.Start("shutdown", "/r /t 0");
        }
    }
}
