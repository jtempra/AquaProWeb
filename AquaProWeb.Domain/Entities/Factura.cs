using AquaProWeb.Domain.Contracts;
using AquaProWeb.Common.Enums;

namespace AquaProWeb.Domain.Entities
{
    public class Factura : BaseEntity
    {
        public int SerieFacturaId
        {
            get; set;
        }
        public string Prefix
        {
            get; set;
        }
        public string NumFactura
        {
            get; set;
        }
        public string Postfix
        {
            get; set;
        }
        public int? ContracteId
        {
            get; set;
        }
        public Contracte Contracte
        {
            get; set;
        }
        public int? ClientFacturarId
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
        public int? OperariId
        {
            get; set;
        }
        public Operari Operari
        {
            get; set;
        }
        public int? FacturaOrigenId
        {
            get; set;
        }
        public Factura FacturaOrigen
        {
            get; set;
        }
        public int? RebutOrigenId
        {
            get; set;
        }
        public Rebut RebutOrigen
        {
            get; set;
        }
        public DateTime DataFactura
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
        public int TipusFacturaId
        {
            get; set;
        }
        public TipusFactura TipusFactura
        {
            get; set;
        }
        public ModeFactura ModeFactura { get; set; } = ModeFactura.Factura;
        public EstatFactura EstatFactura { get; set; } = EstatFactura.Pendent;

        public int SituacioFacturaId
        {
            get; set;
        }
        public SituacioFactura SituacioFactura
        {
            get; set;
        }
        public List<DetallFactura> DetallFactura { get; set; } = new List<DetallFactura>();
        public List<Factura> FacturesAssociades { get; set; } = new List<Factura>();
        public List<AnotacioFactura> Anotacions { get; set; } = new List<AnotacioFactura>();
    }
}
