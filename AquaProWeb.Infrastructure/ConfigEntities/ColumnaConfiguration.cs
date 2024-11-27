using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaProWeb.Infrastructure.ConfigEntities;
public class EnumeracioConfiguration : IEntityTypeConfiguration<Enumeracio>
{
    public void Configure(EntityTypeBuilder<Enumeracio> builder)
    {
        builder.Property(p => p.Descripcio).HasMaxLength(255);
    }
}
