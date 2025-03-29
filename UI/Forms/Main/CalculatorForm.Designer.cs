namespace FFEC
{
    partial class CalculatorForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.макетToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveLayoutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.layoutMenegerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlMenegerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dockMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.topToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bottomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fillToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlsFontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlsFontColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlBackgroundColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlsSelectionColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlsPressColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlsBorderColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.foreColorMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundColorMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formBackgroundMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bordersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayTableMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayAddRowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayRemoveRowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlTableMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlsAddRowtoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlsRemoveRowtoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlsAddColumntoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlsRemoveColumntoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addendumMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.functionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.variablesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.displayTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.controlTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.макетToolStripMenuItem,
            this.variablesToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(784, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // макетToolStripMenuItem
            // 
            this.макетToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveLayoutMenuItem,
            this.layoutMenegerMenuItem,
            this.controlMenegerMenuItem,
            this.changeMenuItem,
            this.gridMenuItem,
            this.addendumMenuItem});
            this.макетToolStripMenuItem.Name = "макетToolStripMenuItem";
            this.макетToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.макетToolStripMenuItem.Text = "Макет";
            // 
            // saveLayoutMenuItem
            // 
            this.saveLayoutMenuItem.Name = "saveLayoutMenuItem";
            this.saveLayoutMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveLayoutMenuItem.Size = new System.Drawing.Size(235, 22);
            this.saveLayoutMenuItem.Text = "Сохранить макет";
            this.saveLayoutMenuItem.Click += new System.EventHandler(this.saveLayoutClick);
            // 
            // layoutMenegerMenuItem
            // 
            this.layoutMenegerMenuItem.Name = "layoutMenegerMenuItem";
            this.layoutMenegerMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.layoutMenegerMenuItem.Size = new System.Drawing.Size(235, 22);
            this.layoutMenegerMenuItem.Text = "Менеджер макетов";
            this.layoutMenegerMenuItem.Click += new System.EventHandler(this.LayoutToolClick);
            // 
            // controlMenegerMenuItem
            // 
            this.controlMenegerMenuItem.Name = "controlMenegerMenuItem";
            this.controlMenegerMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.controlMenegerMenuItem.Size = new System.Drawing.Size(235, 22);
            this.controlMenegerMenuItem.Text = "Каталог управления";
            this.controlMenegerMenuItem.Click += new System.EventHandler(this.ControlToolClick);
            // 
            // changeMenuItem
            // 
            this.changeMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.controlsMenuItem,
            this.menuStripMenuItem,
            this.formBackgroundMenuItem});
            this.changeMenuItem.Name = "changeMenuItem";
            this.changeMenuItem.Size = new System.Drawing.Size(235, 22);
            this.changeMenuItem.Text = "Изменить";
            // 
            // controlsMenuItem
            // 
            this.controlsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dockMenuItem,
            this.controlsFontToolStripMenuItem,
            this.controlsFontColorToolStripMenuItem,
            this.controlBackgroundColorToolStripMenuItem,
            this.controlsSelectionColorToolStripMenuItem,
            this.controlsPressColorToolStripMenuItem,
            this.controlsBorderColorToolStripMenuItem});
            this.controlsMenuItem.Name = "controlsMenuItem";
            this.controlsMenuItem.Size = new System.Drawing.Size(140, 22);
            this.controlsMenuItem.Text = "Управление";
            // 
            // dockMenuItem
            // 
            this.dockMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.noneToolStripMenuItem,
            this.topToolStripMenuItem,
            this.bottomToolStripMenuItem,
            this.leftToolStripMenuItem,
            this.rightToolStripMenuItem,
            this.fillToolStripMenuItem});
            this.dockMenuItem.Name = "dockMenuItem";
            this.dockMenuItem.Size = new System.Drawing.Size(217, 22);
            this.dockMenuItem.Text = "Расположение";
            // 
            // noneToolStripMenuItem
            // 
            this.noneToolStripMenuItem.Name = "noneToolStripMenuItem";
            this.noneToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Delete)));
            this.noneToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.noneToolStripMenuItem.Text = "Нет";
            this.noneToolStripMenuItem.Click += new System.EventHandler(this.NoneToolClick);
            // 
            // topToolStripMenuItem
            // 
            this.topToolStripMenuItem.Name = "topToolStripMenuItem";
            this.topToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Up)));
            this.topToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.topToolStripMenuItem.Text = "Сверху";
            this.topToolStripMenuItem.Click += new System.EventHandler(this.TopToolClick);
            // 
            // bottomToolStripMenuItem
            // 
            this.bottomToolStripMenuItem.Name = "bottomToolStripMenuItem";
            this.bottomToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Down)));
            this.bottomToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.bottomToolStripMenuItem.Text = "Снизу";
            this.bottomToolStripMenuItem.Click += new System.EventHandler(this.BottomToolClick);
            // 
            // leftToolStripMenuItem
            // 
            this.leftToolStripMenuItem.Name = "leftToolStripMenuItem";
            this.leftToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Left)));
            this.leftToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.leftToolStripMenuItem.Text = "Слева";
            this.leftToolStripMenuItem.Click += new System.EventHandler(this.LeftToolClick);
            // 
            // rightToolStripMenuItem
            // 
            this.rightToolStripMenuItem.Name = "rightToolStripMenuItem";
            this.rightToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Right)));
            this.rightToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.rightToolStripMenuItem.Text = "Справа";
            this.rightToolStripMenuItem.Click += new System.EventHandler(this.RightToolClick);
            // 
            // fillToolStripMenuItem
            // 
            this.fillToolStripMenuItem.Name = "fillToolStripMenuItem";
            this.fillToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Space)));
            this.fillToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.fillToolStripMenuItem.Text = "Заполнение";
            this.fillToolStripMenuItem.Click += new System.EventHandler(this.FillToolClick);
            // 
            // controlsFontToolStripMenuItem
            // 
            this.controlsFontToolStripMenuItem.Name = "controlsFontToolStripMenuItem";
            this.controlsFontToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.controlsFontToolStripMenuItem.Text = "Шрифт";
            this.controlsFontToolStripMenuItem.Click += new System.EventHandler(this.FontToolClick);
            // 
            // controlsFontColorToolStripMenuItem
            // 
            this.controlsFontColorToolStripMenuItem.Name = "controlsFontColorToolStripMenuItem";
            this.controlsFontColorToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.controlsFontColorToolStripMenuItem.Text = "Цвет шрифта";
            this.controlsFontColorToolStripMenuItem.Click += new System.EventHandler(this.ControlsFontColorToolClick);
            // 
            // controlBackgroundColorToolStripMenuItem
            // 
            this.controlBackgroundColorToolStripMenuItem.Name = "controlBackgroundColorToolStripMenuItem";
            this.controlBackgroundColorToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.controlBackgroundColorToolStripMenuItem.Text = "Цвет фона";
            this.controlBackgroundColorToolStripMenuItem.Click += new System.EventHandler(this.ControlsBackColorToolClick);
            // 
            // controlsSelectionColorToolStripMenuItem
            // 
            this.controlsSelectionColorToolStripMenuItem.Name = "controlsSelectionColorToolStripMenuItem";
            this.controlsSelectionColorToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.controlsSelectionColorToolStripMenuItem.Text = "Цвет фона при наведении";
            this.controlsSelectionColorToolStripMenuItem.Click += new System.EventHandler(this.ControlsSelectionColorToolClick);
            // 
            // controlsPressColorToolStripMenuItem
            // 
            this.controlsPressColorToolStripMenuItem.Name = "controlsPressColorToolStripMenuItem";
            this.controlsPressColorToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.controlsPressColorToolStripMenuItem.Text = "Цвет фона при нажатии";
            this.controlsPressColorToolStripMenuItem.Click += new System.EventHandler(this.ControlsPressColorToolClick);
            // 
            // controlsBorderColorToolStripMenuItem
            // 
            this.controlsBorderColorToolStripMenuItem.Name = "controlsBorderColorToolStripMenuItem";
            this.controlsBorderColorToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.controlsBorderColorToolStripMenuItem.Text = "Цвет границ";
            this.controlsBorderColorToolStripMenuItem.Click += new System.EventHandler(this.ControlsBorderColorToolClick);
            // 
            // menuStripMenuItem
            // 
            this.menuStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fontMenuToolStripMenuItem,
            this.foreColorMenuToolStripMenuItem,
            this.backgroundColorMenuToolStripMenuItem});
            this.menuStripMenuItem.Name = "menuStripMenuItem";
            this.menuStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.menuStripMenuItem.Text = "Меню";
            // 
            // fontMenuToolStripMenuItem
            // 
            this.fontMenuToolStripMenuItem.Name = "fontMenuToolStripMenuItem";
            this.fontMenuToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.fontMenuToolStripMenuItem.Text = "Шрифт";
            this.fontMenuToolStripMenuItem.Click += new System.EventHandler(this.MenuFontToolClick);
            // 
            // foreColorMenuToolStripMenuItem
            // 
            this.foreColorMenuToolStripMenuItem.Name = "foreColorMenuToolStripMenuItem";
            this.foreColorMenuToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.foreColorMenuToolStripMenuItem.Text = "Цвет шрифта";
            this.foreColorMenuToolStripMenuItem.Click += new System.EventHandler(this.MenuFontColorToolClick);
            // 
            // backgroundColorMenuToolStripMenuItem
            // 
            this.backgroundColorMenuToolStripMenuItem.Name = "backgroundColorMenuToolStripMenuItem";
            this.backgroundColorMenuToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.backgroundColorMenuToolStripMenuItem.Text = "Цвет фона";
            this.backgroundColorMenuToolStripMenuItem.Click += new System.EventHandler(this.MenuStripColorToolClick);
            // 
            // formBackgroundMenuItem
            // 
            this.formBackgroundMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backgroundColorToolStripMenuItem});
            this.formBackgroundMenuItem.Name = "formBackgroundMenuItem";
            this.formBackgroundMenuItem.Size = new System.Drawing.Size(140, 22);
            this.formBackgroundMenuItem.Text = "Фон";
            // 
            // backgroundColorToolStripMenuItem
            // 
            this.backgroundColorToolStripMenuItem.Name = "backgroundColorToolStripMenuItem";
            this.backgroundColorToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.backgroundColorToolStripMenuItem.Text = "Цвет";
            this.backgroundColorToolStripMenuItem.Click += new System.EventHandler(this.BackgroundColorToolClick);
            // 
            // gridMenuItem
            // 
            this.gridMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bordersToolStripMenuItem,
            this.displayTableMenuItem,
            this.controlTableMenuItem});
            this.gridMenuItem.Name = "gridMenuItem";
            this.gridMenuItem.Size = new System.Drawing.Size(235, 22);
            this.gridMenuItem.Text = "Сетка";
            // 
            // bordersToolStripMenuItem
            // 
            this.bordersToolStripMenuItem.Name = "bordersToolStripMenuItem";
            this.bordersToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.bordersToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.bordersToolStripMenuItem.Text = "Границы";
            this.bordersToolStripMenuItem.Click += new System.EventHandler(this.BordersToolClick);
            // 
            // displayTableMenuItem
            // 
            this.displayTableMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.displayAddRowToolStripMenuItem,
            this.displayRemoveRowToolStripMenuItem});
            this.displayTableMenuItem.Name = "displayTableMenuItem";
            this.displayTableMenuItem.Size = new System.Drawing.Size(172, 22);
            this.displayTableMenuItem.Text = "Отображения";
            // 
            // displayAddRowToolStripMenuItem
            // 
            this.displayAddRowToolStripMenuItem.Name = "displayAddRowToolStripMenuItem";
            this.displayAddRowToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.displayAddRowToolStripMenuItem.Text = "Добавить строку";
            this.displayAddRowToolStripMenuItem.Click += new System.EventHandler(this.DisplayAddRowToolClick);
            // 
            // displayRemoveRowToolStripMenuItem
            // 
            this.displayRemoveRowToolStripMenuItem.Name = "displayRemoveRowToolStripMenuItem";
            this.displayRemoveRowToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.displayRemoveRowToolStripMenuItem.Text = "Удалить строку";
            this.displayRemoveRowToolStripMenuItem.Click += new System.EventHandler(this.DisplayRemoveRowToolClick);
            // 
            // controlTableMenuItem
            // 
            this.controlTableMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.controlsAddRowtoolStripMenuItem,
            this.controlsRemoveRowtoolStripMenuItem,
            this.controlsAddColumntoolStripMenuItem,
            this.controlsRemoveColumntoolStripMenuItem});
            this.controlTableMenuItem.Name = "controlTableMenuItem";
            this.controlTableMenuItem.Size = new System.Drawing.Size(172, 22);
            this.controlTableMenuItem.Text = "Управления";
            // 
            // controlsAddRowtoolStripMenuItem
            // 
            this.controlsAddRowtoolStripMenuItem.Name = "controlsAddRowtoolStripMenuItem";
            this.controlsAddRowtoolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.controlsAddRowtoolStripMenuItem.Text = "Добавить строку";
            this.controlsAddRowtoolStripMenuItem.Click += new System.EventHandler(this.ControlsAddRowToolClick);
            // 
            // controlsRemoveRowtoolStripMenuItem
            // 
            this.controlsRemoveRowtoolStripMenuItem.Name = "controlsRemoveRowtoolStripMenuItem";
            this.controlsRemoveRowtoolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.controlsRemoveRowtoolStripMenuItem.Text = "Удалить строку";
            this.controlsRemoveRowtoolStripMenuItem.Click += new System.EventHandler(this.ControlsRemoveRowToolClick);
            // 
            // controlsAddColumntoolStripMenuItem
            // 
            this.controlsAddColumntoolStripMenuItem.Name = "controlsAddColumntoolStripMenuItem";
            this.controlsAddColumntoolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.controlsAddColumntoolStripMenuItem.Text = "Добавить столбец";
            this.controlsAddColumntoolStripMenuItem.Click += new System.EventHandler(this.ControlsAddColumnToolClick);
            // 
            // controlsRemoveColumntoolStripMenuItem
            // 
            this.controlsRemoveColumntoolStripMenuItem.Name = "controlsRemoveColumntoolStripMenuItem";
            this.controlsRemoveColumntoolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.controlsRemoveColumntoolStripMenuItem.Text = "Удалить столбец";
            this.controlsRemoveColumntoolStripMenuItem.Click += new System.EventHandler(this.ControlsRemoveColumnToolClick);
            // 
            // addendumMenuItem
            // 
            this.addendumMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.functionToolStripMenuItem});
            this.addendumMenuItem.Name = "addendumMenuItem";
            this.addendumMenuItem.Size = new System.Drawing.Size(235, 22);
            this.addendumMenuItem.Text = "Добавить";
            // 
            // functionToolStripMenuItem
            // 
            this.functionToolStripMenuItem.Name = "functionToolStripMenuItem";
            this.functionToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.functionToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.functionToolStripMenuItem.Text = "Функция";
            this.functionToolStripMenuItem.Click += new System.EventHandler(this.functionAddStart);
            // 
            // variablesToolStripMenuItem
            // 
            this.variablesToolStripMenuItem.Name = "variablesToolStripMenuItem";
            this.variablesToolStripMenuItem.Size = new System.Drawing.Size(91, 20);
            this.variablesToolStripMenuItem.Text = "Переменные";
            this.variablesToolStripMenuItem.Click += new System.EventHandler(this.VariablesToolClick);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.aboutToolStripMenuItem.Text = "О программе";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItemClick);
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 24);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.displayTableLayoutPanel);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.controlTableLayoutPanel);
            this.splitContainer.Size = new System.Drawing.Size(784, 437);
            this.splitContainer.SplitterDistance = 85;
            this.splitContainer.TabIndex = 1;
            // 
            // displayTableLayoutPanel
            // 
            this.displayTableLayoutPanel.AllowDrop = true;
            this.displayTableLayoutPanel.ColumnCount = 1;
            this.displayTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.displayTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.displayTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.displayTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.displayTableLayoutPanel.Name = "displayTableLayoutPanel";
            this.displayTableLayoutPanel.RowCount = 1;
            this.displayTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.displayTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.displayTableLayoutPanel.Size = new System.Drawing.Size(784, 85);
            this.displayTableLayoutPanel.TabIndex = 0;
            // 
            // controlTableLayoutPanel
            // 
            this.controlTableLayoutPanel.AllowDrop = true;
            this.controlTableLayoutPanel.ColumnCount = 1;
            this.controlTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.controlTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.controlTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.controlTableLayoutPanel.Name = "controlTableLayoutPanel";
            this.controlTableLayoutPanel.RowCount = 1;
            this.controlTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.controlTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.controlTableLayoutPanel.Size = new System.Drawing.Size(784, 348);
            this.controlTableLayoutPanel.TabIndex = 0;
            // 
            // CalculatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "CalculatorForm";
            this.Text = "FFEC";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CalculatorFormClosing);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.TableLayoutPanel displayTableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel controlTableLayoutPanel;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem variablesToolStripMenuItem;
        private ToolStripMenuItem макетToolStripMenuItem;
        private ToolStripMenuItem layoutMenegerMenuItem;
        private ToolStripMenuItem gridMenuItem;
        private ToolStripMenuItem bordersToolStripMenuItem;
        private ToolStripMenuItem displayTableMenuItem;
        private ToolStripMenuItem displayAddRowToolStripMenuItem;
        private ToolStripMenuItem displayRemoveRowToolStripMenuItem;
        private ToolStripMenuItem controlTableMenuItem;
        private ToolStripMenuItem controlsAddRowtoolStripMenuItem;
        private ToolStripMenuItem controlsRemoveRowtoolStripMenuItem;
        private ToolStripMenuItem controlsAddColumntoolStripMenuItem;
        private ToolStripMenuItem controlsRemoveColumntoolStripMenuItem;
        private ToolStripMenuItem changeMenuItem;
        private ToolStripMenuItem controlMenegerMenuItem;
        private ToolStripMenuItem controlsMenuItem;
        private ToolStripMenuItem dockMenuItem;
        private ToolStripMenuItem controlsFontToolStripMenuItem;
        private ToolStripMenuItem controlsFontColorToolStripMenuItem;
        private ToolStripMenuItem controlBackgroundColorToolStripMenuItem;
        private ToolStripMenuItem controlsSelectionColorToolStripMenuItem;
        private ToolStripMenuItem controlsPressColorToolStripMenuItem;
        private ToolStripMenuItem controlsBorderColorToolStripMenuItem;
        private ToolStripMenuItem menuStripMenuItem;
        private ToolStripMenuItem fontMenuToolStripMenuItem;
        private ToolStripMenuItem foreColorMenuToolStripMenuItem;
        private ToolStripMenuItem backgroundColorMenuToolStripMenuItem;
        private ToolStripMenuItem formBackgroundMenuItem;
        private ToolStripMenuItem backgroundColorToolStripMenuItem;
        private ToolStripMenuItem noneToolStripMenuItem;
        private ToolStripMenuItem topToolStripMenuItem;
        private ToolStripMenuItem bottomToolStripMenuItem;
        private ToolStripMenuItem leftToolStripMenuItem;
        private ToolStripMenuItem rightToolStripMenuItem;
        private ToolStripMenuItem fillToolStripMenuItem;
        private ToolStripMenuItem addendumMenuItem;
        private ToolStripMenuItem functionToolStripMenuItem;
        private ToolStripMenuItem saveLayoutMenuItem;
    }
}

