using AquaProWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaProWeb.Infrastructure.Configurations;

public class UsContracteConfiguration : IEntityTypeConfiguration<UsContracte>
{
    public void Configure(EntityTypeBuilder<UsContracte> builder)
    {
        builder.Property(p => p.Codi).IsRequired().HasMaxLength(12);
        builder.Property(p => p.Us).IsRequired().HasMaxLength(50);
        builder.Property(p => p.Descripcio).HasMaxLength(255);
        builder.Property(p => p.Observacions).HasMaxLength(2000);
    }
}
