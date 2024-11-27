using AquaProWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaProWeb.Infrastructure.Configurations;

public class UbicacioConfiguration : IEntityTypeConfiguration<Ubicacio>
{
    public void Configure(EntityTypeBuilder<Ubicacio> builder)
    {
        builder.Property(p => p.Numero).IsRequired().HasMaxLength(12);
        builder.Property(p => p.Bloc).HasMaxLength(12);
        builder.Property(p => p.Escala).HasMaxLength(12);
        builder.Property(p => p.Pis).HasMaxLength(12);
        builder.Property(p => p.Porta).HasMaxLength(12);
        builder.Property(p => p.ResteAdreça).HasMaxLength(255);
        builder.Property(p => p.Localitzacio).HasMaxLength(255);
        builder.Property(p => p.ReferenciaCatastral).HasMaxLength(50);
        builder.Property(p => p.Observacions).HasMaxLength(2000);

        builder.HasOne(p => p.Poblacio)
        .WithMany(u => u.Ubicacions)
        .HasForeignKey(p => p.PoblacioId)
        .OnDelete(DeleteBehavior.Restrict);
    }
}
