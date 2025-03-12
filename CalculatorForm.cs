namespace FFEC
{
    internal partial class CalculatorForm : Form
    {
        private ControlsForm controlsForm;

        public CalculatorForm()
        {
            //Config.InitializeConfiguration(this, menuStrip, splitContainer, displayTableLayoutPanel, controlTableLayoutPanel);
            InitializeComponent();
            InitializePanels();
            InitializeMenuStrip();
            controlsForm = new ControlsForm();
            InputController.Update += () => { Handler.UpdateDisplayPanelsRecord(Global.expression, displayTableLayoutPanel); };
            Json.SendMessage += (String messageText) => { MessageBox.Show(messageText); };
            //try { MessageBox.Show($"{String.Join(", ", Storage.Configurations.SelectToken($"$.Base.WindowSize").ToObject<List<UInt16>>())}"); }
            //catch (Exception ex) { MessageBox.Show(ex.ToString()); }

        }

        private void InitializePanels()
        {
            FillDisplayPanel();
            FillControlsPanel();
        }

        private void InitializeMenuStrip()
        {
            bordersToolStripMenuItem.Checked = Global.borderView;
            GetToolByStyle(Global.placement).Checked = true;
            DisplayPanelsFulledCheck();
            ControlPanelsFulledCheck();
        }

        private void FillDisplayPanel() => Handler.TablePanelFillCells(displayTableLayoutPanel, Wrap.DisplayPanel);

        private void FillControlsPanel() => Handler.TablePanelFillCells(controlTableLayoutPanel, Wrap.ControlPanel);

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

        private void BackgroundColorToolClick(object sender, EventArgs e)
        {
            Handler.UpdateControlColor(this);
        }

        private void ControlsFontColorToolClick(object sender, EventArgs e)
        {
            Handler.UpdateControlsColor('f', controlTableLayoutPanel, displayTableLayoutPanel); // не ставит -\/('_')\/-
        }
        private void ControlsBackColorToolClick(object sender, EventArgs e)
        {
            Handler.UpdateControlsColor('b', controlTableLayoutPanel, displayTableLayoutPanel); // не ставит -\/('_')\/-
        }
        private void ControlsBorderColorToolClick(object sender, EventArgs e)
        {
            Handler.UpdateControlsColor('r', controlTableLayoutPanel);
        }
        private void ControlsSelectionColorToolClick(object sender, EventArgs e)
        {
            Handler.UpdateControlsColor('s', controlTableLayoutPanel);
        }
        private void ControlsPressColorToolClick(object sender, EventArgs e)
        {
            Handler.UpdateControlsColor('p', controlTableLayoutPanel);
        }

        private void MenuStripColorToolClick(object sender, EventArgs e)
        {
            Handler.UpdateControlColor(menuStrip);
        }
        private void MenuFontToolClick(object sender, EventArgs e)
        {
            Handler.UpdateControlFont(menuStrip);
        }
        private void MenuFontColorToolClick(object sender, EventArgs e)
        {
            Handler.UpdateControlFontColor(menuStrip);
        }

        private void DisplayAddRowToolClick(object sender, EventArgs e)
        {
            Handler.PanelAddRow(displayTableLayoutPanel, sender, e);
            DisplayPanelsFulledCheck();
        }

        private void DisplayRemoveRowToolClick(object sender, EventArgs e)
        {
            Handler.PanelRemoveRow(displayTableLayoutPanel, sender, e);
            DisplayPanelsFulledCheck();
        }

        private void ControlsAddRowToolClick(object sender, EventArgs e)
        {
            Handler.PanelAddRow(controlTableLayoutPanel, sender, e);
            ControlPanelsFulledCheck();
        }

        private void controlsRemoveRowToolClick(object sender, EventArgs e)
        {
            Handler.PanelRemoveRow(controlTableLayoutPanel, sender, e);
            ControlPanelsFulledCheck();
        }

        private void ControlsAddColumnToolClick(object sender, EventArgs e)
        {
            Handler.PanelAddColumn(controlTableLayoutPanel, sender, e);
            ControlPanelsFulledCheck();
        }

        private void ControlsRemoveColumnToolClick(object sender, EventArgs e)
        {
            Handler.PanelRemoveColumn(controlTableLayoutPanel, sender, e);
            ControlPanelsFulledCheck();
        }

        private void ControlPanelsFulledCheck()
        {
            controlsRemoveColumntoolStripMenuItem.Enabled = controlTableLayoutPanel.ColumnCount == 1 ? false : true;
            controlsRemoveRowtoolStripMenuItem.Enabled = controlTableLayoutPanel.RowCount == 1 ? false : true;
        }
        private void DisplayPanelsFulledCheck()
        {
            displayRemoveRowToolStripMenuItem.Enabled = displayTableLayoutPanel.RowCount == 1 ? false : true;
        }


    }
}
