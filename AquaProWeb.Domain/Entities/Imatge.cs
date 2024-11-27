using AquaProWeb.Domain.Contracts;

namespace AquaProWeb.Domain.Entities
{
    public class Imatge : BaseEntity
    {
        public string Descripcio { get; set; }
        public DateTime Data { get; set; }
        public string Ruta { get; set; }
        public string Observacions { get; set; }
    }
}
