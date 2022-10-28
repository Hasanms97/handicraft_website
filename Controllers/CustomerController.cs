using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Handicraft_Website.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MimeKit;

namespace Handicraft_Website.Controllers
{
  public class CustomerController : BaseController
  {
    private readonly ILogger<CustomerController> _logger;
    private readonly IWebHostEnvironment _webHostEnviroment;
    private readonly ModelContext _context;

    public CustomerController(ILogger<CustomerController> logger, ModelContext context, IWebHostEnvironment webHostEnviroment) : base(context)
    {
      _logger = logger;
      _context = context;
      _webHostEnviroment = webHostEnviroment;
    }
    public async Task<IActionResult> CustomerIndex()
    {
      // //User ID
      var id = HttpContext.Session.GetInt32("Id");

      // //for viewing the products on the web
      var products = _context.Products.ToList();

      //showing random category every time the page refresh's
      var category = _context.Categories.ToList();
      int CountOfCategory = category.Count();
      List<Category> categories = new List<Category>();
      Random rnd = new Random();
      int rand = 0;
      for (int x = 0; x < 4; x++)
      {
        rand = rnd.Next(0, CountOfCategory);
        categories.Add(category[rand]);
      }

      var testimonial = _context.Testimonials.Include(x=>x.User).Where(x=>x.Status == 1).ToList();
      var count = testimonial.Count();

      // //for Tuple
      var cartProduct = _context.CartProducts.Include(x => x.Cart).Include(x => x.Product).Where(x => x.Cart.UserrId == id).ToList();
      var result = Tuple.Create<IEnumerable<CartProduct>, IEnumerable<Product>, IEnumerable<Category>,IEnumerable<Testimonial>>(cartProduct, products, categories,testimonial);

      return View(result);
    }
    public async Task<IActionResult> ProductDetail(decimal id)
    {
      //for product detail page
      var product = _context.Products.Include(x => x.Category).Where(x => x.Id == id).SingleOrDefault();


      return View(product);
    }
    public async Task<IActionResult> AddToCart(decimal id, int quantity)
    {
      //User ID
      var ID = HttpContext.Session.GetInt32("Id");

      //add to cart logic
      var cart = _context.Carts.Where(x => x.UserrId == ID).OrderBy(x => x.Id).Last();
      var item = _context.Products.Where(x => x.Id == id).SingleOrDefault();

      CartProduct obj = new CartProduct();
      obj.ProductId = item.Id;
      obj.Quantity = quantity;
      obj.CartId = cart.Id;

      _context.Add(obj);
      await _context.SaveChangesAsync();


      return RedirectToAction("ProductDetail", new { ID = id });
    }
    public async Task<IActionResult> ViewCart(decimal ID)
    {
      //User ID
      var id = HttpContext.Session.GetInt32("Id");

      //for the number of items in the cart      
      var numberOfItem = _context.CartProducts.Where(x => x.Cart.UserrId == id).Count();
      ViewBag.numberOfItem = numberOfItem;

      //for viewing the products on the web
      var products = _context.Products.ToList();

      //for Tuple                                   //view cart logic
      var cart = _context.Carts.Include(x => x.CartProducts).Where(x => x.UserrId == id).OrderBy(x => x.Id).Last();
      var cartProduct = _context.CartProducts.Include(x => x.Cart).Include(x => x.Product).Where(x => x.Cart.Id == cart.Id).ToList();
      var result = Tuple.Create<IEnumerable<CartProduct>, IEnumerable<Product>>(cartProduct, products);


      return View(result);
    }
    public async Task<IActionResult> Shop()
    {
      //User ID
      var id = HttpContext.Session.GetInt32("Id");

      //for viewing the products on the web
      var products = _context.Products.ToList();
      var cartProduct = _context.CartProducts.Include(x => x.Cart).Include(x => x.Product).Where(x => x.Cart.UserrId == id).ToList();
      var category = _context.Categories.ToList();



      var result = Tuple.Create<IEnumerable<CartProduct>, IEnumerable<Product>, IEnumerable<Category>>(cartProduct, products, category);

      return View(result);
    }
    public async Task<IActionResult> About()
    {


      return View();
    }
    public async Task<IActionResult> Contact()
    {


      return View();
    }
    [HttpGet]
    public async Task<IActionResult> CheckOut()
    {
      var id = HttpContext.Session.GetInt32("Id");
      var cart = _context.Carts.Include(x => x.CartProducts).Where(x => x.UserrId == id).OrderBy(x => x.Id).Last();
      var shoppingCartItems = _context.CartProducts.Include(x => x.Cart).Where(x => x.CartId == cart.Id).ToList();

      return View(shoppingCartItems);
    }
    [HttpPost]
    public async Task<IActionResult> CheckOut([Bind("Id,Name,CvvNumber,CardNumber,Balance,ExpiredDate,UserrId")] PaymentMethod paymentMethod, [Bind("Id,FirstName,LastName,AddressLine1,AddressLine2,City,Country,PhoneNumber,ZipCode,UserrId")] Address address)
    {
      // //User ID
      var id = HttpContext.Session.GetInt32("Id");

      //checkout logic
      //add Address
      address.UserrId = id;
      _context.Add(address);

      //add payment method
      paymentMethod.UserrId = id;
      _context.Add(paymentMethod);

      await _context.SaveChangesAsync();

      var check = _context.PaymentMethods.Include(p => p.Userr).Where(p => p.UserrId == id).FirstOrDefault();

      if (check == null)
      {
        paymentMethod.Balance = 1000;
      }

      var modelContext = _context.Products.ToList();
      int i = 0;
      int sum = 0;
      var cartProduct = _context.CartProducts.Include(x => x.Cart).Include(x => x.Product).Where(x => x.Cart.UserrId == id).ToList();
      var cart = _context.Carts.Where(x => x.UserrId == id).OrderBy(x => x.Id).Last();
      foreach (var item in cartProduct)
      {
        _context.Products.Where(x => x.Id == cartProduct.ElementAt(i).Product.Id).SingleOrDefault().Quantity -= item.Quantity;
        i++;
        sum = (int)item.Quantity * (int)item.Product.Price;
      }

      paymentMethod.Balance -= sum;
      cart.OrderStatus = 1;
      cart.DateOfPruchase = DateTime.Now;

      Cart UserCart = new Cart();
      UserCart.UserrId = id;
      UserCart.OrderStatus = 0;

      _context.Add(UserCart);
      await _context.SaveChangesAsync();

      //for eamil logic
      var context = _context.UserLogins.Include(x => x.Userr).Where(x => x.UserrId == id).SingleOrDefault();
      var email = context.Email;
      var firstname = context.Userr.FirstName;

      SendEmail(email, firstname);



      return RedirectToAction("CustomerIndex");
    }
    public async Task<IActionResult> ProfileDetails()
    {
      var id = HttpContext.Session.GetInt32("Id");
      var user = _context.Userrs.Where(x => x.Id == id).SingleOrDefault();
      var userlogin = _context.UserLogins.Where(x => x.UserrId == id).SingleOrDefault();
      var result = Tuple.Create<Userr, UserLogin>(user, userlogin);

      return View(result);
    }
    public async Task<IActionResult> ProfileOrders()
    {
      var id = HttpContext.Session.GetInt32("Id");
      var order = _context.Carts.Include(x => x.CartProducts).Where(x => x.UserrId == id && x.OrderStatus == 1).ToList();

      //for cart total cost logic

      return View(order);
    }
    public async Task<IActionResult> ProfileAddress()
    {
      var id = HttpContext.Session.GetInt32("Id");
      var address = _context.Addresses.Where(x => x.UserrId == id).FirstOrDefault();

      return View(address);
    }
    public async Task<IActionResult> CategoryPage(decimal? id)
    {
      var products = _context.Products.Where(x => x.CategoryId == id).ToList();
      return View(products);
    }
    [HttpGet]
    public async Task<IActionResult> EditProfile()
    {
      var id = HttpContext.Session.GetInt32("Id");
      var user = _context.Userrs.Where(x => x.Id == id).SingleOrDefault();
      var userlogin = _context.UserLogins.Where(x => x.UserrId == id).SingleOrDefault();

      // var result = Tuple.Create<Userr, UserLogin>(user, userlogin);

      //viewbag
      ViewBag.info = userlogin;




      return View(user);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditProfile([Bind("Id,FirstName,LastName,ImagePath,ImageFile")] Userr userr, String userName, String email)
    {
      var id = HttpContext.Session.GetInt32("Id");

      //for the user
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
      }
      userr.Id = (decimal)id;
      _context.Update(userr);
      await _context.SaveChangesAsync();


      //for the userlogin
      UserLogin obj = _context.UserLogins.Where(x => x.UserrId == id).SingleOrDefault();
      obj.Email = email;
      obj.UserName = userName;

      _context.Update(obj);
      await _context.SaveChangesAsync();


      return RedirectToAction("EditProfile");
    }
    public async Task<IActionResult> ViewOrderDetails(decimal? id)
    {
      var item = _context.CartProducts.Where(x => x.CartId == id).ToList();

      return View(item);
    }
    public async Task<IActionResult> EditPassword()
    {
      return View();
    }
    [HttpPost]
    public async Task<IActionResult> EditPassword(string CurrentPassword, string NewPassword, string NewPassword2)
    {
      //user id
      var id = HttpContext.Session.GetInt32("Id");
      var userAccount = _context.UserLogins.Where(x => x.UserrId == id).SingleOrDefault();

      if (CurrentPassword == userAccount.Passwordd)
      {
        if (NewPassword == NewPassword2)
        {
          userAccount.Passwordd = NewPassword;
          _context.Update(userAccount);
          await _context.SaveChangesAsync();
        }
      }

      return RedirectToAction("EditPassword");
    }
    public void SendEmail(string email, string name)
    {

      MimeMessage message = new MimeMessage();
      MailboxAddress from = new MailboxAddress("Handicraft", "handicraftjordan@gmail.com");

      message.From.Add(from);
      MailboxAddress to = new MailboxAddress(name, email);
      message.To.Add(to);
      message.Subject = "Your order from AVIATO";

      BodyBuilder body = new BodyBuilder();
      body.HtmlBody = "<h1>Your purches report</h1>";
      // body.Attachments.Add(path); add string path to the parameter
      message.Body = body.ToMessageBody();

      using (var clinte = new SmtpClient())
      {
        clinte.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);

        clinte.Authenticate("handicraftjordan@gmail.com", "gajjkjqgfjdkcvol");


        clinte.Send(message);
        clinte.Disconnect(true);
      }
    }
    public async Task<IActionResult> CustomerReview()
    {
      return View();
    }
    [HttpPost]
    public async Task<IActionResult> CustomerReview([Bind("Content")] Testimonial testimonial)
    {
      // //User ID
      var id = HttpContext.Session.GetInt32("Id");
      testimonial.UserId = id;
      testimonial.Status = 0;

      //status
      // 0-> waiting for admin approval
      // 1-> approved
      // 2-> rejected


      //add the data to the database
      _context.Add(testimonial);
      await _context.SaveChangesAsync();

      return View();
    }

  }
}