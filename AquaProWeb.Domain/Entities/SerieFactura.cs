using AquaProWeb.Domain.Contracts;

namespace AquaProWeb.Domain.Entities
{
    public class SerieFactura : BaseEntity
    {
        public string Serie { get; set; }
        public int Comptador { get; set; } = 1;
        public string Prefix { get; set; }
        public string Postfix { get; set; }
        public string Descripcio { get; set; }
        public string Observacions { get; set; }
    }
}
