using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Reflection;

namespace DataModel
{
    public class emailServices
    {
        private SmtpClient server;
        private MailMessage email;

        public emailServices()
        {
            server = new SmtpClient();
            server.Credentials = new NetworkCredential("de64205f39657e", "daee0a760f4b33");
            server.EnableSsl= true;
            server.Port = 2525;
            server.Host= "sandbox.smtp.mailtrap.io";
        }
        public void createEmail(string Address, string Subject, string Message)
        {
            email = new MailMessage();
            email.From = new MailAddress(Address);
            email.Subject = Subject;
            email.To.Add(Address);
            email.IsBodyHtml= true;
            email.Body = Message;
        }
        public void sendEmail()
        {
            server.Send(email);
        }
    }
}
