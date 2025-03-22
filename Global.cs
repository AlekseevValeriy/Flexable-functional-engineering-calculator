global using System;
global using System.Collections.Generic;
global using System.Drawing;
global using System.Linq;
global using System.Text;
global using System.Windows.Forms;
global using Newtonsoft.Json.Linq;

namespace FFEC
{
    internal static class Global
    {
        public static readonly Random random = new Random();
        public static Boolean borderView = true;
        public static DockStyle placement = DockStyle.None;
        public static List<Composite> expression = new List<Composite>();
        public static Font defaultFont = Form.DefaultFont;
        public static Color defaultBackColor = Form.DefaultBackColor;
        public static Color defaultForeColor = Form.DefaultForeColor;
        public static Color defaultFlatBorderColor = Color.Empty;
        public static Color defaultFlatOverColor = Color.Empty;
        public static Color defaultFlatDownColor = Color.Empty;
    }
}