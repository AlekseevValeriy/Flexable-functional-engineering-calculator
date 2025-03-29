namespace FFEC.UI.Forms.Optional
{
    public partial class FunctionEnter : Form, ICloseTrackable
    {
        public bool closed { get; set; } = true;
        internal STextBox _functionTextBox;
        internal STextBox Display => _functionTextBox;
        internal string FunctionName => nameTextBox.Text;
        public FunctionEnter()
        {
            InitializeComponent();
            _functionTextBox = new STextBox(Handler.GetRuleByData(new JObject()
            {
                { "Sector", "Display"},
                { "Name", "Base" }
            }
            ))
            { ReadOnly = true, Anchor = AnchorStyles.Left | AnchorStyles.Right };
            tableLayoutPanel.Controls.Add(_functionTextBox, 1, 1);
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
