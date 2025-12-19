using Microsoft.AspNetCore.Mvc;

namespace Karigar.Models
{
    public class ServiceRequest : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
