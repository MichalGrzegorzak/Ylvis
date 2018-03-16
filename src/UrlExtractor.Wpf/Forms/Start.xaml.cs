using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace UrlExtractor.Wpf.Forms
{
    /// <summary>
    /// Interaction logic for Start.xaml
    /// </summary>
    public partial class Start : Window
    {
        LogWindow formLogWindow = new LogWindow();
        ListView formListView = new ListView();

        public Start()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            formLogWindow.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            formListView.Show();
        }
    }
}
