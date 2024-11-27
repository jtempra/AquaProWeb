using AquaProWeb.Infrastructure.ConfigEntities;
using Microsoft.EntityFrameworkCore;

namespace AquaProWeb.Infrastructure.Contexts;
public class ConfigDbContext : DbContext
{
    public ConfigDbContext(DbContextOptions<ConfigDbContext> options) : base(options)
    {

    }

    // Els tipus DateTime es mapejaran com Date en SQL Server
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<DateTime>().HaveColumnType("Date");
    }
    // Configurem els models segons els arxius de configuracio del assembly

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration<Columna>(new ColumnaConfiguration());
        modelBuilder.ApplyConfiguration<Taula>(new TaulaConfiguration());
        modelBuilder.ApplyConfiguration<Enumeracio>(new EnumeracioConfiguration());
        modelBuilder.ApplyConfiguration<ValorEnumeracio>(new ValorEnumeracioConfiguration());
    }


    // declarem els DbSets

    public DbSet<Taula> Taules
    {
        get; set;
    }
    public DbSet<Columna> Columnes
    {
        get; set;
    }

    public DbSet<Enumeracio> Enumeracions
    {
        get; set;
    }
    public DbSet<ValorEnumeracio> ValorsEnumeracions
    {
        get; set;
    }
    public DbSet<Usuari> Usuaris
    {
        get; set;
    }
}
