using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaProWeb.Infrastructure.ConfigEntities;
public class ValorEnumeracioConfiguration : IEntityTypeConfiguration<ValorEnumeracio>
{
    public void Configure(EntityTypeBuilder<ValorEnumeracio> builder)
    {
        builder.Property(p => p.Valor).IsRequired();
        builder.Property(p => p.Descripcio).IsRequired().HasMaxLength(100);

    }
}
