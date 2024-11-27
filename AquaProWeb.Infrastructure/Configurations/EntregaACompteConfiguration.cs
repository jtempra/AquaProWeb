using AquaProWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaProWeb.Infrastructure.Configurations;

public class EntregaACompteConfiguration : IEntityTypeConfiguration<EntregaACompte>
{
    public void Configure(EntityTypeBuilder<EntregaACompte> builder)
    {
        builder.Property(p => p.DataEntrega).IsRequired();
        builder.Property(p => p.Import).IsRequired().HasPrecision(18, 2);
        builder.Property(p => p.Observacions).HasMaxLength(2000);
    }
}
