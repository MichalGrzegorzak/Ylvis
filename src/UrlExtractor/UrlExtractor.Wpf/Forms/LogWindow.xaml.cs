using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using UrlExtractor.Wpf.Forms;
using UrlExtractor.Wpf.ViewModel;
using WpfClipboardMonitor;

namespace UrlExtractor.Wpf
{
    /// <summary>
    /// Interaction logic for LogWindow.xaml
    /// </summary>
    public partial class LogWindow : Window
    {
        public ItemLogViewModel Items = new ItemLogViewModel();
        //public bool MonitoringEnabled { get; set; }

        public void NavigateAction()
        {
            MessageBox.Show("Custom Command Executed");
        }

        public bool CaptureClipboard { get; set; }

        WindowClipboardMonitor clipboardMonitor;

        public LogWindow()
        {
            InitializeComponent();

            itemListbox.ItemsSource = Items;
            CaptureClipboard = true;
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            clipboardMonitor = new WindowClipboardMonitor(this);
            clipboardMonitor.ClipboardTextChanged += ClipboardTextChanged;
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            clipboardMonitor.ClipboardTextChanged -= ClipboardTextChanged;
            clipboardMonitor.Dispose();
        }

        private async void ClipboardTextChanged(object sender, string text)
        {
            var clippedText = text.Trim();
            if (string.IsNullOrWhiteSpace(clippedText) || !CaptureClipboard)
                return;

            var item = new LootItemViewModel(clippedText);
            Items.Add(item);

            itemListbox.Items.MoveCurrentToLast();
            itemListbox.ScrollIntoView(itemListbox.Items.CurrentItem);

            await item.PopulatePriceInfoFromWeb();
        }

        //public bool CanExecuteNavigateDownCommand => true;
        //public void ExecutedNavigateDownCommand(object sender, RoutedEventArgs e)
        //{
        //    MessageBox.SwitchView("Custom Command Executed");
        //}
        //public void NavigateDownCommand(object sender, RoutedEventArgs e)
        //{
        //    MessageBox.SwitchView("Custom Command Executed");
        //}


        //NavigateDownCommand
        public void CommandBinding_OnExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            //NavigateAction();
            DetailsView details = new DetailsView();

            var itm = e.OriginalSource as LootItemViewModel;
            var post = Items.Last().Item;
            ClipboardVm vm = new ClipboardVm(post);
            details.Data = vm;
            details.Show();

            CaptureClipboard = false;
            Ctx.Events.RegisterHandler<DetailsViewClosedEvent>(handler => { CaptureClipboard = true; });
        }
    }

    public class DetailsViewClosedEvent
    {

    }
}
