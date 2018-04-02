using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public ObservableCollection<ClipboardVm> Items { get; set; } = new ObservableCollection<ClipboardVm>();

        public ListView()
        {
            InitializeComponent();

            dataGrid.RowDetailsVisibilityMode = DataGridRowDetailsVisibilityMode.VisibleWhenSelected;
            dataGrid.ItemsSource = Items;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<ClipboardPost> posts;
            using (var repo = new LiteRepository("test.db"))
            {
                posts = repo.Query<ClipboardPost>().ToList();
            }

            foreach (ClipboardPost post in posts)
            {
                Items.Add(new ClipboardVm(post));
            }

            //dataGrid.ItemsSource = Items;//attempting to bind the list to a datagrid
        }

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dataGrid.SelectedItem == null) return;
            ClipboardVm data = dataGrid.SelectedItem as ClipboardVm;

            DataGridRow row = sender as DataGridRow;
            //var clipboardVm = new ClipboardVm(data);

            DetailsView view = new DetailsView();
            view.Data = data;
            view.Show();
            // Some operations with this row
        }
    }

    public class ListViewMock
    {
        public ListViewMock()
        {
            AddMockedPosts();
        }
        public List<ClipboardVm> Items { get; set; } = new List<ClipboardVm>();
        protected void AddMockedPosts()
        {
            var downloads = new List<string>(new[] { "111", "222", "333" });
            var cvm = new ClipboardVm()
            {
                Created = DateTime.Now.ToString(),
                DlKey = "DK1",
                Id = 111,
                Pass = "qwert",
                Url = "http://www.onet.pl",
                Previews = "http://preview/1",
                Downloads = downloads
            };
            Items.Add(cvm);
        }
    }
}
