using AquaProWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaProWeb.Infrastructure.Configurations;

public class SituacioFacturaConfiguration : IEntityTypeConfiguration<SituacioFactura>
{
    public void Configure(EntityTypeBuilder<SituacioFactura> builder)
    {
        builder.Property(p => p.Estat).IsRequired();
        builder.Property(p => p.Situacio).IsRequired().HasMaxLength(50);
        builder.Property(p => p.Descripcio).HasMaxLength(255);
        builder.Property(p => p.Observacions).HasMaxLength(2000);
    }
}
