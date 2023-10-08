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
    public class MonetDonateEntitiesController : Controller
    {
        private readonly AppDbContext _context;

        public MonetDonateEntitiesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: MonetDonateEntities
        public async Task<IActionResult> Index()
        {
              return _context.MonetDonation != null ? 
                          View(await _context.MonetDonation.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.MonetDonation'  is null.");
        }

        // GET: MonetDonateEntities/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.MonetDonation == null)
            {
                return NotFound();
            }

            var monetDonateEntity = await _context.MonetDonation
                .FirstOrDefaultAsync(m => m.DonatorsName == id);
            if (monetDonateEntity == null)
            {
                return NotFound();
            }

            return View(monetDonateEntity);
        }

        // GET: MonetDonateEntities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MonetDonateEntities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DonatorsName,DonationDate,Amount")] MonetDonateEntity monetDonateEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(monetDonateEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(monetDonateEntity);
        }

        // GET: MonetDonateEntities/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.MonetDonation == null)
            {
                return NotFound();
            }

            var monetDonateEntity = await _context.MonetDonation.FindAsync(id);
            if (monetDonateEntity == null)
            {
                return NotFound();
            }
            return View(monetDonateEntity);
        }

        // POST: MonetDonateEntities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("DonatorsName,DonationDate,Amount")] MonetDonateEntity monetDonateEntity)
        {
            if (id != monetDonateEntity.DonatorsName)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(monetDonateEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MonetDonateEntityExists(monetDonateEntity.DonatorsName))
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
            return View(monetDonateEntity);
        }

        // GET: MonetDonateEntities/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.MonetDonation == null)
            {
                return NotFound();
            }

            var monetDonateEntity = await _context.MonetDonation
                .FirstOrDefaultAsync(m => m.DonatorsName == id);
            if (monetDonateEntity == null)
            {
                return NotFound();
            }

            return View(monetDonateEntity);
        }

        // POST: MonetDonateEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.MonetDonation == null)
            {
                return Problem("Entity set 'AppDbContext.MonetDonation'  is null.");
            }
            var monetDonateEntity = await _context.MonetDonation.FindAsync(id);
            if (monetDonateEntity != null)
            {
                _context.MonetDonation.Remove(monetDonateEntity);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MonetDonateEntityExists(string id)
        {
          return (_context.MonetDonation?.Any(e => e.DonatorsName == id)).GetValueOrDefault();
        }
    }
}
