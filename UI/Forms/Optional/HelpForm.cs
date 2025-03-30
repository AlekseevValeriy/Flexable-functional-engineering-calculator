namespace FFEC.UI.Forms.Optional
{
    public partial class HelpForm : Form, ICloseTrackable
    {
        public bool closed { get; set; } = true;
        public HelpForm()
        {
            InitializeComponent();
        }
    }
}
