using AquaProWeb.Domain.Contracts;

namespace AquaProWeb.Domain.Entities
{
    public class FamiliaConcepteFactura : BaseEntity
    {
        public string Familia { get; set; }
        public string Descripcio { get; set; }
        public string Observacions { get; set; }
        public ICollection<ConcepteFactura> ConceptesFactura { get; set; }
    }
}
