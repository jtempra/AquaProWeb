using AquaProWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaProWeb.Infrastructure.Configurations;

public class AvisConfiguration : IEntityTypeConfiguration<Avis>
{
    public void Configure(EntityTypeBuilder<Avis> builder)
    {
        builder.Property(p => p.Usuari).IsRequired().HasMaxLength(50);
        builder.Property(p => p.Missatge).IsRequired().HasMaxLength(255);
        builder.Property(p => p.DataInici).IsRequired();
        builder.Property(p => p.DataFi).IsRequired();
        builder.Property(p => p.Emails).HasMaxLength(1000);
    }
}
