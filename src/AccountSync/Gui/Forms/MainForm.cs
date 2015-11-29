using System;
using System.Threading;
using System.Windows.Forms;
using Commons.UI;
using Core;
using Core.Accounts;
using Core.Gmail;
using Core.Model;
using log4net;
using WatTest.Forms;
using Form=System.Windows.Forms.Form;

namespace WatTest
{
    public partial class MainForm : Form
    {
        private MonitorBase _monitor = null;

        public MainForm()
        {
            InitializeComponent();

            Framework.Inst.HavePasswords += Initialize;
            Framework.Inst.GetAccountSettings();
        }

        private void Initialize()
        {
            Framework.Inst.SaveAccountSettingsToFile();

            Framework.Inst.Configure4Tests();
            //Framework.Inst.Configure4Live();

            

            Form1 f = new Form1();
            f.Show();
        }

        private void Login_Click(object sender, EventArgs e)
        {
            if (Framework.Inst.MainAccount != null)
                Framework.Inst.MainAccount.Login();
            else
            {
                //throw new Exception("Please provide login & pass for accounts!");
            }
        }

        private void CurrentPos_Click(object sender, EventArgs e)
        {
            Position p = Framework.Inst.MainAccount.GetCurrentPosition();
            ShowPosition(p);
        }

        private void ShowPosition(Position p)
        {
            label1.Text = "Poz: " + p + " date:" + p.EntryDate;
        }

        private void ChangePos_Click(object sender, EventArgs e)
        {
            Framework.Inst.MainAccount.ChangePositionTo(new Position(0, -8, DateTime.Now));
            ShowPosition(Framework.Inst.MainAccount.Position);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (Framework.Inst.MainAccount != null)
                Framework.Inst.MainAccount.Ie.Close();

            Framework.Inst.SaveAccountSettingsToFile();
            this.Close();
        }

        private void TestPopup_Click_1(object sender, EventArgs e)
        {
            Position arg = new Position(111,2,DateTime.Now);

            ShowWindowIfNewPosition(arg,
                (decision) => label1.Text = "Handling user decision fired!");
        }

        private void ShowWindowIfNewPosition(Position pos, DecisionHandler action)
        {
            string[] questions = new string[] {"Czy chcesz przerwac?", "Szczegoly: " + pos.ToString()};
            OkCancelForm<QuestionUserCtrl> dlg =
                new OkCancelForm<QuestionUserCtrl>(20, questions);
            
            dlg.HandleUserDecison += action;
            dlg.Show();
        }

        private static readonly ILog _tracer = LogManager.GetLogger("GuiLogger");

        private void TestMonitoring_Click(object sender, EventArgs e)
        {
            Framework.CallTrace("Monitoring started!");

            Framework.Inst.OrderingEnabled = true; //!!! WILL PLACE ORDER !!!
            Framework.Inst.SignalsRulesChecking = true; //SKIP CHECKING SIGNALS

            _monitor = Framework.Inst.Monitor;
            _monitor.PositionChangeHandler += new NewPosition(monitor_PositionChangeHandler);
            bool res = _monitor.AreAccountsInSync();
            
            while (Framework.Inst.MonitoringEnabled)
            {
                if (_monitor.DetectChange()) //every 20 seconds
                {
                    for (int i = 0; i < 22; i++ ) //give user a time to react 10sec
                    {
                        Sleep(1);
                        if (Framework.Inst.DecisionMade)
                            break;
                    }
                    
                    if (!Framework.Inst.CancelSynchro) //jesli nie zkancelowano
                    {
                        foreach (AccountBase acc in Framework.Inst.AccountsList)
                        {
                            acc.Login();
                            Position newPosition = new Position(Framework.Inst.MainAccount.Position);
                            Position currentPosition = acc.GetCurrentPosition();

                            if (currentPosition.Direction != newPosition.Direction
                                || currentPosition.Size == 0)
                            {
                                //signal could be greter that position on account size
                                if (currentPosition.Size != 0 
                                    && newPosition.Size / (currentPosition.Size * 2) > 1)
                                {
                                    newPosition.Size = newPosition.Size / 2;
                                    Framework.CallTrace("Position lowered to: " + newPosition.Size);
                                }

                                acc.ChangePositionTo(newPosition);
                                Sleep(2);    
                            }
                            else
                            {
                                Framework.CallTrace("My got, same directions! Updating cancelled!");
                            }

                            acc.Logout();
                        }
                        Framework.Inst.CancelSynchro = false;
                        Framework.Inst.DecisionMade = false;
                    }
                }

                Sleep(1);
            }
        }

        void monitor_PositionChangeHandler(Position newPos)
        {
            ShowWindowIfNewPosition(newPos, (decision) =>
                                        {
                                            Framework.Inst.CancelSynchro = decision;
                                            Framework.Inst.DecisionMade = true;
                                        });
        }

        private void Sleep(int sec)
        {
            Thread.Sleep(1000 * sec);
            Application.DoEvents();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AccountBase main = AccountFactory.Create(ChooseAccount.Main);
            AccountBase sec = AccountFactory.Create(ChooseAccount.Account1);
            main.Login();
            main.ChangePositionTo(sec.Position);

            sec.Login();
            sec.ChangePositionTo(main.Position);
        }

        private void chbMonitoring_CheckedChanged(object sender, EventArgs e)
        {
            Framework.Inst.MonitoringEnabled = !Framework.Inst.MonitoringEnabled;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Framework.CallTrace("Monitoring started!");
            throw new Exception("dddd");
        }

        //[AsyncAttribute]
        private void btnSendSignal_Click(object sender, EventArgs e)
        {
            string size = txbSignal.Text.Substring(0, 1);
            string direct = txbSignal.Text.Substring(1, 1);

            GmailSender send = new GmailSender();
            send.SendSignal(direct, size);
        }

    }
}
