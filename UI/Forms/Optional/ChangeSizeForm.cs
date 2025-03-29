namespace FFEC
{
    public partial class ChangeSizeForm : Form
    {
        private Control control { get; }
        public ChangeSizeForm(string height, string width, Control control)
        {
            InitializeComponent();
            heightTextBox.Text = height;
            widthTextBox.Text = width;
            this.control = control;
        }

        private void ChangeSizeFormClosing(object sender, FormClosingEventArgs e)
        {
            SetSize();
        }

        private void ChangeSizeFormShown(object sender, EventArgs e)
        {
            Handler.SetSubFormPosition(Owner, this);
        }

        private void heightTextBoxMouseDown(object sender, MouseEventArgs e)
        {
            ushort step = 1;
            if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
            {
                step = 5;
            }

            if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
            {
                if (e.Delta > 0)
                {
                    SizeCrement(Keys.Left, step);
                }
                else
                {
                    SizeCrement(Keys.Right, step);
                }
            }
            else
            {
                if (e.Delta > 0)
                {
                    SizeCrement(Keys.Up, step);
                }
                else
                {
                    SizeCrement(Keys.Down, step);
                }
            }
        }

        private void PerformKeyShortcut(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape: this.Close(); break;
                case Keys.Enter or Keys.Tab: SetSize(); break;
                case Keys.Up or Keys.Down or Keys.Left or Keys.Right: SizeCrement(e.KeyCode); break;
            }
        }

        private void SetSize()
        {
            if (IsSizeTextCorrect(out ushort newWidth, out ushort newHeight))
            {
                control.Size = new System.Drawing.Size(newWidth, newHeight);
                widthTextBox.Text = control.Width.ToString();
                heightTextBox.Text = control.Height.ToString();
            }
            ;
        }

        private void SizeCrement(Keys key, ushort step = 1)
        {
            if (IsSizeTextCorrect(out ushort newWidth, out ushort newHeight))
            {
                switch (key)
                {
                    case Keys.Up: { newHeight += step; break; }
                    case Keys.Down:
                        {
                            newHeight = (ushort)(newHeight - step <= 0 ? 1 : newHeight - step);
                            break;
                        }
                    case Keys.Left:
                        {
                            newWidth = (ushort)(newWidth - step <= 0 ? 1 : newWidth - step);
                            break;
                        }
                    case Keys.Right: { newWidth += step; break; }
                }
                control.Size = new System.Drawing.Size(newWidth, newHeight);
                widthTextBox.Text = control.Width.ToString();
                heightTextBox.Text = control.Height.ToString();
            }
            ;
        }
        private bool IsSizeTextCorrect(out ushort width, out ushort height)
        {
            return ushort.TryParse(widthTextBox.Text, out width) & ushort.TryParse(heightTextBox.Text, out height);
        }
    }
}
