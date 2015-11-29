using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using AServiceAgent;
using Commons.UI;

namespace AServiceClient
{
    public class AlarmCallback : AlarmServerCallback
    {
        #region AlarmServerCallback Members

        public void AlertNewSignal(Position pos)
        {
            //Position arg = new Position(111, 2, DateTime.Now);

            string[] questions = new string[] {"Czy chcesz przerwac synchrnozacje?", 
                "Na pozycje:" + pos.Size + " " + pos.Direct + " ?"};

            OkCancelForm<QuestionUserCtrl> dlg =
                new OkCancelForm<QuestionUserCtrl>(15, questions);

            dlg.HandleUserDecison += new DecisionHandler(dlg_HandleUserDecison); ;
            dlg.Show();
        }

        void dlg_HandleUserDecison(bool decision)
        {
            Cor.Client.CancelLastSignal(decision);
        }

        public void UpdateUIAccount(Account acc)
        {
            Cor.CallUpdateUIAccount(acc.Id, acc.Pos);
        }

        #endregion

        public void SignalAlarm(string reminderMessage)
        {
            throw new NotImplementedException();
        }

        public void ServerLogMessages(LogMessage log)
        {
            throw new NotImplementedException();
        }
    }
}
