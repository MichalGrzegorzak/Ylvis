using System;
using System.Windows;

namespace UrlExtractor.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);

            //var clipboardMonitor = new WindowClipboardMonitor(this);
            //clipboardMonitor.ClipboardTextChanged += ClipboardTextChanged;
        }

        private void ClipboardTextChanged(object sender, string text)
        {
            DisplayArea.Content = text;
        }

        private void openLogWindow_Click(object sender, RoutedEventArgs e)
        {
            var window = new LogWindow();
            window.Show();
        }
    }
}
