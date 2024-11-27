using AquaProWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaProWeb.Infrastructure.Configurations;

public class QueixaConfiguration : IEntityTypeConfiguration<Queixa>
{
    public void Configure(EntityTypeBuilder<Queixa> builder)
    {
        builder.Property(p => p.DataEntrada).IsRequired();
        //builder.Property(p => p.Tipus).IsRequired();
        builder.Property(p => p.Situacio).IsRequired();
        builder.Property(p => p.DataSituacio).IsRequired();
        builder.Property(p => p.CanalEntrada).IsRequired();
        builder.Property(p => p.Descripcio).IsRequired().HasMaxLength(2000);
    }
}
