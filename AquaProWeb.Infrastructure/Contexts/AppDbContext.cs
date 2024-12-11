using AquaProWeb.Domain.Contracts;
using AquaProWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AquaProWeb.Infrastructure.Contexts;
public class AppDbContext : DbContext
{

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    // Convencions generals:

    //Els tipus DateTime es mapejaran com Date en SQL Server
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<DateTime>().HaveColumnType("Date");

        configurationBuilder.Properties<Decimal>().HaveColumnType("decimal(18,2)");
    }

    //Configurem els models segons els arxius de configuracio del assembly

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        // un altre forma de mapejar un decimal a un decimal(18,2) en sql server
        //foreach (var property in modelBuilder.Model.GetEntityTypes().
        //             SelectMany(t => t.GetProperties()).Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
        //{
        //    property.SetColumnType("decimal(18,2)");
        //}

        //modelBuilder.Entity<Operari>(entity =>
        //{
        //    entity.HasMany(e => e.ComptadorsAlta).WithOne().HasForeignKey(e => e.OperariInstalacioId).OnDelete(DeleteBehavior.NoAction);
        //    entity.HasMany(e => e.ComptadorsBaixa).WithOne().HasForeignKey(e => e.OperariBaixaId).OnDelete(DeleteBehavior.NoAction);
        //    entity.HasMany(e => e.OrdresTreballCreador).WithOne().HasForeignKey(e => e.CreadorId).OnDelete(DeleteBehavior.NoAction);
        //    entity.HasMany(e => e.OrdresTreballResponsable).WithOne().HasForeignKey(e => e.ResponsableId).OnDelete(DeleteBehavior.NoAction);
        //    entity.HasMany(e => e.OrdresTreballOperari).WithOne().HasForeignKey(e => e.OperariId).OnDelete(DeleteBehavior.NoAction);
        //});

        modelBuilder.Entity<ComptadorUbicacio>(entity =>
        {
            entity.HasOne(e => e.OperariInstalacio).WithMany().HasForeignKey(e => e.OperariInstalacioId).OnDelete(DeleteBehavior.NoAction);
            entity.HasOne(e => e.OperariBaixa).WithMany().HasForeignKey(e => e.OperariBaixaId).OnDelete(DeleteBehavior.NoAction);
        });


        //modelBuilder.Entity<OrdreTreball>(entity =>
        //{
        //    entity.HasOne(e => e.Creador).WithMany().HasForeignKey(e => e.CreadorId).OnDelete(DeleteBehavior.NoAction);
        //    entity.HasOne(e => e.Responsable).WithMany().HasForeignKey(e => e.ResponsableId).OnDelete(DeleteBehavior.NoAction);
        //});

        //modelBuilder.Entity<ComptadorUbicacio>(entity =>
        //    entity.HasKey(cu => new { cu.ComptadorId, cu.UbicacioId }));

        //modelBuilder.Entity<ContacteContracte>(entity =>
        //    entity.HasKey(cu => new { cu.ClientId, cu.ContracteId }));

        //modelBuilder.Entity<ContracteTarifaServei>(entity =>
        //    entity.HasKey(cu => new { cu.ContracteId, cu.TarifaServeiId }));

        //modelBuilder.Entity<LecturaComptador>(entity =>
        //    entity.HasKey(cu => new { cu.LecturaId, cu.ComptadorId }));

        //modelBuilder.Entity<OperariOrdre>(entity =>
        //    entity.HasKey(cu => new { cu.OperariId, cu.OrdreTreballId }));

        //modelBuilder.Entity<SubconcepteTarifaPartida>(entity =>
        //    entity.HasKey(cu => new { cu.SubconcepteTarifaId, cu.PartidaId }));

        //modelBuilder.Entity<TitularContracte>(entity =>
        //    entity.HasKey(cu => new { cu.ClientId, cu.ContracteId }));
    }

    // auditoria nomes per les entitats auditables

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedDate = DateTime.Now;
                    entry.Entity.CreatedBy = "system";
                    break;

                case EntityState.Modified:
                    entry.Entity.LastModifiedDate = DateTime.Now;
                    entry.Entity.LastModifiedBy = "system";
                    break;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }

    // declarem els DbSets

    public DbSet<AnotacioContracte> AnotacionsContractes
    {
        get; set;
    }
    public DbSet<AnotacioRebut> AnotacionsRebuts
    {
        get; set;
    }
    public DbSet<AnotacioFactura> AnotacionsFactures
    {
        get; set;
    }
    public DbSet<AnotacioOrdreTreball> AnotacionsOrdresTreball
    {
        get; set;
    }

    public DbSet<AnotacioCampanya> AnotacionsCampanyes
    {
        get; set;
    }
    public DbSet<Avis> Avisos
    {
        get; set;
    }
    public DbSet<BlocTarifa> BlocsTarifa
    {
        get; set;
    }
    public DbSet<Campanya> Campanyes
    {
        get; set;
    }
    //public DbSet<RebutCampanya> RebutsCampanyes
    //{
    //    get; set;
    //}
    //public DbSet<FacturaCampanya> FacturesCampanyes
    //{
    //    get; set;
    //}
    public DbSet<CanalCobrament> CanalsCobrament
    {
        get; set;
    }
    public DbSet<Carrer> Carrers
    {
        get; set;
    }

    public DbSet<CartaCampanya> CartesCampanyes
    {
        get; set;
    }
    public DbSet<Client> Clients
    {
        get; set;
    }
    public DbSet<Comptador> Comptadors
    {
        get; set;
    }
    public DbSet<ComptadorUbicacio> ComptadorsUbicacio
    {
        get; set;
    }
    public DbSet<CompteRemesaBanc> ComptesRemesaBanc
    {
        get; set;
    }
    public DbSet<CompteTransferenciaClient> ComptesTransferenciaClient
    {
        get; set;
    }
    public DbSet<ConcepteCobrament> ConceptesCobrament
    {
        get; set;
    }
    public DbSet<ConcepteFactura> ConceptesFactura
    {
        get; set;
    }
    public DbSet<ConcepteTarifa> ConceptesTarifa
    {
        get; set;
    }
    public DbSet<ContacteContracte> ContactesContracte
    {
        get; set;
    }
    public DbSet<Contracte> Contractes
    {
        get; set;
    }
    public DbSet<ContracteTarifaServei> ContractesTarifaServei
    {
        get; set;
    }
    public DbSet<DetallFactura> DetallsFactura
    {
        get; set;
    }
    public DbSet<DetallOrdreTreball> DetallsOrdresTreball
    {
        get; set;
    }
    public DbSet<Document> Documents
    {
        get; set;
    }
    public DbSet<DocumentCampanya> DocumentsCampanya
    {
        get; set;
    }
    public DbSet<Empresa> Empreses
    {
        get; set;
    }
    public DbSet<EntregaACompte> EntreguesACompte
    {
        get; set;
    }
    public DbSet<Component> Components
    {
        get; set;
    }
    public DbSet<Escomesa> Escomeses
    {
        get; set;
    }
    public DbSet<Explotacio> Explotacions
    {
        get; set;
    }
    public DbSet<Factura> Factures
    {
        get; set;
    }
    public DbSet<FamiliaConcepteFactura> FamiliesConcepteFactura
    {
        get; set;
    }
    public DbSet<FamiliaContracte> FamiliesContracte
    {
        get; set;
    }
    public DbSet<Imatge> Imatges
    {
        get; set;
    }
    public DbSet<IncidenciaClient> IncidenciesClient
    {
        get; set;
    }
    public DbSet<IncidenciaContracte> IncidenciesContracte
    {
        get; set;
    }
    public DbSet<IncidenciaCreacioLectura> IncidenciesCreacioLectura
    {
        get; set;
    }
    public DbSet<IncidenciaTecnica> IncidenciesTecniques
    {
        get; set;
    }
    public DbSet<IncidenciaUbicacio> IncidenciesUbicacio
    {
        get; set;
    }
    public DbSet<Lectura> Lectures
    {
        get; set;
    }
    public DbSet<LecturaComptador> LecturesComptador
    {
        get; set;
    }
    public DbSet<MarcaComptador> MarquesComptadors
    {
        get; set;
    }
    public DbSet<MotiuBaixaTitular> MotiusBaixaTitular
    {
        get; set;
    }
    public DbSet<MotiuBaixaCompte> MotiusBaixaCompte
    {
        get; set;
    }
    public DbSet<MotiuBaixaContacte> MotiusBaixaContacte
    {
        get; set;
    }
    public DbSet<Operari> Operaris
    {
        get; set;
    }
    public DbSet<OperariOrdre> OperarisOrdre
    {
        get; set;
    }
    public DbSet<OrdreTreball> OrdresTreball
    {
        get; set;
    }
    public DbSet<Pais> Paisos
    {
        get; set;
    }
    public DbSet<PartidaTarifa> PartidesTarifa
    {
        get; set;
    }
    public DbSet<Poblacio> Poblacions
    {
        get; set;
    }
    public DbSet<Queixa> Queixes
    {
        get; set;
    }
    public DbSet<Ramal> Ramals
    {
        get; set;
    }
    public DbSet<Rebut> Rebuts
    {
        get; set;
    }
    public DbSet<Reclamacio> Reclamacions
    {
        get; set;
    }
    public DbSet<RutaLectura> RutesLectura
    {
        get; set;
    }
    public DbSet<SerieFactura> SeriesFactura
    {
        get; set;
    }
    public DbSet<SerieRebut> SeriesRebut
    {
        get; set;
    }
    public DbSet<ServeiTarifa> ServeisTarifa
    {
        get; set;
    }
    public DbSet<SituacioFactura> SituacionsFactura
    {
        get; set;
    }
    public DbSet<SituacioRebut> SituacionsRebut
    {
        get; set;
    }

    public DbSet<SituacioAdministrativaOT> SituacionsAdministrativesOT
    {
        get; set;
    }
    public DbSet<SolicitudAlta> SolicitudsAlta
    {
        get; set;
    }
    public DbSet<SolicitudBaixa> SolicitudsBaixa
    {
        get; set;
    }
    public DbSet<SubconcepteTarifa> SubconceptesTarifa
    {
        get; set;
    }
    public DbSet<SubconcepteTarifaPartida> SubconceptesTarifaPartida
    {
        get; set;
    }
    public DbSet<Suggeriment> Suggeriments
    {
        get; set;
    }
    public DbSet<TarifaServei> TarifesServei
    {
        get; set;
    }
    public DbSet<TipusBaixaClient> TipusBaixaClients
    {
        get; set;
    }
    public DbSet<TipusCampanya> TipusCampanyes
    {
        get; set;
    }
    public DbSet<TipusClient> TipusClients
    {
        get; set;
    }
    public DbSet<TipusComptador> TipusComptadors
    {
        get; set;
    }
    public DbSet<TipusConcepteFactura> TipusConceptesFactura
    {
        get; set;
    }
    public DbSet<TipusDocument> TipusDocuments
    {
        get; set;
    }
    public DbSet<TipusFactura> TipusFactures
    {
        get; set;
    }
    public DbSet<TipusIncidenciaClient> TipusIncidenciesClient
    {
        get; set;
    }
    public DbSet<TipusIncidenciaContracte> TipusIncidenciesContracte
    {
        get; set;
    }
    public DbSet<TipusIncidenciaLectura> TipusIncidenciesLectura
    {
        get; set;
    }
    public DbSet<TipusIncidenciaTecnica> TipusIncidenciesTecnica
    {
        get; set;
    }
    public DbSet<TipusIncidenciaUbicacio> TipusIncidenciesUbicacio
    {
        get; set;
    }
    public DbSet<TipusOrdreTreball> TipusOrdresTreball
    {
        get; set;
    }
    public DbSet<TipusQueixa> TipusQueixes
    {
        get; set;
    }
    public DbSet<TipusReclamacio> TipusReclamacions
    {
        get; set;
    }
    public DbSet<TipusSuggeriment> TipusSuggeriment
    {
        get; set;
    }
    public DbSet<TipusUbicacio> TipusUbicacions
    {
        get; set;
    }
    public DbSet<TipusVia> TipusVies
    {
        get; set;
    }
    public DbSet<TitularCompteContracte> TitularsCompteContracte
    {
        get; set;
    }
    public DbSet<TitularContracte> TitularsContracte
    {
        get; set;
    }
    public DbSet<Ubicacio> Ubicacions
    {
        get; set;
    }
    public DbSet<UsContracte> UsosContracte
    {
        get; set;
    }
    public DbSet<ZonaCarrers> ZonesCarrers
    {
        get; set;
    }
    public DbSet<ZonaFacturacio> ZonesFacturacio
    {
        get; set;
    }
    public DbSet<ZonaOrdreTreball> ZonesOrdresTreball
    {
        get; set;
    }
    public DbSet<ZonaUbicacio> ZonesUbicacions
    {
        get; set;
    }
    public DbSet<MotiuBaixaComptador> MotiusBaixaComptador
    {
        get; set;
    }
}
