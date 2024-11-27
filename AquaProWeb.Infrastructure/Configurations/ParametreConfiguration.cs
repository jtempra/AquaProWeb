using AquaProWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaProWeb.Infrastructure.Configurations;
internal class ParametreConfiguration : IEntityTypeConfiguration<Parametre>
{
    public void Configure(EntityTypeBuilder<Parametre> builder)
    {
        builder.Property(p => p.Descripcio).IsRequired().HasMaxLength(100);

        builder.Property(p => p.Observacions).HasMaxLength(1000);
    }
}
