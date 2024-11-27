using AquaProWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaProWeb.Infrastructure.Configurations;

public class SituacioRebutConfiguration : IEntityTypeConfiguration<SituacioRebut>
{
    public void Configure(EntityTypeBuilder<SituacioRebut> builder)
    {
        builder.Property(p => p.Estat).IsRequired();
        builder.Property(p => p.Situacio).IsRequired().HasMaxLength(50);
        builder.Property(p => p.Descripcio).HasMaxLength(255);
        builder.Property(p => p.Observacions).HasMaxLength(2000);
    }
}
