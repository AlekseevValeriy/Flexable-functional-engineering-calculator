namespace FFEC
{
    public partial class NameEnterForm : Form
    {
        public NameEnterForm()
        {
            InitializeComponent();
        }

        public String NewName { get => textBox1.Text; }
    }
}
