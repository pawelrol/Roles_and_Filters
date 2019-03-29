using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity.UI.Services;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using SmtpClient = System.Net.Mail.SmtpClient;

namespace WebApplication3.Areas.Identity.Services
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            MailMessage msg = new MailMessage("gmkwasniewski@gmail.com", "gmkwasniewski@gmail.com");

            using (var client = new SmtpClient("smtp.gmail.com"))
            {
                client.Port = 587;
                client.Credentials = new NetworkCredential("gmkwasniewski@gmail.com", "");
                client.EnableSsl = true;
                client.Send(msg);
            }
            return null;
        }
    }
}
