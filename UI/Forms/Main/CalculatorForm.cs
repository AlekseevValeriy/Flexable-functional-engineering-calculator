namespace FFEC
{
    internal sealed partial class CalculatorForm : Form
    {
        private ControlsForm controlsForm { get; set; }
        private layoutMenegerForm layoutForm { get; set; }

        private String currentConfiguration { get; set; }

        public CalculatorForm()
        {
            InitializeComponent();
            InitializeConfiguration(JsonStorage.Config["Configuration"].Value<String>());
            InitializePanels();

            controlsForm = new ControlsForm() { Owner = Global.owner };
            layoutForm = new layoutMenegerForm();

            InputController.Update += () => { Handler.UpdateDisplayPanelsRecord(Global.expression, displayTableLayoutPanel); };

            Global.owner = this;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width / 2 - this.Width / 2, Screen.PrimaryScreen.WorkingArea.Height / 2 - this.Height / 2);
        }

        private void InitializeTitle() { if (currentConfiguration is not null) UpdateConfigName(currentConfiguration); }
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
            controlsForm.Owner = Global.owner;
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
        private void AboutToolStripMenuItemClick(object sender, EventArgs e) => new AboutBox() { Owner = Global.owner }.ShowDialog();
        private void FontToolClick(object sender, EventArgs e) => Handler.UpdateControlsFont(controlTableLayoutPanel, displayTableLayoutPanel);
        private void BackgroundColorToolClick(object sender, EventArgs e) => Handler.UpdateControlColor(this);
        private void ControlsFontColorToolClick(object sender, EventArgs e) => Handler.UpdateControlsColor('f', controlTableLayoutPanel, displayTableLayoutPanel);
        private void ControlsBackColorToolClick(object sender, EventArgs e) => Handler.UpdateControlsColor('b', controlTableLayoutPanel, displayTableLayoutPanel);
        private void ControlsBorderColorToolClick(object sender, EventArgs e) => Handler.UpdateControlsColor('r', controlTableLayoutPanel);
        private void ControlsSelectionColorToolClick(object sender, EventArgs e) => Handler.UpdateControlsColor('s', controlTableLayoutPanel);
        private void ControlsPressColorToolClick(object sender, EventArgs e) => Handler.UpdateControlsColor('p', controlTableLayoutPanel);
        private void MenuStripColorToolClick(object sender, EventArgs e) => Handler.UpdateControlColor(menuStrip);
        private void MenuFontToolClick(object sender, EventArgs e) => Handler.UpdateControlFont(menuStrip);
        private void MenuFontColorToolClick(object sender, EventArgs e) => Handler.UpdateControlFontColor(menuStrip);
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
        private void LayoutToolClick(object sender, EventArgs e)
        {
            if (!layoutForm.closed) return;
            layoutForm = new layoutMenegerForm();
            layoutForm.Owner = this;
            layoutForm.Show();
        }

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
        private void ControlPanelsFulledCheck()
        {
            controlsRemoveColumntoolStripMenuItem.Enabled = controlTableLayoutPanel.ColumnCount == 1 ? false : true;
            controlsRemoveRowtoolStripMenuItem.Enabled = controlTableLayoutPanel.RowCount == 1 ? false : true;
        }
        private void DisplayPanelsFulledCheck()
        {
            displayRemoveRowToolStripMenuItem.Enabled = displayTableLayoutPanel.RowCount == 1 ? false : true;
        }

        public void InitializeConfiguration(String configName = "")
        {
            try
            {
                Config.UploadConfigurationInForm
                    (
                        configName,
                        this,
                        menuStrip,
                        splitContainer,
                        displayTableLayoutPanel,
                        controlTableLayoutPanel
                    );
                currentConfiguration = configName;
                InitializeTitle();
            }
            catch (Exception exception)
            {
                MessageBox.Show
                    (
                    caption: "Уведомление",
                    icon: MessageBoxIcon.Information,
                    text: $"Иницилизация конфигурации завершилась неудачно: {exception.Message}",
                    buttons: MessageBoxButtons.OK
                    );
            }
            InitializeMenuStrip();
        }

        public JObject GetConfigData()
        {
            JObject config = new JObject
            {
                ["Global"] = new JObject
                {
                    ["Placement"] = Global.placement.ToString(),
                    ["BorderView"] = Global.borderView
                },

                ["Form"] = new JObject
                {
                    ["Size"] = new JArray(this.Width, this.Height),
                    ["BackColor"] = this.BackColor.Name
                },

                ["SplitContainer"] = new JObject
                {
                    ["SplitterDistance"] = splitContainer.SplitterDistance
                },

                ["TableStructs"] = new JObject
                {
                    ["Display"] = new JArray(displayTableLayoutPanel.RowCount, displayTableLayoutPanel.ColumnCount),
                    ["Controls"] = new JArray(controlTableLayoutPanel.RowCount, controlTableLayoutPanel.ColumnCount)
                },

                ["MenuStrip"] = new JObject
                {
                    ["Font"] = DataSerializer.FontToJObject(menuStrip.Font),
                    ["ForeColor"] = menuStrip.ForeColor.Name,
                    ["BackColor"] = menuStrip.BackColor.Name
                },

                ["DefaultControlStyle"] = new JObject
                {
                    ["Font"] = DataSerializer.FontToJObject(Global.defaultFont),
                    ["ForeColor"] = Global.defaultForeColor.Name,
                    ["BackColor"] = Global.defaultBackColor.Name,
                    ["FlatBorderColor"] = Global.defaultFlatBorderColor.Name,
                    ["FlatMouseDownBackColor"] = Global.defaultFlatDownColor.Name,
                    ["FlatMouseOverBackColor"] = Global.defaultFlatOverColor.Name
                }
            };

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
                            JObject controlData = new JObject
                            {
                                ["Sector"] = ((IDataReceivable)control).JData["Sector"],
                                ["Name"] = ((IDataReceivable)control).JData["Name"],
                                ["PositionByCell"] = new JArray(C, R),
                                ["Placement"] = control.Dock.ToString(),
                                ["Size"] = new JArray(control.Width, control.Height),
                                ["Lock"] = ((IDataStorable)control).Locked
                            };

                            if (((IDataStorable)control).Locked)
                            {
                                controlData["Font"] = DataSerializer.FontToJObject(control.Font);
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
        public void UpdateConfigName(String configName) => this.Text = $"FFEC - {currentConfiguration = configName}";

        private void CalculatorFormClosing(object sender, FormClosingEventArgs e)
        {
            if (currentConfiguration is not null)
            {
                JsonStorage.Config["Configuration"] = currentConfiguration;
                JsonStreamer.WriteConfig(JsonStorage.Config);
            }
        }
    }

}
