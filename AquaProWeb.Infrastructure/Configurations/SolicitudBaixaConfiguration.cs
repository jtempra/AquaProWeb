using AquaProWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaProWeb.Infrastructure.Configurations;

public class SolicitudBaixaConfiguration : IEntityTypeConfiguration<SolicitudBaixa>
{
    public void Configure(EntityTypeBuilder<SolicitudBaixa> builder)
    {
        builder.Property(p => p.DataSolicitud).IsRequired();
        //builder.Property(p => p.Motiu).IsRequired();
        builder.Property(p => p.Solicitant).IsRequired();
        builder.Property(p => p.Situacio).IsRequired();
        builder.Property(p => p.DataSituacio).IsRequired();
        builder.Property(p => p.Observacions).HasMaxLength(2000);
    }
}
