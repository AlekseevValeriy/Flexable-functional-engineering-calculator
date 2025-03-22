namespace FFEC
{
    internal static class JsonDataStorage
    {
        public static JObject Egg { get; } = JsonStreamer.ReadEgg();

        private static JObject controlsData = JsonStreamer.ReadControls();
        public static Dictionary<String, Dictionary<String, String>> Controls
        {
            get => controlsData.ToObject<Dictionary<String, Dictionary<String, String>>>();
        }
        public static String GetControlText(String sector, String name) => controlsData.SelectToken($"$.{sector}.{name}").ToString();

        private static JObject configurationsData = JsonStreamer.ReadConfigurations();
        public static JObject Configurations
        {
            get => configurationsData;
            set => JsonStreamer.WriteConfigurations(value);
        }

        private static JObject configData = JsonStreamer.ReadConfig();
        public static JObject Config
        {
            get => configData;
            set => JsonStreamer.WriteConfig(value);
        }
        private static JObject translateData = JsonStreamer.ReadTranslate();
        public static String GetTranslate(String text)
        {
            return translateData.SelectToken($"$.{text}").ToObject<String?>() ?? text;
        }
    }

    internal static class ContextMenuStorage
    {
        public static Dictionary<String, ContextMenu> contextDictionary = new Dictionary<String, ContextMenu>();

        static ContextMenuStorage()
        {
            contextDictionary["propertyContextMenu"] = Handler.NewTableSizePropertyMenu();
            contextDictionary["propertyContextMenuForDisplayPanel"] = Handler.NewPropertyMenuForDisplayPanel();
            contextDictionary["buttonPropertyContextMenu"] = Handler.NewButtonPropertyMenu();
            contextDictionary["textBoxPropertyContextMenu"] = Handler.NewTextBoxPropertyMenu();
        }
    }

    internal static class EventStorage
    {
        public static Dictionary<String, EventHandler> eventDictionary = new Dictionary<String, EventHandler>();
    }
}
