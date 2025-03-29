namespace FFEC
{
    public partial class NameEnterForm : Form
    {
        public NameEnterForm()
        {
            InitializeComponent();
        }
        public string? GetName()
        {
            return nameTextBox.Text != "" ? nameTextBox.Text : null;
        }
        private void FormShown(object sender, EventArgs e)
        {
            Handler.SetSubFormPosition(Owner, this, customX: Owner.Location.X + (Owner.Size.Width / 2) - (this.Width / 2));
        }
    }
}
