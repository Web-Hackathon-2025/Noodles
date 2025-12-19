using Microsoft.AspNetCore.Mvc;

namespace Karigar.Controllers
{
    public class ServiceRequestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
