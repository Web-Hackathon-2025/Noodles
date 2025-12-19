using Karigar.Data;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

public class ServiceProviderController : Controller
{
    private readonly ApplicationDbContext _context;
    public ServiceProviderController(ApplicationDbContext context) { _context = context; }

    // CUSTOMER: Browse Providers
    public async Task<IActionResult> Index(string search, string category)
    {
        var providers = _context.ServiceProviders.AsQueryable();
        if (!string.IsNullOrEmpty(search)) providers = providers.Where(p => p.Location.Contains(search));
        if (!string.IsNullOrEmpty(category)) providers = providers.Where(p => p.Category == category);
        return View(await providers.ToListAsync());
    }

    // PROVIDER: Their own dashboard to see bookings
    public async Task<IActionResult> Dashboard()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var profile = await _context.ServiceProviders.FirstOrDefaultAsync(p => p.UserId == userId);
        if (profile == null) return RedirectToAction("Create");

        var requests = await _context.ServiceRequests
            .Include(r => r.Customer)
            .Where(r => r.ProviderId == profile.Id)
            .OrderByDescending(r => r.RequestedDate).ToListAsync();
        return View(requests);
    }

    // Action to Accept/Reject
    [HttpPost]
    public async Task<IActionResult> UpdateStatus(int requestId, string status)
    {
        var req = await _context.ServiceRequests.FindAsync(requestId);
        if (req != null)
        {
            req.Status = status;
            await _context.SaveChangesAsync();
        }
        return RedirectToAction("Dashboard");
    }
}
