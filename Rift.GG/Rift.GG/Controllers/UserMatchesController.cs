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
    public class UserMatchesController : Controller
    {
        private readonly MyAppContext _context;

        public UserMatchesController(MyAppContext context)
        {
            _context = context;
        }

        // GET: UserMatches
        public async Task<IActionResult> Index()
        {
            var myAppContext = _context.UserMatches.Include(u => u.Match).Include(u => u.User);
            return View(await myAppContext.ToListAsync());
        }

        // GET: UserMatches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userMatch = await _context.UserMatches
                .Include(u => u.Match)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (userMatch == null)
            {
                return NotFound();
            }

            return View(userMatch);
        }

        // GET: UserMatches/Create
        public IActionResult Create()
        {
            ViewData["MatchId"] = new SelectList(_context.Matches, "MatchId", "MatchId");
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId");
            return View();
        }

        // POST: UserMatches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserMatchId,UserId,MatchId")] UserMatch userMatch)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userMatch);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MatchId"] = new SelectList(_context.Matches, "MatchId", "MatchId", userMatch.MatchId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", userMatch.UserId);
            return View(userMatch);
        }

        // GET: UserMatches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userMatch = await _context.UserMatches.FindAsync(id);
            if (userMatch == null)
            {
                return NotFound();
            }
            ViewData["MatchId"] = new SelectList(_context.Matches, "MatchId", "MatchId", userMatch.MatchId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", userMatch.UserId);
            return View(userMatch);
        }

        // POST: UserMatches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserMatchId,UserId,MatchId")] UserMatch userMatch)
        {
            if (id != userMatch.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userMatch);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserMatchExists(userMatch.UserId))
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
            ViewData["MatchId"] = new SelectList(_context.Matches, "MatchId", "MatchId", userMatch.MatchId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", userMatch.UserId);
            return View(userMatch);
        }

        // GET: UserMatches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userMatch = await _context.UserMatches
                .Include(u => u.Match)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (userMatch == null)
            {
                return NotFound();
            }

            return View(userMatch);
        }

        // POST: UserMatches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userMatch = await _context.UserMatches.FindAsync(id);
            if (userMatch != null)
            {
                _context.UserMatches.Remove(userMatch);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserMatchExists(int id)
        {
            return _context.UserMatches.Any(e => e.UserId == id);
        }
    }
}
