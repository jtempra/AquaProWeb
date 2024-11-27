using AquaProWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaProWeb.Infrastructure.Configurations;
public class DocumentCampanyaConfiguration : IEntityTypeConfiguration<DocumentCampanya>
{
    public void Configure(EntityTypeBuilder<DocumentCampanya> builder)
    {
        builder.Property(p => p.Import).HasColumnType("decimal (18,2)");
        builder.Property(p => p.ImportDespeses).HasColumnType("decimal (18,2)");
        builder.Property(p => p.ImportCobrat).HasColumnType("decimal (18,2)");
    }
}
