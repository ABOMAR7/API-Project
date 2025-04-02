using App_Store.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace App_Store.Api.Data;

public class AppsStoreContext(DbContextOptions<AppsStoreContext> options) : DbContext(options)
{
    public DbSet<Apps> Apps => Set<Apps>();
    public DbSet<Genres> Genres => Set<Genres>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genres>().HasData(
            new { Id = 1, Name = "Educational" },
            new { Id = 2, Name = "Design" },
            new { Id = 3, Name = "Social Media" },
            new { Id = 4, Name = "Religious" },
            new { Id = 5, Name = "Innovations" }
        );
    }
}
