using AquaProWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaProWeb.Infrastructure.Configurations;

public class TitularContracteConfiguration : IEntityTypeConfiguration<TitularContracte>
{
    public void Configure(EntityTypeBuilder<TitularContracte> builder)
    {
        //builder.HasKey(tc => new { tc.ClientId, tc.ContracteId });
        builder.Property(tc => tc.DataAlta).IsRequired();
        //builder.Property(tc => tc.MotiuBaixa).IsRequired();
        builder.Property(tc => tc.Observacions).HasMaxLength(255);
    }
}
