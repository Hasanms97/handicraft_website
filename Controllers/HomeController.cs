using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Handicraft_Website.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace Handicraft_Website.Controllers
{
  public class HomeController : Controller
  {
    private readonly ILogger<HomeController> _logger;
    private readonly ModelContext _context;

    public HomeController(ILogger<HomeController> logger, ModelContext context)
    {
      _logger = logger;
      _context = context;
    }
    public IActionResult Index()
    {
      var products = _context.Products.ToList();
      return View(products);
    }
  }
}