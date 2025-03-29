namespace FFEC
{
    internal static class Handler
    {
        public static void ControlDoDragDrop(object sender, MouseEventArgs e)
        {
            ((Control)sender).DoDragDrop(((IDataTransmitable)sender).GetImportData(), DragDropEffects.Copy | DragDropEffects.Move);
        }

        public static void ControlDoDragDropModifierConside(object sender, MouseEventArgs e)
        {
            if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
            {
                JObject importData = ((IDataTransmitable)sender).GetOriginalImportData();
                TableLayoutPanelCellPosition controlPosition = ((TableLayoutPanel)((Panel)((Control)sender).Parent).Parent).GetCellPosition((Panel)((Control)sender).Parent);

                importData["PreviousPosition"] = new JArray(controlPosition.Column, controlPosition.Row);
                ((Control)sender).DoDragDrop(importData.ToString(), DragDropEffects.Copy | DragDropEffects.Move);

            }
        }

        public static bool DisplayValidate(DragEventArgs e)
        {
            return DragEventArgsToDrop(e)["Sector"].Value<string>() == "Display";
        }

        public static bool ControlValidate(DragEventArgs e)
        {
            return DragEventArgsToDrop(e)["Sector"].Value<string>() != "Display";
        }

        public static ConverterToStringByRule GetRuleByData(JObject data)
        {
            return data["Name"].Value<string>() switch
            {
                "Base" => Output.ExpressionToRecord,
                _ => (List<Composite> expression, bool debug) => ""
            };
        }

        public static EventHandler GetActionByButtonData(JObject data)
        {
            string sector = data["Sector"].Value<string>(), name = data["Name"].Value<string>();
            EventHandler handler = sector switch
            {
                "Numbers" => name switch
                {
                    "Zero" => (object sender, EventArgs e) => { InputController.Append(Global.expression, new Term("0")); }
                    ,
                    "One" => (object sender, EventArgs e) => { InputController.Append(Global.expression, new Term("1")); }
                    ,
                    "Two" => (object sender, EventArgs e) => { InputController.Append(Global.expression, new Term("2")); }
                    ,
                    "Three" => (object sender, EventArgs e) => { InputController.Append(Global.expression, new Term("3")); }
                    ,
                    "Four" => (object sender, EventArgs e) => { InputController.Append(Global.expression, new Term("4")); }
                    ,
                    "Five" => (object sender, EventArgs e) => { InputController.Append(Global.expression, new Term("5")); }
                    ,
                    "Six" => (object sender, EventArgs e) => { InputController.Append(Global.expression, new Term("6")); }
                    ,
                    "Seven" => (object sender, EventArgs e) => { InputController.Append(Global.expression, new Term("7")); }
                    ,
                    "Eight" => (object sender, EventArgs e) => { InputController.Append(Global.expression, new Term("8")); }
                    ,
                    "Nine" => (object sender, EventArgs e) => { InputController.Append(Global.expression, new Term("9")); }
                    ,
                    "Pi" => (object sender, EventArgs e) => { InputController.Append(Global.expression, new Constanta(Math.PI.ToString())); }
                    ,
                    "E" => (object sender, EventArgs e) => { InputController.Append(Global.expression, new Constanta(Math.E.ToString())); }
                    ,
                    _ => (object sender, EventArgs e) => { }
                },
                "Actions" => name switch
                {
                    "ToDouble" => (object sender, EventArgs e) => { InputController.Append(Global.expression, new Comma()); }
                    ,
                    "Backspace" => (object sender, EventArgs e) => { InputController.DeleteLast(Global.expression); }
                    ,
                    "Equally" => (object sender, EventArgs e) =>
                    {
                        try
                        {
                            InputController.Equally(ref Global.expression);
                        }
                        catch (DivideByZeroException)
                        {
                            byte jokesCount = (byte)JsonStorage.Egg["ZeroDivisionHumiliation"].Count();
                            while (Messages.RaiseJokeMessage(JsonStorage.Egg["ZeroDivisionHumiliation"][Global.random.Next(0, jokesCount)].Value<string>()) is not DialogResult.Cancel)
                            {
                                Global.expression.Clear();
                            }

                            InputController.Equally(ref Global.expression);
                        }
                    }
                    ,
                    "Clear" => (object sender, EventArgs e) => { InputController.ClearAll(Global.expression); }
                    ,
                    "ClearElement" => (object sender, EventArgs e) => { InputController.ClearOne(Global.expression); }
                    ,
                    "ChangeSign" => (object sender, EventArgs e) => { InputController.ChangeSign(Global.expression); }
                    ,
                    "Parenthesis" => (object sender, EventArgs e) => { InputController.Append(Global.expression, new Staples()); }
                    ,
                    "CloseFunctionWrite" => (object sender, EventArgs e) => { InputController.CloseExpressionWrite(Global.expression); }
                    ,
                    _ => (object sender, EventArgs e) => { }
                },
                "Operators" => name switch
                {
                    "Append" => (object sender, EventArgs e) => { InputController.Append(Global.expression, new Operator("+", OperatorMark.Add)); }
                    ,
                    "Subtract" => (object sender, EventArgs e) => { InputController.Append(Global.expression, new Operator("-", OperatorMark.Subtract)); }
                    ,
                    "Multiply" => (object sender, EventArgs e) => { InputController.Append(Global.expression, new Operator("×", OperatorMark.Multiply)); }
                    ,
                    "Division" => (object sender, EventArgs e) => { InputController.Append(Global.expression, new Operator("÷", OperatorMark.Division)); }
                    ,
                    "Modular" => (object sender, EventArgs e) => { InputController.Append(Global.expression, new Operator("mod", OperatorMark.Modular)); }
                    ,
                    _ => (object sender, EventArgs e) => { }
                },
                "Function" => name switch
                {
                    "NaturalLogarithm" => (object sender, EventArgs e) => { InputController.Append(Global.expression, new SingularFunction("ln", FunctionMark.NaturalLogarithm)); }
                    ,
                    "EPowerOfX" => (object sender, EventArgs e) => { InputController.Append(Global.expression, new SingularFunction("ePower", FunctionMark.EPowerOfX)); }
                    ,
                    "DecimalLogarithm" => (object sender, EventArgs e) => { InputController.Append(Global.expression, new SingularFunction("lg", FunctionMark.DecimalLogarithm)); }
                    ,
                    "LogarithmOfXBasedOnY" => (object sender, EventArgs e) => { InputController.Append(Global.expression, new BinaryFunction("log", FunctionMark.LogarithmOfXBasedOnY)); }
                    ,
                    "TenPowerOfX" => (object sender, EventArgs e) => { InputController.Append(Global.expression, new SingularFunction("tenPower", FunctionMark.TenPowerOfX)); }
                    ,
                    "TwoPowerOfX" => (object sender, EventArgs e) => { InputController.Append(Global.expression, new SingularFunction("twoPower", FunctionMark.TwoPowerOfX)); }
                    ,
                    "XPowerOfY" => (object sender, EventArgs e) => { InputController.Append(Global.expression, new BinaryFunction("power", FunctionMark.XPowerOfY)); }
                    ,
                    "YRootOfX" => (object sender, EventArgs e) => { InputController.Append(Global.expression, new BinaryFunction("root", FunctionMark.YRootOfX)); }
                    ,
                    "XPowerOfTwo" => (object sender, EventArgs e) => { InputController.Append(Global.expression, new SingularFunction("powerOfTwo", FunctionMark.XPowerOfTwo)); }
                    ,
                    "XPowerOfThree" => (object sender, EventArgs e) => { InputController.Append(Global.expression, new SingularFunction("powerOfThree", FunctionMark.XPowerOfThree)); }
                    ,
                    "SquareRootOfX" => (object sender, EventArgs e) => { InputController.Append(Global.expression, new SingularFunction("squareRoot", FunctionMark.SquareRootOfX)); }
                    ,
                    "CubicRootOfX" => (object sender, EventArgs e) => { InputController.Append(Global.expression, new SingularFunction("cubicRoot", FunctionMark.CubicRootOfX)); }
                    ,
                    "XReverse" => (object sender, EventArgs e) => { InputController.Append(Global.expression, new SingularFunction("reverse", FunctionMark.XReverse)); }
                    ,
                    "XAbsolute" => (object sender, EventArgs e) => { InputController.Append(Global.expression, new SingularFunction("abs", FunctionMark.XAbsolute)); }
                    ,
                    "Exponential" => (object sender, EventArgs e) => { InputController.Append(Global.expression, new SingularFunction("exp", FunctionMark.Exponential)); }
                    ,
                    "NFactorial" => (object sender, EventArgs e) => { InputController.Append(Global.expression, new SingularFunction("factorial", FunctionMark.NFactorial)); }
                    ,
                    _ => (object sender, EventArgs e) => { }
                },
                "Trigonometry" => name switch
                {
                    "Sine" => (object sender, EventArgs e) => { }
                    ,
                    "Cosine" => (object sender, EventArgs e) => { }
                    ,
                    "Tangent" => (object sender, EventArgs e) => { }
                    ,
                    "Cosecant" => (object sender, EventArgs e) => { }
                    ,
                    "Secant" => (object sender, EventArgs e) => { }
                    ,
                    "Cotangent" => (object sender, EventArgs e) => { }
                    ,
                    "Arcsine" => (object sender, EventArgs e) => { }
                    ,
                    "Arccosine" => (object sender, EventArgs e) => { }
                    ,
                    "Arctangent" => (object sender, EventArgs e) => { }
                    ,
                    "Arccosecant" => (object sender, EventArgs e) => { }
                    ,
                    "Arcsecant" => (object sender, EventArgs e) => { }
                    ,
                    "Arccotangent" => (object sender, EventArgs e) => { }
                    ,
                    "DegreesTypeChange" => (object sender, EventArgs e) => { }
                    ,
                    "ToDegreesMinutesSeconds" => (object sender, EventArgs e) => { }
                    ,
                    "ToDegrees" => (object sender, EventArgs e) => { }
                    ,
                    _ => (object sender, EventArgs e) => { }
                },
                "Memory" => name switch
                {
                    "MemoryClear" => (object sender, EventArgs e) => { }
                    ,
                    "MemoryRead" => (object sender, EventArgs e) => { }
                    ,
                    "MemorySave" => (object sender, EventArgs e) => { }
                    ,
                    "MemoryView" => (object sender, EventArgs e) => { }
                    ,
                    "ChangeView" => (object sender, EventArgs e) => { }
                    ,
                    "MemoryNumberAddNumber" => (object sender, EventArgs e) => { }
                    ,
                    "MemoryNumberSubtractNumber" => (object sender, EventArgs e) => { }
                    ,
                    _ => (object sender, EventArgs e) => { }
                },
                "Variables" => name switch
                {
                    _ => (object sender, EventArgs e) => { InputController.Append(Global.expression, new Variable(name)); }
                },
                _ => (object sender, EventArgs e) => { }
            };
            return handler;
        }

        public static void ControlOpenPropertyMenu(object sender, MouseEventArgs e)
        {
            Control control = (Control)sender;
            if (e.Button != MouseButtons.Right)
            {
                return;
            }

            control.ContextMenu = BindSenderToControlPropertyMenu(
                (control is Button)
                ? ContextMenuStorage.GetContextMenu("buttonPropertyContextMenu")
                : ContextMenuStorage.GetContextMenu("textBoxPropertyContextMenu"), control);
        }

        public static ContextMenu NewButtonPropertyMenu()
        {
            ContextMenu contextMenu = NewTextBoxPropertyMenu();

            MenuItem flatBorderColor = new MenuItem("Выделение");
            flatBorderColor.Click += (object sender, EventArgs e) => { EventStorage.GetEvent("flatBorderColor")(sender, e); };
            contextMenu.MenuItems[1].MenuItems[0].MenuItems.Add(flatBorderColor);

            MenuItem flatOverColor = new MenuItem("Фон при наведении");
            flatOverColor.Click += (object sender, EventArgs e) => { EventStorage.GetEvent("flatOverColor")(sender, e); };
            contextMenu.MenuItems[1].MenuItems[0].MenuItems.Add(flatOverColor);

            MenuItem flatDownColor = new MenuItem("Фон при нажатии");
            flatDownColor.Click += (object sender, EventArgs e) => { EventStorage.GetEvent("flatDownColor")(sender, e); };
            contextMenu.MenuItems[1].MenuItems[0].MenuItems.Add(flatDownColor);

            return contextMenu;
        }

        public static ContextMenu NewTextBoxPropertyMenu()
        {
            ContextMenu contextMenu = new ContextMenu();

            MenuItem remove = new MenuItem("Удалить");
            remove.Click += (object sender, EventArgs e) => { EventStorage.GetEvent("remove")(sender, e); };
            contextMenu.MenuItems.Add(remove);

            MenuItem changePropertyMenuItem = new MenuItem("Изменить");
            {
                MenuItem changeColorMenuItem = new MenuItem("Цвет");
                {
                    MenuItem background = new MenuItem("Фон");
                    background.Click += (object sender, EventArgs e) => { EventStorage.GetEvent("background")(sender, e); };
                    changeColorMenuItem.MenuItems.Add(background);

                    MenuItem foreColor = new MenuItem("Шрифт");
                    foreColor.Click += (object sender, EventArgs e) => { EventStorage.GetEvent("foreColor")(sender, e); };
                    changeColorMenuItem.MenuItems.Add(foreColor);
                }
                changePropertyMenuItem.MenuItems.Add(changeColorMenuItem);

                MenuItem fontStyle = new MenuItem("Шрифт");
                fontStyle.Click += (object sender, EventArgs e) => { EventStorage.GetEvent("fontStyle")(sender, e); };
                changePropertyMenuItem.MenuItems.Add(fontStyle);

                MenuItem size = new MenuItem("Размер");
                size.Click += (object sender, EventArgs e) => { EventStorage.GetEvent("size")(sender, e); };
                changePropertyMenuItem.MenuItems.Add(size);

                MenuItem placement = new MenuItem("Расположение");
                placement.Click += (object sender, EventArgs e) => { EventStorage.GetEvent("placement")(sender, e); };
                changePropertyMenuItem.MenuItems.Add(placement);

            }
            contextMenu.MenuItems.Add(changePropertyMenuItem);

            MenuItem controlProperty = new MenuItem("Свойства");
            controlProperty.Click += (object sender, EventArgs e) => { EventStorage.GetEvent("controlProperty")(sender, e); };
            contextMenu.MenuItems.Add(controlProperty);

            MenuItem controlLock = new MenuItem("Блок");
            controlLock.Click += (object sender, EventArgs e) => { EventStorage.GetEvent("controlLock")(sender, e); };
            contextMenu.MenuItems.Add(controlLock);

            return contextMenu;
        }

        public static ContextMenu BindSenderToControlPropertyMenu(ContextMenu menu, object sender)
        {
            Control control = (Control)sender;
            EventStorage.SetEvent("remove", (object sender, EventArgs e) => ControlRemoveFromPanel(control, sender, e));
            EventStorage.SetEvent("background", (object sender, EventArgs e) => RaiseColorDialogForBackColor(control, sender, e));
            EventStorage.SetEvent("foreColor", (object sender, EventArgs e) => RaiseColorDialogForForeColor(control, sender, e));
            EventStorage.SetEvent("flatBorderColor", (object sender, EventArgs e) => RaiseColorDialogForFlatBorderColor(control, sender, e));
            EventStorage.SetEvent("flatOverColor", (object sender, EventArgs e) => RaiseColorDialogForFlatOverColor(control, sender, e));
            EventStorage.SetEvent("flatDownColor", (object sender, EventArgs e) => RaiseColorDialogForFlatDownColor(control, sender, e));
            EventStorage.SetEvent("fontStyle", (object sender, EventArgs e) => RaiseFontDialog(control, sender, e));
            EventStorage.SetEvent("size", (object sender, EventArgs e) => RaiseChangeSizeForm(control, sender, e));
            EventStorage.SetEvent("placement", (object sender, EventArgs e) => RaiseChangePlacementForm(control, sender, e));
            EventStorage.SetEvent("controlProperty", (object sender, EventArgs e) => RaisePropertyForm(control, sender, e));
            EventStorage.SetEvent("controlLock", (object sender, EventArgs e) => ControlLock(control, sender, e));
            menu.MenuItems[3].Checked = ((IDataStorable)control).Locked;

            return menu;
        }

        private static void ControlRemoveFromPanel(object parent, object sender, EventArgs e)
        {
            Control control = (Control)parent;
            Panel panel = (Panel)control.Parent;

            panel.Controls.Remove(control);
        }

        private static void RaiseColorDialogForBackColor(object parent, object sender, EventArgs e)
        {
            Control control = (Control)parent;
            control.BackColor = GetColorByDialog(control.BackColor);
        }

        private static void RaiseColorDialogForForeColor(object parent, object sender, EventArgs e)
        {
            Control control = (Control)parent;
            control.ForeColor = GetColorByDialog(control.ForeColor);
        }
        private static void RaiseColorDialogForFlatBorderColor(object parent, object sender, EventArgs e)
        {
            Button control = (Button)parent;
            control.FlatAppearance.BorderColor = GetColorByDialog(control.FlatAppearance.BorderColor);
        }
        private static void RaiseColorDialogForFlatOverColor(object parent, object sender, EventArgs e)
        {
            Button control = (Button)parent;
            control.FlatAppearance.MouseOverBackColor = GetColorByDialog(control.FlatAppearance.MouseOverBackColor);
        }
        private static void RaiseColorDialogForFlatDownColor(object parent, object sender, EventArgs e)
        {
            Button control = (Button)parent;
            control.FlatAppearance.MouseDownBackColor = GetColorByDialog(control.FlatAppearance.MouseDownBackColor);
        }

        private static Color GetColorByDialog(Color defaultColor)
        {
            ColorDialog dialog = new ColorDialog() { Color = defaultColor };
            return (dialog.ShowDialog() is DialogResult.OK) ? dialog.Color : defaultColor;
        }

        private static Color? GetColorByDialog()
        {
            ColorDialog dialog = new ColorDialog();
            return (dialog.ShowDialog() is DialogResult.OK) ? dialog.Color : null;
        }

        private static void RaiseFontDialog(object parent, object sender, EventArgs e)
        {
            Control control = (Control)parent;
            control.Font = GetFontByDialog(control.Font);
        }

        private static Font GetFontByDialog(Font defaultFont)
        {
            FontDialog dialog = new FontDialog() { Font = defaultFont };
            return (dialog.ShowDialog() is DialogResult.OK) ? dialog.Font : defaultFont;
        }

        private static Font? GetFontByDialog()
        {
            FontDialog dialog = new FontDialog();
            return (dialog.ShowDialog() is DialogResult.OK) ? dialog.Font : null;
        }

        private static void RaiseChangeSizeForm(object parent, object sender, EventArgs e)
        {
            Control control = (Control)parent;

            ChangeSizeForm changeSize1Form = new ChangeSizeForm(control.Height.ToString(), control.Width.ToString(), control) { Owner = Global.owner };
            changeSize1Form.ShowDialog();
        }

        private static void RaiseChangePlacementForm(object parent, object sender, EventArgs e)
        {
            Control control = (Control)parent;

            LocationChoiceForm changePlacementForm = new LocationChoiceForm(control) { Owner = Global.owner };
            changePlacementForm.ShowDialog();
        }

        private static void RaisePropertyForm(object parent, object sender, EventArgs e)
        {
            Control control = (Control)parent;
            PropertyForm propertyForm = new PropertyForm() { Owner = Global.owner };

            Dictionary<string, string> propertyData = new Dictionary<string, string>
            {
                { "Sector", (control as IDataReceivable).JData["Sector"].Value<string>()},
                { "Name", (control as IDataReceivable).JData["Name"].Value<string>()},
                { "Locked", (control as IDataStorable).Locked.ToString()},
                { "Size", $"{control.Width}, {control.Height}" },
                { "Font Name", control.Font.Name },
                { "Font Size", $"{control.Font.Size}" },
                { "Font Unit", $"{control.Font.Unit}" },
                { "Font GdiCharSet", $"{control.Font.GdiCharSet}" },
                { "Font GdiVerticalFont", $"{control.Font.GdiVerticalFont}" },
                { "Font Bold", $"{control.Font.Bold}" },
                { "Font Italic", $"{control.Font.Italic}" },
                { "Font Strikeout", $"{control.Font.Strikeout}" },
                { "Font Underline", $"{control.Font.Underline}" },
                { "BackColor", DataConverter.ColorToString(control.BackColor)},
                { "ForeColor", DataConverter.ColorToString(control.ForeColor)},
            };

            if (control is Button btn && btn.FlatStyle == FlatStyle.Flat)
            {
                propertyData["FlatBorderColor"] = DataConverter.ColorToString(btn.FlatAppearance.BorderColor);
                propertyData["FlatMouseDownBackColor"] = DataConverter.ColorToString(btn.FlatAppearance.MouseDownBackColor);
                propertyData["FlatMouseOverBackColor"] = DataConverter.ColorToString(btn.FlatAppearance.MouseOverBackColor);
            }

            propertyForm.AddLines(propertyData);

            propertyForm.ShowDialog();
        }

        private static void ControlLock(object parent, object sender, EventArgs e)
        {
            IDataStorable control = (IDataStorable)parent;
            control.Locked = !control.Locked;
        }

        public static void PanelDoDrop(object sender, DragEventArgs e)
        {
            JObject data = DragEventArgsToDrop(e);
            Panel panel = (Panel)sender;
            try
            {
                if (panel.Controls.Count == 0)
                {
                    switch (panel.Parent.Name)
                    {
                        case "displayTableLayoutPanel":
                            {
                                panel.Controls.Add(NewTextBox(data));
                                break;
                            }
                        default:
                            {
                                switch (data["Sector"].Value<string>())
                                {
                                    case "Variables":
                                        {
                                            panel.Controls.Add(NewButton(data, data["Name"].Value<string>()));
                                            break;
                                        }
                                    default:
                                        {
                                            panel.Controls.Add(NewButton(data, JsonStorage.GetControlText(data["Sector"].Value<string>(), data["Name"].Value<string>())));
                                            break;
                                        }
                                }
                                break;
                            }
                    }

                    if (data.ContainsKey("PreviousPosition"))
                    {
                        byte[] previousPosition = new byte[2] { data["PreviousPosition"][0].Value<byte>(), data["PreviousPosition"][1].Value<byte>() };
                        ((Panel)((TableLayoutPanel)panel.Parent).GetControlFromPosition(previousPosition[0], previousPosition[1])).Controls.Clear();
                    }

                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"{data[0]} {data[1]} {exception.Message}");
            }
        }

        public static SButton NewButton(JObject data, string text, DockStyle? dock = null)
        {
            SButton button = new SButton(data.ToString()) { Text = text, Dock = dock ?? Global.placement };
            return (SButton)Wrap.DragDrop(Wrap.ChangeProperty(Wrap.ActionPerform(button)), modifierConside: true);
        }

        public static STextBox NewTextBox(JObject data, DockStyle? dock = null)
        {
            STextBox textBox = new STextBox(data.ToString(), GetRuleByData(data)) { Dock = dock ?? Global.placement, ReadOnly = true };
            return (STextBox)Wrap.DragDrop(Wrap.ChangeProperty(textBox), modifierConside: true);
        }

        public static void PanelDoDropEnter(object sender, DragEventArgs e)
        {
            Panel panel = (Panel)sender;
            if (panel.Controls.Count == 0)
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private static JObject DragEventArgsToDrop(DragEventArgs e)
        {
            return JObject.Parse(e.Data.GetData(DataFormats.StringFormat).ToString());
        }

        public static void PanelOpenPropertyMenu(object sender, MouseEventArgs e)
        {
            Panel panel = sender as Panel;
            if (e.Button != MouseButtons.Right)
            {
                return;
            }

            panel.ContextMenu = BindSenderToTablePropertyMenu(
                ContextMenuStorage.GetContextMenu(panel.Parent.Name != "displayTableLayoutPanel"
                ? "propertyContextMenu"
                : "propertyContextMenuForDisplayPanel"),
                sender);
        }
        public static ContextMenu NewTableSizePropertyMenu()
        {
            ContextMenu contextMenu = NewPropertyMenuForDisplayPanel();
            MenuItem addColumn = new MenuItem("Добавить столбец");
            addColumn.Click += (object sender, EventArgs e) => { EventStorage.GetEvent("addColumn")(sender, e); };
            contextMenu.MenuItems.Add(addColumn);
            MenuItem removeColumn = new MenuItem("Удалить столбец");
            removeColumn.Click += (object sender, EventArgs e) => { EventStorage.GetEvent("removeColumn")(sender, e); };
            contextMenu.MenuItems.Add(removeColumn);
            return contextMenu;
        }

        public static ContextMenu NewPropertyMenuForDisplayPanel()
        {
            ContextMenu contextMenu = new ContextMenu();
            MenuItem addRow = new MenuItem("Добавить строку");
            addRow.Click += (object sender, EventArgs e) => { EventStorage.GetEvent("addRow")(sender, e); };
            contextMenu.MenuItems.Add(addRow);
            MenuItem removeRow = new MenuItem("Удалить строку");
            removeRow.Click += (object sender, EventArgs e) => { EventStorage.GetEvent("removeRow")(sender, e); };
            contextMenu.MenuItems.Add(removeRow);
            return contextMenu;
        }

        public static ContextMenu BindSenderToTablePropertyMenu(ContextMenu menu, object sender)
        {
            Panel panel = sender as Panel;

            menu.MenuItems[1].Enabled = ((TableLayoutPanel)panel.Parent).RowCount > 1;
            EventStorage.SetEvent("addRow", (object sender, EventArgs e) => PanelAddRow(panel, sender, e));
            EventStorage.SetEvent("removeRow", (object sender, EventArgs e) => PanelRemoveRow(panel, sender, e));

            if (menu.MenuItems.Count > 2)
            {
                menu.MenuItems[3].Enabled = ((TableLayoutPanel)panel.Parent).ColumnCount > 1;
                EventStorage.SetEvent("addColumn", (object sender, EventArgs e) => PanelAddColumn(panel, sender, e));
                EventStorage.SetEvent("removeColumn", (object sender, EventArgs e) => PanelRemoveColumn(panel, sender, e));
            }
            return menu;
        }
        public static void PanelAddRow(object parent, object sender = null, EventArgs e = null)
        {
            TableLayoutPanel tablePanel = (((Panel)parent).Parent is TableLayoutPanel) ? (TableLayoutPanel)((Panel)parent).Parent : (TableLayoutPanel)parent;
            tablePanel.RowCount += 1;
            tablePanel.RowStyles.Add(new RowStyle());
            TablePanelCorrectRowsCellSize(tablePanel);
            TablePanelFillCells(tablePanel, GetWrapperByTablePanel(tablePanel));
        }
        public static void PanelAddColumn(object parent, object sender = null, EventArgs e = null)
        {
            TableLayoutPanel tablePanel = (((Panel)parent).Parent is TableLayoutPanel) ? (TableLayoutPanel)((Panel)parent).Parent : (TableLayoutPanel)parent;
            tablePanel.ColumnCount += 1;
            tablePanel.ColumnStyles.Add(new ColumnStyle());
            TablePanelCorrectColumnsCellSize(tablePanel);
            TablePanelFillCells(tablePanel, GetWrapperByTablePanel(tablePanel));
        }

        private static Wrapper GetWrapperByTablePanel(TableLayoutPanel tablePanel)
        {
            return tablePanel.Name switch
            {
                "displayTableLayoutPanel" => Wrap.DisplayPanel,
                "controlTableLayoutPanel" => Wrap.ControlPanel,
                _ => throw new Exception("new panel not handled")
            };
        }
        public static void PanelRemoveRow(object parent, object sender, EventArgs e)
        {
            Panel panel = (Panel)parent;
            TableLayoutPanel tablePanel = (panel.Parent is TableLayoutPanel) ? (TableLayoutPanel)panel.Parent : parent as TableLayoutPanel;
            if (tablePanel.RowCount == 1)
            {
                return;
            }

            byte removeIndex = (byte)tablePanel.GetCellPosition(panel).Row;
            if (removeIndex == tablePanel.RowCount - 1)
            {
                for (byte C = 0; C < tablePanel.ColumnCount; C++)
                {
                    Control upControl = tablePanel.GetControlFromPosition(C, removeIndex);
                    if (upControl is not null)
                    {
                        tablePanel.Controls.Remove(upControl);
                    }
                }
            }
            else
            {
                for (byte R = removeIndex; R < tablePanel.RowCount - 1; R++)
                {
                    for (byte C = 0; C < tablePanel.ColumnCount; C++)
                    {
                        Control upControl = tablePanel.GetControlFromPosition(C, R);
                        if (upControl is not null)
                        {
                            tablePanel.Controls.Remove(upControl);
                        }

                        Control downControl = tablePanel.GetControlFromPosition(C, R + 1);
                        if (downControl is not null)
                        {
                            tablePanel.SetCellPosition(downControl, new TableLayoutPanelCellPosition(C, R));
                        }
                    }
                }
            }

            tablePanel.RowCount -= 1;
            tablePanel.RowStyles.RemoveAt(tablePanel.RowStyles.Count - 1);

            if (tablePanel.RowCount != 0)
            {
                TablePanelCorrectRowsCellSize(tablePanel);
            }
        }
        public static void PanelRemoveColumn(object parent, object sender, EventArgs e)
        {
            Panel panel = (Panel)parent;
            TableLayoutPanel tablePanel = (panel.Parent is TableLayoutPanel) ? (TableLayoutPanel)panel.Parent : parent as TableLayoutPanel;
            if (tablePanel.ColumnCount == 1)
            {
                return;
            }

            byte removeIndex = (byte)tablePanel.GetCellPosition(panel).Column;
            if (removeIndex == tablePanel.ColumnCount - 1)
            {
                for (byte R = 0; R < tablePanel.RowCount; R++)
                {
                    Control upControl = tablePanel.GetControlFromPosition(removeIndex, R);
                    if (upControl is not null)
                    {
                        tablePanel.Controls.Remove(upControl);
                    }
                }
            }
            else
            {
                for (byte R = 0; R < tablePanel.RowCount; R++)
                {
                    for (byte C = removeIndex; C < tablePanel.ColumnCount - 1; C++)
                    {
                        Control upControl = tablePanel.GetControlFromPosition(C, R);
                        if (upControl is not null)
                        {
                            tablePanel.Controls.Remove(upControl);
                        }

                        Control downControl = tablePanel.GetControlFromPosition(C + 1, R);
                        if (downControl is not null)
                        {
                            tablePanel.SetCellPosition(downControl, new TableLayoutPanelCellPosition(C, R));
                        }
                    }
                }
            }
            tablePanel.ColumnCount -= 1;
            tablePanel.ColumnStyles.RemoveAt(tablePanel.ColumnStyles.Count - 1);

            if (tablePanel.ColumnCount != 0)
            {
                TablePanelCorrectColumnsCellSize(tablePanel);
            }
        }

        public static void TablePanelFillCells(TableLayoutPanel tablePanel, Wrapper wrapper)
        {
            for (byte R = 0; R < tablePanel.RowCount; R++)
            {
                for (byte C = 0; C < tablePanel.ColumnCount; C++)
                {
                    if (tablePanel.GetControlFromPosition(C, R) is null)
                    {
                        tablePanel.Controls.Add(wrapper(NewDragPanel()), C, R);
                    }
                }
            }
        }

        public static void TablePanelCorrectCellsSize(TableLayoutPanel tablePanel)
        {
            TablePanelCorrectRowsCellSize(tablePanel);
            TablePanelCorrectColumnsCellSize(tablePanel);
        }

        private static void TablePanelCorrectRowsCellSize(TableLayoutPanel tablePanel)
        {
            foreach (RowStyle item in tablePanel.RowStyles)
            {
                item.SizeType = item.SizeType == SizeType.Percent ? item.SizeType : SizeType.Percent;
                item.Height = 100 / tablePanel.RowCount;
            }
        }

        private static void TablePanelCorrectColumnsCellSize(TableLayoutPanel tablePanel)
        {
            foreach (ColumnStyle item in tablePanel.ColumnStyles)
            {
                item.SizeType = item.SizeType == SizeType.Percent ? item.SizeType : SizeType.Percent;
                item.Width = 100 / tablePanel.ColumnCount;
            }
        }

        public static void UpdateControlsBorderView(params TableLayoutPanel[] tablePanels)
        {
            foreach (TableLayoutPanel tablePanel in tablePanels)
            {
                foreach (Panel panel in tablePanel.Controls)
                {
                    panel.BorderStyle = Global.borderView ? BorderStyle.FixedSingle : BorderStyle.None;
                }
            }
        }

        public static void UpdateControlsPlacement(params TableLayoutPanel[] tablePanels)
        {
            foreach (TableLayoutPanel tablePanel in tablePanels)
            {
                foreach (Panel panel in tablePanel.Controls)
                {
                    foreach (Control control in panel.Controls)
                    {
                        if (((IDataStorable)control).Locked == false)
                        {
                            control.Dock = Global.placement;
                        }
                    }
                }
            }
        }

        public static Panel NewDragPanel()
        {
            return new Panel() { Dock = DockStyle.Fill, BorderStyle = Global.borderView ? BorderStyle.FixedSingle : BorderStyle.None, AllowDrop = true };
        }

        public delegate Panel Wrapper(Panel panel);

        public static void UpdateDisplayPanelsRecord(List<Composite> expression, TableLayoutPanel tablePanel)
        {
            {
                foreach (Panel panel in tablePanel.Controls)
                {
                    foreach (Control control in panel.Controls)
                    {
                        UpdateDisplayRecord(expression, control as STextBox);
                    }
                }
            }
        }

        public static void UpdateDisplayRecord(List<Composite> expression, STextBox display)
        {
            display.SetTextByRule(expression);
        }

        public static void UpdateControlColor(Control control)
        {
            Color? color = GetColorByDialog();
            if (color is null)
            {
                return;
            }

            control.BackColor = (Color)color;
        }
        public static void UpdateControlFontColor(Control control)
        {
            Color? color = GetColorByDialog();
            if (color is null)
            {
                return;
            }

            control.ForeColor = (Color)color;
        }
        public static void UpdateControlFont(Control control)
        {
            Font? font = GetFontByDialog();
            if (font is null)
            {
                return;
            }

            control.Font = font;
        }
        public static void UpdateControlsFont(params TableLayoutPanel[] tablePanels)
        {
            Font? font = GetFontByDialog();
            if (font is null)
            {
                return;
            }

            Global.defaultFont = font;
            foreach (TableLayoutPanel tablePanel in tablePanels)
            {
                foreach (Panel panel in tablePanel.Controls)
                {
                    foreach (Control control in panel.Controls)
                    {
                        if (((IDataStorable)control).Locked == false)
                        {
                            control.Font = font;
                        }
                    }
                }
            }
        }

        public static void UpdateControlsColor(char type, params TableLayoutPanel[] tablePanels)
        {
            Color? color = GetColorByDialog();
            if (color is null)
            {
                return;
            }

            SetColor? setter = type switch
            {
                'b' => SetBackColor,
                'f' => SetForeColor,
                'r' => SetFlatBorderColor,
                's' => SetFlatOverColor,
                'p' => SetFlatDownColor,
                _ => null
            };
            if (setter is null)
            {
                return;
            }

            foreach (TableLayoutPanel tablePanel in tablePanels)
            {
                foreach (Panel panel in tablePanel.Controls)
                {
                    foreach (Control control in panel.Controls)
                    {
                        if (((IDataStorable)control).Locked == false)
                        {
                            setter(control, (Color)color);
                        }
                    }
                }
            }
        }

        private static void SetBackColor(Control control, System.Drawing.Color color)
        {
            control.BackColor = Global.defaultBackColor = color;
        }

        private static void SetForeColor(Control control, System.Drawing.Color color)
        {
            control.ForeColor = Global.defaultForeColor = color;
        }

        private static void SetFlatBorderColor(Control control, System.Drawing.Color color)
        {
            ((Button)control).FlatAppearance.BorderColor = Global.defaultFlatBorderColor = color;
        }

        private static void SetFlatOverColor(Control control, System.Drawing.Color color)
        {
            ((Button)control).FlatAppearance.MouseOverBackColor = Global.defaultFlatOverColor = color;
        }

        private static void SetFlatDownColor(Control control, System.Drawing.Color color)
        {
            ((Button)control).FlatAppearance.MouseDownBackColor = Global.defaultFlatDownColor = color;
        }

        private delegate void SetColor(Control control, System.Drawing.Color color);
        public static void TrackableFormClosed(object sender, FormClosedEventArgs e)
        {
            (sender as ICloseTrackable).closed = true;
        }

        public static void TrackableFormShown(object sender, EventArgs e)
        {
            (sender as ICloseTrackable).closed = false;
        }

        public static void SetSubFormPosition(Form ownerForm, Form subForm, int? customX = null, int? customY = null)
        {
            subForm.StartPosition = FormStartPosition.Manual;
            subForm.Location = new Point
                (
                customX ?? ownerForm.Location.X - subForm.Width,
                customY ?? ownerForm.Location.Y + (ownerForm.Size.Width / 2) - (subForm.Height / 2)
                );
        }
    }
}
