using AquaProWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaProWeb.Infrastructure.Configurations;

public class FamiliaConcepteFacturaConfiguration : IEntityTypeConfiguration<FamiliaConcepteFactura>
{
    public void Configure(EntityTypeBuilder<FamiliaConcepteFactura> builder)
    {
        builder.Property(p => p.Familia).IsRequired().HasMaxLength(50);
        builder.Property(p => p.Descripcio).HasMaxLength(255);
        builder.Property(p => p.Observacions).HasMaxLength(2000);
    }

}
