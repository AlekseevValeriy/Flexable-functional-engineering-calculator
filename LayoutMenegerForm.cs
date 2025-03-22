namespace FFEC
{
    public partial class LayoutMenegerForm : Form, ICloseTrackable
    {
        public Boolean closed { get; set; } = true;
        public LayoutMenegerForm()
        {
            InitializeComponent();
        }

        private void LayoutMenegerLoad(object sender, EventArgs e) => UpdateConfigList();


        private void SetConfiguration(object sender, EventArgs e)
        {
            try
            {
                ValidateSelectedItem();
                ((CalculatorForm)Owner).InitializeConfiguration(layoutsListBox.SelectedItem.ToString());
                ((CalculatorForm)Owner).SetConfigName(layoutsListBox.SelectedItem.ToString());
            }
            catch (Exception exception) { MessageBox.Show(exception.Message); }
        }

        private void AddConfiguration(object sender, EventArgs e)
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

        private void SaveConfiguration(object sender, EventArgs e)
        {
            try
            {
                ValidateSelectedItem();
                Config.Set(layoutsListBox.SelectedItem.ToString(), ((CalculatorForm)Owner).GetConfigData());
                Config.Save();
                UpdateConfigList();
            }
            catch (Exception exception) { MessageBox.Show(exception.Message); }
        }

        private void DeleteConfiguration(object sender, EventArgs e)
        {
            try
            {
                ValidateSelectedItem();
                Config.Remove(layoutsListBox.SelectedItem.ToString());
                Config.Save();
            }
            catch (Exception exception) { MessageBox.Show(exception.Message); }
            UpdateConfigList();
        }

        private void ValidateSelectedItem()
        {
            if (layoutsListBox.SelectedItem is null) throw new Exception("Пожалуйста, выберите макет");
        }

        private void GetNameByDialog(ref String name)
        {
            NameEnterForm form = new NameEnterForm();
            if (form.ShowDialog() is DialogResult.OK) name = form.NewName;
        }
        private void UpdateConfigList()
        {
            layoutsListBox.Items.Clear();
            foreach (String configuration in Config.GetList()) layoutsListBox.Items.Add(configuration);
        }
    }
}
