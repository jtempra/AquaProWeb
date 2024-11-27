using AquaProWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaProWeb.Infrastructure.Configurations;
public class PaisConfiguration : IEntityTypeConfiguration<Pais>
{
    public void Configure(EntityTypeBuilder<Pais> builder)
    {
        builder.Property(p => p.Codi).IsRequired().HasMaxLength(2);
        builder.Property(p => p.NomPais).HasMaxLength(100);
        builder.Property(p => p.Observacions).HasMaxLength(2000);
    }
}
