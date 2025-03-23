namespace FFEC
{
    internal class SButton : Button, IDataStorable, IDataMoveable
    {
        public JObject JData { get; } = new JObject();
        public Boolean Locked { get; set; } = false;
        public SButton() : base() { }
        public SButton(String data) : this() { FlatStyle = FlatStyle.Flat; ParseData(data); }
        public void SetJData(Dictionary<String, String> parameters)
        {
            foreach (KeyValuePair<String, String> parameter in parameters) JData[parameter.Key] = parameter.Value;
        }

        public String GetImportData()
        {
            return GetOriginalImportData().ToString();
        }

        public JObject GetOriginalImportData()
        {
            JObject data = new JObject();
            CommonSDataImporter.CommonDataImport(ref data, this);
            if (this.FlatStyle == FlatStyle.Flat)
            {
                data["FlatBorderColor"] = this.FlatAppearance.BorderColor.Name;
                data["FlatMouseDownBackColor"] = this.FlatAppearance.MouseDownBackColor.Name;
                data["FlatMouseOverBackColor"] = this.FlatAppearance.MouseOverBackColor.Name;
            }

            return data;
        }

        public void ParseData(String data)
        {
            JObject parsedData = JObject.Parse(data);
            CommonSDataParser.CommonPathDataParse(parsedData, JData);

            if (parsedData.ContainsKey("Size"))
            {
                CommonSDataParser.CommonDisplayDataParse(parsedData, this);
                if (parsedData.ContainsKey("FlatBorderColor"))
                {
                    String flatBorderColor = parsedData["FlatBorderColor"].Value<String>();
                    if (flatBorderColor != "0") this.FlatAppearance.BorderColor = Color.FromName(flatBorderColor);
                    String flatDownColor = parsedData["FlatMouseDownBackColor"].Value<String>();
                    if (flatDownColor != "0") this.FlatAppearance.MouseDownBackColor = Color.FromName(flatDownColor);
                    String flatOverColor = parsedData["FlatMouseOverBackColor"].Value<String>();
                    if (flatOverColor != "0") this.FlatAppearance.MouseOverBackColor = Color.FromName(flatOverColor);
                }
            }
        }
    }

    internal class STextBox : TextBox, IDataStorable, IDataMoveable
    {
        public JObject JData { get; } = new JObject();
        public Boolean Locked { get; set; } = false;
        public void SetJData(Dictionary<String, String> parameters)
        {
            foreach (KeyValuePair<String, String> parameter in parameters) JData[parameter.Key] = parameter.Value;
        }
        private ConverterToStringByRule Rule { get; }
        public void SetTextByRule(List<Composite> expression) => Text = Rule(expression);
        public STextBox(String data) : base() { ParseData(data); }
        public STextBox(ConverterToStringByRule rule = null) : base() { Rule = rule is not null ? rule : (List<Composite> expression, Boolean debug) => ""; }
        public STextBox(String data, ConverterToStringByRule rule = null) : this(rule) { ParseData(data); }
        public String GetImportData()
        {
            return GetOriginalImportData().ToString();
        }
        public JObject GetOriginalImportData()
        {
            JObject data = new JObject();
            CommonSDataImporter.CommonDataImport(ref data, this);
            return data;
        }

        public void ParseData(String data)
        {
            JObject parsedData = JObject.Parse(data);
            CommonSDataParser.CommonPathDataParse(parsedData, JData);

            if (parsedData.ContainsKey("Size"))
            {
                CommonSDataParser.CommonDisplayDataParse(parsedData, this);
            }
        }
    }

    internal delegate String ConverterToStringByRule(List<Composite> expression, Boolean debug = false);

    internal interface IDataMoveable : IDataReceivable, IDataTransmitable { }

    internal interface IDataReceivable
    {
        public JObject JData { get; }
        public void SetJData(Dictionary<String, String> parameters);
        void ParseData(String data);
    }

    internal interface IDataTransmitable
    {
        public JObject GetOriginalImportData();
        public String GetImportData();
    }

    internal interface IDataStorable
    {
        public Boolean Locked { get; set; }
    }

    internal static class CommonSDataParser
    {
        public static void CommonDisplayDataParse(JObject data, Control control)
        {
            control.Width = data["Size"][0].Value<UInt16>();
            control.Height = data["Size"][1].Value<UInt16>();
            ((IDataStorable)control).Locked = data["Lock"].Value<Boolean>();
            control.Dock = (DockStyle)Enum.Parse(typeof(DockStyle), data["Placement"].Value<String>());
            control.Font = DataSerializer.JTokenToFont(data["Font"]);
            control.BackColor = Color.FromName(data["BackColor"].Value<String>());
            control.ForeColor = Color.FromName(data["ForeColor"].Value<String>());
        }

        public static void CommonPathDataParse(JObject data, JObject jData)
        {
            jData["Sector"] = data["Sector"].Value<String>();
            jData["Name"] = data["Name"].Value<String>();
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
            data["Font"] = new JObject();
            data["Font"]["Name"] = control.Font.Name;
            data["Font"]["Size"] = control.Font.Size;
            data["Font"]["Unit"] = control.Font.Unit.ToString();
            data["Font"]["Bold"] = control.Font.Bold;
            data["Font"]["GdiCharSet"] = control.Font.GdiCharSet;
            data["Font"]["GdiVerticalFont"] = control.Font.GdiVerticalFont;
            data["Font"]["Italic"] = control.Font.Italic;
            data["Font"]["Strikeout"] = control.Font.Strikeout;
            data["Font"]["Underline"] = control.Font.Underline;
            data["BackColor"] = control.BackColor.Name;
            data["ForeColor"] = control.ForeColor.Name;
        }
    }

    internal interface ICloseTrackable
    {
        Boolean closed { get; set; }
    }
}
