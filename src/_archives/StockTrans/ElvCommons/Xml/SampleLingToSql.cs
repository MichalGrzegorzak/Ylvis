using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core
{
    class SampleLingToSql
    {
        public static void ReadAccountSettingsFromFile()
        {
            //XDocument xml = XDocument.Load("AccountSettings.cfg");
            //IEnumerable<Credentials> lista = 
            //    from account in xml.Descendants("Account")
            //              select new Credentials()
            //                         {
            //                             Id = account.Attribute("Id").Value.Parse<int>(),
            //                             Login = account.Element("Login").Value,
            //                             Pass = account.Element("Pass").Value
            //                         };
        }

        public static void WriteXmlSettings()
        {
            //XDocument xml = new XDocument(
            //    new XDeclaration("1.0","utf-8","yes"),
            //    new XElement("AccountsList",
            //        from account in accountsList
            //        orderby account.Id
            //            select new XElement("Account",
            //                new XAttribute("Id", account.Id),
            //                new XElement("Login", account.Login),
            //                new XElement("Pass", account.Pass)
            //            )
            //        )
            //    );
        }
        
    }
}
