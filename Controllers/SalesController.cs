﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TEST2.Models;

namespace TEST2.Controllers
{
    public class SalesController : Controller
    {
        private readonly TerraCoreDbContext _context;

        public SalesController(TerraCoreDbContext context)
        {
            _context = context;
        }

        // GET: Sales
        public async Task<IActionResult> Index()
        {
            var terraCoreDbContext = _context.Sales.Include(s => s.CustomerNavigation).Include(s => s.ProductNavigation).Include(s => s.StaffNavigation);
            return View(await terraCoreDbContext.ToListAsync());
        }

        // GET: Sales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sale = await _context.Sales
                .Include(s => s.CustomerNavigation)
                .Include(s => s.ProductNavigation)
                .Include(s => s.StaffNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sale == null)
            {
                return NotFound();
            }

            return View(sale);
        }

        // GET: Sales/Create
        public IActionResult Create()
        {
            ViewData["Customer"] = new SelectList(_context.Customers, "Id", "Id");
            ViewData["Product"] = new SelectList(_context.Products, "Id", "Id");
            ViewData["Staff"] = new SelectList(_context.Staff, "Id", "Id");
            return View();
        }

        // POST: Sales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Product,Customer,Staff,TimeDate,IsPaid")] Sale sale)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sale);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Customer"] = new SelectList(_context.Customers, "Id", "Id", sale.Customer);
            ViewData["Product"] = new SelectList(_context.Products, "Id", "Id", sale.Product);
            ViewData["Staff"] = new SelectList(_context.Staff, "Id", "Id", sale.Staff);
            return View(sale);
        }

        // GET: Sales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sale = await _context.Sales.FindAsync(id);
            if (sale == null)
            {
                return NotFound();
            }
            ViewData["Customer"] = new SelectList(_context.Customers, "Id", "Id", sale.Customer);
            ViewData["Product"] = new SelectList(_context.Products, "Id", "Id", sale.Product);
            ViewData["Staff"] = new SelectList(_context.Staff, "Id", "Id", sale.Staff);
            return View(sale);
        }

        // POST: Sales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Product,Customer,Staff,TimeDate,IsPaid")] Sale sale)
        {
            if (id != sale.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sale);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaleExists(sale.Id))
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
            ViewData["Customer"] = new SelectList(_context.Customers, "Id", "Id", sale.Customer);
            ViewData["Product"] = new SelectList(_context.Products, "Id", "Id", sale.Product);
            ViewData["Staff"] = new SelectList(_context.Staff, "Id", "Id", sale.Staff);
            return View(sale);
        }

        // GET: Sales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sale = await _context.Sales
                .Include(s => s.CustomerNavigation)
                .Include(s => s.ProductNavigation)
                .Include(s => s.StaffNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sale == null)
            {
                return NotFound();
            }

            return View(sale);
        }

        // POST: Sales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sale = await _context.Sales.FindAsync(id);
            if (sale != null)
            {
                _context.Sales.Remove(sale);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SaleExists(int id)
        {
            return _context.Sales.Any(e => e.Id == id);
        }
    }
}
