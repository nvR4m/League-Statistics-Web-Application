using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Rift.GG.Data;
using Rift.GG.Models;

namespace Rift.GG.Controllers
{
    public class UserStatsController : Controller
    {
        private readonly MyAppContext _context;

        public UserStatsController(MyAppContext context)
        {
            _context = context;
        }

        // GET: UserStats
        public async Task<IActionResult> Index()
        {
            var myAppContext = _context.UserStats.Include(u => u.User);
            return View(await myAppContext.ToListAsync());
        }

        // GET: UserStats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userStats = await _context.UserStats
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (userStats == null)
            {
                return NotFound();
            }

            return View(userStats);
        }

        // GET: UserStats/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId");
            return View();
        }

        // POST: UserStats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,Wins,Losses,Rank")] UserStats userStats)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userStats);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", userStats.UserId);
            return View(userStats);
        }

        // GET: UserStats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userStats = await _context.UserStats.FindAsync(id);
            if (userStats == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", userStats.UserId);
            return View(userStats);
        }

        // POST: UserStats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,Wins,Losses,Rank")] UserStats userStats)
        {
            if (id != userStats.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userStats);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserStatsExists(userStats.UserId))
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
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", userStats.UserId);
            return View(userStats);
        }

        // GET: UserStats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userStats = await _context.UserStats
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (userStats == null)
            {
                return NotFound();
            }

            return View(userStats);
        }

        // POST: UserStats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userStats = await _context.UserStats.FindAsync(id);
            if (userStats != null)
            {
                _context.UserStats.Remove(userStats);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserStatsExists(int id)
        {
            return _context.UserStats.Any(e => e.UserId == id);
        }
    }
}
