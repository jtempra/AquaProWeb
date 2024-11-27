using AquaProWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaProWeb.Infrastructure.Configurations;

public class ContacteContracteConfiguration : IEntityTypeConfiguration<ContacteContracte>
{
    public void Configure(EntityTypeBuilder<ContacteContracte> builder)
    {
        //builder.HasKey(cc => new { cc.ContracteId, cc.ClientId });
        builder.Property(c => c.DataAlta).IsRequired();
        builder.Property(c => c.TipusContacte).IsRequired();
        builder.Property(c => c.Observacions).HasMaxLength(1000);

        //builder.HasMany(c => c.TitularsContracte)
        //.WithOne(c => c.Titular)
        //.HasForeignKey(i => i.ClientId)
        //.OnDelete(DeleteBehavior.Restrict);

        //builder.HasMany(c => c.TitularsContracte)
        //.WithOne(c => c.Contracte)
        //.HasForeignKey(i => i.ContracteId)
        //.OnDelete(DeleteBehavior.Restrict);
    }
}
