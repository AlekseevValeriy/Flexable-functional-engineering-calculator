namespace FFEC
{
    partial class layoutMenegerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.setButton = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Configurations = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.savebutton = new System.Windows.Forms.Button();
            this.deleteAllButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.renameButton = new System.Windows.Forms.Button();
            this.addbutton = new System.Windows.Forms.Button();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Controls.Add(this.setButton, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.dataGridView, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.savebutton, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.deleteAllButton, 1, 3);
            this.tableLayoutPanel.Controls.Add(this.deleteButton, 0, 3);
            this.tableLayoutPanel.Controls.Add(this.renameButton, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.addbutton, 1, 2);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 4;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(322, 267);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // setButton
            // 
            this.setButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.setButton.Location = new System.Drawing.Point(2, 173);
            this.setButton.Margin = new System.Windows.Forms.Padding(2);
            this.setButton.Name = "setButton";
            this.setButton.Size = new System.Drawing.Size(157, 28);
            this.setButton.TabIndex = 1;
            this.setButton.Text = "Установить";
            this.setButton.UseVisualStyleBackColor = true;
            this.setButton.Click += new System.EventHandler(this.SetConfiguration);
            this.setButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDownOfAction);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeColumns = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.ColumnHeadersVisible = false;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Configurations});
            this.tableLayoutPanel.SetColumnSpan(this.dataGridView, 2);
            this.dataGridView.Location = new System.Drawing.Point(3, 3);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.Size = new System.Drawing.Size(316, 165);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDownOfAction);
            // 
            // Configurations
            // 
            this.Configurations.HeaderText = "Конфигурации";
            this.Configurations.Name = "Configurations";
            this.Configurations.ReadOnly = true;
            // 
            // savebutton
            // 
            this.savebutton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.savebutton.Location = new System.Drawing.Point(2, 205);
            this.savebutton.Margin = new System.Windows.Forms.Padding(2);
            this.savebutton.Name = "savebutton";
            this.savebutton.Size = new System.Drawing.Size(157, 28);
            this.savebutton.TabIndex = 3;
            this.savebutton.Text = "Сохранить";
            this.savebutton.UseVisualStyleBackColor = true;
            this.savebutton.Click += new System.EventHandler(this.SaveConfiguration);
            this.savebutton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDownOfAction);
            // 
            // deleteAllButton
            // 
            this.deleteAllButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deleteAllButton.Location = new System.Drawing.Point(163, 237);
            this.deleteAllButton.Margin = new System.Windows.Forms.Padding(2);
            this.deleteAllButton.Name = "deleteAllButton";
            this.deleteAllButton.Size = new System.Drawing.Size(157, 28);
            this.deleteAllButton.TabIndex = 6;
            this.deleteAllButton.Text = "Удалить всё";
            this.deleteAllButton.UseVisualStyleBackColor = true;
            this.deleteAllButton.Click += new System.EventHandler(this.DeleteAllConfiguration);
            this.deleteAllButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDownOfAction);
            // 
            // deleteButton
            // 
            this.deleteButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deleteButton.Location = new System.Drawing.Point(2, 237);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(2);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(157, 28);
            this.deleteButton.TabIndex = 5;
            this.deleteButton.Text = "Удалить";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.DeleteConfiguration);
            this.deleteButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDownOfAction);
            // 
            // renameButton
            // 
            this.renameButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.renameButton.Location = new System.Drawing.Point(163, 173);
            this.renameButton.Margin = new System.Windows.Forms.Padding(2);
            this.renameButton.Name = "renameButton";
            this.renameButton.Size = new System.Drawing.Size(157, 28);
            this.renameButton.TabIndex = 2;
            this.renameButton.Text = "Переименовать";
            this.renameButton.UseVisualStyleBackColor = true;
            this.renameButton.Click += new System.EventHandler(this.RenameConfigurationName);
            this.renameButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDownOfAction);
            // 
            // addbutton
            // 
            this.addbutton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addbutton.Location = new System.Drawing.Point(163, 205);
            this.addbutton.Margin = new System.Windows.Forms.Padding(2);
            this.addbutton.Name = "addbutton";
            this.addbutton.Size = new System.Drawing.Size(157, 28);
            this.addbutton.TabIndex = 4;
            this.addbutton.Text = "Добавить";
            this.addbutton.UseVisualStyleBackColor = true;
            this.addbutton.Click += new System.EventHandler(this.AddConfiguration);
            this.addbutton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDownOfAction);
            // 
            // layoutMenegerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 267);
            this.Controls.Add(this.tableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "layoutMenegerForm";
            this.Text = "Менеджер макетов";
            this.Load += new System.EventHandler(this.LayoutMenegerLoad);
            this.Shown += new System.EventHandler(this.LayoutMenegerFormShown);
            this.tableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel;
        private Button setButton;
        private Button addbutton;
        private Button deleteButton;
        private DataGridView dataGridView;
        private DataGridViewTextBoxColumn Configurations;
        private Button savebutton;
        private Button deleteAllButton;
        private Button renameButton;
    }
}