using System.IO;

namespace FFEC
{
    internal static class JsonStreamer
    {
        private const String globalJsonDataPath = "..\\..\\Data\\Json";


        private const String controlsFilePath = $"{globalJsonDataPath}\\Controls.json";
        public static JObject ReadControls() => ReadFile(controlsFilePath);


        private const String configurationFilePath = $"{globalJsonDataPath}\\Configurations.json";
        public static JObject ReadConfigurations() => ReadFile(configurationFilePath);
        public static void WriteConfigurations(JObject fileData) => WriteFile(configurationFilePath, fileData);


        private const String configFilePath = $"{globalJsonDataPath}\\Config.json";
        public static JObject ReadConfig() => ReadFile(configFilePath);
        public static void WriteConfig(JObject fileData) => WriteFile(configFilePath, fileData);


        private const String translateFilePath = $"{globalJsonDataPath}\\Translate.json";
        public static JObject ReadTranslate() => ReadFile(translateFilePath);


        private const String eggFilePath = $"{globalJsonDataPath}\\EasterEgg.json";
        public static JObject ReadEgg() => ReadFile(eggFilePath);


        private static JObject ReadFile(String filePath)
        {
            String fileData = default(String);
            try
            {
                fileData = File.ReadAllText(filePath, Encoding.Default);
                return JObject.Parse(fileData);
            }
            catch (FileNotFoundException exception) { Messages.RaiseReadFileNotFoundExceptionMessage(exception.Message); }
            catch (Exception exception) { Messages.RaiseExceptionMessage(exception.Message); }
            return new JObject();
        }
        private static void WriteFile(String filePath, JObject fileData)
        {
            try { File.WriteAllText(filePath, fileData.ToString(), Encoding.Default); }
            catch (FileNotFoundException exception) { Messages.RaiseWriteFileNotFoundExceptionMessage(exception.Message); }
            catch (Exception exception) { Messages.RaiseExceptionMessage(exception.Message); }
        }
    }
}
