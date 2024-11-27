using AquaProWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaProWeb.Infrastructure.Configurations;

public class RutaLecturaConfiguration : IEntityTypeConfiguration<RutaLectura>
{
    public void Configure(EntityTypeBuilder<RutaLectura> builder)
    {
        builder.Property(p => p.Ruta).IsRequired().HasMaxLength(50);
        builder.Property(p => p.Descripcio).HasMaxLength(255);
        builder.Property(p => p.Observacions).HasMaxLength(2000);
    }
}
