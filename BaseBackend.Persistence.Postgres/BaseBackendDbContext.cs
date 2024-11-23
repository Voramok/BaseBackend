using BaseBackend.Core.Models;
using BaseBackend.Persistence.Postgres.Configurations;
using BaseBackend.Persistence.Postgres.Entities;
using Microsoft.EntityFrameworkCore;

namespace BaseBackend.Persistence.Postgres;

public class BaseBackendDbContext : DbContext
{
    public BaseBackendDbContext(DbContextOptions<BaseBackendDbContext> options) 
        : base(options)
    {
        
    }
    
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<CategoryEntity> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }
}