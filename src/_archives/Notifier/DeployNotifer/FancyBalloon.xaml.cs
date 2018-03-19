using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using DeployNotifer;
using Hardcodet.Wpf.TaskbarNotification;
using CommonLibrary;

namespace Samples
{
    /// <summary>
    /// Interaction logic for FancyBalloon.xaml
    /// </summary>
    public partial class FancyBalloon : UserControl
    {
        DispatcherTimer _timer;
        TimeSpan _time;

        private bool isClosing = false;

        #region BalloonText dependency property

        /// <summary>
        /// Description
        /// </summary>
        public static readonly DependencyProperty BalloonTextProperty =
            DependencyProperty.Register("BalloonText",
                typeof (string),
                typeof (FancyBalloon),
                new FrameworkPropertyMetadata(""));

        /// <summary>
        /// A property wrapper for the <see cref="BalloonTextProperty"/>
        /// dependency property:<br/>
        /// Description
        /// </summary>
        public string BalloonText
        {
            get { return (string) GetValue(BalloonTextProperty); }
            set { SetValue(BalloonTextProperty, value); }
        }

        #endregion

        #region BalloonContentText dependency property

        /// <summary>
        /// Description
        /// </summary>
        public static readonly DependencyProperty BalloonContentTextProperty =
            DependencyProperty.Register("BalloonContentText",
                typeof(string),
                typeof(FancyBalloon),
                new FrameworkPropertyMetadata(""));

        /// <summary>
        /// A property wrapper for the <see cref="BalloonContentTextProperty"/>
        /// dependency property:<br/>
        /// Description
        /// </summary>
        public string BalloonContentText
        {
            get { return (string)GetValue(BalloonContentTextProperty); }
            set { SetValue(BalloonContentTextProperty, value); }
        }

        #endregion

        public FancyBalloon(int seconds)
        {
            InitializeComponent();
            _time = TimeSpan.FromSeconds(seconds);

            _timer = new DispatcherTimer();
            _timer.Tick += dispatcherTimer_Tick;
            _timer.Interval = new TimeSpan(0, 0, 1);
            _timer.Start();

            //_timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            //{
            //    tbTime.Text = _time.ToString("c");
            //    if (_time == TimeSpan.Zero) _timer.Stop();
            //    _time = _time.Add(TimeSpan.FromSeconds(-1));
            //}, Application.Current.Dispatcher);

            //_timer.Start();            
            TaskbarIcon.AddBalloonClosingHandler(this, OnBalloonClosing);
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            // Update myCountdownLabel here
            tbTime.Text = _time.ToString();// ("c");
            if (_time == TimeSpan.Zero) _timer.Stop();
            _time = _time.Add(TimeSpan.FromSeconds(-1));
        }


        /// <summary>
        /// By subscribing to the <see cref="TaskbarIcon.BalloonClosingEvent"/>
        /// and setting the "Handled" property to true, we suppress the popup
        /// from being closed in order to display the custom fade-out animation.
        /// </summary>
        private void OnBalloonClosing(object sender, RoutedEventArgs e)
        {
            e.Handled = true; //suppresses the popup from being closed immediately
            isClosing = true;
            _timer.Stop();
        }


        /// <summary>
        /// Resolves the <see cref="TaskbarIcon"/> that displayed
        /// the balloon and requests a close action.
        /// </summary>
        private void imgClose_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //the tray icon assigned this attached property to simplify access
            TaskbarIcon taskbarIcon = TaskbarIcon.GetParentTaskbarIcon(this);
            taskbarIcon.CloseBalloon();
        }

        /// <summary>
        /// If the users hovers over the balloon, we don't close it.
        /// </summary>
        private void grid_MouseEnter(object sender, MouseEventArgs e)
        {
            //if we're already running the fade-out animation, do not interrupt anymore
            //(makes things too complicated for the sample)
            if (isClosing) return;

            //the tray icon assigned this attached property to simplify access
            TaskbarIcon taskbarIcon = TaskbarIcon.GetParentTaskbarIcon(this);
            taskbarIcon.ResetBalloonCloseTimer();
        }


        /// <summary>
        /// Closes the popup once the fade-out animation completed.
        /// The animation was triggered in XAML through the attached
        /// BalloonClosing event.
        /// </summary>
        private void OnFadeOutCompleted(object sender, EventArgs e)
        {
            Popup pp = (Popup) Parent;
            pp.IsOpen = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (App.Client.InnerChannel.State == System.ServiceModel.CommunicationState.Faulted)
            {
                App.RegisterClient();
            }

            App.Client.NotifyServer(new DeployNotifer.BroadcastServiceReference.EventDataType()
            {
                ClientName = Environment.UserName,
                EventMessage = ActionType.Cancel.ToString()
            });
        }
    }
}