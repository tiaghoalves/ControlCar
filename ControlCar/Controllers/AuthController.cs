using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ControlCar.Models;

namespace ControlCar.Controllers
{
    public class AuthController : Controller
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Auth
        public async Task<IActionResult> Index()
        {
            return View(await _context.Authentication.ToListAsync());
        }

        // GET: Auth/Login
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn([Bind("Email,Password")] Authentication authUser)
        {
            if (string.IsNullOrEmpty(authUser.Email) || string.IsNullOrEmpty(authUser.Password))
            {
                return NotFound();
            }


            var user = await _context.Authentication.FirstOrDefaultAsync(auth => auth.Email == authUser.Email && auth.Password == authUser.Password);

            if (user != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return NotFound();
            }
        }

        // GET: Auth/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authentication = await _context.Authentication
                .FirstOrDefaultAsync(m => m.IdAuthentication == id);
            if (authentication == null)
            {
                return NotFound();
            }

            return View(authentication);
        }

        // GET: Auth/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Auth/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAuthentication,User,Email,Password")] Authentication authentication)
        {
            if (ModelState.IsValid)
            {
                _context.Add(authentication);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(authentication);
        }

        // GET: Auth/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authentication = await _context.Authentication.FindAsync(id);
            if (authentication == null)
            {
                return NotFound();
            }
            return View(authentication);
        }

        // POST: Auth/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAuthentication,User,Email,Password")] Authentication authentication)
        {
            if (id != authentication.IdAuthentication)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(authentication);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuthenticationExists(authentication.IdAuthentication))
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
            return View(authentication);
        }

        // GET: Auth/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authentication = await _context.Authentication
                .FirstOrDefaultAsync(m => m.IdAuthentication == id);
            if (authentication == null)
            {
                return NotFound();
            }

            return View(authentication);
        }

        // POST: Auth/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var authentication = await _context.Authentication.FindAsync(id);
            _context.Authentication.Remove(authentication);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AuthenticationExists(int id)
        {
            return _context.Authentication.Any(e => e.IdAuthentication == id);
        }
    }
}
