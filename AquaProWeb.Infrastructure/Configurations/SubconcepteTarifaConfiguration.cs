using AquaProWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaProWeb.Infrastructure.Configurations;

public class SubconcepteTarifaConfiguration : IEntityTypeConfiguration<SubconcepteTarifa>
{
    public void Configure(EntityTypeBuilder<SubconcepteTarifa> builder)
    {
        builder.Property(p => p.Subconcepte).IsRequired().HasMaxLength(50);
        builder.Property(p => p.Versio).IsRequired();
        builder.Property(p => p.Descripcio).HasMaxLength(255);
        builder.Property(p => p.Valor).IsRequired();
        builder.Property(p => p.Minim).IsRequired();
        builder.Property(p => p.Exempt).IsRequired();
        builder.Property(p => p.Bonificacio).IsRequired();
        builder.Property(p => p.Taxa).IsRequired();
        builder.Property(p => p.DataAplicacio).IsRequired();
        builder.Property(p => p.DataAprovacio).IsRequired();
        builder.Property(p => p.Actiu).IsRequired();
        builder.Property(p => p.Demora).IsRequired();
        builder.Property(p => p.Periode).IsRequired();
        builder.Property(p => p.FactorMultiplicador).IsRequired();
    }
}
