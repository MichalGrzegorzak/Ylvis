using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using LiteDB;
using UrlExtractor.Model;
using UrlExtractor.Wpf.Controls;
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

            //StackPanel panel = new StackPanel();
            //panel.Orientation = Orientation.Vertical;
            //BindDownloads(_data.Downloads);
        }

        private void BindDownloads(List<string> downloads)
        {
            foreach (string line in downloads)
            {
                
                string[] lines = new string[2];
                if (line.StartsWith("http"))
                {
                    lines[0] = "Unknown";
                    lines[1] = line;
                }
                else
                {
                    int idx = line.IndexOf(":");
                    if (idx > 0)
                    {
                        lines[0] = line.Substring(0, idx);
                        lines[1] = line.Substring(idx + 1).Trim();
                    }
                    else
                    {
                        lines[0] = "Unknown";
                        lines[1] = line;
                    }
                }
                

                TextBlock lbl = new TextBlock();
                lbl.Text = lines[0];
                frmPanel.Children.Add(lbl);

                TextWithButton editBox = new TextWithButton();
                //TextBox editBox = new TextBox();
                editBox.Text = lines[1];
                frmPanel.Children.Add(editBox);
            }
        }

        public ClipboardVm Data
        {
            get => _data;
            set {
                _data = value;
                pnlDock.DataContext = _data;
                BindDownloads(_data.Downloads);
            }
        }


        private void Save(object sender, ExecutedRoutedEventArgs e)
        {
            using (var repo = new LiteRepository("test.db"))
            {
                var post = repo.FirstOrDefault<ClipboardPost>(x=> x.Id == Data.Id);
                Data.UpdateModel(post);
                repo.Update(post);
            }
        }
        private void Cancel(object sender, ExecutedRoutedEventArgs e)
        {
            App.ViewManager.Close(this.Owner);
        }

        private void CanSave(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void CanCancel(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
    }
}
