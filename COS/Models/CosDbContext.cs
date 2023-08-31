using Microsoft.EntityFrameworkCore;

namespace COS.Models;

public class CosDbContext : DbContext
{
    public CosDbContext(DbContextOptions<CosDbContext> options) : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Dinner> DinnerOptions { get; set; }
}