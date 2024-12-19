using AquaProWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaProWeb.Infrastructure.Configurations;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.Property(c => c.Nom).IsRequired().HasMaxLength(50);
        builder.Property(c => c.PrimerCognom).HasMaxLength(50);
        builder.Property(c => c.SegonCognom).HasMaxLength(50);
        builder.Ignore(c => c.NomSencer);
        builder.Property(c => c.TipusClientId).IsRequired();
        builder.Property(c => c.TipusDocumentIdentificacio).IsRequired();
        builder.Property(c => c.DocumentIdentificacio).IsRequired().HasMaxLength(12);
        builder.Property(c => c.Adressa).IsRequired().HasMaxLength(100);
        builder.Property(c => c.CodiPostal).IsRequired().HasMaxLength(7);
        builder.Property(c => c.Poblacio).IsRequired().HasMaxLength(50);
        builder.Property(c => c.Provincia).IsRequired().HasMaxLength(50);
        builder.Property(c => c.ResteAdressa).HasMaxLength(100);
        builder.Property(c => c.Telefon1).HasMaxLength(15);
        builder.Property(c => c.Telefon2).HasMaxLength(15);
        builder.Property(c => c.Telefon3).HasMaxLength(15);
        builder.Property(c => c.Mobil1).HasMaxLength(15);
        builder.Property(c => c.Mobil2).HasMaxLength(15);
        builder.Property(c => c.Mobil3).HasMaxLength(15);
        builder.Property(c => c.EMail1).HasMaxLength(100);
        builder.Property(c => c.EMail2).HasMaxLength(100);
        builder.Property(c => c.EMail3).HasMaxLength(100);
        builder.Property(c => c.IBAN).HasMaxLength(50);
        builder.Property(c => c.DataAlta).IsRequired();
        builder.Property(c => c.Observacions).HasMaxLength(255);
        builder.Property(c => c.RebCartes).HasDefaultValue(0);
        builder.Property(c => c.RebFactures).HasDefaultValue(0);
        builder.Property(c => c.RebRebuts).HasDefaultValue(0);

        //builder.HasMany(c => c.TitularsContracte)
        //.WithOne(c => c.Titular)
        //.HasForeignKey(i => i.ClientId)
        //.OnDelete(DeleteBehavior.NoAction);


    }
}
