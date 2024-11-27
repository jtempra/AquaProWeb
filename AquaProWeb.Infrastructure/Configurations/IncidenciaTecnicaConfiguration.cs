using AquaProWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaProWeb.Infrastructure.Configurations;

public class IncidenciaTecnicaConfiguration : IEntityTypeConfiguration<IncidenciaTecnica>
{
    public void Configure(EntityTypeBuilder<IncidenciaTecnica> builder)
    {
        builder.Property(p => p.Ubicacio).IsRequired().HasMaxLength(2000);
        builder.Property(p => p.Caracter).IsRequired();
        builder.Property(p => p.Descripcio).IsRequired().HasMaxLength(2000);
        builder.Property(p => p.Observacions).HasMaxLength(2000);
        builder.Property(p => p.DataIncidencia).IsRequired();
    }
}
