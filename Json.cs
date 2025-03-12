using System.IO;

namespace FFEC
{
    internal static class Json
    {
        private const String controlsFilePath = "..\\..\\JsonData\\Controls.json";
        private const String configurationFilePath = "..\\..\\JsonData\\Configurations.json";
        private const String configFilePath = "..\\..\\JsonData\\Config.json";

        public static JObject ReadControls() => ReadFile(controlsFilePath);
        public static JObject ReadConfigurations() => ReadFile(configurationFilePath);
        public static void WriteConfigurations(JObject fileData) => WriteFile(configurationFilePath, fileData);
        public static JObject ReadConfig() => ReadFile(configFilePath);
        public static void WriteConfig(JObject fileData) => WriteFile(configFilePath, fileData);

        private static JObject ReadFile(String filePath)
        {
            String fileData;
            try { fileData = File.ReadAllText(filePath); } // with Encoding.UNICODE get exception -\/('_')\/-
            catch (Exception exception) { fileData = ""; SendMessage(exception.ToString());}
            return JObject.Parse(fileData);
        }
        private static void WriteFile(String filePath, JObject fileData)
        {
            try { File.WriteAllText(filePath, fileData.ToString()); }
            catch (Exception exception) { SendMessage(exception.ToString()); }
        }

        private static void ViewCurrentPath() => MessageBox.Show($"{System.IO.Path.GetDirectoryName(Application.ExecutablePath)}");

        public static event InteractWithUI SendMessage;
        public delegate void InteractWithUI(String data);
    }
}
