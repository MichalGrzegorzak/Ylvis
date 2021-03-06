﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using LiteDB;
using NDde.Client;
using UrlExtractor.Model;
using UrlExtractor.Wpf.Controls;
using UrlExtractor.Wpf.ViewModel;

namespace UrlExtractor.Wpf.Forms
{
    /// <summary>
    /// Interaction logic for Start.xaml
    /// </summary>
    public partial class Start : Window
    {
        //LogWindow formLogWindow = new LogWindow();
        //ListView formListView = new ListView();
        //DetailsView formDetailsView = new DetailsView();

        public Start()
        {
            InitializeComponent();
        }

        private void EventHandler(CloseWindowMessage closeWindowMessage)
        {
            App.ViewManager.ShowPrevious();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //formLogWindow.SwitchView();
            App.ViewManager.SwitchView<LogWindow>();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //formListView.SwitchView();
            App.ViewManager.SwitchView<ListView>();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ClipboardPost post;
            using (var repo = new LiteRepository("test.db"))
            {
                post = repo.Query<ClipboardPost>().ToList().LastOrDefault();
            }

            var details = App.ViewManager.SwitchView<DetailsView>();
            details.Data = new ClipboardVm(post);
            //formDetailsView.SwitchView();

        }



        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            using (var repo = new LiteRepository("test.db"))
            {
                var all = repo.Query<ClipboardPost>().ToList();
                foreach (ClipboardPost post in all)
                {
                    repo.Delete<ClipboardPost>(post.Id);
                }
            }
        }

        private void windowStart_Loaded(object sender, RoutedEventArgs e)
        {
            App.Events.RegisterHandler<CloseWindowMessage>(EventHandler);
            //App.ViewManager.
        }
    }
}
