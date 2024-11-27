using AquaProWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaProWeb.Infrastructure.Configurations;

public class EmpresaConfiguration : IEntityTypeConfiguration<Empresa>
{
    public void Configure(EntityTypeBuilder<Empresa> builder)
    {
        builder.Property(p => p.NomEmpresa).IsRequired().HasMaxLength(100);
        builder.Property(p => p.CIF).IsRequired().HasMaxLength(12);
        builder.Property(p => p.Direccio).IsRequired().HasMaxLength(100);
        builder.Property(p => p.CP).IsRequired().HasMaxLength(7);
        builder.Property(p => p.Poblacio).IsRequired().HasMaxLength(50);
        builder.Property(p => p.Provincia).IsRequired().HasMaxLength(50);
        builder.Property(p => p.Telefon).HasMaxLength(12);
        builder.Property(p => p.Mobil).HasMaxLength(12);
        builder.Property(p => p.Email).HasMaxLength(100);
        builder.Property(p => p.WWW).HasMaxLength(100);
        builder.Property(p => p.Observacions).HasMaxLength(2000);
        builder.Property(p => p.NomCurtEmpresa).HasMaxLength(25);

    }
}
