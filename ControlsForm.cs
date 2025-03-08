using System.Windows.Forms;

namespace FFEC
{
    public partial class ControlsForm : Form
    {
        public Boolean IsClosed { get; private set; } = true;
        public ControlsForm() // panic
        {
            InitializeComponent();

            foreach (KeyValuePair<String, Dictionary<String, String>> sector in Storage.GetControlsData())
            {
                TabPage tab = new TabPage(sector.Key);

                IRemovableGenerator generator = sector.Key != "Display" ? NewButton : NewTextBox;

                FlowLayoutPanel flowPanel = new FlowLayoutPanel() { Dock = DockStyle.Fill, AutoScroll = true };
                foreach (KeyValuePair<String, String> controlPair in sector.Value)
                {
                    GroupBox groupBox = new GroupBox() { Text = controlPair.Key, Width = 150, Height = 80 };
                    IRemoveable control = generator(sector.Key, controlPair, groupBox.Size);
                    groupBox.Controls.Add(Wrap.DragDrop((Control)control));
                    flowPanel.Controls.Add(groupBox);
                }
                tab.Controls.Add(flowPanel);

                tabControl.TabPages.Add(tab);
            }

        }
        IRemoveable NewButton(String sector, KeyValuePair<String, String> data, System.Drawing.Size boxSize)
        {
            SButton button = new SButton() { Data = new string[] { sector, data.Key }, Text = data.Value };
            button.Location = new System.Drawing.Point(
                (boxSize.Width / 2) - (button.Size.Width / 2),
                (boxSize.Height / 2) - (button.Size.Height / 2));
            return button;
        }

        IRemoveable NewTextBox(String sector, KeyValuePair<String, String> data, System.Drawing.Size boxSize)
        {
            STextBox textBox = new STextBox() { Data = new string[] { sector, data.Key }, ReadOnly = true };
            textBox.Location = new System.Drawing.Point(
                (boxSize.Width / 2) - (textBox.Size.Width / 2),
                (boxSize.Height / 2) - (textBox.Size.Height / 2));
            return textBox;
        }

        private delegate IRemoveable IRemovableGenerator(String sector, KeyValuePair<String, String> data, System.Drawing.Size boxSize);

        private void ControlsFormClosed(object sender, FormClosedEventArgs e) => IsClosed = true;
        private void ControlsFormShown(object sender, EventArgs e) => IsClosed = false;

    }
}
