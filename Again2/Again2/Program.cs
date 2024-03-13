using Again2.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ProniaDbContext>(options =>
{
    options.UseSqlServer("name=ConnectionStrings:default");
});

var app = builder.Build();

app.UseStaticFiles();
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
    );
app.MapControllerRoute(
    name:"default",
    pattern:"{controller=home}/{action=Index}/{id?}"
    
    );

app.Run();

