using AquaProWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaProWeb.Infrastructure.Configurations;

public class LecturaConfiguration : IEntityTypeConfiguration<Lectura>
{
    public void Configure(EntityTypeBuilder<Lectura> builder)
    {
        builder.Property(p => p.Periode).IsRequired();
        builder.Property(p => p.Situacio).IsRequired();
        builder.Property(p => p.PeriodeFacturacio).IsRequired();
    }
}
