namespace FFEC
{
    internal class SButton : Button, IDataStorable, IDataMoveable
    {
        public JObject JData { get; } = [];
        public bool Locked { get; set; } = false;
        public SButton() : base() { }
        public SButton(string data) : this() { FlatStyle = FlatStyle.Flat; ParseData(data); }
        public void SetJData(Dictionary<string, string> parameters)
        {
            foreach (KeyValuePair<string, string> parameter in parameters)
            {
                JData[parameter.Key] = parameter.Value;
            }
        }

        public string GetImportData()
        {
            return GetOriginalImportData().ToString();
        }

        public JObject GetOriginalImportData()
        {
            JObject data = [];
            CommonSDataImporter.CommonDataImport(ref data, this);
            if (this.FlatStyle == FlatStyle.Flat)
            {
                data["FlatBorderColor"] = this.FlatAppearance.BorderColor.Name;
                data["FlatMouseDownBackColor"] = this.FlatAppearance.MouseDownBackColor.Name;
                data["FlatMouseOverBackColor"] = this.FlatAppearance.MouseOverBackColor.Name;
            }

            return data;
        }

        public void ParseData(string data)
        {
            JObject parsedData = JObject.Parse(data);
            CommonSDataParser.CommonPathDataParse(parsedData, JData);

            if (parsedData.ContainsKey("Size"))
            {
                CommonSDataParser.CommonDisplayDataParse(parsedData, this);
                if (parsedData.ContainsKey("FlatBorderColor"))
                {
                    string flatBorderColor = parsedData["FlatBorderColor"].Value<string>();
                    if (flatBorderColor != "0")
                    {
                        this.FlatAppearance.BorderColor = Color.FromName(flatBorderColor);
                    }

                    string flatDownColor = parsedData["FlatMouseDownBackColor"].Value<string>();
                    if (flatDownColor != "0")
                    {
                        this.FlatAppearance.MouseDownBackColor = Color.FromName(flatDownColor);
                    }

                    string flatOverColor = parsedData["FlatMouseOverBackColor"].Value<string>();
                    if (flatOverColor != "0")
                    {
                        this.FlatAppearance.MouseOverBackColor = Color.FromName(flatOverColor);
                    }
                }
            }
        }
    }

    internal class STextBox : TextBox, IDataStorable, IDataMoveable
    {
        public JObject JData { get; } = [];
        public bool Locked { get; set; } = false;
        public void SetJData(Dictionary<string, string> parameters)
        {
            foreach (KeyValuePair<string, string> parameter in parameters)
            {
                JData[parameter.Key] = parameter.Value;
            }
        }
        private ConverterToStringByRule Rule { get; }
        public void SetTextByRule(List<Composite> expression)
        {
            Text = Rule(expression);
        }
        public STextBox() : base() { }
        public STextBox(string data) : base() { ParseData(data); }
        public STextBox(ConverterToStringByRule rule = null) : base() { Rule = rule is not null ? rule : (List<Composite> expression, bool debug) => ""; }
        public STextBox(string data, ConverterToStringByRule rule = null) : this(rule) { ParseData(data); }
        public string GetImportData()
        {
            return GetOriginalImportData().ToString();
        }
        public JObject GetOriginalImportData()
        {
            JObject data = [];
            CommonSDataImporter.CommonDataImport(ref data, this);
            return data;
        }

        public void ParseData(string data)
        {
            JObject parsedData = JObject.Parse(data);
            CommonSDataParser.CommonPathDataParse(parsedData, JData);

            if (parsedData.ContainsKey("Size"))
            {
                CommonSDataParser.CommonDisplayDataParse(parsedData, this);
            }
        }
    }

    internal delegate string ConverterToStringByRule(List<Composite> expression, bool debug = false);

    internal interface IDataMoveable : IDataReceivable, IDataTransmitable { }

    internal interface IDataReceivable
    {
        JObject JData { get; }
        void SetJData(Dictionary<string, string> parameters);
        void ParseData(string data);
    }

    internal interface IDataTransmitable
    {
        JObject GetOriginalImportData();
        string GetImportData();
    }

    internal interface IDataStorable
    {
        bool Locked { get; set; }
    }

    internal static class CommonSDataParser
    {
        public static void CommonDisplayDataParse(JObject data, Control control)
        {
            control.Width = data["Size"][0].Value<ushort>();
            control.Height = data["Size"][1].Value<ushort>();
            ((IDataStorable)control).Locked = data["Lock"].Value<bool>();
            control.Dock = (DockStyle)Enum.Parse(typeof(DockStyle), data["Placement"].Value<string>());
            control.Font = DataConverter.JTokenToFont(data["Font"]);
            control.BackColor = Color.FromName(data["BackColor"].Value<string>());
            control.ForeColor = Color.FromName(data["ForeColor"].Value<string>());
        }

        public static void CommonPathDataParse(JObject data, JObject jData)
        {
            jData["Sector"] = data["Sector"].Value<string>();
            jData["Name"] = data["Name"].Value<string>();
        }
    }

    internal static class CommonSDataImporter
    {
        public static void CommonDataImport(ref JObject data, Control control)
        {
            data["Sector"] = ((IDataReceivable)control).JData["Sector"];
            data["Name"] = ((IDataReceivable)control).JData["Name"];
            data["Size"] = new JArray(control.Width, control.Height);
            data["Lock"] = ((IDataStorable)control).Locked;
            data["Placement"] = control.Dock.ToString();
            data["Font"] = new JObject
            {
                ["Name"] = control.Font.Name,
                ["Size"] = control.Font.Size,
                ["Unit"] = control.Font.Unit.ToString(),
                ["Bold"] = control.Font.Bold,
                ["GdiCharSet"] = control.Font.GdiCharSet,
                ["GdiVerticalFont"] = control.Font.GdiVerticalFont,
                ["Italic"] = control.Font.Italic,
                ["Strikeout"] = control.Font.Strikeout,
                ["Underline"] = control.Font.Underline
            };
            data["BackColor"] = control.BackColor.Name;
            data["ForeColor"] = control.ForeColor.Name;
        }
    }

    internal interface ICloseTrackable
    {
        bool closed { get; set; }
    }
}
