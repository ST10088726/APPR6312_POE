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
    public class DisastersEntitiesController : Controller
    {
        private readonly AppDbContext _context;

        public DisastersEntitiesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: DisastersEntites
        public async Task<IActionResult> Index()
        {
              return _context.Disasters != null ? 
                          View(await _context.Disasters.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.Disasters'  is null.");
        }

        // GET: DisastersEntites/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Disasters == null)
            {
                return NotFound();
            }

            var disastersEntites = await _context.Disasters
                .FirstOrDefaultAsync(m => m.DisId == id);
            if (disastersEntites == null)
            {
                return NotFound();
            }

            return View(disastersEntites);
        }

        // GET: DisastersEntites/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DisastersEntites/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DisId,StartDate,EndDate,Location,Description,RequiredAidTypes,AllocateGoods,AllocateMoney,AllocatedMoneyLeft")] DisastersEntities disastersEntites)
        {
            if (ModelState.IsValid)
            {
                _context.Add(disastersEntites);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(disastersEntites);
        }

        // GET: DisastersEntites/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Disasters == null)
            {
                return NotFound();
            }

            var disastersEntites = await _context.Disasters.FindAsync(id);
            if (disastersEntites == null)
            {
                return NotFound();
            }
            return View(disastersEntites);
        }

        // POST: DisastersEntites/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DisId,StartDate,EndDate,Location,Description,RequiredAidTypes,AllocateGoods,AllocateMoney,AllocatedMoneyLeft")] DisastersEntities disastersEntites)
        {
            if (id != disastersEntites.DisId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(disastersEntites);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DisastersEntitesExists(disastersEntites.DisId))
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
            return View(disastersEntites);
        }

        // GET: DisastersEntites/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Disasters == null)
            {
                return NotFound();
            }

            var disastersEntites = await _context.Disasters
                .FirstOrDefaultAsync(m => m.DisId == id);
            if (disastersEntites == null)
            {
                return NotFound();
            }

            return View(disastersEntites);
        }

        // POST: DisastersEntites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Disasters == null)
            {
                return Problem("Entity set 'AppDbContext.Disasters'  is null.");
            }
            var disastersEntites = await _context.Disasters.FindAsync(id);
            if (disastersEntites != null)
            {
                _context.Disasters.Remove(disastersEntites);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DisastersEntitesExists(int id)
        {
          return (_context.Disasters?.Any(e => e.DisId == id)).GetValueOrDefault();
        }
    }
}
