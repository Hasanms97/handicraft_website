using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Handicraft_Website.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace Handicraft_Website.Controllers
{
  public class VendorController : Controller
  {
    private readonly ModelContext _context;
    private readonly IWebHostEnvironment _webHostEnviroment;

    public VendorController(ModelContext context, IWebHostEnvironment webHostEnviroment)
    {
      _context = context;
      _webHostEnviroment = webHostEnviroment;
    }

    public IActionResult Index()
    {
      ViewBag.numberOfCustomers = _context.Userrs.Count();
      ViewBag.numberOfCraftsman = _context.UserLogins.Where(x => x.RoleId == 2).Count();
      ViewBag.numberOfProduct = _context.Products.Count();


      var id = HttpContext.Session.GetInt32("Id");
      var user = _context.UserLogins.Include(x => x.Userr).Where(x => x.Id == id).FirstOrDefault();
      ViewBag.adminInfo = user;

      return View();
    }
    public IActionResult AddCraft()
    {


      ViewData["Id"] = new SelectList(_context.Categories, "Id", "CategoryName");

      return View();
    }
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

        var id = HttpContext.Session.GetInt32("Id");

        var user = _context.Userrs.Where(x => x.Id == id).SingleOrDefault();
        var vendorCart = _context.Carts.Where(x => x.UserrId == user.Id).FirstOrDefault();

        CartProduct cartProduct = new CartProduct();
        cartProduct.ProductId = product.Id;
        cartProduct.CartId = vendorCart.Id;
        cartProduct.Quantity = 0;

        _context.Add(cartProduct);
        await _context.SaveChangesAsync();
      }
      return View("AddCraft");
    }
    public async Task<IActionResult> ViewItems()
    {
      var id = HttpContext.Session.GetInt32("Id");

      var vendorCart = _context.Carts.Where(x => x.UserrId == id).SingleOrDefault();
      var vendorItems = _context.CartProducts.Include(x => x.Product).Where(x => x.CartId == vendorCart.Id);
      List<Category> categories = new List<Category>();

      foreach (var item in vendorItems)
      {
        categories.Add(_context.Categories.Where(x => x.Id == item.Product.CategoryId).SingleOrDefault());
      }

      ViewBag.categoryList = categories;



      return View(await vendorItems.ToListAsync());
    }
    public async Task<IActionResult> EditCraft(decimal id)
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


      ViewData["Id"] = new SelectList(_context.Categories, "Id", "CategoryName");
      return View(product);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditCraft(decimal id, [Bind("Id,Name,Price,CategoryId,Description,ImagePath,Quantity,ImageFile")] Product product)
    {
      if (id != product.Id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {

          //updating image
          if (product.ImageFile != null)
          {
            string wwwRootPath = _webHostEnviroment.WebRootPath;
            string fileName = Guid.NewGuid().ToString() + "_" +
            product.ImageFile.FileName;
            string path = Path.Combine(wwwRootPath + "/Images/",
            fileName);
            using (var fileStream = new FileStream(path,
            FileMode.Create))
            {
              await product.ImageFile.CopyToAsync(fileStream);
            }

            product.ImagePath = fileName;
          }


          _context.Update(product);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {

        }
        return RedirectToAction("ViewItems");
      }
      return View(product);
    }
    public async Task<IActionResult> DeleteCraft(decimal id)
    {
      var product = await _context.Products.FindAsync(id);
      _context.Products.Remove(product);
      await _context.SaveChangesAsync();


      return RedirectToAction("ViewItems");
    }
    public async Task<IActionResult> CraftDetails(decimal id)
    {
      var productDetails = _context.Products.Include(x => x.Category).Where(x => x.Id == id).SingleOrDefault();

      return View(productDetails);
    }
    public IActionResult UpdateProfile()
    {
      var id = HttpContext.Session.GetInt32("Id");
      var user = _context.UserLogins.Include(x => x.Userr).Where(x => x.UserrId == id).FirstOrDefault();
      ViewBag.vendorInfo = user;

      return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UpdateProfile([Bind("Id,FirstName,LastName,ImagePath,ImageFile")] Userr userr, String userName, String email)
    {
      var id = HttpContext.Session.GetInt32("Id");
      userr.Id = (decimal)id;
      var userlogin = _context.UserLogins.Where(x => x.UserrId == id).SingleOrDefault();
      if (id != userlogin.UserrId)
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
          userlogin.Email = email;
          userlogin.UserName = userName;

          //for the user
          _context.Update(userr);
          await _context.SaveChangesAsync();

          //for the userlogin
          _context.Update(userr);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {

          throw;
        }
        return RedirectToAction("UpdateProfile");
      }
      return RedirectToAction("UpdateProfile");
    }
    [HttpPost]
    public async Task<IActionResult> UpdatePassword(String currentpassword, String newPassword1, String newPassword2)
    {
      var id = HttpContext.Session.GetInt32("Id");
      var accountInfo = _context.UserLogins.Where(x => x.Id == id).SingleOrDefault();

      if (currentpassword == accountInfo.Passwordd)
      {
        accountInfo.Passwordd = newPassword1;
        _context.Update(accountInfo);
        await _context.SaveChangesAsync();
      }

      return RedirectToAction("UpdateProfile");
    }
  }
}