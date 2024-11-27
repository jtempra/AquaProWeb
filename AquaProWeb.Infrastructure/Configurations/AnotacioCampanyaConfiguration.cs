using AquaProWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaProWeb.Infrastructure.Configurations;
public class AnotacioCampanyaConfiguration : IEntityTypeConfiguration<AnotacioCampanya>
{
    public void Configure(EntityTypeBuilder<AnotacioCampanya> builder)
    {
        builder.Property(p => p.Descripcio).IsRequired().HasMaxLength(255);
        builder.Property(p => p.Data).IsRequired();
        builder.Property(p => p.Observacions).HasMaxLength(1000);
    }
}
