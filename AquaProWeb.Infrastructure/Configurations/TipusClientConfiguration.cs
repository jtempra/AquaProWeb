using AquaProWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaProWeb.Infrastructure.Configurations;

public class TipusClientConfiguration : IEntityTypeConfiguration<TipusClient>
{
    public void Configure(EntityTypeBuilder<TipusClient> builder)
    {
        builder.Property(t => t.Tipus).HasMaxLength(50).IsRequired();
        builder.Property(t => t.Observacions).HasMaxLength(255);

    }
}
