using Again2.Areas.Admin.ViewModel;
using Again2.Context;
using Again2.Helpers;
using Again2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Again2.Areas.Admin.Controllers;
[Area("Admin")]

public class SliderController : Controller
{
    private readonly ProniaDbContext _context;
    private readonly IWebHostEnvironment _webHostEnvironment;
    public SliderController(ProniaDbContext context, IWebHostEnvironment webHostEnvironment)
    {
        _context = context;
        _webHostEnvironment = webHostEnvironment;
    }

    public IActionResult Index()
    {
        var slider = _context.Sliders.ToList();
        

        return View(slider);
    }
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(SliderViewModel slider)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        if (!slider.Image.CheckFileSize(3000))
        {
            ModelState.AddModelError("Image", "Too Big!");
            return View();
        }
        if (!slider.Image.CheckFileType("image/"))
        {
            ModelState.AddModelError("Image", "sekil olsun");
            return View();
        }
        string fileName = $"{Guid.NewGuid()}-{slider.Image.FileName}";
        string path = Path.Combine(_webHostEnvironment.WebRootPath, "assets", "images", "website-images", fileName);
        FileStream stream = new FileStream(path, FileMode.Create);
        await slider.Image.CopyToAsync(stream);
        stream.Dispose();

        Slider newslider = new()
        {
            Offer = slider.Offer,
            Title = slider.Title,
            Description = slider.Description,
            Image = fileName
        };
        _context.Sliders.Add(newslider);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
    public async Task<IActionResult> Delete(int id)
    {
        var slider = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == id);
        if (slider == null)
        {
            return NotFound();
        }
        return View(slider);
    }

    [HttpPost]
    [ActionName("Delete")]
    public async Task<IActionResult> DeleteSlider(int id)
    {
        var slider = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == id);
        if (slider == null)
        {
            return NotFound();
        }
        string path = Path.Combine(_webHostEnvironment.WebRootPath, "assets", "images", "website-images", slider.Image);
        if (System.IO.File.Exists(path))
        {
            System.IO.File.Delete(path);
        }
        _context.Remove(slider);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }
}
