using AboutMeService.Services.Abstraction;
using AboutMeViewModel.Entities;
using AboutMeViewModel.Entities.Home;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace AboutMeWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmailService service;

        public HomeController(IEmailService service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index(ContactVM contact)
        {
            service.Send(contact, "tu6hwwz7l@code.edu.az", "Test1", "mesajin ozu", "dd", "d4");
            return View();
        }
        

    }
}
