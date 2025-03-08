using FFEC;

namespace FFEC
{
    internal partial class CalculatorForm : Form
    {
        private ControlsForm controlsForm;

        public CalculatorForm()
        {
            InitializeComponent();
            InitializePanels();
            bordersToolStripMenuItem.Checked = Global.borderView;
            controlsForm = new ControlsForm();
            GetToolByStyle(Global.placement).Checked = true;

            InputController.Update += () => { Handler.UpdateDisplayPanelsRecord(Global.expression, displayTableLayoutPanel); };
        }

        private void InitializePanels()
        {
            FillDisplayPanel();
            FillControlsPanel();
        }

        private void FillDisplayPanel() => Handler.TablePanelFillCells(ref displayTableLayoutPanel, Wrap.DisplayPanel);

        private void FillControlsPanel() => Handler.TablePanelFillCells(ref controlTableLayoutPanel, Wrap.ControlPanel);

        private void ControlToolClick(object sender, EventArgs e)
        {
            if (!controlsForm.IsClosed) return;
            controlsForm = new ControlsForm();
            controlsForm.Show();
        }

        private void BordersToolClick(object sender, EventArgs e)
        { 
            bordersToolStripMenuItem.Checked = Global.borderView = !Global.borderView;
            Handler.UpdateControlsBorderView(controlTableLayoutPanel, displayTableLayoutPanel);
        }

        private void NoneToolClick(object sender, EventArgs e) => CheckedCurrentPlacementTools(DockStyle.None);

        private void TopToolClick(object sender, EventArgs e) => CheckedCurrentPlacementTools(DockStyle.Top);

        private void BottomToolClick(object sender, EventArgs e) => CheckedCurrentPlacementTools(DockStyle.Bottom);

        private void RightToolClick(object sender, EventArgs e) => CheckedCurrentPlacementTools(DockStyle.Right);

        private void LeftToolClick(object sender, EventArgs e) => CheckedCurrentPlacementTools(DockStyle.Left);

        private void FillToolClick(object sender, EventArgs e) => CheckedCurrentPlacementTools(DockStyle.Fill);

        private void CheckedCurrentPlacementTools(DockStyle style)
        {
            foreach (ToolStripMenuItem iitem in placementToolStripMenuItem.DropDownItems) iitem.Checked = false;
            GetToolByStyle(style).Checked = true;
            Global.placement = style;
            Handler.UpdateControlsPlacement(controlTableLayoutPanel, displayTableLayoutPanel);
        }

        private ToolStripMenuItem GetToolByStyle(DockStyle style)
        {
            return style switch
            {
                DockStyle.Top => topToolStripMenuItem,
                DockStyle.Bottom => bottomToolStripMenuItem,
                DockStyle.Left => leftToolStripMenuItem,
                DockStyle.Right => rightToolStripMenuItem,
                DockStyle.Fill => fillToolStripMenuItem,
                DockStyle.None or _ => noneToolStripMenuItem
            };
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }

        private void FontToolClick(object sender, EventArgs e)
        {
            Handler.UpdateControlsFont(controlTableLayoutPanel, displayTableLayoutPanel);
        }

        private void FontColorToolClick(object sender, EventArgs e)
        {
            Handler.UpdateControlsColor('f', controlTableLayoutPanel, displayTableLayoutPanel);
        }

        private void BackgroundColorToolClick(object sender, EventArgs e)
        {
            Handler.UpdateControlColor(this);
        }

        private void ControlsColorToolClick(object sender, EventArgs e)
        {
            Handler.UpdateControlsColor('b', controlTableLayoutPanel, displayTableLayoutPanel);
        }

        private void MenuStripColorToolClick(object sender, EventArgs e)
        {
            Handler.UpdateControlColor(menuStrip);
        }
    }
}
