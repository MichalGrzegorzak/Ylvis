using System;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Pop3
{
    public class SmtpSender
    {
        protected SmtpClient client = null;

        public string From { get; set; }
        public string To { get; set; } 

        public SmtpSender(string host, int port)
        {
            client = new SmtpClient(host, port);
        }

        public MailMessage CreateMessage(string subject, string body)
        {
            return CreateMessage(From, To, subject, body);
        }

        public static MailMessage CreateMessage(string from, string to, string subject, string body)
        {
           return new MailMessage(from, to, subject, body);
        }

        public void Send(MailMessage message)
        {
            SendMessage(client, message);

            //Console.WriteLine(
            //    "Sending emails completed. Give POP3 server a bit of time to receive the emails, then press 'Return' key.");
            //Console.ReadLine();
        }

        private void Old(MailMessage message)
        {
            SendMessage(client, message);
            Console.WriteLine("Sending emails completed. Give POP3 server a bit of time to receive the emails, then press 'Return' key.");
            Console.ReadLine();

            //SmtpClient client = new SmtpClient("smtp.gmail.com", 999);

            // TODO: Replace email addresses.
            //MailAddress from = new MailAddress("mgrzegorzak@gmail.com", "Any name or remove this string");
            //MailAddress to = new MailAddress(mailTo);
            //MailMessage message;
            AlternateView thisAlternateView1;
            AlternateView thisAlternateView2;

            //just body text email
            //message = new MailMessage(from, to);
            //message.Subject = "Text only email";
            //message.Body = "This is a test e-mail message with just a plain text body.";
            

            ////pure text email with body and 1 alternative view
            //message = new MailMessage(from, to);
            //message.Subject = "pure text email with body and 1 alternative view";
            //message.Body = "This is the body text";
            //thisAlternateView1 = AlternateView.CreateAlternateViewFromString("This is the alternative view text");
            //message.AlternateViews.Add(thisAlternateView1);
            //SendMessage(client, message);

            ////pure text email with no body but 1 alternative view
            //message = new MailMessage(from, to);
            //message.Subject = "pure text email with no body but 1 alternative view";
            //thisAlternateView1 = AlternateView.CreateAlternateViewFromString("This is the alternative view text");
            //message.AlternateViews.Add(thisAlternateView1);
            //SendMessage(client, message);

            ////pure text email with plain text body and 2 alternative views
            //message = new MailMessage(from, to);
            //message.Subject = "pure text email with plain text body and 2 alternative views";
            //message.Body = "This is the body text";
            //thisAlternateView1 = AlternateView.CreateAlternateViewFromString("This is the alternative view text");
            //message.AlternateViews.Add(thisAlternateView1);
            //thisAlternateView2 = AlternateView.CreateAlternateViewFromString("<html><body>This is a <b>HTML<b> text body</body></html>");
            //thisAlternateView2.ContentType.MediaType = "text/html";
            //message.AlternateViews.Add(thisAlternateView2);
            //SendMessage(client, message);

            ////email with attachment and UTF8 body encoding
            //message = new MailMessage(from, to);
            //message.Subject = "email with attachment and UTF8 body encoding";
            //message.SubjectEncoding = Encoding.ASCII;
            //message.Body = "Body text";
            //// Include some non-ASCII characters in body and subject.
            //string someArrows = new string(new char[] { '\u2190', '\u2191', '\u2192', '\u2193' });
            //message.Body += Environment.NewLine + someArrows;
            //message.BodyEncoding = Encoding.UTF8;

            //// TODO: Write path and name of an existing file into the following string
            //Attachment thisAttachment = new Attachment(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Pic.GIF");
            //message.Attachments.Add(thisAttachment);

            //message.BodyEncoding = Encoding.UTF8;
            //message.Subject = "test message 1" + someArrows;
            //message.SubjectEncoding = Encoding.UTF7;

            //client.Send(message);
        }

        static void SendMessage(SmtpClient client, MailMessage message)
        {
            client.Send(message);
            Console.WriteLine("Message '" + message.Subject + "'sent");
            // Clean up.
            message.Dispose();
        }
    }
}
