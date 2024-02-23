namespace AboutMeService.Services.Abstraction
{
    public interface IEmailService
    {
        void Send(string mailTo, string subject, string body, bool isBodyHtml = false);
    }
}
