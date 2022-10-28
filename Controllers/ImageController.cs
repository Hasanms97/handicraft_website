using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Handicraft_Website.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Handicraft_Website.Controllers
{
  public class ImageController : Controller
  {
    private readonly ModelContext _context;
    private readonly IWebHostEnvironment _webHostEnviroment;

    public ImageController(ModelContext context,IWebHostEnvironment webHostEnviroment)
    {
      _context = context;
      _webHostEnviroment = webHostEnviroment;
    }

    // GET: Image
    public async Task<IActionResult> Index()
    {
      var modelContext = _context.Images.Include(i => i.Page);
      return View(await modelContext.ToListAsync());
    }

    // GET: Image/Details/5
    public async Task<IActionResult> Details(decimal? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var image = await _context.Images
          .Include(i => i.Page)
          .FirstOrDefaultAsync(m => m.Id == id);
      if (image == null)
      {
        return NotFound();
      }

      return View(image);
    }

    // GET: Image/Create
    public IActionResult Create()
    {
      ViewData["PageId"] = new SelectList(_context.Pages, "Id", "Id");
      return View();
    }

    // POST: Image/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,PageId,ImagePath,ImageFile")] Image image)
    {
      if (ModelState.IsValid)
      {
        if (image.ImageFile != null)
        {
          string wwwRootPath = _webHostEnviroment.WebRootPath;
          string fileName = Guid.NewGuid().ToString() + "_" +
          image.ImageFile.FileName;
          string path = Path.Combine(wwwRootPath + "/Images/", fileName);
          using (var fileStream = new FileStream(path, FileMode.Create))
          {
            await image.ImageFile.CopyToAsync(fileStream);
          }
          image.ImagePath = fileName;
          _context.Add(image);
        }
        _context.Add(image);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      ViewData["PageId"] = new SelectList(_context.Pages, "Id", "Id", image.PageId);
      return View(image);
    }

    // GET: Image/Edit/5
    public async Task<IActionResult> Edit(decimal? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var image = await _context.Images.FindAsync(id);
      if (image == null)
      {
        return NotFound();
      }
      ViewData["PageId"] = new SelectList(_context.Pages, "Id", "Id", image.PageId);
      return View(image);
    }

    // POST: Image/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(decimal id, [Bind("Id,PageId,ImagePath")] Image image)
    {
      if (id != image.Id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(image);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!ImageExists(image.Id))
          {
            return NotFound();
          }
          else
          {
            throw;
          }
        }
        return RedirectToAction(nameof(Index));
      }
      ViewData["PageId"] = new SelectList(_context.Pages, "Id", "Id", image.PageId);
      return View(image);
    }

    // GET: Image/Delete/5
    public async Task<IActionResult> Delete(decimal? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var image = await _context.Images
          .Include(i => i.Page)
          .FirstOrDefaultAsync(m => m.Id == id);
      if (image == null)
      {
        return NotFound();
      }

      return View(image);
    }

    // POST: Image/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(decimal id)
    {
      var image = await _context.Images.FindAsync(id);
      _context.Images.Remove(image);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool ImageExists(decimal id)
    {
      return _context.Images.Any(e => e.Id == id);
    }
  }
}
