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
  public class CategoryController : Controller
  {
    private readonly ModelContext _context;
    private readonly IWebHostEnvironment _webHostEnviroment;

    public CategoryController(ModelContext context, IWebHostEnvironment webHostEnviroment)
    {
      _context = context;
      _webHostEnviroment = webHostEnviroment;
    }

    // GET: Category
    public async Task<IActionResult> Index()
    {
      return View(await _context.Categories.ToListAsync());
    }

    // GET: Category/Details/5
    public async Task<IActionResult> Details(decimal? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var category = await _context.Categories
          .FirstOrDefaultAsync(m => m.Id == id);
      if (category == null)
      {
        return NotFound();
      }

      return View(category);
    }

    // GET: Category/Create
    public IActionResult Create()
    {
      return View();
    }

    // POST: Category/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,CategoryName,ImagePath,ImageFile")] Category category)
    {
      if (ModelState.IsValid)
      {
        if (category.ImageFile != null)
        {
          string wwwRootPath = _webHostEnviroment.WebRootPath;
          string fileName = Guid.NewGuid().ToString() + "_" +
          category.ImageFile.FileName;
          string path = Path.Combine(wwwRootPath + "/Images/", fileName);
          using (var fileStream = new FileStream(path, FileMode.Create))
          {
            await category.ImageFile.CopyToAsync(fileStream);
          }
          category.ImagePath = fileName;
          _context.Add(category);
        }
        _context.Add(category);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      return View(category);
    }

    // GET: Category/Edit/5
    public async Task<IActionResult> Edit(decimal? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var category = await _context.Categories.FindAsync(id);
      if (category == null)
      {
        return NotFound();
      }
      return View(category);
    }

    // POST: Category/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(decimal id, [Bind("Id,CategoryName,ImagePath,ImageFile")] Category category)
    {
      if (id != category.Id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          if (category.ImageFile != null)
          {
            string wwwRootPath = _webHostEnviroment.WebRootPath;
            string fileName = Guid.NewGuid().ToString() + "_" +
            category.ImageFile.FileName;
            string path = Path.Combine(wwwRootPath + "/Images/",
            fileName);
            using (var fileStream = new FileStream(path,
            FileMode.Create))
            {
              await category.ImageFile.CopyToAsync(fileStream);
            }
            category.ImagePath = fileName;
          }

          _context.Update(category);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!CategoryExists(category.Id))
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
      return View(category);
    }

    // GET: Category/Delete/5
    public async Task<IActionResult> Delete(decimal? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var category = await _context.Categories
          .FirstOrDefaultAsync(m => m.Id == id);
      if (category == null)
      {
        return NotFound();
      }

      return View(category);
    }

    // POST: Category/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(decimal id)
    {
      var category = await _context.Categories.FindAsync(id);
      _context.Categories.Remove(category);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool CategoryExists(decimal id)
    {
      return _context.Categories.Any(e => e.Id == id);
    }
  }
}
