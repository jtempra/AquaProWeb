using AquaProWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaProWeb.Infrastructure.Configurations;

public class ComptadorUbicacioConfiguration : IEntityTypeConfiguration<ComptadorUbicacio>
{
    public void Configure(EntityTypeBuilder<ComptadorUbicacio> builder)
    {
        builder.Property(p => p.DataInstalacio).IsRequired();
        builder.Property(p => p.Observacions).HasMaxLength(1000);

        builder.HasKey(p => new { p.ComptadorId, p.UbicacioId });


        //builder.HasOne(e => e.OperariInstalacio).WithMany().HasForeignKey(e => e.OperariInstalacioId).OnDelete(DeleteBehavior.NoAction);
        //builder.HasOne(e => e.OperariBaixa).WithMany().HasForeignKey(e => e.OperariBaixaId).OnDelete(DeleteBehavior.NoAction);
    }
}
