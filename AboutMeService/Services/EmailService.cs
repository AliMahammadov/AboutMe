using AboutMeService.Services.Abstraction;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace AboutMeService.Service
{
    public class EmailService:IEmailService
    {
        IConfiguration _configuration { get; }

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Send(string mailTo, string subject,string body,  bool isBodyHtml=false)
        {
            SmtpClient smtp = new SmtpClient(_configuration["Email:Host"],Convert.ToInt32(_configuration["Email:Port"]));
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential(_configuration["Email:Login"], _configuration["Email:Password"]);
            MailAddress from = new MailAddress(_configuration["Email:Login"], "Basliq");
            MailAddress to = new MailAddress(mailTo);
            MailMessage message = new MailMessage(from,to);
            message.Subject = "geden mesaj";
            message.Body = body;
            message.IsBodyHtml = isBodyHtml;
            smtp.Send(message);
        }

    }
}
