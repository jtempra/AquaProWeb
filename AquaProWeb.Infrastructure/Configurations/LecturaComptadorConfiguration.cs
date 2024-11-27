using AquaProWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaProWeb.Infrastructure.Configurations;

public class LecturaComptadorConfiguration : IEntityTypeConfiguration<LecturaComptador>
{
    public void Configure(EntityTypeBuilder<LecturaComptador> builder)
    {
        builder.HasKey(lc => new { lc.LecturaId, lc.ComptadorId });
        builder.Property(p => p.LecturaInicial).IsRequired();
        builder.Property(p => p.LecturaFinal).IsRequired();
        builder.Property(p => p.Tipus).IsRequired();
    }
}
