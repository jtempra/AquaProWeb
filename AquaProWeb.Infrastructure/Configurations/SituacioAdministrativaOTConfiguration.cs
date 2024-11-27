using AquaProWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaProWeb.Infrastructure.Configurations;

public class SituacioAdministrativaOTConfiguration : IEntityTypeConfiguration<SituacioAdministrativaOT>
{
    public void Configure(EntityTypeBuilder<SituacioAdministrativaOT> builder)
    {
        builder.Property(p => p.Situacio).IsRequired().HasMaxLength(50);
        builder.Property(p => p.Descripcio).HasMaxLength(255);
        builder.Property(p => p.Observacions).HasMaxLength(2000);
    }
}
