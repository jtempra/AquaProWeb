using AquaProWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaProWeb.Infrastructure.Configurations;

public class ConcepteFacturaConfiguration : IEntityTypeConfiguration<ConcepteFactura>
{
    public void Configure(EntityTypeBuilder<ConcepteFactura> builder)
    {
        builder.Property(p => p.Codi).IsRequired().HasMaxLength(12);
        builder.Property(p => p.Descripcio).HasMaxLength(255);
        builder.Property(p => p.Observacions).HasMaxLength(2000);
        builder.Property(p => p.PVP).IsRequired().HasPrecision(18, 2);
        builder.Property(p => p.PreuCompra).IsRequired().HasPrecision(18, 2);
        builder.Property(p => p.PreuTarifa).IsRequired().HasPrecision(18, 2);
        builder.Property(p => p.PreuUltimaCompra).IsRequired().HasPrecision(18, 2);
        builder.Property(p => p.Estoc).IsRequired();
        builder.Property(p => p.EstocMinim).IsRequired();
        builder.Property(p => p.CodiComptable).HasMaxLength(25);
        builder.Property(p => p.Emmagatzemable).IsRequired();
    }
}
