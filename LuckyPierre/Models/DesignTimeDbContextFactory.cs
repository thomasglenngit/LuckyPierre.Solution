using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace LuckyPierre.Models
{
  public class LuckyPierreContextFactory : IDesignTimeDbContextFactory<LuckyPierreContext>
  {
    LuckyPierreContext IDesignTimeDbContextFactory<LuckyPierreContext>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();

      var builder = new DbContextOptionsBuilder<LuckyPierreContext>();
      var connectionString = configuration.GetConnectionString("DefaultConnection");

      builder.UseMySql(connectionString);

      return new LuckyPierreContext(builder.Options);
    }
  }
}