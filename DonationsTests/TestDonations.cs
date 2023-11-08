using APPR_AZURE_CONNECT.Controllers.Disaster;
using APPR_AZURE_CONNECT.Controllers.Entity;
using APPR_AZURE_CONNECT.Controllers.Home;
using APPR_AZURE_CONNECT.Controllers.MonetDonation;
using APPR_AZURE_CONNECT.Data;
using APPR_AZURE_CONNECT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DonationsTests
{
    [TestClass]
    public class TestDonations
    {
        private readonly AppDbContext _context;
        [TestMethod]
        public async Task Create_WhenValueISupplied_ShouldDealWithExceptions(int id)
        {
            if (_context.Disasters == null)
            {
                Problem("Entity set 'AppDbContext.Disasters'  is null.");
            }
            //Could not think of any code to test as its tr
            var disastersEntites = await _context.Disasters.FindAsync(id);
            if (disastersEntites != null)
            {
                _context.Disasters.Remove(disastersEntites);
            }
        }

        private void Problem(string v)
        {
            throw new NotImplementedException();
        }

        public async Task<IActionResult> MethodToCheckIfDeleteWentThrough(int? id)
        {
            if (id == null || _context.Disasters == null)
            {
                NotFoundResult();
            }

            var disastersEntites = await _context.Disasters
                .FirstOrDefaultAsync(m => m.DisId == id);
            if (disastersEntites == null)
            {
                NotFoundResult();
            }

            return (IActionResult)disastersEntites;
        }

        private void NotFoundResult()
        {
            throw new NotImplementedException();
        }
        

        private void RedirectToActionResult(string v)
        {
            throw new NotImplementedException();
        }
    }
           
          
}
            
          
               
                
            
        
    
