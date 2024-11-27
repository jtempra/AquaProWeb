using AquaProWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaProWeb.Infrastructure.Configurations;

public class ContracteConfiguration
{
    public void Configure(EntityTypeBuilder<Contracte> builder)
    {
        builder.Property(p => p.Tipus).IsRequired();
        builder.Property(p => p.DataSolicitud).IsRequired();
        builder.Property(p => p.DataAlta).IsRequired();
        builder.Property(p => p.DataAltaFacturacio).IsRequired();
        builder.Property(p => p.Butlleti).HasMaxLength(25);
        builder.Property(p => p.Referencia).HasMaxLength(25);
        builder.Property(p => p.Cedula).HasMaxLength(25);
        builder.Property(p => p.Observacions).HasMaxLength(1000);
        builder.Property(p => p.PeriodeFacturacio).IsRequired();
        builder.Property(p => p.Idioma).IsRequired();
        builder.Property(p => p.TipusSubministrament).IsRequired();
        builder.Property(p => p.PropietatComptador).IsRequired();

        //builder.HasMany(c => c.TitularsContracte)
        //.WithOne(c => c.Contracte)
        //.HasForeignKey(i => i.ContracteId)
        //.OnDelete(DeleteBehavior.NoAction);
    }
}
