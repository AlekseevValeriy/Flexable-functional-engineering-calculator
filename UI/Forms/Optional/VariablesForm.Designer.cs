namespace FFEC.UI.Forms.Optional
{
    partial class VariablesForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.NFName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.dataGridView, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.addButton, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.removeButton, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(213, 171);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeColumns = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NFName,
            this.Value});
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridView, 2);
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(2, 2);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(209, 135);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridViewCellBeginEdit);
            this.dataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCellEndEdit);
            // 
            // NFName
            // 
            this.NFName.HeaderText = "Название";
            this.NFName.Name = "NFName";
            this.NFName.ReadOnly = true;
            // 
            // Value
            // 
            this.Value.HeaderText = "Значение";
            this.Value.Name = "Value";
            // 
            // addButton
            // 
            this.addButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addButton.Location = new System.Drawing.Point(2, 141);
            this.addButton.Margin = new System.Windows.Forms.Padding(2);
            this.addButton.MaximumSize = new System.Drawing.Size(100, 28);
            this.addButton.MinimumSize = new System.Drawing.Size(100, 28);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(100, 28);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "Добавить";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.AddVariable);
            // 
            // removeButton
            // 
            this.removeButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.removeButton.Location = new System.Drawing.Point(108, 141);
            this.removeButton.Margin = new System.Windows.Forms.Padding(2);
            this.removeButton.MaximumSize = new System.Drawing.Size(100, 28);
            this.removeButton.MinimumSize = new System.Drawing.Size(100, 28);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(100, 28);
            this.removeButton.TabIndex = 2;
            this.removeButton.Text = "Удалить";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.RemoveVariable);
            // 
            // VariablesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(213, 171);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(229, 210);
            this.Name = "VariablesForm";
            this.Text = "Переменные";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.Shown += new System.EventHandler(Handler.TrackableFormShown);
            this.FormClosed += new FormClosedEventHandler(Handler.TrackableFormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private DataGridView dataGridView;
        private Button addButton;
        private Button removeButton;
        private DataGridViewTextBoxColumn NFName;
        private DataGridViewTextBoxColumn Value;
    }
}