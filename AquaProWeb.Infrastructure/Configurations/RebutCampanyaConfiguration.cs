using AquaProWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaProWeb.Infrastructure.Configurations;
public class RebutCampanyaConfiguration : IEntityTypeConfiguration<RebutCampanya>
{
    public void Configure(EntityTypeBuilder<RebutCampanya> builder)
    {
        //builder.Property(p => p.CampanyaId).IsRequired();
        //builder.Property(p => p.NumRebut).IsRequired();
        //builder.Property(p => p.Estat).IsRequired();
        //builder.Property(p => p.SituacioRebut).IsRequired();
        builder.Property(p => p.Import).HasColumnType("decimal (18,2)");
        builder.Property(p => p.ImportDespeses).HasColumnType("decimal (18,2)");
        builder.Property(p => p.ImportCobrat).HasColumnType("decimal (18,2)");
    }
}
