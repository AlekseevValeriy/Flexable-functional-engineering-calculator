namespace FFEC
{
    internal static class Config
    {
        public static String LoadConfiguration(String configName)
        {
            List<String> configs = GetList();

            if (configs.Count == 0) throw new Exception("Отсутствует базовая конфигурация");
            if (!configs.Contains(configName)) configName = configs.First();

            return JsonDataStorage.Configurations[configName].ToString();
        }
        public static void Save() => JsonStreamer.WriteConfigurations(JsonDataStorage.Configurations);

        public static void Set(String configName, JObject configData) => JsonDataStorage.Configurations[configName] = configData;

        public static void Remove(String configName) => JsonDataStorage.Configurations.Remove(configName);

        public static String GetDefaultData() => JsonDataStorage.Config["DefaultConfiguration"].ToString();

        public static void InitializeConfiguration(String configName, CalculatorForm mainForm, MenuStrip menuStrip, SplitContainer splitContainer, TableLayoutPanel displayTable, TableLayoutPanel controlsTable)
        {
            try
            {
                JObject config = JObject.Parse(LoadConfiguration(configName));


                Global.placement = (DockStyle)Enum.Parse(typeof(DockStyle), config["Global"]["Placement"].Value<String>());
                Global.borderView = config["Global"]["BorderView"].Value<Boolean>();

                mainForm.Size = new Size(config["Form"]["Size"][0].Value<UInt16>(), config["Form"]["Size"][1].Value<UInt16>());
                mainForm.BackColor = Color.FromName(config["Form"]["BackColor"].Value<String>());

                splitContainer.SplitterDistance = config["SplitContainer"]["SplitterDistance"].Value<Int32>();

                displayTable.Controls.Clear();
                displayTable.RowCount = 0;
                displayTable.RowStyles.Clear();
                Byte displayRowCount = config["TableStructs"]["Display"][0].Value<Byte>();
                for (Byte R = 0; R < displayRowCount; R++) { Handler.PanelAddRow(displayTable); }

                controlsTable.Controls.Clear();
                controlsTable.RowCount = 0;
                controlsTable.RowStyles.Clear();
                controlsTable.ColumnCount = 0;
                controlsTable.ColumnStyles.Clear();
                Byte controlsRowCount = config["TableStructs"]["Controls"][0].Value<Byte>();
                Byte controlsColumnCount = config["TableStructs"]["Controls"][1].Value<Byte>();
                for (Byte R = 0; R < controlsRowCount; R++) Handler.PanelAddRow(controlsTable);
                for (Byte C = 0; C < controlsColumnCount; C++) Handler.PanelAddColumn(controlsTable);

                JToken menuStripFontToken = config["MenuStrip"]["Font"];
                menuStrip.Font = ExtractDataJson.BuildFontFromJToken(menuStripFontToken);
                menuStrip.BackColor = Color.FromName(config["MenuStrip"]["BackColor"].Value<String>());
                menuStrip.ForeColor = Color.FromName(config["MenuStrip"]["ForeColor"].Value<String>());

                JToken defaultControlFontToken = config["DefaultControlStyle"]["Font"];
                Font defaultControlFont = ExtractDataJson.BuildFontFromJToken(defaultControlFontToken);
                Color defaultControlBackColor = Color.FromName(config["DefaultControlStyle"]["BackColor"].Value<String>());
                Color defaultControlForeColor = Color.FromName(config["DefaultControlStyle"]["ForeColor"].Value<String>());
                Color defaultControlFlatBorderColor = Color.FromName(config["DefaultControlStyle"]["FlatBorderColor"].Value<String>());
                Color defaultControlFlatOverColor = Color.FromName(config["DefaultControlStyle"]["FlatMouseOverBackColor"].Value<String>());
                Color defaultControlFlatDownColor = Color.FromName(config["DefaultControlStyle"]["FlatMouseDownBackColor"].Value<String>());

                foreach (JToken dat in config["ControlsLayout"])
                {
                    JObject data = dat.ToObject<JObject>();
                    DockStyle? dockStyle = (DockStyle)Enum.Parse(typeof(DockStyle), data["Placement"].Value<String>());
                    if (!data["Lock"].Value<Boolean>())
                    {

                        data["Font"] = JObjectByFont(defaultControlFont);
                        data["ForeColor"] = defaultControlForeColor.Name;
                        data["BackColor"] = defaultControlBackColor.Name;

                        dockStyle = null;
                    }
                    Control control;
                    if (data["Sector"].Value<String>() != "Display")
                    {
                        data["FlatBorderColor"] = defaultControlFlatBorderColor.Name;
                        data["FlatMouseDownBackColor"] = defaultControlFlatDownColor.Name;
                        data["FlatMouseOverBackColor"] = defaultControlFlatOverColor.Name;

                        control = Handler.NewButton(data, JsonDataStorage.GetControlText(data["Sector"].Value<String>(), data["Name"].Value<String>()), dockStyle);
                        controlsTable.GetControlFromPosition(data["PositionByCell"][0].Value<Byte>(), data["PositionByCell"][1].Value<Byte>()).Controls.Add(control);
                    }
                    else
                    {
                        control = Handler.NewTextBox(data, dockStyle);
                        displayTable.GetControlFromPosition(data["PositionByCell"][0].Value<Byte>(), data["PositionByCell"][1].Value<Byte>()).Controls.Add(control);
                    }
                }

                Global.expression.Clear();

            }
            catch (Exception exception)
            {
                MessageBox.Show($"Иницилизация конфигурации завершилась неудачно: {exception.Message}");
            }
        }

        public static List<String> GetList()
        {
            List<String> configurations = new List<String>();
            foreach (KeyValuePair<String, JToken> configuration in JsonDataStorage.Configurations) configurations.Add(configuration.Key);
            return configurations;
        }

        public static JObject JObjectByFont(Font font)
        {
            JObject obj = new JObject();
            obj["Name"] = font.Name;
            obj["Size"] = font.Size;
            obj["Unit"] = font.Unit.ToString();
            obj["Bold"] = font.Bold;
            obj["GdiCharSet"] = font.GdiCharSet;
            obj["GdiVerticalFont"] = font.GdiVerticalFont;
            obj["Italic"] = font.Italic;
            obj["Strikeout"] = font.Strikeout;
            obj["Underline"] = font.Underline;
            return obj;
        }
    }
}
