using Again2.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Again2.Context;

public class ProniaDbContext : IdentityDbContext<AppUser>
{
    public ProniaDbContext(DbContextOptions<ProniaDbContext> options) : base(options)
    {
    }

    public DbSet<Shipping> Shippings { get; set; }
    public DbSet<Slider> Sliders { get; set; }

}
