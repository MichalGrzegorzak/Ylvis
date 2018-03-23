using System;
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
            Text = "skopiuj mnie";
        }

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(TextWithButton), new PropertyMetadata(string.Empty));

        static TextWithButton()
        {
            HeightProperty.OverrideMetadata(typeof(TextWithButton), new FrameworkPropertyMetadata((double)22));
        }

        //public static readonly DependencyProperty CaptionProperty = DependencyProperty.Register("Caption", typeof(string), typeof(TextWithButton), new FrameworkPropertyMetadata(String.Empty));
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(txb.Text);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var expression = (sender as TextBox).GetBindingExpression(TextBox.TextProperty);
            expression.UpdateSource();
        }
    }
}
