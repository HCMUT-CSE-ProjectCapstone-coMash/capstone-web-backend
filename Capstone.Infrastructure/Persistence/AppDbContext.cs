using Microsoft.EntityFrameworkCore;
using Capstone.Domain.Entities;

namespace Capstone.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users => Set<User>();
    public DbSet<Product> Products => Set<Product>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().ToTable("users");
        modelBuilder.Entity<Product>().ToTable("products");
    }
}
