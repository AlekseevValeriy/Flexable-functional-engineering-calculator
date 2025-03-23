namespace FFEC
{
    public partial class NameEnterForm : Form
    {
        public NameEnterForm()
        {
            InitializeComponent();
            this.MaximizeBox = false;
        }

        public String NewName { get => textBox1.Text; }

        private void NameEnterForm_Shown(object sender, EventArgs e)
        {
            Handler.SetSubFormPosition((Form)Owner, this, customX: ((Form)Owner).Location.X + ((Form)Owner).Size.Width / 2 - this.Width / 2);
        }
    }
}
