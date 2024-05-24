using Microsoft.EntityFrameworkCore;
using SuperApp.Domain.SuperHeroes;
using SuperApp.Domain.User;

namespace SuperApp.Repository.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<SuperHero> SuperHeroes { get; set; }
    
    public DbSet<User> Users { get; set; }
}