using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace Karigar.Controllers
{


    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
   
    {
        public IActionResult Dashboard()
        {
            return View();
        }
    }

}

