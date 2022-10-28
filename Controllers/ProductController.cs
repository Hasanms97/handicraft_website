using System;
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
  public class ProductController : Controller
  {
    private readonly ModelContext _context;
    private readonly IWebHostEnvironment _webHostEnviroment;

    public ProductController(ModelContext context,IWebHostEnvironment webHostEnviroment)
    {
      _context = context;
      _webHostEnviroment = webHostEnviroment;
    }

    // GET: Product
    public async Task<IActionResult> Index()
    {
      var modelContext = _context.Products.Include(p => p.Category);
      return View(await modelContext.ToListAsync());
    }

    // GET: Product/Details/5
    public async Task<IActionResult> Details(decimal? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var product = await _context.Products
          .Include(p => p.Category)
          .FirstOrDefaultAsync(m => m.Id == id);
      if (product == null)
      {
        return NotFound();
      }

      return View(product);
    }

    // GET: Product/Create
    public IActionResult Create()
    {
      ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id");
      return View();
    }

    // POST: Product/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateCraft([Bind("Id,Name,Price,CategoryId,Description,ImagePath,Quantity,ImageFile")] Product product)
    {
      if (ModelState.IsValid)
      {
        if (product.ImageFile != null)
        {
          string wwwRootPath = _webHostEnviroment.WebRootPath;
          string fileName = Guid.NewGuid().ToString() + "_" +
          product.ImageFile.FileName;
          string path = Path.Combine(wwwRootPath + "/Images/", fileName);
          using (var fileStream = new FileStream(path, FileMode.Create))
          {
            await product.ImageFile.CopyToAsync(fileStream);
          }
          product.ImagePath = fileName;
          _context.Add(product);
        }
        _context.Add(product);
        await _context.SaveChangesAsync();
        
        return RedirectToAction(nameof(Index));
      }
      ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id", product.CategoryId);
      return View(product);
    }

    // GET: Product/Edit/5
    public async Task<IActionResult> Edit(decimal? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var product = await _context.Products.FindAsync(id);
      if (product == null)
      {
        return NotFound();
      }
      ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id", product.CategoryId);
      return View(product);
    }

    // POST: Product/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(decimal id, [Bind("Id,Name,Price,CategoryId,Description,ImagePath,Quantity")] Product product)
    {
      if (id != product.Id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(product);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!ProductExists(product.Id))
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
      ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id", product.CategoryId);
      return View(product);
    }

    // GET: Product/Delete/5
    public async Task<IActionResult> Delete(decimal? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var product = await _context.Products
          .Include(p => p.Category)
          .FirstOrDefaultAsync(m => m.Id == id);
      if (product == null)
      {
        return NotFound();
      }

      return View(product);
    }

    // POST: Product/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(decimal id)
    {
      var product = await _context.Products.FindAsync(id);
      _context.Products.Remove(product);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool ProductExists(decimal id)
    {
      return _context.Products.Any(e => e.Id == id);
    }
  }
}
