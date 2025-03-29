namespace FFEC
{
    internal static class Wrap
    {
        public static Control DragDrop(Control control, bool modifierConside = false)
        {
            control.AllowDrop = true;
            control.MouseDown += modifierConside ? Handler.ControlDoDragDropModifierConside : Handler.ControlDoDragDrop;
            return control;
        }

        public static SButton ActionPerform(SButton button)
        {
            button.Click += Handler.GetActionByButtonData(button.JData);
            return button;
        }

        public static Control ChangeProperty(Control control)
        {
            control.MouseUp += Handler.ControlOpenPropertyMenu;
            return control;
        }

        public static Panel DisplayPanel(Panel panel)
        {
            panel.DragDrop += (object sender, DragEventArgs e) => { if (Handler.DisplayValidate(e)) { Handler.PanelDoDrop(sender, e); } };
            panel.DragEnter += (object sender, DragEventArgs e) => { if (Handler.DisplayValidate(e)) { Handler.PanelDoDropEnter(sender, e); } };
            panel.MouseClick += Handler.PanelOpenPropertyMenu;
            return panel;
        }

        public static Panel ControlPanel(Panel panel)
        {
            panel.DragDrop += (object sender, DragEventArgs e) => { if (Handler.ControlValidate(e)) { Handler.PanelDoDrop(sender, e); } };
            panel.DragEnter += (object sender, DragEventArgs e) => { if (Handler.ControlValidate(e)) { Handler.PanelDoDropEnter(sender, e); } };
            panel.MouseClick += Handler.PanelOpenPropertyMenu;
            return panel;
        }
    }
}
