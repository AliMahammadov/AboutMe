using AboutMeViewModel.Entities;

namespace AboutMeService.Services.Abstraction
{
    public interface IEmailService
    {
        void Send(ContactVM contact, string mailTo, string subject, string body,string name,string surname ,bool isBodyHtml = false);
    }
}