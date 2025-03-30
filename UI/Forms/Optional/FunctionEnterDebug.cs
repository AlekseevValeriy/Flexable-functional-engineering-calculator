namespace FFEC.UI.Forms.Optional
{
    public partial class FunctionEnterDebug : Form, ICloseTrackable
    {
        public bool closed { get; set; } = true;
        internal STextBox _functionTextBox;
        internal STextBox _manualTextBox;
        internal STextBox Display => _functionTextBox;
        internal STextBox Manual => _manualTextBox;
        internal string FunctionName => nameTextBox.Text;
        public FunctionEnterDebug()
        {
            InitializeComponent();
            _functionTextBox = new STextBox(Handler.GetRuleByData(new JObject()
            {
                { "Sector", "Display"},
                { "Name", "Base" }
            }
            ))
            { ReadOnly = true, Anchor = AnchorStyles.Left | AnchorStyles.Right };
            _manualTextBox = new STextBox(Handler.GetRuleByData(new JObject()
            {
                { "Sector", "Display"},
                { "Name", "Manual" }
            }
            ))
            { ReadOnly = true, Dock = DockStyle.Fill, ScrollBars = ScrollBars.Vertical };
            tableLayoutPanel.Controls.Add(_functionTextBox, 1, 1);
            tableLayoutPanel.Controls.Add(_manualTextBox, 1, 2);
            DialogResult = DialogResult.Abort;
        }

        private void FunctionEnteClosed(object sender, FormClosedEventArgs e)
        {
            //Global.expression.Clear();
            (Owner as CalculatorForm).functionAddEnd(sender: this);
        }

        private void SaveFunction(object sender, EventArgs e)
        {
            if (nameTextBox.Text == "")
            {
                Messages.RaiseErrorMessage("Пожалуйста, введите название функции!");
                return;
            }
            if (JsonStorage.Configurations[Config.CurrentConfig]["CustomFunctions"].ToObject<Dictionary<string, string>>().Select(x => x.Key).ToList().Contains(nameTextBox.Text))
            {
                Messages.RaiseErrorMessage("Такое название уже есть. Пожалуйста, введите другое название функции!");
                return;
            }
            if (Global.expression.Count == 0)
            {
                Messages.RaiseErrorMessage("Пожалуйста, введите функцию!");
                return;
            }
            if (!(Global.expression.Count > 1 && Global.expression[Global.expression.Count - 2] is Operator) & !(Global.expression.Count == 1 && Global.expression.Last() is IExpressionStoreable))
            {
                Messages.RaiseErrorMessage("Пожалуйста, введите корректуню функцию!");
                return;
            }
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
