using System;
using System.Net;
using System.Net.Mail;
using WebApi.Domain.Interfaces.ServiceInterfaces;

namespace WebApi.Services.EmailService
{
    public class EmailService : IEmailService
    {
        public bool Send(
            string toName,
            string toEmail,
            string subject,
            string body,
            string fromName,
            string fromEmail)
        {
            var smtpClient = new SmtpClient(Configurations.Smtp.Host, Configurations.Smtp.Port);

            smtpClient.Credentials = new NetworkCredential(Configurations.Smtp.Username, Configurations.Smtp.Password);
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.EnableSsl = true;

            var mail = new MailMessage();

            mail.From = new MailAddress(fromEmail, fromName);
            mail.To.Add(new MailAddress(toEmail, toName));
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;

            try
            {
                smtpClient.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
