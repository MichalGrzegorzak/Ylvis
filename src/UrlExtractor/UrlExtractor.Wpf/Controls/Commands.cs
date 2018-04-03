using System.Windows.Input;

namespace UrlExtractor.Wpf.Controls
{
    public static class Commands
    {

        //public static readonly RoutedUICommand DoSomething = new RoutedUICommand();
        public static readonly RoutedUICommand Save = new RoutedUICommand();
        public static readonly RoutedUICommand Cancel = new RoutedUICommand();
        public static readonly RoutedUICommand SomeOtherAction = new RoutedUICommand("Some other action", "SomeOtherAction", typeof(LogWindow));
        //public static readonly RoutedUICommand MoreDeeds = new RoutedUICommand("More deeds", "MoreDeeeds", typeof(Window1));

    }
}