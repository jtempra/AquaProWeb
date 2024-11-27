using AquaProWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaProWeb.Infrastructure.Configurations;

public class EscomesaConfiguration : IEntityTypeConfiguration<Escomesa>
{
    public void Configure(EntityTypeBuilder<Escomesa> builder)
    {
        builder.Property(p => p.Nom).IsRequired().HasMaxLength(50);
        builder.Property(p => p.Descripcio).IsRequired().HasMaxLength(255);
    }
}
