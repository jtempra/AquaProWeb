using AquaProWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaProWeb.Infrastructure.Configurations;

public class OrdreTreballConfiguration : IEntityTypeConfiguration<OrdreTreball>
{
    public void Configure(EntityTypeBuilder<OrdreTreball> builder)
    {
        builder.Property(p => p.Origen).IsRequired();
        builder.Property(p => p.DataCreacio).IsRequired();
        builder.Property(p => p.DataSituacio).IsRequired();
        builder.Property(p => p.Situacio).IsRequired();
        builder.Property(p => p.Descripcio).IsRequired().HasMaxLength(2000);
        builder.Property(p => p.Solucio).HasMaxLength(2000);
        builder.Property(p => p.Facturable).IsRequired();
        builder.Property(p => p.TallSubministrament).IsRequired();
        builder.Property(p => p.Ubicacio).HasMaxLength(255);
        builder.Property(p => p.Recurrent).IsRequired();
        builder.Property(p => p.EnviadaApp).IsRequired();



        builder.HasOne(e => e.Creador).WithMany().HasForeignKey(e => e.CreadorId).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(e => e.Responsable).WithMany().HasForeignKey(e => e.ResponsableId).OnDelete(DeleteBehavior.NoAction);
    }
}
