using Core.Entities.Utilities.Email;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Infra.SMTP
{
    public class EmailManager : IEmailManager
    {

        public void SendEmailTo(string emailFrom, string emailTo, string header, string bodycontent,string smpt)
        {
            string subject = header;
            string body = bodycontent;
            string to = emailTo;
            MailMessage mailMessage = new MailMessage()
            {
                From = new MailAddress(emailFrom),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
                
            };
            mailMessage.To.Add(to);
            SmtpClient smtp = new SmtpClient("smtp.gmail.com")
            {
                UseDefaultCredentials = false,
                Port = 587,
                EnableSsl = true,
                Credentials = new NetworkCredential("xxxxxx@gmail.com", "xxxxxxx")
            };

            smtp.Send(mailMessage);
        }
    }
}
