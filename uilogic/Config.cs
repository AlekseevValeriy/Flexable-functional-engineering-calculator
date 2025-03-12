namespace FFEC
{
    internal static class Config
    {
        private static String currentConfiguration;
        public static void InitializeConfiguration(CalculatorForm form, MenuStrip menu, SplitContainer splitContainer, TableLayoutPanel displayTablePanels, TableLayoutPanel controlTablePanels)
        {
            currentConfiguration = GetCurrentConfiguration();
            List<String> configurations = GetConfigurationsList();

            if (configurations.Count == 0) return;
            if (currentConfiguration == "" | !configurations.Contains(currentConfiguration)) currentConfiguration = configurations.First();

            List<UInt16> configurationsWindowSize = ReceiveJsonData<List<UInt16>>("WindowSize");
            form.Size = new Size(configurationsWindowSize[0], configurationsWindowSize[1]);

            if (Enum.TryParse<DockStyle>(ReceiveJsonData<String>("Placement"), out DockStyle dockStyle)) Global.placement = dockStyle;
            else return;

            Global.borderView = ReceiveJsonData<Boolean>("BorderView");

            splitContainer.SplitterDistance = ReceiveJsonData<UInt16>("SplitContainerSplitterDistance");

            Byte[] displayTableCapacity = ReceiveJsonData<Byte[]>("TableCapacity", "Display"), controlTableCapacity = ReceiveJsonData<Byte[]>("TableCapacity", "Controls");
            displayTablePanels.RowCount = displayTableCapacity[0]; displayTablePanels.ColumnCount = displayTableCapacity[1];
            controlTablePanels.RowCount = controlTableCapacity[0]; controlTablePanels.ColumnCount = controlTableCapacity[1];

            form.BackColor = ColorByArray(ReceiveJsonData<Byte[]>("Form", "BackColor"));
            Font? menuFont = GetNewFontByToken("MenuStrip");
            if (menuFont is null) return;
            else menu.Font = menuFont;
            menu.ForeColor = ColorByArray(ReceiveJsonData<Byte[]>("MenuStrip", "ForeColor"));
            menu.BackColor = ColorByArray(ReceiveJsonData<Byte[]>("MenuStrip", "BackColor"));

            // -- controls data //



        }

        private static Color ColorByArray(Byte[] list) => Color.FromArgb(list[0], list[1], list[2], list[3]);

        private static Font? GetNewFontByToken(params List<String> tokens)
        {
            String tokenPath = String.Join(".", tokens);
            FontStyle style = FontStyle.Regular;
            if (ReceiveJsonData<Boolean>(tokenPath, "Font", "Bold")) style = style | FontStyle.Bold;
            if (ReceiveJsonData<Boolean>(tokenPath, "Font", "Italic")) style = style | FontStyle.Italic;
            if (ReceiveJsonData<Boolean>(tokenPath, "Font", "Strikeout")) style = style | FontStyle.Strikeout;
            if (ReceiveJsonData<Boolean>(tokenPath, "Font", "Underline")) style = style | FontStyle.Underline;
            if (!Enum.TryParse<GraphicsUnit>(ReceiveJsonData<String>(tokenPath, "Font", "Unit"), out GraphicsUnit graphicsUnit)) return null;
            Font font = new Font(
                familyName: ReceiveJsonData<String>(tokenPath, "Font", "Name"),
                emSize: ReceiveJsonData<Single>(tokenPath, "Font", "Size"),
                unit: graphicsUnit,
                gdiCharSet: ReceiveJsonData<Byte>(tokenPath, "Font", "GdiCharSet"),
                gdiVerticalFont: ReceiveJsonData<Boolean>(tokenPath, "Font", "GdiVerticalFont"),
                style: style
                );
            return font;
        }
        
        private static JToken? ReceiveJsonData(params List<String> tokens)
        {
            return Storage.Configurations.SelectToken($"$.{currentConfiguration}.{String.Join(".", tokens)}");
        }
        private static T? ReceiveJsonData<T>(params List<String> tokens)
        {
            return Storage.Configurations.SelectToken($"$.{currentConfiguration}.{String.Join(".", tokens)}").ToObject<T>();
        }

        public static String GetCurrentConfiguration() => Storage.Config.SelectToken($"$.Configuration").ToString();
        public static List<String> GetConfigurationsList()
        {
            List<String> configurations = new List<String>();
            foreach (KeyValuePair<String, JToken> configuration in Storage.Configurations) configurations.Add(configuration.Key);
            return configurations;
        }
    }
}
