using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TEST2.Models;

namespace TEST2.Controllers
{
    public class WholesellersController : Controller
    {
        private readonly TerraCoreDbContext _context;

        public WholesellersController(TerraCoreDbContext context)
        {
            _context = context;
        }

        // GET: Wholesellers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Wholesellers.ToListAsync());
        }

        // GET: Wholesellers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wholeseller = await _context.Wholesellers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (wholeseller == null)
            {
                return NotFound();
            }

            return View(wholeseller);
        }

        // GET: Wholesellers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Wholesellers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Address,PostCode,Town,Bank,SortCode,AccountNumber")] Wholeseller wholeseller)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wholeseller);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(wholeseller);
        }

        // GET: Wholesellers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wholeseller = await _context.Wholesellers.FindAsync(id);
            if (wholeseller == null)
            {
                return NotFound();
            }
            return View(wholeseller);
        }

        // POST: Wholesellers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Address,PostCode,Town,Bank,SortCode,AccountNumber")] Wholeseller wholeseller)
        {
            if (id != wholeseller.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wholeseller);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WholesellerExists(wholeseller.Id))
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
            return View(wholeseller);
        }

        // GET: Wholesellers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wholeseller = await _context.Wholesellers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (wholeseller == null)
            {
                return NotFound();
            }

            return View(wholeseller);
        }

        // POST: Wholesellers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var wholeseller = await _context.Wholesellers.FindAsync(id);
            if (wholeseller != null)
            {
                _context.Wholesellers.Remove(wholeseller);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WholesellerExists(int id)
        {
            return _context.Wholesellers.Any(e => e.Id == id);
        }
    }
}
