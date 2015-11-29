using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media.Imaging;
using CommonLibrary;
using Hardcodet.Wpf.TaskbarNotification;
using Samples;

namespace DeployNotifer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static TaskbarIcon notifyIcon;

        public static BroadcastServiceReference.BroadcastServiceClient Client;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            //create the notifyicon (it's a resource declared in NotifyIconResources.xaml
            notifyIcon = (TaskbarIcon)FindResource("NotifyIcon");
            RegisterClient();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            if ((Client != null))
            {
                Client.Abort();
                Client = null;
            }

            notifyIcon.Dispose(); //the icon would clean up automatically, but this is cleaner
            base.OnExit(e);
        }

        public static void HandleBroadcast(object sender, EventArgs e)
        {
            var eventData = (BroadcastServiceReference.EventDataType)sender;
            string text = String.Empty;

            FancyBalloon balloon = new FancyBalloon(eventData.Minutes);
            balloon.BalloonText = eventData.EventMessage;
            balloon.Height = 180;

            ActionType action = EnumUtil.ParseEnum<ActionType>(eventData.EventMessage);

            switch (action)
            {
                case ActionType.Triggered:
                    text = string.Format("Build {0} by {1}", eventData.EventMessage.ToLower(), eventData.ClientName);
                    break;
                case ActionType.Cancel:
                    balloon.Height = 120;
                    text = string.Format("Build cancel by {0}", eventData.ClientName);
                    break;
                case ActionType.Build:
                    balloon.Height = 120;
                    text = string.Format("Building project");
                    break;
            }
            balloon.BalloonContentText = text;

            notifyIcon.ShowCustomBalloon(balloon, new PopupAnimation(), 10000);
        }

        public static void RegisterClient()
        {
            if ((Client != null))
            {
                Client.Abort();
                Client = null;
            }

            BroadcastCallback cb = new BroadcastCallback();
            cb.SetHandler(HandleBroadcast);

            System.ServiceModel.InstanceContext context =
                new System.ServiceModel.InstanceContext(cb);
            Client = new BroadcastServiceReference.BroadcastServiceClient(context);

            Client.RegisterClient(Environment.UserName);
        }
    }
}
