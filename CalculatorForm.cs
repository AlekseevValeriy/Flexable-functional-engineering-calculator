namespace FFEC
{
    internal partial class CalculatorForm : Form
    {
        private ControlsForm controlsForm;
        private LayoutMenegerForm layoutForm;

        private String? currentConfiguration;

        public CalculatorForm()
        {
            InitializeComponent();
            InitializeConfiguration(JsonDataStorage.Config["Configuration"].Value<String>());
            InitializeTitle();
            InitializePanels();
            InitializeMenuStrip();
            controlsForm = new ControlsForm();
            layoutForm = new LayoutMenegerForm();
            InputController.Update += () => { Handler.UpdateDisplayPanelsRecord(Global.expression, displayTableLayoutPanel); };
            JsonStreamer.SendMessage += (String messageText) => { MessageBox.Show(messageText); };
            //try { MessageBox.Show($"{String.Join(", ", Storage.Configurations.SelectToken($"$.Base.WindowSize").ToObject<List<UInt16>>())}"); }
            //catch (Exception ex) { MessageBox.Show(ex.ToString()); }

        }

        private void InitializeTitle()
        {
            if (currentConfiguration is not null) SetConfigName(currentConfiguration);
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
            if (!controlsForm.closed) return;
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

        private void ControlsRemoveRowToolClick(object sender, EventArgs e)
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

        private void LayoutToolClick(object sender, EventArgs e)
        {
            if (!layoutForm.closed) return;
            layoutForm = new LayoutMenegerForm();
            layoutForm.Owner = this;
            layoutForm.Show();
        }

        public void InitializeConfiguration(String configName = "")
        {
            Config.InitializeConfiguration
                (
                    configName,
                    this,
                    menuStrip,
                    splitContainer,
                    displayTableLayoutPanel,
                    controlTableLayoutPanel
                );
            currentConfiguration = configName;
            InitializeMenuStrip();
        }

        public JObject GetConfigData()
        {
            JObject config = new JObject();

            config["Global"] = new JObject();
            config["Global"]["Placement"] = Global.placement.ToString();
            config["Global"]["BorderView"] = Global.borderView;

            config["Form"] = new JObject();
            config["Form"]["Size"] = new JArray(this.Width, this.Height);
            config["Form"]["BackColor"] = this.BackColor.Name;

            config["SplitContainer"] = new JObject();
            config["SplitContainer"]["SplitterDistance"] = splitContainer.SplitterDistance;

            config["TableStructs"] = new JObject();
            config["TableStructs"]["Display"] = new JArray(displayTableLayoutPanel.RowCount, displayTableLayoutPanel.ColumnCount);
            config["TableStructs"]["Controls"] = new JArray(controlTableLayoutPanel.RowCount, controlTableLayoutPanel.ColumnCount);

            config["MenuStrip"] = new JObject();
            config["MenuStrip"]["Font"] = new JObject();
            config["MenuStrip"]["Font"]["Name"] = menuStrip.Font.Name;
            config["MenuStrip"]["Font"]["Size"] = menuStrip.Font.Size;
            config["MenuStrip"]["Font"]["Unit"] = menuStrip.Font.Unit.ToString();
            config["MenuStrip"]["Font"]["Bold"] = menuStrip.Font.Bold;
            config["MenuStrip"]["Font"]["GdiCharSet"] = menuStrip.Font.GdiCharSet;
            config["MenuStrip"]["Font"]["GdiVerticalFont"] = menuStrip.Font.GdiVerticalFont;
            config["MenuStrip"]["Font"]["Italic"] = menuStrip.Font.Italic;
            config["MenuStrip"]["Font"]["Strikeout"] = menuStrip.Font.Strikeout;
            config["MenuStrip"]["Font"]["Underline"] = menuStrip.Font.Underline;
            config["MenuStrip"]["ForeColor"] = menuStrip.ForeColor.Name;
            config["MenuStrip"]["BackColor"] = menuStrip.BackColor.Name;

            config["DefaultControlStyle"] = new JObject();
            config["DefaultControlStyle"]["Font"] = Config.JObjectByFont(Global.defaultFont);
            config["DefaultControlStyle"]["ForeColor"] = Global.defaultForeColor.Name;
            config["DefaultControlStyle"]["BackColor"] = Global.defaultBackColor.Name;
            config["DefaultControlStyle"]["FlatBorderColor"] = Global.defaultFlatBorderColor.Name;
            config["DefaultControlStyle"]["FlatMouseDownBackColor"] = Global.defaultFlatDownColor.Name;
            config["DefaultControlStyle"]["FlatMouseOverBackColor"] = Global.defaultFlatOverColor.Name;

            JArray controlsArray = new JArray();

            TableLayoutPanel[] tables = new TableLayoutPanel[] { displayTableLayoutPanel, controlTableLayoutPanel };

            foreach (TableLayoutPanel table in tables)
            {
                for (Byte R = 0; R < table.RowCount; R++)
                {
                    for (Byte C = 0; C < table.ColumnCount; C++)
                    {
                        if (table.GetControlFromPosition(C, R).Controls.Count != 0)
                        {
                            Control control = table.GetControlFromPosition(C, R).Controls[0];
                            JObject controlData = new JObject();
                            controlData["Sector"] = ((IDataReceivable)control).JData["Sector"];
                            controlData["Name"] = ((IDataReceivable)control).JData["Name"];
                            controlData["PositionByCell"] = new JArray(C, R);
                            controlData["Placement"] = control.Dock.ToString();
                            controlData["Size"] = new JArray(control.Width, control.Height);
                            controlData["Lock"] = ((IDataStorable)control).Locked;

                            if (((IDataStorable)control).Locked)
                            {
                                controlData["Font"] = Config.JObjectByFont(control.Font);
                                controlData["ForeColor"] = control.ForeColor.Name;
                                controlData["BackColor"] = control.BackColor.Name;
                                if (table.Name != "displayTableLayoutPanel")
                                {
                                    controlData["FlatBorderColor"] = ((Button)control).FlatAppearance.BorderColor.Name;
                                    controlData["FlatMouseDownBackColor"] = ((Button)control).FlatAppearance.MouseDownBackColor.Name;
                                    controlData["FlatMouseOverBackColor"] = ((Button)control).FlatAppearance.MouseOverBackColor.Name;
                                }
                            }

                            controlsArray.Add(controlData);
                        }
                    }
                }
            }

            config["ControlsLayout"] = controlsArray;

            return config;
        }
        public void SetConfigName(String configName) => this.Text = $"FFEC - {currentConfiguration = configName}";

        private void CalculatorFormClosing(object sender, FormClosingEventArgs e)
        {
            if (currentConfiguration is not null)
            {
                JsonDataStorage.Config["Configuration"] = currentConfiguration;
                JsonStreamer.WriteConfig(JsonDataStorage.Config);
            }
        }
    }

}
