namespace FFEC
{
    partial class ChangeSizeForm
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
            this.heightLabel = new System.Windows.Forms.Label();
            this.widthLabel = new System.Windows.Forms.Label();
            this.heightTextBox = new System.Windows.Forms.TextBox();
            this.widthTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.heightLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.widthLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.heightTextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.widthTextBox, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(259, 91);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // heightLabel
            // 
            this.heightLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.heightLabel.AutoSize = true;
            this.heightLabel.Location = new System.Drawing.Point(42, 16);
            this.heightLabel.Name = "heightLabel";
            this.heightLabel.Size = new System.Drawing.Size(45, 13);
            this.heightLabel.TabIndex = 0;
            this.heightLabel.Text = "Высота";
            // 
            // widthLabel
            // 
            this.widthLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.widthLabel.AutoSize = true;
            this.widthLabel.Location = new System.Drawing.Point(41, 61);
            this.widthLabel.Name = "widthLabel";
            this.widthLabel.Size = new System.Drawing.Size(46, 13);
            this.widthLabel.TabIndex = 1;
            this.widthLabel.Text = "Ширина";
            // 
            // heightTextBox
            // 
            this.heightTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.heightTextBox.Location = new System.Drawing.Point(144, 12);
            this.heightTextBox.Name = "heightTextBox";
            this.heightTextBox.Size = new System.Drawing.Size(100, 20);
            this.heightTextBox.TabIndex = 2;
            this.heightTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PerformKeyShortcut);
            this.heightTextBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.heightTextBoxMouseDown);
            // 
            // widthTextBox
            // 
            this.widthTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.widthTextBox.Location = new System.Drawing.Point(144, 58);
            this.widthTextBox.Name = "widthTextBox";
            this.widthTextBox.Size = new System.Drawing.Size(100, 20);
            this.widthTextBox.TabIndex = 3;
            this.widthTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PerformKeyShortcut);
            // 
            // ChangeSizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 91);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(275, 130);
            this.Name = "ChangeSizeForm";
            this.Text = "Настройка размера";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChangeSizeFormClosing);
            this.Shown += new System.EventHandler(this.ChangeSizeFormShown);
            this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.heightTextBoxMouseDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label heightLabel;
        private Label widthLabel;
        private TextBox heightTextBox;
        private TextBox widthTextBox;
    }
}