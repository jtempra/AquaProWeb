using AquaProWeb.Domain.Contracts;

namespace AquaProWeb.Domain.Entities
{
    public class ZonaUbicacions : BaseEntity
    {
        public string Zona { get; set; }
        public string Descripcio { get; set; }
        public string Observacions { get; set; }
        public ICollection<Ubicacio> Ubicacions { get; set; }
    }
}
