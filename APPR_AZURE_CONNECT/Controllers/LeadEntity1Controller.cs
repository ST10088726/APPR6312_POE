using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using APPR_AZURE_CONNECT.Data;
using APPR_AZURE_CONNECT.Models;

namespace APPR_AZURE_CONNECT.Controllers
{
    public class LeadEntity1Controller : Controller
    {
        private readonly AppDbContext _context;

        public LeadEntity1Controller(AppDbContext context)
        {
            _context = context;
        }

        // GET: LeadEntity1
        public async Task<IActionResult> Index()
        {
              return _context.Donation != null ? 
                          View(await _context.Donation.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.Donation'  is null.");
        }

        // GET: LeadEntity1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Donation == null)
            {
                return NotFound();
            }

            var leadEntity1 = await _context.Donation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leadEntity1 == null)
            {
                return NotFound();
            }

            return View(leadEntity1);
        }

        // GET: LeadEntity1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LeadEntity1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DonateDate,DonateName,Item,Category,Description")] LeadEntity1 leadEntity1)
        {
            if (ModelState.IsValid)
            {
                _context.Add(leadEntity1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(leadEntity1);
        }

        // GET: LeadEntity1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Donation == null)
            {
                return NotFound();
            }

            var leadEntity1 = await _context.Donation.FindAsync(id);
            if (leadEntity1 == null)
            {
                return NotFound();
            }
            return View(leadEntity1);
        }

        // POST: LeadEntity1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DonateDate,DonateName,Item,Category,Description")] LeadEntity1 leadEntity1)
        {
            if (id != leadEntity1.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(leadEntity1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeadEntity1Exists(leadEntity1.Id))
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
            return View(leadEntity1);
        }

        // GET: LeadEntity1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Donation == null)
            {
                return NotFound();
            }

            var leadEntity1 = await _context.Donation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leadEntity1 == null)
            {
                return NotFound();
            }

            return View(leadEntity1);
        }

        // POST: LeadEntity1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Donation == null)
            {
                return Problem("Entity set 'AppDbContext.Donation'  is null.");
            }
            var leadEntity1 = await _context.Donation.FindAsync(id);
            if (leadEntity1 != null)
            {
                _context.Donation.Remove(leadEntity1);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeadEntity1Exists(int id)
        {
          return (_context.Donation?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
