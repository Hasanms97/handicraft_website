using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Handicraft_Website.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace Handicraft_Website.Controllers
{
  public class BaseController : Controller
  {
    private readonly ModelContext _context;
    public BaseController(ModelContext context)
    {
      _context = context;
    }
    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
      //User ID
      var id = HttpContext.Session.GetInt32("Id");

      // for viewing the products on the web
      var products = _context.Products.ToList();
      var cart = _context.Carts.Include(x => x.CartProducts).Where(x => x.UserrId == id).OrderBy(x => x.Id).Last();
      var cartproduct = _context.CartProducts.Include(x => x.Cart).Include(x => x.Product).Where(x => x.CartId == cart.Id).ToList();

      //for the number of items in the cart      
      var numberOfItem = _context.CartProducts.Where(x => x.CartId == cart.Id).Count();
      ViewBag.numberOfItem = numberOfItem;

      //for Tuple
      var result = Tuple.Create<IEnumerable<CartProduct>, IEnumerable<Product>>(cartproduct, products);

      ViewBag.temp = result;
    }

  }


}