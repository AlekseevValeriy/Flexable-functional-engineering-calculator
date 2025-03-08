using System.Drawing.Text;
using System.Linq.Expressions;
using System.Windows.Forms;
using FFEC;

namespace FFEC
{
    internal static class Handler
    {
        public static void ControlDoDragDrop(Object sender, MouseEventArgs e)
        {
            ((Control)sender).DoDragDrop(ConvertToDrag(((IRemoveable)sender).Data), DragDropEffects.Copy | DragDropEffects.Move);
        }

        public static void ControlDoDragDropModifierConside(Object sender, MouseEventArgs e)
        {
            if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
            {
                ((Control)sender).DoDragDrop(ConvertToDrag(((IRemoveable)sender).Data), DragDropEffects.Copy | DragDropEffects.Move);
                ((Control)sender).Parent.Controls.Clear();
            }
        }

        public static Boolean DisplayValidate(DragEventArgs e) => DragEventArgsToDrop(e)[0] == "Display";

        public static Boolean ControlValidate(DragEventArgs e) => DragEventArgsToDrop(e)[0] != "Display";

        public static ConverterToStringByRule GetRuleByData(String[] data)
        {
            return data[1] switch
            {
                "Base" => Display.ExpressionToRecord,
                _ => (List<Composite> expression, Boolean debug) => ""
            };
        }

