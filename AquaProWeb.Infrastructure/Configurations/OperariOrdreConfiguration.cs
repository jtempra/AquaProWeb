using AquaProWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaProWeb.Infrastructure.Configurations;

public class OperariOrdreConfiguration : IEntityTypeConfiguration<OperariOrdre>
{
    public void Configure(EntityTypeBuilder<OperariOrdre> builder)
    {
        builder.HasKey(p => new { p.OrdreTreballId, p.OperariId });
    }
}
