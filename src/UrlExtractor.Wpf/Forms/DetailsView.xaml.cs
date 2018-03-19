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
using UrlExtractor.Model;
using UrlExtractor.Wpf.ViewModel;

namespace UrlExtractor.Wpf.Forms
{
    /// <summary>
    /// Interaction logic for DetailsView.xaml
    /// </summary>
    public partial class DetailsView : Window
    {
        private ClipboardVm _data = new ClipboardVm();

        public DetailsView()
        {
            InitializeComponent();
            pnlDock.DataContext = _data;
        }

        public ClipboardVm Data
        {
            get => _data;
            set {
                _data = value;
                pnlDock.DataContext = _data;
            }
        }
    }
}
