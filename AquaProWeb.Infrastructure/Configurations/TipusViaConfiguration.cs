using AquaProWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaProWeb.Infrastructure.Configurations;

public class TipusViaConfiguration : IEntityTypeConfiguration<TipusVia>
{
    public void Configure(EntityTypeBuilder<TipusVia> builder)
    {
        builder.Property(p => p.Codi).IsRequired().HasMaxLength(2);
        builder.Property(p => p.Descripcio).HasMaxLength(255);
        builder.Property(p => p.Observacions).HasMaxLength(2000);
    }
}
