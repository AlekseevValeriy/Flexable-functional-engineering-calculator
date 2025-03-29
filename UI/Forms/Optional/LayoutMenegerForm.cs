using FFEC.UI.Forms.Optional;

namespace FFEC
{
    public partial class LayoutMenegerForm : Form, ICloseTrackable
    {
        public bool closed { get; set; } = true;
        public Dictionary<string, Form> SubOwners { get; set; } = [];
        public LayoutMenegerForm()
        {
            InitializeComponent();
        }


        private void LayoutMenegerLoad(object sender, EventArgs e)
        {
            UpdateConfigList();
        }

        private void SetConfiguration(object sender = null, EventArgs e = null)
        {
            try
            {
                ValidateSelectedItem();
                (Owner as CalculatorForm).InitializeConfiguration(GetSelectedCell());
                (Owner as CalculatorForm).UpdateConfigName(GetSelectedCell());
                UpdateInSubOwners();
            }
            catch (InformationException exception) { Messages.RaiseInformationMessage(exception.Message); }
            catch (Exception exception) { Messages.RaiseExceptionMessage(exception.Message); }
        }

        private void AddConfiguration(object sender = null, EventArgs e = null)
        {
            try
            {
                string name = null;
                GetNameByDialog(ref name);
                if (name is null | name == string.Empty)
                {
                    return;
                }

                Config.Set(name, JObject.Parse(Config.GetDefaultData()));
                Config.Save();
                UpdateConfigList();
            }
            catch (InformationException exception) { Messages.RaiseInformationMessage(exception.Message); }
            catch (Exception exception) { Messages.RaiseExceptionMessage(exception.Message); }
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
            catch (InformationException exception) { Messages.RaiseInformationMessage(exception.Message); }
            catch (Exception exception) { Messages.RaiseExceptionMessage(exception.Message); }
        }

        private void DeleteAllConfiguration(object sender = null, EventArgs e = null)
        {
            if (Messages.RaiseDeleteAllMessage() is not DialogResult.OK)
            {
                return;
            }

            try
            {
                foreach (DataGridViewRow configName in dataGridView.Rows)
                {
                    Config.Remove(configName.Cells[0].Value.ToString());
                }
                Config.Save();
            }
            catch (InformationException exception) { Messages.RaiseInformationMessage(exception.Message); }
            catch (Exception exception) { Messages.RaiseExceptionMessage(exception.Message); }
            UpdateConfigList();
        }

        private void RenameConfigurationName(object sender = null, EventArgs e = null)
        {
            try
            {
                ValidateSelectedItem();
                string oldName = GetSelectedCell();
                string newName = null;
                GetNameByDialog(ref newName);
                if (newName is null | newName == string.Empty)
                {
                    return;
                }

                Config.Set(newName, JObject.Parse(Config.LoadConfiguration(oldName)));
                Config.Remove(oldName);

                Config.Save();
            }
            catch (InformationException exception) { Messages.RaiseInformationMessage(exception.Message); }
            catch (Exception exception) { Messages.RaiseExceptionMessage(exception.Message); }
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
            catch (InformationException exception) { Messages.RaiseInformationMessage(exception.Message); }
            catch (Exception exception) { Messages.RaiseExceptionMessage(exception.Message); }
            UpdateConfigList();
        }
        private void ValidateSelectedItem()
        {
            if (GetSelectedCell() is null)
            {
                throw new InformationException("Пожалуйста, выберите макет");
            }
        }
        private void GetNameByDialog(ref string name)
        {
            NameEnterForm form = new NameEnterForm() { Owner = this };
            if (form.ShowDialog() is DialogResult.OK)
            {
                name = form.GetName();
            }
        }
        private void UpdateConfigList()
        {
            dataGridView.Rows.Clear();
            foreach (string configuration in Config.GetList())
            {
                dataGridView.Rows.Add(configuration);
            }
        }
        private string GetSelectedCell()
        {
            return dataGridView.SelectedCells[0].Value?.ToString();
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
                        case Keys.A: DeleteAllConfiguration(); break;
                        case Keys.Enter: SetConfiguration(); break;
                        case Keys.S: SaveConfiguration(); break;
                        case Keys.N: AddConfiguration(); break;
                        case Keys.R: RenameConfigurationName(); break;
                    }
                }
            }
            catch (InformationException exception) { Messages.RaiseInformationMessage(exception.Message); }
            catch (Exception exception) { Messages.RaiseExceptionMessage(exception.Message); }
        }
        private void FormShown(object sender, EventArgs e)
        {
            Handler.SetSubFormPosition(Owner, this);
        }

        private void UpdateInSubOwners()
        {
            if (SubOwners["Controls"] is ControlsForm controls && !controls.closed)
            {
                controls.UpdateRequiredTabs();
            }

            if (SubOwners["Variables"] is VariablesForm variables && !variables.closed)
            {
                variables.UpdateVariables();
            }
        }
    }

    internal class InformationException : Exception
    {
        public InformationException(string text) : base(text) { }
    }
}
