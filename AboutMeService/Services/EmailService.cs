using AboutMeService.Services.Abstraction;
using AboutMeViewModel.Entities;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace AboutMeService.Service
{
    public class EmailService : IEmailService
    {
        IConfiguration _configuration { get; }

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Send(ContactVM contact,string mailTo,string name,string surname, string subject, string body, bool isBodyHtml = false)
        {
            SmtpClient smtp = new SmtpClient(_configuration["Email:Host"], Convert.ToInt32(_configuration["Email:Port"]));
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential(_configuration["Email:Login"], _configuration["Email:Password"]);
            MailAddress from = new MailAddress(_configuration["Email:Login"], "TƏKLİF");
            MailAddress to = new MailAddress(mailTo);
            MailMessage message = new MailMessage(from, to);
            message.Body = contact.Message;
            message.Subject = contact.Email;

            //message.Subject = "geden mesaj";
            //message.Body = "israilden zeng elemisem";
            message.IsBodyHtml = isBodyHtml;
            smtp.Send(message);
        }

    }
}