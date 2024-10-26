using CafeMenuApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CafeMenuApp.Persistence.EntityConfiguration;

internal class PropertyConfiguration : IEntityTypeConfiguration<Property>
{
    public void Configure(EntityTypeBuilder<Property> builder)
    {
        builder.ToTable(nameof(Property));
        builder.Property(p => p.Key).IsRequired().HasMaxLength(50);
        builder.Property(p => p.Value).IsRequired().HasMaxLength(50);
    }
}
