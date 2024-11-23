using BaseBackend.Core.Models;
using BaseBackend.Persistence.Postgres.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseBackend.Persistence.Postgres.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<ProductEntity>
{
    public void Configure(EntityTypeBuilder<ProductEntity> builder)
    {
        builder.HasKey(p => p.Id);
        
        builder.Property(p => p.Name)
            .HasMaxLength(Product.MAX_NAME_LENGTH)
            .IsRequired();
        
        builder.HasOne(u => u.Category)
            .WithMany(p => p.Products);
    }
}