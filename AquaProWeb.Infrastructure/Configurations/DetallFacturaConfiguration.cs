using AquaProWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaProWeb.Infrastructure.Configurations;

public class DetallFacturaConfiguration : IEntityTypeConfiguration<DetallFactura>
{
    public void Configure(EntityTypeBuilder<DetallFactura> builder)
    {
        //builder.Property(p => p.ConcepteFacturaId).IsRequired();
        builder.Property(p => p.Descripcio).IsRequired().HasMaxLength(2000);
        builder.Property(p => p.Quantitat).IsRequired();
        builder.Property(p => p.Preu).IsRequired().HasPrecision(18, 2);
        builder.Property(p => p.Descompte).IsRequired();
        builder.Property(p => p.Taxa).IsRequired();
        builder.Ignore(p => p.BaseImposable);
        builder.Ignore(p => p.ImportDescompte);
        builder.Ignore(p => p.ImportTaxa);
        builder.Ignore(p => p.ImportTotal);
    }
}
