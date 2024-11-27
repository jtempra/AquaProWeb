using AquaProWeb.Domain.Contracts;

namespace AquaProWeb.Domain.Entities
{
    public class TipusConcepteFactura : BaseEntity
    {
        public string Tipus { get; set; }
        public string Descripcio { get; set; }
        public string Observacions { get; set; }
        public ICollection<ConcepteFactura> ConceptesFactura { get; set; }
    }
}
