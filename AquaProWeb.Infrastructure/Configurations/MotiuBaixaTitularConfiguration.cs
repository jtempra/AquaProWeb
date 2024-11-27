using AquaProWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaProWeb.Infrastructure.Configurations;

public class MotiuBaixaTitularConfiguration : IEntityTypeConfiguration<MotiuBaixaTitular>
{
    public void Configure(EntityTypeBuilder<MotiuBaixaTitular> builder)
    {
        builder.Property(p => p.Motiu).HasMaxLength(255).IsRequired();
    }
}
