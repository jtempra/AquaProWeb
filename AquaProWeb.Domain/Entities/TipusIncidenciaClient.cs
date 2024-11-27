using AquaProWeb.Domain.Contracts;

namespace AquaProWeb.Domain.Entities
{
    public class TipusIncidenciaClient : BaseEntity
    {
        public string Tipus { get; set; }
        public string Descripcio { get; set; }
        public string Observacions { get; set; }
    }
}
