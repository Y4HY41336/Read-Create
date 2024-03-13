using Again2.Context;
using Again2.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Again.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProniaDbContext _context;

        public HomeController(ProniaDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var shippings = await _context.Shippings.ToListAsync();
            var sliders = await _context.Sliders.ToListAsync();
            HomeViewModel homeView = new()
            {
                Shippings = shippings,
                Sliders = sliders
            };
            return View(homeView);
        }
    }
}
