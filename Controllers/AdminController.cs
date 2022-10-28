using System;
using System.Collections;
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
using MimeKit;

namespace Handicraft_Website.Controllers
{
  public class AdminController : Controller
  {
    private readonly ModelContext _context;

    private readonly IWebHostEnvironment _webHostEnviroment;

    public AdminController(ModelContext context, IWebHostEnvironment webHostEnviroment)
    {
      _context = context;
      _webHostEnviroment = webHostEnviroment;
    }

    public IActionResult Index()
    {
      ViewBag.numberOfCustomers = _context.Userrs.Count();
      ViewBag.numberOfCraftsman = _context.UserLogins.Where(x => x.RoleId == 2).Count();
      ViewBag.numberOfProduct = _context.Products.Count();


      var username = HttpContext.Session.GetInt32("Id");
      var user = _context.UserLogins.Include(x => x.Userr).Where(x => x.Id == username).FirstOrDefault();
      ViewBag.adminInfo = user;

      return View();
    }
    public ActionResult VendorsRegistration()
    {
      var vendorsOnAproval = _context.UserLogins.Include(x => x.Userr).Where(x => x.RoleId == 21).ToList();
      ViewBag.vendorsOnAproval = vendorsOnAproval;
      return View();
    }
    public async Task<IActionResult> sales()
    {
      var modelContext = _context.CartProducts.Include(p => p.Cart).Include(p => p.Product);
      ViewBag.TotalQuantity = modelContext.Sum(x => x.Quantity);



      return View(await modelContext.ToListAsync());

    }
    [HttpPost]
    public async Task<IActionResult> sales(DateTime? startDate, DateTime? endDate)
    {
      var result = _context.CartProducts.Include(p => p.Cart).Include(p => p.Product);


      if (startDate == null && endDate == null)
      {
        ViewBag.TotalQuantity = result.Sum(x => x.Quantity);

        return View(await result.ToListAsync());
      }
      else if (startDate == null && endDate != null)
      {
        var res = await result.Where(x => x.Cart.DateOfPruchase.Value.Date == endDate).ToListAsync();
        ViewBag.TotalQuantity = result.Where(x => x.Cart.DateOfPruchase.Value.Date == endDate).Sum(x => x.Quantity);
        return View(res);
      }

      else if (startDate != null && endDate == null)
      {
        var res = await result.Where(x => x.Cart.DateOfPruchase.Value.Date == startDate).ToListAsync();
        ViewBag.TotalQuantity = result.Where(x => x.Cart.DateOfPruchase.Value.Date == startDate).Sum(x => x.Quantity);
        return View(res);
      }
      else
      {
        var res = await result.Where(x => x.Cart.DateOfPruchase.Value.Date >= startDate && x.Cart.DateOfPruchase.Value.Date <= endDate).ToListAsync();
        ViewBag.TotalQuantity = result.Where(x => x.Cart.DateOfPruchase.Value.Date >= startDate && x.Cart.DateOfPruchase.Value.Date <= endDate).Sum(x => x.Quantity);
        return View(res);
      }
    }
    [HttpPost]
    public async Task<IActionResult> PDF_Report(string month, string year, string yearSelection, string monthSelection)
    {
      var result = _context.CartProducts.Include(p => p.Cart).Include(p => p.Product);

      if (monthSelection != null)
      {
        var res = await result.Where(x => x.Cart.DateOfPruchase.Value.Month == Int16.Parse(month)).ToListAsync();
        ViewBag.TotalQuantity = result.Where(x => x.Cart.DateOfPruchase.Value.Month == Int16.Parse(month)).Sum(x => x.Quantity);
        return View("FinancialReport", res);
      }
      if (yearSelection != null)
      {
        var res = await result.Where(x => x.Cart.DateOfPruchase.Value.Month == Int16.Parse(year)).ToListAsync();
        ViewBag.TotalQuantity = result.Where(x => x.Cart.DateOfPruchase.Value.Month == Int16.Parse(year)).Sum(x => x.Quantity);
        return View("FinancialReport", res);
      }

      return View();
    }
    public IActionResult FinancialReport()
    {


      return View();
    }
    public IActionResult UpdateProfile()
    {
      var username = HttpContext.Session.GetInt32("Id");
      var user = _context.UserLogins.Include(x => x.Userr).Where(x => x.Id == username).FirstOrDefault();
      ViewBag.adminInfo = user;

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
          else
          {
            userr.ImagePath = _context.Userrs.Where(x => x.Id == id).AsNoTracking<Userr>().SingleOrDefault().ImagePath;
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

    public async Task<IActionResult> UpdateRole(decimal id)
    {



      var vendor = _context.UserLogins.Where(x => x.Id == id).Include(x => x.Userr).SingleOrDefault();

      Cart cart = new Cart();
      cart.UserrId = vendor.UserrId;
      cart.OrderStatus = 0;

      _context.Add(cart);
      await _context.SaveChangesAsync();
      vendor.RoleId = 2;
      _context.Update(vendor);
      await _context.SaveChangesAsync();

      var email = vendor.Email;
      var firstname = vendor.Userr.FirstName;

      SendEmail(email, firstname);


      return View("VendorsRegistration");
    }
    public async Task<IActionResult> ReportsAsync()
    {

      return View(await _context.Userrs.ToListAsync());
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
    [HttpGet]
    public async Task<IActionResult> TestimonialRequest()
    {
      var testimonialsRequest = _context.Testimonials.Include(x => x.User).Where(x => x.Status == 0).ToList();
      var testimonals = _context.Testimonials.Include(x => x.User).Where(x => x.Status != 0).ToList();

      var result = Tuple.Create<IEnumerable<Testimonial>, IEnumerable<Testimonial>>(testimonialsRequest, testimonals);

      return View(result);
    }
    public async Task<IActionResult> AcceptTestimonial(decimal? id)
    {
      var testimonal = _context.Testimonials.Where(x => x.Id == id).SingleOrDefault();
      testimonal.Status = 1;

      _context.Update(testimonal);
      await _context.SaveChangesAsync();

      return RedirectToAction("TestimonialRequest", "Admin");
    }
    public async Task<IActionResult> RejectTestimonial(decimal? id)
    {
      var testimonal = _context.Testimonials.Where(x => x.Id == id).SingleOrDefault();
      testimonal.Status = 2;

      _context.Update(testimonal);
      await _context.SaveChangesAsync();


      return RedirectToAction("TestimonialRequest", "Admin");
    }
    public IActionResult AddCategory()
    {
      var category = _context.Categories.ToList();
      ViewBag.Categories = category;
      return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddCategory([Bind("Id,CategoryName,ImagePath,ImageFile")] Category category)
    {
      if (ModelState.IsValid)
      {
        if (category.ImageFile != null)
        {
          string wwwRootPath = _webHostEnviroment.WebRootPath;
          string fileName = Guid.NewGuid().ToString() + "" +
          category.ImageFile.FileName;
          string path = Path.Combine(wwwRootPath + "/Images/", fileName);
          using (var fileStream = new FileStream(path, FileMode.Create))
          {
            await category.ImageFile.CopyToAsync(fileStream);
          }
          category.ImagePath = fileName;

        }
        _context.Add(category);
        await _context.SaveChangesAsync();

      }
      return RedirectToAction("AddCategory", "Admin");
    }
    public IActionResult ManagePages()
    {

      return View();
    }
    [HttpGet]
    public async Task<IActionResult> ManageHome()
    {
      var Images = _context.Images.Where(x=> x.PageId == 1).ToList();

      ViewBag.images = Images;
      return View();
    }
    [HttpPost]
    public async Task<IActionResult> ManageHome(decimal id, [Bind("Id,PageId,ImagePath,ImageFile")] Image image)
    { 
      image.PageId = 1;
      if (image.ImageFile != null)
      {
        string wwwRootPath = _webHostEnviroment.WebRootPath;
        string fileName = Guid.NewGuid().ToString() + "_" +
        image.ImageFile.FileName;
        string path = Path.Combine(wwwRootPath + "/Images/",
        fileName);
        using (var fileStream = new FileStream(path,
        FileMode.Create))
        {
          await image.ImageFile.CopyToAsync(fileStream);
        }
        image.ImagePath = fileName;
      }

      _context.Update(image);
      await _context.SaveChangesAsync();

      return RedirectToAction("ManageHome","Admin");
    }
    public async Task<IActionResult> ManageAboutUs()
    {
      var content = _context.Contents.Include(x => x.Page).ThenInclude(x => x.Images).ToList();

      return View(content);
    }
    [HttpPost]
    public async Task<IActionResult> EditManageAboutUs([Bind("Id,PageId,Content1,Header")] Content content, IFormFile ImageFile)
    {
      _context.Update(content);
      await _context.SaveChangesAsync();

      return RedirectToAction("ManageAboutUs", "Admin");
    }
    public async Task<IActionResult> ManageContactUs()
    {
      var content = _context.Contents.Include(x => x.Page).ThenInclude(x => x.Images).Where(x => x.PageId == 3).ToList();

      return View(content);
    }
    [HttpPost]
    public async Task<IActionResult> ManageContactUs1(string Header1, string Content1, string Header2, string Content2, string Header3, string Content3, decimal id1, decimal id2, decimal id3)
    {
      var content1 = _context.Contents.Where(x => x.Id == id1).SingleOrDefault();
      var content2 = _context.Contents.Where(x => x.Id == id2).SingleOrDefault();
      var content3 = _context.Contents.Where(x => x.Id == id3).SingleOrDefault();

      content1.Header = Header1;
      content1.Content1 = Content1;

      content2.Header = Header2;
      content2.Content1 = Content2;

      content3.Header = Header3;
      content3.Content1 = Content3;

      _context.Update(content1);
      _context.Update(content2);
      _context.Update(content3);
      await _context.SaveChangesAsync();

      return RedirectToAction("ManageContactUs", "Admin");
    }
    [HttpPost]
    public async Task<IActionResult> ManageContactUs2(string Header1, decimal id)
    {
      var content = _context.Contents.Where(x => x.Id == id).SingleOrDefault();
      content.Header = Header1;

      _context.Update(content);
      await _context.SaveChangesAsync();

      return RedirectToAction("ManageContactUs", "Admin");
    }


  }
}