using Microsoft.AspNetCore.Mvc;

namespace Karigar.Models
{
    public class ServiceProviderProfile : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
