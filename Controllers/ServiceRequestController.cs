using Microsoft.AspNetCore.Mvc;
using Karigar.Data;
using Karigar.Models;
using System.Security.Claims;

namespace Karigar.Controllers
{
    public class ServiceRequestController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ServiceRequestController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Submit a request to a provider
        [HttpPost]
        public async Task<IActionResult> Book(int providerId, string description)
        {
            var request = new ServiceRequest
            {
                ProviderId = providerId,
                CustomerId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                ServiceDescription = description,
                RequestedDate = DateTime.Now,
                Status = "Pending"
            };

            _context.ServiceRequests.Add(request);
            await _context.SaveChangesAsync();
            return RedirectToAction("MyRequests");
        }

        public async Task<IActionResult> MyRequests()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var myBookings = _context.ServiceRequests
                .Where(r => r.CustomerId == userId)
                .ToList();
            return View(myBookings);
        }
    }
}
