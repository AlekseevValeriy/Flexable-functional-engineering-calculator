using System.IO;

namespace FFEC
{
    internal static class JsonStreamer
    {
        private const String controlsFilePath = "..\\..\\JsonData\\Controls.json";
        private const String configurationFilePath = "..\\..\\JsonData\\Configurations.json";
        private const String configFilePath = "..\\..\\JsonData\\Config.json";
        private const String translateFilePath = "..\\..\\JsonData\\Translate.json";
        private const String eggFilePath = "..\\..\\JsonData\\EasterEgg.json";

        public static JObject ReadControls() => ReadFile(controlsFilePath);

        public static JObject ReadConfigurations() => ReadFile(configurationFilePath);
        public static void WriteConfigurations(JObject fileData) => WriteFile(configurationFilePath, fileData);

        public static JObject ReadConfig() => ReadFile(configFilePath);
        public static void WriteConfig(JObject fileData) => WriteFile(configFilePath, fileData);

        public static JObject ReadTranslate() => ReadFile(translateFilePath, encoding: Encoding.Default);

        public static JObject ReadEgg() => ReadFile(eggFilePath);

        private static JObject ReadFile(String filePath, Encoding encoding = null)
        {
            String fileData;
            try { fileData = encoding is null ? File.ReadAllText(filePath) : File.ReadAllText(filePath, encoding); }
            catch (Exception exception) { fileData = ""; SendMessage(exception.ToString()); }
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

    internal static class ExtractDataJson
    {

        public static String ARBGStringByColor(Color color)
        {
            return $"[{color.A},{color.R},{color.B},{color.G}]";
        }

        public static Font BuildFontFromJToken(JToken token)
        {
            return BuildFont
                    (
                        isBold: token["Bold"].Value<Boolean>(),
                        isItalic: token["Italic"].Value<Boolean>(),
                        isStrikeout: token["Strikeout"].Value<Boolean>(),
                        isUnderline: token["Underline"].Value<Boolean>(),
                        familyName: token["Name"].Value<String>(),
                        emSize: token["Size"].Value<Single>(),
                        unit: (GraphicsUnit)Enum.Parse(typeof(GraphicsUnit), token["Unit"].Value<String>()),
                        gdiCharSet: token["GdiCharSet"].Value<Byte>(),
                        gdiVerticalFont: token["GdiVerticalFont"].Value<Boolean>()
                    );
        }

        public static Font BuildFont(Boolean isBold, Boolean isItalic, Boolean isStrikeout, Boolean isUnderline, String familyName, Single emSize, GraphicsUnit unit, Byte gdiCharSet, Boolean gdiVerticalFont)
        {
            FontStyle style = FontStyle.Regular;
            if (isBold) style = style | FontStyle.Bold;
            if (isItalic) style = style | FontStyle.Italic;
            if (isStrikeout) style = style | FontStyle.Strikeout;
            if (isUnderline) style = style | FontStyle.Underline;
            return new Font(familyName: familyName, emSize: emSize, unit: unit, gdiCharSet: gdiCharSet, gdiVerticalFont: gdiVerticalFont, style: style);
        }
    }
}
