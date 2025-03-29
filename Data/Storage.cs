namespace FFEC
{
    internal static class JsonStorage
    {
        public static string GetControlText(string sector, string name)
        {
            return controlsData[sector][name].Value<string>();
        }

        public static Dictionary<string, Dictionary<string, string>> Controls => controlsData.ToObject<Dictionary<string, Dictionary<string, string>>>();
        private static readonly JObject controlsData = JsonStreamer.ReadControls();


        public static JObject Configurations { get => configurationsData; set => JsonStreamer.WriteConfigurations(value); }
        private static readonly JObject configurationsData = JsonStreamer.ReadConfigurations();


        public static JObject Config { get => configData; set => JsonStreamer.WriteConfigurations(value); }
        private static readonly JObject configData = JsonStreamer.ReadConfig();


        public static string GetTranslate(string text)
        {
            return translateData[text] is not null ? translateData[text].Value<string>() : text;
        }

        private static readonly JObject translateData = JsonStreamer.ReadTranslate();

        public static JObject Egg { get; } = JsonStreamer.ReadEgg();
    }

    internal static class ContextMenuStorage
    {
        public static ContextMenu GetContextMenu(string name)
        {
            try { return contextMenuDictionary[name]; }
            catch (KeyNotFoundException exception) { Messages.RaiseKeyNotFoundExceptionMessage(exception.Message, typeof(ContextMenu)); }
            return new ContextMenu();

        }
        private static readonly Dictionary<string, ContextMenu> contextMenuDictionary = [];

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
        public static EventHandler GetEvent(string name)
        {
            try { return eventDictionary[name]; }
            catch (KeyNotFoundException exception) { Messages.RaiseKeyNotFoundExceptionMessage(exception.Message, typeof(EventHandler)); }
            catch (ArgumentNullException exception) { Messages.RaiseArgumentNullExceptionMessage(exception.Message); }
            return new EventHandler((object sender, EventArgs e) => { });

        }
        public static void SetEvent(string name, EventHandler eve)
        {
            try { eventDictionary[name] = eve; }
            catch (ArgumentNullException exception) { Messages.RaiseArgumentNullExceptionMessage(exception.Message); }
        }
        private static readonly Dictionary<string, EventHandler> eventDictionary = [];
    }
}
