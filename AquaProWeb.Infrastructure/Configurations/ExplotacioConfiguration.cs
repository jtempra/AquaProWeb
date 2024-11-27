using AquaProWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaProWeb.Infrastructure.Configurations;

public class ExplotacioConfiguration : IEntityTypeConfiguration<Explotacio>
{
    public void Configure(EntityTypeBuilder<Explotacio> builder)
    {
        builder.Property(p => p.Codi).IsRequired().HasMaxLength(25);
        builder.Property(p => p.Nom).IsRequired().HasMaxLength(255);
    }
}
