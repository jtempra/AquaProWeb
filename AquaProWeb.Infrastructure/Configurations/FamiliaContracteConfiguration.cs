using AquaProWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaProWeb.Infrastructure.Configurations;

public class FamiliaContracteConfiguration : IEntityTypeConfiguration<FamiliaContracte>
{
    public void Configure(EntityTypeBuilder<FamiliaContracte> builder)
    {
        builder.Property(p => p.Codi).IsRequired().HasMaxLength(25);
        builder.Property(p => p.Familia).IsRequired().HasMaxLength(100);
        builder.Property(p => p.Descripcio).IsRequired().HasMaxLength(255);
    }
}
