namespace FFEC
{
    public partial class PropertyForm : Form
    {
        public PropertyForm()
        {
            InitializeComponent();
            this.Size = dataGridView1.ClientSize;
        }

        public void AddLine(String property, String data)
        {
            dataGridView1.Rows.Add(property, data);
        }
    }

}
