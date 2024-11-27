using AquaProWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaProWeb.Infrastructure.Configurations;

public class MotiuBaixaContacteConfiguration : IEntityTypeConfiguration<MotiuBaixaContacte>
{
    public void Configure(EntityTypeBuilder<MotiuBaixaContacte> builder)
    {
        builder.Property(p => p.Motiu).HasMaxLength(255).IsRequired();
    }
}
