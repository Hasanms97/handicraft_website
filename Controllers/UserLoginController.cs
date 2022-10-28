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
    public class UserLoginController : Controller
    {
        private readonly ModelContext _context;

        public UserLoginController(ModelContext context)
        {
            _context = context;
        }

        // GET: UserLogin
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.UserLogins.Include(u => u.Role).Include(u => u.Userr);
            return View(await modelContext.ToListAsync());
        }

        // GET: UserLogin/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userLogin = await _context.UserLogins
                .Include(u => u.Role)
                .Include(u => u.Userr)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userLogin == null)
            {
                return NotFound();
            }

            return View(userLogin);
        }

        // GET: UserLogin/Create
        public IActionResult Create()
        {
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Id");
            ViewData["UserrId"] = new SelectList(_context.Userrs, "Id", "Id");
            return View();
        }

        // POST: UserLogin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserName,Passwordd,Email,RoleId,UserrId")] UserLogin userLogin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userLogin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Id", userLogin.RoleId);
            ViewData["UserrId"] = new SelectList(_context.Userrs, "Id", "Id", userLogin.UserrId);
            return View(userLogin);
        }

        // GET: UserLogin/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userLogin = await _context.UserLogins.FindAsync(id);
            if (userLogin == null)
            {
                return NotFound();
            }
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Id", userLogin.RoleId);
            ViewData["UserrId"] = new SelectList(_context.Userrs, "Id", "Id", userLogin.UserrId);
            return View(userLogin);
        }

        // POST: UserLogin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Id,UserName,Passwordd,Email,RoleId,UserrId")] UserLogin userLogin)
        {
            if (id != userLogin.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userLogin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserLoginExists(userLogin.Id))
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
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Id", userLogin.RoleId);
            ViewData["UserrId"] = new SelectList(_context.Userrs, "Id", "Id", userLogin.UserrId);
            return View(userLogin);
        }

        // GET: UserLogin/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userLogin = await _context.UserLogins
                .Include(u => u.Role)
                .Include(u => u.Userr)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userLogin == null)
            {
                return NotFound();
            }

            return View(userLogin);
        }

        // POST: UserLogin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var userLogin = await _context.UserLogins.FindAsync(id);
            _context.UserLogins.Remove(userLogin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserLoginExists(decimal id)
        {
            return _context.UserLogins.Any(e => e.Id == id);
        }
    }
}
