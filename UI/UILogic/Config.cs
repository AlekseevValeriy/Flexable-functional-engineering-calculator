﻿namespace FFEC
{
    internal static class Config
    {
        public static String LoadConfiguration(String configName)
        {
            List<String> configs = GetList();

            if (configs.Count == 0) throw new Exception("Отсутствует базовая конфигурация");
            if (!configs.Contains(configName)) configName = configs.First();

            return JsonStorage.Configurations[configName].ToString();
        }
        public static void Save() => JsonStreamer.WriteConfigurations(JsonStorage.Configurations);

        public static void Set(String configName, JObject configData) => JsonStorage.Configurations[configName] = configData;

        public static void Remove(String configName) => JsonStorage.Configurations.Remove(configName);

        public static String GetDefaultData() => JsonStorage.Config["DefaultConfiguration"].ToString();
        public static List<String> GetList()
        {
            List<String> configurations = new List<String>();
            foreach (KeyValuePair<String, JToken> configuration in JsonStorage.Configurations) configurations.Add(configuration.Key);
            return configurations;
        }

        public static void UploadConfigurationInForm(String configName, CalculatorForm mainForm, MenuStrip menuStrip, SplitContainer splitContainer, TableLayoutPanel displayTable, TableLayoutPanel controlsTable)
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
            menuStrip.Font = DataSerializer.JTokenToFont(menuStripFontToken);
            menuStrip.BackColor = Color.FromName(config["MenuStrip"]["BackColor"].Value<String>());
            menuStrip.ForeColor = Color.FromName(config["MenuStrip"]["ForeColor"].Value<String>());

            JToken defaultControlFontToken = config["DefaultControlStyle"]["Font"];
            Font defaultControlFont = DataSerializer.JTokenToFont(defaultControlFontToken);
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

                    data["Font"] = DataSerializer.FontToJObject(defaultControlFont);
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

                    control = Handler.NewButton(data, JsonStorage.GetControlText(data["Sector"].Value<String>(), data["Name"].Value<String>()), dockStyle);
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

    }
}
