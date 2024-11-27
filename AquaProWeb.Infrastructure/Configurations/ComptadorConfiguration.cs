using AquaProWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaProWeb.Infrastructure.Configurations;

public class ComptadorConfiguration : IEntityTypeConfiguration<Comptador>
{
    public void Configure(EntityTypeBuilder<Comptador> builder)
    {
        builder.Property(p => p.Codi).IsRequired().HasMaxLength(25);
        builder.Property(p => p.Model).IsRequired().HasMaxLength(50);
        builder.Property(p => p.Classe).IsRequired().HasMaxLength(50);
        builder.Property(p => p.Microxip).HasMaxLength(25);
        builder.Property(p => p.Digits).IsRequired();
    }
}
