using AquaProWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaProWeb.Infrastructure.Configurations;

public class ConcepteTarifaConfiguration : IEntityTypeConfiguration<ConcepteTarifa>
{
    public void Configure(EntityTypeBuilder<ConcepteTarifa> builder)
    {
        builder.Property(p => p.Descripcio).IsRequired().HasMaxLength(100);
        builder.Property(p => p.Observacions).HasMaxLength(255);
        builder.Property(p => p.Actiu).IsRequired();
        builder.Property(p => p.Ordre).IsRequired();
        builder.Property(p => p.CodiComptable).HasMaxLength(50);
    }
}
