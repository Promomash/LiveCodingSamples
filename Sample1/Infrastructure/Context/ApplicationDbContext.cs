using Microsoft.EntityFrameworkCore;
using Models;

namespace Infrastructure.Context;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Country> Countries { get; set; }
    public DbSet<Province> Provinces { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Country>().HasData([
            new()
            {
                Id = 1,
                Name = "Country 1",
            },
            new()
            {
                Id = 2,
                Name = "Country 2",
            },
        ]);

        modelBuilder.Entity<Province>().HasData([
            new
            {
                Id = 1,
                Name = "Province 2.1",
                CountryId = 2
            },
            new
            {
                Id = 2,
                Name = "Province 2.2",
                CountryId = 2
            },
            new
            {
                Id = 3,
                Name = "Province 2.3",
                CountryId = 2
            },
            new
            {
                Id = 4,
                Name = "Province 1.1",
                CountryId = 1
            },
            new
            {
                Id = 5,
                Name = "Province 1.2",
                CountryId = 1
            },
            new
            {
                Id = 6,
                Name = "Province 1.3",
                CountryId = 1
            },
        ]);
    }
}