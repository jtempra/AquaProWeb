using AquaProWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaProWeb.Infrastructure.Configurations;

public class BlocTarifaConfiguration : IEntityTypeConfiguration<BlocTarifa>
{
    public void Configure(EntityTypeBuilder<BlocTarifa> builder)
    {
        builder.Property(p => p.Bloc).IsRequired();
        builder.Property(p => p.Descripcio).IsRequired().HasMaxLength(255);
        builder.Property(p => p.Ordre).IsRequired();
        builder.Property(p => p.Valor).IsRequired();
        builder.Property(p => p.Preu).HasPrecision(18, 2).IsRequired();
        builder.Property(p => p.Actiu).IsRequired();
        builder.Property(p => p.M3Adicionals).IsRequired();
    }
}
