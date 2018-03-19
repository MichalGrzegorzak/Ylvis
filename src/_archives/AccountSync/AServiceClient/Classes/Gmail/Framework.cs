using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Commons;
using Commons.Extensions;
using Commons.UI;

namespace AServiceClient.Gmail
{
    public delegate void MessagelogHandler(string message);

    public sealed class Framework
    {
        public static event MessagelogHandler Trace;
        public static void CallTrace(string message)
        {
            if(Trace != null)
                Trace.Invoke(message);
        }

        #region Singleton declarations
        static readonly Framework _instance = new Framework();
        public static Framework Inst
        {
            get { return _instance; }
        }
        Framework()
        {
            ReadAccountSettingsFromFile();
            //browser = new IE();
        }

        static Framework()
        {
        } 
        #endregion

        private void InitializeAllObjects()
        {
            //Monitor = new MonitorGmail();
        }

        //private MonitorBase Monitor;
        public bool MonitoringEnabled = true;

        internal List<AccountCredentials> CredentialsList = new List<AccountCredentials>();
        //public Credentials MainCredentials;
        //public Credentials TestCredentials;
        public AccountCredentials MailFrom;
        public AccountCredentials MailSignal;

        #region Reading configuration
        const string settingFileName = "mails.psw";
        public void SaveAccountSettingsToFile()
        {
            CallTrace("Saving settings to config!");

            CredentialsList = new List<AccountCredentials>(
                new AccountCredentials[] {CredentialsList[0], CredentialsList[1] });
                //new Credentials[] {MailFrom, MailSignal, CredentialsList[3], CredentialsList[4] });

            XDocument xml = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement("AccountsList",
                             from account in CredentialsList
                             orderby account.AccountId
                             select new XElement("Account",
                                                 new XAttribute("Id", account.AccountId),
                                                 new XAttribute("Login", account.Login),
                                                 new XAttribute("Pass", account.Pass)
                                 )
                    ));

            xml.Save(settingFileName);
        }

        public bool ReadAccountSettingsFromFile()
        {
            bool result = true;
            try
            {
                XDocument xml = XDocument.Load(settingFileName);
                IEnumerable<AccountCredentials> lista =
                    from account in xml.Descendants("Account")
                    orderby account.Attribute("Id").Value.Parse<int>()
                    select new AccountCredentials()
                    {
                        AccountId = account.Attribute("Id").Value.Parse<int>(),
                        Login = account.Attribute("Login").Value,
                        Pass = account.Attribute("Pass").Value
                    };

                CredentialsList = new List<AccountCredentials>(lista);
                MailFrom = CredentialsList[0];
                MailSignal = CredentialsList[1];
            }
            catch (Exception)
            {
                result = false;
                //throw;
            }
            return result;
        } 
        #endregion

        public void GetAccountSettings()
        {
            if (!Framework.Inst.ReadAccountSettingsFromFile())
            {
                var f0 = new ShowFormGetValue<LoginAndPassForm>(
                    (cred) => { CredentialsList.Add(cred); InvokeHavePass(); });
                var f1 = new ShowFormGetValue<LoginAndPassForm>(
                    (cred) => { CredentialsList.Add(cred); InvokeHavePass(); });
            }
            else
            {
                HavePasswords.Invoke();
            }
        }

        private void InvokeHavePass()
        {
            if(CredentialsList.Count >= 2)
                HavePasswords.Invoke();
        }

        public event Action HavePasswords;
    }
}