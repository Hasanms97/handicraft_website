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
  public class UserrController : Controller
  {
    private readonly ModelContext _context;
    private readonly IWebHostEnvironment _webHostEnviroment;

    public UserrController(ModelContext context, IWebHostEnvironment webHostEnviroment)
    {
      _context = context;
      _webHostEnviroment = webHostEnviroment;
    }

    // GET: Userr
    public async Task<IActionResult> Index()
    {
      return View(await _context.Userrs.ToListAsync());
    }

    // GET: Userr/Details/5
    public async Task<IActionResult> Details(decimal? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var userr = await _context.Userrs
          .FirstOrDefaultAsync(m => m.Id == id);
      if (userr == null)
      {
        return NotFound();
      }

      return View(userr);
    }

    // GET: Userr/Create
    public IActionResult Create()
    {
      return View();
    }

    // POST: Userr/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,ImagePath,ImageFile")] Userr userr)
    {
      if (ModelState.IsValid)
      {
        if (userr.ImageFile != null)
        {
          string wwwRootPath = _webHostEnviroment.WebRootPath;
          string fileName = Guid.NewGuid().ToString() + "_" +
          userr.ImageFile.FileName;
          string path = Path.Combine(wwwRootPath + "/Images/", fileName);
          using (var fileStream = new FileStream(path, FileMode.Create))
          {
            await userr.ImageFile.CopyToAsync(fileStream);
          }
          userr.ImagePath = fileName;
          _context.Add(userr);
        }

        _context.Add(userr);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      return View(userr);
    }

    // GET: Userr/Edit/5
    public async Task<IActionResult> Edit(decimal? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var userr = await _context.Userrs.FindAsync(id);
      if (userr == null)
      {
        return NotFound();
      }
      return View(userr);
    }

    // POST: Userr/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(decimal id, [Bind("Id,FirstName,LastName,ImagePath,ImageFile")] Userr userr)
    {
      if (id != userr.Id)
      {
        return NotFound();
      }
      if (ModelState.IsValid)
      {
        try
        {
          if (userr.ImageFile != null)
          {
            string wwwRootPath = _webHostEnviroment.WebRootPath;
            string fileName = Guid.NewGuid().ToString() + "_" +
            userr.ImageFile.FileName;
            string path = Path.Combine(wwwRootPath + "/Images/",
            fileName);
            using (var fileStream = new FileStream(path,
            FileMode.Create))
            {
              await userr.ImageFile.CopyToAsync(fileStream);
            }
            userr.ImagePath = fileName;
          }
          _context.Update(userr);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!UserrExists((int)userr.Id))
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
      return View(userr);
    }
    // GET: Userr/Delete/5
    public async Task<IActionResult> Delete(decimal? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var userr = await _context.Userrs
          .FirstOrDefaultAsync(m => m.Id == id);
      if (userr == null)
      {
        return NotFound();
      }

      return View(userr);
    }

    // POST: Userr/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(decimal id)
    {
      var userr = await _context.Userrs.FindAsync(id);
      _context.Userrs.Remove(userr);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool UserrExists(decimal id)
    {
      return _context.Userrs.Any(e => e.Id == id);
    }
  }
}
