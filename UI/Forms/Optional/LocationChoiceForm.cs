using System.Data;

namespace FFEC
{
    public partial class LocationChoiceForm : Form
    {
        private Control control { get; }
        public LocationChoiceForm(Control control)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.control = control;
            comboBox.Items.AddRange(Enum.GetValues(typeof(DockStyle)).Cast<Object>().ToArray());
            comboBox.Text = control.Dock.ToString();
        }

        private void LocationChoiceForm_Shown(object sender, EventArgs e)
        {
            Handler.SetSubFormPosition((Form)Owner, this);
        }

        private void SelectedValueChanged(object sender, EventArgs e)
        {
            control.Dock = (DockStyle)comboBox.SelectedItem;
        }
    }
}
