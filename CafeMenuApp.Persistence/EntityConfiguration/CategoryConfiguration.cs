using CafeMenuApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CafeMenuApp.Persistence.EntityConfiguration;

internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable(nameof(Category));
        builder.Property(p => p.Name).IsRequired().HasMaxLength(200);
        builder.HasOne(p => p.ParentCategory).WithMany(p => p.SubCategories).HasForeignKey(p => p.ParentCategoryId);
    }
}
