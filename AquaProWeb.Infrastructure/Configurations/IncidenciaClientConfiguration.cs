using AquaProWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaProWeb.Infrastructure.Configurations;

public class IncidenciaClientConfiguration : IEntityTypeConfiguration<IncidenciaClient>
{
    public void Configure(EntityTypeBuilder<IncidenciaClient> builder)
    {
        builder.Property(p => p.Incidencia).IsRequired().HasMaxLength(50);
        builder.Property(p => p.Descripcio).IsRequired().HasMaxLength(255);
    }
}
