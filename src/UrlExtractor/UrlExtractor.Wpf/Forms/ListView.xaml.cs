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
using LiteDB;
using UrlExtractor.Model;
using UrlExtractor.Wpf.ViewModel;

namespace UrlExtractor.Wpf.Forms
{
    /// <summary>
    /// Interaction logic for ListView.xaml
    /// </summary>
    public partial class ListView : Window
    {
        List<ClipboardPost> allPosts = new List<ClipboardPost>();

        public ListView()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (var repo = new LiteRepository("test.db"))
            {
                allPosts = repo.Query<ClipboardPost>().ToList();
            }

            dataGrid.ItemsSource = allPosts;//attempting to bind the list to a datagrid
        }

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dataGrid.SelectedItem == null) return;
            ClipboardPost data = dataGrid.SelectedItem as ClipboardPost;

            DataGridRow row = sender as DataGridRow;
            var clipboardVm = new ClipboardVm(data);

            DetailsView view = new DetailsView();
            view.Data = clipboardVm;
            view.Show();
            // Some operations with this row
        }
    }
}
