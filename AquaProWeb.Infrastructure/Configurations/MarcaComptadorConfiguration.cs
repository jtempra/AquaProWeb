using AquaProWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaProWeb.Infrastructure.Configurations;

public class MarcaComptadorConfiguration : IEntityTypeConfiguration<MarcaComptador>
{
    public void Configure(EntityTypeBuilder<MarcaComptador> builder)
    {
        builder.Property(m => m.Marca).IsRequired().HasMaxLength(50);
        builder.Property(m => m.Fabricant).HasMaxLength(50);
        builder.Property(m => m.Observacions).HasMaxLength(255);

    }
}
