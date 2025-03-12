global using System;
global using System.Linq;
global using System.Text;
global using System.Collections.Generic;
global using System.Threading.Tasks;
global using System.Windows.Forms;
global using System.Drawing;
global using Newtonsoft.Json;
global using Newtonsoft.Json.Linq;

namespace FFEC
{
    internal static class Global
    {
        public static String currentConfiguration = Config.GetCurrentConfiguration();
        public static Boolean borderView = true;
        public static DockStyle placement = DockStyle.None;
        public static List<Composite> expression = new List<Composite>();
    }
}