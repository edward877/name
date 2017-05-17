using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net.Mail;
using System.Net;
using System.Net.Mime;

namespace Email
{
   
    public class SendEmail
    {
        SmtpClient Smtp;
       

        public SendEmail()
        {
            Smtp = new SmtpClient("smtp.mail.ru", 2525);
            Smtp.Credentials = new NetworkCredential("the.garage", "1234qwe");
            Smtp.EnableSsl = true;
        }

        public void SendMessage(string email, string subject, string text)
        {
            MailMessage Message = new MailMessage();
            Message.From = new MailAddress("the.garage@mail.ru");
            Message.To.Add(new MailAddress(email));
            Message.Subject = subject;
            Message.Body = text;
            Smtp.Send(Message);
        }

    }
}
