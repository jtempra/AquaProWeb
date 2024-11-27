using AquaProWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaProWeb.Infrastructure.Configurations;

public class CanalCobramentConfiguration : IEntityTypeConfiguration<CanalCobrament>
{
    public void Configure(EntityTypeBuilder<CanalCobrament> builder)
    {
        builder.Property(p => p.Canal).IsRequired().HasMaxLength(100);
        builder.Property(p => p.FormaPagament).IsRequired();
        builder.Property(p => p.Descripcio).HasMaxLength(255);
        builder.Property(p => p.Observacions).HasMaxLength(1000);
        builder.Property(p => p.BIC).HasMaxLength(50);
    }
}
