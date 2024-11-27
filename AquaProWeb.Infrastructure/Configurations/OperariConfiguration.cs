using AquaProWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaProWeb.Infrastructure.Configurations;

public class OperariConfiguration : IEntityTypeConfiguration<Operari>
{
    public void Configure(EntityTypeBuilder<Operari> builder)
    {
        builder.Property(p => p.Nom).IsRequired().HasMaxLength(50);
        builder.Property(p => p.Mobil).HasMaxLength(15);
        builder.Property(p => p.Tipus).IsRequired();
        builder.Property(p => p.Observacions).HasMaxLength(255);


        builder.HasMany(e => e.ComptadorsAlta).WithOne().HasForeignKey(e => e.OperariInstalacioId).OnDelete(DeleteBehavior.NoAction);
        builder.HasMany(e => e.ComptadorsBaixa).WithOne().HasForeignKey(e => e.OperariBaixaId).OnDelete(DeleteBehavior.NoAction);
        builder.HasMany(e => e.OrdresTreballCreador).WithOne().HasForeignKey(e => e.CreadorId).OnDelete(DeleteBehavior.NoAction);
        builder.HasMany(e => e.OrdresTreballResponsable).WithOne().HasForeignKey(e => e.ResponsableId).OnDelete(DeleteBehavior.NoAction);
        builder.HasMany(e => e.OrdresTreballOperari).WithOne().HasForeignKey(e => e.OperariId).OnDelete(DeleteBehavior.NoAction);

    }
}
