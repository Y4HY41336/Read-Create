using Again2.Context;
using Again2.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Again2.Areas.Admin.Controllers;
[Area("Admin")]
public class ShippingController : Controller
{
    private readonly ProniaDbContext _context;

    public ShippingController(ProniaDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var shippings = await _context.Shippings.ToListAsync();
        return View(shippings);
    }
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(Shipping shipping)
    {
        await _context.Shippings.AddAsync(shipping);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }
    public async Task<IActionResult> Delete(int id)
    {

        var shippings = await _context.Shippings.FirstOrDefaultAsync(x => x.Id == id);
        if (shippings == null)
        {
            return NotFound();
        }
        return View(shippings);
    }

    [HttpPost]
    [ActionName("Delete")]
    public async Task<IActionResult> DeleteSlider(int id)
    {
        var shipping = await _context.Shippings.FirstOrDefaultAsync(s => s.Id == id);
        if (shipping == null)
        {
            return NotFound();
        }
        _context.Remove(shipping);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }
}
