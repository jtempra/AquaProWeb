using AquaProWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaProWeb.Infrastructure.Configurations;
public class TipusRequerimentTipusOrdreTreballConfiguration : IEntityTypeConfiguration<TipusRequerimentTipusOrdreTreball>
{
    public void Configure(EntityTypeBuilder<TipusRequerimentTipusOrdreTreball> builder)
    {
        builder.HasKey(p => new { p.TipusOrdreTreballId, p.TipusRequerimentOrdreTreballId });
    }
}
