using AquaProWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaProWeb.Infrastructure.Configurations;

public class RebutConfiguration : IEntityTypeConfiguration<Rebut>
{
    public void Configure(EntityTypeBuilder<Rebut> builder)
    {
        builder.Property(p => p.Prefix).HasMaxLength(12);
        builder.Property(p => p.NumRebut).IsRequired().HasMaxLength(12);
        builder.Property(p => p.Postfix).HasMaxLength(12);
        builder.Property(p => p.Periode).IsRequired();
        builder.Property(p => p.DataRebut).IsRequired();
        builder.Property(p => p.DataVenciment).IsRequired();
        builder.Property(p => p.DataSituacio).IsRequired();
        builder.Property(p => p.FormaPagament).IsRequired();
        builder.Property(p => p.TipusRebut).IsRequired();
        builder.Property(p => p.EstatRebut).IsRequired();
        builder.Property(p => p.LecturaActual).IsRequired();
        builder.Property(p => p.LecturaAnterior).IsRequired();
        builder.Property(p => p.ConsumEstimat).IsRequired();
        builder.Property(p => p.ConsumImputat).IsRequired();
        builder.Property(p => p.ConsumLectura).IsRequired();
        builder.Property(p => p.ConsumFacturat).IsRequired();

        builder.HasOne(p => p.RebutOriginal).WithOne()
            .HasForeignKey<Rebut>(p => p.RebutOriginalId).OnDelete(DeleteBehavior.Restrict);


    }
}
