using AquaProWeb.Domain.Contracts;

namespace AquaProWeb.Domain.Entities
{
    public class ZonaFacturacio : BaseEntity
    {
        public string Zona { get; set; }
        public string Descripcio { get; set; }
        public string Observacions { get; set; }
    }
}
