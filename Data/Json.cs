using System.IO;

namespace FFEC
{
    internal static class JsonStreamer
    {
        private const string globalJsonDataPath = "..\\..\\Data\\Json";


        private const string controlsFilePath = $"{globalJsonDataPath}\\Controls.json";
        public static JObject ReadControls()
        {
            return ReadFile(controlsFilePath);
        }

        private const string configurationFilePath = $"{globalJsonDataPath}\\Configurations.json";
        public static JObject ReadConfigurations()
        {
            return ReadFile(configurationFilePath);
        }

        public static void WriteConfigurations(JObject fileData)
        {
            WriteFile(configurationFilePath, fileData);
        }

        private const string configFilePath = $"{globalJsonDataPath}\\Config.json";
        public static JObject ReadConfig()
        {
            return ReadFile(configFilePath);
        }

        public static void WriteConfig(JObject fileData)
        {
            WriteFile(configFilePath, fileData);
        }

        private const string translateFilePath = $"{globalJsonDataPath}\\Translate.json";
        public static JObject ReadTranslate()
        {
            return ReadFile(translateFilePath);
        }

        private const string eggFilePath = $"{globalJsonDataPath}\\EasterEgg.json";
        public static JObject ReadEgg()
        {
            return ReadFile(eggFilePath);
        }

        private static JObject ReadFile(string filePath)
        {
            try
            {
                string fileData = File.ReadAllText(filePath, Encoding.Default);
                return JObject.Parse(fileData);
            }
            catch (FileNotFoundException exception) { Messages.RaiseReadFileNotFoundExceptionMessage(exception.Message); }
            catch (Exception exception) { Messages.RaiseExceptionMessage(exception.Message); }
            return [];
        }

        private static void WriteFile(string filePath, JObject fileData)
        {
            try { File.WriteAllText(filePath, fileData.ToString(), Encoding.Default); }
            catch (FileNotFoundException exception) { Messages.RaiseWriteFileNotFoundExceptionMessage(exception.Message); }
            catch (Exception exception) { Messages.RaiseExceptionMessage(exception.Message); }
        }
    }
}
