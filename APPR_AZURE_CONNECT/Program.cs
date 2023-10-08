using APPR_AZURE_CONNECT.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using APPR_AZURE_CONNECT.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("APPR_AZURE_CONNECTContextConnection") ?? throw new InvalidOperationException("Connection string 'APPR_AZURE_CONNECTContextConnection' not found.");
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<APPR_AZURE_CONNECTContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDefaultIdentity<APPR_AZURE_CONNECTUser>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<APPR_AZURE_CONNECTContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
