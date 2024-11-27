using AquaProWeb.Domain.Contracts;

namespace AquaProWeb.Domain.Entities
{
    public class DetallOrdreTreball : BaseEntity
    {
        public int OrdreTreballId { get; set; }
        public OrdreTreball OrdreTreball { get; set; }
        public int OperariId { get; set; }
        public Operari Operari { get; set; }
        public int? ConcepteFacturaId { get; set; }
        public ConcepteFactura Concepte { get; set; }
        public string Descripcio { get; set; }
        public double Quantitat { get; set; } = 0;
        public decimal PreuCost { get; set; } = 0m;
        public decimal PreuVenda { get; set; } = 0m;
        public double Descompte { get; set; } = 0;
        public double Taxa { get; set; } = 0;
        public DateTime DataConcepte { get; set; }
        public Boolean ActualitzatEstoc { get; set; } = false;

    }
}
