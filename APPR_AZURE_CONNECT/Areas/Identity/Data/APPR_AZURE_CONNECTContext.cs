using APPR_AZURE_CONNECT.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using APPR_AZURE_CONNECT.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace APPR_AZURE_CONNECT.Areas.Identity.Data
{
    public class APPR_AZURE_CONNECTContext : IdentityDbContext<APPR_AZURE_CONNECTUser>
    {
        public APPR_AZURE_CONNECTContext(DbContextOptions<APPR_AZURE_CONNECTContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
