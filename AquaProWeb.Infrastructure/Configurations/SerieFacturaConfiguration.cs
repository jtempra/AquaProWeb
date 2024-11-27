using AquaProWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaProWeb.Infrastructure.Configurations;

public class SerieFacturaConfiguration : IEntityTypeConfiguration<SerieFactura>
{
    public void Configure(EntityTypeBuilder<SerieFactura> builder)
    {
        builder.Property(p => p.Serie).IsRequired().HasMaxLength(25);
        builder.Property(p => p.Comptador).IsRequired();
        builder.Property(p => p.Prefix).HasMaxLength(12);
        builder.Property(p => p.Postfix).HasMaxLength(12);
        builder.Property(p => p.Descripcio).HasMaxLength(255);
        builder.Property(p => p.Observacions).HasMaxLength(2000);
    }
}
