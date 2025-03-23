namespace FFEC
{
    public partial class PropertyForm : Form
    {
        public PropertyForm()
        {
            InitializeComponent();
            this.MaximizeBox = false;
        }

        public void AddLines(Dictionary<String, String> data)
        {
            foreach (KeyValuePair<String, String> valuePair in data) AddLine(valuePair.Key, valuePair.Value);
            SetSize();
        }

        public void AddLine(String property, String data)
        {
            dataGridView1.Rows.Add(property, data);

        }

        private void SetSize()
        {
            Size newSize = dataGridView1.PreferredSize;
            this.MinimumSize = newSize;
        }

        private void PropertyForm_Shown(object sender, EventArgs e)
        {
            Handler.SetSubFormPosition((Form)Owner, this);
        }
    }

}
