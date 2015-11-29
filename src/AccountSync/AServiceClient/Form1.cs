using System;
using System.ServiceModel;
using System.Threading;
using System.Windows.Forms;
using AServiceAgent;
using AServiceClient.Gmail;
using Commons;
using Commons.Extensions;
using log4net;

namespace AServiceClient
{
    public partial class Form1 : Form
    {
        private static readonly ILog log = LogManager.GetLogger("GuiLogger");
        private static GmailSender gmailSender = new GmailSender();
        
        public Form1()
        {
            InitializeComponent();

            SetupAll();
        }

        private void SetupAll()
        {
            Cor.UpdateUIAccount += new UpdateUIAccountHandler(accounts1.UpdateAccount);
            ShowLogMessage += new HandleLogMessage(Form1_ShowLogMessage);

            #region CONFIG ctrlChangePosition
            ctrlChangePosition.BtnName = "Change position";
            ctrlChangePosition.BtnAction += () =>
                {
                     string dir = ctrlChangePosition.PositionDir;
                     int size = ctrlChangePosition.PositionSize;
                     Cor.Client.ChangePosition(size, dir, 2300, DateTime.Now);
                     log.Info("New position: " + size + " " + dir);
                };
            #endregion

            #region CONFIG ctrlSendMail
            ctrlSendMail.BtnName = "Send email";
            ctrlSendMail.BtnAction += () =>
                {
                    string dir = ctrlSendMail.PositionDir;
                    int size = ctrlSendMail.PositionSize;

                    //ASYNC OPERATION
                    Thread t = new Thread(() =>
                    {
                        gmailSender.SendSignal(dir, size.ToString());
                        log.Info("Mail was send: " + size + " " + dir);
                    });
                    t.Start();
                };
            #endregion
        }

        void Form1_ShowLogMessage(string message)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(() => Form1_ShowLogMessage(message)));
                return;
            }
            richTextBox1.Text += message;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            InstanceContext context = new InstanceContext(new AlarmCallback());
            Cor.Client = new AlarmServerClient(context);
            Cor.Client.ConnectOperator();
            log.Info("Connected to service!");
            
            Account[] accounts = Cor.Client.GetAccounts();
            accounts1.Initialize(accounts);
        }

        private void btnDetectPosition_Click(object sender, EventArgs e)
        {
            Cor.Client.DetectPosition();
            log.Info("detect position on account...");
        }

        private void Monitor()
        {
            AccountCredentials c = Framework.Inst.MailSignal;
            GmailWatcher watcher = new GmailWatcher(c);
            watcher.PositionChangeHandler += new NewPosition(watcher_PositionChangeHandler);

            //Form1.ShowLogMessage.Invoke("Monnitoring running");

            while (Framework.Inst.MonitoringEnabled)
            {
                Form1.ShowLogMessage.Invoke(".");
                SysCmd cmd = watcher.GetCommand();
                cmd = SysCmd.Flat;
                Thread.Sleep(20000);
            }
        }

        void watcher_PositionChangeHandler(Position pos)
        {
            Cor.Client.DetectPosition();
                //ChangePosition(pos.Size, pos.Direct, 2300, DateTime.Now);
            log.Info("Detecting position!");
        }

        private void btnMonitoring_Click(object sender, EventArgs e)
        {
            log.Info("gmail monitoring started...");
            Thread t = new Thread(Monitor);
            t.Start();
        }

        public static event HandleLogMessage ShowLogMessage;
    }
    
    public delegate void HandleLogMessage(string message);
}
