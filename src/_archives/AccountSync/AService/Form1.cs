using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Net.Security;
using System.ServiceModel.Description;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;
using AServiceContract;
using Commons.Appenders;
using log4net;

namespace AService
{
    public delegate void DoThreadedGoodManualType(string s);

    public partial class Form1 : Form
    {
        private static readonly ILog log = LogManager.GetLogger("GuiLogger");

        private ServiceHost host;
        private string urlMeta, urlService = "";

        public Form1(params String[] args)
        {
            InitializeComponent();

            try
            {
                AlarmServer server = new AlarmServer(args);
                server.forma = this;

                host = new ServiceHost(server);
                //host = new ServiceHost(typeof(AlarmServer));
                //ConfigureService();
                host.Open();

                UiLogMessage("Started!");

                GuiTraceAppender.LogMessage += logControl1.ShowLogMessage;
            }
            catch (TimeoutException timeProblem)
            {
               Console.WriteLine(timeProblem.Message);
               Console.ReadLine();
            }
            catch (CommunicationException commProblem)
            {
               Console.WriteLine(commProblem.Message);
               Console.ReadLine();
            }

        }

        public void UiLogMessage(string text)
        {
            //if (InvokeRequired)
            //{
            //    BeginInvoke(new MethodInvoker(() => UiLogMessage(text))); return;
            //}
            
            //richTextBox1.Text += text;
            log.Info(text);
        }

        private void ConfigureService()
        {
            // Returns a list of ipaddress configuration
            IPHostEntry ips = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ips.AddressList[0]; // Select the first entry. I hope it's this maschines IP
            
            // Create the url that is needed to specify where the service should be started
            urlService = "net.tcp://" + ipAddress + ":8000/AlarmServer";
            host = new ServiceHost(typeof(AlarmServer));

            NetTcpBinding tcpBinding = new NetTcpBinding();
            tcpBinding.TransactionFlow = false;
            tcpBinding.Security.Transport.ProtectionLevel = ProtectionLevel.EncryptAndSign;
            tcpBinding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Windows;
            tcpBinding.Security.Mode = SecurityMode.None;
            // <- Very crucial

            // Add a endpoint
            host.AddServiceEndpoint(typeof(IAlarmServer), tcpBinding, urlService);
            
            // A channel to describe the service. Used with the proxy scvutil.exe tool
            ServiceMetadataBehavior metadataBehavior;
            metadataBehavior = host.Description.Behaviors.Find<ServiceMetadataBehavior>();
            if (metadataBehavior == null)
            {
                // This is how I create the proxy object that is generated via the svcutil.exe tool
                metadataBehavior = new ServiceMetadataBehavior();
                metadataBehavior.HttpGetUrl = new Uri("http://" + ipAddress + ":8001/AlarmServer");
                metadataBehavior.HttpGetEnabled = true;
                metadataBehavior.ToString();
                host.Description.Behaviors.Add(metadataBehavior);
                urlMeta = metadataBehavior.HttpGetUrl.ToString();
            }

            //forProxy
            //host.AddServiceEndpoint(typeof(AlarmServer), )
            host.Open();
        }

        private void btnChangeConfig_Click(object sender, EventArgs e)
        {
            if(ServSettings.Is4Live)
                ServSettings.Configure4Test();
            else
                ServSettings.Configure4Live();

        }
    }
}