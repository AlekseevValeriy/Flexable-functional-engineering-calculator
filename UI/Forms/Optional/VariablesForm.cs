namespace FFEC.UI.Forms.Optional
{
    public partial class VariablesForm : Form, ICloseTrackable
    {
        private string tempEditedCellValue = null;
        public bool closed { get; set; } = true;
        public Dictionary<string, Form> SubOwners { get; set; } = [];
        public VariablesForm()
        {
            InitializeComponent();
            InitializeVariables();
        }

        public bool Contains(string name)
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (name == row.Cells[0].Value.ToString())
                {
                    return true;
                }
            }
            return false;
        }

        private void InitializeVariables()
        {
            foreach (KeyValuePair<string, long> variable in JsonStorage.Configurations[Config.CurrentConfig]["Variables"].ToObject<Dictionary<string, long>>())
            {
                WriteLine(variable);
            }
        }

        public void UpdateVariables()
        {
            dataGridView.Rows.Clear();
            InitializeVariables();
        }

        private void WriteLine(KeyValuePair<string, long> variable)
        {
            dataGridView.Rows.Add(variable.Key, variable.Value.ToString());
        }

        private void ControlsFormShown(object sender, EventArgs e)
        {
            Handler.SetSubFormPosition(Owner, this);
        }

        private void AddVariable(object sender, EventArgs e)
        {
            VariableEnterForm variableForm = new VariableEnterForm() { Owner = this };
            if (variableForm.ShowDialog() is DialogResult.OK && variableForm.ValidateVariable())
            {
                KeyValuePair<string, long> variable = variableForm.GetVariable();
                WriteLine(variable);
                JsonStorage.Configurations[Config.CurrentConfig]["Variables"][variable.Key] = variable.Value;
                UpdateInOwners();
            }
        }

        private void RemoveVariable(object sender, EventArgs e)
        {
            (JsonStorage.Configurations[Config.CurrentConfig]["Variables"] as JObject).Remove(dataGridView.SelectedCells[0].Value.ToString());
            dataGridView.Rows.RemoveAt(dataGridView.SelectedCells[0].RowIndex);
            UpdateInOwners();
        }

        private void UpdateInOwners()
        {
            if (SubOwners["Controls"] is ControlsForm controls && !controls.closed)
            {
                controls.UpdateRequiredTabs();
            } (Owner as CalculatorForm).UpdateVariablesOnPanel();
            InputController.UpdateVariableInExpression(Global.expression);
        }

        private void dataGridViewCellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dataGridView.SelectedCells.Count == 0)
            {
                return;
            }

            tempEditedCellValue = dataGridView[e.ColumnIndex, e.RowIndex].Value.ToString();
        }

        private void dataGridViewCellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView.SelectedCells.Count == 0)
            {
                return;
            }

            string newValue = dataGridView[e.ColumnIndex, e.RowIndex].Value.ToString();

            if (double.TryParse(newValue, out double value))
            {
                dataGridView[e.ColumnIndex, e.RowIndex].Value = value.ToString();
                JsonStorage.Configurations[Config.CurrentConfig]["Variables"][dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString()] = value.ToString();
            }
            else
            {
                Messages.RaiseErrorMessage("Введено неверное значение. Пожалуйста, введите число!");
                dataGridView[e.ColumnIndex, e.RowIndex].Value = tempEditedCellValue;
                tempEditedCellValue = null;
            }
        }
    }
}
