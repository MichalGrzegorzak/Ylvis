using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using LiteDB;
using NDde.Client;
using UrlExtractor.Model;
using UrlExtractor.Wpf.ViewModel;

namespace UrlExtractor.Wpf.Forms
{
    /// <summary>
    /// Interaction logic for Start.xaml
    /// </summary>
    public partial class Start : Window
    {
        LogWindow formLogWindow = new LogWindow();
        ListView formListView = new ListView();
        DetailsView formDetailsView = new DetailsView();

        public Start()
        {
            InitializeComponent();

           //this.Reques
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            formLogWindow.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            formListView.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ClipboardPost post;
            using (var repo = new LiteRepository("test.db"))
            {
                post = repo.Query<ClipboardPost>().ToList().LastOrDefault();
            }

            formDetailsView.Data = new ClipboardVm(post);
            formDetailsView.Show();

        }



        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            string browser = @"C:\Users\user\Desktop\TBrowser\Browser\firefox.exe";
            //string url = GetBrowserURL();
            //MessageBox.Show(url);
        }
    }
}
