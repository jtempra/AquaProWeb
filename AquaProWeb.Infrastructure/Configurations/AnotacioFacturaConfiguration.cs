using AquaProWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaProWeb.Infrastructure.Configurations;
public class AnotacioFacturaConfiguration : IEntityTypeConfiguration<AnotacioFactura>
{
    public void Configure(EntityTypeBuilder<AnotacioFactura> builder)
    {
        builder.Property(p => p.Descripcio).IsRequired().HasMaxLength(255);
        builder.Property(p => p.Data).IsRequired();
        builder.Property(p => p.Observacions).HasMaxLength(1000);
    }
}
