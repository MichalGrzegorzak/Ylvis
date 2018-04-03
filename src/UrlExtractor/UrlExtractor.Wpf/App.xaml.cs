using System.Windows;
using UrlExtractor.Wpf.Controls;
using UrlExtractor.Wpf.Forms;

namespace UrlExtractor.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ViewManager ViewManager = new ViewManager();
        public static EventAggregator Events = new EventAggregator();

        public App()
        {
            ViewManager.SwitchView<Start>();
        }
    }
}
