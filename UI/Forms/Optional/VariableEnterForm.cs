namespace FFEC.UI.Forms.Optional
{
    public partial class VariableEnterForm : Form
    {
        public VariableEnterForm()
        {
            InitializeComponent();
        }

        public KeyValuePair<string, long> GetVariable()
        {
            return new KeyValuePair<string, long>(nameTextBox.Text, long.Parse(valueTextBox.Text));
        }

        public bool ValidateVariable()
        {
            return nameTextBox.Text != "" && !(Owner as VariablesForm).Contains(nameTextBox.Text) &
               valueTextBox.Text != "" && long.TryParse(valueTextBox.Text, out long result);
        }
    }
}
