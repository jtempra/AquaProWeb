using AquaProWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaProWeb.Infrastructure.Configurations;

public class TarifaServeiConfiguration : IEntityTypeConfiguration<TarifaServei>
{
    public void Configure(EntityTypeBuilder<TarifaServei> builder)
    {
        builder.Property(p => p.Tarifa).IsRequired().HasMaxLength(50);
        builder.Property(p => p.Descripcio).HasMaxLength(50);
        builder.Property(p => p.Observacions).HasMaxLength(50);
    }
}
