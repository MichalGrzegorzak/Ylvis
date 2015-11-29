using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using Pop3;

namespace Core.Gmail
{
    public class GmailSender : SmtpSender
    {
        public GmailSender() : base("smtp.gmail.com", 587)
        {
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Timeout = 20000;

            From = Framework.Inst.MailFrom.Login;
            To = Framework.Inst.MailSignal.Login;
            client.Credentials = new NetworkCredential(From, Framework.Inst.MailFrom.Pass);
        }

        private void Sleep()
        {
            Framework.CallTrace("Sleep 4 sec...");
            Thread.Sleep(4000);
        }

        public void SendSpamMail()
        {
            MailMessage mail = CreateMessage("jestem spamem z MAIN MAILA", "transak spam spam z MAIN MAILA");
            Send(mail);
            Sleep();
        }

        public void SendTest4S()
        {
            MailMessage mail = CreateMessage("TRANSAKCJE: FW20Z09 S 4*2238 g.16:00 dn.28.08.2009", 
                "Na rachunku nr 00-22-255294 zawarto w dniu 28.08.2009 o godz. 16:00 transakcje: FW20Z09 S 4*2238");
            Send(mail);
            Sleep();
        }

        public void SendTest4K()
        {
            MailMessage mail = CreateMessage("TRANSAKCJE: FW20Z09 K 4*2258 g.16:00 dn.28.08.2009",
                "Na rachunku nr 00-22-255294 zawarto w dniu 28.08.2009 o godz. 16:15 transakcje: FW20Z09 K 4*2258");
            Send(mail);
            Sleep();
        }

        public void SendSignal(string direction, string size)
        {
            Framework.CallTrace("Sending mail signal: " + size + direction);

            string subject = string.Format("TRANSAKCJE: FW20Z09 {0} {1}*2266 g.16:00 dn.28.08.2009", direction, size);
            string message = string.Format("Na rachunku nr 00-22-255294 zawarto w dniu 28.08.2009 o godz. 16:15 transakcje: FW20Z09 {0} {1}*2266", direction, size);
            MailMessage mail = CreateMessage(subject, message);
            Send(mail);
            Sleep();
        }

        public void SendTest3Kand1K()
        {
            MailMessage mail = CreateMessage("TRANSAKCJE: FW20Z09 K 3*2200 g.15:15 dn.28.08.2009",
                "Na rachunku nr 00-22-255294 zawarto w dniu 27.08.2009 o godz. 15:15 transakcje: FW20Z09 K 3*2200");
            Send(mail);

            mail = CreateMessage("TRANSAKCJE: FW20Z09 K 1*2200 g.15:15 dn.28.08.2009",
                "Na rachunku nr 00-22-255294 zawarto w dniu 27.08.2009 o godz. 15:15 transakcje: FW20Z09 K 1*2200");
            Send(mail);
            Sleep();
        }

        public void SendTest3Sand1K()
        {
            MailMessage mail = CreateMessage("TRANSAKCJE: FW20Z09 S 3*1900 g.15:15 dn.28.08.2009",
                "Na rachunku nr 00-22-255294 zawarto w dniu 27.08.2009 o godz. 15:15 transakcje: FW20Z09 S 3*1900");
            Send(mail);

            mail = CreateMessage("TRANSAKCJE: FW20Z09 K 1*1900 g.15:15 dn.28.08.2009",
                "Na rachunku nr 00-22-255294 zawarto w dniu 27.08.2009 o godz. 15:15 transakcje: FW20Z09 K 1*1900");
            Send(mail);
            Sleep();
        }
    }
}
