using AquaProWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaProWeb.Infrastructure.Configurations;

public class CampanyaConfiguration : IEntityTypeConfiguration<Campanya>
{
    public void Configure(EntityTypeBuilder<Campanya> builder)
    {
        builder.Property(p => p.Nom).IsRequired().HasMaxLength(50);
        builder.Property(p => p.DataCampanya).IsRequired();
        builder.Property(p => p.Descripcio).HasMaxLength(255);
        builder.Property(p => p.Observacions).HasMaxLength(2000);
    }
}
