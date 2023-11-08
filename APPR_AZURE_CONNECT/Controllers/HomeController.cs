using APPR_AZURE_CONNECT.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using APPR_AZURE_CONNECT.Data;
using APPR_AZURE_CONNECT.Models;
using Microsoft.EntityFrameworkCore;

namespace APPR_AZURE_CONNECT.Controllers.Home
{
    public class HomeController : Controller
    {
        
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            return _context.Disasters != null ?
                         View(await _context.Disasters.ToListAsync()) :
                         Problem("Entity set 'AppDbContext.Disasters'  is null.");
        }
      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}