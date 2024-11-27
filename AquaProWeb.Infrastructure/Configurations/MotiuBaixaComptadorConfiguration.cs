using AquaProWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaProWeb.Infrastructure.Configurations;

public class MotiuBaixaComptadorConfiguration : IEntityTypeConfiguration<MotiuBaixaComptador>
{
    public void Configure(EntityTypeBuilder<MotiuBaixaComptador> builder)
    {
        builder.Property(p => p.Motiu).HasMaxLength(255).IsRequired();
    }
}
