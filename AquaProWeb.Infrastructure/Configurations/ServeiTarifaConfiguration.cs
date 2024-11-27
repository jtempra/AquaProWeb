using AquaProWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaProWeb.Infrastructure.Configurations;

public class ServeiTarifaConfiguration : IEntityTypeConfiguration<ServeiTarifa>
{
    public void Configure(EntityTypeBuilder<ServeiTarifa> builder)
    {
        builder.Property(p => p.Servei).IsRequired().HasMaxLength(50);
        builder.Property(p => p.Descripcio).HasMaxLength(255);
        builder.Property(p => p.Observacions).HasMaxLength(2000);
    }
}
