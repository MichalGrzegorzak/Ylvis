using System.Windows.Input;

namespace UrlExtractor.Wpf.Controls
{
    public static class Commands
    {

        public static readonly RoutedUICommand DoSomething = new RoutedUICommand("Do something", "DoSomething", typeof(LogWindow));
        //public static readonly RoutedUICommand SomeOtherAction = new RoutedUICommand("Some other action", "SomeOtherAction", typeof(Window1));
        //public static readonly RoutedUICommand MoreDeeds = new RoutedUICommand("More deeds", "MoreDeeeds", typeof(Window1));

    }
}