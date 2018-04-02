using System;
using System.Windows;
using UrlExtractor.Wpf.Controls;
using UrlExtractor.Wpf.Forms;

namespace UrlExtractor.Wpf
{
    public class ViewManager
    {
        DetailsView details = new DetailsView();
        ListView list = new ListView();
        LogWindow log = new LogWindow();
        Start start = new Start();

        private Window current = null;
        private Window previous = null;
        private Window next = null;
        //private bool _isInitialized = false;

        public ViewManager()
        {
            details.Closing += Closing;
            list.Closing += Closing;
            log.Closing += Closing;
            //start.Closing += Closing;
            //current = start;
            //previous = start;
        }


        private void Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            var wind = (sender as Window);
            //wind.Visibility = Visibility.Hidden;
            
            //ShowPrevious();
            App.Events.PostMessage(new CloseWindowMessage() {CurrentWindow = wind});
        }

        public T Show<T>() where T : Window
        {
            if (typeof(T) == typeof(Start))
                return SwitchView<T>(start, list);
            if (typeof(T) == typeof(DetailsView))
                return SwitchView<T>(details, list);
            if (typeof(T) == typeof(ListView))
                return SwitchView<T>(list, details);
            if (typeof(T) == typeof(LogWindow))
                return SwitchView<T>(log, start);
            return null;
        }

        public void ShowNext()
        {
            if(next != null)
                SwitchView<Window>(next, null);
        }
        public void ShowPrevious()
        {
            if (previous != null)
                SwitchView<Window>(previous, current);
        }

        private T SwitchView<T>(Window now, Window next) where T : Window
        {
            previous = current;
            current = now;
            this.next = next;
            //
            if(previous != null)
                previous.Visibility = Visibility.Hidden;
            current.Show();
            return (T)now;
        }
    }
}