using System.Data;

namespace FFEC
{
    public partial class LocationChoiceForm : Form
    {
        private Control control { get; }
        public LocationChoiceForm(Control control)
        {
            InitializeComponent();
            this.control = control;
            locationComboBox.Items.AddRange(Enum.GetValues(typeof(DockStyle)).Cast<object>().ToArray());
            locationComboBox.Text = control.Dock.ToString();
        }

        private void SelectedValueChanged(object sender, EventArgs e)
        {
            control.Dock = (DockStyle)locationComboBox.SelectedItem;
        }

        private void FormShown(object sender, EventArgs e)
        {
            Handler.SetSubFormPosition(Owner, this);
        }
    }
}
