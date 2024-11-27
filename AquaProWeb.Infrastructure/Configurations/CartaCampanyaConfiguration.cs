using AquaProWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaProWeb.Infrastructure.Configurations;
public class CartaCampanyaConfiguration : IEntityTypeConfiguration<CartaCampanya>
{
    public void Configure(EntityTypeBuilder<CartaCampanya> builder)
    {
        builder.Property(p => p.CampanyaId).IsRequired();
        builder.Property(p => p.ContracteId).IsRequired();
        builder.Property(p => p.RutaCarta).IsRequired().HasMaxLength(255);
        builder.Property(p => p.Descripcio).HasMaxLength(255);
        builder.Property(p => p.Observacions).HasMaxLength(1000);
    }
}
