using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace UrlExtract.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            BackgroundStart();
            cmbSettings.SelectedIndex = 0;
        }

        public string FileContent { get; set; }

        async void BackgroundStart()
        {
            //txbInput.Text = File.ReadAllText("test.txt");
            txbInput.Text = "LOADING....";
            await Task.Run(() =>
            {
                FileContent = File.ReadAllText("test.txt").Decode();
            });

            txbInput.Text = "LOADED";
            //btnParse_Click(this, null);
            txbResults.Text = ParseLinks(FileContent);
            //txbResults.Text.Decode()
        }

        public string OutputBox
        {
            get => txbResults.Text;
            set => txbResults.Text = value;
        }

        private void btnParse_Click(object sender, EventArgs e)
        {
            txbResults.Text = ParseLinks(txbInput.Text);
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private string ParseLinks(string input)
        {
            //var doc = new HtmlWeb().LoadHtml(url);
            var doc = new HtmlDocument();
            doc.LoadHtml(FileContent);

            var linkTags = doc.DocumentNode.Descendants("link");

            var linkedPages = doc.DocumentNode.Descendants("a")
                .Select(a => a.GetAttributeValue("href", null))
                .Where(u => !String.IsNullOrEmpty(u));

            LinkFilter filter = new LinkFilter();
            var grouper = filter.FilterLinks(linkedPages);
            grouper.AssignToGroups();

            StringBuilder sb = new StringBuilder();
            var groupKeys = grouper.Groups.Keys;

            int groupsCount = groupKeys.Count;
            sb.AppendLine($"ALL: {groupsCount}");
            foreach (string key in groupKeys)
            {
                sb.AppendLine($"GROUP: {key}");
            }
            sb.AppendLine($"");
            foreach (string key in groupKeys)
            {
                foreach (string link in grouper.Groups[key])
                {
                    sb.AppendLine($"\t\t {key}{link}");
                }
                sb.AppendLine($"");
            }
            return sb.ToString();
            //return grouper.ToString();
            //OutputBox = String.Join("\n", linkedPages);
        }

        

        
    }
}
