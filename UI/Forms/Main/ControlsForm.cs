namespace FFEC
{
    public partial class ControlsForm : Form, ICloseTrackable
    {
        public bool closed { get; set; } = true;
        private static readonly Dictionary<string, TabPage> cachedRequiredPages = [];
        public ControlsForm()
        {
            InitializeComponent();
            InitializeTabs();
        }

        private void InitializeTabs()
        {

            Dictionary<string, Dictionary<string, string>> controlsData = JsonStorage.Controls;

            List<TabPage> readyTabPages = [];

            //Parallel.ForEach(controlsData, (sector) => InitializeTab(readyTabPages, sector));
            foreach (KeyValuePair<string, Dictionary<string, string>> sector in controlsData)
            {
                InitializeTab(readyTabPages, sector);
            }

            readyTabPages.AddRange(GetRequiredTabs());

            readyTabPages.Sort((x, y) => x.Text.CompareTo(y.Text));

            foreach (TabPage page in readyTabPages)
            {
                tabControl.TabPages.Add(page);
            }
        }

        private List<TabPage> GetRequiredTabs()
        {
            Dictionary<string, string> variables = JsonStorage.Configurations[Config.CurrentConfig]["Variables"].ToObject<Dictionary<string, string>>().ToDictionary(pair => pair.Key, pair => pair.Key);

            Dictionary<string, Dictionary<string, string>> localControlsData = new Dictionary<string, Dictionary<string, string>>
            {
                ["Variables"] = variables,
                ["Custom functions"] = JsonStorage.Configurations[Config.CurrentConfig]["CustomFunctions"].ToObject<Dictionary<string, string>>()
            };

            List<TabPage> readyTabPages = [];

            //Parallel.ForEach(localControlsData, (sector) => InitializeTab(readyTabPages, sector));
            foreach (KeyValuePair<string, Dictionary<string, string>> sector in localControlsData)
            {
                InitializeTab(readyTabPages, sector);
            }

            return readyTabPages;

        }

        public void UpdateRequiredTabs()
        /*очень очень сомнительно. 
         * Замеченные баги: 
            * нет связки с формой каталого (не обновляются контролы), 
            * на место страницы контролов устанавливается таблица кастомных функций. 
         * Независимо от наличия параллелизма
         * Поиск элемента по ключу (названию) - IndexOfKey всегда даёт -1 индекс (типа его нет)
         */
        {
            bool hasCached = cachedRequiredPages.Count != 0;

            List<TabPage> readyPages = GetRequiredTabs();
            Dictionary<string, TabPage> readyDictPages = PageListToDict(readyPages);

            foreach (KeyValuePair<string, TabPage> page in readyDictPages)
            {
                TabPage tabPage = null;
                if (!hasCached)
                {
                    foreach (TabPage pag in tabControl.TabPages)
                    {
                        if (page.Key == pag.Text)
                        {
                            cachedRequiredPages[page.Key] = tabPage = pag;
                        }
                    }
                    ;
                }
                else
                {
                    tabPage = cachedRequiredPages[page.Key];
                }

                tabPage.Controls.Clear();
                tabPage.Controls.Add(page.Value.Controls[0]);
            }

            Dictionary<string, TabPage> PageListToDict(List<TabPage> pages)
            {
                return pages.Zip(pages.Select(x => x.Text), (k, v) => new { Key = v, Value = k }).ToDictionary(p => p.Key, p => p.Value);
            }
        }

        private void InitializeTab(List<TabPage> tabPages, KeyValuePair<string, Dictionary<string, string>> sectorData)
        {
            TabPage tab = new TabPage(JsonStorage.GetTranslate(sectorData.Key));

            IRemovableGenerator generator = sectorData.Key != "Display" ? NewButton : NewTextBox;
            FlowLayoutPanel flowPanel = new FlowLayoutPanel() { Dock = DockStyle.Fill, AutoScroll = true };
            List<GroupBox> groupBoxs = [];

            //Parallel.ForEach(sectorData.Value, (controlPair) => InitializeBox(groupBoxs, controlPair, sectorData, generator));
            foreach (KeyValuePair<string, string> controlPair in sectorData.Value)
            {
                InitializeBox(groupBoxs, controlPair, sectorData, generator);
            }

            groupBoxs.Sort((x, y) => x.Text.CompareTo(y.Text));

            foreach (GroupBox box in groupBoxs)
            {
                flowPanel.Controls.Add(box);
            }

            tab.Controls.Add(flowPanel);

            tabPages.Add(tab);
        }

        private void InitializeBox(List<GroupBox> groupBoxs, KeyValuePair<string, string> controlPair, KeyValuePair<string, Dictionary<string, string>> sectorData, IRemovableGenerator generator)
        {
            GroupBox groupBox = new System.Windows.Forms.GroupBox() { Text = JsonStorage.GetTranslate(controlPair.Key), Height = 110, Width = 200 };
            IDataStorable control = generator(sectorData.Key, controlPair, groupBox.Size);
            groupBox.Controls.Add(Wrap.DragDrop(control as Control));
            groupBoxs.Add(groupBox);
        }

        private IDataStorable NewButton(string sector, KeyValuePair<string, string> data, Size boxSize)
        {
            SButton button = new SButton(new JObject { { "Sector", sector }, { "Name", data.Key } }.ToString())
            {
                Text = data.Value,
                Size = new Size(70, 40)
            };
            button.Location = new System.Drawing.Point(
                (boxSize.Width / 2) - (button.Size.Width / 2),
                (boxSize.Height / 2) - (button.Size.Height / 2));
            return button;
        }

        private IDataStorable NewTextBox(string sector, KeyValuePair<string, string> data, System.Drawing.Size boxSize)
        {
            STextBox textBox = new STextBox(new JObject { { "Sector", sector }, { "Name", data.Key } }.ToString()) { ReadOnly = true };
            textBox.Location = new System.Drawing.Point(
                (boxSize.Width / 2) - (textBox.Size.Width / 2),
                (boxSize.Height / 2) - (textBox.Size.Height / 2));
            return textBox;
        }

        private delegate IDataStorable IRemovableGenerator(string sector, KeyValuePair<string, string> data, System.Drawing.Size boxSize);

        private void ControlsFormShown(object sender, EventArgs e)
        {
            Handler.SetSubFormPosition(Owner, this, customY: Owner.Location.Y);
        }
    }
}
