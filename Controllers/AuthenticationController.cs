using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Handicraft_Website.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Handicraft_Website.Controllers
{
  public class AuthenticationController : Controller
  {
    private readonly ModelContext _context;

    private readonly IWebHostEnvironment _webHostEnvironment;

    public AuthenticationController(ModelContext context, IWebHostEnvironment webHostEnvironment)
    {
      _context = context;
      _webHostEnvironment = webHostEnvironment;
    }
    public IActionResult Login()
    {
      return View();
    }

    [HttpPost]
    public IActionResult Login(string username, string password)
    {

      var item = _context.UserLogins.SingleOrDefault(x => x.UserName == username && x.Passwordd == password);


      if (item != null)
      {
        switch (item.RoleId)
        {
          case 21:
            {
              return View("error");
            }
          case 1:
            {
              HttpContext.Session.SetInt32("Id", (int)item.UserrId);
              return RedirectToAction("Index", "Admin");
            }
          case 2:
            {
              HttpContext.Session.SetInt32("Id", (int)item.UserrId);
              return RedirectToAction("Index", "Vendor");
            }
          case 3:
            {
              HttpContext.Session.SetInt32("Id", (int)item.UserrId);
              return RedirectToAction("CustomerIndex", "Customer");
            }
        }
      }
      else
      {
        ViewBag.error = "Invalid username or password";
        return View();
      }
      return View();
    }


    public IActionResult Register()
    {
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register([Bind("Id,FirstName,LastName,ImagePath,ImageFile")] Userr customer, string username, string email, string password) // customer => fname , lname , imagefile
    {

      if (ModelState.IsValid)
      {
        if (customer.ImageFile != null)
        {
          string wwwrootPath = _webHostEnvironment.WebRootPath; // wwwrootpath
          string imageName = Guid.NewGuid().ToString() + "_" + customer.ImageFile.FileName; // image name
          string path = Path.Combine(wwwrootPath + "/images/", imageName); // wwwroot/Image/imagename

          using (var filestream = new FileStream(path, FileMode.Create))
          {
            await customer.ImageFile.CopyToAsync(filestream);
          }
          customer.ImagePath = imageName;
        }

        _context.Add(customer);
        await _context.SaveChangesAsync();
        UserLogin user = new UserLogin();
        user.UserName = username;
        user.Passwordd = password;
        user.Email = email;
        user.RoleId = 3;
        user.UserrId = customer.Id;

        _context.Add(user);
        await _context.SaveChangesAsync();


        Cart cart = new Cart();
        cart.OrderStatus = 0;
        cart.UserrId = customer.Id;
        _context.Add(cart);
        await _context.SaveChangesAsync();

        return RedirectToAction("Login");
      }

      return View(customer);
    }
    public IActionResult VendorRegister()
    {
      return View();
    }
    [HttpPost]
    public async Task<IActionResult> VendorRegister([Bind("Id,FirstName,LastName,ImagePath,ImageFile")] Userr customer, string username, string email, string password) // customer => fname , lname , imagefile
    {

      if (ModelState.IsValid)
      {
        if (customer.ImageFile != null)
        {
          string wwwrootPath = _webHostEnvironment.WebRootPath; // wwwrootpath
          string imageName = Guid.NewGuid().ToString() + "_" + customer.ImageFile.FileName; // image name
          string path = Path.Combine(wwwrootPath + "/images/", imageName); // wwwroot/Image/imagename

          using (var filestream = new FileStream(path, FileMode.Create))
          {
            await customer.ImageFile.CopyToAsync(filestream);
          }
          customer.ImagePath = imageName;
        }
        _context.Add(customer);
        await _context.SaveChangesAsync();
        UserLogin user = new UserLogin();
        user.UserName = username;
        user.Passwordd = password;
        user.Email = email;
        user.RoleId = 21;
        user.UserrId = customer.Id;

        _context.Add(user);
        await _context.SaveChangesAsync();


        return RedirectToAction("Login");
      }

      return View(customer);
    }

  }
}
