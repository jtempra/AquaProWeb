using AquaProWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaProWeb.Infrastructure.Configurations;

public class FacturaConfiguration : IEntityTypeConfiguration<Factura>
{
    public void Configure(EntityTypeBuilder<Factura> builder)
    {
        builder.Property(p => p.Prefix).HasMaxLength(12);
        builder.Property(p => p.NumFactura).IsRequired().HasMaxLength(12);
        builder.Property(p => p.Postfix).HasMaxLength(12);
        builder.Property(p => p.DataFactura).IsRequired();
        builder.Property(p => p.DataSituacio).IsRequired();
        builder.Property(p => p.DataVenciment).IsRequired();
        builder.Property(p => p.FormaPagament).IsRequired();
        builder.Property(p => p.ModeFactura).IsRequired();
    }
}
