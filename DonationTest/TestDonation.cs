using APPR_AZURE_CONNECT.Data;
using APPR_AZURE_CONNECT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DonationTest
{
    [TestClass]
    public class TestDonation
    {
        private readonly AppDbContext _context;
        [TestMethod]
        public async Task<IActionResult> CheckingBefireDeletion(int? id)
        {
            if (id == null || _context.Disasters == null)
            {
                return NotFoundResult();
            }

            var disastersEntites = await _context.Disasters
                .FirstOrDefaultAsync(m => m.DisId == id);
            if (disastersEntites == null)
            {
                return NotFoundResult();
            }

            return (IActionResult)disastersEntites;
        }

        private IActionResult NotFoundResult()
        {
            throw new NotImplementedException();
        }
        public async Task<IActionResult> ChecjIfDeleteIsConfirmed(int id)
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

        private IActionResult Problem(string v)
        {
            throw new NotImplementedException();
        }

        private IActionResult RedirectToAction(string v)
        {
            throw new NotImplementedException();
        }
        //Same Logic with the other entities is tested by these same methods as they are all based on the same logic as well as the way they are called
        private bool CheckingExistanceOfDisaterEntityExists(int id)
        {
            return (_context.Disasters?.Any(e => e.DisId == id)).GetValueOrDefault();
        }
        public async Task<IActionResult> CreationOfMainPageWithexceptionToDealWithIfPageIsNotFound()
        {
            return _context.MonetDonation != null ?
                        ViewResult(await _context.MonetDonation.ToListAsync()) :
                        Problem("Entity set 'AppDbContext.MonetDonation'  is null.");
        }

        private IActionResult ViewResult(List<MonetDonateEntity> monetDonateEntities)
        {
            throw new NotImplementedException();
        }
    }
}