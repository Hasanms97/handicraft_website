using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Handicraft_Website.Models;

namespace Handicraft_Website.Controllers
{
    public class CartProductController : Controller
    {
        private readonly ModelContext _context;

        public CartProductController(ModelContext context)
        {
            _context = context;
        }

        // GET: CartProduct
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.CartProducts.Include(c => c.Cart).Include(c => c.Product);
            return View(await modelContext.ToListAsync());
        }

        // GET: CartProduct/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartProduct = await _context.CartProducts
                .Include(c => c.Cart)
                .Include(c => c.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cartProduct == null)
            {
                return NotFound();
            }

            return View(cartProduct);
        }

        // GET: CartProduct/Create
        public IActionResult Create()
        {
            ViewData["CartId"] = new SelectList(_context.Carts, "Id", "Id");
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id");
            return View();
        }

        // POST: CartProduct/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductId,CartId,Quantity")] CartProduct cartProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cartProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CartId"] = new SelectList(_context.Carts, "Id", "Id", cartProduct.CartId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", cartProduct.ProductId);
            return View(cartProduct);
        }

        // GET: CartProduct/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartProduct = await _context.CartProducts.FindAsync(id);
            if (cartProduct == null)
            {
                return NotFound();
            }
            ViewData["CartId"] = new SelectList(_context.Carts, "Id", "Id", cartProduct.CartId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", cartProduct.ProductId);
            return View(cartProduct);
        }

        // POST: CartProduct/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Id,ProductId,CartId,Quantity")] CartProduct cartProduct)
        {
            if (id != cartProduct.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cartProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartProductExists(cartProduct.Id))
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
            ViewData["CartId"] = new SelectList(_context.Carts, "Id", "Id", cartProduct.CartId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", cartProduct.ProductId);
            return View(cartProduct);
        }

        // GET: CartProduct/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartProduct = await _context.CartProducts
                .Include(c => c.Cart)
                .Include(c => c.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cartProduct == null)
            {
                return NotFound();
            }

            return View(cartProduct);
        }

        // POST: CartProduct/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var cartProduct = await _context.CartProducts.FindAsync(id);
            _context.CartProducts.Remove(cartProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CartProductExists(decimal id)
        {
            return _context.CartProducts.Any(e => e.Id == id);
        }
    }
}
