using AquaProWeb.Domain.Contracts;

namespace AquaProWeb.Domain.Entities
{
    public class DetallFactura : BaseEntity
    {
        public int FacturaId { get; set; }
        public Factura Factura { get; set; }
        public int? ConcepteFacturaId { get; set; }
        public ConcepteFactura ConcepteFactura { get; set; }
        public string Descripcio { get; set; }
        public double Quantitat { get; set; } = 0;
        public decimal Preu { get; set; } = 0m;
        public double Descompte { get; set; } = 0;
        public double Taxa { get; set; } = 0;
        public decimal BaseImposable => (decimal)Quantitat * Preu;
        public decimal ImportDescompte => BaseImposable * (decimal)Descompte / 100m;
        public decimal ImportTaxa => (BaseImposable - ImportDescompte) * (decimal)Taxa / 100m;
        public decimal ImportTotal => Math.Round(BaseImposable - ImportDescompte + ImportTaxa, 2);

    }
}
