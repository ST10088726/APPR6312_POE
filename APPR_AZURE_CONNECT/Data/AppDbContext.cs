using APPR_AZURE_CONNECT.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using APPR_AZURE_CONNECT.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace APPR_AZURE_CONNECT.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options) 
        {          
        }
        public DbSet<LeadEntity1> Donation { get; set; }
        public DbSet<MonetDonateEntity> MonetDonation { get; set; }
        public DbSet<DisastersEntities> Disasters { get; set; }
    }

}
