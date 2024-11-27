using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaProWeb.Infrastructure.ConfigEntities;
public class TaulaConfiguration : IEntityTypeConfiguration<Taula>
{
    public void Configure(EntityTypeBuilder<Taula> builder)
    {
        builder.Property(p => p.Nom).IsRequired().HasMaxLength(50);
        builder.Property(p => p.Descripcio).IsRequired().HasMaxLength(100);
        builder.Property(p => p.Observacions).HasMaxLength(255);

    }
}
