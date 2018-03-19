using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace UrlExtractor.Wpf.Controls.FormPanel
{
    public class OkCancelFrame : ContentControl
    {
        public static readonly DependencyProperty OkCommandProperty =
            DependencyProperty.Register("OkCommand", typeof(ICommand), typeof(OkCancelFrame));

        public ICommand OkCommand
        {
            get { return (ICommand)GetValue(OkCommandProperty); }
            set { SetValue(OkCommandProperty, value); }
        }

        public static readonly DependencyProperty OkCommandParameterProperty =
            DependencyProperty.Register("OkCommandParameter", typeof(object), typeof(OkCancelFrame));

        public object OkCommandParameter
        {
            get { return GetValue(OkCommandParameterProperty); }
            set { SetValue(OkCommandParameterProperty, value); }
        }

        public static readonly DependencyProperty CancelCommandProperty =
            DependencyProperty.Register("CancelCommand", typeof(ICommand), typeof(OkCancelFrame));

        public ICommand CancelCommand
        {
            get { return (ICommand)GetValue(CancelCommandProperty); }
            set { SetValue(CancelCommandProperty, value); }
        }

    }
}
