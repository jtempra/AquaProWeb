using AquaProWeb.Domain.Contracts;

namespace AquaProWeb.Domain.Entities
{
    public class SerieRebut : BaseEntity
    {
        public string Serie { get; set; }
        public int Comptador { get; set; }
        public string Prefix { get; set; }
        public string Postfix { get; set; }
        public string Descripcio { get; set; }
        public string Observacions { get; set; }
    }
}
