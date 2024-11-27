using AquaProWeb.Domain.Contracts;
using AquaProWeb.Common.Enums;

namespace AquaProWeb.Domain.Entities
{
    public class Rebut : BaseEntity
    {
        public int SerieRebutId
        {
            get; set;
        }
        public string Prefix
        {
            get; set;
        }
        public string NumRebut
        {
            get; set;
        }
        public string Postfix
        {
            get; set;
        }
        public int Periode
        {
            get; set;
        }
        public int ContracteId
        {
            get; set;
        }
        public Contracte Contracte
        {
            get; set;
        }
        public int ClientFacturarId
        {
            get; set;
        }
        public Client ClientFacturar
        {
            get; set;
        }
        public int? ClientEnviamentId
        {
            get; set;
        }
        public Client ClientEnviament
        {
            get; set;
        }
        public int? ClientPagamentId
        {
            get; set;
        }
        public Client ClientPagament
        {
            get; set;
        }
        public DateTime DataRebut
        {
            get; set;
        }
        public DateTime DataSituacio
        {
            get; set;
        }
        public DateTime DataVenciment
        {
            get; set;
        }
        public FormaPagament FormaPagament { get; set; } = FormaPagament.Finestreta;
        public int ConcepteCobramentId
        {
            get; set;
        }
        public ConcepteCobrament ConcepteCobrament
        {
            get; set;
        }
        public TipusRebut TipusRebut
        {
            get; set;
        }
        public int? RebutOriginalId
        {
            get; set;
        }
        public Rebut RebutOriginal
        {
            get; set;
        }
        public EstatRebut EstatRebut { get; set; } = EstatRebut.Pendent;
        public int SituacioRebutId
        {
            get; set;
        }
        public SituacioRebut SituacioRebut
        {
            get; set;
        }
        public DateTime DataLecturaAnterior
        {
            get; set;
        }
        public DateTime DataLecturaActual
        {
            get; set;
        }
        public double LecturaAnterior { get; set; } = 0;
        public double LecturaActual { get; set; } = 0;
        public double ConsumLectura { get; set; } = 0;
        public double ConsumImputat { get; set; } = 0;
        public double ConsumEstimat { get; set; } = 0;
        public double ConsumFacturat { get; set; } = 0;
        public string Comptador
        {
            get; set;
        }
        public int UbicacioId
        {
            get; set;
        }
        public Ubicacio Ubicacio
        {
            get; set;
        }
        public decimal ImportBaseImposable { get; set; } = 0;
        public decimal ImportIVA { get; set; } = 0;
        public decimal ImportTotal => ImportBaseImposable + ImportIVA;
        public decimal ImportCobrat { get; set; } = 0;
        public decimal ImportPendent => ImportTotal - ImportCobrat;

        public List<DetallRebut> DetallRebut { get; set; } = new List<DetallRebut>();
        public List<Factura> FacturesAssociades { get; set; } = new List<Factura>();
        public List<Rebut> RebutsAssociats { get; set; } = new List<Rebut>();
        public List<AnotacioRebut> Anotacions { get; set; } = new List<AnotacioRebut>();
    }
}
