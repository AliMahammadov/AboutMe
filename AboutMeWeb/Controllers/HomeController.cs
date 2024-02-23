using AboutMeService.Services.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace AboutMeWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmailService service;

        public HomeController(IEmailService service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }
        public async Task<IActionResult> SendMail()
        {
            service.Send("tu6hwwz7l@code.edu.az", "Test1", "mesajin ozu");
            return View();
        }

    }
}
