using AquaProWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaProWeb.Infrastructure.Configurations;

public class ZonaUbicacionsConfiguration : IEntityTypeConfiguration<ZonaUbicacions>
{
    public void Configure(EntityTypeBuilder<ZonaUbicacions> builder)
    {
        builder.Property(p => p.Zona).IsRequired().HasMaxLength(50);
        builder.Property(p => p.Descripcio).HasMaxLength(255);
        builder.Property(p => p.Observacions).HasMaxLength(2000);
    }
}
