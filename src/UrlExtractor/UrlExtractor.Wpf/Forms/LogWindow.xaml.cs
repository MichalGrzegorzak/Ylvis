using System;
using System.ComponentModel;
using System.Windows;
using UrlExtractor.Wpf.ViewModel;
using WpfClipboardMonitor;

namespace UrlExtractor.Wpf
{
    /// <summary>
    /// Interaction logic for LogWindow.xaml
    /// </summary>
    public partial class LogWindow : Window
    {
        ItemLogViewModel items = new ItemLogViewModel();

        WindowClipboardMonitor clipboardMonitor;

        public LogWindow()
        {
            InitializeComponent();

            itemListbox.ItemsSource = items;
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);

            clipboardMonitor = new WindowClipboardMonitor(this);
            clipboardMonitor.ClipboardTextChanged += ClipboardTextChanged;
        }

        private async void ClipboardTextChanged(object sender, string text)
        {
            var clippedText = text.Trim();
            if (string.IsNullOrWhiteSpace(clippedText))
                return;

            var item = new LootItemViewModel(clippedText);
            items.Add(item);

            itemListbox.Items.MoveCurrentToLast();
            itemListbox.ScrollIntoView(itemListbox.Items.CurrentItem);

            await item.PopulatePriceInfoFromWeb();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            clipboardMonitor.ClipboardTextChanged -= ClipboardTextChanged;
            clipboardMonitor.Dispose();
        }
    }
}
