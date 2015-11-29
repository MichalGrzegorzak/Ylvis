using System;
using Commons.UI;
using Core.Accounts;

namespace Core
{
    public class NewPositionArg : EventArgs, IQuestion
    {
        public AccountBase Account { get; set; }
        public Position ToPosition { get; set; }
        public bool Execute { get; set; }
        public int Timeout = 30;

        public string Question
        {
            get
            {
                return  "Would you like to Cancel synchronization on accountId " 
                    + Account.Credentials.AccountId + " ?";
            }
            set
            {
            }
        }

        public string QuestionDetails
        {
            get
            {
                string s = "Curr. pos.: " + Account.Position.ToString()
                       + " to position: " + ToPosition.ToString() + "\n";
                s += "Signal time: " + ToPosition.EntryDate;

                return s;
            }
            set
            {
            }
        }
    }
}
