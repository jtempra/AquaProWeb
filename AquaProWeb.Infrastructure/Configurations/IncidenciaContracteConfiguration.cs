using AquaProWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaProWeb.Infrastructure.Configurations;

public class IncidenciaContracteConfiguration : IEntityTypeConfiguration<IncidenciaContracte>
{
    public void Configure(EntityTypeBuilder<IncidenciaContracte> builder)
    {
        builder.Property(p => p.Incidencia).IsRequired().HasMaxLength(50);
        builder.Property(p => p.Descripcio).IsRequired().HasMaxLength(255);
    }
}
