namespace FFEC
{
    internal static class Storage
    {
        private static JObject controlsData = Json.ReadControls();
        public static Dictionary<String, Dictionary<String, String>> Controls 
        { 
            get => controlsData.ToObject<Dictionary<String, Dictionary<String, String>>>();
        }
        public static String GetControlText(String sector, String name) => controlsData.SelectToken($"$.{sector}.{name}").ToString();

        private static JObject configurationsData = Json.ReadConfigurations();
        public static JObject Configurations 
        { 
            get => configurationsData;
            set => Json.WriteConfigurations(value);
        }
        
        private static JObject configData = Json.ReadConfig();
        public static JObject Config
        { 
            get => configData;
            set => Json.WriteConfig(value);
        }
    }
}
