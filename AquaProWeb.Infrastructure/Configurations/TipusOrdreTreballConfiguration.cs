using AquaProWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaProWeb.Infrastructure.Configurations;

public class TipusOrdreTreballConfiguration : IEntityTypeConfiguration<TipusOrdreTreball>
{
    public void Configure(EntityTypeBuilder<TipusOrdreTreball> builder)
    {
        builder.Property(p => p.Tipus).IsRequired().HasMaxLength(50);
        builder.Property(p => p.Descripcio).HasMaxLength(255);
        builder.Property(p => p.Observacions).HasMaxLength(2000);
    }
}
