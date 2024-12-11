using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

namespace AquaProWeb.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Avisos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Usuari = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Missatge = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DataInici = table.Column<DateTime>(type: "Date", nullable: false),
                    DataFi = table.Column<DateTime>(type: "Date", nullable: false),
                    Importancia = table.Column<int>(type: "int", nullable: false),
                    EnviarEmail = table.Column<bool>(type: "bit", nullable: false),
                    Emails = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avisos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CanalsCobrament",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Canal = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FormaPagament = table.Column<int>(type: "int", nullable: false),
                    Descripcio = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Observacions = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    BIC = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CanalsCobrament", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComptesRemesaBanc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcio = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IBAN = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    BIC = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Sufixe = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Activa = table.Column<bool>(type: "bit", nullable: false),
                    Observacions = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComptesRemesaBanc", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComptesTransferenciaClient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcio = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IBAN = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    BIC = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Activa = table.Column<bool>(type: "bit", nullable: false),
                    Observacions = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComptesTransferenciaClient", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConceptesCobrament",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Concepte = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcio = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Observacions = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    CodiComptable = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConceptesCobrament", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empreses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomEmpresa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CIF = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Direccio = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CP = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    Poblacio = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Provincia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    Mobil = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    WWW = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Observacions = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    NomCurtEmpresa = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empreses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enumeracio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcio = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enumeracio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Explotacions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codi = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Observacions = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Explotacions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FamiliesConcepteFactura",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Familia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcio = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Observacions = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamiliesConcepteFactura", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FamiliesContracte",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codi = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Familia = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcio = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Observacions = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamiliesContracte", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Imatges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcio = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Data = table.Column<DateTime>(type: "Date", nullable: false),
                    Ruta = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Observacions = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imatges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IncidenciesCreacioLectura",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContracteId = table.Column<int>(type: "int", nullable: false),
                    Periode = table.Column<int>(type: "int", nullable: false),
                    TipusIncidencia = table.Column<int>(type: "int", nullable: false),
                    DataIncidencia = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncidenciesCreacioLectura", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IncidenciesTecniques",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ubicacio = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Caracter = table.Column<int>(type: "int", nullable: false),
                    Descripcio = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Solucio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observacions = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    DataIncidencia = table.Column<DateTime>(type: "Date", nullable: false),
                    DataInici = table.Column<DateTime>(type: "Date", nullable: true),
                    DataFinal = table.Column<DateTime>(type: "Date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncidenciesTecniques", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MarquesComptadors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marca = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Fabricant = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Observacions = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarquesComptadors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MotiusBaixaComptador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Motiu = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Observacions = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotiusBaixaComptador", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MotiusBaixaCompte",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Motiu = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Observacions = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotiusBaixaCompte", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MotiusBaixaContacte",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Motiu = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Observacions = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotiusBaixaContacte", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MotiusBaixaTitular",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Motiu = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Observacions = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotiusBaixaTitular", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Operaris",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Mobil = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Tipus = table.Column<int>(type: "int", nullable: false),
                    Observacions = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operaris", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Paisos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codi = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    NomPais = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Observacions = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paisos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parametre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcio = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ValorNumeric = table.Column<double>(type: "float", nullable: true),
                    ValorString = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValorData = table.Column<DateTime>(type: "Date", nullable: true),
                    Observacions = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parametre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PartidesTarifa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Partida = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcio = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Observacions = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartidesTarifa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ramals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcio = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Observacions = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ramals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RutesLectura",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ruta = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcio = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Observacions = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RutesLectura", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SeriesFactura",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Serie = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Comptador = table.Column<int>(type: "int", nullable: false),
                    Prefix = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    Postfix = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    Descripcio = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Observacions = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeriesFactura", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SeriesRebut",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Serie = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Comptador = table.Column<int>(type: "int", nullable: false),
                    Prefix = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    Postfix = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    Descripcio = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Observacions = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeriesRebut", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServeisTarifa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Servei = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcio = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Observacions = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServeisTarifa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SituacionsAdministrativesOT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Situacio = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcio = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Observacions = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SituacionsAdministrativesOT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SituacionsFactura",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estat = table.Column<int>(type: "int", nullable: false),
                    Situacio = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcio = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Observacions = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SituacionsFactura", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SituacionsRebut",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estat = table.Column<int>(type: "int", nullable: false),
                    Situacio = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcio = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Observacions = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SituacionsRebut", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Taula",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcio = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Observacions = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Simbol = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taula", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipusBaixaClients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipusBaixa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observacions = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipusBaixaClients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipusCampanyes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcio = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Observacions = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipusCampanyes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipusClients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Observacions = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipusClients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipusComptadors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcio = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Observacions = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipusComptadors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipusConceptesFactura",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcio = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Observacions = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipusConceptesFactura", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipusDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcio = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Observacions = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipusDocuments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipusFactures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcio = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Observacions = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipusFactures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipusIncidenciesClient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcio = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Observacions = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipusIncidenciesClient", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipusIncidenciesContracte",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcio = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Observacions = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipusIncidenciesContracte", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipusIncidenciesLectura",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ConsumApte = table.Column<bool>(type: "bit", nullable: false),
                    ConsumImputar = table.Column<bool>(type: "bit", nullable: false),
                    Opcio = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Descripcio = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Observacions = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipusIncidenciesLectura", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipusIncidenciesTecnica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcio = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Observacions = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipusIncidenciesTecnica", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipusIncidenciesUbicacio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcio = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Observacions = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipusIncidenciesUbicacio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipusOrdresTreball",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcio = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Observacions = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipusOrdresTreball", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipusQueixes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcio = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Observacions = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipusQueixes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipusReclamacions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcio = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Observacions = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipusReclamacions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipusSuggeriment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcio = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Observacions = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipusSuggeriment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipusUbicacions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcio = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Observacions = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipusUbicacions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipusVies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codi = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Descripcio = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Observacions = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipusVies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsosContracte",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codi = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Us = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcio = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Observacions = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsosContracte", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuari",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Cognoms = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NomUsuari = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuari", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZonesCarrers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Zona = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcio = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Observacions = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZonesCarrers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZonesFacturacio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Zona = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcio = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Observacions = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZonesFacturacio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZonesOrdresTreball",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Zona = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcio = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Observacions = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZonesOrdresTreball", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZonesUbicacions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Zona = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcio = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Observacions = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZonesUbicacions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ValorEnumeracio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<int>(type: "int", nullable: false),
                    Descripcio = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EnumeracioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValorEnumeracio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ValorEnumeracio_Enumeracio_EnumeracioId",
                        column: x => x.EnumeracioId,
                        principalTable: "Enumeracio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Poblacions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    CodiINE = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true),
                    Observacions = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ExplotacioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poblacions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Poblacions_Explotacions_ExplotacioId",
                        column: x => x.ExplotacioId,
                        principalTable: "Explotacions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Escomeses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcio = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Observacions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiametreNominal = table.Column<float>(type: "real", nullable: false),
                    DiametreEscomesa = table.Column<float>(type: "real", nullable: false),
                    CoeficientCabdal = table.Column<float>(type: "real", nullable: false),
                    PressioDisseny = table.Column<float>(type: "real", nullable: false),
                    PressioMaximaDisseny = table.Column<float>(type: "real", nullable: false),
                    PressioFuncionamentAdmisible = table.Column<float>(type: "real", nullable: false),
                    PressioMaximaAdmisible = table.Column<float>(type: "real", nullable: false),
                    PressioAssaigAdmisible = table.Column<float>(type: "real", nullable: false),
                    PressioNominal = table.Column<float>(type: "real", nullable: false),
                    ValvulaPasIntegral = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RamalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Escomeses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Escomeses_Ramals_RamalId",
                        column: x => x.RamalId,
                        principalTable: "Ramals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConceptesTarifa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcio = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Observacions = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Actiu = table.Column<bool>(type: "bit", nullable: false),
                    Ordre = table.Column<int>(type: "int", nullable: false),
                    CodiComptable = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    ServeiTarifaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConceptesTarifa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConceptesTarifa_Empreses_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empreses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConceptesTarifa_ServeisTarifa_ServeiTarifaId",
                        column: x => x.ServeiTarifaId,
                        principalTable: "ServeisTarifa",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TarifesServei",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tarifa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcio = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Observacions = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ServeiTarifaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TarifesServei", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TarifesServei_ServeisTarifa_ServeiTarifaId",
                        column: x => x.ServeiTarifaId,
                        principalTable: "ServeisTarifa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FacturaCampanya",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampanyaId = table.Column<int>(type: "int", nullable: false),
                    NumFactura = table.Column<int>(type: "int", nullable: false),
                    Estat = table.Column<int>(type: "int", nullable: false),
                    SituacioFacturaId = table.Column<int>(type: "int", nullable: false),
                    Import = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImportDespeses = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImportCobrat = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacturaCampanya", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FacturaCampanya_SituacionsFactura_SituacioFacturaId",
                        column: x => x.SituacioFacturaId,
                        principalTable: "SituacionsFactura",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RebutCampanya",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampanyaId = table.Column<int>(type: "int", nullable: false),
                    NumRebut = table.Column<int>(type: "int", nullable: false),
                    Estat = table.Column<int>(type: "int", nullable: false),
                    SituacioRebutId = table.Column<int>(type: "int", nullable: false),
                    Import = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImportDespeses = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImportCobrat = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RebutCampanya", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RebutCampanya_SituacionsRebut_SituacioRebutId",
                        column: x => x.SituacioRebutId,
                        principalTable: "SituacionsRebut",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Columna",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Propietat = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Capçalera = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Descripcio = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TipusColumna = table.Column<int>(type: "int", nullable: false),
                    Amplada = table.Column<int>(type: "int", nullable: false),
                    Visible = table.Column<bool>(type: "bit", nullable: false),
                    TaulaId = table.Column<int>(type: "int", nullable: false),
                    Ordre = table.Column<int>(type: "int", nullable: false),
                    TaulaComboId = table.Column<int>(type: "int", nullable: true),
                    ColumnaComboId = table.Column<int>(type: "int", nullable: true),
                    EnumeracioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Columna", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Columna_Taula_TaulaId",
                        column: x => x.TaulaId,
                        principalTable: "Taula",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Campanyes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TipusCampanyaId = table.Column<int>(type: "int", nullable: false),
                    DataCampanya = table.Column<DateTime>(type: "Date", nullable: false),
                    Descripcio = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Observacions = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    DataInici = table.Column<DateTime>(type: "Date", nullable: true),
                    DataFinal = table.Column<DateTime>(type: "Date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campanyes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Campanyes_TipusCampanyes_TipusCampanyaId",
                        column: x => x.TipusCampanyaId,
                        principalTable: "TipusCampanyes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comptadors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codi = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Classe = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MarcaId = table.Column<int>(type: "int", nullable: false),
                    TipusComptadorId = table.Column<int>(type: "int", nullable: false),
                    Diametre = table.Column<int>(type: "int", nullable: false),
                    Digits = table.Column<int>(type: "int", nullable: false),
                    Microxip = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    DataCompra = table.Column<DateTime>(type: "Date", nullable: true),
                    DataBaixa = table.Column<DateTime>(type: "Date", nullable: true),
                    PeriodeRevisio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comptadors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comptadors_MarquesComptadors_MarcaId",
                        column: x => x.MarcaId,
                        principalTable: "MarquesComptadors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comptadors_TipusComptadors_TipusComptadorId",
                        column: x => x.TipusComptadorId,
                        principalTable: "TipusComptadors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConceptesFactura",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codi = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Descripcio = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Observacions = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    PVP = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    PreuCompra = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    PreuTarifa = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    PreuUltimaCompra = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Descompte = table.Column<double>(type: "float", nullable: false),
                    Unitat = table.Column<int>(type: "int", nullable: true),
                    FamiliaConcepteFacturaId = table.Column<int>(type: "int", nullable: false),
                    TipusConcepteFacturaId = table.Column<int>(type: "int", nullable: false),
                    Estoc = table.Column<double>(type: "float", nullable: false),
                    EstocMinim = table.Column<double>(type: "float", nullable: false),
                    CodiComptable = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Emmagatzemable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConceptesFactura", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConceptesFactura_FamiliesConcepteFactura_FamiliaConcepteFacturaId",
                        column: x => x.FamiliaConcepteFacturaId,
                        principalTable: "FamiliesConcepteFactura",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConceptesFactura_TipusConceptesFactura_TipusConcepteFacturaId",
                        column: x => x.TipusConcepteFacturaId,
                        principalTable: "TipusConceptesFactura",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IncidenciesUbicacio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Incidencia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TipusIncidenciaUbicacioId = table.Column<int>(type: "int", nullable: false),
                    Descripcio = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Observacions = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncidenciesUbicacio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IncidenciesUbicacio_TipusIncidenciesUbicacio_TipusIncidenciaUbicacioId",
                        column: x => x.TipusIncidenciaUbicacioId,
                        principalTable: "TipusIncidenciesUbicacio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TipusRequerimentTipusOrdreTreball",
                columns: table => new
                {
                    TipusOrdreTreballId = table.Column<int>(type: "int", nullable: false),
                    TipusRequerimentOrdreTreballId = table.Column<int>(type: "int", nullable: false),
                    Obligatori = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipusRequerimentTipusOrdreTreball", x => new { x.TipusOrdreTreballId, x.TipusRequerimentOrdreTreballId });
                    table.ForeignKey(
                        name: "FK_TipusRequerimentTipusOrdreTreball_TipusOrdresTreball_TipusOrdreTreballId",
                        column: x => x.TipusOrdreTreballId,
                        principalTable: "TipusOrdresTreball",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PrimerCognom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SegonCognom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TipusContacte = table.Column<int>(type: "int", nullable: false),
                    TipusClientId = table.Column<int>(type: "int", nullable: false),
                    TipusDocumentIdentificacio = table.Column<int>(type: "int", nullable: false),
                    DocumentIdentificacio = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    TipusViaId = table.Column<int>(type: "int", nullable: false),
                    Adressa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CodiPostal = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    Poblacio = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Provincia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PaisId = table.Column<int>(type: "int", nullable: false),
                    ResteAdressa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Telefon1 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Telefon2 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Telefon3 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Mobil1 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Mobil2 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Mobil3 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    EMail1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EMail2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EMail3 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Observacions = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IBAN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DataAlta = table.Column<DateTime>(type: "Date", nullable: false),
                    DataBaixa = table.Column<DateTime>(type: "Date", nullable: true),
                    RebCartes = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RebFactures = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RebRebuts = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_Paisos_PaisId",
                        column: x => x.PaisId,
                        principalTable: "Paisos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clients_TipusClients_TipusClientId",
                        column: x => x.TipusClientId,
                        principalTable: "TipusClients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clients_TipusVies_TipusViaId",
                        column: x => x.TipusViaId,
                        principalTable: "TipusVies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carrers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CodiPostal = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    Observacions = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PoblacioId = table.Column<int>(type: "int", nullable: false),
                    ZonaCarrersId = table.Column<int>(type: "int", nullable: false),
                    TipusViaId = table.Column<int>(type: "int", nullable: false),
                    CategoriaVia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carrers_Poblacions_PoblacioId",
                        column: x => x.PoblacioId,
                        principalTable: "Poblacions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Carrers_TipusVies_TipusViaId",
                        column: x => x.TipusViaId,
                        principalTable: "TipusVies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Carrers_ZonesCarrers_ZonaCarrersId",
                        column: x => x.ZonaCarrersId,
                        principalTable: "ZonesCarrers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Components",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Descripcio = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Observacions = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    EscomesaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Components", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Components_Escomeses_EscomesaId",
                        column: x => x.EscomesaId,
                        principalTable: "Escomeses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubconceptesTarifa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subconcepte = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Versio = table.Column<int>(type: "int", nullable: false),
                    Descripcio = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Valor = table.Column<double>(type: "float", nullable: false),
                    Minim = table.Column<double>(type: "float", nullable: false),
                    Exempt = table.Column<double>(type: "float", nullable: false),
                    Bonificacio = table.Column<double>(type: "float", nullable: false),
                    TipusSubconcepte = table.Column<int>(type: "int", nullable: false),
                    Taxa = table.Column<double>(type: "float", nullable: false),
                    PartidaAplicarId = table.Column<int>(type: "int", nullable: true),
                    DataAprovacio = table.Column<DateTime>(type: "Date", nullable: false),
                    DataAplicacio = table.Column<DateTime>(type: "Date", nullable: false),
                    DataCaducitat = table.Column<DateTime>(type: "Date", nullable: true),
                    Actiu = table.Column<bool>(type: "bit", nullable: false),
                    Unitats = table.Column<int>(type: "int", nullable: false),
                    Demora = table.Column<bool>(type: "bit", nullable: false),
                    Prorratejable = table.Column<bool>(type: "bit", nullable: false),
                    Periode = table.Column<int>(type: "int", nullable: false),
                    MultiplicaFactor = table.Column<bool>(type: "bit", nullable: false),
                    FactorCorreccio = table.Column<int>(type: "int", nullable: false),
                    ConcepteTarifaId = table.Column<int>(type: "int", nullable: false),
                    TarifaServeiId = table.Column<int>(type: "int", nullable: false),
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    FactorMultiplicadors = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FactorMultiplicador = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubconceptesTarifa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubconceptesTarifa_ConceptesTarifa_ConcepteTarifaId",
                        column: x => x.ConcepteTarifaId,
                        principalTable: "ConceptesTarifa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubconceptesTarifa_Empreses_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empreses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SubconceptesTarifa_PartidesTarifa_PartidaAplicarId",
                        column: x => x.PartidaAplicarId,
                        principalTable: "PartidesTarifa",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SubconceptesTarifa_TarifesServei_TarifaServeiId",
                        column: x => x.TarifaServeiId,
                        principalTable: "TarifesServei",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnotacionsCampanyes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcio = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CampanyaId = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "Date", nullable: false),
                    OperariId = table.Column<int>(type: "int", nullable: false),
                    Observacions = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnotacionsCampanyes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnotacionsCampanyes_Campanyes_CampanyaId",
                        column: x => x.CampanyaId,
                        principalTable: "Campanyes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnotacionsCampanyes_Operaris_OperariId",
                        column: x => x.OperariId,
                        principalTable: "Operaris",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IncidenciesClient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Incidencia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TipusIncidenciaClientId = table.Column<int>(type: "int", nullable: false),
                    Descripcio = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Observacions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncidenciesClient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IncidenciesClient_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_IncidenciesClient_TipusIncidenciesClient_TipusIncidenciaClientId",
                        column: x => x.TipusIncidenciaClientId,
                        principalTable: "TipusIncidenciesClient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SolicitudsAlta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    DataSolicitud = table.Column<DateTime>(type: "Date", nullable: false),
                    Solicitant = table.Column<int>(type: "int", nullable: false),
                    Situacio = table.Column<int>(type: "int", nullable: false),
                    DataSituacio = table.Column<DateTime>(type: "Date", nullable: false),
                    Observacions = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolicitudsAlta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SolicitudsAlta_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ubicacions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Bloc = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    Escala = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    Pis = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    Porta = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    ResteAdreça = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PosicioGeografica = table.Column<Point>(type: "geography", nullable: true),
                    Localitzacio = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ReferenciaCatastral = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Observacions = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    DataAlta = table.Column<DateTime>(type: "Date", nullable: true),
                    DataBaixa = table.Column<DateTime>(type: "Date", nullable: true),
                    TipusUbicacioId = table.Column<int>(type: "int", nullable: false),
                    ZonaUbicacioId = table.Column<int>(type: "int", nullable: false),
                    PoblacioId = table.Column<int>(type: "int", nullable: false),
                    CarrerId = table.Column<int>(type: "int", nullable: false),
                    EscomesaId = table.Column<int>(type: "int", nullable: false),
                    SituacioComptador = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RutaLecturaId = table.Column<int>(type: "int", nullable: false),
                    OrdreRutaLectura = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ubicacions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ubicacions_Carrers_CarrerId",
                        column: x => x.CarrerId,
                        principalTable: "Carrers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ubicacions_Escomeses_EscomesaId",
                        column: x => x.EscomesaId,
                        principalTable: "Escomeses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ubicacions_Poblacions_PoblacioId",
                        column: x => x.PoblacioId,
                        principalTable: "Poblacions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ubicacions_RutesLectura_RutaLecturaId",
                        column: x => x.RutaLecturaId,
                        principalTable: "RutesLectura",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ubicacions_TipusUbicacions_TipusUbicacioId",
                        column: x => x.TipusUbicacioId,
                        principalTable: "TipusUbicacions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ubicacions_ZonesUbicacions_ZonaUbicacioId",
                        column: x => x.ZonaUbicacioId,
                        principalTable: "ZonesUbicacions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BlocsTarifa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bloc = table.Column<int>(type: "int", nullable: false),
                    Descripcio = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Ordre = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<double>(type: "float", nullable: false),
                    Preu = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Actiu = table.Column<bool>(type: "bit", nullable: false),
                    M3Adicionals = table.Column<double>(type: "float", nullable: false),
                    Versio = table.Column<int>(type: "int", nullable: false),
                    SubconcepteTarifaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlocsTarifa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlocsTarifa_SubconceptesTarifa_SubconcepteTarifaId",
                        column: x => x.SubconcepteTarifaId,
                        principalTable: "SubconceptesTarifa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubconceptesTarifaPartida",
                columns: table => new
                {
                    SubconcepteTarifaId = table.Column<int>(type: "int", nullable: false),
                    PartidaId = table.Column<int>(type: "int", nullable: false),
                    Observacions = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubconceptesTarifaPartida", x => new { x.SubconcepteTarifaId, x.PartidaId });
                    table.ForeignKey(
                        name: "FK_SubconceptesTarifaPartida_PartidesTarifa_PartidaId",
                        column: x => x.PartidaId,
                        principalTable: "PartidesTarifa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubconceptesTarifaPartida_SubconceptesTarifa_SubconcepteTarifaId",
                        column: x => x.SubconcepteTarifaId,
                        principalTable: "SubconceptesTarifa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComptadorsUbicacio",
                columns: table => new
                {
                    UbicacioId = table.Column<int>(type: "int", nullable: false),
                    ComptadorId = table.Column<int>(type: "int", nullable: false),
                    DataInstalacio = table.Column<DateTime>(type: "Date", nullable: false),
                    OperariInstalacioId = table.Column<int>(type: "int", nullable: true),
                    DataBaixa = table.Column<DateTime>(type: "Date", nullable: true),
                    OperariBaixaId = table.Column<int>(type: "int", nullable: true),
                    Observacions = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    OperariId = table.Column<int>(type: "int", nullable: true),
                    OperariId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComptadorsUbicacio", x => new { x.ComptadorId, x.UbicacioId });
                    table.ForeignKey(
                        name: "FK_ComptadorsUbicacio_Comptadors_ComptadorId",
                        column: x => x.ComptadorId,
                        principalTable: "Comptadors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComptadorsUbicacio_Operaris_OperariBaixaId",
                        column: x => x.OperariBaixaId,
                        principalTable: "Operaris",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ComptadorsUbicacio_Operaris_OperariId",
                        column: x => x.OperariId,
                        principalTable: "Operaris",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ComptadorsUbicacio_Operaris_OperariId1",
                        column: x => x.OperariId1,
                        principalTable: "Operaris",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ComptadorsUbicacio_Operaris_OperariInstalacioId",
                        column: x => x.OperariInstalacioId,
                        principalTable: "Operaris",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ComptadorsUbicacio_Ubicacions_UbicacioId",
                        column: x => x.UbicacioId,
                        principalTable: "Ubicacions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contractes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UbicacioId = table.Column<int>(type: "int", nullable: false),
                    Tipus = table.Column<int>(type: "int", nullable: false),
                    DataSolicitud = table.Column<DateTime>(type: "Date", nullable: false),
                    DataAlta = table.Column<DateTime>(type: "Date", nullable: false),
                    DataAltaFacturacio = table.Column<DateTime>(type: "Date", nullable: false),
                    DataBaixa = table.Column<DateTime>(type: "Date", nullable: true),
                    DataVenciment = table.Column<DateTime>(type: "Date", nullable: true),
                    DuracioContracte = table.Column<int>(type: "int", nullable: false),
                    VolumContractat = table.Column<double>(type: "float", nullable: false),
                    PressioContractada = table.Column<double>(type: "float", nullable: false),
                    ConsumMinim = table.Column<double>(type: "float", nullable: false),
                    ConsumMaxim = table.Column<double>(type: "float", nullable: false),
                    ConsumPromig = table.Column<double>(type: "float", nullable: false),
                    ConsumCompensar = table.Column<double>(type: "float", nullable: false),
                    Butlleti = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataButlleti = table.Column<DateTime>(type: "Date", nullable: true),
                    Referencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataReferencia = table.Column<DateTime>(type: "Date", nullable: true),
                    Cedula = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataCedula = table.Column<DateTime>(type: "Date", nullable: true),
                    PeriodeFacturacio = table.Column<int>(type: "int", nullable: false),
                    Facturable = table.Column<bool>(type: "bit", nullable: false),
                    SubministramentTallat = table.Column<bool>(type: "bit", nullable: false),
                    DataTall = table.Column<DateTime>(type: "Date", nullable: true),
                    Tallable = table.Column<bool>(type: "bit", nullable: false),
                    Empleat = table.Column<bool>(type: "bit", nullable: false),
                    FamiliaId = table.Column<int>(type: "int", nullable: false),
                    UsId = table.Column<int>(type: "int", nullable: false),
                    Idioma = table.Column<int>(type: "int", nullable: false),
                    Observacions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Revisio = table.Column<int>(type: "int", nullable: false),
                    TipusSubministrament = table.Column<int>(type: "int", nullable: false),
                    PropietatComptador = table.Column<int>(type: "int", nullable: false),
                    ZonaFacturacioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contractes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contractes_FamiliesContracte_FamiliaId",
                        column: x => x.FamiliaId,
                        principalTable: "FamiliesContracte",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contractes_Ubicacions_UbicacioId",
                        column: x => x.UbicacioId,
                        principalTable: "Ubicacions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contractes_UsosContracte_UsId",
                        column: x => x.UsId,
                        principalTable: "UsosContracte",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contractes_ZonesFacturacio_ZonaFacturacioId",
                        column: x => x.ZonaFacturacioId,
                        principalTable: "ZonesFacturacio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnotacionsContractes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcio = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ContracteId = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "Date", nullable: false),
                    OperariId = table.Column<int>(type: "int", nullable: false),
                    Observacions = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnotacionsContractes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnotacionsContractes_Contractes_ContracteId",
                        column: x => x.ContracteId,
                        principalTable: "Contractes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnotacionsContractes_Operaris_OperariId",
                        column: x => x.OperariId,
                        principalTable: "Operaris",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartesCampanyes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampanyaId = table.Column<int>(type: "int", nullable: false),
                    ContracteId = table.Column<int>(type: "int", nullable: false),
                    RutaCarta = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Descripcio = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Observacions = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartesCampanyes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartesCampanyes_Campanyes_CampanyaId",
                        column: x => x.CampanyaId,
                        principalTable: "Campanyes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartesCampanyes_Contractes_ContracteId",
                        column: x => x.ContracteId,
                        principalTable: "Contractes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContactesContracte",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    ContracteId = table.Column<int>(type: "int", nullable: false),
                    DataAlta = table.Column<DateTime>(type: "Date", nullable: false),
                    DataBaixa = table.Column<DateTime>(type: "Date", nullable: true),
                    TipusContacte = table.Column<int>(type: "int", nullable: false),
                    MotiuBaixaContacteId = table.Column<int>(type: "int", nullable: true),
                    Observacions = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactesContracte", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactesContracte_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContactesContracte_Contractes_ContracteId",
                        column: x => x.ContracteId,
                        principalTable: "Contractes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ContactesContracte_MotiusBaixaContacte_MotiuBaixaContacteId",
                        column: x => x.MotiuBaixaContacteId,
                        principalTable: "MotiusBaixaContacte",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ContractesTarifaServei",
                columns: table => new
                {
                    ContracteId = table.Column<int>(type: "int", nullable: false),
                    TarifaServeiId = table.Column<int>(type: "int", nullable: false),
                    DataIniciTarifa = table.Column<DateTime>(type: "Date", nullable: false),
                    DataFiTarifa = table.Column<DateTime>(type: "Date", nullable: false),
                    Observacions = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractesTarifaServei", x => new { x.ContracteId, x.TarifaServeiId });
                    table.ForeignKey(
                        name: "FK_ContractesTarifaServei_Contractes_ContracteId",
                        column: x => x.ContracteId,
                        principalTable: "Contractes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContractesTarifaServei_TarifesServei_TarifaServeiId",
                        column: x => x.TarifaServeiId,
                        principalTable: "TarifesServei",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EntreguesACompte",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContracteId = table.Column<int>(type: "int", nullable: false),
                    DataEntrega = table.Column<DateTime>(type: "Date", nullable: false),
                    Import = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ConcepteCobramentId = table.Column<int>(type: "int", nullable: false),
                    Observacions = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntreguesACompte", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntreguesACompte_ConceptesCobrament_ConcepteCobramentId",
                        column: x => x.ConcepteCobramentId,
                        principalTable: "ConceptesCobrament",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntreguesACompte_Contractes_ContracteId",
                        column: x => x.ContracteId,
                        principalTable: "Contractes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IncidenciesContracte",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Incidencia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TipusIncidenciaContracteId = table.Column<int>(type: "int", nullable: false),
                    Descripcio = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Observacions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContracteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncidenciesContracte", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IncidenciesContracte_Contractes_ContracteId",
                        column: x => x.ContracteId,
                        principalTable: "Contractes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_IncidenciesContracte_TipusIncidenciesContracte_TipusIncidenciaContracteId",
                        column: x => x.TipusIncidenciaContracteId,
                        principalTable: "TipusIncidenciesContracte",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lectures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContracteId = table.Column<int>(type: "int", nullable: false),
                    Periode = table.Column<int>(type: "int", nullable: false),
                    Situacio = table.Column<int>(type: "int", nullable: false),
                    ConsumLectura = table.Column<double>(type: "float", nullable: false),
                    ConsumImputat = table.Column<double>(type: "float", nullable: false),
                    ConsumEstimat = table.Column<double>(type: "float", nullable: false),
                    RutaId = table.Column<int>(type: "int", nullable: false),
                    OrdreRuta = table.Column<int>(type: "int", nullable: false),
                    PeriodeFacturacio = table.Column<int>(type: "int", nullable: false),
                    Fuita = table.Column<bool>(type: "bit", nullable: false),
                    BonificarFuita = table.Column<bool>(type: "bit", nullable: false),
                    ConsumBonificarFuita = table.Column<double>(type: "float", nullable: false),
                    Observacions = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lectures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lectures_Contractes_ContracteId",
                        column: x => x.ContracteId,
                        principalTable: "Contractes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lectures_RutesLectura_RutaId",
                        column: x => x.RutaId,
                        principalTable: "RutesLectura",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "OrdresTreball",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContracteId = table.Column<int>(type: "int", nullable: true),
                    ClientId = table.Column<int>(type: "int", nullable: true),
                    TipusOrdreTreballId = table.Column<int>(type: "int", nullable: false),
                    Origen = table.Column<int>(type: "int", nullable: false),
                    DataCreacio = table.Column<DateTime>(type: "Date", nullable: false),
                    DataSituacio = table.Column<DateTime>(type: "Date", nullable: false),
                    CreadorId = table.Column<int>(type: "int", nullable: false),
                    ResponsableId = table.Column<int>(type: "int", nullable: false),
                    Situacio = table.Column<int>(type: "int", nullable: false),
                    SituacioAdministrativaOTId = table.Column<int>(type: "int", nullable: false),
                    Descripcio = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Solucio = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Facturable = table.Column<bool>(type: "bit", nullable: false),
                    TallSubministrament = table.Column<bool>(type: "bit", nullable: false),
                    Ubicacio = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ZonaOrdreTreballId = table.Column<int>(type: "int", nullable: false),
                    Prioritat = table.Column<int>(type: "int", nullable: false),
                    Geolocalitzacio = table.Column<Point>(type: "geography", nullable: true),
                    Recurrent = table.Column<bool>(type: "bit", nullable: false),
                    EnviadaApp = table.Column<bool>(type: "bit", nullable: false),
                    CampanyaId = table.Column<int>(type: "int", nullable: true),
                    OperariId = table.Column<int>(type: "int", nullable: true),
                    OperariId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdresTreball", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdresTreball_Campanyes_CampanyaId",
                        column: x => x.CampanyaId,
                        principalTable: "Campanyes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrdresTreball_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrdresTreball_Contractes_ContracteId",
                        column: x => x.ContracteId,
                        principalTable: "Contractes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrdresTreball_Operaris_CreadorId",
                        column: x => x.CreadorId,
                        principalTable: "Operaris",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrdresTreball_Operaris_OperariId",
                        column: x => x.OperariId,
                        principalTable: "Operaris",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrdresTreball_Operaris_OperariId1",
                        column: x => x.OperariId1,
                        principalTable: "Operaris",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrdresTreball_Operaris_ResponsableId",
                        column: x => x.ResponsableId,
                        principalTable: "Operaris",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrdresTreball_SituacionsAdministrativesOT_SituacioAdministrativaOTId",
                        column: x => x.SituacioAdministrativaOTId,
                        principalTable: "SituacionsAdministrativesOT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdresTreball_TipusOrdresTreball_TipusOrdreTreballId",
                        column: x => x.TipusOrdreTreballId,
                        principalTable: "TipusOrdresTreball",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdresTreball_ZonesOrdresTreball_ZonaOrdreTreballId",
                        column: x => x.ZonaOrdreTreballId,
                        principalTable: "ZonesOrdresTreball",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Queixes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContracteId = table.Column<int>(type: "int", nullable: false),
                    DataEntrada = table.Column<DateTime>(type: "Date", nullable: false),
                    TipusQueixaId = table.Column<int>(type: "int", nullable: false),
                    Situacio = table.Column<int>(type: "int", nullable: false),
                    DataSituacio = table.Column<DateTime>(type: "Date", nullable: false),
                    CanalEntrada = table.Column<int>(type: "int", nullable: false),
                    Descripcio = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Resposta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataResposta = table.Column<DateTime>(type: "Date", nullable: true),
                    DataLimitResolucio = table.Column<DateTime>(type: "Date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Queixes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Queixes_Contractes_ContracteId",
                        column: x => x.ContracteId,
                        principalTable: "Contractes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Queixes_TipusQueixes_TipusQueixaId",
                        column: x => x.TipusQueixaId,
                        principalTable: "TipusQueixes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rebuts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerieRebutId = table.Column<int>(type: "int", nullable: false),
                    Prefix = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    NumRebut = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Postfix = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    Periode = table.Column<int>(type: "int", nullable: false),
                    ContracteId = table.Column<int>(type: "int", nullable: false),
                    ClientFacturarId = table.Column<int>(type: "int", nullable: false),
                    ClientEnviamentId = table.Column<int>(type: "int", nullable: true),
                    ClientPagamentId = table.Column<int>(type: "int", nullable: true),
                    DataRebut = table.Column<DateTime>(type: "Date", nullable: false),
                    DataSituacio = table.Column<DateTime>(type: "Date", nullable: false),
                    DataVenciment = table.Column<DateTime>(type: "Date", nullable: false),
                    FormaPagament = table.Column<int>(type: "int", nullable: false),
                    ConcepteCobramentId = table.Column<int>(type: "int", nullable: false),
                    TipusRebut = table.Column<int>(type: "int", nullable: false),
                    RebutOriginalId = table.Column<int>(type: "int", nullable: true),
                    EstatRebut = table.Column<int>(type: "int", nullable: false),
                    SituacioRebutId = table.Column<int>(type: "int", nullable: false),
                    DataLecturaAnterior = table.Column<DateTime>(type: "Date", nullable: false),
                    DataLecturaActual = table.Column<DateTime>(type: "Date", nullable: false),
                    LecturaAnterior = table.Column<double>(type: "float", nullable: false),
                    LecturaActual = table.Column<double>(type: "float", nullable: false),
                    ConsumLectura = table.Column<double>(type: "float", nullable: false),
                    ConsumImputat = table.Column<double>(type: "float", nullable: false),
                    ConsumEstimat = table.Column<double>(type: "float", nullable: false),
                    ConsumFacturat = table.Column<double>(type: "float", nullable: false),
                    Comptador = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UbicacioId = table.Column<int>(type: "int", nullable: false),
                    ImportBaseImposable = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImportIVA = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImportCobrat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RebutId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rebuts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rebuts_Clients_ClientEnviamentId",
                        column: x => x.ClientEnviamentId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Rebuts_Clients_ClientFacturarId",
                        column: x => x.ClientFacturarId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rebuts_Clients_ClientPagamentId",
                        column: x => x.ClientPagamentId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Rebuts_ConceptesCobrament_ConcepteCobramentId",
                        column: x => x.ConcepteCobramentId,
                        principalTable: "ConceptesCobrament",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rebuts_Contractes_ContracteId",
                        column: x => x.ContracteId,
                        principalTable: "Contractes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Rebuts_Rebuts_RebutId",
                        column: x => x.RebutId,
                        principalTable: "Rebuts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Rebuts_Rebuts_RebutOriginalId",
                        column: x => x.RebutOriginalId,
                        principalTable: "Rebuts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rebuts_SituacionsRebut_SituacioRebutId",
                        column: x => x.SituacioRebutId,
                        principalTable: "SituacionsRebut",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rebuts_Ubicacions_UbicacioId",
                        column: x => x.UbicacioId,
                        principalTable: "Ubicacions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Reclamacions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContracteId = table.Column<int>(type: "int", nullable: false),
                    DataEntrada = table.Column<DateTime>(type: "Date", nullable: false),
                    TipusReclamacioId = table.Column<int>(type: "int", nullable: false),
                    Situacio = table.Column<int>(type: "int", nullable: false),
                    DataSituacio = table.Column<DateTime>(type: "Date", nullable: false),
                    CanalEntrada = table.Column<int>(type: "int", nullable: false),
                    Descripcio = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Resposta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataResposta = table.Column<DateTime>(type: "Date", nullable: false),
                    DataLimitResolucio = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reclamacions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reclamacions_Contractes_ContracteId",
                        column: x => x.ContracteId,
                        principalTable: "Contractes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reclamacions_TipusReclamacions_TipusReclamacioId",
                        column: x => x.TipusReclamacioId,
                        principalTable: "TipusReclamacions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SolicitudsBaixa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContracteId = table.Column<int>(type: "int", nullable: false),
                    DataSolicitud = table.Column<DateTime>(type: "Date", nullable: false),
                    TipusBaixaClientId = table.Column<int>(type: "int", nullable: false),
                    Solicitant = table.Column<int>(type: "int", nullable: false),
                    Situacio = table.Column<int>(type: "int", nullable: false),
                    DataSituacio = table.Column<DateTime>(type: "Date", nullable: false),
                    Observacions = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolicitudsBaixa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SolicitudsBaixa_Contractes_ContracteId",
                        column: x => x.ContracteId,
                        principalTable: "Contractes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SolicitudsBaixa_TipusBaixaClients_TipusBaixaClientId",
                        column: x => x.TipusBaixaClientId,
                        principalTable: "TipusBaixaClients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Suggeriments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContracteId = table.Column<int>(type: "int", nullable: false),
                    DataEntrada = table.Column<DateTime>(type: "Date", nullable: false),
                    TipusSuggerimentId = table.Column<int>(type: "int", nullable: false),
                    Situacio = table.Column<int>(type: "int", nullable: false),
                    DataSituacio = table.Column<DateTime>(type: "Date", nullable: false),
                    CanalEntrada = table.Column<int>(type: "int", nullable: false),
                    Descripcio = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Resposta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataResposta = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suggeriments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Suggeriments_Contractes_ContracteId",
                        column: x => x.ContracteId,
                        principalTable: "Contractes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Suggeriments_TipusSuggeriment_TipusSuggerimentId",
                        column: x => x.TipusSuggerimentId,
                        principalTable: "TipusSuggeriment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TitularsCompteContracte",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    IBAN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContracteId = table.Column<int>(type: "int", nullable: false),
                    DataAlta = table.Column<DateTime>(type: "Date", nullable: false),
                    DataBaixa = table.Column<DateTime>(type: "Date", nullable: true),
                    MotiuBaixaTitularCompteId = table.Column<int>(type: "int", nullable: true),
                    Observacions = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TitularsCompteContracte", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TitularsCompteContracte_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TitularsCompteContracte_Contractes_ContracteId",
                        column: x => x.ContracteId,
                        principalTable: "Contractes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TitularsCompteContracte_MotiusBaixaCompte_MotiuBaixaTitularCompteId",
                        column: x => x.MotiuBaixaTitularCompteId,
                        principalTable: "MotiusBaixaCompte",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TitularsContracte",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    ContracteId = table.Column<int>(type: "int", nullable: false),
                    DataAlta = table.Column<DateTime>(type: "Date", nullable: false),
                    DataBaixa = table.Column<DateTime>(type: "Date", nullable: true),
                    MotiuBaixaTitularId = table.Column<int>(type: "int", nullable: true),
                    Observacions = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TitularsContracte", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TitularsContracte_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TitularsContracte_Contractes_ContracteId",
                        column: x => x.ContracteId,
                        principalTable: "Contractes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TitularsContracte_MotiusBaixaTitular_MotiuBaixaTitularId",
                        column: x => x.MotiuBaixaTitularId,
                        principalTable: "MotiusBaixaTitular",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdDocument = table.Column<int>(type: "int", nullable: false),
                    ContracteId = table.Column<int>(type: "int", nullable: false),
                    AutorCreacio = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DataCreacio = table.Column<DateTime>(type: "Date", nullable: true),
                    AutorModificacio = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DataModificacio = table.Column<DateTime>(type: "Date", nullable: true),
                    Descripcio = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Observacions = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Ruta = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TipusDocumentId = table.Column<int>(type: "int", nullable: false),
                    AssociatA = table.Column<int>(type: "int", nullable: true),
                    DocumentAssociatId = table.Column<int>(type: "int", nullable: true),
                    LecturaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documents_Contractes_ContracteId",
                        column: x => x.ContracteId,
                        principalTable: "Contractes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Documents_Lectures_LecturaId",
                        column: x => x.LecturaId,
                        principalTable: "Lectures",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Documents_TipusDocuments_TipusDocumentId",
                        column: x => x.TipusDocumentId,
                        principalTable: "TipusDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LecturesComptador",
                columns: table => new
                {
                    LecturaId = table.Column<int>(type: "int", nullable: false),
                    ComptadorId = table.Column<int>(type: "int", nullable: false),
                    LecturaInicial = table.Column<double>(type: "float", nullable: false),
                    LecturaFinal = table.Column<double>(type: "float", nullable: false),
                    DataLecturaInicial = table.Column<DateTime>(type: "Date", nullable: true),
                    DataLecturaFinal = table.Column<DateTime>(type: "Date", nullable: true),
                    Tipus = table.Column<int>(type: "int", nullable: false),
                    OperariId = table.Column<int>(type: "int", nullable: false),
                    TipusIncidenciaLecturaId = table.Column<int>(type: "int", nullable: false),
                    IncidenciaComptador = table.Column<int>(type: "int", nullable: false),
                    IncidenciaConsum = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LecturesComptador", x => new { x.LecturaId, x.ComptadorId });
                    table.ForeignKey(
                        name: "FK_LecturesComptador_Comptadors_ComptadorId",
                        column: x => x.ComptadorId,
                        principalTable: "Comptadors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LecturesComptador_Lectures_LecturaId",
                        column: x => x.LecturaId,
                        principalTable: "Lectures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LecturesComptador_Operaris_OperariId",
                        column: x => x.OperariId,
                        principalTable: "Operaris",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LecturesComptador_TipusIncidenciesLectura_TipusIncidenciaLecturaId",
                        column: x => x.TipusIncidenciaLecturaId,
                        principalTable: "TipusIncidenciesLectura",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnotacionsOrdresTreball",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcio = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    OrdreTreballId = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "Date", nullable: false),
                    OperariId = table.Column<int>(type: "int", nullable: false),
                    Observacions = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnotacionsOrdresTreball", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnotacionsOrdresTreball_Operaris_OperariId",
                        column: x => x.OperariId,
                        principalTable: "Operaris",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnotacionsOrdresTreball_OrdresTreball_OrdreTreballId",
                        column: x => x.OrdreTreballId,
                        principalTable: "OrdresTreball",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetallsOrdresTreball",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrdreTreballId = table.Column<int>(type: "int", nullable: false),
                    OperariId = table.Column<int>(type: "int", nullable: false),
                    ConcepteFacturaId = table.Column<int>(type: "int", nullable: true),
                    Descripcio = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Quantitat = table.Column<double>(type: "float", nullable: false),
                    PreuCost = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    PreuVenda = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Descompte = table.Column<double>(type: "float", nullable: false),
                    Taxa = table.Column<double>(type: "float", nullable: false),
                    DataConcepte = table.Column<DateTime>(type: "Date", nullable: false),
                    ActualitzatEstoc = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallsOrdresTreball", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetallsOrdresTreball_ConceptesFactura_ConcepteFacturaId",
                        column: x => x.ConcepteFacturaId,
                        principalTable: "ConceptesFactura",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DetallsOrdresTreball_Operaris_OperariId",
                        column: x => x.OperariId,
                        principalTable: "Operaris",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetallsOrdresTreball_OrdresTreball_OrdreTreballId",
                        column: x => x.OrdreTreballId,
                        principalTable: "OrdresTreball",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OperarisOrdre",
                columns: table => new
                {
                    OrdreTreballId = table.Column<int>(type: "int", nullable: false),
                    OperariId = table.Column<int>(type: "int", nullable: false),
                    OperariId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperarisOrdre", x => new { x.OrdreTreballId, x.OperariId });
                    table.ForeignKey(
                        name: "FK_OperarisOrdre_Operaris_OperariId",
                        column: x => x.OperariId,
                        principalTable: "Operaris",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OperarisOrdre_Operaris_OperariId1",
                        column: x => x.OperariId1,
                        principalTable: "Operaris",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OperarisOrdre_OrdresTreball_OrdreTreballId",
                        column: x => x.OrdreTreballId,
                        principalTable: "OrdresTreball",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnotacionsRebuts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcio = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    RebutId = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "Date", nullable: false),
                    OperariId = table.Column<int>(type: "int", nullable: false),
                    Observacions = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnotacionsRebuts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnotacionsRebuts_Operaris_OperariId",
                        column: x => x.OperariId,
                        principalTable: "Operaris",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnotacionsRebuts_Rebuts_RebutId",
                        column: x => x.RebutId,
                        principalTable: "Rebuts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetallRebut",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RebutId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallRebut", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetallRebut_Rebuts_RebutId",
                        column: x => x.RebutId,
                        principalTable: "Rebuts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Factures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerieFacturaId = table.Column<int>(type: "int", nullable: false),
                    Prefix = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    NumFactura = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Postfix = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    ContracteId = table.Column<int>(type: "int", nullable: true),
                    ClientFacturarId = table.Column<int>(type: "int", nullable: true),
                    ClientEnviamentId = table.Column<int>(type: "int", nullable: true),
                    ClientPagamentId = table.Column<int>(type: "int", nullable: true),
                    OperariId = table.Column<int>(type: "int", nullable: true),
                    FacturaOrigenId = table.Column<int>(type: "int", nullable: true),
                    RebutOrigenId = table.Column<int>(type: "int", nullable: true),
                    DataFactura = table.Column<DateTime>(type: "Date", nullable: false),
                    DataSituacio = table.Column<DateTime>(type: "Date", nullable: false),
                    DataVenciment = table.Column<DateTime>(type: "Date", nullable: false),
                    FormaPagament = table.Column<int>(type: "int", nullable: false),
                    ConcepteCobramentId = table.Column<int>(type: "int", nullable: false),
                    TipusFacturaId = table.Column<int>(type: "int", nullable: false),
                    ModeFactura = table.Column<int>(type: "int", nullable: false),
                    EstatFactura = table.Column<int>(type: "int", nullable: false),
                    SituacioFacturaId = table.Column<int>(type: "int", nullable: false),
                    OrdreTreballId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Factures_Clients_ClientEnviamentId",
                        column: x => x.ClientEnviamentId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Factures_Clients_ClientFacturarId",
                        column: x => x.ClientFacturarId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Factures_Clients_ClientPagamentId",
                        column: x => x.ClientPagamentId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Factures_ConceptesCobrament_ConcepteCobramentId",
                        column: x => x.ConcepteCobramentId,
                        principalTable: "ConceptesCobrament",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Factures_Contractes_ContracteId",
                        column: x => x.ContracteId,
                        principalTable: "Contractes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Factures_Factures_FacturaOrigenId",
                        column: x => x.FacturaOrigenId,
                        principalTable: "Factures",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Factures_Operaris_OperariId",
                        column: x => x.OperariId,
                        principalTable: "Operaris",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Factures_OrdresTreball_OrdreTreballId",
                        column: x => x.OrdreTreballId,
                        principalTable: "OrdresTreball",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Factures_Rebuts_RebutOrigenId",
                        column: x => x.RebutOrigenId,
                        principalTable: "Rebuts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Factures_SituacionsFactura_SituacioFacturaId",
                        column: x => x.SituacioFacturaId,
                        principalTable: "SituacionsFactura",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Factures_TipusFactures_TipusFacturaId",
                        column: x => x.TipusFacturaId,
                        principalTable: "TipusFactures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnotacionsFactures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcio = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FacturaId = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "Date", nullable: false),
                    OperariId = table.Column<int>(type: "int", nullable: false),
                    Observacions = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnotacionsFactures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnotacionsFactures_Factures_FacturaId",
                        column: x => x.FacturaId,
                        principalTable: "Factures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnotacionsFactures_Operaris_OperariId",
                        column: x => x.OperariId,
                        principalTable: "Operaris",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetallsFactura",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacturaId = table.Column<int>(type: "int", nullable: false),
                    ConcepteFacturaId = table.Column<int>(type: "int", nullable: true),
                    Descripcio = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Quantitat = table.Column<double>(type: "float", nullable: false),
                    Preu = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Descompte = table.Column<double>(type: "float", nullable: false),
                    Taxa = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallsFactura", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetallsFactura_ConceptesFactura_ConcepteFacturaId",
                        column: x => x.ConcepteFacturaId,
                        principalTable: "ConceptesFactura",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DetallsFactura_Factures_FacturaId",
                        column: x => x.FacturaId,
                        principalTable: "Factures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DocumentsCampanya",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampanyaId = table.Column<int>(type: "int", nullable: false),
                    TipusDocumentId = table.Column<int>(type: "int", nullable: true),
                    RebutId = table.Column<int>(type: "int", nullable: true),
                    SituacioRebutId = table.Column<int>(type: "int", nullable: true),
                    FacturaId = table.Column<int>(type: "int", nullable: true),
                    SituacioFacturaId = table.Column<int>(type: "int", nullable: true),
                    Import = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImportDespeses = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImportCobrat = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentsCampanya", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentsCampanya_Campanyes_CampanyaId",
                        column: x => x.CampanyaId,
                        principalTable: "Campanyes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocumentsCampanya_Factures_FacturaId",
                        column: x => x.FacturaId,
                        principalTable: "Factures",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DocumentsCampanya_Rebuts_RebutId",
                        column: x => x.RebutId,
                        principalTable: "Rebuts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DocumentsCampanya_SituacionsFactura_SituacioFacturaId",
                        column: x => x.SituacioFacturaId,
                        principalTable: "SituacionsFactura",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DocumentsCampanya_SituacionsRebut_SituacioRebutId",
                        column: x => x.SituacioRebutId,
                        principalTable: "SituacionsRebut",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DocumentsCampanya_TipusDocuments_TipusDocumentId",
                        column: x => x.TipusDocumentId,
                        principalTable: "TipusDocuments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnotacionsCampanyes_CampanyaId",
                table: "AnotacionsCampanyes",
                column: "CampanyaId");

            migrationBuilder.CreateIndex(
                name: "IX_AnotacionsCampanyes_OperariId",
                table: "AnotacionsCampanyes",
                column: "OperariId");

            migrationBuilder.CreateIndex(
                name: "IX_AnotacionsContractes_ContracteId",
                table: "AnotacionsContractes",
                column: "ContracteId");

            migrationBuilder.CreateIndex(
                name: "IX_AnotacionsContractes_OperariId",
                table: "AnotacionsContractes",
                column: "OperariId");

            migrationBuilder.CreateIndex(
                name: "IX_AnotacionsFactures_FacturaId",
                table: "AnotacionsFactures",
                column: "FacturaId");

            migrationBuilder.CreateIndex(
                name: "IX_AnotacionsFactures_OperariId",
                table: "AnotacionsFactures",
                column: "OperariId");

            migrationBuilder.CreateIndex(
                name: "IX_AnotacionsOrdresTreball_OperariId",
                table: "AnotacionsOrdresTreball",
                column: "OperariId");

            migrationBuilder.CreateIndex(
                name: "IX_AnotacionsOrdresTreball_OrdreTreballId",
                table: "AnotacionsOrdresTreball",
                column: "OrdreTreballId");

            migrationBuilder.CreateIndex(
                name: "IX_AnotacionsRebuts_OperariId",
                table: "AnotacionsRebuts",
                column: "OperariId");

            migrationBuilder.CreateIndex(
                name: "IX_AnotacionsRebuts_RebutId",
                table: "AnotacionsRebuts",
                column: "RebutId");

            migrationBuilder.CreateIndex(
                name: "IX_BlocsTarifa_SubconcepteTarifaId",
                table: "BlocsTarifa",
                column: "SubconcepteTarifaId");

            migrationBuilder.CreateIndex(
                name: "IX_Campanyes_TipusCampanyaId",
                table: "Campanyes",
                column: "TipusCampanyaId");

            migrationBuilder.CreateIndex(
                name: "IX_Carrers_PoblacioId",
                table: "Carrers",
                column: "PoblacioId");

            migrationBuilder.CreateIndex(
                name: "IX_Carrers_TipusViaId",
                table: "Carrers",
                column: "TipusViaId");

            migrationBuilder.CreateIndex(
                name: "IX_Carrers_ZonaCarrersId",
                table: "Carrers",
                column: "ZonaCarrersId");

            migrationBuilder.CreateIndex(
                name: "IX_CartesCampanyes_CampanyaId",
                table: "CartesCampanyes",
                column: "CampanyaId");

            migrationBuilder.CreateIndex(
                name: "IX_CartesCampanyes_ContracteId",
                table: "CartesCampanyes",
                column: "ContracteId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_PaisId",
                table: "Clients",
                column: "PaisId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_TipusClientId",
                table: "Clients",
                column: "TipusClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_TipusViaId",
                table: "Clients",
                column: "TipusViaId");

            migrationBuilder.CreateIndex(
                name: "IX_Columna_TaulaId",
                table: "Columna",
                column: "TaulaId");

            migrationBuilder.CreateIndex(
                name: "IX_Components_EscomesaId",
                table: "Components",
                column: "EscomesaId");

            migrationBuilder.CreateIndex(
                name: "IX_Comptadors_MarcaId",
                table: "Comptadors",
                column: "MarcaId");

            migrationBuilder.CreateIndex(
                name: "IX_Comptadors_TipusComptadorId",
                table: "Comptadors",
                column: "TipusComptadorId");

            migrationBuilder.CreateIndex(
                name: "IX_ComptadorsUbicacio_OperariBaixaId",
                table: "ComptadorsUbicacio",
                column: "OperariBaixaId");

            migrationBuilder.CreateIndex(
                name: "IX_ComptadorsUbicacio_OperariId",
                table: "ComptadorsUbicacio",
                column: "OperariId");

            migrationBuilder.CreateIndex(
                name: "IX_ComptadorsUbicacio_OperariId1",
                table: "ComptadorsUbicacio",
                column: "OperariId1");

            migrationBuilder.CreateIndex(
                name: "IX_ComptadorsUbicacio_OperariInstalacioId",
                table: "ComptadorsUbicacio",
                column: "OperariInstalacioId");

            migrationBuilder.CreateIndex(
                name: "IX_ComptadorsUbicacio_UbicacioId",
                table: "ComptadorsUbicacio",
                column: "UbicacioId");

            migrationBuilder.CreateIndex(
                name: "IX_ConceptesFactura_FamiliaConcepteFacturaId",
                table: "ConceptesFactura",
                column: "FamiliaConcepteFacturaId");

            migrationBuilder.CreateIndex(
                name: "IX_ConceptesFactura_TipusConcepteFacturaId",
                table: "ConceptesFactura",
                column: "TipusConcepteFacturaId");

            migrationBuilder.CreateIndex(
                name: "IX_ConceptesTarifa_EmpresaId",
                table: "ConceptesTarifa",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_ConceptesTarifa_ServeiTarifaId",
                table: "ConceptesTarifa",
                column: "ServeiTarifaId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactesContracte_ClientId",
                table: "ContactesContracte",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactesContracte_ContracteId",
                table: "ContactesContracte",
                column: "ContracteId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactesContracte_MotiuBaixaContacteId",
                table: "ContactesContracte",
                column: "MotiuBaixaContacteId");

            migrationBuilder.CreateIndex(
                name: "IX_Contractes_FamiliaId",
                table: "Contractes",
                column: "FamiliaId");

            migrationBuilder.CreateIndex(
                name: "IX_Contractes_UbicacioId",
                table: "Contractes",
                column: "UbicacioId");

            migrationBuilder.CreateIndex(
                name: "IX_Contractes_UsId",
                table: "Contractes",
                column: "UsId");

            migrationBuilder.CreateIndex(
                name: "IX_Contractes_ZonaFacturacioId",
                table: "Contractes",
                column: "ZonaFacturacioId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractesTarifaServei_TarifaServeiId",
                table: "ContractesTarifaServei",
                column: "TarifaServeiId");

            migrationBuilder.CreateIndex(
                name: "IX_DetallRebut_RebutId",
                table: "DetallRebut",
                column: "RebutId");

            migrationBuilder.CreateIndex(
                name: "IX_DetallsFactura_ConcepteFacturaId",
                table: "DetallsFactura",
                column: "ConcepteFacturaId");

            migrationBuilder.CreateIndex(
                name: "IX_DetallsFactura_FacturaId",
                table: "DetallsFactura",
                column: "FacturaId");

            migrationBuilder.CreateIndex(
                name: "IX_DetallsOrdresTreball_ConcepteFacturaId",
                table: "DetallsOrdresTreball",
                column: "ConcepteFacturaId");

            migrationBuilder.CreateIndex(
                name: "IX_DetallsOrdresTreball_OperariId",
                table: "DetallsOrdresTreball",
                column: "OperariId");

            migrationBuilder.CreateIndex(
                name: "IX_DetallsOrdresTreball_OrdreTreballId",
                table: "DetallsOrdresTreball",
                column: "OrdreTreballId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_ContracteId",
                table: "Documents",
                column: "ContracteId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_LecturaId",
                table: "Documents",
                column: "LecturaId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_TipusDocumentId",
                table: "Documents",
                column: "TipusDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentsCampanya_CampanyaId",
                table: "DocumentsCampanya",
                column: "CampanyaId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentsCampanya_FacturaId",
                table: "DocumentsCampanya",
                column: "FacturaId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentsCampanya_RebutId",
                table: "DocumentsCampanya",
                column: "RebutId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentsCampanya_SituacioFacturaId",
                table: "DocumentsCampanya",
                column: "SituacioFacturaId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentsCampanya_SituacioRebutId",
                table: "DocumentsCampanya",
                column: "SituacioRebutId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentsCampanya_TipusDocumentId",
                table: "DocumentsCampanya",
                column: "TipusDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_EntreguesACompte_ConcepteCobramentId",
                table: "EntreguesACompte",
                column: "ConcepteCobramentId");

            migrationBuilder.CreateIndex(
                name: "IX_EntreguesACompte_ContracteId",
                table: "EntreguesACompte",
                column: "ContracteId");

            migrationBuilder.CreateIndex(
                name: "IX_Escomeses_RamalId",
                table: "Escomeses",
                column: "RamalId");

            migrationBuilder.CreateIndex(
                name: "IX_FacturaCampanya_SituacioFacturaId",
                table: "FacturaCampanya",
                column: "SituacioFacturaId");

            migrationBuilder.CreateIndex(
                name: "IX_Factures_ClientEnviamentId",
                table: "Factures",
                column: "ClientEnviamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Factures_ClientFacturarId",
                table: "Factures",
                column: "ClientFacturarId");

            migrationBuilder.CreateIndex(
                name: "IX_Factures_ClientPagamentId",
                table: "Factures",
                column: "ClientPagamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Factures_ConcepteCobramentId",
                table: "Factures",
                column: "ConcepteCobramentId");

            migrationBuilder.CreateIndex(
                name: "IX_Factures_ContracteId",
                table: "Factures",
                column: "ContracteId");

            migrationBuilder.CreateIndex(
                name: "IX_Factures_FacturaOrigenId",
                table: "Factures",
                column: "FacturaOrigenId");

            migrationBuilder.CreateIndex(
                name: "IX_Factures_OperariId",
                table: "Factures",
                column: "OperariId");

            migrationBuilder.CreateIndex(
                name: "IX_Factures_OrdreTreballId",
                table: "Factures",
                column: "OrdreTreballId");

            migrationBuilder.CreateIndex(
                name: "IX_Factures_RebutOrigenId",
                table: "Factures",
                column: "RebutOrigenId");

            migrationBuilder.CreateIndex(
                name: "IX_Factures_SituacioFacturaId",
                table: "Factures",
                column: "SituacioFacturaId");

            migrationBuilder.CreateIndex(
                name: "IX_Factures_TipusFacturaId",
                table: "Factures",
                column: "TipusFacturaId");

            migrationBuilder.CreateIndex(
                name: "IX_IncidenciesClient_ClientId",
                table: "IncidenciesClient",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_IncidenciesClient_TipusIncidenciaClientId",
                table: "IncidenciesClient",
                column: "TipusIncidenciaClientId");

            migrationBuilder.CreateIndex(
                name: "IX_IncidenciesContracte_ContracteId",
                table: "IncidenciesContracte",
                column: "ContracteId");

            migrationBuilder.CreateIndex(
                name: "IX_IncidenciesContracte_TipusIncidenciaContracteId",
                table: "IncidenciesContracte",
                column: "TipusIncidenciaContracteId");

            migrationBuilder.CreateIndex(
                name: "IX_IncidenciesUbicacio_TipusIncidenciaUbicacioId",
                table: "IncidenciesUbicacio",
                column: "TipusIncidenciaUbicacioId");

            migrationBuilder.CreateIndex(
                name: "IX_Lectures_ContracteId",
                table: "Lectures",
                column: "ContracteId");

            migrationBuilder.CreateIndex(
                name: "IX_Lectures_RutaId",
                table: "Lectures",
                column: "RutaId");

            migrationBuilder.CreateIndex(
                name: "IX_LecturesComptador_ComptadorId",
                table: "LecturesComptador",
                column: "ComptadorId");

            migrationBuilder.CreateIndex(
                name: "IX_LecturesComptador_OperariId",
                table: "LecturesComptador",
                column: "OperariId");

            migrationBuilder.CreateIndex(
                name: "IX_LecturesComptador_TipusIncidenciaLecturaId",
                table: "LecturesComptador",
                column: "TipusIncidenciaLecturaId");

            migrationBuilder.CreateIndex(
                name: "IX_OperarisOrdre_OperariId",
                table: "OperarisOrdre",
                column: "OperariId");

            migrationBuilder.CreateIndex(
                name: "IX_OperarisOrdre_OperariId1",
                table: "OperarisOrdre",
                column: "OperariId1");

            migrationBuilder.CreateIndex(
                name: "IX_OrdresTreball_CampanyaId",
                table: "OrdresTreball",
                column: "CampanyaId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdresTreball_ClientId",
                table: "OrdresTreball",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdresTreball_ContracteId",
                table: "OrdresTreball",
                column: "ContracteId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdresTreball_CreadorId",
                table: "OrdresTreball",
                column: "CreadorId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdresTreball_OperariId",
                table: "OrdresTreball",
                column: "OperariId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdresTreball_OperariId1",
                table: "OrdresTreball",
                column: "OperariId1");

            migrationBuilder.CreateIndex(
                name: "IX_OrdresTreball_ResponsableId",
                table: "OrdresTreball",
                column: "ResponsableId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdresTreball_SituacioAdministrativaOTId",
                table: "OrdresTreball",
                column: "SituacioAdministrativaOTId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdresTreball_TipusOrdreTreballId",
                table: "OrdresTreball",
                column: "TipusOrdreTreballId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdresTreball_ZonaOrdreTreballId",
                table: "OrdresTreball",
                column: "ZonaOrdreTreballId");

            migrationBuilder.CreateIndex(
                name: "IX_Poblacions_ExplotacioId",
                table: "Poblacions",
                column: "ExplotacioId");

            migrationBuilder.CreateIndex(
                name: "IX_Queixes_ContracteId",
                table: "Queixes",
                column: "ContracteId");

            migrationBuilder.CreateIndex(
                name: "IX_Queixes_TipusQueixaId",
                table: "Queixes",
                column: "TipusQueixaId");

            migrationBuilder.CreateIndex(
                name: "IX_RebutCampanya_SituacioRebutId",
                table: "RebutCampanya",
                column: "SituacioRebutId");

            migrationBuilder.CreateIndex(
                name: "IX_Rebuts_ClientEnviamentId",
                table: "Rebuts",
                column: "ClientEnviamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Rebuts_ClientFacturarId",
                table: "Rebuts",
                column: "ClientFacturarId");

            migrationBuilder.CreateIndex(
                name: "IX_Rebuts_ClientPagamentId",
                table: "Rebuts",
                column: "ClientPagamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Rebuts_ConcepteCobramentId",
                table: "Rebuts",
                column: "ConcepteCobramentId");

            migrationBuilder.CreateIndex(
                name: "IX_Rebuts_ContracteId",
                table: "Rebuts",
                column: "ContracteId");

            migrationBuilder.CreateIndex(
                name: "IX_Rebuts_RebutId",
                table: "Rebuts",
                column: "RebutId");

            migrationBuilder.CreateIndex(
                name: "IX_Rebuts_RebutOriginalId",
                table: "Rebuts",
                column: "RebutOriginalId",
                unique: true,
                filter: "[RebutOriginalId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Rebuts_SituacioRebutId",
                table: "Rebuts",
                column: "SituacioRebutId");

            migrationBuilder.CreateIndex(
                name: "IX_Rebuts_UbicacioId",
                table: "Rebuts",
                column: "UbicacioId");

            migrationBuilder.CreateIndex(
                name: "IX_Reclamacions_ContracteId",
                table: "Reclamacions",
                column: "ContracteId");

            migrationBuilder.CreateIndex(
                name: "IX_Reclamacions_TipusReclamacioId",
                table: "Reclamacions",
                column: "TipusReclamacioId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudsAlta_ClientId",
                table: "SolicitudsAlta",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudsBaixa_ContracteId",
                table: "SolicitudsBaixa",
                column: "ContracteId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudsBaixa_TipusBaixaClientId",
                table: "SolicitudsBaixa",
                column: "TipusBaixaClientId");

            migrationBuilder.CreateIndex(
                name: "IX_SubconceptesTarifa_ConcepteTarifaId",
                table: "SubconceptesTarifa",
                column: "ConcepteTarifaId");

            migrationBuilder.CreateIndex(
                name: "IX_SubconceptesTarifa_EmpresaId",
                table: "SubconceptesTarifa",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_SubconceptesTarifa_PartidaAplicarId",
                table: "SubconceptesTarifa",
                column: "PartidaAplicarId");

            migrationBuilder.CreateIndex(
                name: "IX_SubconceptesTarifa_TarifaServeiId",
                table: "SubconceptesTarifa",
                column: "TarifaServeiId");

            migrationBuilder.CreateIndex(
                name: "IX_SubconceptesTarifaPartida_PartidaId",
                table: "SubconceptesTarifaPartida",
                column: "PartidaId");

            migrationBuilder.CreateIndex(
                name: "IX_Suggeriments_ContracteId",
                table: "Suggeriments",
                column: "ContracteId");

            migrationBuilder.CreateIndex(
                name: "IX_Suggeriments_TipusSuggerimentId",
                table: "Suggeriments",
                column: "TipusSuggerimentId");

            migrationBuilder.CreateIndex(
                name: "IX_TarifesServei_ServeiTarifaId",
                table: "TarifesServei",
                column: "ServeiTarifaId");

            migrationBuilder.CreateIndex(
                name: "IX_TitularsCompteContracte_ClientId",
                table: "TitularsCompteContracte",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_TitularsCompteContracte_ContracteId",
                table: "TitularsCompteContracte",
                column: "ContracteId");

            migrationBuilder.CreateIndex(
                name: "IX_TitularsCompteContracte_MotiuBaixaTitularCompteId",
                table: "TitularsCompteContracte",
                column: "MotiuBaixaTitularCompteId");

            migrationBuilder.CreateIndex(
                name: "IX_TitularsContracte_ClientId",
                table: "TitularsContracte",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_TitularsContracte_ContracteId",
                table: "TitularsContracte",
                column: "ContracteId");

            migrationBuilder.CreateIndex(
                name: "IX_TitularsContracte_MotiuBaixaTitularId",
                table: "TitularsContracte",
                column: "MotiuBaixaTitularId");

            migrationBuilder.CreateIndex(
                name: "IX_Ubicacions_CarrerId",
                table: "Ubicacions",
                column: "CarrerId");

            migrationBuilder.CreateIndex(
                name: "IX_Ubicacions_EscomesaId",
                table: "Ubicacions",
                column: "EscomesaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ubicacions_PoblacioId",
                table: "Ubicacions",
                column: "PoblacioId");

            migrationBuilder.CreateIndex(
                name: "IX_Ubicacions_RutaLecturaId",
                table: "Ubicacions",
                column: "RutaLecturaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ubicacions_TipusUbicacioId",
                table: "Ubicacions",
                column: "TipusUbicacioId");

            migrationBuilder.CreateIndex(
                name: "IX_Ubicacions_ZonaUbicacioId",
                table: "Ubicacions",
                column: "ZonaUbicacioId");

            migrationBuilder.CreateIndex(
                name: "IX_ValorEnumeracio_EnumeracioId",
                table: "ValorEnumeracio",
                column: "EnumeracioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnotacionsCampanyes");

            migrationBuilder.DropTable(
                name: "AnotacionsContractes");

            migrationBuilder.DropTable(
                name: "AnotacionsFactures");

            migrationBuilder.DropTable(
                name: "AnotacionsOrdresTreball");

            migrationBuilder.DropTable(
                name: "AnotacionsRebuts");

            migrationBuilder.DropTable(
                name: "Avisos");

            migrationBuilder.DropTable(
                name: "BlocsTarifa");

            migrationBuilder.DropTable(
                name: "CanalsCobrament");

            migrationBuilder.DropTable(
                name: "CartesCampanyes");

            migrationBuilder.DropTable(
                name: "Columna");

            migrationBuilder.DropTable(
                name: "Components");

            migrationBuilder.DropTable(
                name: "ComptadorsUbicacio");

            migrationBuilder.DropTable(
                name: "ComptesRemesaBanc");

            migrationBuilder.DropTable(
                name: "ComptesTransferenciaClient");

            migrationBuilder.DropTable(
                name: "ContactesContracte");

            migrationBuilder.DropTable(
                name: "ContractesTarifaServei");

            migrationBuilder.DropTable(
                name: "DetallRebut");

            migrationBuilder.DropTable(
                name: "DetallsFactura");

            migrationBuilder.DropTable(
                name: "DetallsOrdresTreball");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "DocumentsCampanya");

            migrationBuilder.DropTable(
                name: "EntreguesACompte");

            migrationBuilder.DropTable(
                name: "FacturaCampanya");

            migrationBuilder.DropTable(
                name: "Imatges");

            migrationBuilder.DropTable(
                name: "IncidenciesClient");

            migrationBuilder.DropTable(
                name: "IncidenciesContracte");

            migrationBuilder.DropTable(
                name: "IncidenciesCreacioLectura");

            migrationBuilder.DropTable(
                name: "IncidenciesTecniques");

            migrationBuilder.DropTable(
                name: "IncidenciesUbicacio");

            migrationBuilder.DropTable(
                name: "LecturesComptador");

            migrationBuilder.DropTable(
                name: "MotiusBaixaComptador");

            migrationBuilder.DropTable(
                name: "OperarisOrdre");

            migrationBuilder.DropTable(
                name: "Parametre");

            migrationBuilder.DropTable(
                name: "Queixes");

            migrationBuilder.DropTable(
                name: "RebutCampanya");

            migrationBuilder.DropTable(
                name: "Reclamacions");

            migrationBuilder.DropTable(
                name: "SeriesFactura");

            migrationBuilder.DropTable(
                name: "SeriesRebut");

            migrationBuilder.DropTable(
                name: "SolicitudsAlta");

            migrationBuilder.DropTable(
                name: "SolicitudsBaixa");

            migrationBuilder.DropTable(
                name: "SubconceptesTarifaPartida");

            migrationBuilder.DropTable(
                name: "Suggeriments");

            migrationBuilder.DropTable(
                name: "TipusIncidenciesTecnica");

            migrationBuilder.DropTable(
                name: "TipusRequerimentTipusOrdreTreball");

            migrationBuilder.DropTable(
                name: "TitularsCompteContracte");

            migrationBuilder.DropTable(
                name: "TitularsContracte");

            migrationBuilder.DropTable(
                name: "Usuari");

            migrationBuilder.DropTable(
                name: "ValorEnumeracio");

            migrationBuilder.DropTable(
                name: "Taula");

            migrationBuilder.DropTable(
                name: "MotiusBaixaContacte");

            migrationBuilder.DropTable(
                name: "ConceptesFactura");

            migrationBuilder.DropTable(
                name: "Factures");

            migrationBuilder.DropTable(
                name: "TipusDocuments");

            migrationBuilder.DropTable(
                name: "TipusIncidenciesClient");

            migrationBuilder.DropTable(
                name: "TipusIncidenciesContracte");

            migrationBuilder.DropTable(
                name: "TipusIncidenciesUbicacio");

            migrationBuilder.DropTable(
                name: "Comptadors");

            migrationBuilder.DropTable(
                name: "Lectures");

            migrationBuilder.DropTable(
                name: "TipusIncidenciesLectura");

            migrationBuilder.DropTable(
                name: "TipusQueixes");

            migrationBuilder.DropTable(
                name: "TipusReclamacions");

            migrationBuilder.DropTable(
                name: "TipusBaixaClients");

            migrationBuilder.DropTable(
                name: "SubconceptesTarifa");

            migrationBuilder.DropTable(
                name: "TipusSuggeriment");

            migrationBuilder.DropTable(
                name: "MotiusBaixaCompte");

            migrationBuilder.DropTable(
                name: "MotiusBaixaTitular");

            migrationBuilder.DropTable(
                name: "Enumeracio");

            migrationBuilder.DropTable(
                name: "FamiliesConcepteFactura");

            migrationBuilder.DropTable(
                name: "TipusConceptesFactura");

            migrationBuilder.DropTable(
                name: "OrdresTreball");

            migrationBuilder.DropTable(
                name: "Rebuts");

            migrationBuilder.DropTable(
                name: "SituacionsFactura");

            migrationBuilder.DropTable(
                name: "TipusFactures");

            migrationBuilder.DropTable(
                name: "MarquesComptadors");

            migrationBuilder.DropTable(
                name: "TipusComptadors");

            migrationBuilder.DropTable(
                name: "ConceptesTarifa");

            migrationBuilder.DropTable(
                name: "PartidesTarifa");

            migrationBuilder.DropTable(
                name: "TarifesServei");

            migrationBuilder.DropTable(
                name: "Campanyes");

            migrationBuilder.DropTable(
                name: "Operaris");

            migrationBuilder.DropTable(
                name: "SituacionsAdministrativesOT");

            migrationBuilder.DropTable(
                name: "TipusOrdresTreball");

            migrationBuilder.DropTable(
                name: "ZonesOrdresTreball");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "ConceptesCobrament");

            migrationBuilder.DropTable(
                name: "Contractes");

            migrationBuilder.DropTable(
                name: "SituacionsRebut");

            migrationBuilder.DropTable(
                name: "Empreses");

            migrationBuilder.DropTable(
                name: "ServeisTarifa");

            migrationBuilder.DropTable(
                name: "TipusCampanyes");

            migrationBuilder.DropTable(
                name: "Paisos");

            migrationBuilder.DropTable(
                name: "TipusClients");

            migrationBuilder.DropTable(
                name: "FamiliesContracte");

            migrationBuilder.DropTable(
                name: "Ubicacions");

            migrationBuilder.DropTable(
                name: "UsosContracte");

            migrationBuilder.DropTable(
                name: "ZonesFacturacio");

            migrationBuilder.DropTable(
                name: "Carrers");

            migrationBuilder.DropTable(
                name: "Escomeses");

            migrationBuilder.DropTable(
                name: "RutesLectura");

            migrationBuilder.DropTable(
                name: "TipusUbicacions");

            migrationBuilder.DropTable(
                name: "ZonesUbicacions");

            migrationBuilder.DropTable(
                name: "Poblacions");

            migrationBuilder.DropTable(
                name: "TipusVies");

            migrationBuilder.DropTable(
                name: "ZonesCarrers");

            migrationBuilder.DropTable(
                name: "Ramals");

            migrationBuilder.DropTable(
                name: "Explotacions");
        }
    }
}
