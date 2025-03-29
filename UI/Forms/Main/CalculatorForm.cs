using FFEC.UI.Forms.Optional;

namespace FFEC
{
    internal sealed partial class CalculatorForm : Form
    {

        private ControlsForm ControlsForm { get; set; }
        private LayoutMenegerForm LayoutForm { get; set; }
        private VariablesForm VariablesForm { get; set; }
        private FunctionEnter FunctionEnterForm { get; set; }

        private string currentConfiguration { get; set; }

        public CalculatorForm()
        {
            InitializeComponent();
            InitializeOwnedForms();
            InitializeConfiguration(JsonStorage.Config["Configuration"].Value<string>());
            InitializePanels();

            UpdateVariablesOnPanel();

            InputController.Update += UpdateMainDisplay;

            Global.owner = this;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width / 2) - (this.Width / 2), (Screen.PrimaryScreen.WorkingArea.Height / 2) - (this.Height / 2));
        }

        private void UpdateMainDisplay()
        {
            Handler.UpdateDisplayPanelsRecord(Global.expression, displayTableLayoutPanel);
        }

        private void UpdateFunctionEnterDisplay()
        {
            Handler.UpdateDisplayRecord(Global.expression, FunctionEnterForm.Display);
        }

        private void InitializeOwnedForms()
        {
            ControlsForm = new ControlsForm() { Owner = Global.owner };
            LayoutForm = new LayoutMenegerForm() { Owner = Global.owner, SubOwners = new Dictionary<string, Form> { { "Controls", ControlsForm }, { "Variables", VariablesForm } } };
            VariablesForm = new VariablesForm() { Owner = Global.owner, SubOwners = new Dictionary<string, Form> { { "Controls", ControlsForm } } };
            FunctionEnterForm = new FunctionEnter() { Owner = this };
        }

        private void InitializeTitle()
        {
            if (currentConfiguration is not null)
            {
                UpdateConfigName(currentConfiguration);
            }
        }
        private void InitializePanels()
        {
            FillDisplayPanel();
            FillControlsPanel();
        }
        private void InitializeMenuStrip()
        {
            bordersToolStripMenuItem.Checked = Global.borderView;

            CheckedCurrentPlacementTools(Global.placement);

            DisplayPanelsFulledCheck();
            ControlPanelsFulledCheck();
        }
        private void FillDisplayPanel()
        {
            Handler.TablePanelFillCells(displayTableLayoutPanel, Wrap.DisplayPanel);
        }

        private void FillControlsPanel()
        {
            Handler.TablePanelFillCells(controlTableLayoutPanel, Wrap.ControlPanel);
        }

        private void ControlToolClick(object sender, EventArgs e)
        {

            if (!ControlsForm.closed)
            {
                return;
            }

            ControlsForm = new ControlsForm() { Owner = Global.owner };
            ControlsForm.Show();
        }

        private void LayoutToolClick(object sender, EventArgs e)
        {
            if (!LayoutForm.closed)
            {
                return;
            }

            LayoutForm = new LayoutMenegerForm() { Owner = Global.owner, SubOwners = new Dictionary<string, Form> { { "Controls", ControlsForm }, { "Variables", VariablesForm } } };
            LayoutForm.Show();
        }

        private void VariablesToolClick(object sender, EventArgs e)
        {
            if (!VariablesForm.closed)
            {
                return;
            }

            VariablesForm = new VariablesForm() { Owner = Global.owner, SubOwners = new Dictionary<string, Form> { { "Controls", ControlsForm } } };
            VariablesForm.Show();
        }


        private void BordersToolClick(object sender, EventArgs e)
        {
            bordersToolStripMenuItem.Checked = Global.borderView = !Global.borderView;
            Handler.UpdateControlsBorderView(controlTableLayoutPanel, displayTableLayoutPanel);
        }
        private void NoneToolClick(object sender, EventArgs e)
        {
            CheckedCurrentPlacementTools(DockStyle.None);
        }

        private void TopToolClick(object sender, EventArgs e)
        {
            CheckedCurrentPlacementTools(DockStyle.Top);
        }

        private void BottomToolClick(object sender, EventArgs e)
        {
            CheckedCurrentPlacementTools(DockStyle.Bottom);
        }

        private void RightToolClick(object sender, EventArgs e)
        {
            CheckedCurrentPlacementTools(DockStyle.Right);
        }

        private void LeftToolClick(object sender, EventArgs e)
        {
            CheckedCurrentPlacementTools(DockStyle.Left);
        }

        private void FillToolClick(object sender, EventArgs e)
        {
            CheckedCurrentPlacementTools(DockStyle.Fill);
        }

        private void AboutToolStripMenuItemClick(object sender, EventArgs e)
        {
            new AboutBox() { Owner = Global.owner }.ShowDialog();
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
            Handler.UpdateControlsColor('f', controlTableLayoutPanel, displayTableLayoutPanel);
        }

        private void ControlsBackColorToolClick(object sender, EventArgs e)
        {
            Handler.UpdateControlsColor('b', controlTableLayoutPanel, displayTableLayoutPanel);
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

        private void CheckedCurrentPlacementTools(DockStyle style)
        {
            foreach (ToolStripMenuItem iitem in dockMenuItem.DropDownItems)
            {
                iitem.Checked = false;
            }

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
            controlsRemoveColumntoolStripMenuItem.Enabled = controlTableLayoutPanel.ColumnCount != 1;
            controlsRemoveRowtoolStripMenuItem.Enabled = controlTableLayoutPanel.RowCount != 1;
        }
        private void DisplayPanelsFulledCheck()
        {
            displayRemoveRowToolStripMenuItem.Enabled = displayTableLayoutPanel.RowCount != 1;
        }

        public void InitializeConfiguration(string configName = "")
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
                string cfgName = configName;
                if (cfgName != "")
                {
                    JsonStorage.Config["Configuration"] = cfgName;
                    Config.UpdateCurrentConfig();
                    currentConfiguration = cfgName;
                    InitializeTitle();
                }
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

                ["Variables"] = JsonStorage.Configurations[currentConfiguration]["Variables"],

                ["CustomFunctions"] = JsonStorage.Configurations[currentConfiguration]["CustomFunctions"],

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
                    ["Font"] = DataConverter.FontToJObject(menuStrip.Font),
                    ["ForeColor"] = menuStrip.ForeColor.Name,
                    ["BackColor"] = menuStrip.BackColor.Name
                },

                ["DefaultControlStyle"] = new JObject
                {
                    ["Font"] = DataConverter.FontToJObject(Global.defaultFont),
                    ["ForeColor"] = Global.defaultForeColor.Name,
                    ["BackColor"] = Global.defaultBackColor.Name,
                    ["FlatBorderColor"] = Global.defaultFlatBorderColor.Name,
                    ["FlatMouseDownBackColor"] = Global.defaultFlatDownColor.Name,
                    ["FlatMouseOverBackColor"] = Global.defaultFlatOverColor.Name
                }
            };

            JArray controlsArray = [];

            TableLayoutPanel[] tables = new TableLayoutPanel[] { displayTableLayoutPanel, controlTableLayoutPanel };

            foreach (TableLayoutPanel table in tables)
            {
                for (byte R = 0; R < table.RowCount; R++)
                {
                    for (byte C = 0; C < table.ColumnCount; C++)
                    {
                        if (table.GetControlFromPosition(C, R).Controls.Count != 0)
                        {
                            Control control = table.GetControlFromPosition(C, R).Controls[0];
                            JObject controlData = new JObject
                            {
                                ["Sector"] = (control as IDataReceivable).JData["Sector"],
                                ["Name"] = (control as IDataReceivable).JData["Name"],
                                ["PositionByCell"] = new JArray(C, R),
                                ["Placement"] = control.Dock.ToString(),
                                ["Size"] = new JArray(control.Width, control.Height),
                                ["Lock"] = (control as IDataStorable).Locked
                            };

                            if (((IDataStorable)control).Locked)
                            {
                                controlData["Font"] = DataConverter.FontToJObject(control.Font);
                                controlData["ForeColor"] = control.ForeColor.Name;
                                controlData["BackColor"] = control.BackColor.Name;
                                if (table.Name != "displayTableLayoutPanel")
                                {
                                    controlData["FlatBorderColor"] = (control as Button).FlatAppearance.BorderColor.Name;
                                    controlData["FlatMouseDownBackColor"] = (control as Button).FlatAppearance.MouseDownBackColor.Name;
                                    controlData["FlatMouseOverBackColor"] = (control as Button).FlatAppearance.MouseOverBackColor.Name;
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
        public void UpdateConfigName(string configName)
        {
            this.Text = $"FFEC - {currentConfiguration = configName}";
        }

        private void CalculatorFormClosing(object sender, FormClosingEventArgs e)
        {
            if (currentConfiguration is not null)
            {
                JsonStorage.Config["Configuration"] = currentConfiguration;
                JsonStreamer.WriteConfigurations(JsonStorage.Configurations);
                JsonStreamer.WriteConfig(JsonStorage.Config);
            }
        }

        public void UpdateVariablesOnPanel()
        {
            TableLayoutControlCollection controls = controlTableLayoutPanel.Controls;
            if (controls.Count == 0)
            {
                return;
            }

            List<string> variableNames = Config.GetVariableNames();

            foreach (Control control in controls)
            {
                if (control is Panel panel && panel.Controls.Count != 0)
                {
                    if (panel.Controls[0] is SButton button && button.JData["Sector"].Value<string>() == "Variables")
                    {
                        if (!variableNames.Contains(button.JData["Name"].Value<string>()))
                        {
                            panel.Controls.Remove(button);
                        }
                    }
                }

            }
        }

        private void saveLayoutClick(object sender, EventArgs e)
        {
            try
            {
                Config.Set(currentConfiguration, GetConfigData());
                Config.Save();
            }
            catch (InformationException exception) { Messages.RaiseInformationMessage(exception.Message); }
            catch (Exception exception) { Messages.RaiseExceptionMessage(exception.Message); }
        }

        public void functionAddStart(object sender = null, EventArgs e = null)
        {
            if (!FunctionEnterForm.closed)
            {
                return;
            }

            FunctionEnterForm = new FunctionEnter() { Owner = this };
            FunctionEnterForm.Show();

            Global.expression.Clear();
            InputController.UpdateDisplay();
            InputController.Update -= UpdateMainDisplay;
            InputController.Update += UpdateFunctionEnterDisplay;


            //InputController.Update += UpdateDisplay;
        }

        public void functionAddEnd(object sender = null, EventArgs e = null)
        {
            if ((sender as FunctionEnter).DialogResult is DialogResult.OK)
            {
                JsonStorage.Configurations[Config.CurrentConfig]["CustomFunctions"][(sender as FunctionEnter).FunctionName] = Output.ExpressionToManual(Global.expression);
            }

            InputController.Update -= UpdateFunctionEnterDisplay;
            InputController.Update += UpdateMainDisplay;
            Global.expression.Clear();
        }
    }

}
