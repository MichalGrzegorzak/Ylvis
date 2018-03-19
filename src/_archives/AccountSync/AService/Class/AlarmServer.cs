using System;
using System.Collections;
using System.Linq;
using System.Threading;
using System.Timers;
using System.Collections.Generic;
using System.ServiceModel;
using System.Windows.Forms;
using AServiceContract;

namespace AService
{
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.Single, 
        ConcurrencyMode = ConcurrencyMode.Single)]
    public class AlarmServer : IAlarmServer
    {
        private static IAlarmCallback _client = null;
        private static AutoResetEvent _decisionMadeEvent = new AutoResetEvent(false);
        private static List<Position> signals = new List<Position>();
        private static AccountManager manager = new AccountManager();

        public Form1 forma = null;
        public bool LastSignalCancelled = false;
        public static AccountSettings aSettings = null;

        public AlarmServer(params String[] args)
        {
            aSettings = new AccountSettings();
            aSettings.ReadAccountSettingsFromFile();

            if (args != null && args.Length > 0
                && args[0] == "-proxy")
            {
                ServSettings.Configure4Test();
            }
            else
            {
               ServSettings.Configure4Test(); // !!!!!!!!!!!!
               //ServSettings.Configure4Live();
            }

            manager.AccountUpdatedHandler += new AccountUpdated(manager_AccountUpdatedHandler);
            manager.InitializeAccountsDetails(aSettings.Credentials);

            //4. if S then fire callback & start timer
            //5. if elapsed and not cancelled then GO
            //6. updating the accounts, (fire callback to update the account?)

            //Thread t = new Thread(Monitor);
            //t.SetApartmentState(ApartmentState.STA);
            //t.Start();
        }

        void manager_AccountUpdatedHandler(Account account)
        {
            _client.UpdateUIAccount(account);
        }

        public List<Account> GetAccounts()
        {
            List<Account> acc = new List<Account>();
            acc.Add(manager.Main);
            acc.AddRange(manager.AccountsToSync);
            return acc;
        }

        public void DetectPosition()
        {
            Position current = manager.GetMainAccountPosition();
            ChangePosition(current);
        }

        public void ChangePosition(int size, string direct, int price, DateTime date)
        {
            ChangePosition(new Position(size, direct, price, date));
        }

        private void ChangePosition(Position current)
        {
            manager.Main.Pos = current;
            signals.Add(current);

            if (_client != null) //if client connected, updated his GUI, and give him chance to break alert
            {
                _client.UpdateUIAccount(manager.Main);
                _client.AlertNewSignal(current);
            }

            Thread t = new Thread(() =>
            {
                _decisionMadeEvent.WaitOne(TimeSpan.FromSeconds(20));
                if (!LastSignalCancelled)
                {
                    UpdateAllAccounts(current);
                    LastSignalCancelled = false;
                }
            });
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }

        private void UpdateAllAccounts(Position toPosition)
        {
            manager.UpdateAllAccounts(toPosition);

            //przejdz do watku glownego!!
            UpdateUi("Zakonczono update kont");
        }

        private void UpdateUi(string log)
        {
            forma.UiLogMessage(log);
        }

        #region IAlarmServer Members

        public void ConnectOperator()
        {
            _client = OperationContext.Current.GetCallbackChannel<IAlarmCallback>();
        }

        public void DisconnectOperator()
        {
            _client = null;
        }

        public bool CancelLastSignal(bool decision)
        {
            LastSignalCancelled = decision;
            _decisionMadeEvent.Set();
            return true;
        }

        #endregion
    }
}
