using AquaProWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaProWeb.Infrastructure.Configurations;

public class DetallOrdreTreballConfiguration : IEntityTypeConfiguration<DetallOrdreTreball>
{
    public void Configure(EntityTypeBuilder<DetallOrdreTreball> builder)
    {
        builder.Property(p => p.Descripcio).IsRequired().HasMaxLength(2000);
        builder.Property(p => p.PreuCost).HasPrecision(18, 2);
        builder.Property(p => p.PreuVenda).HasPrecision(18, 2);
        builder.Property(p => p.DataConcepte).IsRequired();
        builder.Property(p => p.ActualitzatEstoc).IsRequired();
    }
}
