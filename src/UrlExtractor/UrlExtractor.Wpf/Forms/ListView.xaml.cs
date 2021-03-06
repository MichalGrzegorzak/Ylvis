﻿using System;
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
    public interface IRefresh
    {
        void Refresh();
    }
    /// <summary>
    /// Interaction logic for ListView.xaml
    /// </summary>
    public partial class ListView : Window, IRefresh
    {
        public ObservableCollection<ClipboardVm> Items { get; set; } = new ObservableCollection<ClipboardVm>();

        public ListView()
        {
            InitializeComponent();
            dataGrid.RowDetailsVisibilityMode = DataGridRowDetailsVisibilityMode.VisibleWhenSelected;
        }

        public void Refresh()
        {
            List<ClipboardPost> posts;
            using (var repo = new LiteRepository("test.db"))
            {
                posts = repo.Query<ClipboardPost>().ToList();
            }

            Items = new ObservableCollection<ClipboardVm>();
            foreach (ClipboardPost post in posts)
            {
                Items.Add(new ClipboardVm(post));
            }

            
            dataGrid.ItemsSource = Items;
            //dataGrid.ItemsSource = Items;//attempting to bind the list to a datagrid
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Refresh();
        }

        //private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        //{
        //    if (dataGrid.SelectedItem == null) return;
        //    ClipboardVm data = dataGrid.SelectedItem as ClipboardVm;

        //    DataGridRow row = sender as DataGridRow;
        //    //var clipboardVm = new ClipboardVm(data);

        //    DetailsView view = new DetailsView();
        //    view.Data = data;
        //    view.SwitchView();
        //}

        private void dataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // Check if the user double-clicked a grid row and not something else
            if (e.OriginalSource == null) return;
            var row = ItemsControl.ContainerFromElement((DataGrid)sender, e.OriginalSource as DependencyObject) as DataGridRow;

            // If so, go ahead and do my thing
            if (row != null)
            {
                var item = (ClipboardVm)dataGrid.Items[row.GetIndex()];
                var view = App.ViewManager.OpenNew<DetailsView>();
                view.Data = item;
            }
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
            var prev = new List<string>(new[] { "http://preview/1", "http://preview/2" });

            var cvm = new ClipboardVm()
            {
                Created = DateTime.Now.ToString(),
                DlKey = "DK1",
                Id = 111,
                Pass = "qwert",
                Url = "http://www.onet.pl",
                Previews = prev,
                Downloads = downloads
            };
            Items.Add(cvm);
        }
    }
}
