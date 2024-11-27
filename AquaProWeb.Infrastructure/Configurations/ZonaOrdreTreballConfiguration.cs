using AquaProWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaProWeb.Infrastructure.Configurations;

public class ZonaOrdreTreballConfiguration : IEntityTypeConfiguration<ZonaOrdreTreball>
{
    public void Configure(EntityTypeBuilder<ZonaOrdreTreball> builder)
    {
        builder.Property(p => p.Zona).IsRequired().HasMaxLength(50);
        builder.Property(p => p.Descripcio).HasMaxLength(255);
        builder.Property(p => p.Observacions).HasMaxLength(2000);
    }
}
