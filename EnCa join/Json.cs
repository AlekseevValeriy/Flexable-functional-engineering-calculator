using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace FFEC
{
    internal static class Json
    {
        public static Dictionary<String, Dictionary<String, String>> ReadControls()
        {
            //MessageBox.Show($"{System.IO.Path.GetDirectoryName(Application.ExecutablePath)}"); // current folder
            string fileName = "..\\..\\JsonData\\Controls.json";
            string jsonString = File.ReadAllText(fileName); // panic
            Dictionary<String, Dictionary<String, String>> tabsData = JsonConvert.DeserializeObject<Dictionary<String, Dictionary<String, String>>>(jsonString);
            return tabsData;
        }

        public static JObject ReadConfig()
        {
            //MessageBox.Show($"{System.IO.Path.GetDirectoryName(Application.ExecutablePath)}"); // current folder
            string fileName = "..\\..\\JsonData\\Config.json";
            string jsonString = File.ReadAllText(fileName); // panic
            JObject o = JObject.Parse(jsonString);
            return o;
        }
    }
}
