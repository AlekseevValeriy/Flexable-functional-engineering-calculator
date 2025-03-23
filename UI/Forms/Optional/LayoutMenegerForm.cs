namespace FFEC
{
    public partial class layoutMenegerForm : Form, ICloseTrackable
    {
        public Boolean closed { get; set; } = true;
        public layoutMenegerForm()
        {
            InitializeComponent();
            this.MaximizeBox = false;
        }

        private void LayoutMenegerLoad(object sender, EventArgs e) => UpdateConfigList();


        private void SetConfiguration(object sender = null, EventArgs e = null)
        {
            try
            {
                ValidateSelectedItem();
                ((CalculatorForm)Owner).InitializeConfiguration(GetSelectedCell());
                ((CalculatorForm)Owner).UpdateConfigName(GetSelectedCell());
            }
            catch (Exception exception) { MessageBox.Show(exception.Message); }
        }

        private void AddConfiguration(object sender = null, EventArgs e = null)
        {
            try
            {
                String name = null;
                GetNameByDialog(ref name);
                if (name is null | name == String.Empty) return;

                Config.Set(name, JObject.Parse(Config.GetDefaultData()));
                Config.Save();
                UpdateConfigList();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void SaveConfiguration(object sender = null, EventArgs e = null)
        {
            try
            {
                ValidateSelectedItem();
                Config.Set(GetSelectedCell(), ((CalculatorForm)Owner).GetConfigData());
                Config.Save();
                UpdateConfigList();
            }
            catch (Exception exception) { MessageBox.Show(exception.Message); }
        }

        private void DeleteAllConfiguration(object sender = null, EventArgs e = null)
        {
            if (Messages.RaiseDeleteAllMessage() is not DialogResult.OK) return;
            try
            {
                foreach (DataGridViewRow configName in dataGridView.Rows)
                {
                    Config.Remove(configName.Cells[0].Value.ToString());
                }
                Config.Save();
            }
            catch (Exception exception) { MessageBox.Show(exception.Message); }
            UpdateConfigList();
        }

        private void RenameConfigurationName(object sender = null, EventArgs e = null)
        {
            try
            {
                ValidateSelectedItem();
                String oldName = GetSelectedCell();
                String newName = null;
                GetNameByDialog(ref newName);
                if (newName is null | newName == String.Empty) return;

                Config.Set(newName, JObject.Parse(Config.LoadConfiguration(oldName)));
                Config.Remove(oldName);

                Config.Save();
            }
            catch (Exception exception) { MessageBox.Show(exception.Message); }
            UpdateConfigList();
        }

        private void DeleteConfiguration(object sender = null, EventArgs e = null)
        {
            try
            {
                ValidateSelectedItem();
                Config.Remove(GetSelectedCell());
                Config.Save();
            }
            catch (Exception exception) { MessageBox.Show(exception.Message); }
            UpdateConfigList();
        }

        private void ValidateSelectedItem()
        {
            if (GetSelectedCell() is null) throw new Exception("Пожалуйста, выберите макет");
        }

        private void GetNameByDialog(ref String name)
        {
            NameEnterForm form = new NameEnterForm() { Owner = this };
            if (form.ShowDialog() is DialogResult.OK) name = form.NewName;
        }
        private void UpdateConfigList()
        {
            dataGridView.Rows.Clear();
            foreach (String configuration in Config.GetList()) dataGridView.Rows.Add(configuration);
        }

        private String? GetSelectedCell()
        {
            Object? value = dataGridView.SelectedCells[0].Value;
            return value is null ? null : value.ToString();
        }

        private void LayoutMenegerFormShown(object sender, EventArgs e)
        {
            Handler.SetSubFormPosition((Form)Owner, this);
        }

        private void KeyDownOfAction(object sender, KeyEventArgs e)
        {
            try
            {
                ValidateSelectedItem();

                if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.Delete: DeleteConfiguration(); break;
                        case Keys.A & Keys.Delete: DeleteAllConfiguration(); break;
                        case Keys.Enter: SetConfiguration(); break;
                        case Keys.S: SaveConfiguration(); break;
                        case Keys.N: AddConfiguration(); break;
                        case Keys.R: RenameConfigurationName(); break;
                    }
                }
            }
            catch (Exception exception) { MessageBox.Show(exception.Message); }
        }
    }
}
