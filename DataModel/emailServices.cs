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
            server.Credentials = new NetworkCredential("andapashabobo30@gmail.com", "epeqshbibaieqart");
            server.EnableSsl= true;
            server.Port = 587;
            server.Host= "smtp.gmail.com";
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
