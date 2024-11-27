using AquaProWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaProWeb.Infrastructure.Configurations;
public class ComponentConfiguration : IEntityTypeConfiguration<Component>
{
    public void Configure(EntityTypeBuilder<Component> builder)
    {
        builder.Property(p => p.Codi).IsRequired().HasMaxLength(50);
        builder.Property(p => p.Nom).IsRequired().HasMaxLength(255);
        builder.Property(p => p.Descripcio).IsRequired().HasMaxLength(1000);
        builder.Property(p => p.Observacions).HasMaxLength(2000);
    }

}
