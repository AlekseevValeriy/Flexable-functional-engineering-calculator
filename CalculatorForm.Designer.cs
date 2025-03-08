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
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.functionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bordersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.placementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.topToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bottomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fillToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.цветToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.displayTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.controlTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.менюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.фонToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.элементыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.цветФонаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.цветШрифтаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlBackgroundColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlFontColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlBorderColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlSelectionColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.цветНажатияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(784, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
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
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bordersToolStripMenuItem,
            this.placementToolStripMenuItem,
            this.fontToolStripMenuItem,
            this.цветToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.viewToolStripMenuItem.Text = "Вид";
            // 
            // bordersToolStripMenuItem
            // 
            this.bordersToolStripMenuItem.Name = "bordersToolStripMenuItem";
            this.bordersToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.bordersToolStripMenuItem.Text = "Границы";
            this.bordersToolStripMenuItem.Click += new System.EventHandler(this.BordersToolClick);
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
            this.placementToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.placementToolStripMenuItem.Text = "Расположение";
            // 
            // noneToolStripMenuItem
            // 
            this.noneToolStripMenuItem.Name = "noneToolStripMenuItem";
            this.noneToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.noneToolStripMenuItem.Text = "None";
            this.noneToolStripMenuItem.Click += new System.EventHandler(this.NoneToolClick);
            // 
            // topToolStripMenuItem
            // 
            this.topToolStripMenuItem.Name = "topToolStripMenuItem";
            this.topToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.topToolStripMenuItem.Text = "Top";
            this.topToolStripMenuItem.Click += new System.EventHandler(this.TopToolClick);
            // 
            // bottomToolStripMenuItem
            // 
            this.bottomToolStripMenuItem.Name = "bottomToolStripMenuItem";
            this.bottomToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.bottomToolStripMenuItem.Text = "Bottom";
            this.bottomToolStripMenuItem.Click += new System.EventHandler(this.BottomToolClick);
            // 
            // rightToolStripMenuItem
            // 
            this.rightToolStripMenuItem.Name = "rightToolStripMenuItem";
            this.rightToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.rightToolStripMenuItem.Text = "Right";
            this.rightToolStripMenuItem.Click += new System.EventHandler(this.RightToolClick);
            // 
            // leftToolStripMenuItem
            // 
            this.leftToolStripMenuItem.Name = "leftToolStripMenuItem";
            this.leftToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.leftToolStripMenuItem.Text = "Left";
            this.leftToolStripMenuItem.Click += new System.EventHandler(this.LeftToolClick);
            // 
            // fillToolStripMenuItem
            // 
            this.fillToolStripMenuItem.Name = "fillToolStripMenuItem";
            this.fillToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.fillToolStripMenuItem.Text = "Fill";
            this.fillToolStripMenuItem.Click += new System.EventHandler(this.FillToolClick);
            // 
            // fontToolStripMenuItem
            // 
            this.fontToolStripMenuItem.Name = "fontToolStripMenuItem";
            this.fontToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.fontToolStripMenuItem.Text = "Шрифт";
            this.fontToolStripMenuItem.Click += new System.EventHandler(this.FontToolClick);
            // 
            // цветToolStripMenuItem
            // 
            this.цветToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.менюToolStripMenuItem,
            this.фонToolStripMenuItem,
            this.элементыToolStripMenuItem});
            this.цветToolStripMenuItem.Name = "цветToolStripMenuItem";
            this.цветToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.цветToolStripMenuItem.Text = "Цвет";
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
            this.splitContainer.SplitterDistance = 87;
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
            this.displayTableLayoutPanel.Size = new System.Drawing.Size(784, 87);
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
            this.controlTableLayoutPanel.Size = new System.Drawing.Size(784, 346);
            this.controlTableLayoutPanel.TabIndex = 0;
            // 
            // менюToolStripMenuItem
            // 
            this.менюToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.цветФонаToolStripMenuItem,
            this.цветШрифтаToolStripMenuItem});
            this.менюToolStripMenuItem.Name = "менюToolStripMenuItem";
            this.менюToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.менюToolStripMenuItem.Text = "Меню";
            // 
            // фонToolStripMenuItem
            // 
            this.фонToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backgroundColorToolStripMenuItem});
            this.фонToolStripMenuItem.Name = "фонToolStripMenuItem";
            this.фонToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.фонToolStripMenuItem.Text = "Фон";
            // 
            // элементыToolStripMenuItem
            // 
            this.элементыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.controlBackgroundColorToolStripMenuItem,
            this.controlFontColorToolStripMenuItem,
            this.controlBorderColorToolStripMenuItem,
            this.controlSelectionColorToolStripMenuItem,
            this.цветНажатияToolStripMenuItem});
            this.элементыToolStripMenuItem.Name = "элементыToolStripMenuItem";
            this.элементыToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.элементыToolStripMenuItem.Text = "Элементы";
            // 
            // цветФонаToolStripMenuItem
            // 
            this.цветФонаToolStripMenuItem.Name = "цветФонаToolStripMenuItem";
            this.цветФонаToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.цветФонаToolStripMenuItem.Text = "Цвет фона";
            // 
            // цветШрифтаToolStripMenuItem
            // 
            this.цветШрифтаToolStripMenuItem.Name = "цветШрифтаToolStripMenuItem";
            this.цветШрифтаToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.цветШрифтаToolStripMenuItem.Text = "Цвет шрифта";
            // 
            // backgroundColorToolStripMenuItem
            // 
            this.backgroundColorToolStripMenuItem.Name = "backgroundColorToolStripMenuItem";
            this.backgroundColorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.backgroundColorToolStripMenuItem.Text = "Цвет фона";
            // 
            // controlBackgroundColorToolStripMenuItem
            // 
            this.controlBackgroundColorToolStripMenuItem.Name = "controlBackgroundColorToolStripMenuItem";
            this.controlBackgroundColorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.controlBackgroundColorToolStripMenuItem.Text = "Цвет фона";
            // 
            // controlFontColorToolStripMenuItem
            // 
            this.controlFontColorToolStripMenuItem.Name = "controlFontColorToolStripMenuItem";
            this.controlFontColorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.controlFontColorToolStripMenuItem.Text = "Цвет шрифта";
            // 
            // controlBorderColorToolStripMenuItem
            // 
            this.controlBorderColorToolStripMenuItem.Name = "controlBorderColorToolStripMenuItem";
            this.controlBorderColorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.controlBorderColorToolStripMenuItem.Text = "Цвет бордюров";
            // 
            // controlSelectionColorToolStripMenuItem
            // 
            this.controlSelectionColorToolStripMenuItem.Name = "controlSelectionColorToolStripMenuItem";
            this.controlSelectionColorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.controlSelectionColorToolStripMenuItem.Text = "Цвет выделения";
            // 
            // цветНажатияToolStripMenuItem
            // 
            this.цветНажатияToolStripMenuItem.Name = "цветНажатияToolStripMenuItem";
            this.цветНажатияToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.цветНажатияToolStripMenuItem.Text = "Цвет нажатия";
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
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem bordersToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem placementToolStripMenuItem;
        private ToolStripMenuItem noneToolStripMenuItem;
        private ToolStripMenuItem leftToolStripMenuItem;
        private ToolStripMenuItem fillToolStripMenuItem;
        private ToolStripMenuItem topToolStripMenuItem;
        private ToolStripMenuItem bottomToolStripMenuItem;
        private ToolStripMenuItem rightToolStripMenuItem;
        private ToolStripMenuItem fontToolStripMenuItem;
        private ToolStripMenuItem цветToolStripMenuItem;
        private ToolStripMenuItem менюToolStripMenuItem;
        private ToolStripMenuItem цветФонаToolStripMenuItem;
        private ToolStripMenuItem цветШрифтаToolStripMenuItem;
        private ToolStripMenuItem фонToolStripMenuItem;
        private ToolStripMenuItem backgroundColorToolStripMenuItem;
        private ToolStripMenuItem элементыToolStripMenuItem;
        private ToolStripMenuItem controlBackgroundColorToolStripMenuItem;
        private ToolStripMenuItem controlFontColorToolStripMenuItem;
        private ToolStripMenuItem controlBorderColorToolStripMenuItem;
        private ToolStripMenuItem controlSelectionColorToolStripMenuItem;
        private ToolStripMenuItem цветНажатияToolStripMenuItem;
    }
}

