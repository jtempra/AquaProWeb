using AquaProWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaProWeb.Infrastructure.Configurations;

public class ConcepteCobramentConfiguration : IEntityTypeConfiguration<ConcepteCobrament>
{
    public void Configure(EntityTypeBuilder<ConcepteCobrament> builder)
    {
        builder.Property(p => p.Concepte).IsRequired().HasMaxLength(50);
        builder.Property(p => p.Descripcio).HasMaxLength(255);
        builder.Property(p => p.Observacions).HasMaxLength(2000);
        builder.Property(p => p.CodiComptable).HasMaxLength(50);
    }
}
