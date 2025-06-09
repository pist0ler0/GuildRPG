using GuildRPG.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using GuildRPG.Data;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<GuildRPGContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("GuildRPGContext") ?? throw new InvalidOperationException("Connection string 'GuildRPGContext' not found.")));
builder.Services.AddDbContext<GuildRPGIdentityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("GuildRPGIdentityContextConnection")));

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
.AddEntityFrameworkStores<GuildRPGIdentityContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<GuildService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
