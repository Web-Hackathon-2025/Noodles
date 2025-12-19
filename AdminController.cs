using Microsoft.AspNetCore.Mvc;

namespace Karigar.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
