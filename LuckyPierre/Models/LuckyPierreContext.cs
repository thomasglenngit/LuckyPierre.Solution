using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace LuckyPierre.Models
{
  public class LuckyPierreContext : IdentityDbContext<ApplicationUser>
  {
    public DbSet<Flavor> Flavors { get; set; }
    public DbSet<Treat> Treats { get; set; }
    public DbSet<TreatFlavor> TreatFlavors { get; set; } 
    public LuckyPierreContext(DbContextOptions options) : base(options) { }
  }
}