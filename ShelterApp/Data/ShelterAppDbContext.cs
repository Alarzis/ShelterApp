using Microsoft.EntityFrameworkCore;
using ShelterApp.Data.Entities;

namespace ShelterApp.Data;

public class ShelterAppDbContext : DbContext
{
    public DbSet<Employee> Employees => Set<Employee>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseInMemoryDatabase("StorageAppDb");
    }
}
