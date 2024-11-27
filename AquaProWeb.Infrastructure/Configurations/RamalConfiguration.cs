using AquaProWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaProWeb.Infrastructure.Configurations;

public class RamalConfiguration : IEntityTypeConfiguration<Ramal>
{
    public void Configure(EntityTypeBuilder<Ramal> builder)
    {
        builder.Property(p => p.Nom).HasMaxLength(50).IsRequired();
        builder.Property(p => p.Descripcio).HasMaxLength(255).IsRequired();
        builder.Property(p => p.Observacions).HasMaxLength(2000);
    }
}
