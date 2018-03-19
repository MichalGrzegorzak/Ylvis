using System;
using System.Collections.Generic;
using log4net;
using Pop3;
using Pop3.Infotypes;

namespace AServiceClient.Gmail
{
    public class GmailReader
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(GmailReader));
        private Pop3MimeClient _client = null;

        public GmailReader(string addres, string pass)
        {
            Initialize(addres, pass);
        }

        public void Initialize(string addres, string pass)
        {
            _client = new Pop3MimeClient("pop.gmail.com", 995, true, addres, pass);
            _client.Trace += new TraceHandler(client_Trace);
            _client.Warning += new WarningHandler(client_Warning);
            _client.ReadTimeout = 60000; //give pop server 60 seconds to answer
        }
        
        public List<string> GetMails(string filter)
        {
            //Framework.CallTrace("GetMails...");
            _log.Debug("Getting mails...");

            List<string> mails = new List<string>();
            try
            {
                _client.Connect();
            }
            catch(Exception ex)
            {
                _log.Fatal("Can`t connect to Gmail! ", ex);
                return mails;
            }

            int numberOfMailsInMailbox, mailboxSize, downloadNumberOfEmails, maxDownloadEmails = 99;
            _client.GetMailboxStats(out numberOfMailsInMailbox, out mailboxSize);

            //get at most the xx first emails
            downloadNumberOfEmails = (numberOfMailsInMailbox < maxDownloadEmails)
                                         ? numberOfMailsInMailbox : maxDownloadEmails;

            if (numberOfMailsInMailbox > 0)
                Framework.CallTrace("Mails found: " + numberOfMailsInMailbox);
            
            for (int i = 1; i <= downloadNumberOfEmails; i++)
            {
                string s = GetEmailBody(i);
                if (s.Length > 0)
                {
                    if (s.Contains(filter))
                        mails.Add(s);
                    else
                    {
                        Framework.CallTrace("ERR Mail does not match");
                        _log.Error("Mail does not match => " + s);
                    }
                }
            }

            _client.Disconnect();
            return mails;
        }

        private string GetEmailBody(int idx)
        {
            string res = "";
            RxMailMessage mm;

            _client.GetEmail(idx, out mm);
            if (mm == null)
            {
                string s = "Email " + idx + " cannot be displayed.";
                _log.Error(s);
                Framework.CallTrace(s);
            }
            else
            {
                //Console.WriteLine(mm.MailStructure());
                res = mm.Body;
            }
            return res;
        }

        #region Handling tracing & logging
        static void client_Warning(string warningText, string response)
        {
            string m = warningText + " " + response;
            _log.Warn(m);
            Framework.CallTrace(m);    

        }

        static void client_Trace(string traceText)
        {
            _log.Debug(traceText);
        }
        #endregion
    }
}
