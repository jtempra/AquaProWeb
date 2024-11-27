using AquaProWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaProWeb.Infrastructure.Configurations;

public class CompteTransferenciaClientConfiguration : IEntityTypeConfiguration<CompteTransferenciaClient>
{
    public void Configure(EntityTypeBuilder<CompteTransferenciaClient> builder)
    {
        builder.Property(p => p.Descripcio).IsRequired().HasMaxLength(255);
        builder.Property(p => p.IBAN).IsRequired().HasMaxLength(35);
        builder.Property(p => p.BIC).HasMaxLength(11);
        builder.Property(p => p.Observacions).HasMaxLength(2000);
    }
}
