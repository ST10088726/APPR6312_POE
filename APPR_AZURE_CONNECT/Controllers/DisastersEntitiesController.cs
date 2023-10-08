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

        // GET: DisastersEntities
        public async Task<IActionResult> Index()
        {
              return _context.Disasters != null ? 
                          View(await _context.Disasters.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.Disasters'  is null.");
        }

        // GET: DisastersEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Disasters == null)
            {
                return NotFound();
            }

            var disastersEntities = await _context.Disasters
                .FirstOrDefaultAsync(m => m.DisId == id);
            if (disastersEntities == null)
            {
                return NotFound();
            }

            return View(disastersEntities);
        }

        // GET: DisastersEntities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DisastersEntities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DisId,StartDate,EndDate,Location,Description,RequiredAidTypes")] DisastersEntities disastersEntities)
        {
            if (ModelState.IsValid)
            {
                _context.Add(disastersEntities);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(disastersEntities);
        }

        // GET: DisastersEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Disasters == null)
            {
                return NotFound();
            }

            var disastersEntities = await _context.Disasters.FindAsync(id);
            if (disastersEntities == null)
            {
                return NotFound();
            }
            return View(disastersEntities);
        }

        // POST: DisastersEntities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DisId,StartDate,EndDate,Location,Description,RequiredAidTypes")] DisastersEntities disastersEntities)
        {
            if (id != disastersEntities.DisId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(disastersEntities);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DisastersEntitiesExists(disastersEntities.DisId))
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
            return View(disastersEntities);
        }

        // GET: DisastersEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Disasters == null)
            {
                return NotFound();
            }

            var disastersEntities = await _context.Disasters
                .FirstOrDefaultAsync(m => m.DisId == id);
            if (disastersEntities == null)
            {
                return NotFound();
            }

            return View(disastersEntities);
        }

        // POST: DisastersEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Disasters == null)
            {
                return Problem("Entity set 'AppDbContext.Disasters'  is null.");
            }
            var disastersEntities = await _context.Disasters.FindAsync(id);
            if (disastersEntities != null)
            {
                _context.Disasters.Remove(disastersEntities);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DisastersEntitiesExists(int id)
        {
          return (_context.Disasters?.Any(e => e.DisId == id)).GetValueOrDefault();
        }
    }
}
