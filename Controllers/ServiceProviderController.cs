using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Karigar.Models;
using Karigar.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;


namespace Karigar.Controllers
{
    [Authorize(Roles = "ServiceProvider")]
    public class ServiceProviderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ServiceProviderController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ServiceProviderProfile model)
        {
            if (!ModelState.IsValid)
                return View(model);

            model.UserId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value;

            _context.ServiceProviderProfiles.Add(model);
            await _context.SaveChangesAsync();

            return RedirectToAction("Dashboard");
        }

    }

}
