using AquaProWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaProWeb.Infrastructure.Configurations;

public class MotiuBaixaTitularCompteConfiguration : IEntityTypeConfiguration<MotiuBaixaCompte>
{
    public void Configure(EntityTypeBuilder<MotiuBaixaCompte> builder)
    {
        builder.Property(p => p.Motiu).HasMaxLength(255).IsRequired();
    }
}
