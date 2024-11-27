using AquaProWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaProWeb.Infrastructure.Configurations;

public class PoblacioConfiguration : IEntityTypeConfiguration<Poblacio>
{
    public void Configure(EntityTypeBuilder<Poblacio> builder)
    {
        builder.Property(p => p.Nom).IsRequired().HasMaxLength(25);
        builder.Property(p => p.CodiINE).HasMaxLength(7);
        builder.Property(p => p.Observacions).HasMaxLength(255);
    }
}
