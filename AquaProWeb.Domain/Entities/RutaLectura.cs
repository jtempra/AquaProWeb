using AquaProWeb.Domain.Contracts;

namespace AquaProWeb.Domain.Entities
{
    public class RutaLectura : BaseEntity
    {
        public string Ruta { get; set; }
        public string Descripcio { get; set; }
        public string Observacions { get; set; }
    }
}
