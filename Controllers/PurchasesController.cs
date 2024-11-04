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
    public class PurchasesController : Controller
    {
        private readonly TerraCoreDbContext _context;

        public PurchasesController(TerraCoreDbContext context)
        {
            _context = context;
        }

        // GET: Purchases
        public async Task<IActionResult> Index()
        {
            var terraCoreDbContext = _context.Purchases.Include(p => p.ProductNavigation).Include(p => p.StaffNavigation).Include(p => p.WholesellerNavigation);
            return View(await terraCoreDbContext.ToListAsync());
        }

        // GET: Purchases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchase = await _context.Purchases
                .Include(p => p.ProductNavigation)
                .Include(p => p.StaffNavigation)
                .Include(p => p.WholesellerNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (purchase == null)
            {
                return NotFound();
            }

            return View(purchase);
        }

        // GET: Purchases/Create
        public IActionResult Create()
        {
            ViewData["Product"] = new SelectList(_context.Products, "Id", "Id");
            ViewData["Staff"] = new SelectList(_context.Staff, "Id", "Id");
            ViewData["Wholeseller"] = new SelectList(_context.Wholesellers, "Id", "Id");
            return View();
        }

        // POST: Purchases/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Product,SerialNo,Wholeseller,Staff,TimeDate,IsPaid")] Purchase purchase)
        {
            if (ModelState.IsValid)
            {
                _context.Add(purchase);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Product"] = new SelectList(_context.Products, "Id", "Id", purchase.Product);
            ViewData["Staff"] = new SelectList(_context.Staff, "Id", "Id", purchase.Staff);
            ViewData["Wholeseller"] = new SelectList(_context.Wholesellers, "Id", "Id", purchase.Wholeseller);
            return View(purchase);
        }

        // GET: Purchases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchase = await _context.Purchases.FindAsync(id);
            if (purchase == null)
            {
                return NotFound();
            }
            ViewData["Product"] = new SelectList(_context.Products, "Id", "Id", purchase.Product);
            ViewData["Staff"] = new SelectList(_context.Staff, "Id", "Id", purchase.Staff);
            ViewData["Wholeseller"] = new SelectList(_context.Wholesellers, "Id", "Id", purchase.Wholeseller);
            return View(purchase);
        }

        // POST: Purchases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Product,SerialNo,Wholeseller,Staff,TimeDate,IsPaid")] Purchase purchase)
        {
            if (id != purchase.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(purchase);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PurchaseExists(purchase.Id))
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
            ViewData["Product"] = new SelectList(_context.Products, "Id", "Id", purchase.Product);
            ViewData["Staff"] = new SelectList(_context.Staff, "Id", "Id", purchase.Staff);
            ViewData["Wholeseller"] = new SelectList(_context.Wholesellers, "Id", "Id", purchase.Wholeseller);
            return View(purchase);
        }

        // GET: Purchases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchase = await _context.Purchases
                .Include(p => p.ProductNavigation)
                .Include(p => p.StaffNavigation)
                .Include(p => p.WholesellerNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (purchase == null)
            {
                return NotFound();
            }

            return View(purchase);
        }

        // POST: Purchases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var purchase = await _context.Purchases.FindAsync(id);
            if (purchase != null)
            {
                _context.Purchases.Remove(purchase);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PurchaseExists(int id)
        {
            return _context.Purchases.Any(e => e.Id == id);
        }
    }
}
