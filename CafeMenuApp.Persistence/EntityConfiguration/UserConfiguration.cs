using CafeMenuApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CafeMenuApp.Persistence.EntityConfiguration;

internal class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(nameof(User));
        builder.Property(p => p.Name).IsRequired().HasMaxLength(30);
        builder.Property(p => p.SurName).IsRequired().HasMaxLength(50);
        builder.Property(p => p.HasPassword).IsRequired(false);
        builder.Property(p => p.SaltPassword).IsRequired(false);
    }
}
