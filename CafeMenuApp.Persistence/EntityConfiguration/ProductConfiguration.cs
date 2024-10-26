using CafeMenuApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CafeMenuApp.Persistence.EntityConfiguration;

internal class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable(nameof(Product));
        builder.Property(p => p.Name).IsRequired().HasMaxLength(200);
        builder.Property(p => p.ImagePath).IsRequired(false).HasMaxLength(500);
    }
}
