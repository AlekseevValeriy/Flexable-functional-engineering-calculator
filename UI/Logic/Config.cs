namespace FFEC
{
    internal static class Config
    {
        private static string _currentConfig = null;
        public static string CurrentConfig
        {
            get
            {
                if (_currentConfig is null)
                {
                    UpdateCurrentConfig();
                }

                return _currentConfig;
            }
        }

        public static void UpdateCurrentConfig()
        {
            List<string> configs = GetList();
            string localCurrentConfig = JsonStorage.Config["Configuration"].Value<string>();
            _currentConfig = configs.Count != 0 ? configs.Contains(localCurrentConfig) ? localCurrentConfig : configs.First() : null;
        }

        public static string LoadConfiguration(string configName = "")
        {
            List<string> configs = GetList();

            if (configName != "" & configs.Count == 0)
            {
                throw new Exception("Отсутствует базовая конфигурация");
            }

            if (!configs.Contains(configName))
            {
                configName = configs.First();
            }

            return JsonStorage.Configurations[configName].ToString();
        }
        public static void Save()
        {
            JsonStreamer.WriteConfigurations(JsonStorage.Configurations);
        }

        public static void Set(string configName, JObject configData)
        {
            JsonStorage.Configurations[configName] = configData;
        }

        public static void Remove(string configName)
        {
            JsonStorage.Configurations.Remove(configName);
        }

        public static string GetDefaultData()
        {
            return JsonStorage.Config["DefaultConfiguration"].ToString();
        }

        public static List<string> GetList()
        {
            List<string> configurations = [];
            foreach (KeyValuePair<string, JToken> configuration in JsonStorage.Configurations)
            {
                configurations.Add(configuration.Key);
            }

            return configurations;
        }

        public static void UploadConfigurationInForm(string configName, CalculatorForm mainForm, MenuStrip menuStrip, SplitContainer splitContainer, TableLayoutPanel displayTable, TableLayoutPanel controlsTable)
        {
            JObject config = JObject.Parse(LoadConfiguration(configName));

            Global.placement = (DockStyle)Enum.Parse(typeof(DockStyle), config["Global"]["Placement"].Value<string>());
            Global.borderView = config["Global"]["BorderView"].Value<bool>();

            mainForm.Size = new Size(config["Form"]["Size"][0].Value<ushort>(), config["Form"]["Size"][1].Value<ushort>());
            mainForm.BackColor = Color.FromName(config["Form"]["BackColor"].Value<string>());

            splitContainer.SplitterDistance = config["SplitContainer"]["SplitterDistance"].Value<int>();

            displayTable.Controls.Clear();
            displayTable.RowCount = 0;
            displayTable.RowStyles.Clear();
            byte displayRowCount = config["TableStructs"]["Display"][0].Value<byte>();
            for (byte R = 0; R < displayRowCount; R++) { Handler.PanelAddRow(displayTable); }

            controlsTable.Controls.Clear();
            controlsTable.RowCount = 0;
            controlsTable.RowStyles.Clear();
            controlsTable.ColumnCount = 0;
            controlsTable.ColumnStyles.Clear();

            byte controlsRowCount = config["TableStructs"]["Controls"][0].Value<byte>();
            byte controlsColumnCount = config["TableStructs"]["Controls"][1].Value<byte>();
            for (byte R = 0; R < controlsRowCount; R++)
            {
                Handler.PanelAddRow(controlsTable);
            }

            for (byte C = 0; C < controlsColumnCount; C++)
            {
                Handler.PanelAddColumn(controlsTable);
            }

            JToken menuStripFontToken = config["MenuStrip"]["Font"];
            menuStrip.Font = DataConverter.JTokenToFont(menuStripFontToken);
            menuStrip.BackColor = Color.FromName(config["MenuStrip"]["BackColor"].Value<string>());
            menuStrip.ForeColor = Color.FromName(config["MenuStrip"]["ForeColor"].Value<string>());

            JToken defaultControlFontToken = config["DefaultControlStyle"]["Font"];
            Font defaultControlFont = DataConverter.JTokenToFont(defaultControlFontToken);
            Color defaultControlBackColor = Color.FromName(config["DefaultControlStyle"]["BackColor"].Value<string>());
            Color defaultControlForeColor = Color.FromName(config["DefaultControlStyle"]["ForeColor"].Value<string>());
            Color defaultControlFlatBorderColor = Color.FromName(config["DefaultControlStyle"]["FlatBorderColor"].Value<string>());
            Color defaultControlFlatOverColor = Color.FromName(config["DefaultControlStyle"]["FlatMouseOverBackColor"].Value<string>());
            Color defaultControlFlatDownColor = Color.FromName(config["DefaultControlStyle"]["FlatMouseDownBackColor"].Value<string>());

            foreach (JToken dat in config["ControlsLayout"])
            {
                JObject data = dat.ToObject<JObject>();
                DockStyle? dockStyle = (DockStyle)Enum.Parse(typeof(DockStyle), data["Placement"].Value<string>());
                if (!data["Lock"].Value<bool>())
                {

                    data["Font"] = DataConverter.FontToJObject(defaultControlFont);
                    data["ForeColor"] = defaultControlForeColor.Name;
                    data["BackColor"] = defaultControlBackColor.Name;

                    dockStyle = null;
                }
                Control control;
                TableLayoutPanel table;
                if (data["Sector"].Value<string>() != "Display")
                {
                    data["FlatBorderColor"] = defaultControlFlatBorderColor.Name;
                    data["FlatMouseDownBackColor"] = defaultControlFlatDownColor.Name;
                    data["FlatMouseOverBackColor"] = defaultControlFlatOverColor.Name;

                    if (data["Sector"].Value<string>() == "Variables")
                    {
                        if (!GetVariableNames().Contains(data["Name"].Value<string>())) continue;
                        control = Handler.NewButton(data, data["Name"].Value<string>(), dockStyle);
                    }
                    else if (data["Sector"].Value<string>() == "Custom functions")
                    {
                        if(!GetCustomFunctionNames().Contains(data["Name"].Value<string>())) continue;
                        control = Handler.NewButton(data, data["Name"].Value<string>(), dockStyle);
                    }
                    else
                    {
                        control = Handler.NewButton(data, JsonStorage.GetControlText(data["Sector"].Value<string>(), data["Name"].Value<string>()), dockStyle);
                    }
                    table = controlsTable;
                }
                else
                {
                    control = Handler.NewTextBox(data, dockStyle);
                    table = displayTable;
                }
                table.GetControlFromPosition(data["PositionByCell"][0].Value<byte>(), data["PositionByCell"][1].Value<byte>()).Controls.Add(control);
            }

            Global.expression.Clear();
        }

        public static List<string> GetVariableNames()
        {
            return JsonStorage.Configurations[Config.CurrentConfig]["Variables"].ToObject<Dictionary<string, string>>().Select(x => x.Key).ToList();
        }
        public static List<string> GetCustomFunctionNames()
        {
            return JsonStorage.Configurations[Config.CurrentConfig]["CustomFunctions"].ToObject<Dictionary<string, string>>().Select(x => x.Key).ToList();
        }
    }
}
