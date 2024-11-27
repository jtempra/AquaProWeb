using AquaProWeb.Common.Enums;
using AquaProWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AquaProWeb.Infrastructure.Configurations;

public class CarrerConfiguration : IEntityTypeConfiguration<Carrer>
{
    public void Configure(EntityTypeBuilder<Carrer> builder)
    {
        builder.Property(p => p.Nom).IsRequired().HasMaxLength(50);
        builder.Property(p => p.CodiPostal).IsRequired().HasMaxLength(7);
        builder.Property(p => p.Observacions).HasMaxLength(255);
        builder.Property(p => p.CategoriaVia).HasConversion(new EnumToNumberConverter<CategoriaVia, int>());
    }
}
