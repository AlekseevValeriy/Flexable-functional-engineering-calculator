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
            this.LayoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.functionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bordersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.менюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.foreColorMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundColorMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.фонToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.элементыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlsFontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlsFontColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlBackgroundColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlsBorderColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlsSelectionColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlsPressColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.placementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.topToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bottomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fillToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вместительностьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отображениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayAddRowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayRemoveRowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.управлениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlsAddRowtoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlsRemoveRowtoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlsAddColumntoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlsRemoveColumntoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.LayoutToolStripMenuItem,
            this.addToolStripMenuItem,
            this.настройкиToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(784, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // LayoutToolStripMenuItem
            // 
            this.LayoutToolStripMenuItem.Name = "LayoutToolStripMenuItem";
            this.LayoutToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.LayoutToolStripMenuItem.Text = "Макет";
            this.LayoutToolStripMenuItem.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.LayoutToolStripMenuItem.Click += new System.EventHandler(this.LayoutToolClick);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.controlToolStripMenuItem,
            this.functionToolStripMenuItem});
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.addToolStripMenuItem.Text = "Добавить";
            // 
            // controlToolStripMenuItem
            // 
            this.controlToolStripMenuItem.Name = "controlToolStripMenuItem";
            this.controlToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.controlToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.controlToolStripMenuItem.Text = "Управление";
            this.controlToolStripMenuItem.Click += new System.EventHandler(this.ControlToolClick);
            // 
            // functionToolStripMenuItem
            // 
            this.functionToolStripMenuItem.Name = "functionToolStripMenuItem";
            this.functionToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.functionToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.functionToolStripMenuItem.Text = "Функцию";
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewToolStripMenuItem,
            this.placementToolStripMenuItem,
            this.вместительностьToolStripMenuItem});
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bordersToolStripMenuItem,
            this.менюToolStripMenuItem,
            this.фонToolStripMenuItem,
            this.элементыToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.viewToolStripMenuItem.Text = "Вид";
            // 
            // bordersToolStripMenuItem
            // 
            this.bordersToolStripMenuItem.Name = "bordersToolStripMenuItem";
            this.bordersToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.bordersToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.bordersToolStripMenuItem.Text = "Границы";
            this.bordersToolStripMenuItem.Click += new System.EventHandler(this.BordersToolClick);
            // 
            // менюToolStripMenuItem
            // 
            this.менюToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fontMenuToolStripMenuItem,
            this.foreColorMenuToolStripMenuItem,
            this.backgroundColorMenuToolStripMenuItem});
            this.менюToolStripMenuItem.Name = "менюToolStripMenuItem";
            this.менюToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.менюToolStripMenuItem.Text = "Меню";
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
            // фонToolStripMenuItem
            // 
            this.фонToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backgroundColorToolStripMenuItem});
            this.фонToolStripMenuItem.Name = "фонToolStripMenuItem";
            this.фонToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.фонToolStripMenuItem.Text = "Фон";
            // 
            // backgroundColorToolStripMenuItem
            // 
            this.backgroundColorToolStripMenuItem.Name = "backgroundColorToolStripMenuItem";
            this.backgroundColorToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.backgroundColorToolStripMenuItem.Text = "Цвет фона";
            this.backgroundColorToolStripMenuItem.Click += new System.EventHandler(this.BackgroundColorToolClick);
            // 
            // элементыToolStripMenuItem
            // 
            this.элементыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.controlsFontToolStripMenuItem,
            this.controlsFontColorToolStripMenuItem,
            this.controlBackgroundColorToolStripMenuItem,
            this.controlsBorderColorToolStripMenuItem,
            this.controlsSelectionColorToolStripMenuItem,
            this.controlsPressColorToolStripMenuItem});
            this.элементыToolStripMenuItem.Name = "элементыToolStripMenuItem";
            this.элементыToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.элементыToolStripMenuItem.Text = "Управление";
            // 
            // controlsFontToolStripMenuItem
            // 
            this.controlsFontToolStripMenuItem.Name = "controlsFontToolStripMenuItem";
            this.controlsFontToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.controlsFontToolStripMenuItem.Text = "Шрифт";
            this.controlsFontToolStripMenuItem.Click += new System.EventHandler(this.FontToolClick);
            // 
            // controlsFontColorToolStripMenuItem
            // 
            this.controlsFontColorToolStripMenuItem.Name = "controlsFontColorToolStripMenuItem";
            this.controlsFontColorToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.controlsFontColorToolStripMenuItem.Text = "Цвет шрифта";
            this.controlsFontColorToolStripMenuItem.Click += new System.EventHandler(this.ControlsFontColorToolClick);
            // 
            // controlBackgroundColorToolStripMenuItem
            // 
            this.controlBackgroundColorToolStripMenuItem.Name = "controlBackgroundColorToolStripMenuItem";
            this.controlBackgroundColorToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.controlBackgroundColorToolStripMenuItem.Text = "Цвет фона";
            this.controlBackgroundColorToolStripMenuItem.Click += new System.EventHandler(this.ControlsPressColorToolClick);
            // 
            // controlsBorderColorToolStripMenuItem
            // 
            this.controlsBorderColorToolStripMenuItem.Name = "controlsBorderColorToolStripMenuItem";
            this.controlsBorderColorToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.controlsBorderColorToolStripMenuItem.Text = "Цвет бордюров";
            this.controlsBorderColorToolStripMenuItem.Click += new System.EventHandler(this.ControlsBorderColorToolClick);
            // 
            // controlsSelectionColorToolStripMenuItem
            // 
            this.controlsSelectionColorToolStripMenuItem.Name = "controlsSelectionColorToolStripMenuItem";
            this.controlsSelectionColorToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.controlsSelectionColorToolStripMenuItem.Text = "Цвет выделения";
            this.controlsSelectionColorToolStripMenuItem.Click += new System.EventHandler(this.ControlsSelectionColorToolClick);
            // 
            // controlsPressColorToolStripMenuItem
            // 
            this.controlsPressColorToolStripMenuItem.Name = "controlsPressColorToolStripMenuItem";
            this.controlsPressColorToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.controlsPressColorToolStripMenuItem.Text = "Цвет нажатия";
            this.controlsPressColorToolStripMenuItem.Click += new System.EventHandler(this.ControlsPressColorToolClick);
            // 
            // placementToolStripMenuItem
            // 
            this.placementToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.noneToolStripMenuItem,
            this.topToolStripMenuItem,
            this.bottomToolStripMenuItem,
            this.rightToolStripMenuItem,
            this.leftToolStripMenuItem,
            this.fillToolStripMenuItem});
            this.placementToolStripMenuItem.Name = "placementToolStripMenuItem";
            this.placementToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.placementToolStripMenuItem.Text = "Расположение";
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
            this.topToolStripMenuItem.Text = "Верх";
            this.topToolStripMenuItem.Click += new System.EventHandler(this.TopToolClick);
            // 
            // bottomToolStripMenuItem
            // 
            this.bottomToolStripMenuItem.Name = "bottomToolStripMenuItem";
            this.bottomToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Down)));
            this.bottomToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.bottomToolStripMenuItem.Text = "Низ";
            this.bottomToolStripMenuItem.Click += new System.EventHandler(this.BottomToolClick);
            // 
            // rightToolStripMenuItem
            // 
            this.rightToolStripMenuItem.Name = "rightToolStripMenuItem";
            this.rightToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Right)));
            this.rightToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.rightToolStripMenuItem.Text = "Право";
            this.rightToolStripMenuItem.Click += new System.EventHandler(this.RightToolClick);
            // 
            // leftToolStripMenuItem
            // 
            this.leftToolStripMenuItem.Name = "leftToolStripMenuItem";
            this.leftToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Left)));
            this.leftToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.leftToolStripMenuItem.Text = "Лево";
            this.leftToolStripMenuItem.Click += new System.EventHandler(this.LeftToolClick);
            // 
            // fillToolStripMenuItem
            // 
            this.fillToolStripMenuItem.Name = "fillToolStripMenuItem";
            this.fillToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Space)));
            this.fillToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.fillToolStripMenuItem.Text = "Заполнение";
            this.fillToolStripMenuItem.Click += new System.EventHandler(this.FillToolClick);
            // 
            // вместительностьToolStripMenuItem
            // 
            this.вместительностьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.отображениеToolStripMenuItem,
            this.управлениеToolStripMenuItem});
            this.вместительностьToolStripMenuItem.Name = "вместительностьToolStripMenuItem";
            this.вместительностьToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.вместительностьToolStripMenuItem.Text = "Вместительность";
            // 
            // отображениеToolStripMenuItem
            // 
            this.отображениеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.displayAddRowToolStripMenuItem,
            this.displayRemoveRowToolStripMenuItem});
            this.отображениеToolStripMenuItem.Name = "отображениеToolStripMenuItem";
            this.отображениеToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.отображениеToolStripMenuItem.Text = "Отображение";
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
            // управлениеToolStripMenuItem
            // 
            this.управлениеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.controlsAddRowtoolStripMenuItem,
            this.controlsRemoveRowtoolStripMenuItem,
            this.controlsAddColumntoolStripMenuItem,
            this.controlsRemoveColumntoolStripMenuItem});
            this.управлениеToolStripMenuItem.Name = "управлениеToolStripMenuItem";
            this.управлениеToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.управлениеToolStripMenuItem.Text = "Управление";
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
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.aboutToolStripMenuItem.Text = "О программе";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
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
            this.splitContainer.SplitterDistance = 86;
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
            this.displayTableLayoutPanel.Size = new System.Drawing.Size(784, 86);
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
            this.controlTableLayoutPanel.Size = new System.Drawing.Size(784, 347);
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
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem functionToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.ToolStripMenuItem controlToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel displayTableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel controlTableLayoutPanel;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem настройкиToolStripMenuItem;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem bordersToolStripMenuItem;
        private ToolStripMenuItem менюToolStripMenuItem;
        private ToolStripMenuItem fontMenuToolStripMenuItem;
        private ToolStripMenuItem foreColorMenuToolStripMenuItem;
        private ToolStripMenuItem backgroundColorMenuToolStripMenuItem;
        private ToolStripMenuItem фонToolStripMenuItem;
        private ToolStripMenuItem backgroundColorToolStripMenuItem;
        private ToolStripMenuItem элементыToolStripMenuItem;
        private ToolStripMenuItem controlsFontToolStripMenuItem;
        private ToolStripMenuItem controlsFontColorToolStripMenuItem;
        private ToolStripMenuItem controlBackgroundColorToolStripMenuItem;
        private ToolStripMenuItem controlsBorderColorToolStripMenuItem;
        private ToolStripMenuItem controlsSelectionColorToolStripMenuItem;
        private ToolStripMenuItem controlsPressColorToolStripMenuItem;
        private ToolStripMenuItem placementToolStripMenuItem;
        private ToolStripMenuItem noneToolStripMenuItem;
        private ToolStripMenuItem topToolStripMenuItem;
        private ToolStripMenuItem bottomToolStripMenuItem;
        private ToolStripMenuItem rightToolStripMenuItem;
        private ToolStripMenuItem leftToolStripMenuItem;
        private ToolStripMenuItem fillToolStripMenuItem;
        private ToolStripMenuItem вместительностьToolStripMenuItem;
        private ToolStripMenuItem отображениеToolStripMenuItem;
        private ToolStripMenuItem displayAddRowToolStripMenuItem;
        private ToolStripMenuItem displayRemoveRowToolStripMenuItem;
        private ToolStripMenuItem управлениеToolStripMenuItem;
        private ToolStripMenuItem controlsRemoveRowtoolStripMenuItem;
        private ToolStripMenuItem controlsAddRowtoolStripMenuItem;
        private ToolStripMenuItem controlsAddColumntoolStripMenuItem;
        private ToolStripMenuItem controlsRemoveColumntoolStripMenuItem;
        private ToolStripMenuItem LayoutToolStripMenuItem;
    }
}

