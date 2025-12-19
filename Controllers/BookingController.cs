using Microsoft.AspNetCore.Mvc;

namespace Karigar.Controllers
{
    public class BookingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
