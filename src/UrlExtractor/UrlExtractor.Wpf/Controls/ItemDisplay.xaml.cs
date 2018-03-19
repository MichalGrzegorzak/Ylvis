using System.Windows;
using System.Windows.Controls;
using UrlExtractor.Wpf.ViewModel;

namespace UrlExtractor.Wpf.Controls
{
    /// <summary>
    /// Interaction logic for ItemDisplay.xaml
    /// </summary>
    public partial class ItemDisplay : UserControl
    {
        public ItemDisplay()
        {
            InitializeComponent();
        }

        private void CopyRawText_Click(object sender, RoutedEventArgs e)
        {
            var source = e.Source as MenuItem;
            var itemModel = source.DataContext as LootItemViewModel;
            Clipboard.SetText(itemModel.RawItemText);
            // TODO: supress outgoing text from incoming capture
        }

        private async void LookupPrice_Click(object sender, RoutedEventArgs e)
        {
            var source = e.Source as MenuItem;
            var itemModel = source.DataContext as LootItemViewModel;

            await itemModel.PopulatePriceInfoFromWeb();
        }
    }
}
