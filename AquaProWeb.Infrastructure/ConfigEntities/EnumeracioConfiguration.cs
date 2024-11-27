using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaProWeb.Infrastructure.ConfigEntities;
public class ColumnaConfiguration : IEntityTypeConfiguration<Columna>
{
    public void Configure(EntityTypeBuilder<Columna> builder)
    {
        builder.Property(p => p.Propietat).IsRequired().HasMaxLength(50);
        builder.Property(p => p.Descripcio).HasMaxLength(255);
        builder.Property(p => p.TipusColumna).IsRequired();
        builder.Property(p => p.Amplada).IsRequired();
        builder.Property(p => p.Capçalera).HasMaxLength(50);
        builder.Property(p => p.Visible).IsRequired();
    }
}
