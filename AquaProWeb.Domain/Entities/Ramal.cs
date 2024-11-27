using AquaProWeb.Domain.Contracts;

namespace AquaProWeb.Domain.Entities
{
    public class Ramal : BaseEntity
    {
        public string Nom { get; set; }
        public string Descripcio { get; set; }
        public string Observacions { get; set; }
    }
}
