using AquaProWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaProWeb.Infrastructure.Configurations;

public class PartidaTarifaConfiguration : IEntityTypeConfiguration<PartidaTarifa>
{
    public void Configure(EntityTypeBuilder<PartidaTarifa> builder)
    {
        builder.Property(p => p.Partida).IsRequired().HasMaxLength(50);
        builder.Property(p => p.Descripcio).HasMaxLength(255);
        builder.Property(p => p.Observacions).HasMaxLength(2000);
    }
}
