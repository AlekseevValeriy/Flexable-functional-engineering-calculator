namespace FFEC
{
    internal static class JsonStorage
    {
        public static String GetControlText(String sector, String name) => controlsData[sector][name].Value<String>();
        public static Dictionary<String, Dictionary<String, String>> Controls => controlsData.ToObject<Dictionary<String, Dictionary<String, String>>>();
        private static JObject controlsData = JsonStreamer.ReadControls();


        public static JObject Configurations { get => configurationsData; set => JsonStreamer.WriteConfigurations(value); }
        private static JObject configurationsData = JsonStreamer.ReadConfigurations();


        public static JObject Config { get => configData; set => JsonStreamer.WriteConfigurations(value); }
        private static JObject configData = JsonStreamer.ReadConfig();


        public static String GetTranslate(String text) => translateData[text].Value<String>() ?? text;
        private static JObject translateData = JsonStreamer.ReadTranslate();

        public static JObject Egg { get; } = JsonStreamer.ReadEgg();
    }

    internal static class ContextMenuStorage
    {
        public static ContextMenu GetContextMenu(String name)
        {
            try { return contextMenuDictionary[name]; }
            catch (KeyNotFoundException exception) { Messages.RaiseKeyNotFoundExceptionMessage(exception.Message, typeof(ContextMenu)); }
            return new ContextMenu();

        }
        private static Dictionary<String, ContextMenu> contextMenuDictionary = new Dictionary<String, ContextMenu>();

        static ContextMenuStorage()
        {
            contextMenuDictionary["propertyContextMenu"] = Handler.NewTableSizePropertyMenu();
            contextMenuDictionary["propertyContextMenuForDisplayPanel"] = Handler.NewPropertyMenuForDisplayPanel();
            contextMenuDictionary["buttonPropertyContextMenu"] = Handler.NewButtonPropertyMenu();
            contextMenuDictionary["textBoxPropertyContextMenu"] = Handler.NewTextBoxPropertyMenu();
        }
    }

    internal static class EventStorage
    {
        public static EventHandler GetEvent(String name)
        {
            try { return eventDictionary[name]; }
            catch (KeyNotFoundException exception) { Messages.RaiseKeyNotFoundExceptionMessage(exception.Message, typeof(EventHandler)); }
            catch (ArgumentNullException exception) { Messages.RaiseArgumentNullExceptionMessage(exception.Message); }
            return new EventHandler((Object sender, EventArgs e) => { });

        }
        public static void SetEvent(String name, EventHandler eve)
        {
            try { eventDictionary[name] = eve; }
            catch(ArgumentNullException exception) { Messages.RaiseArgumentNullExceptionMessage(exception.Message); }
        }
        private static Dictionary<String, EventHandler> eventDictionary = new Dictionary<String, EventHandler>();
    }
}
