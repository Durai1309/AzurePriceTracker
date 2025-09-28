using AzurePriceTracker.Data;
using AzurePriceTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AzurePriceTracker.Controllers
{
    public class AzurePricesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AzurePricesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var serviceGroups = await _context.ServiceGroups
                .OrderBy(sg => sg.ServiceFamily)
                .ThenBy(sg => sg.ServiceName)
                .ToListAsync();

            return View(serviceGroups);
        }

        public async Task<IActionResult> Details(string serviceFamily, string serviceName)
        {
            var products = await _context.ProductDetails
                .Where(p => p.ServiceFamily == serviceFamily && p.ServiceName == serviceName)
                .OrderBy(p => p.ProductName)
                .ThenBy(p => p.SkuName)
                .ToListAsync();

            return View(products);
        }
    }
}