        public static EventHandler GetActionByButtonData(String[] data)
        {
            EventHandler handler = data[0] switch
            {
                "Numbers" => data[1] switch
                {
                    "Zero" => (Object sender, EventArgs e) => { InputController.Append(Global.expression, new Term("0")); },
                    "One" => (Object sender, EventArgs e) => { InputController.Append(Global.expression, new Term("1")); },
                    "Two" => (Object sender, EventArgs e) => { InputController.Append(Global.expression, new Term("2")); },
                    "Three" => (Object sender, EventArgs e) => { InputController.Append(Global.expression, new Term("3")); },
                    "Four" => (Object sender, EventArgs e) => { InputController.Append(Global.expression, new Term("4")); },
                    "Five" => (Object sender, EventArgs e) => { InputController.Append(Global.expression, new Term("5")); },
                    "Six" => (Object sender, EventArgs e) => { InputController.Append(Global.expression, new Term("6")); },
                    "Seven" => (Object sender, EventArgs e) => { InputController.Append(Global.expression, new Term("7")); },
                    "Eight" => (Object sender, EventArgs e) => { InputController.Append(Global.expression, new Term("8")); },
                    "Nine" => (Object sender, EventArgs e) => { InputController.Append(Global.expression, new Term("9")); },
                    "Pi" => (Object sender, EventArgs e) => { InputController.Append(Global.expression, new Constanta(Math.PI.ToString())); },
                    "E" => (Object sender, EventArgs e) => { InputController.Append(Global.expression, new Constanta(Math.E.ToString())); },
                    _ => (Object sender, EventArgs e) => { }
                },
                "Actions" => data[1] switch
                {
                    "ToDouble" => (Object sender, EventArgs e) => { InputController.Append(Global.expression, new Comma()); },
                    "Backspace" => (Object sender, EventArgs e) => { InputController.DeleteLast(Global.expression); },
                    "Equally" => (Object sender, EventArgs e) => { InputController.Equally(ref Global.expression); },
                    "Clear" => (Object sender, EventArgs e) => { InputController.ClearAll(Global.expression); },
                    "ClearElement" => (Object sender, EventArgs e) => { InputController.ClearOne(Global.expression); },
                    "ChangeSign" => (Object sender, EventArgs e) => { InputController.ChangeSign(Global.expression); },
                    "Parenthesis" => (Object sender, EventArgs e) => { InputController.Append(Global.expression, new Staples()); },
                    "CloseFunctionWrite" => (Object sender, EventArgs e) => { InputController.CloseExpressionWrite(Global.expression); },
                    _ => (Object sender, EventArgs e) => { }
                },
                "Operators" => data[1] switch
                {
                    "Append" => (Object sender, EventArgs e) => { InputController.Append(Global.expression, new Operator("+", OperatorMark.Add)); },
                    "Subtract" => (Object sender, EventArgs e) => { InputController.Append(Global.expression, new Operator("-", OperatorMark.Subtract)); },
                    "Multiply" => (Object sender, EventArgs e) => { InputController.Append(Global.expression, new Operator("×", OperatorMark.Multiply)); },
                    "Division" => (Object sender, EventArgs e) => { InputController.Append(Global.expression, new Operator("÷", OperatorMark.Division)); },
                    "Modular" => (Object sender, EventArgs e) => { InputController.Append(Global.expression, new Operator("mod", OperatorMark.Modular)); },
                    _ => (Object sender, EventArgs e) => { }
                },
                "Function" => data[1] switch
                {
                    "NaturalLogarithm" => (Object sender, EventArgs e)  => { InputController.Append(Global.expression, new SingularFunction("ln", FunctionMark.NaturalLogarithm)); },
                    "EPowerOfX" => (Object sender, EventArgs e)  => { InputController.Append(Global.expression, new SingularFunction("ePower", FunctionMark.EPowerOfX)); },
                    "DecimalLogarithm" => (Object sender, EventArgs e)  => { InputController.Append(Global.expression, new SingularFunction("lg", FunctionMark.DecimalLogarithm)); },
                    "LogarithmOfXBasedOnY" => (Object sender, EventArgs e)  => { InputController.Append(Global.expression, new BinaryFunction("log", FunctionMark.LogarithmOfXBasedOnY)); },
                    "TenPowerOfX" => (Object sender, EventArgs e)  => { InputController.Append(Global.expression, new SingularFunction("tenPower", FunctionMark.TenPowerOfX)); },
                    "TwoPowerOfX" => (Object sender, EventArgs e)  => { InputController.Append(Global.expression, new SingularFunction("twoPower", FunctionMark.TwoPowerOfX)); },
                    "XPowerOfY" => (Object sender, EventArgs e)  => { InputController.Append(Global.expression, new BinaryFunction("power", FunctionMark.XPowerOfY)); },
                    "YRootOfX" => (Object sender, EventArgs e)  => { InputController.Append(Global.expression, new BinaryFunction("root", FunctionMark.YRootOfX)); },
                    "XPowerOfTwo" => (Object sender, EventArgs e)  => { InputController.Append(Global.expression, new SingularFunction("powerOfTwo", FunctionMark.XPowerOfTwo)); },
                    "XPowerOfThree" => (Object sender, EventArgs e)  => { InputController.Append(Global.expression, new SingularFunction("powerOfThree", FunctionMark.XPowerOfThree)); },
                    "SquareRootOfX" => (Object sender, EventArgs e)  => { InputController.Append(Global.expression, new SingularFunction("squareRoot", FunctionMark.SquareRootOfX)); },
                    "CubicRootOfX" => (Object sender, EventArgs e)  => { InputController.Append(Global.expression, new SingularFunction("cubicRoot", FunctionMark.CubicRootOfX)); },
                    "XReverse" => (Object sender, EventArgs e) => { InputController.Append(Global.expression, new SingularFunction("reverse", FunctionMark.XReverse)); },
                    "XAbsolute" => (Object sender, EventArgs e)  => { InputController.Append(Global.expression, new SingularFunction("abs", FunctionMark.XAbsolute)); },
                    "Exponential" => (Object sender, EventArgs e)  => { InputController.Append(Global.expression, new SingularFunction("exp", FunctionMark.Exponential)); },
                    "NFactorial" => (Object sender, EventArgs e)  => { InputController.Append(Global.expression, new SingularFunction("factorial", FunctionMark.NFactorial)); },
                    _ => (Object sender, EventArgs e) => { }
                },
                "Trigonometry" => data[1] switch
                {
                    "Sine" => (Object sender, EventArgs e) => { },
                    "Cosine" => (Object sender, EventArgs e) => { },
                    "Tangent" => (Object sender, EventArgs e) => { },
                    "Cosecant" => (Object sender, EventArgs e) => { },
                    "Secant" => (Object sender, EventArgs e) => { },
                    "Cotangent" => (Object sender, EventArgs e) => { },
                    "Arcsine" => (Object sender, EventArgs e) => { },
                    "Arccosine" => (Object sender, EventArgs e) => { },
                    "Arctangent" => (Object sender, EventArgs e) => { },
                    "Arccosecant" => (Object sender, EventArgs e) => { },
                    "Arcsecant" => (Object sender, EventArgs e) => { },
                    "Arccotangent" => (Object sender, EventArgs e) => { },
                    "DegreesTypeChange" => (Object sender, EventArgs e) => { },
                    "ToDegreesMinutesSeconds" => (Object sender, EventArgs e) => { },
                    "ToDegrees" => (Object sender, EventArgs e) => { },
                    _ => (Object sender, EventArgs e) => { }
                },
                "Memory" => data[1] switch
                {
                    "MemoryClear" => (Object sender, EventArgs e) => { },
                    "MemoryRead" => (Object sender, EventArgs e) => { },
                    "MemorySave" => (Object sender, EventArgs e) => { },
                    "MemoryView" => (Object sender, EventArgs e) => { },
                    "ChangeView" => (Object sender, EventArgs e) => { },
                    "MemoryNumberAddNumber" => (Object sender, EventArgs e) => { },
                    "MemoryNumberSubtractNumber" => (Object sender, EventArgs e) => { },
                    _ => (Object sender, EventArgs e) => { }
                },
                _ => (Object sender, EventArgs e) => { }
            };
            return handler;
        }

