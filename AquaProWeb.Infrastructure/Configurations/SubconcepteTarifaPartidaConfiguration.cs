using AquaProWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaProWeb.Infrastructure.Configurations;

public class SubconcepteTarifaPartidaConfiguration : IEntityTypeConfiguration<SubconcepteTarifaPartida>
{
    public void Configure(EntityTypeBuilder<SubconcepteTarifaPartida> builder)
    {
        builder.HasKey(p => new { p.SubconcepteTarifaId, p.PartidaId });
        builder.Property(p => p.Observacions).HasMaxLength(2000);
    }
}
