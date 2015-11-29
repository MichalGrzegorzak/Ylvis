using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Commons;
using Commons.Extensions;
using Commons.UI;
using Core.Accounts;
using Core.Aspects;
using Core.Model;
using log4net;
using WatiN.Core;

namespace Core
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

        #region Configuration
        public void Configure4Live()
        {
            InitializeAllObjects();

            MainAccount.Login();
            Position main = MainAccount.GetCurrentPosition();

            TestAccount.Login();
            Position test = TestAccount.GetCurrentPosition();

            SetAccountsPositions(main, test);
        }

        public void Configure4Tests()
        {
            OrderingEnabled = false;

            InitializeAllObjects();

            Position main = new Position(1111, 2, DateTime.Now.Subtract(new TimeSpan(2,0,0)));
            Position test = new Position(1100, -2, DateTime.Now);
            SetAccountsPositions(main, test);
        }

        //public void Configure4UnitTests()
        //{
        //    InitializeAllObjects();

        //    Position main = new Position(1111, 2, DateTime.Now.Subtract(new TimeSpan(2, 0, 0)));
        //    Position test = new Position(1100, -2, DateTime.Now);
        //    SetAccountsPositions(main, test);
        //}

        private void SetAccountsPositions(Position main, Position test)
        {
            MainAccount.Position = main;
            TestAccount.Position = test;
        }

        private void InitializeAllObjects()
        {
            browser = new IE();

            MainAccount = AccountFactory.Create(ChooseAccount.Main);
            TestAccount = AccountFactory.Create(ChooseAccount.Account1);

            Monitor = new MonitorGmail();
            AddAccountToSync(TestAccount);
        } 
        #endregion

        //[TraceProperties] 
        public bool CancelSynchro = false;
        //[TraceProperties] 
        public bool DecisionMade = false;
        //[TraceProperties] 
        public bool MonitoringEnabled = true;
        //[TraceProperties] 
        public bool SignalsRulesChecking = true;
        //[TraceProperties] 
        public bool OrderingEnabled = true;
        
        public IE browser;
        public MonitorBase Monitor = null;
        public AccountBase MainAccount = null;
        public AccountBase TestAccount = null;
        public List<AccountBase> AccountsList = new List<AccountBase>();

        internal List<AccountCredentials> CredentialsList = new List<AccountCredentials>();
        //public Credentials MainCredentials;
        //public Credentials TestCredentials;
        public AccountCredentials MailFrom;
        public AccountCredentials MailSignal;

        #region Reading configuration
        const string settingFileName = "AccountSettings.psw";
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

        public void AddAccountToSync(AccountBase account)
        {
            if(!AccountsList.Exists( 
                (acc) => (account.Credentials.AccountId == acc.Credentials.AccountId)))
            {
                AccountsList.Add(account);
            }
            else
            {
                //throw new Exception("Account alredy added!");
            }
        }

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