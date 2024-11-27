using AquaProWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaProWeb.Infrastructure.Configurations;

internal class TitularCompteContracteConfiguration : IEntityTypeConfiguration<TitularCompteContracte>
{
    public void Configure(EntityTypeBuilder<TitularCompteContracte> builder)
    {
        builder.Property(t => t.DataAlta).IsRequired();

        builder.Property(t => t.Observacions).HasMaxLength(2000);
    }
}
