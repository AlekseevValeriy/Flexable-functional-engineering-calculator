namespace FFEC
{
    partial class LayoutMenegerForm
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
            this.layoutsListBox = new System.Windows.Forms.ListBox();
            this.setButton = new System.Windows.Forms.Button();
            this.Addbutton = new System.Windows.Forms.Button();
            this.Savebutton = new System.Windows.Forms.Button();
            this.Deletebutton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.layoutsListBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.setButton, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Addbutton, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.Savebutton, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.Deletebutton, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(322, 267);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // layoutsListBox
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.layoutsListBox, 2);
            this.layoutsListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutsListBox.FormattingEnabled = true;
            this.layoutsListBox.Location = new System.Drawing.Point(2, 2);
            this.layoutsListBox.Margin = new System.Windows.Forms.Padding(2);
            this.layoutsListBox.Name = "layoutsListBox";
            this.layoutsListBox.Size = new System.Drawing.Size(318, 199);
            this.layoutsListBox.TabIndex = 0;
            // 
            // setButton
            // 
            this.setButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.setButton.Location = new System.Drawing.Point(2, 205);
            this.setButton.Margin = new System.Windows.Forms.Padding(2);
            this.setButton.Name = "setButton";
            this.setButton.Size = new System.Drawing.Size(157, 28);
            this.setButton.TabIndex = 1;
            this.setButton.Text = "Установить";
            this.setButton.UseVisualStyleBackColor = true;
            this.setButton.Click += new System.EventHandler(this.SetConfiguration);
            // 
            // Addbutton
            // 
            this.Addbutton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Addbutton.Location = new System.Drawing.Point(163, 205);
            this.Addbutton.Margin = new System.Windows.Forms.Padding(2);
            this.Addbutton.Name = "Addbutton";
            this.Addbutton.Size = new System.Drawing.Size(157, 28);
            this.Addbutton.TabIndex = 2;
            this.Addbutton.Text = "Добавить";
            this.Addbutton.UseVisualStyleBackColor = true;
            this.Addbutton.Click += new System.EventHandler(this.AddConfiguration);
            // 
            // Savebutton
            // 
            this.Savebutton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Savebutton.Location = new System.Drawing.Point(2, 237);
            this.Savebutton.Margin = new System.Windows.Forms.Padding(2);
            this.Savebutton.Name = "Savebutton";
            this.Savebutton.Size = new System.Drawing.Size(157, 28);
            this.Savebutton.TabIndex = 3;
            this.Savebutton.Text = "Сохранить";
            this.Savebutton.UseVisualStyleBackColor = true;
            this.Savebutton.Click += new System.EventHandler(this.SaveConfiguration);
            // 
            // Deletebutton
            // 
            this.Deletebutton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Deletebutton.Location = new System.Drawing.Point(163, 237);
            this.Deletebutton.Margin = new System.Windows.Forms.Padding(2);
            this.Deletebutton.Name = "Deletebutton";
            this.Deletebutton.Size = new System.Drawing.Size(157, 28);
            this.Deletebutton.TabIndex = 4;
            this.Deletebutton.Text = "Удалить";
            this.Deletebutton.UseVisualStyleBackColor = true;
            this.Deletebutton.Click += new System.EventHandler(this.DeleteConfiguration);
            // 
            // LayoutMeneger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 267);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "LayoutMeneger";
            this.Text = "Менеджер макетов";
            this.Load += new System.EventHandler(this.LayoutMenegerLoad);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Button setButton;
        private Button Addbutton;
        private Button Savebutton;
        private Button Deletebutton;
        private ListBox layoutsListBox;
    }
}