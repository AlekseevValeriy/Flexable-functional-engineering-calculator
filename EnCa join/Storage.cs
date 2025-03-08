namespace FFEC
{
    internal static class Storage
    {
        private static Dictionary<String, Dictionary<String, String>> controlsData = Json.ReadControls();

        public static String GetButtonText(String sector, String name) => controlsData[sector][name];
        public static Dictionary<String, Dictionary<String, String>> GetControlsData() => controlsData;
    }
}
