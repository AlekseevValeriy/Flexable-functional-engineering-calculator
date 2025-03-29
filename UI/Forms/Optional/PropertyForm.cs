namespace FFEC
{
    public partial class PropertyForm : Form
    {
        public PropertyForm()
        {
            InitializeComponent();
        }
        public void AddLines(Dictionary<string, string> data)
        {
            foreach (KeyValuePair<string, string> valuePair in data)
            {
                AddLine(valuePair.Key, valuePair.Value);
            }

            SetSize();
        }
        private void SetSize() { Size newSize = dataGridView.PreferredSize; this.MinimumSize = newSize; }
        public void AddLine(string property, string data)
        {
            dataGridView.Rows.Add(property, data);
        }

        private void FormShown(object sender, EventArgs e)
        {
            Handler.SetSubFormPosition(Owner, this);
        }
    }

}
