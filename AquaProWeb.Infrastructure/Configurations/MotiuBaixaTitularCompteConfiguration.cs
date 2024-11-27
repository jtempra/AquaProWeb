using AquaProWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaProWeb.Infrastructure.Configurations;

public class MotiuBaixaTitularCompteConfiguration : IEntityTypeConfiguration<MotiuBaixaTitularCompte>
{
    public void Configure(EntityTypeBuilder<MotiuBaixaTitularCompte> builder)
    {
        builder.Property(p => p.Motiu).HasMaxLength(255).IsRequired();
    }
}
