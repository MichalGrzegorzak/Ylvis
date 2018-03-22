using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using UrlExtractor.Wpf.ViewModel;

namespace UrlExtractor.Wpf.Controls
{
    /// <summary>
    /// Interaction logic for ItemDisplay.xaml
    /// </summary>
    public partial class TextWithButton : UserControl
    {
        public TextWithButton()
        {
            InitializeComponent();
            SearchText  = "skopiuj mnie";
        }

        public string SearchText { get; set; }


        private void SearchBoxKeyDown(object sender, KeyEventArgs e)
        {
            //throw new System.NotImplementedException();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(txb.Text);
        }
    }
}