        public static void ControlOpenPropertyMenu(Object sender, MouseEventArgs e)
        {
            Control control = (Control)sender;
            if (e.Button != MouseButtons.Right) return;

            ContextMenu contextMenu = new ContextMenu();

            MenuItem removeMenuItem = new MenuItem() { Text = "Удалить" };
            removeMenuItem.Click += (Object sender, EventArgs e) => ControlRemoveFromPanel(control, sender, e);
            contextMenu.MenuItems.Add(removeMenuItem);

            MenuItem changePropertyMenuItem = new MenuItem() { Text = "Изменить" };
            {
                MenuItem changeColorMenuItem = new MenuItem() { Text = "Цвет" };
                changeColorMenuItem.Click += (Object sender, EventArgs e) => RaiseColorDialog(control, sender, e);
                changePropertyMenuItem.MenuItems.Add(changeColorMenuItem);

                MenuItem changeFontMenuItem = new MenuItem() { Text = "Шрифт" };
                changeFontMenuItem.Click += (Object sender, EventArgs e) => RaiseFontDialog(control, sender, e);
                changePropertyMenuItem.MenuItems.Add(changeFontMenuItem);

                MenuItem changeSizeMenuItem = new MenuItem() { Text = "Размер" };
                changeSizeMenuItem.Click += (Object sender, EventArgs e) => RaiseChangeSizeForm(control, sender, e);
                changePropertyMenuItem.MenuItems.Add(changeSizeMenuItem);

                MenuItem changePlacementMenuItem = new MenuItem() { Text = "Расположение" };
                changePlacementMenuItem.Click += (Object sender, EventArgs e) => RaiseChangePlacementForm(control, sender, e);
                changePropertyMenuItem.MenuItems.Add(changePlacementMenuItem);
            }
            contextMenu.MenuItems.Add(changePropertyMenuItem);

            MenuItem propertyMenuItem = new MenuItem() { Text = "Свойства" };
            propertyMenuItem.Click += (Object sender, EventArgs e) => RaisePropertyForm(control, sender, e);
            contextMenu.MenuItems.Add(propertyMenuItem);

            MenuItem lockMenuItem = new MenuItem() { Text = "Блок", Checked = ((IRemoveable)control).Locked };
            lockMenuItem.Click += (Object sender, EventArgs e) => ControlLock(control, sender, e);
            contextMenu.MenuItems.Add(lockMenuItem);

            control.ContextMenu = contextMenu;
        }

