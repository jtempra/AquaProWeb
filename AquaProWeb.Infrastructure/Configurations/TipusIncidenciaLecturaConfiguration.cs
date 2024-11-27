using AquaProWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaProWeb.Infrastructure.Configurations;

public class TipusIncidenciaLecturaConfiguration : IEntityTypeConfiguration<TipusIncidenciaLectura>
{
    public void Configure(EntityTypeBuilder<TipusIncidenciaLectura> builder)
    {
        builder.Property(p => p.Tipus).IsRequired().HasMaxLength(50);
        builder.Property(p => p.ConsumApte).IsRequired();
        builder.Property(p => p.ConsumImputar).IsRequired();
        builder.Property(p => p.Opcio).IsRequired();
        builder.Property(p => p.Descripcio).HasMaxLength(255);
        builder.Property(p => p.Observacions).HasMaxLength(2000);
    }
}
