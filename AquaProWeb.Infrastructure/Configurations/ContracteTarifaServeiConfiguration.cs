using AquaProWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaProWeb.Infrastructure.Configurations;

public class ContracteTarifaServeiConfiguration : IEntityTypeConfiguration<ContracteTarifaServei>
{
    public void Configure(EntityTypeBuilder<ContracteTarifaServei> builder)
    {
        builder.HasKey(p => new { p.ContracteId, p.TarifaServeiId });
        builder.Property(p => p.DataIniciTarifa).IsRequired();
        builder.Property(p => p.DataFiTarifa).IsRequired();
        builder.Property(p => p.Observacions).HasMaxLength(2000);
    }
}
