using AquaProWeb.Domain.Contracts;

namespace AquaProWeb.Domain.Entities
{
    public class ServeiTarifa : BaseEntity
    {
        public string Servei { get; set; }
        public string Descripcio { get; set; }
        public string Observacions { get; set; }
        public ICollection<ConcepteTarifa> ConceptesTarifa { get; set; }
        public ICollection<TarifaServei> TarifesServei { get; set; }
    }
}
