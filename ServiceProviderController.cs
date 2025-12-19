using Microsoft.AspNetCore.Mvc;

namespace Karigar.Controllers
{
    public class ServiceProviderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
