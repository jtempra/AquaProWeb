using AquaProWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaProWeb.Infrastructure.Configurations;
public class FacturaCampanyaConfiguration : IEntityTypeConfiguration<FacturaCampanya>
{
    public void Configure(EntityTypeBuilder<FacturaCampanya> builder)
    {
        //builder.Property(p => p.CampanyaId).IsRequired();
        //builder.Property(p => p.NumFactura).IsRequired();
        //builder.Property(p => p.Estat).IsRequired();
        //builder.Property(p => p.SituacioFactura).IsRequired();
        builder.Property(p => p.Import).HasColumnType("decimal (18,2)");
        builder.Property(p => p.ImportDespeses).HasColumnType("decimal (18,2)");
        builder.Property(p => p.ImportCobrat).HasColumnType("decimal (18,2)");
    }
}
