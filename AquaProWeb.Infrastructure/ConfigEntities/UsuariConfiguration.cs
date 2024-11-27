using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaProWeb.Infrastructure.ConfigEntities;
public class UsuariConfiguration : IEntityTypeConfiguration<Usuari>
{
    public void Configure(EntityTypeBuilder<Usuari> builder)
    {
        builder.Property(p => p.Id).IsRequired();
        builder.Property(p => p.Nom).IsRequired().HasMaxLength(50);
        builder.Property(p => p.Cognoms).IsRequired().HasMaxLength(100);
        builder.Property(p => p.Email).IsRequired().HasMaxLength(100);
        builder.Property(p => p.NomUsuari).IsRequired().HasMaxLength(25);
        builder.Property(p => p.Password).IsRequired().HasMaxLength(25);
    }
}
