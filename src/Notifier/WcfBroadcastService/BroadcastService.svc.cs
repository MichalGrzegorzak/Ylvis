using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Timers;
using System.Windows.Threading;
using CommonLibrary;
using ThoughtWorks.CruiseControl.Remote;
using ThoughtWorks.CruiseControl.Remote.Messages;

namespace WcfBroadcastService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class BroadcastService : IBroadcastService
    {
        private const int timeInit = 2;

        private static bool build = false;

        private static int time = timeInit;
        private int interval = 30000;
        public static Timer Timer;

        private static Dictionary<string, IBroadcastCallBack> clients = new Dictionary<string, IBroadcastCallBack>();
        
        private static object locker = new object();

        public void RegisterClient(string clientName)
        {
            if (!string.IsNullOrEmpty(clientName))
            {
                try
                {
                    IBroadcastCallBack callback =
                        OperationContext.Current.GetCallbackChannel<IBroadcastCallBack>();
                    lock (locker)
                    {
                        //remove the old client
                        if (clients.Keys.Contains(clientName))
                            clients.Remove(clientName);
                        clients.Add(clientName, callback);
                    }
                }
                catch (Exception ex)
                {
                }
            }
        }

        public void NotifyServer(EventDataType eventData)
        {
            lock (locker)
            {
                if ((build && eventData.EventMessage != ActionType.Cancel.ToString()) || (!build && eventData.EventMessage == ActionType.Cancel.ToString()))
                    return;

                if (eventData.EventMessage == ActionType.Triggered.ToString())
                {
                    build = true;
                    eventData.Minutes = time * interval / 1000;
                    Timer = new Timer(interval);
                    Timer.Elapsed += (sender, e) => Timer_Elapsed(sender, e, eventData.ClientName);
                    Timer.Enabled = true;
                    Timer.Start();
                }
                else//cancel
                {
                    time = timeInit;
                    build = false;
                    Timer.Stop();
                }

                SendNotification(eventData);
            }
        }

        public List<string> GetAllClients()
        {
            return clients.Keys.ToList();
        }

        private static void SendNotification(EventDataType eventData)
        {
            var inactiveClients = new List<string>();

            foreach (var client in clients)
            {
                //if (client.Key != eventData.ClientName)
                {
                    try
                    {
                        client.Value.BroadcastToClient(eventData);
                    }
                    catch (Exception ex)
                    {
                        inactiveClients.Add(client.Key);
                    }
                }
            }

            if (inactiveClients.Count > 0)
            {
                foreach (var client in inactiveClients)
                {
                    clients.Remove(client);
                }
            }
        }

        void Timer_Elapsed(object sender, ElapsedEventArgs e, string name)
        {
            time--;

            var eventData = new EventDataType
            {
                ClientName = name,
                EventMessage = time > 0 ? ActionType.Triggered.ToString() : ActionType.Build.ToString(),
                Minutes = time * interval / 1000
            };

            if (time == 0)
            {
                time = timeInit;
                build = false;
                Timer.Stop();
                //force build
                ForceBuild("172.21.2.66", "Vacation Scheduler");
            }
            
            SendNotification(eventData);
            
        }

        private void ForceBuild(String ipAddressOrHostNameOfCCServer, String projectToExecute)
        {
            var client = new CruiseServerHttpClient(string.Format("http://{0}/ccnet/", ipAddressOrHostNameOfCCServer));
            client.Request(projectToExecute, new IntegrationRequest(BuildCondition.ForceBuild, "PL_PW_LKAFA", "lukasz.kafar"));
        }
    }
}
