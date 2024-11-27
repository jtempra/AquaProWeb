using AquaProWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaProWeb.Infrastructure.Configurations;

public class CompteRemesaBancConfiguration : IEntityTypeConfiguration<CompteRemesaBanc>
{
    public void Configure(EntityTypeBuilder<CompteRemesaBanc> builder)
    {
        builder.Property(p => p.Descripcio).IsRequired().HasMaxLength(255);
        builder.Property(p => p.IBAN).IsRequired().HasMaxLength(35);
        builder.Property(p => p.Sufixe).IsRequired().HasMaxLength(3);
        builder.Property(p => p.BIC).HasMaxLength(11);
        builder.Property(p => p.Observacions).HasMaxLength(2000);
    }
}
