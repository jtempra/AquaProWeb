using AquaProWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaProWeb.Infrastructure.Configurations;

public class DocumentConfiguration : IEntityTypeConfiguration<Document>
{
    public void Configure(EntityTypeBuilder<Document> builder)
    {
        builder.Property(p => p.AutorCreacio).HasMaxLength(50);
        builder.Property(p => p.AutorModificacio).HasMaxLength(50);
        builder.Property(p => p.Descripcio).IsRequired().HasMaxLength(255);
        builder.Property(p => p.Observacions).HasMaxLength(2000);
        builder.Property(p => p.Ruta).IsRequired().HasMaxLength(255);
    }
}
