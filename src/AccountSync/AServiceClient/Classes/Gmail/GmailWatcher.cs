using System;
using System.Collections.Generic;
using System.Linq;
using AServiceAgent;
using Commons;
using log4net;

namespace AServiceClient.Gmail
{
    public delegate void NewPosition(Position newPos);

    public class GmailWatcher
    {
        public event NewPosition PositionChangeHandler;

        private static readonly ILog log = LogManager.GetLogger(typeof(GmailWatcher));
        private GmailReader reader = null;
        public Position Position;
        //public int MailsInInbox = 0;

        public GmailWatcher(AccountCredentials cred)
        {
            string login = cred.Login;
            string pass = cred.Pass;
            reader = new GmailReader(login, pass);
        }
        
        public SysCmd GetCommand()
        {
            SysCmd result = SysCmd.None;
            
            List<string> mails = reader.GetMails("transakcje");
            if (mails.Count == 0)
                return result;

            Framework.CallTrace("Some mail(s) found!");
            List<SysCmd> signals = new List<SysCmd>();
            foreach (string body in mails)
                signals.Add(ParseSignal(body));

            //check if signals are ok
            if (signals.Count > 3)
            {
                string m = "3 signals in one batch!";
                log.Warn(m);
                Framework.CallTrace(m);

            }
            else if (signals.Count == 2 && signals[0] != signals[1])
            {
                string m = "2 different signals in one batch!";
                log.Fatal(m);
                Framework.CallTrace(m);
            }
            
            result = signals.Last();
            if(result != SysCmd.None)
                PositionChangeHandler.Invoke(new Position());

            return result;
        }

        public static SysCmd ParseSignal(string mailBody)
        {
            SysCmd res = SysCmd.None;
            int start = mailBody.IndexOf("FW20") + 8;
            mailBody = mailBody.Substring(start);
            //mailBody.CutBetween()
            string direction = mailBody.Substring(0, 1);
            string volume = mailBody.Substring(2, 1);
            string price = mailBody.Substring(4, 4);

            if (direction == "K") res = SysCmd.L;
            else if (direction == "S") res = SysCmd.S;
            else throw new Exception("What the fuck, should be K or S!");

            //"Na rachunku nr 00-22-255294 zawarto w dniu 27.08.2009 o godz. 15:15 transakcje: FW20Z09 S 3*1900");
            Framework.CallTrace("Signal parsed as " + volume + direction);
            return res;
        }

       
    }
}