        private static void ControlRemoveFromPanel(Object parent, Object sender, EventArgs e)
        {
            Control control = (Control)parent;
            Panel panel = (Panel)control.Parent;

            panel.Controls.Remove(control);
        }

        private static void RaiseColorDialog(Object parent, Object sender, EventArgs e)
        {
            Control control = (Control)parent;
            control.BackColor = GetColorByDialog(control.BackColor);
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

        private static void RaiseFontDialog(Object parent, Object sender, EventArgs e)
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

        private static void RaiseChangeSizeForm(Object parent, Object sender, EventArgs e)
        {
            Control control = (Control)parent;

            Form changeSizeForm = new Form() { Height = 90, Width = 260 };
            TableLayoutPanel tablePanel = new TableLayoutPanel() { Dock = DockStyle.Fill, ColumnCount = 2, RowCount = 2 };

            Label heightLable = new Label() { Text = "Высота" };
            tablePanel.Controls.Add(heightLable, 0, 0);
            TextBox heightTextBox = new TextBox() { Text = control.Height.ToString() };
            tablePanel.Controls.Add(heightTextBox, 1, 0);

            Label widthLable = new Label() { Text = "Ширина" };
            tablePanel.Controls.Add(widthLable, 0, 1);
            TextBox widthTextBox = new TextBox() { Text = control.Width.ToString() };
            tablePanel.Controls.Add(widthTextBox, 1, 1);

            changeSizeForm.Controls.Add(tablePanel);

            heightTextBox.KeyDown += PerformKeyShortcut;
            widthTextBox.KeyDown += PerformKeyShortcut;

            changeSizeForm.ShowDialog();
            SetSize();

            void PerformKeyShortcut(Object sender, KeyEventArgs e)
            {
                switch (e.KeyCode)
                {
                    case Keys.Escape: changeSizeForm.Close(); break;
                    case Keys.Enter or Keys.Tab: SetSize(); break;
                    case Keys.Up or Keys.Down or Keys.Left or Keys.Right: SizeCrement(e.KeyCode); break;
                }
            }

            void SetSize()
            {
                if (IsSizeTextCorrect(out UInt16 newWidth, out UInt16 newHeight))
                {
                    control.Size = new System.Drawing.Size(newWidth, newHeight);
                    widthTextBox.Text = control.Width.ToString();
                    heightTextBox.Text = control.Height.ToString();
                };
            }

            void SizeCrement(Keys key)
            {
                if (IsSizeTextCorrect(out UInt16 newWidth, out UInt16 newHeight))
                {
                    switch (key)
                    {
                        case Keys.Up: { newHeight++; break; }
                        case Keys.Down: { newHeight--; break; }
                        case Keys.Left: { newWidth--; break; }
                        case Keys.Right: { newWidth++; break; }
                    }
                    control.Size = new System.Drawing.Size(newWidth, newHeight);
                    widthTextBox.Text = control.Width.ToString();
                    heightTextBox.Text = control.Height.ToString();
                };
            }

            Boolean IsSizeTextCorrect(out UInt16 width, out UInt16 height)
            {
                return UInt16.TryParse(widthTextBox.Text, out width) & UInt16.TryParse(heightTextBox.Text, out height);
            }
        }

        private static void RaiseChangePlacementForm(Object parent, Object sender, EventArgs e)
        {
            Control control = (Control)parent;

            Form changePlacementForm = new Form() { Height = 90, Width = 260 };

            TableLayoutPanel tablePanel = new TableLayoutPanel() { Dock = DockStyle.Fill, ColumnCount = 2, RowCount = 1 };

            Label dockLable = new Label() { Text = "Привязка" };
            tablePanel.Controls.Add(dockLable, 0, 0);
            
            ComboBox dockComboBox = new ComboBox() { Dock = DockStyle.Fill, Text = control.Dock.ToString() };
            dockComboBox.Items.AddRange(Enum.GetValues(typeof(DockStyle)).Cast<Object>().ToArray());
            dockComboBox.SelectedValueChanged += (Object sender, EventArgs e) => control.Dock = (DockStyle)dockComboBox.SelectedItem;
            tablePanel.Controls.Add(dockComboBox, 1, 0);

            changePlacementForm.Controls.Add(tablePanel);

            changePlacementForm.ShowDialog();
        }

        private static void RaisePropertyForm(Object parent, Object sender, EventArgs e)
        {
            Control control = (Control)parent;
            Form propertyForm = new Form();

            TableLayoutPanel tablePanel = new TableLayoutPanel() { CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset, ColumnCount = 2, Dock = DockStyle.Fill };

            String[][] propertyData = new String[][]
            {
                new String[2] {"BackColor", $"{control.BackColor.R}, {control.BackColor.G}, {control.BackColor.B}, {control.BackColor.A}"},
                new String[2] {"FontName", control.Font.Name},
                new String[2] {"FontSize", control.Font.Size.ToString()},
                new String[2] {"FontColor", $"{control.ForeColor.R}, {control.ForeColor.G}, {control.ForeColor.B}, {control.ForeColor.A}"},
                new String[2] {"Width", control.Width.ToString()},
                new String[2] {"Height", control.Height.ToString()},
                new String[2] {"Anchor", control.Anchor.ToString()},
                new String[2] {"Dock", control.Dock.ToString()},
            };
            tablePanel.RowCount = propertyData.Length;
            

            foreach (String[] data in propertyData)
            {
                tablePanel.Controls.Add(new Label() { Text = data[0] });
                tablePanel.Controls.Add(new Label() { Text = data[1] });
            }
            propertyForm.Controls.Add(tablePanel);
            propertyForm.ShowDialog();
        }

        private static void ControlLock(Object parent, Object sender, EventArgs e)
        {
            IRemoveable control = (IRemoveable)parent;
            control.Locked = !control.Locked;
        }

        public static void PanelDoDrop(Object sender, DragEventArgs e)
        {
            String[] data = DragEventArgsToDrop(e);
            Panel panel = (Panel)sender;
            try
            {
                if (panel.Controls.Count == 0)
                {
                    if (panel.Parent.Name != "displayTableLayoutPanel")
                    { 
                        SButton button = new SButton() { Data = new String[] { data[0], data[1] }, Text = Storage.GetButtonText(data[0], data[1]), Dock = Global.placement, FlatStyle = FlatStyle.Flat };
                        panel.Controls.Add(Wrap.DragDrop(Wrap.ChangeProperty(Wrap.ActionPerform(button)), modifierConside: true));
                    }
                    else 
                    {
                        STextBox textBox = new STextBox(GetRuleByData(data)) { Data = new String[] { data[0], data[1] }, Dock = Global.placement, ReadOnly = true };
                        panel.Controls.Add(Wrap.DragDrop(Wrap.ChangeProperty(textBox), modifierConside: true));
                    }                   
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"{data[0]} {data[1]} {exception.Message}");
            }
        }

        public static void PanelDoDropEnter(Object sender, DragEventArgs e)
        {
            Panel panel = (Panel)sender;
            if (panel.Controls.Count == 0) e.Effect = DragDropEffects.Copy;
        }

        private static String ConvertToDrag(String[] data) => String.Join(";", data.ToList<String>());
        private static String[] ConvertToDrop(String data) => data.Split(';');
        private static String[] DragEventArgsToDrop(DragEventArgs e) => ConvertToDrop(e.Data.GetData(DataFormats.StringFormat).ToString());

        public static void PanelOpenPropertyMenu(Object sender, MouseEventArgs e)
        {
            Panel panel = (Panel)sender;
            if (e.Button != MouseButtons.Right) return;

            ContextMenu contextMenu = new ContextMenu();

            MenuItem addRowMenuItem = new MenuItem() { Text = "Добавить строку" };
            addRowMenuItem.Click += (Object sender, EventArgs e) => PanelAddRow(panel, sender, e);
            contextMenu.MenuItems.Add(addRowMenuItem);

            MenuItem removeRowMenuItem = new MenuItem() { Text = "Удалить строку", Enabled = ((TableLayoutPanel)panel.Parent).RowCount > 1 };
            removeRowMenuItem.Click += (Object sender, EventArgs e) => PanelRemoveRow(panel, sender, e);
            contextMenu.MenuItems.Add(removeRowMenuItem);

            if (panel.Parent.Name != "displayTableLayoutPanel")
            {
                MenuItem addColumnMenuItem = new MenuItem() { Text = "Добавить столбец" };
                addColumnMenuItem.Click += (Object sender, EventArgs e) => PanelAddColumn(panel, sender, e);
                contextMenu.MenuItems.Add(addColumnMenuItem);

                MenuItem removeColumnMenuItem = new MenuItem() { Text = "Удалить столбец", Enabled = ((TableLayoutPanel)panel.Parent).ColumnCount > 1 };
                removeColumnMenuItem.Click += (Object sender, EventArgs e) => PanelRemoveColumn(panel, sender, e);
                contextMenu.MenuItems.Add(removeColumnMenuItem);
            }
            panel.ContextMenu = contextMenu;
        }

        private static void PanelAddRow(Object parent, Object sender, EventArgs e)
        {
            TableLayoutPanel tablePanel = (TableLayoutPanel)((Panel)parent).Parent;
            tablePanel.RowCount += 1;
            tablePanel.RowStyles.Add(new RowStyle());
            TablePanelCorrectRowsCellSize(ref tablePanel);
            TablePanelFillCells(ref tablePanel, GetWrapperByTablePanel(ref tablePanel));
        }
        private static void PanelAddColumn(Object parent, Object sender, EventArgs e)
        {
            TableLayoutPanel tablePanel = (TableLayoutPanel)((Panel)parent).Parent;
            tablePanel.ColumnCount += 1;
            tablePanel.ColumnStyles.Add(new ColumnStyle());
            TablePanelCorrectColumnsCellSize(ref tablePanel);
            TablePanelFillCells(ref tablePanel, GetWrapperByTablePanel(ref tablePanel));
        }

        private static Wrapper GetWrapperByTablePanel(ref TableLayoutPanel tablePanel)
        {
            return tablePanel.Name switch
            {
                "displayTableLayoutPanel" => Wrap.DisplayPanel,
                "controlTableLayoutPanel" => Wrap.ControlPanel,
                _ => throw new Exception("new panel not handled")
            };
        }
        private static void PanelRemoveRow(Object parent, Object sender, EventArgs e)
        {
            TableLayoutPanel tablePanel = (TableLayoutPanel)((Panel)parent).Parent;
            if (tablePanel.RowCount == 1) return;
            for (Byte C = 0; C < tablePanel.RowCount; C++)
            {
                Control control = tablePanel.GetControlFromPosition(C, tablePanel.RowCount - 1);
                if (control is not null) tablePanel.Controls.Remove(control);
            }
            tablePanel.RowStyles.RemoveAt(tablePanel.RowCount - 1);
            tablePanel.RowCount -= 1;
            if (tablePanel.RowCount != 0) TablePanelCorrectRowsCellSize(ref tablePanel);

        }
        private static void PanelRemoveColumn(Object parent, Object sender, EventArgs e)
        {
            TableLayoutPanel tablePanel = (TableLayoutPanel)((Panel)parent).Parent;
            if (tablePanel.ColumnCount == 1) return;
            for (Byte R = 0; R < tablePanel.ColumnCount; R++)
            {
                Control control = tablePanel.GetControlFromPosition(tablePanel.ColumnCount - 1, R);
                if (control is not null) tablePanel.Controls.Remove(control);
            }
            tablePanel.ColumnCount -= 1;
            if (tablePanel.ColumnCount != 0) TablePanelCorrectColumnsCellSize(ref tablePanel);
        }

        public static void TablePanelFillCells(ref TableLayoutPanel tablePanel, Wrapper wrapper)
        {
            for (Byte R = 0; R < tablePanel.RowCount; R++)
            {
                for (Byte C = 0; C < tablePanel.ColumnCount; C++)
                {
                    if (tablePanel.GetControlFromPosition(C, R) is null) tablePanel.Controls.Add(wrapper(NewDragPanel()), C, R);
                    //MessageBox.Show($"col {II} row {I} control {tableLayoutPanel1.GetControlFromPosition(II, I)}");
                }
            }
        }

        public static void TablePanelCorrectCellsSize(ref TableLayoutPanel tablePanel)
        {
            TablePanelCorrectRowsCellSize(ref tablePanel);
            TablePanelCorrectColumnsCellSize(ref tablePanel);
        }

        private static void TablePanelCorrectRowsCellSize(ref TableLayoutPanel tablePanel)
        {
            foreach (RowStyle item in tablePanel.RowStyles)
            {
                item.SizeType = item.SizeType == SizeType.Percent ? item.SizeType : SizeType.Percent;
                item.Height = 100 / tablePanel.RowCount;
            }
        }

        private static void TablePanelCorrectColumnsCellSize(ref TableLayoutPanel tablePanel)
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
                    foreach (Control control in panel.Controls) if (((IRemoveable)control).Locked == false) control.Dock = Global.placement;
                }
            }
        }

        public static Panel NewDragPanel() => new Panel() { Dock = DockStyle.Fill, BorderStyle = Global.borderView ? BorderStyle.FixedSingle : BorderStyle.None, AllowDrop = true };

        public delegate Panel Wrapper(Panel panel);

        public static void UpdateDisplayPanelsRecord(List<Composite> expression, TableLayoutPanel tablePanel)
        {
            {
                foreach (Panel panel in tablePanel.Controls)
                {
                    foreach (Control control in panel.Controls) ((STextBox)control).SetTextByRule(expression);
                }
            }
        }

        public static void UpdateControlColor(Control control)
        {
            Color? color = GetColorByDialog();
            if (color is null) return;
            control.BackColor = (Color)color;
        }

        public static void UpdateControlsColor(Char type, params TableLayoutPanel[] tablePanels)
        {
            Color? color = GetColorByDialog();
            if (color is null) return;

            SetColor setter;
            if (type == 'b') setter = SetBackColor;
            else if (type == 'f') setter = SetForeColor;
            else return;

            foreach (TableLayoutPanel tablePanel in tablePanels)
            {
                foreach (Panel panel in tablePanel.Controls)
                {
                    foreach (Control control in panel.Controls) if (((IRemoveable)control).Locked == false) setter(control, (Color)color); 
                }
            }
        }

        public static void UpdateControlsFont(params TableLayoutPanel[] tablePanels)
        {
            Font? font = GetFontByDialog();
            if (font is null) return;

            foreach (TableLayoutPanel tablePanel in tablePanels)
            {
                foreach (Panel panel in tablePanel.Controls)
                {
                    foreach (Control control in panel.Controls) if (((IRemoveable)control).Locked == false) control.Font = (Font)font;
                }
            }
        }

        private static void SetBackColor(Control control, System.Drawing.Color color) => control.BackColor = color;
        private static void SetForeColor(Control control, System.Drawing.Color color) => control.ForeColor = color;

        private delegate void SetColor(Control control, System.Drawing.Color color);

        
    }
}
