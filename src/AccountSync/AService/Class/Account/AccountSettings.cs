using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using AServiceContract;
using Commons.Extensions;

namespace AService
{
    public class AccountSettings
    {
        const string settingFileName = "AccountSettings.psw";

        public List<Credentials> Credentials = new List<Credentials>();

        #region Read / Store configuration
        
        public void SaveAccountSettingsToFile()
        {
            //CallTrace("Saving settings to config!");

            //Credentials = new List<Credentials>(
              //  new Credentials[] { MailFrom, MailSignal, Credentials[2], Credentials[3] });

            XDocument xml = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement("AccountsList",
                             from account in Credentials
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
                IEnumerable<Credentials> lista =
                    from account in xml.Descendants("Account")
                    orderby account.Attribute("Id").Value.Parse<int>()
                    select new Credentials()
                    {
                        AccountId = account.Attribute("Id").Value.Parse<int>(),
                        Login = account.Attribute("Login").Value,
                        Pass = account.Attribute("Pass").Value
                    };

                Credentials = new List<Credentials>(lista);
                //MailFrom = Credentials[0];
                //MailSignal = Credentials[1];
            }
            catch (Exception)
            {
                result = false;
                //throw;
            }
            return result;
        }

        #endregion
    }
}
