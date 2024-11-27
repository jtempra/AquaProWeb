using AquaProWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaProWeb.Infrastructure.Configurations;

public class ImatgeConfiguration : IEntityTypeConfiguration<Imatge>
{
    public void Configure(EntityTypeBuilder<Imatge> builder)
    {
        builder.Property(p => p.Descripcio).IsRequired().HasMaxLength(255);

        // no permeten Unicode (caracters raros), només caracters ASCII. Usarem varchar i no nvarchar (mes estalvi d'espai)
        builder.Property(p => p.Ruta).IsRequired().HasMaxLength(255).IsUnicode(false);
        builder.Property(p => p.Observacions).HasMaxLength(2000);
    }
}
