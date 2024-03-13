using Again2.Models;
using Microsoft.EntityFrameworkCore;

namespace Again2.Context;

public class ProniaDbContext : DbContext
{
    public ProniaDbContext(DbContextOptions<ProniaDbContext> options) : base(options)
    {
    }

    public DbSet<Shipping> Shippings { get; set; }
    public DbSet<Slider> Sliders { get; set; }

}
